using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text;
using Uno.IconFontTester;
using Uno.IconFontTester.Models;
using Windows.System;

namespace IconFontTester;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
#if !NETFX_CORE
        ConfigurationPanel.Visibility = Visibility.Collapsed;
#endif
    }

    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        Refresh();
    }

    public ObservableCollection<IconItem> Glyphs { get; } = new ObservableCollection<IconItem>();

    public async void OpenSelectionFolder()
    {
        var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("UnoIconTest", CreationCollisionOption.OpenIfExists);
        await Launcher.LaunchFolderAsync(folder);
    }

    public async void Refresh()
    {
        Glyphs.Clear();
#if NETFX_CORE
            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("UnoIconTest", CreationCollisionOption.OpenIfExists);
            var file = (await folder.TryGetItemAsync("selection.json")) as StorageFile;
#else
        var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Fonts/selection.json"));
#endif
        if (file != null)
        {
            var text = await FileIO.ReadTextAsync(file);
            var icoMoon = JsonConvert.DeserializeObject<IcoMoon>(text);
            var glyphs = icoMoon.Icons.Select(i => i.Properties.Code /*Convert.ToString(i.Properties.Code, 16)*/).OrderBy(i => i).ToList();
            foreach (var glyph in glyphs)
            {
                var bytes = BitConverter.GetBytes((ushort)glyph);
                var glyphText = Encoding.Unicode.GetString(bytes);
                Glyphs.Add(new IconItem(Convert.ToString(glyph, 16), glyphText));
            }
        }
    }
}
