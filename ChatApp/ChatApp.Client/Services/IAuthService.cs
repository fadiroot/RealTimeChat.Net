using ChatApp.Client.Models;

namespace ChatApp.Client.Services;

public interface IAuthService
{
    public Task<bool> Login(LoginModel loginModel);
}