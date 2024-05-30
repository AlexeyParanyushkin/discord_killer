FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DiscordKiller.Examples/DiscordKiller.Examples.csproj", "DiscordKiller.Examples/"]
RUN dotnet restore "DiscordKiller.Examples/DiscordKiller.Examples.csproj"
COPY . .
WORKDIR "/src/DiscordKiller.Examples"
RUN dotnet build "DiscordKiller.Examples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscordKiller.Examples.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscordKiller.Examples.dll"]
