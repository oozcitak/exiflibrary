using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the format of the <see cref="ImageFile"/>.
    /// </summary>
    public enum ImageFileFormat
    {
        /// <summary>
        /// The file is not recognized.
        /// </summary>
        Unknown,
        /// <summary>
        /// The file is a JPEG/Exif or JPEG/JFIF file.
        /// </summary>
        JPEG,
        /// <summary>
        /// The file is a TIFF File.
        /// </summary>
        TIFF,
        /// <summary>
        /// The file is a PNG File.
        /// </summary>
        PNG,
    }
}
