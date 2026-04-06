using Services.Abstractions;
using Services.Contracts.ExternalClients;
using System.Text.Json;

namespace ExternalClients
{
    public class CardDataCollectorClient : IDataCollectionService
    {
        private readonly HttpClient _httpClient;
        public CardDataCollectorClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExternalCardDataDto> GetContentProductAsync(string productId, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"={productId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();


            var apiResponse = JsonSerializer.Deserialize<ExternalCardDataDto>(content);

            return apiResponse;
        }

        public async Task<ExternalCardDataDto> GetCardDataAsync(string productId, CancellationToken token = default)
        {
            var response = await _httpClient.GetAsync($"api/card-data/{productId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonSerializer.Deserialize<ExternalCardDataDto>(content);

            return apiResponse;
        }
    }
}
