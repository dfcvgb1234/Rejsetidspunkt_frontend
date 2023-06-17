using Rejsetidspunkt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services
{
    public class STrainStationService
    {
        public List<StationModel> Stations { get; }

        public static STrainStationService Load()
        {
            Stream fileStream = FileSystem.OpenAppPackageFileAsync("Stogsstationer.csv").Result;


            List<StationModel> stations = new List<StationModel>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = reader.ReadLine();

                while (!String.IsNullOrWhiteSpace(line))
                {
                    StationModel model = new StationModel();
                    string[] lineContent = line.Split(';');
                    
                    model.Id = lineContent[0].Trim();
                    model.Name = lineContent[1].Replace("\"", "").Trim();
                    model.X = lineContent[2].Trim();
                    model.Y= lineContent[3].Trim();

                    stations.Add(model);

                    line = reader.ReadLine();
                }
            }

            return new STrainStationService(stations);
        }

        public async Task<List<StationModel>> GetClosestStations(int meters, double x, double y)
        {
            RejseplanenLocationService locationService = new RejseplanenLocationService();
            var closestStations = await locationService.GetClosestLocations(meters, x, y);

            return FindSTrainMatches(closestStations);
        }

        private List<StationModel> FindSTrainMatches(LocationList closestStations)
        {
            List<StationModel> stationMatches = new List<StationModel>();
            foreach (StopLocation location in closestStations.StopLocations)
            {
                var stationMatch = Stations.Where(x => x.Name.ToLower() == location.Name.ToLower()).First();
                if (stationMatch != null)
                {
                    stationMatches.Add(stationMatch);
                }
            }

            return stationMatches;
        }

        private STrainStationService(List<StationModel> stations)
        {
            this.Stations = stations;
        }
    }
}
