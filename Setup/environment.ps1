If ($useralias -eq $null) {
    Write-Host "Please set useralias and start the script again"
    exit
}

If ($serveradminpassword -eq $null) {
    Write-Host "Please set serveradminpassword and start the script again"
    exit
}

If ($resourcegroupname -eq $null) {
    Write-Host "Please set resourcegroupname and start the script again"
    exit
}

$location = "eastus"
$webappplanname = (-join($useralias,"-webappplan"))
$webappname = (-join($useralias,"-webapp"))
$serveradminname = "ServerAdmin"
$servername = (-join($useralias, "-workshop-server"))
$dbname = "eShop"