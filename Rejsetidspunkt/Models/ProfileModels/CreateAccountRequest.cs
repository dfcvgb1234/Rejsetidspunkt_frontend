using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Models.ProfileModels
{
    internal class CreateAccountRequest
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
