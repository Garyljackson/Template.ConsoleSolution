using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Template.ConsoleSolution.ConsoleApp.Features.SampleFeature
{
    public class SampleHttpClient : ISampleHttpClient
    {
        private readonly HttpClient _httpClient;

        public SampleHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DoSomethingWithTheClient()
        {
            var result = await _httpClient.GetStringAsync(new Uri("https://www.google.com"));
        }
    }
}