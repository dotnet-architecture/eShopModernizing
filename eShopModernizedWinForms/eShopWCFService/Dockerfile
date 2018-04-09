FROM microsoft/wcf

WORKDIR WcfService

RUN powershell -NoProfile -Command \
    Import-module IISAdministration; \
    New-IISSite -Name "WcfService" -PhysicalPath C:\WcfService -BindingInformation "*:83:"

EXPOSE 83

ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .