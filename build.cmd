@echo [93m Creating the 'deploy' folder tree[0m

@echo [93m Building MVC project...[0m
nuget restore eShopModernizedMVCSolution\eShopModernizedMVC.sln
msbuild eShopModernizedMVCSolution\src\eShopModernizedMVC\eShopModernizedMVC.csproj /nologo /p:PublishProfile=FolderProfile.pubxml /p:DeployOnBuild=true /p:docker_publish_root=..\..\..\deploy\mvc\
@echo [93m Building Webforms project...[0m
nuget restore eShopModernizedWebFormsSolution\eShopModernizedWebForms.sln
msbuild eShopModernizedWebFormsSolution\src\eShopModernizedWebForms\eShopModernizedWebForms.csproj /nologo /p:PublishProfile=FolderProfile.pubxml /p:DeployOnBuild=true /p:docker_publish_root=..\..\..\deploy\webforms\
@echo [93m Building WCF project...[0m
nuget restore eShopModernizedNTier\eShopModernizedNTier.sln
msbuild eShopModernizedNTier\src\eShopWCFService\eShopWCFService.csproj /nologo /p:PublishProfile=FolderProfile.pubxml /p:DeployOnBuild=true /p:docker_publish_root=..\..\..\deploy\wcf\
@echo [93m Copying Dockerfiles to deploy folder[0m
@copy /Y eShopModernizedNTier\src\eShopWCFService\Dockerfile deploy\wcf\ 
@copy /Y eShopModernizedMVCSolution\src\eShopModernizedMVC\Dockerfile deploy\mvc
@copy /Y eShopModernizedWebFormsSolution\src\eShopModernizedWebForms\Dockerfile deploy\webforms
@echo [93m Building docker images... [0m
docker-compose -f docker-compose.yml -f docker-compose.override.yml build