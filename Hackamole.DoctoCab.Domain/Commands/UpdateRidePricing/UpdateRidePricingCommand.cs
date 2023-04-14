using Hackamole.DoctoCab.Domain.Entities;

namespace Hackamole.DoctoCab.Domain.Commands.UpdateRidePricing;

public class UpdateRidePricingCommand
{
    public UpdateRidePricingCommand(Ride ride)
    {
        ArgumentNullException.ThrowIfNull(ride);

        this.Ride = ride;
    }

    public Ride Ride { get; set; }
}