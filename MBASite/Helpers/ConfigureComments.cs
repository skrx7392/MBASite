using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MBASite.Helpers
{
    public class ConfigureComments
    {
        public static Comments DeserializeComments(string comment)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Comments));
            var stringReader = new System.IO.StringReader(comment);
            return serializer.Deserialize(stringReader) as Comments;
        }

        public static string SerializeComments(Comments comment)
        {
            var stringWriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(typeof(Comments));
            serializer.Serialize(stringWriter, comment);
            return stringWriter.ToString();
        }

        public static Comments AddNewComment(Comments comments, string newComment)
        {
            comments.comments.Add(DeserializeSingleComment(newComment));
            return comments;
        }

        public static Comment DeserializeSingleComment(string comment)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Comment));
            var stringReader = new System.IO.StringReader(comment);
            return serializer.Deserialize(stringReader) as Comment;
        }
    }
}