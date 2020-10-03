namespace Core.Infrastructure.Hotel.Repositories
{
    using Application.Hotel.Reservations.Queries.HomePage;
    using AutoMapper;
    using Core.Application.Hotel.Reservations;
    using Core.Domain.Hotel.Factories.Reservations;
    using Core.Domain.Hotel.Models.Reservations;
    using Core.Domain.Hotel.Repositories.Customers;
    using Core.Domain.Hotel.Repositories.Reservations;
    using Core.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class ReservationRepository : DataRepository<IHotelDbContext, Reservation>,
        IReservationDomainRepository,
        IReservationQueryRepository
    {
        //private readonly IReservationFactory reservationFactory;
        private readonly ICustomerDomainRepository customerRepository;
        private readonly IMapper mapper;

        public ReservationRepository(HotelSystemDbContext db, IMapper mapper,
            ICustomerDomainRepository customerRepository)
            //IReservationFactory reservationFactory)
            : base(db)
        {
            this.mapper = mapper;
            //this.reservationFactory = reservationFactory;
            this.customerRepository = customerRepository;
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
            var roomsId = this.Data.Reservations
                .Where(x => (x.StartDate >= checkIn && x.StartDate <= checkOut) || (x.EndDate >= checkIn && x.EndDate <= checkOut))
                .SelectMany(x => x.Rooms)
                .Select(x => x.Id)
                .Distinct()
                .ToList();

            return roomsId;
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

        //public async Task<Reservation> CreateReservation(AllAvailableRoomsViewModel model, string userId)
        //{
        //    var customer = await this.customerRepository.FindByUser(userId);

        //    var rooms = new List<Room>();

        //    foreach(var id in model.RoomIds)
        //    {
        //        var room = await this.Data.Rooms
        //            .FirstOrDefaultAsync(r => r.Id == id);

        //        rooms.Add(room);
        //    }

        //    var reservation = this.reservationFactory
        //        .WithStartDate(DateTime.Parse(model.CheckIn))
        //        .WithEndDate(DateTime.Parse(model.CheckOut))
        //        .WithAdults(model.Adults)
        //        .WithKids(model.Kids)
        //        .WithCustomer(customer)
        //        .WithPricePerDay(model.PricePerDay)
        //        .WithAdvancedPayment(0)
        //        .WithIsPaid(false)
        //        .WithRooms(rooms)
        //        .Build();

        //    await this.Save(reservation);

        //    return reservation;
        //}
    }
}
