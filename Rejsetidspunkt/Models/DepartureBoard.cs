using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rejsetidspunkt.Models
{
    public class DepartureBoard
    {
        [XmlElement("Departure")]
        public List<Departure> Departures { get; set; }

        public DepartureBoard() { }
    }
}
