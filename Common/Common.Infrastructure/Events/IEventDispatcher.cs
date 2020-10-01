namespace Common.Infrastructure.Events
{
    using System.Threading.Tasks;
    using Common.Domain;

    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
