using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Uno.IconFontTester;

public partial class IcoMoon
{
    [JsonProperty("IcoMoonType")]
    public string IcoMoonType { get; set; }

    [JsonProperty("icons")]
    public IconElement[] Icons { get; set; }

    [JsonProperty("height")]
    public long Height { get; set; }

    [JsonProperty("metadata")]
    public IcoMoonMetadata Metadata { get; set; }

    [JsonProperty("preferences")]
    public Preferences Preferences { get; set; }
}

public partial class IconElement
{
    //[JsonProperty("icon")]
    //public IconIcon Icon { get; set; }

    //[JsonProperty("attrs")]
    //public Attr[] Attrs { get; set; }

    [JsonProperty("properties")]
    public Properties Properties { get; set; }

    //[JsonProperty("setIdx")]
    //public long SetIdx { get; set; }

    //[JsonProperty("setId")]
    //public long SetId { get; set; }

    //[JsonProperty("iconIdx")]
    //public long IconIdx { get; set; }
}

public partial class Attr
{
    [JsonProperty("fill")]
    public Fill Fill { get; set; }
}

public partial class IconIcon
{
    [JsonProperty("paths")]
    public string[] Paths { get; set; }

    [JsonProperty("attrs")]
    public Attr[] Attrs { get; set; }

    [JsonProperty("isMulticolor")]
    public bool IsMulticolor { get; set; }

    [JsonProperty("isMulticolor2")]
    public bool IsMulticolor2 { get; set; }

    [JsonProperty("grid")]
    public long Grid { get; set; }

    [JsonProperty("tags")]
    public string[] Tags { get; set; }

    [JsonProperty("colorPermutations")]
    public ColorPermutations ColorPermutations { get; set; }
}

public partial class ColorPermutations
{
    [JsonProperty("17481881")]
    public The17481881[] The17481881 { get; set; }
}

public partial class The17481881
{
    [JsonProperty("f")]
    public long F { get; set; }
}

public partial class Properties
{
    [JsonProperty("order")]
    public long Order { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("prevSize")]
    public long PrevSize { get; set; }

    [JsonProperty("code")]
    public long Code { get; set; }
}

public partial class IcoMoonMetadata
{
    [JsonProperty("name")]
    public string Name { get; set; }
}

public partial class Preferences
{
    [JsonProperty("showGlyphs")]
    public bool ShowGlyphs { get; set; }

    [JsonProperty("showQuickUse")]
    public bool ShowQuickUse { get; set; }

    [JsonProperty("showQuickUse2")]
    public bool ShowQuickUse2 { get; set; }

    [JsonProperty("showSVGs")]
    public bool ShowSvGs { get; set; }

    [JsonProperty("fontPref")]
    public FontPref FontPref { get; set; }

    [JsonProperty("imagePref")]
    public ImagePref ImagePref { get; set; }

    [JsonProperty("historySize")]
    public long HistorySize { get; set; }

    [JsonProperty("showCodes")]
    public bool ShowCodes { get; set; }

    [JsonProperty("gridSize")]
    public long GridSize { get; set; }
}

public partial class FontPref
{
    [JsonProperty("prefix")]
    public string Prefix { get; set; }

    [JsonProperty("metadata")]
    public FontPrefMetadata Metadata { get; set; }

    [JsonProperty("metrics")]
    public Metrics Metrics { get; set; }

    [JsonProperty("embed")]
    public bool Embed { get; set; }

    [JsonProperty("includeMetadata")]
    public bool IncludeMetadata { get; set; }

    [JsonProperty("showMetrics")]
    public bool ShowMetrics { get; set; }

    [JsonProperty("showSelector")]
    public bool ShowSelector { get; set; }

    [JsonProperty("showMetadata")]
    public bool ShowMetadata { get; set; }

    [JsonProperty("showVersion")]
    public bool ShowVersion { get; set; }
}

public partial class FontPrefMetadata
{
    [JsonProperty("fontFamily")]
    public string FontFamily { get; set; }

    [JsonProperty("majorVersion")]
    public long MajorVersion { get; set; }

    [JsonProperty("minorVersion")]
    public long MinorVersion { get; set; }
}

public partial class Metrics
{
    [JsonProperty("emSize")]
    public long EmSize { get; set; }

    [JsonProperty("baseline")]
    public double Baseline { get; set; }

    [JsonProperty("whitespace")]
    public long Whitespace { get; set; }
}

public partial class ImagePref
{
    [JsonProperty("prefix")]
    public string Prefix { get; set; }

    [JsonProperty("png")]
    public bool Png { get; set; }

    [JsonProperty("useClassSelector")]
    public bool UseClassSelector { get; set; }

    [JsonProperty("color")]
    public long Color { get; set; }

    [JsonProperty("bgColor")]
    public long BgColor { get; set; }

    [JsonProperty("classSelector")]
    public string ClassSelector { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}

public enum Fill { Rgb000 };

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
        {
            FillConverter.Singleton,
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
    };
}

internal class FillConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Fill) || t == typeof(Fill?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        if (value == "rgb(0, 0, 0)")
        {
            return Fill.Rgb000;
        }
        throw new Exception("Cannot unmarshal type Fill");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (Fill)untypedValue;
        if (value == Fill.Rgb000)
        {
            serializer.Serialize(writer, "rgb(0, 0, 0)");
            return;
        }
        throw new Exception("Cannot marshal type Fill");
    }

    public static readonly FillConverter Singleton = new FillConverter();
}
