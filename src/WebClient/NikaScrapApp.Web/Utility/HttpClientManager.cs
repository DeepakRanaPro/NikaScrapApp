using System.Net.Http.Headers;
using System;
using System.Net.Http;
  

namespace NikaScrapApp.Web.Utility
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
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseBody);
        }

        public async Task<T> PostAsync<T>(string endpoint, HttpContent content)
        {
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseBody);
        } 
        public async Task<T> PutAsync<T>(string endpoint, HttpContent content)
        {
            HttpResponseMessage response = await _httpClient.PutAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseBody);
        }

        public async Task<T> DeleteAsync<T>(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseBody);
        }
    }

    public class ClientApp
    {
     public async void RunAsync()
        {
            var httpClientManager = new HttpClientManager("https://api.example.com/");

            // Example GET request
            var user = await httpClientManager.GetAsync<User>("users/1");
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}");

            // Example POST request
            var newUser = new User { Name = "Alice", Email = "alice@example.com" };
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(newUser), System.Text.Encoding.UTF8, "application/json");
            var createdUser = await httpClientManager.PostAsync<User>("users", content);
           
            Console.WriteLine($"Created Id: {createdUser.Id}, Name: {createdUser.Name}, Email: {createdUser.Email}"
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set}
    }
}
