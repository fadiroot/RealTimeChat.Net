using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ChatClient;
using ChatClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient();
// 👇 Register AuthService with a pre-configured HttpClient
builder.Services.AddHttpClient("ApiClient" ,client =>
{
    client.BaseAddress = new Uri("http://localhost:5264/");
});

builder.Services.AddScoped<AuthService>(); 


await builder.Build().RunAsync();