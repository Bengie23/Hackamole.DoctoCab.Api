using System.ComponentModel.DataAnnotations.Schema;

namespace Hackamole.DoctoCab.Domain.Entities;

public class Ride
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public long AppointmentId { get; set; }
    public RideState State { get; set; }

    public ICollection<Address> Locations { get; set; }

    public PricingEstimate? PricingEstimate { get; set; }
    public Guid SurrogateId { get; set; }
}