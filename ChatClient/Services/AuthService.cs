using System.Net.Http.Json;
using ChatClient.Models;

namespace ChatClient.Services;

public class AuthService
{
    private readonly IHttpClientFactory _clientFactory;

    public AuthService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<(bool Success, string Message)> Register(RegisterModel model)
    {
        try
        {
            var client = _clientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("/register", model);
            
            if (response.IsSuccessStatusCode)
            {
                return (true, "Registration successful!");
            }
            else
            {
                // Handle API error responses (assuming JSON error format)
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, $"Registration failed: {response.StatusCode} - {errorContent}");
            }
        }
        catch (HttpRequestException ex)
        {
            return (false, $"Network error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return (false, $"Unexpected error: {ex.Message}");
        }
    }
}