using Hackamole.DoctoCab.Domain.Entities;

namespace Hackamole.DoctoCab.Domain.Interfaces;

public interface IPricingClient
{
    PricingEstimate GetPricingEstimate(Ride ride);
}