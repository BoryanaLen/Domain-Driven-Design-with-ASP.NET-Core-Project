namespace Infrastructure.Common.Persistence.Models.PaymentTypeData
{
    using Domain.Common.Models;

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
