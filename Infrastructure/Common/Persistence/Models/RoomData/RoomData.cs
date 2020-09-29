﻿namespace Infrastructure.Common.Persistence.Models.RoomData
{
    using Domain.Common.Models;
    using Persistence.Models.RoomTypeData;

    public class RoomData : Entity<int>
    {
        internal RoomData(
            string roomNumber,
            string description,
            RoomTypeData roomType
            )
        {         
            this.RoomNumber = roomNumber;
            this.Description = description;

            this.RoomType = roomType;
        }

        private RoomData(
            string roomNumber,
            string description
            )
        {
            this.RoomNumber = roomNumber;
            this.Description = description;

            this.RoomType = default!;
        }

        public string RoomNumber { get; private set; }      

        public string Description { get; private set; }

        public RoomTypeData RoomType { get; private set; }      
    }
}
