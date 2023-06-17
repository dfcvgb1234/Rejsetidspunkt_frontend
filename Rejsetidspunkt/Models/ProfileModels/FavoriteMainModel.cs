using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rejsetidspunkt.Models.ProfileModels
{
    internal class FavoriteMainModel
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public string StationId { get; set; }
        public string Line { get; set; }
        public string LineImageSource { get; set; }
        public string Direction { get; set; }
    }
}
