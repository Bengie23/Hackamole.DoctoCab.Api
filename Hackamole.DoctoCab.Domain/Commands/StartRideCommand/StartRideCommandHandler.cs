using Hackamole.DoctoCab.Domain.Entities;
using Hackamole.DoctoCab.Domain.Interfaces;

namespace Hackamole.DoctoCab.Domain.Commands.StartRideCommand;

public class StartRideCommandHandler
{
    private readonly IRideManager RideManager;

    public StartRideCommandHandler(IRideManager rideManager)
    {
        ArgumentNullException.ThrowIfNull(rideManager);
        this.RideManager = rideManager;
    }

    public void Handle(StartRideCommand command)
    {
        RideManager.StartRide(command.DTO);
    }
}