$ReleaseVersionNumber = $env:APPVEYOR_BUILD_VERSION
$PreReleaseName = ''

If($env:APPVEYOR_PULL_REQUEST_NUMBER -ne $null) {
  $PreReleaseName = '-PR-' + $env:APPVEYOR_PULL_REQUEST_NUMBER
} ElseIf($env:APPVEYOR_REPO_BRANCH -ne 'master' -and -not $env:APPVEYOR_REPO_BRANCH.StartsWith('release')) {
  $PreReleaseName = '-' + $env:APPVEYOR_REPO_BRANCH
} Else {
  $PreReleaseName = ''
}

$PSScriptFilePath = (Get-Item $MyInvocation.MyCommand.Path).FullName
$ScriptDir = Split-Path -Path $PSScriptFilePath -Parent
$SolutionRoot = Split-Path -Path $ScriptDir -Parent

$ProjectJsonPath = Join-Path -Path $SolutionRoot -ChildPath "ExifLibrary\ExifLibrary.csproj"
#$re = [regex]"(?<=`"version`":\s`")[.\w-\*]*(?=`",)"
#$re1 = [regex]"(?<=\[assembly: AssemblyVersion\(`")1.0.0.0(?=`")"
#$re2 = [regex]"(?<=\[assembly: AssemblyFileVersion\(`")1.0.0.0(?=`")"
$re = [regex]"(?<=<Version>).*(?=<\/Version>)"

Write-Host "ProjectJson Path: $ProjectJsonPath"
Write-Host "Writing version: $ReleaseVersionNumber$PreReleaseName"
#Write-Host "Regex 1: $re1"
#Write-Host "Regex 2: $re2"
Write-Host "Regex: $re"
 
$re.Replace([string]::Join("`n", (Get-Content -Path $ProjectJsonPath)), "$ReleaseVersionNumber$PreReleaseName", 1) | Set-Content -Path $ProjectJsonPath -Encoding UTF8
#$re1.Replace([string]::Join("`n", (Get-Content -Path $ProjectJsonPath)), "$ReleaseVersionNumber$PreReleaseName", 1) | Set-Content -Path $ProjectJsonPath -Encoding UTF8
#$re2.Replace([string]::Join("`n", (Get-Content -Path $ProjectJsonPath)), "$ReleaseVersionNumber$PreReleaseName", 1) | Set-Content -Path $ProjectJsonPath -Encoding UTF8