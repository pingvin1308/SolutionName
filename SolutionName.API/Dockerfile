FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SolutionName.API/SolutionName.API.csproj", "SolutionName.API/"]
RUN dotnet restore "SolutionName.API/SolutionName.API.csproj"
COPY . .
WORKDIR "/src/SolutionName.API"
RUN dotnet build "SolutionName.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SolutionName.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SolutionName.API.dll"]
