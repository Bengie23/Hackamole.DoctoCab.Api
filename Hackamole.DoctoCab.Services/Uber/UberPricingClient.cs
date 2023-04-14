using Hackamole.DoctoCab.Data;
using Hackamole.DoctoCab.Domain.Entities;
using Hackamole.DoctoCab.Domain.Interfaces;

namespace Hackamole.DoctoCab.Services.Uber;

public class UberPricingClient : IPricingClient
{
    private readonly UberPricingClientOptions UberPricingClientOptions;

    public UberPricingClient(UberPricingClientOptions uberPricingClientOptions)
    {
        ArgumentNullException.ThrowIfNull(uberPricingClientOptions);
        this.UberPricingClientOptions = uberPricingClientOptions;
    }
    public PricingEstimate GetPricingEstimate(Ride ride)
    {
        if (Decimal.TryParse(UberPricingClientOptions.PriceEstimation, out decimal pricing))
        {
            return new PricingEstimate()
            {
                EstimationCreated = DateTime.Now,
                PriceEstimate = pricing
            };
        }

        return null;
    }
}