# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source code and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the runtime-only image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose port (match what your app uses, usually 80 or 5000)
EXPOSE 80

ENTRYPOINT ["dotnet", "ReviewAPI.dll"]
