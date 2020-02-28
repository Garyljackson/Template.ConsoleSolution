using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Template.ConsoleSolution.ConsoleApp.Infrastructure.Http
{
    public abstract class HttpClientBase
    {
        private readonly HttpClient _httpClient;

        protected HttpClientBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<TResponse> GetAsync<TResponse>(Uri requestUri)
        {
            var requestMessage = CreateRequest(HttpMethod.Get, requestUri);
            var responseMessage = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);

            return await GetResponseContent<TResponse>(responseMessage);
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(Uri requestUri, TRequest request)
        {
            await using var requestStream = new MemoryStream();
            await SerializeAsync(requestStream, request);

            var requestMessage = CreateRequest(HttpMethod.Post, requestUri, requestStream);
            var responseMessage = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);

            return await GetResponseContent<TResponse>(responseMessage);
        }

        protected async Task PutAsync<TRequest>(Uri requestUri, TRequest request)
        {
            await using var requestStream = new MemoryStream();
            await SerializeAsync(requestStream, request);

            var requestMessage = CreateRequest(HttpMethod.Put, requestUri, requestStream);
            await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
        }

        protected async Task<TResponse> DeleteAsync<TRequest, TResponse>(Uri requestUri)
        {
            var requestMessage = CreateRequest(HttpMethod.Delete, requestUri);
            var responseMessage = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);

            return await GetResponseContent<TResponse>(responseMessage);
        }

        private static HttpRequestMessage CreateRequest(HttpMethod httpMethod, Uri requestUri, Stream requestStream)
        {
            var streamContent = new StreamContent(requestStream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return new HttpRequestMessage(httpMethod, requestUri)
            {
                Content = streamContent
            };
        }

        private static HttpRequestMessage CreateRequest(HttpMethod httpMethod, Uri requestUri)
        {
            return new HttpRequestMessage(httpMethod, requestUri);
        }

        private static async Task<TResponse> GetResponseContent<TResponse>(HttpResponseMessage httpResponseMessage)
        {
            await using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            return await DeserializeAsync<TResponse>(contentStream);
        }

        private static async Task<T> DeserializeAsync<T>(Stream contentStream)
        {
            return await JsonSerializer.DeserializeAsync<T>(contentStream, DefaultJsonSerializerOptions.Options);
        }

        private static async Task SerializeAsync<T>(Stream stream, T request)
        {
            await JsonSerializer.SerializeAsync(stream, request, DefaultJsonSerializerOptions.Options);
            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}