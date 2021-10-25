$Filter = '_*.cs'
$StartInDir = $PSScriptRoot
$TargetSubDir = "bin","obj"

$cs_FileCount = @(Get-ChildItem -LiteralPath $StartInDir -Filter $Filter -File -Recurse |
    Where-Object {
        $_.Directory.Name -NotIn $TargetSubDir
        }).Count

$cs_FileCount
pause
