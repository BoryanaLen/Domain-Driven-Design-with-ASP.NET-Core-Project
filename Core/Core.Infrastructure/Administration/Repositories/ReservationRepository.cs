namespace Core.Infrastructure.Administration.Repositories
{
    using AutoMapper;
    using Core.Application.Administration.Reservations;
    using Core.Application.Administration.Reservations.Queries;
    using Core.Domain.Administration.Models.Reservations;
    using Core.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    internal class ReservationRepository : DataRepository<IAdministrationDbContext, Reservation>,
        IReservationQueryRepository
    {
        private readonly IMapper mapper;

        public ReservationRepository(HotelSystemDbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public int GetReservedRooms()
        {
            var reservations = this.Data.Reservations
                .Where(x => x.StartDate < DateTime.Today && x.EndDate >= DateTime.Today)
                .Select(x => x.Id)
                .ToList();

            int currentInHouse = this.Data.ReservationRooms
               .Where(x => reservations.Any(x2 => x2 == x.ReservationDataId))
               .Count();

            return currentInHouse;
        }

        public int GetRoomsArrivals()
        {
            var reservations = this.Data.Reservations
                .Where(x => x.StartDate.Date == DateTime.Today.Date)
                .Select(x => x.Id)
                .ToList();

            int currentInHouse = this.Data.ReservationRooms
               .Where(x => reservations.Any(x2 => x2 == x.ReservationDataId))
               .Count();

            return currentInHouse;
        }

        public int GetRoomsDeparture()
        {
            var reservations = this.Data.Reservations
               .Where(x => x.EndDate.Date == DateTime.Today.Date)
               .Select(x => x.Id)
               .ToList();

            int currentInHouse = this.Data.ReservationRooms
               .Where(x => reservations.Any(x2 => x2 == x.ReservationDataId))
               .Count();

            return currentInHouse;
        }

        public async Task<int> GetAllReservationsCountAsync()
        {
            var reservations = await this.Data.Reservations
                .ToArrayAsync();

            return reservations.Count();
        }

        public async Task<int> GetAllRoomsCountAsync()
        {
            var rooms = await this.Data.Rooms
                .ToArrayAsync();

            return rooms.Count();
        }

        public IEnumerable<ColumnChartViewModel> IncomesForCurrentYear()
        {
            var incomes = this.Data.Reservations
               .Where(x => x.StartDate.Year == DateTime.Now.Year)
               .OrderBy(x => x.StartDate)
               .GroupBy(gp => new { gp.StartDate.Month })
               .Select(x => new ColumnChartViewModel
               {
                   Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(x.Key.Month),
                   TotalAmount = (int)x.Sum(y => y.TotalAmount),
               }).ToList();

            return incomes;
        }

        public int GetAllOccupiedRooms()
        {
            var rooms = this.Data.Reservations
               .Where(x => x.StartDate <= DateTime.Now.Date && x.EndDate > DateTime.Now.Date)
               .Select(x => x.Id);

            var roomsCount = this.Data.ReservationRooms
               .Where(x => rooms.Any(x2 => x2 == x.RoomId))
               .Distinct()
               .Count();

            return roomsCount;
        }
    }
}
