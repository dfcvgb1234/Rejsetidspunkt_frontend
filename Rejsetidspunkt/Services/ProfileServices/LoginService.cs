using Rejsetidspunkt.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services.ProfileServices
{
    internal class LoginService : ProfileBaseService
    {
        public static async Task<bool> Login(string username, string password)
        {
            string hardwareKey = generateHardwareKey(75);
            LoginRequest request = new LoginRequest()
            {
                username = username,
                userPassword = password,
                hardwareKey = hardwareKey
            };

            using (HttpClient client = new HttpClient())
            {
                var content = JsonSerializer.Serialize(request);
                var response = await client.PostAsync(BaseUrl + "/session/login", new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();

                    LocalStorageService.SaveStringToStorage("AccessKey", stringContent);
                    LocalStorageService.SaveStringToStorage("HardwareKey", hardwareKey);

                    return true;
                }
                return false;
            }
        }

        public static async Task<bool> CheckLogin()
        {
            var accessKey = LocalStorageService.GetStringFromStorage("AccessKey");
            var hardwareKey = LocalStorageService.GetStringFromStorage("HardwareKey");

            LoginCheckRequest request = new LoginCheckRequest()
            {
                accessKey = accessKey,
                hardwareKey = hardwareKey
            };

            using (HttpClient client = new HttpClient())
            {
                var content = JsonSerializer.Serialize(request);
                var response = await client.PostAsync(BaseUrl + "/session/check", new StringContent(content, Encoding.UTF8, "application/json"));

                return response.IsSuccessStatusCode;
            }
        }

        public static async Task Logout()
        {
            var accessKey = LocalStorageService.GetStringFromStorage("AccessKey");
            var hardwareKey = LocalStorageService.GetStringFromStorage("HardwareKey");

            LoginCheckRequest request = new LoginCheckRequest()
            {
                accessKey = accessKey,
                hardwareKey = hardwareKey
            };

            using (HttpClient client = new HttpClient())
            {
                var content = JsonSerializer.Serialize(request);
                var response = await client.PostAsync(BaseUrl + "/session/logout", new StringContent(content, Encoding.UTF8, "application/json"));

                LocalStorageService.DeleteStringFromStorage("AccessKey");
                LocalStorageService.DeleteStringFromStorage("HardwareKey");
            }
        }

        private static string generateHardwareKey(int length)
        {
            Random rand = new Random();
            string charbase = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, length)
                   .Select(_ => charbase[rand.Next(charbase.Length)])
                   .ToArray());
        }

        public static async Task<UserResponse> GetLoggedInAcount()
        {
            var accessKey = LocalStorageService.GetStringFromStorage("AccessKey");
            var hardwareKey = LocalStorageService.GetStringFromStorage("HardwareKey");

            LoginCheckRequest request = new LoginCheckRequest()
            {
                accessKey = accessKey,
                hardwareKey = hardwareKey
            };

            using (HttpClient client = new HttpClient())
            {
                var content = JsonSerializer.Serialize(request);
                var response = await client.PostAsync(BaseUrl + "/session/user", new StringContent(content, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<UserResponse>(stringContent);

                }
                return null;
            }
        }
    }
}
