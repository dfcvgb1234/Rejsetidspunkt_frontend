using Rejsetidspunkt.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services.ProfileServices
{
    internal class FavoritesService : ProfileBaseService
    {
        public static async Task AddFavorite(string stationId, string line, string direction)
        {
            AddFavoriteRequest request = new AddFavoriteRequest()
            {
                stationId = stationId,
                line = line,
                direction = direction
            };

            string accessKey = LocalStorageService.GetStringFromStorage("AccessKey");

            using (HttpClient client = new HttpClient())
            {
                var content = JsonSerializer.Serialize(request);
                var response = await client.PostAsync(BaseUrl + "/favorites/" + accessKey, new StringContent(content, Encoding.UTF8, "application/json"));
            }
        }

        public static async Task<FavoriteMainModel> GetSingleFavoriteById(int id)
        {
            string accessKey = LocalStorageService.GetStringFromStorage("AccessKey");
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + "/favorites/" + accessKey + "/" + id);

                var stringResponse = await response.Content.ReadAsStringAsync();

                var favorite = JsonSerializer.Deserialize<FavoriteResponse>(stringResponse);
                var stations = STrainStationService.Load().Stations;
                return new FavoriteMainModel()
                {
                    Id = favorite.id,
                    Line = favorite.line,
                    StationId = favorite.stationId,
                    Direction = favorite.direction,
                    LineImageSource = "images/" + favorite.line.ToLower() + "_train.png",
                    StationName = stations.First(x => x.Id == favorite.stationId).Name
                };
            }
        }

        public static async Task<List<FavoriteModel>> GetAllFavorites()
        {
            string accessKey = LocalStorageService.GetStringFromStorage("AccessKey");

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl + "/favorites/" + accessKey);

                var stringResponse = await response.Content.ReadAsStringAsync();

                var favorites = JsonSerializer.Deserialize<List<FavoriteResponse>>(stringResponse);

                var stations = STrainStationService.Load().Stations;

                List<FavoriteModel> result = new List<FavoriteModel>();
                foreach (FavoriteResponse res in favorites)
                {
                    result.Add(new FavoriteModel()
                    {
                        Id = res.id,
                        Direction = res.direction,
                        LineImageSource = "images/" + res.line.ToLower() + "_train.png",
                        StationName = stations.First(x => x.Id == res.stationId).Name
                    });
                }

                return result;
            }
        }

        public static async Task RemoveFavorite(int id)
        {
            string accessKey = LocalStorageService.GetStringFromStorage("AccessKey");

            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(BaseUrl + "/favorites/" + accessKey + "/" + id);
            }
        }
    }
}
