using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Models.ProfileModels
{
    internal class LoginCheckRequest
    {
        public string accessKey { get; set; }
        public string hardwareKey { get; set; }
    }
}
