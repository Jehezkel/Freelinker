FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY ./WebApi ./
# Copy everything
# COPY . ./WebApi
# # Restore as distinct layers
RUN dotnet restore
# # Build and publish a release
RUN dotnet publish -c Release -o out

# # Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WebApi.dll"]
