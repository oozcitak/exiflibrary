using System;

namespace MetadataLibrary.JPEG
{
	/// <summary>
	/// Contains JPEG/Exif metadata.
	/// </summary>
	public static class Exif
	{
		/// <summary>
		/// A general indication of the kind of data contained in this subfile.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.NewSubfileType"/> enum.
		/// </summary>
		public static ExifTag NewSubfileType = new ExifTag (IFD.Zeroth, 254, MetadataType.Enum, ExifType.Long);

		/// <summary>
		/// A general indication of the kind of data contained in this subfile.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.SubfileType"/> enum.
		/// </summary>
		public static ExifTag SubfileType = new ExifTag (IFD.Zeroth, 255, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// The number of columns of image data, equal to the number of pixels per row.
		/// </summary>
		public static ExifTag ImageWidth = new ExifTag (IFD.Zeroth, 256, MetadataType.UInt, ExifType.Short | ExifType.Long, ExifType.Long);

		/// <summary>
		/// The number of rows of image data.
		/// </summary>
		public static ExifTag ImageLength = new ExifTag (IFD.Zeroth, 257, MetadataType.UInt, ExifType.Short | ExifType.Long, ExifType.Long);

		/// <summary>
		/// The number of bits per image component.
		/// </summary>
		public static ExifTag BitsPerSample = new ExifTag (IFD.Zeroth, 258, MetadataType.UShort, ExifType.Short, 3);

		/// <summary>
		/// The compression scheme used for the image data. 
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.Compression"/> enum.
		/// </summary>
		public static ExifTag Compression = new ExifTag (IFD.Zeroth, 259, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// The pixel composition.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.PhotometricInterpretation"/> enum.
		/// </summary>
		public static ExifTag PhotometricInterpretation = new ExifTag (IFD.Zeroth, 262, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// For black and white TIFF files that represent shades of gray, the technique 
		/// used to convert from gray to black and white pixels.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.Threshholding"/> enum.
		/// </summary>
		public static ExifTag Threshholding = new ExifTag (IFD.Zeroth, 263, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// The width of the dithering or halftoning matrix used to create a dithered or
		/// halftoned bilevel file.
		/// </summary>
		public static ExifTag CellWidth = new ExifTag (IFD.Zeroth, 264, MetadataType.UShort, ExifType.Short);

		/// <summary>
		/// The length of the dithering or halftoning matrix used to create a dithered or 
		/// halftoned bilevel file.
		/// </summary>
		public static ExifTag CellLength = new ExifTag (IFD.Zeroth, 265, MetadataType.UShort, ExifType.Short);

		/// <summary>
		/// The logical order of bits within a byte.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.FillOrder"/> enum.
		/// </summary>
		public static ExifTag FillOrder = new ExifTag (IFD.Zeroth, 266, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// The name of the document from which this image was scanned.
		/// </summary>
		public static ExifTag DocumentName = new ExifTag (IFD.Zeroth, 269, MetadataType.String, ExifType.ASCII, true);

		/// <summary>
		/// A character string giving the title of the image.
		/// </summary>
		public static ExifTag ImageDescription = new ExifTag (IFD.Zeroth, 270, MetadataType.String, ExifType.ASCII, true);

		/// <summary>
		/// The manufacturer of the recording equipment.
		/// </summary>
		public static ExifTag Make = new ExifTag (IFD.Zeroth, 271, MetadataType.String, ExifType.ASCII, true);

		/// <summary>
		/// The model name or model number of the equipment.
		/// </summary>
		public static ExifTag Model = new ExifTag (IFD.Zeroth, 272, MetadataType.String, ExifType.ASCII, true);

		/// <summary>
		/// For each strip, the byte offset of that strip.
		/// </summary>
		public static ExifTag StripOffsets = new ExifTag (IFD.Zeroth, 273, MetadataType.UInt, ExifType.Short | ExifType.Long, true);

		/// <summary>
		/// The image orientation.
		/// The value of this tag should be cast to a <see cref="MetadataLibrary.Orientation"/> enum.
		/// </summary>
		public static ExifTag Orientation = new ExifTag (IFD.Zeroth, 274, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// The number of components per pixel.
		/// </summary>
		public static ExifTag SamplesPerPixel = new ExifTag (IFD.Zeroth, 277, MetadataType.UShort, ExifType.Short);

		/// <summary>
		/// The number of rows per strip.
		/// </summary>
		public static ExifTag RowsPerStrip = new ExifTag (IFD.Zeroth, 278, MetadataType.UInt, ExifType.Short | ExifType.Long);

		/// <summary>
		/// The total number of bytes in each strip.
		/// </summary>
		public static ExifTag StripByteCounts = new ExifTag (IFD.Zeroth, 279, MetadataType.UInt, ExifType.Short | ExifType.Long, true);

		/// <summary>
		/// The minimum component value used.
		/// </summary>
		public static ExifTag MinSampleValue = new ExifTag (IFD.Zeroth, 280, MetadataType.UShort, ExifType.Short, true);

		/// <summary>
		/// The maximum component value used.
		/// </summary>
		public static ExifTag MaxSampleValue = new ExifTag (IFD.Zeroth, 281, MetadataType.UShort, ExifType.Short, true);

		/// <summary>
		/// The number of pixels per <see cref="MetadataLibrary.Metadata.Exif.ResolutionUnit"/> 
		/// in the <see cref="MetadataLibrary.Metadata.Exif.ImageWidth"/> direction.
		/// </summary>
		public static ExifTag XResolution = new ExifTag (IFD.Zeroth, 282, MetadataType.Float, ExifType.Rational);

		/// <summary>
		/// The number of pixels per <see cref="MetadataLibrary.Metadata.Exif.ResolutionUnit"/>
		/// in the <see cref="MetadataLibrary.Metadata.Exif.ImageLength"/> direction.
		/// </summary>
		public static ExifTag YResolution = new ExifTag (IFD.Zeroth, 283, MetadataType.Float, ExifType.Rational);

		/// <summary>
		/// Indicates whether pixel components are recorded in chunky or planar format.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.PlanarConfiguration"/> enum.
		/// </summary>
		public static ExifTag PlanarConfiguration = new ExifTag (IFD.Zeroth, 284, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// The name of the page from which this image was scanned.
		/// </summary>
		public static ExifTag PageName = new ExifTag (IFD.Zeroth, 285, MetadataType.String, ExifType.ASCII, true);

		/// <summary>
		/// The X offset in <see cref="MetadataLibrary.Metadata.Exif.ResolutionUnit"/>
		/// of the left side of the image, with respect to the left side of the page.
		/// </summary>
		public static ExifTag XPosition = new ExifTag (IFD.Zeroth, 286, MetadataType.Float, ExifType.Rational);

		/// <summary>
		/// The Y offset in <see cref="MetadataLibrary.Metadata.Exif.ResolutionUnit"/>
		/// of the top of the image, with respect to the top of the page.
		/// </summary>
		public static ExifTag YPosition = new ExifTag (IFD.Zeroth, 287, MetadataType.Float, ExifType.Rational);

		/// <summary>
		/// For each string of contiguous unused bytes in a TIFF file, the byte offset of 
		/// the string. This tag is mostly abandonded, it was an attempt at memory management 
		/// inside TIFF files that did not succeed.
		/// </summary>
		public static ExifTag FreeOffsets = new ExifTag (IFD.Zeroth, 288, MetadataType.UInt, ExifType.Long, true);

		/// <summary>
		/// For each string of contiguous unused bytes in a TIFF file, the number of bytes
		/// in the string. This tag is mostly abandonded, it was an attempt at memory management
		/// inside TIFF files that did not succeed.
		/// </summary>
		public static ExifTag FreeByteCounts = new ExifTag (IFD.Zeroth, 289, MetadataType.UInt, ExifType.Long, true);

		/// <summary>
		/// The precision of the information contained in the <see cref="GrayResponseCurve"/>.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.GrayResponseUnit"/> enum.
		/// </summary>
		public static ExifTag GrayResponseUnit = new ExifTag (IFD.Zeroth, 290, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// For grayscale data, the optical density of each possible pixel value.
		/// </summary>
		public static ExifTag GrayResponseCurve = new ExifTag (IFD.Zeroth, 291, MetadataType.UShort, ExifType.Short, true);

		/// <summary>
		/// Options for Group 3 Fax compression.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.T4Options"/> enum.
		/// </summary>
		public static ExifTag T4Options = new ExifTag (IFD.Zeroth, 292, MetadataType.Enum, ExifType.Long);

		/// <summary>
		/// Options for Group 4 Fax compression.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.T6Options"/> enum.
		/// </summary>
		public static ExifTag T6Options = new ExifTag (IFD.Zeroth, 293, MetadataType.Enum, ExifType.Long);

		/// <summary>
		/// The unit for measuring <see cref="XResolution"/> and 
		/// <see cref="YResolution"/>.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.ResolutionUnit"/> enum.	
		/// </summary>
		public static ExifTag ResolutionUnit = new ExifTag (IFD.Zeroth, 296, MetadataType.Enum, ExifType.Short);

		/// <summary>
		/// The page number of the page from which this image was scanned.
		/// The value of this tag should be cast to a 
		/// <see cref="MetadataLibrary.PageNumber"/> struct.	
		/// </summary>
		public static ExifTag PageNumber = new ExifTag (IFD.Zeroth, 297, MetadataType.UShort, ExifType.Short, 2);

		/// <summary>
		/// Describes a transfer function for the image in tabular style.
		/// </summary>
		public static ExifTag TransferFunction = new ExifTag (IFD.Zeroth, 301, MetadataType.UShort, ExifType.Short, true);

		/// <summary>
		/// The name and version of the software or firmware of the camera or
		/// image input device used to generate the image.
		/// </summary>
		public static ExifTag Software = new ExifTag (IFD.Zeroth, 305, MetadataType.String, ExifType.ASCII, true);

		/// <summary>
		/// The date and time of image creation.
		/// </summary>
		public static ExifTag DateTime = new ExifTag (IFD.Zeroth, 306, MetadataType.String, ExifType.ASCII, true);

		/// <summary>
		/// The name of the camera owner, photographer or image creator.
		/// </summary>
		public static ExifTag Artist = new ExifTag (IFD.Zeroth, 315, MetadataType.String, ExifType.ASCII, true);
		
	}
}
