﻿namespace Domain.Administration.Models.SpecialOffer
{
    using Common;
    using System;
    using System.Collections.Generic;

    internal class SpecialOfferData : IInitialData
    {
        public Type EntityType => typeof(SpecialOffer);

        public IEnumerable<object> GetData()
            => new List<SpecialOffer>
            {
                new SpecialOffer(
                    "Saint Valentine",
                    "Romance and Relax",
                     @"Only 200.00 EUR for two nights
                          Stay in the beautiful room facing the mountain.                                   
                          Rich breakfast buffet with homemade pastries and croissants,
                          cold cuts and cheeses of our territory, eggs, bacon, yoghurt, fresh fruit, cereals,
                          freshly baked bread and Gluten Free corner
                          Soft bedroom slippers
                          Romantic setting with petals and chocolates in the chosen room"
                     ),
                new SpecialOffer(
                    "Easter",
                    "Holiday and Relax",
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
                        Children's play area with children's animation every day from 9:30 to 12:00 and from 16:30 to 22:00 for children from 4 to 12 years old."
                    ),
                new SpecialOffer(
                    "Christmas",
                    "Relax and Holiday",
                    @"Only 200.00 EUR for two nights.
                    Overnight with breakfast and dinner;                   
                    Traditional Christmas dinner with festive Christmas turkey and roast pig, and specially selected festive musical-artistic program;
                    Christmas gifts for all hotel guests;
                    Children's party with gifts for children;
                    Use of swimming pool with mineral water 30-31 ° C;
                    Use of Jacuzzi with mineral water 36-38 ° C;
                    Use of sauna;
                    Use of fitness;
                    Use of steam room;
                    Using a relax zone;
                    Children's play area with children's animation every day from 9:30 to 12:00 and from 16:30 to 22:00 for children from 4 to 12 years old."
                    ),
            };
    }
}
