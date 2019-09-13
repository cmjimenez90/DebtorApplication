FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DebtorWebApp/DebtorWebApp.csproj", "DebtorWebApp/"]
RUN dotnet restore "DebtorWebApp/DebtorWebApp.csproj"
COPY . .
WORKDIR "/src/DebtorWebApp"
RUN dotnet build "DebtorWebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DebtorWebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DebtorWebApp.dll"]