using Rejsetidspunkt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services
{
    internal class RejseplanenTimetableService : RejseplanenAPISpecification
    {
        public async Task<List<DepartureWrapper>> GetAllDeparturesFromStationId(string stationId)
        {
            List<DepartureWrapper> departures = new List<DepartureWrapper>();
            using (HttpClient client = new HttpClient())
            {
                DateTime date = DateTime.Now;
                var getResult = await client.GetAsync(RejseplanenBaseURL + "/departureBoard?id=" + stationId + "&useBus=0&useMetro=0");

                if (getResult.IsSuccessStatusCode)
                {
                    var content = await getResult.Content.ReadAsStringAsync();

                    var dep = XMLService<DepartureBoard>.DeserializeResponse(content);

                    foreach (Departure d in dep.Departures)
                    {
                        DateTime scheduledDate = new DateTime(
                            Int32.Parse(d.Date.Split('.')[2]) + 2000,
                            Int32.Parse(d.Date.Split('.')[1]),
                            Int32.Parse(d.Date.Split('.')[0]),
                            Int32.Parse(d.Time.Split(':')[0]),
                            Int32.Parse(d.Time.Split(':')[1]),
                            0);

                        DepartureWrapper wrapper = new DepartureWrapper()
                        {
                            Name = d.Name,
                            Type = d.Type,
                            Stop = d.Stop,
                            DateTime = scheduledDate,
                            StationId = d.StationId,
                            Line = d.Line,
                            Messages = d.Messages,
                            Track = d.Track,
                            FinalStop = d.FinalStop,
                            Direction = d.Direction
                        };

                        if (!String.IsNullOrEmpty(d.RTDate) && !String.IsNullOrWhiteSpace(d.RTTime))
                        {
                            wrapper.DateTime = new DateTime(
                            Int32.Parse(d.RTDate.Split('.')[2]) + 2000,
                            Int32.Parse(d.RTDate.Split('.')[1]),
                            Int32.Parse(d.RTDate.Split('.')[0]),
                            Int32.Parse(d.RTTime.Split(':')[0]),
                            Int32.Parse(d.RTTime.Split(':')[1]),
                            0);
                        }

                        if (!String.IsNullOrWhiteSpace(d.RTTrack))
                        {
                            wrapper.Track = d.RTTrack;
                        }

                        departures.Add(wrapper);
                    }
                }

                return departures;
            }
        }

        public async Task<DepartureWrapper> GetFirstDepartureForTrain(string stationId, string trainLine, string direction)
        {
            var departures = await GetAllDeparturesFromStationId(stationId);

            return departures.First(x => x.Name == trainLine && x.FinalStop.ToLower().Contains(direction.ToLower()));
        }
    }
}
