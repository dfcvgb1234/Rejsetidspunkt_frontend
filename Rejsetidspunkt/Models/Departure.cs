using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rejsetidspunkt.Models
{
    public class Departure
    {
        public Departure() { }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlAttribute("stop")]
        public string Stop { get; set; }

        [XmlAttribute("time")]
        public string Time { get; set; }

        [XmlAttribute("rtTime")]
        public string RTTime { get; set; }

        [XmlAttribute("date")]
        public string Date { get; set; }

        [XmlAttribute("rtDate")]
        public string RTDate { get; set; }

        [XmlAttribute("id")]
        public string StationId { get; set; }

        [XmlAttribute("line")]
        public string Line { get; set; }

        [XmlAttribute("messages")]
        public int Messages { get; set; }

        [XmlAttribute("track")]
        public string Track { get; set; }

        [XmlAttribute("rtTrack")]
        public string RTTrack { get; set; }

        [XmlAttribute("finalStop")]
        public string FinalStop { get; set; }

        [XmlAttribute("direction")]
        public string Direction { get; set; }

        [XmlElement("JourneyDetailRef")]
        public List<JourneyDetailRef> Details { get; set; }
    }
}
