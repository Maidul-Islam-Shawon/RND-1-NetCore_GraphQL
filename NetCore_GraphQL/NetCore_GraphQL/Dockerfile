#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5001
ENV ASPNETCORE_URLS=http://*:5001


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetCore_GraphQL.csproj", "./"]
RUN dotnet restore "./NetCore_GraphQL.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "NetCore_GraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCore_GraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCore_GraphQL.dll"]