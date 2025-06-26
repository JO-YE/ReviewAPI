# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj and restore
COPY ReviewAPI/*.csproj ./ReviewAPI/
WORKDIR /src/ReviewAPI
RUN dotnet restore

# Copy the rest of the app
COPY . .
WORKDIR /src/ReviewAPI
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ReviewAPI.dll"]
