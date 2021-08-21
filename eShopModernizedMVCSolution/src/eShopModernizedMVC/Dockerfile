FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 AS base
ARG source
WORKDIR /inetpub/wwwroot
EXPOSE 80


FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 AS build
WORKDIR /inetpub/wwwroot
COPY ["eShopModernizedMVCSolution/src/eShopModernizedMVC/eShopModernizedMVC.csproj", "eShopModernizedMVC/"]
RUN dotnet restore "eShopModernizedMVC/eShopModernizedMVC.csproj"
COPY . .
WORKDIR "eShopModernizedMVC"
RUN dotnet build "eShopModernizedMVC.csproj" -c Release -o /mvc/build

FROM build AS publish
RUN dotnet publish "eShopModernizedMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

