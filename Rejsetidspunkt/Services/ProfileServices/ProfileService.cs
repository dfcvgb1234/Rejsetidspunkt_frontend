using Rejsetidspunkt.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services.ProfileServices
{
    internal class ProfileService : ProfileBaseService
    {
        public static async Task<bool> CreateAccount(string email, string username, string password)
        {
            CreateAccountRequest request = new CreateAccountRequest()
            {
                email = email,
                username = username,
                password = password
            };

            using (HttpClient client = new HttpClient())
            {
                var content = JsonSerializer.Serialize(request);
                var response = await client.PostAsync(BaseUrl + "/users", new StringContent(content, Encoding.UTF8, "application/json"));

                return response.IsSuccessStatusCode;
            }
        }
    }
}
