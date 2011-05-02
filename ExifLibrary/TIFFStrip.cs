using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a strip of compressed image data in a TIFF file.
    /// </summary>
    public class TIFFStrip
    {
        /// <summary>
        /// Compressed image data contained in this strip.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TIFFStrip"/> class.
        /// </summary>
        /// <param name="data">The byte array to copy strip from.</param>
        /// <param name="offset">The offset to the beginning of strip.</param>
        /// <param name="length">The length of strip.</param>
        public TIFFStrip(byte[] data, uint offset, uint length)
        {
            Data = new byte[length];
            Array.Copy(data, offset, Data, 0, length);
        }
    }
}
