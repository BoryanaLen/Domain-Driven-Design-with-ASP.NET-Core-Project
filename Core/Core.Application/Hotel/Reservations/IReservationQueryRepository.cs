﻿namespace Core.Application.Hotel.Reservations
{
    using Common.Application.Contracts;
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Core.Domain.Hotel.Models.Reservations;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReservationQueryRepository : IQueryRepository<Reservation>
    {
        IEnumerable<int> GetAllReservedRoomsId(DateTime checkIn, DateTime checkOut);

        IEnumerable<AvailableRoomViewModel> GetAllRooms();

        Task<int> GetRoomTypeCapacityAdultsByIdAsync(int id);

        Task<int> GetRoomTypeCapacityKidsByIdAsync(int id);

        DetailsRoomViewOutputModel GetRoomViewModelById(int id);

        IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes();

        Task<Reservation> CreateReservation(AllAvailableRoomsViewModel model);

        AllAvailableRoomsViewModel AvailableRooms(string checkIn, string checkOut, int adults, int kids, int page = Constants.DefaultPageNumber, int perPage = Constants.PageSize);

        AllAvailableRoomsViewModel Book(AllAvailableRoomsViewModel model);

        Task<AllAvailableRoomsViewModel> BookRooms(AllAvailableRoomsViewModel model);

        IndexViewOutputModel GetOffers();
    }
}
