using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Core
{
    public class NutritionService
    {
        public static Hits GetNutritionFor(string foodItem)
        {
            var httpRequest = (HttpWebRequest)HttpWebRequest.Create($"https://nutritionix-api.p.mashape.com/v1_1/search/{foodItem}");

            httpRequest.Method = "GET";

            httpRequest.Headers.Add("X-Mashape-Key", "3tJvBRAwkUmshH7yHao6x84jllbZp1ETXLojsnEQdmxJbD19Kj");
            httpRequest.Accept = "application/json";

            var httpResponse = httpRequest.GetResponse();

            var httpResponseStream = httpResponse.GetResponseStream();

            using (var streamReader = new StreamReader(httpResponseStream))
            {
                string json = streamReader.ReadToEnd();

                // parse json into an object
                var o = JObject.Parse(json);

                // get the hits array
                var oHits = o["hits"];

                // get the first hit as a json string
                string firstHitJson = oHits.First["fields"].ToString();
                return JsonConvert.DeserializeObject<Hits>(firstHitJson);
            }
        }
    }
}
