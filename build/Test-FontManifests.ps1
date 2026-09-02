# Checks every *.ttf.manifest under nuget/: valid JSON, every family_name is an
# ms-appx:///<PackageId>/Fonts/<file> URI for the package that owns the manifest,
# and <file> exists next to the manifest. Also checks every Fonts/SHA256SUMS
# (sha256sum format) against the files next to it.
$ErrorActionPreference = 'Stop'
$errors = 0
$nuget = Join-Path $PSScriptRoot '..' 'nuget'
$notBuildOutput = { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' }
foreach ($manifest in Get-ChildItem $nuget -Recurse -Filter '*.ttf.manifest' | Where-Object $notBuildOutput) {
    $prefix = "ms-appx:///$($manifest.Directory.Parent.Name)/Fonts/"
    $fonts = @((Get-Content $manifest.FullName -Raw | ConvertFrom-Json).fonts)
    foreach ($font in $fonts) {
        $ok = $font.family_name.StartsWith($prefix) -and
              (Test-Path (Join-Path $manifest.DirectoryName $font.family_name.Substring($prefix.Length)) -PathType Leaf)
        if (-not $ok) {
            Write-Host "::error file=$($manifest.FullName)::weight $($font.font_weight) -> $($font.family_name) does not resolve to a file in $($manifest.DirectoryName)"
            $errors++
        }
    }
    Write-Host "$($manifest.FullName): $($fonts.Count) entries"
}
foreach ($sums in Get-ChildItem $nuget -Recurse -Filter 'SHA256SUMS' | Where-Object $notBuildOutput) {
    foreach ($line in Get-Content $sums.FullName) {
        if ($line -notmatch '^([0-9a-f]{64}) [ *](.+)$') { continue }
        $file = Join-Path $sums.DirectoryName $Matches[2]
        if (-not (Test-Path $file -PathType Leaf) -or (Get-FileHash $file -Algorithm SHA256).Hash -ne $Matches[1].ToUpperInvariant()) {
            Write-Host "::error file=$($sums.FullName)::$($Matches[2]) is missing or does not match its recorded SHA-256"
            $errors++
        }
    }
    Write-Host "$($sums.FullName): verified"
}
if ($errors) { exit 1 }
