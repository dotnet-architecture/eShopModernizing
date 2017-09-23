# eShopModernizing web applications
This repo provides two sample hypothetical legacy eShop web apps (traditional ASP.NET WebForms and MVC  in .NET Framework) and how you can modernize them (Lift and Shift scenario) with Windows Containers and Azure Cloud into the following deployment options:
- Regular Windows Server 2016 VM (Virtual MAchine)
- ACS-Kubernetes orchestrator cluster
- Service Fabric orchestrators cluster 

All that modernization significantly improving the deployments for DevOps, without having to change the app's architecture or C# code.

## Review the Wiki for detailed instructions on how to set it up and deploy to multiple environments

Wiki: https://github.com/dotnet-architecture/eShopModernizing/wiki

01. Tour on eShopModernizing apps implementation code
02. How to containerized the .NET Framework web apps with Windows Containers and Docker
03. How to deploy your Windows Containers based app into Azure VMs (Including CI CD)
04. How to deploy your Windows Containers based apps into Kubernetes in Azure Container Service (Including C CD)
05. How to deploy your Windows Containers based apps into Azure Service Fabric (Including CI CD)
05.1 Quick procedure to create a Secure Service Fabric cluster in Azure using PowerShell
10. How to migrate the SQL database to Azure with the Azure Database Migration Service
11. Deploying to Azure App Service, with NO Windows Containers (Including CI CD)

### Choose in memory mock-data or real database connection to a SQL Server container
The program allows either to connect to the database to get the catalog or to use mock data if one database is not available. The option to select one or the another is in the `Web.config` file:
>```
><add key="UseMockData" value="true" />
>``` 

In case the database is selected ( UseMockData equals to false) then the connection string can be set in the section:
>```
><add name="CatalogDBContext" connectionString="Your connection string here" providerName="System.Data.SqlClient" />
>``` 
