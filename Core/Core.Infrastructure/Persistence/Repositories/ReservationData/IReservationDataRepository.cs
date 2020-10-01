namespace Core.Infrastructure.Persistence.Repositories.ReservationData
{
    using Common.Application.Contracts;
    using Common.Domain;
    using Core.Infrastructure.Persistence.Models.ReservationData;
    using System.Threading;
    using System.Threading.Tasks;

    class IReservationDataRepository : IQueryRepository<ReservationData>, IDomainRepository<ReservationData>
    {
        public Task Save(ReservationData entity, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
