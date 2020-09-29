namespace Infrastructure.Hotel.Repositories
{
    using Application.Hotel.Accommodations;
    using Application.Hotel.Accommodations.Queries.Home;
    using Infrastructure.Common.Persistence;
    using Infrastructure.Common.Persistence.Models.RoomTypeData;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RoomRepository : DataRepository<HotelDbContext, RoomTypeData>, IRoomRepository
    {
        public RoomRepository(HotelDbContext db)
            : base(db)
        {

        }

        public IEnumerable<DetailsRoomTypeViewOutputModel> GetAllRoomTypes(
            CancellationToken cancellationToken = default)
        {
            var roomTypes = this.Data
                .RoomTypes
                .ToList()
                .Select(x => new DetailsRoomTypeViewOutputModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    CapacityAdults = x.CapacityAdults,
                    CapacityKids = x.CapacityKids,
                    Image = x.Image,
                    Description = x.Description
                }).ToList();


            return roomTypes;
        }

    }
}
