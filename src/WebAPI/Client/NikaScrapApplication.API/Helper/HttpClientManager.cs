using System.Net.Http.Headers;
using System.Text.Json;

namespace NikaScrapApplication.API.Helper
{
    public class HttpClientManager
    {
        private readonly HttpClient _httpClient;

        public HttpClientManager(string baseAddress)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(endpoint);
            httpResponseMessage.EnsureSuccessStatusCode();
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            var response = System.Text.Json.JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });

            if (response == null)
            {
                throw new InvalidOperationException("Deserialization returned null.");
            }

            return response!;
        }

        public async Task<T> PostAsync<T>(string endpoint, HttpContent content)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(endpoint, content);
            httpResponseMessage.EnsureSuccessStatusCode();
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            var response = System.Text.Json.JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });

            if (response == null)
            {
                throw new InvalidOperationException("Deserialization returned null.");
            }

            return response!;
        }
        public async Task<T> PutAsync<T>(string endpoint, HttpContent content)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsync(endpoint, content);
            httpResponseMessage.EnsureSuccessStatusCode();
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = System.Text.Json.JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });

            if (response == null)
            {
                throw new InvalidOperationException("Deserialization returned null.");
            }

            return response!;
        }

        public async Task<T> DeleteAsync<T>(string endpoint)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync(endpoint);
            httpResponseMessage.EnsureSuccessStatusCode();
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = System.Text.Json.JsonSerializer.Deserialize<T>(responseBody, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });

            if (response == null)
            {
                throw new InvalidOperationException("Deserialization returned null.");
            }

            return response!;
        }
    }
}
