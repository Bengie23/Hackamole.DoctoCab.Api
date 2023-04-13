using Hackamole.DoctoCab.Domain.Commands.StartRideCommand;
using Hackamole.DoctoCab.Domain.Commands.UpdateRideGeoLocation;
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

    public RideController(IRideManager rideManager, IGeoLocationClient mapsClient)
    {
        ArgumentNullException.ThrowIfNull(rideManager);
        ArgumentNullException.ThrowIfNull(mapsClient);
        
        this.RideManager = rideManager;
        this.MapsClient = mapsClient;
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
        
        //populate GeoLocation(s)
        
        var ride = RideManager.GetRideBySurrogateId(rideDto.SurrogateId);
        var locationCommand = new UpdateRideGeoLocationCommand(ride);
        var locationCommandHandler = new UpdateRideGeoLocationCommandHandler(MapsClient, RideManager);
        
        locationCommandHandler.Handle(ride);

        
        ride = RideManager.GetRideBySurrogateId(rideDto.SurrogateId);
        return ride;
    }
}