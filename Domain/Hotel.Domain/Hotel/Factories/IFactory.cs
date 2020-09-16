namespace Hotel.Domain.Hotel.Factories
{
    using Common;

    public interface IFactory<out TEntity>
        where TEntity : IAggregateRoot
    {
        TEntity Build();
    }
}
