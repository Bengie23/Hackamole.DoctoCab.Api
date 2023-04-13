using Hackamole.DoctoCab.Domain.DTOs;

namespace Hackamole.DoctoCab.Domain.Commands.StartRideCommand;

public class StartRideCommand
{
    public RideDTO DTO { get; protected set; }

    public StartRideCommand(RideDTO dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        this.DTO = dto;
    }
}