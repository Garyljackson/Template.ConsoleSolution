using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Template.ConsoleSolution.ConsoleApp.Infrastructure.Settings;

namespace Template.ConsoleSolution.ConsoleApp.Features.SampleFeature
{
    internal class MySampleFeature : IMySampleFeature
    {
        private readonly IOptions<SampleSettings> _sampleSettings;
        private readonly ISampleHttpClient _sampleHttpClient;

        public MySampleFeature(IOptions<SampleSettings> sampleSettings, ISampleHttpClient sampleHttpClient)
        {
            _sampleSettings = sampleSettings;
            _sampleHttpClient = sampleHttpClient;
        }

        public async Task DoFeatureWorkAsync()
        {
            Console.WriteLine($"Setting 1 (appsettings.json): {_sampleSettings.Value.Setting1}");
            Console.WriteLine($"Setting 2 (appsettings.Development.json): {_sampleSettings.Value.Setting2}");

            await _sampleHttpClient.DoSomethingWithTheClient();
        }
    }
}