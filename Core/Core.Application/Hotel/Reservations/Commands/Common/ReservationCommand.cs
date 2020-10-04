namespace Core.Application.Hotel.Reservations.Commands.Common
{
    using global::Common.Application;
    using System;
    using System.Collections.Generic;

    public abstract class ReservationCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
    {
        public string CheckIn { get; set; } = default!;

        public string CheckOut { get; set; } = default!;

        public int Adults { get; set; }

        public int Kids { get; set; }

        public List<int> RoomIds { get; set; } = default!;

        public string PaymentTypeId { get; set; } = default!;

        public string ReservationStatusId { get; set; } = default!;

        public string UserFirstName { get; set; } = default!;

        public string UserLastName { get; set; } = default!;

        public string UserUserId { get; set; } = default!;

        public string UserEmail { get; set; } = default!;

        public decimal PricePerDay { get; set; }

        public int TotalDays { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
