FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5011
ENV ASPNETCORE_URLS=http://+:5011

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .


FROM build AS publish
RUN dotnet publish "eTuristickaAgencija.API" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD ./eTuristickaAgencija.API/img ./img

ENTRYPOINT ["dotnet", "eTuristickaAgencija.API.dll"]