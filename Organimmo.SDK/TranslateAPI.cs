using Organimmo.Services.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace Organimmo.SDK
{
    public class TranslateAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TranslateAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<RootDto> Get(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("TranslateAPI");

            var route = $"root/{id}";
            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadFromJsonAsync<RootDto>();
        }

        public async Task<IList<ItemDto>> Find()
        {
            var httpClient = _httpClientFactory.CreateClient("TranslateAPI");

            var route = "item";
            var httpResponse = await httpClient.GetAsync(route);

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadFromJsonAsync<IList<ItemDto>>();
        }

        public async Task<ItemDto>? CreateTranslation(ItemDto item)
        {
            var httpClient = _httpClientFactory.CreateClient("TranslateAPI");

            var route = $"TranslateWordAsync?text={item.BaseText}&translation={item.CurrentText}";
            var httpResponse = await httpClient.PostAsJsonAsync<ItemDto>(route, item);

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadFromJsonAsync<ItemDto>();
        }


        public async Task<RootDto>? CreateRootObject(RootDto root)
        {
            var httpClient = _httpClientFactory.CreateClient("TranslateAPI");

            var route = $"/SerializeRootAsync";
            var httpResponse = await httpClient.PostAsJsonAsync<RootDto>(route, root);

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadFromJsonAsync<ItemDto>();
        }
    }
}