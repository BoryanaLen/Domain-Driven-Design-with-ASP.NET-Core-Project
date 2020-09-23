﻿namespace Domain.Hotel.Models.Rooms
{
    using Common;
    using System;
    using System.Collections.Generic;

    internal class RoomTypeData : IInitialData
    {
        public Type EntityType => typeof(RoomType);

        public IEnumerable<object> GetData()
            => new List<RoomType>
            {
                new RoomType("Single room", 100, 1, 0, "pictures/single-room.jpg",
                     @"Suitable for one adult; LCD TV with cable TV;
                    Free Wi-Fi access; Individually controlled air conditioning system; 
                    Separate bathroom and toilet; Non-smoking room; Telephone Hair dryer;"),

                new RoomType
                ( "Double room", 150, 2, 1, "pictures/double room.jpg",
                   @"Panoramic window room; Suitable for two adults; 
                    Individually controlled air conditioning system; LCD TV with cable television; 
                    Free Wi-Fi Separate beds; Separate bathroom and toilet; Non-smoking room; 
                    Mini bar; Telephone Hair dryer;"),

                new RoomType
                ( "Studio", 200, 3, 1, "pictures/club-floor-room.jpg",
                     @"Each of the spacious studios has a unique vision and interior.
                        Some of the studios have terraces with wonderful views, as well as baths in the bathrooms. 
                        The studios at the hotel are equipped with bedrooms, a dressing table, 
                        a living room with a sofa, armchairs and a coffee table, and the equipment 
                        includes multi split air conditioners, digital TV, telephone, 
                        mini bar and wireless internet. Each of the studios bathrooms is supplied with
                        healing mineral water."),
                new RoomType
                ( "Apartment", 250, 4, 1, "pictures/suits.jpg",
                    @"Stylishly furnished apartments with an area of ​​90 sq.m. consisting
                    of a separate living and sleeping area and an extra spacious terrace, 
                    revealing a splendid panoramic view of the mountain."
                ),
            };
    }
}
