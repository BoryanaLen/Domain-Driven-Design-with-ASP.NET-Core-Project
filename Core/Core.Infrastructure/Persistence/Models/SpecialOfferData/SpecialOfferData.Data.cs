namespace Core.Infrastructure.Persistence.Models.SpecialOfferData
{
    using Common.Domain;
    using System;
    using System.Collections.Generic;

    internal class SpecialOfferDataData : IInitialData
    {
        public Type EntityType => typeof(SpecialOfferData);

        public IEnumerable<object> GetData()
            => new List<SpecialOfferData>
            {
                new SpecialOfferData(
                    "Saint Valentine",
                     @"Only 200.00 EUR for two nights
                          Stay in the beautiful room facing the mountain.                                   
                          Rich breakfast buffet with homemade pastries and croissants,
                          cold cuts and cheeses of our territory, eggs, bacon, yoghurt, fresh fruit, cereals,
                          freshly baked bread and Gluten Free corner
                          Soft bedroom slippers
                          Romantic setting with petals and chocolates in the chosen room",
                     "Romance and Relax"
                     ),
                new SpecialOfferData(
                    "New Year",
                     @"Only 200.00 EUR for two nights
                          Stay in the beautiful room facing the mountain.                                   
                          Rich breakfast buffet with homemade pastries and croissants,
                          cold cuts and cheeses of our territory, eggs, bacon, yoghurt, fresh fruit, cereals,
                          freshly baked bread and Gluten Free corner
                          Soft bedroom slippers
                          Romantic setting with petals and chocolates in the chosen room",
                      "Fun and Holiday"
                     ),
                new SpecialOfferData(
                    "Easter",
                    @"Only 200.00 EUR for two nights.
                          Easter dinner with selected dishes, specially prepared by our experienced chefs and accompanied by a musical-artistic program;
                        Specially selected festive musical-artistic program;
                        Gifts for all hotel guests;
                        Children's party with gifts for children;
                        Use of swimming pool with mineral water 30-31 ° C;
                        Use of Jacuzzi with mineral water 36-38 ° C;
                        Use of sauna;
                        Use of fitness;
                        Use of steam room;
                        Using a relax zone;
                        Children's play area with children's animation every day from 9:30 to 12:00 and from 16:30 to 22:00 for children from 4 to 12 years old.",
                    "Holiday and Relax"
                    ),
                new SpecialOfferData(
                    "Christmas Party",
                    @"Christmas gifts for all hotel guests;
                    Children's party with gifts for children;
                    Use of swimming pool with mineral water 30-31 ° C;
                    Use of Jacuzzi with mineral water 36-38 ° C;
                    Use of sauna;
                    Use of fitness;
                    Use of steam room;
                    Using a relax zone;",
                    "Relax and Holiday"
                    ),
            };
    }
}
