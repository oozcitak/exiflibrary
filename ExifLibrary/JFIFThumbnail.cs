using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a JFIF thumbnail.
    /// </summary>
    public class JFIFThumbnail
    {
        protected JFIFThumbnail()
        {
            Palette = new byte[0];
            PixelData = new byte[0];
        }

        public JFIFThumbnail(ImageFormat format, byte[] data)
                    : this()
        {
            Format = format;
            PixelData = data;
        }

        public JFIFThumbnail(byte[] palette, byte[] data)
                    : this()
        {
            Format = ImageFormat.BMPPalette;
            Palette = palette;
            PixelData = data;
        }

        public enum ImageFormat
        {
            JPEG,

            BMPPalette,

            BMP24Bit,
        }

        /// <summary>
        /// Gets the image format.
        /// </summary>
        public ImageFormat Format { get; private set; }

        /// <summary>
        /// Gets the 256 color RGB palette.
        /// </summary>
        public byte[] Palette { get; private set; }

        /// <summary>
        /// Gets raw image data.
        /// </summary>
        public byte[] PixelData { get; private set; }
    }
}