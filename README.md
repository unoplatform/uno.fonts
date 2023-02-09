# Uno.Fonts

Repository for NuGet packages that can be added to install fonts for any new or existing Uno application. Uno.Fonts currently offers the following fonts as NuGet packages:

# Uno Fluent UI Assets Font

An open source icon font for the [Fluent design system](https://www.microsoft.com/design/fluent). Uno FluentUI Assets is intended to be a drop-in replacement for Microsoft's Segoe MDL2 Assets font for use with [Uno Platform](https://platform.uno), WinUI and UWP apps.

## Icon fonts

This repository includes two icon fonts:

- **Uno Fluent Icons** - matches the Windows 11 iconography style
- **Uno MDL2 Assets** - matches the Windows 10 iconography style

Both fonts use the same font family name and file names to make it possible to easily swap them in place.

## Icon sources

Some icons are unique to the font, the other ones come from multiple sources:

Fluent UI System Icons
https://github.com/microsoft/fluentui-system-icons

Icons 8 Line awesome
https://github.com/icons8/line-awesome

Winjs symbols
https://github.com/winjs/winjs/tree/master/src/fonts

## Editing the font file

Here are some steps to update the font to add missing icons:

1. Download [FontForge](https://fontforge.org/en-US/)
1. Open the existing `.ttf` font file
1. Find the character you want to change by using Goto (in the view menu or ctrl+shit+>, make sure to prefix the hex code with an `u`)
1. Open the symbol you wish to change by double clicking on it
1. Import a symbol from the newly opened window using the EPS format or other compatible format
1. Export the font in File > Generate to all the required formats (`.ttf` and `.woff2`)
  - For ttf, use TrueType not TrueType(Symbols) for more info you can go here https://fontforge.org/docs/ui/dialogs/generate.html. 
  - There is no need to save the FontForge format since you can open a font from any of the supported format (You can use this to test if the font as been correctly modified).
  - You can ignore the `.g2n` file

# Google Roboto Font

The recommended, [open source](https://github.com/googlefonts/roboto), font family for Google's visual language [Material Design](https://m3.material.io/). Uno.Fonts.Roboto comes pre-packaged within the [Uno Material](https://github.com/unoplatform/Uno.Themes) and [Uno Material Toolkit](https://github.com/unoplatform/uno.toolkit.ui) libraries.

# Usage Guidelines

## Installing fonts for new applications

Simply install the desired Uno.Fonts NuGet package into your Uno project's shared class library. You will then be able to reference the font files from your XAML, like so:

```xml

<FontFamily x:Key="MyRobotoLightFontFamily">ms-appx:///Uno.Fonts.Roboto/Fonts/Roboto-Light.ttf</FontFamily>

```

> **NOTE**: If you are using the older versions of the Uno solution templates (with the `.shproj` file) then you will need to install the font NuGet package into each platform's `.csproj`

## Updating existing applications

If you have an existing Uno Platform application using an older version of the font and want to update to the latest, the following steps are needed:

### For Uno.Fonts.Fluent

1. Find all files with the name `uno-fluentui-assets.ttf` and replace them with the same file from the updated icon font.
2. Inside of the WebAssembly project find the `Fonts.css` file and replace it with the one provided by updated icon font.

### For Uno.Fonts.Roboto

1. Remove all existing Roboto font files from the application (including those under the Assets/ folder for either your shared project or for each specific platform head)
2. Remove references to the font file from `info.plist` if you are targetting iOS/macOS/Catalyst
3. Inside of the WebAssembly project find the `Fonts.css` file and remove any references to the Roboto font, such as `@font-face { font-family: 'Roboto'; ... }`.
