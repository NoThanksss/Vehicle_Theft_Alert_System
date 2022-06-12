#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Vehicle_Theft_Alert_System/Vehicle_Theft_Alert_System.csproj", "Vehicle_Theft_Alert_System/"]
RUN dotnet restore "Vehicle_Theft_Alert_System/Vehicle_Theft_Alert_System.csproj"
COPY . .
WORKDIR "/src/Vehicle_Theft_Alert_System"
RUN dotnet build "Vehicle_Theft_Alert_System.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vehicle_Theft_Alert_System.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vehicle_Theft_Alert_System.dll"]