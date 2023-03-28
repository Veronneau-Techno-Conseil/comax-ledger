FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ComaxProcessor/*.csproj ComaxProcessor/
RUN dotnet restore ComaxProcessor/ComaxProcessor.csproj

COPY . . 
WORKDIR /app/ComaxProcessor
RUN dotnet publish ComaxProcessor.csproj -c release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "CommunAxiom.Ledger.ComaxProcessor.dll"]

