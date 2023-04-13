using Hackamole.DoctoCab.Domain.Entities;

namespace Hackamole.DoctoCab.Domain.Interfaces;

public interface IUberClient
{
    PricingEstimate GetPricingEstimate(Ride ride);
}