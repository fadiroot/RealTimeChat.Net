using System.Net.Http.Json;
using ChatApp.Client.Models;
using Microsoft.AspNetCore.Components;

namespace ChatApp.Client.Services
{
    public class AuthService : IAuthService 
    { 
        private readonly HttpClient _http;
        private readonly NavigationManager _navigation;

        public AuthService(HttpClient http, NavigationManager navigation)
        {
            _http = http;
            _navigation = navigation;
        }

        public async Task<bool> Login(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("/login", model);
            if (response.IsSuccessStatusCode)
            {
                _navigation.NavigateTo("/");
                return true;
            }
            return false;
        }
    }
}