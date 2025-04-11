FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChatClient/ChatClient.Client/ChatClient.Client.csproj", "ChatClient/ChatClient.Client/"]
RUN dotnet restore "ChatClient/ChatClient.Client/ChatClient.Client.csproj"
COPY . .
WORKDIR "/src/ChatClient/ChatClient.Client"
RUN dotnet build "ChatClient.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ChatClient.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatClient.Client.dll"]
