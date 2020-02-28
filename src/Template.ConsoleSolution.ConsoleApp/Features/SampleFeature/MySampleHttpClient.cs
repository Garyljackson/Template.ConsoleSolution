using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Template.ConsoleSolution.ConsoleApp.Infrastructure.Http;
using Template.ConsoleSolution.ConsoleApp.Models;

namespace Template.ConsoleSolution.ConsoleApp.Features.SampleFeature
{
    public class MySampleHttpClient : HttpClientBase
    {
        public MySampleHttpClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var response = await GetAsync<IEnumerable<BookDto>>(new Uri("https://localhost:44338/api/books"));
            return response;
        }

        public async Task<BookDto> CreateBook(BookDto book)
        {
            var response = await PostAsync<BookDto, BookDto>(new Uri("https://localhost:44338/api/books"), book);
            return response;
        }
    }
}