using Domain.Administration.Models.SpecialOffer;

namespace Domain.Administration.Factories
{
    public class SpecialOfferFactory : ISpecialOfferFactory
    {
        private string title = default!;
        private string content = default!;
        private string shortContent = default!;

        public ISpecialOfferFactory WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public ISpecialOfferFactory WithContent(string content)
        {
            this.content = content;
            return this;
        }

        public ISpecialOfferFactory WithShortContent(string shortContent)
        {
            this.shortContent = shortContent;
            return this;
        }

        public SpecialOffer Build()
        {
            return new SpecialOffer(this.title, this.content, this.shortContent);
        }

        public SpecialOffer Build(string title, string content, string shortContent)
            => this
                .WithTitle(title)
                .WithContent(content)
                .WithShortContent(shortContent)
                .Build();
    }
}
