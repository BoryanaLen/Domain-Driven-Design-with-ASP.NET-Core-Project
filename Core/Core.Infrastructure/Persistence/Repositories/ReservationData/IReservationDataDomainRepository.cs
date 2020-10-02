namespace Core.Infrastructure.Persistence.Repositories.ReservationData
{
    using Common.Domain;
    using Core.Application.Hotel.Reservations.Queries.HomePage;
    using Core.Infrastructure.Persistence.Models.ReservationData;
    using System.Threading.Tasks;

    public interface IReservationDataDomainRepository : IDomainRepository<ReservationData>
    {
        Task<ReservationData> CreateReservation(AllAvailableRoomsViewModel model, string userId);
    }
}
