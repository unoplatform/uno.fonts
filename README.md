# Uno Fluent UI Assets Open Source Font

An icon font for the [Fluent design system](https://www.microsoft.com/design/fluent). Uno FluentUI Assets is intended to be a drop-in replacement for Microsoft's Segoe MDL2 Assets font for use with [Uno Platform](https://platform.uno), WinUI and UWP apps.

# Icon fonts

This repository includes two icon fonts:

- **Uno Fluent Icons** - matches the Windows 11 iconography style
- **Uno MDL2 Assets** - matches the Windows 10 iconography style

Both fonts use the same font family name and file names to make it possible to easily swap them in place.

# Updating existing application

If you have an existing Uno Platform application using older version of the font and want to update to the latest, two steps are needed:

1. Find all files with the name `uno-fluentui-assets.ttf` and replace them with the same file from the updated icon font.
2. Inside of the WebAssembly project find `Fonts.css` file and replace it with the one provided by updated icon font.

# Icon sources
Some icons are unique to the font, the other ones come from multiple sources:

Fluent UI System Icons
https://github.com/microsoft/fluentui-system-icons

Icons 8 Line awesome
https://github.com/icons8/line-awesome

Winjs symbols
https://github.com/winjs/winjs/tree/master/src/fonts

# Editing the font file

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
