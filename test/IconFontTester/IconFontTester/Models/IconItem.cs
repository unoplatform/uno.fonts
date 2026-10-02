using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.IconFontTester.Models;

public class IconItem
{
    public IconItem(string id, string glyph)
    {
        Id = id;
        Glyph = glyph;
    }

    public string Id { get; set; }
    
    public string Glyph { get; set; }
}
