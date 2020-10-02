using System.Collections.Generic;

namespace Core.Application.Hotel.Reservations.Commands.Create
{
    public class CreateReservationOutputModel
    {
        public CreateReservationOutputModel()
        {
            this.RoomIds = new List<int>();
        }

        public string CheckIn { get; set; } = default!;

        public string CheckOut { get; set; } = default!;

        public int Adults { get; set; }

        public int Kids { get; set; }

        public List<int> RoomIds { get; set; }

        public string PaymentTypeId { get; set; } = default!;

        public string ReservationStatusId { get; set; } = default!;

        public string UserFirstName { get; set; } = default!;

        public string UserLastName { get; set; } = default!;

        public string UserUserName { get; set; } = default!;

        public decimal PricePerDay { get; set; }

        public int TotalDays { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
