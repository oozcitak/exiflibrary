using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the IFD section containing tags.
    /// </summary>
    public enum IFD : int
    {
        Unknown = 0,
        Zeroth = 100000,
        EXIF = 200000,
        GPS = 300000,
        Interop = 400000,
        First = 500000,
        MakerNote = 600000,
        JFIF = 700000,
        JFXX = 800000,
        PNG = 900000,
    }
}
