using Hackamole.DoctoCab.Domain.Entities;

namespace Hackamole.DoctoCab.Domain.Interfaces;

public interface IGeoLocationClient
{
    GeoLocation GetGeoLocation(Address address);
}