#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WorkerServiceExample/WorkerServiceExample.csproj", "WorkerServiceExample/"]
RUN dotnet restore "WorkerServiceExample/WorkerServiceExample.csproj"
COPY . .
WORKDIR "/src/WorkerServiceExample"
RUN dotnet build "WorkerServiceExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkerServiceExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerServiceExample.dll"]