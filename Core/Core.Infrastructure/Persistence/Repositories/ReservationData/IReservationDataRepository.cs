namespace Core.Infrastructure.Persistence.Repositories.ReservationData
{
    using Common.Application.Contracts;
    using Common.Domain;
    using Core.Infrastructure.Persistence.Models.ReservationData;

    public interface IReservationDataRepository : IQueryRepository<ReservationData>, IDomainRepository<ReservationData>
    {
       
    }
}
