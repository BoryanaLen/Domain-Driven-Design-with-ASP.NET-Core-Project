namespace Hotel.Domain.Hotel.Models.Reservations
{
    using Common;
    using Exceptions;

    using static ModelConstants.HotelUser;

    public class HotelUser: Entity<int>
    {
        internal HotelUser(string firstName, string lastName, string userName)
        {
            this.Validate(firstName);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string UserName { get; private set; }

        public HotelUser UpdateFirstName(string newFirstName)
        {
            this.Validate(newFirstName);
            this.FirstName = newFirstName;

            return this;
        }

        public void Validate(string newFirstName)
            => Guard.ForStringLength<InvalidReservationException>(
                newFirstName,
                MinFirstNameLength,
                MaxFirstNameLength,
                nameof(this.FirstName));
    }
}
