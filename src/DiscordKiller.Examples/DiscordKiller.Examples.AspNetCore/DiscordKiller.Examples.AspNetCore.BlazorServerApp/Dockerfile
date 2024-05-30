FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DiscordKiller.Examples.AspNetCore/DiscordKiller.Examples.AspNetCore.BlazorServerApp/DiscordKiller.Examples.AspNetCore.BlazorServerApp.csproj", "DiscordKiller.Examples.AspNetCore/DiscordKiller.Examples.AspNetCore.BlazorServerApp/"]
RUN dotnet restore "DiscordKiller.Examples.AspNetCore/DiscordKiller.Examples.AspNetCore.BlazorServerApp/DiscordKiller.Examples.AspNetCore.BlazorServerApp.csproj"
COPY . .
WORKDIR "/src/DiscordKiller.Examples.AspNetCore/DiscordKiller.Examples.AspNetCore.BlazorServerApp"
RUN dotnet build "DiscordKiller.Examples.AspNetCore.BlazorServerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscordKiller.Examples.AspNetCore.BlazorServerApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscordKiller.Examples.AspNetCore.BlazorServerApp.dll"]
