using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services
{
    public class DistanceTimingService
    {
        public static async Task<TimeSpan> CalculateWalkTime(double x1, double x2, double y1, double y2)
        {
            var timeToWalkSeconds = await Task.Run(() =>
            {
                Location destination = new Location(x1, y1);
                Location currentLocation = new Location(x2, y2);

                double distance = Location.CalculateDistance(currentLocation, destination, DistanceUnits.Kilometers)*1000;

                // This data is compiled with real life data.
                // It takes 10 minutes to walk from my appartment to the station.
                var timeToWalkSeconds = (distance/ 607.682347461242) * 600;

                return Math.Round(timeToWalkSeconds * 100) / 100;
            });
            
            return TimeSpan.FromSeconds(timeToWalkSeconds);
        }

        public static async Task<TimeSpan> CalculateCycleTime(double x1, double x2, double y1, double y2)
        {
            var timeToWalkSeconds = await Task.Run(() =>
            {
                Location destination = new Location(x1, y1);
                Location currentLocation = new Location(x2, y2);

                double distance = Location.CalculateDistance(currentLocation, destination, DistanceUnits.Kilometers) * 1000;

                // This data is compiled with real life data.
                // It takes 10 minutes to walk from my appartment to the station.
                var timeToWalkSeconds = (distance / 607.682347461242) * 600;

                return Math.Round(timeToWalkSeconds * 100) / 100;
            });

            // We are assuming it takes half the time to cycle the distance.
            return TimeSpan.FromSeconds(timeToWalkSeconds / 2);
        }
    }
}
