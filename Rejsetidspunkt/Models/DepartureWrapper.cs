using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rejsetidspunkt.Models
{
    internal class DepartureWrapper
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Stop { get; set; }

        public DateTime DateTime { get; set; }

        public string StationId { get; set; }

        public string Line { get; set; }

        public int Messages { get; set; }

        public string Track { get; set; }

        public string FinalStop { get; set; }

        public string Direction { get; set; }
    }
}
