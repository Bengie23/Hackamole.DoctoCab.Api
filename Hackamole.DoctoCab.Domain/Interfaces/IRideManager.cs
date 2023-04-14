using Hackamole.DoctoCab.Domain.DTOs;
using Hackamole.DoctoCab.Domain.Entities;

namespace Hackamole.DoctoCab.Domain.Interfaces;

public interface IRideManager
{
    void StartRide(RideDTO ride);

    Ride GetRideBySurrogateId(Guid surrogateId);

    void UpdateRideAddress(Guid rideId, int addressId, GeoLocation location);

    void UpdateRidePricing(Guid rideId, PricingEstimate pricingEstimate);
}