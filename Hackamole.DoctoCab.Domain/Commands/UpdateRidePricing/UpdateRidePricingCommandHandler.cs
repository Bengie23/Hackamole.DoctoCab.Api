using Hackamole.DoctoCab.Domain.Entities;
using Hackamole.DoctoCab.Domain.Interfaces;

namespace Hackamole.DoctoCab.Domain.Commands.UpdateRidePricing;

public class UpdateRidePricingCommandHandler
{
    private readonly IPricingClient PricingClient;
    private readonly IRideManager RideManager;

    public UpdateRidePricingCommandHandler(IPricingClient pricingClient, IRideManager rideManager)
    {
        ArgumentNullException.ThrowIfNull(pricingClient);
        ArgumentNullException.ThrowIfNull(rideManager);
        
        this.PricingClient = pricingClient;
        this.RideManager = rideManager;
    }

    public void Handle(Ride ride)
    {
        var pricing = PricingClient.GetPricingEstimate(ride);
        RideManager.UpdateRidePricing(ride.Id, pricing);
    }
}