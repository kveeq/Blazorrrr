#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Blazorrrr/Blazorrrr.csproj", "Blazorrrr/"]
RUN dotnet restore "Blazorrrr/Blazorrrr.csproj"
COPY . .
WORKDIR "/src/Blazorrrr"
RUN dotnet build "Blazorrrr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blazorrrr.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blazorrrr.dll"]