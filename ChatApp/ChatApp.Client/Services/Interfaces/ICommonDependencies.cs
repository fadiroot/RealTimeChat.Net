namespace ChatApp.Client.Services;

public static class ICommonDepenedencies 
{
    public static IServiceCollection AddDependencies(this IServiceCollection services) 
    {
        services.AddSingleton<AccountManagment>();

        return services;
    }
}