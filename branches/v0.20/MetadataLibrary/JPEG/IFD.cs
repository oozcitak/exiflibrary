using System;
using System.Collections.Generic;
using System.Text;

namespace MetadataLibrary
{
    /// <summary>
    /// Represents the IFD section containing tags.
    /// </summary>
    internal enum IFD
    {
        Unknown,
        Zeroth,
        EXIF,
        GPS,
        Interop,
        First
    }
}
