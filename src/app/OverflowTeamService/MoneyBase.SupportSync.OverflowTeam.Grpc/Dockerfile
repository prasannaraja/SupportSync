#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OverflowTeamService/MoneyBase.SupportSync.OverflowTeam.Grpc/MoneyBase.SupportSync.OverflowTeam.Grpc.csproj", "OverflowTeamService/MoneyBase.SupportSync.OverflowTeam.Grpc/"]
RUN dotnet restore "./OverflowTeamService/MoneyBase.SupportSync.OverflowTeam.Grpc/MoneyBase.SupportSync.OverflowTeam.Grpc.csproj"
COPY . .
WORKDIR "/src/OverflowTeamService/MoneyBase.SupportSync.OverflowTeam.Grpc"
RUN dotnet build "./MoneyBase.SupportSync.OverflowTeam.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MoneyBase.SupportSync.OverflowTeam.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoneyBase.SupportSync.OverflowTeam.Grpc.dll"]