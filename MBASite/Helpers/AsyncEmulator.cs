using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;

namespace MBASite.Helpers
{
    public class AsyncEmulator
    {
        public static List<T> EmulateAsync<T>(string endpoint)
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
    }
}