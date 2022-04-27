#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["it-test-consumer/it-test-consumer.csproj", "it-test-consumer/"]
RUN dotnet restore "it-test-consumer/it-test-consumer.csproj"
COPY . .
WORKDIR "/src/it-test-consumer"
RUN dotnet build "it-test-consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "it-test-consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "it-test-consumer.dll"]