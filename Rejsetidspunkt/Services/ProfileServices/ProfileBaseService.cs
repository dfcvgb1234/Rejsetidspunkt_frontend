using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Services.ProfileServices
{
    internal abstract class ProfileBaseService
    {
        protected static string BaseUrl { get; } = "https://rejsetidspunkt.azurewebsites.net/api/v1";
    }
}
