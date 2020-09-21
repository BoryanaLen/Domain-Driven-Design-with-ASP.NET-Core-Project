namespace Hotel.Domain.Administration.Factories
{
    using Administration.Models.SpecialOffer;
    using Common;

   public interface ISpecialOfferFactory : IFactory<SpecialOffer>
    {
        ISpecialOfferFactory WithTitle(string title);

        ISpecialOfferFactory WithContent(string content);

        ISpecialOfferFactory WithShortContent(string shortContent);

        public SpecialOffer Build(string title, string content, string shortContent)
            => this
                .WithTitle(title)
                .WithContent(content)
                .WithShortContent(shortContent)
                .Build();
    }
}
