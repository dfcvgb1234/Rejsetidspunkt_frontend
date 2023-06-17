using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rejsetidspunkt.Models
{
    public class StopLocation
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("x")]
        public int XLocation { get; set; }

        [XmlAttribute("y")]
        public int YLocation { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
