namespace Hackamole.DoctoCab.Data;

public class DbInitializer
{
    private readonly RideDbContext DbContext;
    private readonly RideDbSeeder DbSeeder;

    public DbInitializer(RideDbContext dbContext, RideDbSeeder dbSeeder)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
        ArgumentNullException.ThrowIfNull(dbSeeder);
        
        this.DbContext = dbContext;
        this.DbSeeder = dbSeeder;
    }

    public void Run()
    {
        DbContext.Database.EnsureDeleted();
        DbContext.Database.EnsureCreated();
        
        DbSeeder.Seed();
    }
}