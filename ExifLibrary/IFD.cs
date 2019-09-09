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
        /// <summary>
        /// Unkown IFD section.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Zeroth IFD section.
        /// </summary>
        Zeroth = 100000,
        /// <summary>
        /// Exif IFD section.
        /// </summary>
        EXIF = 200000,
        /// <summary>
        /// GPS IFD section.
        /// </summary>
        GPS = 300000,
        /// <summary>
        /// Interop IFD section.
        /// </summary>
        Interop = 400000,
        /// <summary>
        /// First IFD section.
        /// </summary>
        First = 500000,
        /// <summary>
        /// A pseudo-IFD section containing makernotes.
        /// </summary>
        MakerNote = 600000,
        /// <summary>
        /// A pseudo-IFD section containing JFIF tags.
        /// </summary>
        JFIF = 700000,
        /// <summary>
        /// A pseudo-IFD section containing JFXX tags.
        /// </summary>
        JFXX = 800000,
        /// <summary>
        /// A pseudo-IFD section containing PGN tags.
        /// </summary>
        PNG = 900000,
    }
}
