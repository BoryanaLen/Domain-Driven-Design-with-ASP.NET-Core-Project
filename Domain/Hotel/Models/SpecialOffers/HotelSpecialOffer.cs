namespace Domain.Hotel.Models.SpecialOffers
{
    using Common;
    using Common.Models;
    using Hotel.Exceptions;

    using static ModelConstants.SpecialOffer;

    public class HotelSpecialOffer : Entity<int>, IAggregateRoot
    {
        internal HotelSpecialOffer(string title, string content, string shortContent)
        {
            this.Validate(title, content, shortContent);

            this.Title = title;
            this.Content = content;
            this.ShortContent = shortContent;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string ShortContent { get; private set; }

        private void Validate(string title, string content, string shortContent)
        {
            this.ValidateTitle(title);
            this.ValidateContent(content);
            this.ValidateShortContent(shortContent);
        }

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidSpecialOfferException>(
                title,
                TitleMinLength,
                TitleMaxLength,
                nameof(this.Title));

        private void ValidateContent(string content)
            => Guard.ForStringLength<InvalidSpecialOfferException>(
                content,
                ContentMinLength,
                ContentMaxLength,
                nameof(this.Content));

        private void ValidateShortContent(string shortContent)
            => Guard.ForStringLength<InvalidSpecialOfferException>(
                shortContent,
                ShortContentMinLength,
                ShortContentMaxLength,
                nameof(this.ShortContent));
    }
}
