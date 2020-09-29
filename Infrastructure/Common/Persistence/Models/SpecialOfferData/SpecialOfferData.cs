namespace Infrastructure.Common.Persistence.Models.SpecialOfferData
{
    using Domain.Common;
    using Domain.Common.Models;

    public class SpecialOfferData : Entity<int>, IAggregateRoot
    {
        internal SpecialOfferData(string title, string content, string shortContent)
        {
            this.Title = title;
            this.Content = content;
            this.ShortContent = shortContent;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string ShortContent { get; private set; }
    }
}
