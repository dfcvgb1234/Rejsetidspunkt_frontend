using Rejsetidspunkt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services
{
    internal class RejseplanenLocationService : RejseplanenAPISpecification
    {
        public async  Task<LocationList> GetLocationById(string stationId)
        {
            using (HttpClient client = new HttpClient())
            {
                var getResult = await client.GetAsync(RejseplanenBaseURL + "/location?input=" + stationId);
                
                if (getResult.IsSuccessStatusCode)
                {
                    var content = await getResult.Content.ReadAsStringAsync();

                    return XMLService<LocationList>.DeserializeResponse(content);
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<LocationList> GetClosestLocations(int meters, double x, double y)
        {
            using (HttpClient client = new HttpClient())
            {
                var getResult = await client.GetAsync(RejseplanenBaseURL + "/stopsNearby?" + String.Format("coordX={0}&coordY={1}&maxRadius={2}&maxNumber=30",
                    x, y, meters));

                if (getResult.IsSuccessStatusCode)
                {
                    var content = await getResult.Content.ReadAsStringAsync();

                    return XMLService<LocationList>.DeserializeResponse(content);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
