//using Marvin.StreamExtensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherStack.API

{
    class HttpClientFactoryInstanceManagementService : IIntegrationService
    {
        private readonly CancellationTokenSource _cancellationTokenSource =
        new CancellationTokenSource();

        private readonly IHttpClientFactory _httpClientFactory;


        //inject factory via contructor
        public HttpClientFactoryInstanceManagementService(IHttpClientFactory httpClientFactory)
        // WeatherClient weatherClient)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task Run()
        {
            await GetWeatherWithHttpClientFromFactory("London", "uk", _cancellationTokenSource.Token);
        }

        private async Task GetWeatherWithHttpClientFromFactory(string city, string countryCode,
            CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://api.weatherstack.com/");
            httpClient.Timeout = new TimeSpan(0, 0, 30);
            httpClient.DefaultRequestHeaders.Clear();

            var API_key = "82727441592b5987ded09df48165bc90";

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"current?access_key=YOUR_ACCESS_KEY&query=New York");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            using (var response = await httpClient.SendAsync(request,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                //var weather = stream.ReadAndDeserializeFromJson<_200>();
            }

        }
    }
}
