using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using Uno.IconFontTester;
using Uno.IconFontTester.Models;
using Windows.System;

namespace IconFontTester;

public sealed partial class MainPage : Page
{
    private string _searchTerm;

    public MainPage()
    {
        this.InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        Refresh();
    }

    public string SearchTerm
    {
        get => _searchTerm;
        set
        {
            _searchTerm = value;
            UpdateSearch();
        }
    }

    private List<IconItem> _allGlyphs = new List<IconItem>();

    public ObservableCollection<IconItem> FilteredGlyphs { get; } = new ObservableCollection<IconItem>();

    public async void OpenSelectionFolder()
    {
        var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("UnoIconTest", CreationCollisionOption.OpenIfExists);
        await Launcher.LaunchFolderAsync(folder);
    }

    public async void Refresh()
    {
        _allGlyphs.Clear();
#if NETFX_CORE
            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("UnoIconTest", CreationCollisionOption.OpenIfExists);
            var file = (await folder.TryGetItemAsync("selection.json")) as StorageFile;
#else
        StorageFile file;
        try
        {
            file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Fonts/selection.json"));
        }
        catch (Exception)
        {
            var dialog = new ContentDialog()
            {
                Title = "Error",
                Content = "The selection.json file was not found in the Assets/Fonts/ folder. Add it, and click Refresh to try again.",
                CloseButtonText = "Ok",
                XamlRoot = XamlRoot
            };
            await dialog.ShowAsync();
            return;
        }
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
                _allGlyphs.Add(new IconItem(Convert.ToString(glyph, 16), glyphText));
            }
        }

        UpdateSearch();
    }

    public void UpdateSearch()
    {
        FilteredGlyphs.Clear();
        if (string.IsNullOrWhiteSpace(SearchTerm))
        {
            foreach (var item in _allGlyphs)
            {
                FilteredGlyphs.Add(item);
            }
        }
        else
        {
            foreach (var item in _allGlyphs.Where(g => g.Id?.Contains(SearchTerm, StringComparison.InvariantCultureIgnoreCase) == true))
            {
                FilteredGlyphs.Add(item);
            }
        }
    }
}
