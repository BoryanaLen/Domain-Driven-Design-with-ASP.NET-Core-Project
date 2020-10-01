namespace Core.Infrastructure.Persistence.Models.PaymentTypeData
{
    using Common.Domain.Models;

    public class PaymentTypeData : Entity<int>
    {
        internal PaymentTypeData(
            string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
