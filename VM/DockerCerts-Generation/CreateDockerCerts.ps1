param(
	[Parameter(Mandatory = $True, Position = 1)]
	[string]$hostName,

	[Parameter(Mandatory = $False)]
	[string]$location = "southcentralus"
)

$ErrorActionPreference = "Stop"
if ([int](Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"  -Name Release).Release -lt 393295) {
	throw "Your version of .NET framework is not supported for this script, needs at least 4.6+"
}
function GenerateCerts {
	$splat = @{
		type              = "Custom" ;
		KeyExportPolicy   = "Exportable";
		Subject           = "CN=Docker TLS Root";
		CertStoreLocation = "Cert:\CurrentUser\My";
		HashAlgorithm     = "sha256";
		KeyLength         = 4096;
		KeyUsage          = @("CertSign", "CRLSign");
		TextExtension     = @("2.5.29.19 ={critical} {text}ca=1")
	}
	$rootCert = New-SelfSignedCertificate @splat

	$splat = @{
		Path     = "c:\DockerCerts\rootCA.cer";
		Value    = "-----BEGIN CERTIFICATE-----`n" + [System.Convert]::ToBase64String($rootCert.RawData, [System.Base64FormattingOptions]::InsertLineBreaks) + "`n-----END CERTIFICATE-----";
		Encoding = "ASCII";
	}
	Set-Content @splat

	Write-Host "CA certificate generated"

	$splat = @{
		CertStoreLocation = "Cert:\CurrentUser\My";
		DnsName           = "$hostName.$location.cloudapp.azure.com", "localhost", "$hostName";        
		Signer            = $rootCert ;
		KeyExportPolicy   = "Exportable";
		Provider          = "Microsoft Enhanced Cryptographic Provider v1.0";
		Type              = "SSLServerAuthentication";
		HashAlgorithm     = "sha256";
		TextExtension     = @("2.5.29.37= {text}1.3.6.1.5.5.7.3.1");
		KeyLength         = 4096;
	}
	$serverCert = New-SelfSignedCertificate @splat

	$splat = @{
		Path     = "c:\DockerCerts\serverCert.cer";
		Value    = "-----BEGIN CERTIFICATE-----`n" + [System.Convert]::ToBase64String($serverCert.RawData, [System.Base64FormattingOptions]::InsertLineBreaks) + "`n-----END CERTIFICATE-----";
		Encoding = "Ascii"
	}
	Set-Content @splat

	Write-Host "Server certificate generated"

	$privateKeyFromCert = [System.Security.Cryptography.X509Certificates.RSACertificateExtensions]::GetRSAPrivateKey($serverCert)
	$splat = @{
		Path     = "c:\DockerCerts\privateKey.cer";
		Value    = ("-----BEGIN RSA PRIVATE KEY-----`n" + [System.Convert]::ToBase64String($privateKeyFromCert.Key.Export([System.Security.Cryptography.CngKeyBlobFormat]::Pkcs8PrivateBlob), [System.Base64FormattingOptions]::InsertLineBreaks) + "`n-----END RSA PRIVATE KEY-----");
		Encoding = "Ascii";
	}
	Set-Content @splat

	Write-Host "Server private key generated"

	$splat = @{
		CertStoreLocation = "Cert:\CurrentUser\My";
		Subject           = "CN=clientCert";
		Signer            = $rootCert ;
		KeyExportPolicy   = "Exportable";
		Provider          = "Microsoft Enhanced Cryptographic Provider v1.0";
		TextExtension     = @("2.5.29.37= {text}1.3.6.1.5.5.7.3.2") ;
		HashAlgorithm     = "sha256";
		KeyLength         = 4096;
	}
	$clientCert = New-SelfSignedCertificate  @splat

	Write-Host "Client certificate generated"

	$splat = @{
		Path     = "c:\DockerCerts\clientPublicKey.cer" ;
		Value    = ("-----BEGIN CERTIFICATE-----`n" + [System.Convert]::ToBase64String($clientCert.RawData, [System.Base64FormattingOptions]::InsertLineBreaks) + "`n-----END CERTIFICATE-----");
		Encoding = "Ascii";
	}
	Set-Content  @splat

	$clientprivateKeyFromCert = [System.Security.Cryptography.X509Certificates.RSACertificateExtensions]::GetRSAPrivateKey($clientCert)
	$splat = @{
		Path     = "c:\DockerCerts\clientPrivateKey.cer";
		Value    = ("-----BEGIN RSA PRIVATE KEY-----`n" + [System.Convert]::ToBase64String($clientprivateKeyFromCert.Key.Export([System.Security.Cryptography.CngKeyBlobFormat]::Pkcs8PrivateBlob), [System.Base64FormattingOptions]::InsertLineBreaks) + "`n-----END RSA PRIVATE KEY-----");
		Encoding = "Ascii";
	}
	Set-Content  @splat

	Write-Host "Client private key generated"
}

GenerateCerts

Write-Host "CA, Server and Client Certificate files should be generated in this same folder"