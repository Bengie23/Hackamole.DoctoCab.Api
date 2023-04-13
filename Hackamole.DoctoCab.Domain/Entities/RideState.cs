namespace Hackamole.DoctoCab.Domain.Entities;

public enum RideState
{
    Empty,
    WithGeoLocation,
    WithPriceEstimation,
    Scheduled,
    Completed
}