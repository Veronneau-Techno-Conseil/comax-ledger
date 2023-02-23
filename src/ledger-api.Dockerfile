FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ComaxLedgerApi/*.csproj ComaxLedgerApi/
RUN dotnet restore ComaxLedgerApi/ComaxLedgerApi.csproj

COPY . . 
WORKDIR /app/ComaxLedgerApi
RUN dotnet publish ComaxLedgerApi.csproj -c release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "CommunAxiom.Ledger.ComaxLedgerApi.dll"]

