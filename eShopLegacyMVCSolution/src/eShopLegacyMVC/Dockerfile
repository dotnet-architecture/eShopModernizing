FROM microsoft/aspnet:4.7
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
