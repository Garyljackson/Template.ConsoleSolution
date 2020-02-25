using System;
using System.Threading.Tasks;

namespace Template.ConsoleSolution.ConsoleApp
{
    internal class Startup
    {
        public Task StartApplicationAsync()
        {
            Console.WriteLine("Hello World");
            return Task.CompletedTask;
        }
    }
}