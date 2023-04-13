using Hackamole.DoctoCab.Domain.Entities;

namespace Hackamole.DoctoCab.Domain.DTOs;

public class RideDTO
{
    public int AppointmentId { get; set; }

    public Address RideFrom { get; set; }
    
    public Address RideTo { get; set; }

    public Guid SurrogateId { get; set; }
}