using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MBASite.Helpers
{
    public class ConfigureComments
    {
        public static comments DeserializeComments(string comment)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(comments));
            var stringReader = new System.IO.StringReader(comment);
            return serializer.Deserialize(stringReader) as comments;
        }

        public static string SerializeComments(comments comment)
        {
            var stringWriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(typeof(comments));
            serializer.Serialize(stringWriter, comment);
            return stringWriter.ToString();
        }
    }
}