using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MBASite.Helpers
{
    public class ConfigureComments
    {
        /// <summary>
        /// Deserialize xml data
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Returns Comments object</returns>
        public static Comments DeserializeComments(string comment)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Comments));
            var stringReader = new System.IO.StringReader(comment);
            return serializer.Deserialize(stringReader) as Comments;
        }

        /// <summary>
        /// Serialize Comments object to xml string
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static string SerializeComments(Comments comment)
        {
            var stringWriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(typeof(Comments));
            serializer.Serialize(stringWriter, comment);
            return stringWriter.ToString();
        }

        /// <summary>
        /// Adds a new comment to existing comments
        /// </summary>
        /// <param name="comments"></param>
        /// <param name="newComment"></param>
        /// <returns></returns>
        public static Comments AddNewComment(Comments comments, string newComment)
        {
            comments.comments.Add(DeserializeSingleComment(newComment));
            return comments;
        }

        /// <summary>
        /// Deserialize a single comment and returns a Comment object
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static Comment DeserializeSingleComment(string comment)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Comment));
            var stringReader = new System.IO.StringReader(comment);
            return serializer.Deserialize(stringReader) as Comment;
        }
    }
}