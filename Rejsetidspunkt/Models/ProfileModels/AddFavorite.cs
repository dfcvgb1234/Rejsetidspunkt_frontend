using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Models.ProfileModels
{
    internal class AddFavoriteRequest
    {
        public int id { get; set; }
        public string stationId { get; set; }
        public string line { get; set; }
        public string direction { get; set; }
    }
}

