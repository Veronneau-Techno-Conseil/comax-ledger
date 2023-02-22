FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

COPY ComaxProcessor/. /ComaxProcessor
COPY ComaxLedgerApiClient/. /ComaxLedgerApiClient
COPY ComaxLedgerLib/. /ComaxLedgerLib

WORKDIR /ComaxProcessor

RUN dotnet restore

RUN dotnet publish -c release -o out

WORKDIR /app/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

COPY --from=build-env app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "CommunAxiom.Ledger.ComaxProcessor.dll"]