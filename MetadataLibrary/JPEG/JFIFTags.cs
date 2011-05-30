using System;

namespace MetadataLibrary
{
	public static partial class Metadata
	{
		public static class JFIF
		{
			/// <summary>
			/// Represents the JFIF version.
			/// </summary>
			public static JFIFTag JFIFVersion = new JFIFTag (MetadataType.String, JFIFType.ASCII);

			/// <summary>
			/// Represents units for X and Y densities.
			/// </summary>
			public static JFIFTag JFIFUnits = new JFIFTag (MetadataType.Enum, JFIFType.Byte);

			/// <summary>
			/// Horizontal pixel density.
			/// </summary>
			public static JFIFTag XDensity = new JFIFTag (MetadataType.UShort, JFIFType.Short);

			/// <summary>
			/// Vertical pixel density.
			/// </summary>
			public static JFIFTag YDensity = new JFIFTag (MetadataType.UShort, JFIFType.Short);

			/// <summary>
			/// Thumbnail horizontal pixel count.
			/// </summary>
			public static JFIFTag XThumbnail = new JFIFTag (MetadataType.UByte, JFIFType.Byte);

			/// <summary>
			/// Thumbnail vertical pixel count.
			/// </summary>
			public static JFIFTag YThumbnail = new JFIFTag (MetadataType.UByte, JFIFType.Byte);

			/// <summary>
			/// JFIF thumbnail as an array of RGB values for the thumbnail pixels.
			/// </summary>
			public static JFIFTag Thumbnail = new JFIFTag (MetadataType.UByte, JFIFType.Byte);
		}
	}
}
