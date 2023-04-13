using Hackamole.DoctoCab.Domain.Entities;

namespace Hackamole.DoctoCab.Domain.Commands.UpdateRideGeoLocation;

public class UpdateRideGeoLocationCommand
{
    public UpdateRideGeoLocationCommand(Ride ride)
    {
        ArgumentNullException.ThrowIfNull(ride);
        this.Ride = ride;
    }

    public Ride Ride { get; set; }
}