# Use the official ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BlazorOkta.csproj", "./"]
RUN dotnet restore "BlazorOkta.csproj"
COPY . .
RUN dotnet build "BlazorOkta.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "BlazorOkta.csproj" -c Release -o /app/publish

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorOkta.dll"]

