namespace Core.Application.Hotel.Reservations.Commands.Common
{
    using global::Common.Application;
    using System;
    using System.Collections.Generic;

    public abstract class ReservationCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
    {
        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public int Adults { get; private set; }

        public int Kids { get; private set; }

        public int Customer { get; private set; }

        public decimal PricePerDay { get; private set; }

        public decimal AdvancedPayment { get; private set; }

        public bool IsPaid { get; private set; }
    }
}
