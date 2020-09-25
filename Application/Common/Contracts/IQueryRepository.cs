namespace Application.Common.Contracts
{
    using Domain.Common;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        //Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
