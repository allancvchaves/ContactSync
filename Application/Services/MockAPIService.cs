using System.Text.Json;
using Application.Entities;
using Application.Interfaces;

namespace Application.Services
{
    public class MockAPIService : IMockAPIService
    {
        private readonly HttpClient _httpClient;

        public MockAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Contact>> GetMockContacts()
        {
            var apiUrl = "https://challenge.trio.dev/api/v1/contacts";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var contacts = JsonSerializer.Deserialize<List<Contact>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return contacts ?? new List<Contact>();

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching contacts: {ex.Message}");
                return new List<Contact>();
            }
        }


    }
}
