using System;

namespace MetadataLibrary
{
	/// <summary>
	/// Represents the units for the X and Y densities
	/// for a JFIF file.
	/// </summary>
	public enum JFIFUnits : byte
	{
		/// <summary>
		/// No units specified, X and Y specify the pixel aspect ratio.
		/// </summary>
		None = 0,
		/// <summary>
		/// Dots per inch.
		/// </summary>
		DotsPerInch = 1,
		/// <summary>
		/// Dots per centimeter.
		/// </summary>
		DotsPerCm = 2
	}

	/// <summary>
	/// Represents the JFIF extension.
	/// </summary>
	public enum JFIFExtension : byte
	{
		/// <summary>
		/// Thumbnail coded using JPEG.
		/// </summary>
		ThumbnailJPEG = 0x10,
		/// <summary>
		/// Thumbnail stored using a 256-Color RGB palette.
		/// </summary>
		ThumbnailPaletteRGB = 0x11,
		/// <summary>
		/// Thumbnail stored using 3 bytes/pixel (24-bit) RGB values.
		/// </summary>
		Thumbnail24BitRGB = 0x13
	}
}

