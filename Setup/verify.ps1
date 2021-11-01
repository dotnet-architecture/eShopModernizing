$ErrorActionPreference = 'SilentlyContinue'

$plan = Get-AzAppServicePlan -Name $webappplanname -ResourceGroup $resourcegroupname
if ($plan) { Write-Host("The app service plan was created") } else { Write-Host("The app service plan was not created") }

$webapp = Get-AzWebApp -Name $webappname -ResourceGroup $resourcegroupname
if ($webapp) { Write-Host("The web app was created") } else { Write-Host("The web app was not created") }

$server = Get-AzSqlServer -ServerName $servername -ResourceGroupName $resourcegroupname
if ($server) { Write-Host("The database server was created") } else { Write-Host("The database server was not created") }

$database = Get-AzSqlDatabase  -ResourceGroupName $resourcegroupname -ServerName $servername -DatabaseName $dbName
if ($database) { Write-Host("The database was created") } else { Write-Host("The database was not created") }
