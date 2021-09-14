Function Convert-ToPackageReference
{
    Param ( [Parameter( Mandatory, ValueFromPipeline )][String] $inputUri,
            [String] $stylesheetUri = "https://gist.githubusercontent.com/a4099181/074a6c3dd524ea0d343382137492399c/raw/e2cd1bc88671bb1435569ba9ab1835994aa91725/Convert-ToPackageReference.xsl",
            [String] $resultsFile   = [System.IO.Path]::GetTempFileName() )

    Process {
        $xslt = New-Object System.Xml.Xsl.XslCompiledTransform
        $xslt.Load( $stylesheetUri )
        $xslt.Transform( $inputUri, $resultsFile )
        Get-Content $resultsFile
    }
}

Function Update-ProjectFile
{
    Param ( [Parameter( Mandatory )][String] $projectFile,
            [Parameter( Mandatory, ValueFromPipeline )][String] $content )

    Begin   { $packageReference = '' }
    Process { $packageReference += $content }
    End     {
        $projXml = New-Object System.Xml.XmlDocument
        $projXml.Load( $projectFile )

        $nameSpc = New-Object System.Xml.XmlNamespaceManager $projXml.NameTable
        $nameSpc.AddNamespace("x", "http://schemas.microsoft.com/developer/msbuild/2003");

        $prefXml = New-Object System.Xml.XmlDocument
        $prefXml.LoadXml( $packageReference )

        $prefXml.SelectNodes( "/x:Project/x:ItemGroup/x:PackageReference", $nameSpc ) |
            % {
                $pkgNode = $projXml.ImportNode( $_, $true )
                $pkgName = $_.Include.Split('-')[0]
                $version = $_.Version

                $nodes   = $projXml.SelectNodes( "/x:Project/x:ItemGroup/x:Reference", $nameSpc ) |
                                ? Include -Like  "$pkgName*"

                if ( $nodes.Count -eq 0 )
                {
                    Write-Information "$projectFile $pkgName package outside the project file."
                    $itemGroup = $projXml.CreateElement( "ItemGroup", $nameSpc.LookupNamespace( "x" ) )
                    $itemGroup.AppendChild( $pkgNode )
                    $projXml.DocumentElement.AppendChild( $itemGroup )
                }
                else {
                    $nodes | % {
                        if ( $_.Include -Match "$version" )
                        {
                            Write-Information "$projectFile $pkgName valid reference."
                            $_.ParentNode.AppendChild( $pkgNode )
                            $_.ParentNode.RemoveChild( $_ )
                        }
                        else
                        {
                            Write-Warning "$projectFile $pkgName version mismatched."
                            $_.ParentNode.InsertBefore( $pkgNode, $_ )
                        }
                    }
                }
            }

        $projXml.SelectNodes( "/x:Project/x:ItemGroup/x:*[@Include='packages.config']", $nameSpc ) |
            % { $_.ParentNode.RemoveChild( $_ ) }

        $projXml.Save( $projectFile )
    }
}

Get-ChildItem . -Recurse -File -Filter packages.config |
    select @{ Name="ProjectFile";    Expression={ (Get-ChildItem -Path "$($_.Directory)\*.csproj").FullName } },
           @{ Name="PackagesConfig"; Expression={ $_.FullName } } |
    ? { $_.ProjectFile } |
    % {
        Write-Host "Found: " $_.ProjectFile
        $_.PackagesConfig | Convert-ToPackageReference | Update-ProjectFile $_.ProjectFile -InformationAction Continue
        Remove-Item $_.PackagesConfig
    }
