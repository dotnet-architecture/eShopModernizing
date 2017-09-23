# eShopModernizing web applications
This repo provides two sample hypothetical legacy eShop web apps (traditional ASP.NET WebForms and MVC  in .NET Framework) and how you can modernize them (Lift and Shift scenario) with Windows Containers and Azure Cloud into the following deployment options:
- Regular Windows Server 2016 VM (Virtual Machine)
- ACS-Kubernetes orchestrator cluster
- Service Fabric orchestrators cluster   

All those mentioned environments can be deployed into Azure cloud (as explained in the Wiki) but you can also deploy all those environments into on-premises servers or even in other public clouds.

## Related Guide/eBook
You can download its related guidance with this free guide/eBook:

Download (Draft state): https://aka.ms/liftandshiftwithcontainersebook

![image](https://user-images.githubusercontent.com/1712635/30777199-499fbacc-a06a-11e7-88ac-8928a6f269ec.png)

The modernization with Windows Containers significantly improves the deployments for DevOps, without having to change the app's architecture or C# code.

The sample apps are simple web apps for the internal backoffice of an eShop so employees can update the Product Catalog. 
Both apps are therefore simple CRUD web application to update data into a SQL Server database. 

See a screenshots of both apps below.

### INITIAL VERSIONS

r![image](https://user-images.githubusercontent.com/1712635/30354184-db7f1098-97df-11e7-8e7b-c18c67b8ba2a.png)

### CONTAINERIZED VERSION IN DEVELOPMENT ENVIRONMENT

![image](https://user-images.githubusercontent.com/1712635/30395628-9c4bff98-987b-11e7-82ca-89a1648f3bdc.png)

### UI and business features

The WebFoms and MVC apps are pretty similiar in regards UI and business features. We just created both versions so you can compare, depending on what technology you are using for your existing apps (ASP.NET MVC or Web Forms).

![image](https://user-images.githubusercontent.com/1712635/30354210-0638f3b2-97e0-11e7-82c5-df18197ccdbd.png)

### DEPLOYMENT TO AZURE WINDOWS SERVER 2016 VM
![image](https://user-images.githubusercontent.com/1712635/30402804-d62632a2-9893-11e7-817a-f9f616cdf380.png)

### DEPLOYMENT TO KUBERNETES CLUSTER IN AZURE CONTAINER SERVICE
![image](https://user-images.githubusercontent.com/1712635/30443383-264dd546-9934-11e7-8c86-6d0c892927bb.png)

### DEPLOYMENT TO SERVICE FABRIC CLUSTER
![image](https://user-images.githubusercontent.com/1712635/30446445-094e998a-993e-11e7-96d8-ed1dd9fef142.png)


## Review the Wiki for detailed instructions on how to set it up and deploy to multiple environments

Wiki: https://github.com/dotnet-architecture/eShopModernizing/wiki

01. Tour on eShopModernizing apps implementation code
02. How to containerize the .NET Framework web apps with Windows Containers and Docker
03. How to deploy your Windows Containers based app into Azure VMs (Including CI CD)
04. How to deploy your Windows Containers based apps into Kubernetes in Azure Container Service (Including C CD)
05. How to deploy your Windows Containers based apps into Azure Service Fabric (Including CI CD)
05.1 Quick procedure to create a Secure Service Fabric cluster in Azure using PowerShell
10. How to migrate the SQL database to Azure with the Azure Database Migration Service
11. Deploying to Azure App Service, with NO Windows Containers (Including CI CD)

### Choose in-memory mock-data or real database connection to a SQL Server database
The apps allow either to connect to the real database to get/update the product catalog or to use mock-data if, due to any reason, the database is still not available and you need to test/demo the app. 

For each application, the option to select one or the other mode can be configured in the docker-compose.override.yml file when using Windows Containers or at the `Web.config` file when you still are NOT using Containers (original versions).


## Additional apps to modernize: WCF services and WinForms desktop apps 
16
We're also creating an additonal modernization example based on a "legacy apps" which has a client WinForms desktop application and a SOAP service built with WCF (Windows Communication Foundation). You can explore it at the following GitHub repo:

https://github.com/dotnet-architecture/eShopModernizingWCFWinForms 
