using Common.Application;
using Common.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Hotel.Reservations.Commands.Common
{
    class ChangeReservationCommandExtensions
    {
        //public static async Task<Result> DealerHasCarAd(
        //    this ICurrentUser currentUser,
        //    IDealerDomainRepository dealerRepository,
        //    int carAdId,
        //    CancellationToken cancellationToken)
        //{
        //    var dealerId = await dealerRepository.GetDealerId(
        //        currentUser.UserId,
        //        cancellationToken);

        //    var dealerHasCar = await dealerRepository.HasCarAd(
        //        dealerId,
        //        carAdId,
        //        cancellationToken);

        //    return dealerHasCar
        //        ? Result.Success
        //        : "You cannot edit this car ad.";
        //}
    }
}
