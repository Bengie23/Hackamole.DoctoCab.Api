using Hackamole.DoctoCab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackamole.DoctoCab.Data;

public class RideDbContext : DbContext
{
    public DbSet<Ride> Ride { get; set; }

    public DbSet<Address> Address { get; set; }
    
    public DbSet<GeoLocation> GeoLocation { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=rides;user=root;password=password");
    }
}