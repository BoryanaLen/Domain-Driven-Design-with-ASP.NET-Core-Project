﻿namespace Core.Infrastructure.Administration.Repositories
{
    using AutoMapper;
    using Core.Application.Administration.Dashboard.Queries;
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
                .ToList()
                .Where(x => x.StartDate < DateTime.Today && x.EndDate >= DateTime.Today)
                .Select(x => x.Id)
                .ToList();

            int currentInHouse = this.Data.ReservationRooms
                .ToList()
               .Where(x => reservations.Any(x2 => x2 == x.ReservationDataId))
               .Count();

            return currentInHouse;
        }

        public int GetRoomsArrivals()
        {
            var reservations = this.Data.Reservations
                .ToList()
                .Where(x => x.StartDate.Date == DateTime.Today.Date)
                .Select(x => x.Id)
                .ToList();

            int currentInHouse = this.Data.ReservationRooms
                .ToList()
               .Where(x => reservations.Any(x2 => x2 == x.ReservationDataId))
               .Count();

            return currentInHouse;
        }

        public int GetRoomsDeparture()
        {
            var reservations = this.Data.Reservations
                .ToList()
                .Where(x => x.EndDate.Date == DateTime.Today.Date)
                .Select(x => x.Id)
                .ToList();

            int currentInHouse = this.Data.ReservationRooms
                .ToList()
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
                .ToList()
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
                .ToList()
               .Where(x => x.StartDate <= DateTime.Now.Date && x.EndDate > DateTime.Now.Date)
               .Select(x => x.Id);

            var roomsCount = this.Data.ReservationRooms
                .ToList()
               .Where(x => rooms.Any(x2 => x2 == x.RoomId))
               .Distinct()
               .Count();

            return roomsCount;
        }

        public async Task<IndexViewModel> GetCurrentCondition()
        {
            var viewModel = new IndexViewModel { };
            int roomsCount = await this.GetAllRoomsCountAsync();

            viewModel.ReservedRooms = this.GetReservedRooms();
            viewModel.ExpectedRoomsArrivals = this.GetRoomsArrivals();
            viewModel.ExpectedRoomsDepartures = this.GetRoomsDeparture();
            viewModel.RoomsEndOfDay = viewModel.ReservedRooms + viewModel.ExpectedRoomsArrivals - viewModel.ExpectedRoomsDepartures;
            viewModel.OccupiedRooms = this.GetAllOccupiedRooms();
            viewModel.AvailableRooms = roomsCount - viewModel.OccupiedRooms;

            return viewModel;
        }

        public async Task<List<PieChartViewModel>> GetRoomsChartData()
        {
            int occupiedRooms = this.GetAllOccupiedRooms();
            int totalRooms = await this.GetAllRoomsCountAsync();

            List<PieChartViewModel> data = new List<PieChartViewModel>()
            {
                new PieChartViewModel
                {
                    Status = "Available",
                    Count = totalRooms - occupiedRooms,
                },
                new PieChartViewModel
                {
                    Status = "Occupied",
                    Count = occupiedRooms,
                },
            };

            return data;
        }
    }
}
