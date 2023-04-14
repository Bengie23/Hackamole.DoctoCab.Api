namespace Hackamole.DoctoCab.Domain.Entities;

public class PricingEstimate
{
    public int Id { get; set; }
    public decimal PriceEstimate { get; set; }

    public DateTime EstimationCreated { get; set; }
}