namespace Infrastructure.Common.Persistence.Models.RoomTypeData
{
    using Domain.Common;
    using Domain.Common.Models;

    public class RoomTypeData : Entity<int>, IAggregateRoot
    {
        internal RoomTypeData(
            string name, 
            decimal price, 
            int capacityAdults, 
            int capacityKids,
            string image,
            string description)
        {
            this.Name = name;
            this.Price = price;
            this.CapacityAdults = capacityAdults;
            this.CapacityKids = capacityKids;
            this.Description = description;
            this.Image = image;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int CapacityAdults { get; private set; }

        public int CapacityKids { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }
    }
}
