using Organimmo.Services.Model;
using System.Net.Http.Json;
using Organimmo.SDK.Contract;

namespace Organimmo.SDK
{
    public class TranslateAPI: ITranslateAPI
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
    }
}