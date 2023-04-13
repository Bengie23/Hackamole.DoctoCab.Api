using Hackamole.DoctoCab.Data;

namespace Hackamole.DoctoCab.Api;

public static class DbContextExtensions
{
    public static void InitializeDb(this WebApplication? app)
    {
        ArgumentNullException.ThrowIfNull(app);
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var initializer = services.GetRequiredService<DbInitializer>();
        initializer.Run();
    }
}