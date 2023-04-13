using Hackamole.DoctoCab.Data;
using Hackamole.DoctoCab.Domain.Entities;
using Hackamole.DoctoCab.Domain.Interfaces;

namespace Hackamole.DoctoCab.Services.Google;

public class GoogleMapsClient : IGeoLocationClient
{
    private readonly GoogleMapsClientOptions GoogleMapsClientOptions;

    public GoogleMapsClient(GoogleMapsClientOptions googleMapsClientOptions)
    {
        ArgumentNullException.ThrowIfNull(googleMapsClientOptions);

        this.GoogleMapsClientOptions = googleMapsClientOptions;
    }
    public GeoLocation GetGeoLocation(Address address)
    {
        return new GeoLocation()
        {
            Latitude = GoogleMapsClientOptions.Latitude,
            Longitude = GoogleMapsClientOptions.Longitude
        };
    }
}