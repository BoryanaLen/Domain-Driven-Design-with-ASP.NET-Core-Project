namespace Core.Application.Hotel.Reservations.Queries.HomePage
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Application;

    public class AllAvailableRoomsViewModel : PagedListViewModel
    {
        public AllAvailableRoomsViewModel()
        {
            this.ListOfRoomsInReservation = new HashSet<DetailsRoomViewOutputModel>();
            this.Rooms = new HashSet<AvailableRoomViewModel>();
            this.RoomIds = new List<int>();
        }

        public IEnumerable<AvailableRoomViewModel> Rooms { get; set; }

        public string CheckIn { get; set; } = default!;

        public string CheckOut { get; set; } = default!;

        public int Adults { get; set; } 

        public int Kids { get; set; }

        public List<int> RoomIds { get; set; }

        public string PaymentTypeId { get; set; } = default!;

        public string ReservationStatusId { get; set; } = default!;

        [Display(Name = "First name")]
        public string UserFirstName { get; set; } = default!;

        [Display(Name = "Last name")]
        public string UserLastName { get; set; } = default!;

        public string UserUserId { get; set; } = default!;

        public decimal PricePerDay { get; set; }

        public int TotalDays { get; set; }

        public decimal TotalAmount { get; set; }

        public IEnumerable<DetailsRoomViewOutputModel> ListOfRoomsInReservation { get; set; }
    }
}
