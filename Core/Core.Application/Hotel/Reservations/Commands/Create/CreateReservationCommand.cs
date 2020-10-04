namespace Core.Application.Hotel.Reservations.Commands.Create
{
    using Core.Application.Hotel.Reservations.Commands.Common;
    using Core.Domain.Hotel.Factories.Reservations;
    using Core.Domain.Hotel.Models.Reservations;
    using Core.Domain.Hotel.Repositories.Customers;
    using Core.Domain.Hotel.Repositories.Reservations;
    using global::Common.Application.Contracts;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateReservationCommand 
    {
        //private readonly IReservationDomainRepository reservationDomainRepository;
        //private readonly ICustomerDomainRepository customerRepository;
        //private readonly IReservationFactory reservationFactory;
        //private readonly ICurrentUser currentUser;

        //public CreateReservationCommand(
        //    IReservationDomainRepository reservationDomainRepository,
        //    ICustomerDomainRepository customerRepository,
        //    IReservationFactory reservationFactory,
        //    ICurrentUser currentUser)
        //{
        //    this.reservationDomainRepository = reservationDomainRepository;
        //    this.customerRepository = customerRepository;
        //    this.reservationFactory = reservationFactory;
        //    this.currentUser = currentUser;
        //}

        //public async Task<Reservation> Handle(
        //    CreateReservationCommand request, CancellationToken cancellationToken = default)
        //{
        //    var user = currentUser;

        //    var customer = await this.customerRepository.FindByUser(user.UserId);

        //    var rooms = new List<Room>();

        //    foreach (var id in request.RoomIds)
        //    {
        //        var room = (await reservationDomainRepository
        //            .GetRoom(id));

        //        rooms.Add(room);
        //    }

        //    var factory = customer == null
        //           ? this.reservationFactory.WithCustomer(
        //               request.UserFirstName,
        //               request.UserLastName,
        //               user.Email,
        //               user.UserId)
        //           : this.reservationFactory.WithCustomer(customer);

        //    var reservation = factory
        //          .WithStartDate(DateTime.Parse(request.CheckIn))
        //          .WithEndDate(DateTime.Parse(request.CheckOut))
        //          .WithAdults(request.Adults)
        //          .WithKids(request.Kids)
        //          .WithPricePerDay(request.PricePerDay)
        //          .WithAdvancedPayment(0)
        //          .WithIsPaid(false)
        //          .WithRooms(rooms)
        //          .Build();

        //    return reservation;
        //}
    }
}
