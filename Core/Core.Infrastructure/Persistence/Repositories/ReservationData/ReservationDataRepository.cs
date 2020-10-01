namespace Core.Infrastructure.Persistence.Repositories.ReservationData
{
    public class ReservationDataRepository : IReservationDataRepository
    {
        private readonly IReservationDataFactory reservationFactory;
        public ReservationDataRepository(HotelSystemDbContext db,
            IReservationFactory reservationFactory)
            : base(db)
        {
            this.reservationFactory = reservationFactory;
        }
    }
}
