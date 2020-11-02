using Marvin.StreamExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherStack.API.Models;


namespace WeatherStack.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly CancellationTokenSource _cancellationTokenSource =
            new CancellationTokenSource();

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<Tempature>GetiTempWithZipAsync(string zip)
        {
            var token = _cancellationTokenSource.Token;


            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://api.weatherstack.com/");
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();

            var API_key = "82727441592b5987ded09df48165bc90";

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"current?access_key={API_key}&query={zip}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            using (var response = await httpClient.SendAsync(request,
                HttpCompletionOption.ResponseHeadersRead,
                token))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var temp = stream.ReadAndDeserializeFromJson<Tempature>();
                return temp;
            }
        }
        public async Task<Tempature>GetiTempWithCityAsync(string city)
        {
            var token = _cancellationTokenSource.Token;


            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://api.weatherstack.com/");
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();

            var API_key = "82727441592b5987ded09df48165bc90";

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"current?access_key={API_key}&query={city}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            using (var response = await httpClient.SendAsync(request,
                HttpCompletionOption.ResponseHeadersRead,
                token))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var temp = stream.ReadAndDeserializeFromJson<Tempature>();
                return temp;
            }
        }
    }
}
