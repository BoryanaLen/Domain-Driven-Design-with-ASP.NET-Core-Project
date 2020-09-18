namespace Hotel.Domain.Hotel.Models.Rooms
{
    using Common.Models;
    using Exceptions;

    using static ModelConstants.Common;
    using static ModelConstants.RoomType;

    public class RoomType : Entity<int>
    {
        internal RoomType(
            string name, 
            decimal price, 
            int capacityAdults, 
            int capacityKids,
            string image,
            string description)
        {
            this.Validate(name, price, capacityAdults, capacityKids, description, image);

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

        private void Validate(string name, decimal price, int capacityAdults, int capacityKids, string description, string image)
        {
            this.ValidateName(name);
            this.ValidatePrice(price);
            this.ValidateCapacityAdults(capacityAdults);
            this.ValidateCapacityKids(capacityKids);
            this.ValidateDescription(description);
            this.ValidateImage(image);
        }

        private void ValidateName(string name)
           => Guard.ForStringLength<InvalidRoomException>(
               name,
               MinNameLength,
               MaxNameLength,
               nameof(this.Name));

        private void ValidatePrice(decimal price)
            => Guard.AgainstOutOfRange<InvalidRoomException>(
                price,
                Zero,
                decimal.MaxValue,
                nameof(this.Price));

        private void ValidateCapacityAdults(int capacity)
             => Guard.AgainstOutOfRange<InvalidRoomException>(
               capacity,
               MinNumberOfAdults,
               MaxNumberOfAdults,
               nameof(this.CapacityAdults));

        private void ValidateCapacityKids(int capacity)
            => Guard.AgainstOutOfRange<InvalidRoomException>(
              capacity,
              MinNumberOfKids,
              MaxNumberOfKids,
              nameof(this.CapacityKids));

        private void ValidateDescription(string description)
         => Guard.ForStringLength<InvalidRoomException>(
               description,
               MinDescriptionLength,
               MaxDescriptionLength,
               nameof(this.Description));

        private void ValidateImage(string image)
           => Guard.AgainstEmptyString<InvalidRoomException>(
               image,
               nameof(this.Image));
    }
}
