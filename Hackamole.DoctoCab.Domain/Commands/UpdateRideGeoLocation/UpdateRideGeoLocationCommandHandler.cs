using Hackamole.DoctoCab.Domain.Entities;
using Hackamole.DoctoCab.Domain.Interfaces;


namespace Hackamole.DoctoCab.Domain.Commands.UpdateRideGeoLocation;

public class UpdateRideGeoLocationCommandHandler
{
    private readonly IGeoLocationClient MapsClient;
    private readonly IRideManager RideManager;

    public UpdateRideGeoLocationCommandHandler(IGeoLocationClient mapsClient, IRideManager rideManager)
    {
        ArgumentNullException.ThrowIfNull(mapsClient);
        ArgumentNullException.ThrowIfNull(rideManager);

        this.RideManager = rideManager;
        this.MapsClient = mapsClient;
    }

    public void Handle(Ride ride)
    {
        var addressWithNullLocation = ride.Locations.FirstOrDefault(add => add.Location is null);
        GeoLocation location = MapsClient.GetGeoLocation(addressWithNullLocation);

        RideManager.UpdateRideAddress(ride.Id,addressWithNullLocation.Id, location);
    }
}