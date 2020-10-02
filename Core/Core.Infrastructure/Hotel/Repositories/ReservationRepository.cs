namespace Core.Infrastructure.Hotel.Repositories
{
    using Application.Hotel.Reservations.Queries.HomePage;
    using Core.Domain.Hotel.Factories.Reservations;
    using Core.Domain.Hotel.Models.Reservations;
    using Core.Infrastructure.Persistence;
    using Core.Infrastructure.Persistence.Models.ReservationData;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ReservationRepository : DataRepository<HotelSystemDbContext, ReservationData>, IReservationQueryRepository
    {
        //private readonly IReservationFactory reservationFactory;
        public ReservationRepository(HotelSystemDbContext db)
            //IReservationFactory reservationFactory)
            : base(db)
        {
            //this.reservationFactory = reservationFactory;
        }

        public IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes(
            CancellationToken cancellationToken = default)
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
            var room = this.Data
               .Rooms
               .ToList()
               .Select(x => new DetailsRoomViewOutputModel()
               {
                   Id = x.Id,
                   RoomNumber = x.RoomNumber,
                   Description = x.Description,
                   RoomTypeId = x.RoomTypeId
               })
               .FirstOrDefault(x => x.Id == id);


            return room;
        }

        //public int CreateReservation()
        //{
            //var dealer = await this.dealerRepository.FindByUser(
            //        this.currentUser.UserId,
            //        cancellationToken);

            //var category = await this.carAdRepository.GetCategory(
            //    request.Category,
            //    cancellationToken);

            //var manufacturer = await this.carAdRepository.GetManufacturer(
            //    request.Manufacturer,
            //    cancellationToken);

            //var factory = manufacturer == null
            //    ? this.carAdFactory.WithManufacturer(request.Manufacturer)
            //    : this.carAdFactory.WithManufacturer(manufacturer);

            //var reservation = factory
            //    .WithModel(request.Model)
            //    .WithCategory(category)
            //    .WithImageUrl(request.ImageUrl)
            //    .WithPricePerDay(request.PricePerDay)
            //    .WithOptions(
            //        request.HasClimateControl,
            //        request.NumberOfSeats,
            //        Enumeration.FromValue<TransmissionType>(request.TransmissionType))
            //    .Build();

            //dealer.AddCarAd(carAd);

            //await this.carAdRepository.Save(carAd, cancellationToken);

            //return new CreateCarAdOutputModel(carAd.Id);
        //}
    }
}
