FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ChatClient/ChatClient/ChatClient.csproj", "ChatClient/ChatClient/"]
COPY ["ChatClient/ChatClient.Client/ChatClient.Client.csproj", "ChatClient/ChatClient.Client/"]
RUN dotnet restore "ChatClient/ChatClient/ChatClient.csproj"
COPY . .
WORKDIR "/src/ChatClient/ChatClient"
RUN dotnet build "ChatClient.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ChatClient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatClient.dll"]
