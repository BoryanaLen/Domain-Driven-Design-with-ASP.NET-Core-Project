namespace Application.Hotel.Accommodations.Queries.Home
{
    using System;

    public class CheckAvailableRoomsViewOutputModel
    {
        public DateTime? CheckIn { get; set; }
       
        public DateTime? CheckOut { get; set; }

        public int Adults { get; set; }

        public int Kids { get; set; }
    }
}
