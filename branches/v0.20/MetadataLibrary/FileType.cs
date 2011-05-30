using System;
using System.Collections.Generic;
using System.Text;

namespace MetadataLibrary
{
    /// <summary>
    /// Represents the type of the <see cref="MetaFile"/>.
    /// </summary>
    public enum FileType
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
    }
}
