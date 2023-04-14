using Hackamole.DoctoCab.Domain.Commands.StartRideCommand;
using Hackamole.DoctoCab.Domain.Commands.UpdateRideGeoLocation;
using Hackamole.DoctoCab.Domain.Commands.UpdateRidePricing;
using Hackamole.DoctoCab.Domain.DTOs;
using Hackamole.DoctoCab.Domain.Entities;
using Hackamole.DoctoCab.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackamole.DoctoCab.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RideController
{
    private readonly IRideManager RideManager;
    private readonly IGeoLocationClient MapsClient;
    private readonly IPricingClient PricingClient;

    public RideController(IRideManager rideManager, IGeoLocationClient mapsClient, IPricingClient pricingClient)
    {
        ArgumentNullException.ThrowIfNull(rideManager);
        ArgumentNullException.ThrowIfNull(mapsClient);
        ArgumentNullException.ThrowIfNull(pricingClient);
        
        this.RideManager = rideManager;
        this.MapsClient = mapsClient;
        this.PricingClient = pricingClient;
    }

    [HttpPost(Name = "StartRide")]
    public Ride Post(RideDTO rideDto)
    {
        ArgumentNullException.ThrowIfNull(rideDto);

        //create object
        rideDto.SurrogateId = Guid.NewGuid();
        var command = new StartRideCommand(rideDto);
        var handler = new StartRideCommandHandler(RideManager);
        
        handler.Handle(command);
        
        var ride = RideManager.GetRideBySurrogateId(rideDto.SurrogateId);
        
        //populate GeoLocation(s)
        var locationCommand = new UpdateRideGeoLocationCommand(ride);
        var locationCommandHandler = new UpdateRideGeoLocationCommandHandler(MapsClient, RideManager);
        
        locationCommandHandler.Handle(ride);

        //populate pricing
        var pricingCommand = new UpdateRidePricingCommand(ride);
        var pricingCommandHandler = new UpdateRidePricingCommandHandler(PricingClient, RideManager);
        
        pricingCommandHandler.Handle(ride);
        
        //return final object
        ride = RideManager.GetRideBySurrogateId(rideDto.SurrogateId);
        return ride;
    }
}