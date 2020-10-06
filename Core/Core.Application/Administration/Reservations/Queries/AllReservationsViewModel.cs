namespace Core.Application.Administration.Dashboard.Queries
{
    using Core.Application.Administration.Reservations.Queries;
    using System.Collections.Generic;

    public class AllReservationsViewModel
    {
        public IEnumerable<DetailsReservationViewModel> Reservations { get; set; } = default!;
    }
}
