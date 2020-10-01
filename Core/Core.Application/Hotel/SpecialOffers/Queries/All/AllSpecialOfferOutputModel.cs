namespace Core.Application.Hotel.SpecialOffers.Queries.All
{
    public class AllSpecialOfferOutputModel 
    {
        public int Id { get;  set; }

        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public string ShortContent { get;  set; } = default!;
    }
}
