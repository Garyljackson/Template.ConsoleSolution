using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Template.ConsoleSolution.ConsoleApp.Infrastructure.Settings;
using Template.ConsoleSolution.ConsoleApp.Models;

namespace Template.ConsoleSolution.ConsoleApp.Features.SampleFeature
{
    internal class MySampleFeature : IMySampleFeature
    {
        private readonly IOptions<SampleSettings> _sampleSettings;
        private readonly MySampleHttpClient _mySampleHttpClient;

        public MySampleFeature(IOptions<SampleSettings> sampleSettings, MySampleHttpClient mySampleHttpClient)
        {
            _sampleSettings = sampleSettings;
            _mySampleHttpClient = mySampleHttpClient;
        }

        public async Task DoFeatureWorkAsync()
        {
            Console.WriteLine($"Setting 1 (appsettings.json): {_sampleSettings.Value.Setting1}");
            Console.WriteLine($"Setting 2 (appsettings.Development.json): {_sampleSettings.Value.Setting2}");


            var createBookResult = await _mySampleHttpClient.CreateBook(new BookDto
            {
                Id = Guid.NewGuid(),
                Author = "Joe Soap",
                Title = "Joe's world of soap"
            });

            var allBooks = await _mySampleHttpClient.GetAllBooksAsync();
        }
    }
}