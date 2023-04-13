using Hackamole.DoctoCab.Domain.DTOs;
using Hackamole.DoctoCab.Domain.Entities;
using Hackamole.DoctoCab.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hackamole.DoctoCab.Data;

public class RideManager : IRideManager
{
    private readonly RideDbContext DbContext;

    public RideManager(RideDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        this.DbContext = dbContext;
    }

    public void StartRide(RideDTO rideDto)
    {
        Ride ride = new Ride()
        {
            SurrogateId = rideDto.SurrogateId,
            AppointmentId = rideDto.AppointmentId,
            Created = DateTime.Now,
            State = RideState.Empty,
            Locations = new List<Address>()
            {
                new Address()
                {
                    City = rideDto.RideFrom.City,
                    Country = rideDto.RideFrom.Country,
                    IsOrigin = true,
                    PostalCode = rideDto.RideFrom.PostalCode,
                    Street = rideDto.RideFrom.Street,
                    Province = rideDto.RideFrom.Province
                },
                new Address()
                {
                    City = rideDto.RideTo.City,
                    Country = rideDto.RideTo.Country,
                    PostalCode = rideDto.RideTo.PostalCode,
                    Street = rideDto.RideTo.Street,
                    Province = rideDto.RideTo.Province
                }
            }
        };
        DbContext.Ride.Add(ride);
        DbContext.SaveChanges();
    }

    public Ride GetRideBySurrogateId(Guid surrogateId)
    {
        return DbContext.Ride.Where(ride => ride.SurrogateId == surrogateId).FirstOrDefault();
    }

    public void UpdateRideAddress(Guid rideId, int addressId, GeoLocation location)
    {
        var ride = DbContext.Ride.Include(x => x.Locations).FirstOrDefault(ride => ride.Id == rideId);
        var address = ride.Locations.FirstOrDefault(loc => loc.Id == addressId);
        address.Location = location;

        DbContext.SaveChanges();
    }
}