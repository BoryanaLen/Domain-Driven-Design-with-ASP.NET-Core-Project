namespace Core.Domain.Hotel.Repositories.Reservations
{
    using Common.Domain;
    using Core.Domain.Hotel.Models.Reservations;
    using System.Threading.Tasks;

    public interface IReservationDomainRepository: IDomainRepository<Reservation>
    {
        
    }
}
