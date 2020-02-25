using System;
using System.Threading.Tasks;
using Template.ConsoleSolution.ConsoleApp.Features.SampleFeature;

namespace Template.ConsoleSolution.ConsoleApp
{
    internal class Startup
    {
        private readonly IMySampleFeature _mySampleFeature;

        public Startup(IMySampleFeature mySampleFeature)
        {
            _mySampleFeature = mySampleFeature;
        }

        public async Task StartApplicationAsync()
        {
            Console.WriteLine("Hello World");
            await _mySampleFeature.DoFeatureWorkAsync();
        }
    }
}