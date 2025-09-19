using Millenium.View.Interface;
using Millenium.View.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Millenium.View.Services
{
    public class ActionService : IActionService
    {
        private readonly HttpClient _httpClient;

        public ActionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetCardActionsAsync(string userId, string cardNumber)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<string>>(
                    $"api/cards/{userId}/{cardNumber}/actions") ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd pobierania akcji: {ex.Message}");
                return new List<string>();
            }
        }

        public async Task<List<CardInfo>> GetUserCardsAsync(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/cards/{userId}");

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Błąd HTTP: {response.StatusCode}");
                    return new List<CardInfo>();
                }

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Odpowiedź API: {content}");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return await _httpClient.GetFromJsonAsync<List<CardInfo>>($"api/cards/{userId}", options)
                    ?? new List<CardInfo>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Błąd sieci: {ex.Message}");
                return new List<CardInfo>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Błąd JSON: {ex.Message}");
                return new List<CardInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Inny błąd: {ex.Message}");
                return new List<CardInfo>();
            }
        }
    }
}