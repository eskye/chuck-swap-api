#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV APPDATA = var

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["API/src/Sovtech.ChuckSwapi.Api/Sovtech.ChuckSwapi.Api.csproj", "src/Sovtech.ChuckSwapi.Api/"]
COPY ["API/src/Sovtech.ChuckSwapi.ApplicationCore/Sovtech.ChuckSwapi.ApplicationCore.csproj", "src/Sovtech.ChuckSwapi.ApplicationCore/"]
COPY ["API/src/Sovtech.ChuckSwapi.Contracts/Sovtech.ChuckSwapi.Contracts.csproj", "src/Sovtech.ChuckSwapi.Contracts/"]
RUN dotnet restore "API/src/Sovtech.ChuckSwapi.Api/Sovtech.ChuckSwapi.Api.csproj"
COPY . .
WORKDIR "/src/src/Sovtech.ChuckSwapi.Api"
RUN dotnet build "Sovtech.ChuckSwapi.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sovtech.ChuckSwapi.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Sovtech.ChuckSwapi.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Sovtech.ChuckSwapi.Api.dll