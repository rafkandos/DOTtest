using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EngineeringTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EngineeringTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchController : ControllerBase
    {
        private readonly ProvinceCityDBContext _context;

        public FetchController(ProvinceCityDBContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<status>> GetFetch(string name)
        {
            status output = new status();

            if(name == "province")
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.rajaongkir.com/starter/province?key=0df6d5bf733214af6c6644eb8717c92c"));

                WebReq.Method = "GET";

                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Console.WriteLine(WebResp.StatusCode);
                Console.WriteLine(WebResp.Server);

                string jsonString;
                using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }

                var item = JsonConvert.DeserializeObject<ResultAPI>(jsonString);

                var jsonObj = JObject.Parse(jsonString);
                var asd = jsonObj.SelectToken("rajaongkir");
                //JObject JObjecta = JObject.Parse();
                JArray resut = (JArray)asd.SelectToken("results");

                foreach (JToken r in resut)
                {
                    var value = (string)r.SelectToken("province");
                    Province p = new Province();
                    p.province = value;
                    _context.Province.Add(p);
                }

                output.code = 200;
                output.description = "OKE";
            }

            if (name == "city")
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.rajaongkir.com/starter/city?key=0df6d5bf733214af6c6644eb8717c92c"));

                WebReq.Method = "GET";

                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Console.WriteLine(WebResp.StatusCode);
                Console.WriteLine(WebResp.Server);

                string jsonString;
                using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }

                var item = JsonConvert.DeserializeObject<ResultAPI>(jsonString);

                var jsonObj = JObject.Parse(jsonString);
                var asd = jsonObj.SelectToken("rajaongkir");
                //JObject JObjecta = JObject.Parse();
                JArray resut = (JArray)asd.SelectToken("results");

                foreach (JToken r in resut)
                {
                    var value = (string)r.SelectToken("city");
                    var cat = (string)r.SelectToken("type");
                    var post = (string)r.SelectToken("postal_code");
                    City c = new City();
                    c.city_name = value;

                    _context.City.Add(c);
                }

                output.code = 200;
                output.description = "OKE";
                
            }

            return output;
        }
    }
}