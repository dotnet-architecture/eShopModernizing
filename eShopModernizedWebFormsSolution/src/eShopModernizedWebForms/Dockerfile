FROM microsoft/aspnet:4.7.2
ARG source
WORKDIR /inetpub/wwwroot
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
