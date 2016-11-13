using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace MBASite.Helpers
{
    public class ContactApi
    {
        public static List<T> GetDataFromApi<T>(string endpoint)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = url + System.Web.Configuration.WebConfigurationManager.AppSettings[endpoint];
            var list = new List<T>();
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(uri))
                {
                    string jsonString = response.Result.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<T>>(jsonString);
                    return list;
                }
            }
        }

        public static bool PostToApi<T>(T details, string endpoint)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings[endpoint];
            var jsonString = new JavaScriptSerializer().Serialize(details);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var httpResponse = client.PostAsync(url + uri, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    return responseContent.Equals("\"Success\"") ? true : false;
                }
            }
            return false;
        }
    }
}