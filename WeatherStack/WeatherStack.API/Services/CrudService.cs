//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenWeather.Client.Services
{


    public class CRUDService : WeatherStack.API.IIntegrationService
    {
            //        var API_key = "2e5bfdfdea878d6f3a01d80aa50213a8";
        private static HttpClient _httpClient = new HttpClient();
        public CRUDService()
        {

            // set up HttpClient instance

            _httpClient.BaseAddress = new Uri("http://api.weatherstack.com/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task Run()
        {
             await GetResource();
        }

    
        public async Task GetResource()
        {                
            var API_key = "82727441592b5987ded09df48165bc90";

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"current?access_key=YOUR_ACCESS_KEY&query=New York");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            //var weather = new _200();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
              //  weather = JsonConvert.DeserializeObject<Tempature>(content);
            }
            else if (response.Content.Headers.ContentType.MediaType == "application/xml")
            {
                //var serializer = new XmlSerializer(typeof(List<_200>));
                //weather = (_200)serializer.Deserialize(new StringReader(content));
            }
        }

    }
}


