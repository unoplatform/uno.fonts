# Checks every *.ttf.manifest under nuget/: valid JSON, every family_name is an
# ms-appx:///<PackageId>/Fonts/<file> URI for the package that owns the manifest,
# and <file> exists next to the manifest.
$ErrorActionPreference = 'Stop'
$errors = 0
foreach ($manifest in Get-ChildItem (Join-Path $PSScriptRoot '..' 'nuget') -Recurse -Filter '*.ttf.manifest') {
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
if ($errors) { exit 1 }
