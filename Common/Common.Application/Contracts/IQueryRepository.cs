namespace Common.Application.Contracts
{
    using Common.Domain;

    public interface IQueryRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
    }
}
