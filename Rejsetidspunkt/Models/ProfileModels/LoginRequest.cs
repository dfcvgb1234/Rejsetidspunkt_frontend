using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Models.ProfileModels
{
    internal class LoginRequest
    {
        public string username { get; set; }
        public string userPassword { get; set; }
        public string hardwareKey { get; set; }
    }
}
