using Hackamole.DoctoCab.Api;
using Hackamole.DoctoCab.Data;
using Hackamole.DoctoCab.Domain.Interfaces;
using Hackamole.DoctoCab.Services.Google;
using Hackamole.DoctoCab.Services.Uber;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
GoogleMapsClientOptions googleMapsClientOptions = new GoogleMapsClientOptions();
builder.Configuration.GetSection(nameof(GoogleMapsClientOptions)).Bind(googleMapsClientOptions);
builder.Services.AddSingleton<GoogleMapsClientOptions>(googleMapsClientOptions);

UberPricingClientOptions uberPricingClientOptions = new UberPricingClientOptions();
builder.Configuration.GetSection(nameof(UberPricingClientOptions)).Bind(uberPricingClientOptions);
builder.Services.AddSingleton<UberPricingClientOptions>(uberPricingClientOptions);

builder.Services.AddDbContext<RideDbContext>();
builder.Services.AddTransient<DbInitializer>();
builder.Services.AddTransient<RideDbSeeder>();
builder.Services.AddScoped<IRideManager, RideManager>();
builder.Services.AddScoped<IGeoLocationClient, GoogleMapsClient>();
builder.Services.AddScoped<IPricingClient, UberPricingClient>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.InitializeDb();

app.Run();
