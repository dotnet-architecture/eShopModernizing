FROM mcr.microsoft.com/dotnet/framework/wcf:4.7.2
EXPOSE 80
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
