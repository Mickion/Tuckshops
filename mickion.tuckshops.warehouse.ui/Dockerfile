#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["mickion.tuckshops.warehouse.ui/mickion.tuckshops.warehouse.ui.csproj", "mickion.tuckshops.warehouse.ui/"]
RUN dotnet restore "mickion.tuckshops.warehouse.ui/mickion.tuckshops.warehouse.ui.csproj"
COPY . .
WORKDIR "/src/mickion.tuckshops.warehouse.ui"
RUN dotnet build "mickion.tuckshops.warehouse.ui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mickion.tuckshops.warehouse.ui.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mickion.tuckshops.warehouse.ui.dll"]