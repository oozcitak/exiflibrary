using System;

namespace MetadataLibrary
{
	public static partial class Metadata
	{
		public static class JFXX
		{
			/// <summary>
			/// Represents the JFXX extension code.
			/// The value of this tag should be cast to a 
			/// <see cref="MetadataLibrary.JFIFExtension"/> enum.
			/// </summary>
			public static JFIFTag ExtensionCode = new JFIFTag (MetadataType.Enum, JFIFType.Byte);

			/// <summary>
			/// Thumbnail horizontal pixel count.
			/// </summary>
			public static JFIFTag XThumbnail = new JFIFTag (MetadataType.UByte, JFIFType.Byte);

			/// <summary>
			/// Thumbnail vertical pixel count.
			/// </summary>
			public static JFIFTag YThumbnail = new JFIFTag (MetadataType.UByte, JFIFType.Byte);

			/// <summary>
			/// JFXX thumbnail as an array of RGB values for the thumbnail pixels or indices
			/// into the color palette.
			/// </summary>
			public static JFIFTag Thumbnail = new JFIFTag (MetadataType.UByte, JFIFType.Byte);
			
			/// <summary>
			/// 24-bit RGB pixel values for the color palette.
			/// The RGB values define the colors represented by
			/// each value of an 8-bit binary encoding (0 - 255).
			/// </summary>
			public static JFIFTag Palette = new JFIFTag (MetadataType.UByte, JFIFType.Byte);
		}
	}
}
