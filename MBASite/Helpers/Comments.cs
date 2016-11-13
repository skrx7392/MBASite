using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MBASite.Helpers
{
    [XmlRoot("Comments")]
    public class Comments
    {
        [XmlElement("Comment")]
        public List<Comment> comments { get; set; }
    }

    public class Comment
    {
        [XmlAttribute("Author")]
        public string Author { get; set; }
        [XmlAttribute("Date")]
        public DateTime Date { get; set; }
    }
}