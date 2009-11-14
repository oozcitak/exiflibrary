using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the units for the X and Y densities
    /// for a JFIF file.
    /// </summary>
    public enum JFIFDensityUnit : byte
    {
        /// <summary>
        /// No units, XDensity and YDensity specify the pixel aspect ratio.
        /// </summary>
        None = 0,
        /// <summary>
        /// XDensity and YDensity are dots per inch.
        /// </summary>
        DotsPerInch = 1,
        /// <summary>
        /// XDensity and YDensity are dots per cm.
        /// </summary>
        DotsPerCm = 2,
    }
}
