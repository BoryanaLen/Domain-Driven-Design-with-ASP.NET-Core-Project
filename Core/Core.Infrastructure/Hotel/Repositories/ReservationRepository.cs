namespace Core.Infrastructure.Hotel.Repositories
{
    using Application.Hotel.Reservations.Queries.HomePage;
    using AutoMapper;
    using Common.Application.Contracts;
    using Core.Application.Hotel.Reservations;
    using Core.Domain.Hotel.Factories.Reservations;
    using Core.Domain.Hotel.Models.Reservations;
    using Core.Domain.Hotel.Repositories.Customers;
    using Core.Domain.Hotel.Repositories.Reservations;
    using Core.Infrastructure.Persistence;
    using Core.Infrastructure.Persistence.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class ReservationRepository : DataRepository<IHotelDbContext, Reservation>,
        IReservationDomainRepository,
        IReservationQueryRepository
    {
        private readonly ICustomerDomainRepository customerRepository;
        private readonly IReservationFactory reservationFactory;
        private readonly ICurrentUser currentUser;
        private readonly IMapper mapper;

        public ReservationRepository(HotelSystemDbContext db, IMapper mapper,
            ICustomerDomainRepository customerRepository,
            ICurrentUser currentUser,
            IReservationFactory reservationFactory)
            : base(db)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
            this.reservationFactory = reservationFactory;
            this.currentUser = currentUser;
        }

        public IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes()
        {
            var roomTypes = this.Data
                .RoomTypes
                .ToList()
                .Select(x => new DetailsRoomTypeViewOutputModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    CapacityAdults = x.CapacityAdults,
                    CapacityKids = x.CapacityKids,
                    Image = x.Image,
                    Description = x.Description
                }).ToList();

            return roomTypes;
        }

        public IEnumerable<int> GetAllReservedRoomsId(DateTime checkIn, DateTime checkOut)
        {
            var reservationIds = this.Data.Reservations
                .Where(x => (x.StartDate >= checkIn && x.StartDate <= checkOut) || (x.EndDate >= checkIn && x.EndDate <= checkOut))
                .Select(x => x.Id)
                .ToList();

            var roomIds = this.Data.ReservationRooms
                .Where(x => reservationIds.Any(x2 => x2 == x.Id))
                .Select(x => x.Id)
                .ToList();

            return roomIds;
        }

        public IEnumerable<AvailableRoomViewModel> GetAllRooms()
        {
            var list = this.Data
                .Rooms
                .ToList();

            var rooms = list
                .Select(x => new AvailableRoomViewModel()
                {
                    Id = x.Id,
                    RoomNumber = x.RoomNumber,                  
                    Description = x.Description, 
                    RoomTypeId = x.RoomTypeId,
                }).ToList();

            foreach (var room in rooms)
            {
                var roomType = this.Data.RoomTypes
                    .FirstOrDefault(r => r.Id == room.RoomTypeId);

                room.RoomTypeName = roomType.Name;
                room.RoomTypeImage = roomType.Image;
                room.RoomTypePrice = roomType.Price;
                room.RoomTypeCapacityAdults = roomType.CapacityAdults;
                room.RoomTypeCapacityKids = roomType.CapacityKids;
            }

            return rooms;
        }

        public async Task<int> GetRoomTypeCapacityAdultsByIdAsync(int id)
        {
            var roomType = await this.Data
               .RoomTypes
               .FirstOrDefaultAsync(x => x.Id == id);

            return roomType.CapacityAdults;
        }

        public async Task<int> GetRoomTypeCapacityKidsByIdAsync(int id)
        {
            var roomType = await this.Data
               .RoomTypes
               .FirstOrDefaultAsync(x => x.Id == id);

            return roomType.CapacityKids;
        }

        public DetailsRoomViewOutputModel GetRoomViewModelById(int id)
        {
            var room = this.GetAllRooms()
                .Select(x => new DetailsRoomViewOutputModel()
                {
                    Id = x.Id,
                    RoomNumber = x.RoomNumber,
                    Description = x.Description,
                    RoomTypeId = x.RoomTypeId,
                    RoomTypeCapacityAdults = x.RoomTypeCapacityAdults,
                    RoomTypeCapacityKids = x.RoomTypeCapacityKids,
                    RoomTypeImage = x.RoomTypeImage,
                    RoomTypeName = x.RoomTypeName,
                    RoomTypePrice = x.RoomTypePrice
                })
               .FirstOrDefault(x => x.Id == id);

            return room;
        }

        public async Task<Room> GetRoom(int roomId)
        {
            return await this.Data.Rooms
                .FirstOrDefaultAsync(r => r.Id == roomId);
        }

        public async Task<Reservation> CreateReservation(AllAvailableRoomsViewModel model)
        {
            var customer = await this.customerRepository.FindByUser(model.UserUserId);

            var rooms = new List<Room>();

            var factory = customer == null
                   ? this.reservationFactory.WithCustomer(
                       model.UserFirstName,
                       model.UserLastName,
                       model.UserEmail,
                       model.UserUserId)
                   : this.reservationFactory.WithCustomer(customer);

            var reservation = factory
                  .WithStartDate(DateTime.Parse(model.CheckIn))
                  .WithEndDate(DateTime.Parse(model.CheckOut))
                  .WithAdults(model.Adults)
                  .WithKids(model.Kids)
                  .WithTotalAmount(model.TotalAmount)
                  .WithAdvancedPayment(0)
                  .WithIsPaid(false)
                  .Build();

            ReservationData reservationData = default!;

            var result = mapper.Map(reservation, reservationData);

            await this.Data.Reservations.AddAsync(result);

            await this.Data.SaveChangesAsync();

            foreach (var id in model.RoomIds)
            {
                await this.Data.ReservationRooms.AddAsync(new ReservationRoom(result.Id, id));
            }

            await this.Data.SaveChangesAsync();

            return reservation;
        }
    }
}
