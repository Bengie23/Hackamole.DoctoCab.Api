using Hackamole.DoctoCab.Domain.Entities;

namespace Hackamole.DoctoCab.Data;

public class RideDbSeeder
{
    private readonly RideDbContext DbContext;

    public RideDbSeeder(RideDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        this.DbContext = dbContext;
    }

    public void Seed()
    {
        DbContext.Ride.Add(new Ride()
        {
            AppointmentId = 1,
            Created = DateTime.Now,
            State = RideState.Empty,
            Locations = new List<Address>()
            {
                new Address()
                {
                    City = "Montreal",
                    Province = "QC",
                    PostalCode = "H2J 3M2",
                    Street = "4244 Rue Chambord",
                    Country = "CA",
                    IsOrigin = true
                },
                new Address()
                {
                    City = "Montreal",
                    Province = "QC",
                    PostalCode = "H2T 3B3",
                    Street = "5455 Av. de Gaspé",
                    Country = "CA"
                }
            }
        });
        
        DbContext.SaveChanges();
    }
}