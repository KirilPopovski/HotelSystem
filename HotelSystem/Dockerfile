#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HotelSystem/HotelSystem.csproj", "HotelSystem/"]
COPY ["HotelSystem.Common/HotelSystem.Common.csproj", "HotelSystem.Common/"]
RUN dotnet restore "HotelSystem/HotelSystem.csproj"
COPY . .
WORKDIR "/src/HotelSystem"
RUN dotnet build "HotelSystem.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "HotelSystem.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelSystem.dll"]