namespace Application.Hotel.Accommodations.Queries.Home
{
    public class DetailsRoomTypeViewOutputModel
    {
        public int Id { get; set; } 

        public string Name { get; set; } = default!;

        public decimal Price { get; set; }

        public int CapacityAdults { get; set; }

        public int CapacityKids { get; set; }

        public string Image { get; set; } = default!;

        public string Description { get; set; } = default!;
    }
}
