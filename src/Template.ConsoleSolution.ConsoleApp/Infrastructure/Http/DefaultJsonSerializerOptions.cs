using System.Text.Json;

namespace Template.ConsoleSolution.ConsoleApp.Infrastructure.Http
{
    public static class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions Options =>
            new JsonSerializerOptions
                {PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
    }
}