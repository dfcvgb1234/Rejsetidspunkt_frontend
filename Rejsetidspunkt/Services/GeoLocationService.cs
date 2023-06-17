using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services
{
    internal class GeoLocationService
    {
        public async Task<bool> HasPermissions()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            return status == PermissionStatus.Granted;
        }

        public async Task<bool> AskForPermissions()
        {
            if (await HasPermissions())
            {
                return true;
            }

            var result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return result == PermissionStatus.Granted;
        }

        public async Task<Location> GetCurrentUserLocation()
        {
            if (await HasPermissions() == false)
            {
                return new Location(55.675758, 12.569020);
            }

            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                return await Geolocation.Default.GetLocationAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new Location(55.675758, 12.569020);
            }
        }
    }
}
