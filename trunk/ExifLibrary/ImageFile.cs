using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ExifLibrary
{
	/// <summary>
	/// Represents the base class for image files.
	/// </summary>
	[TypeDescriptionProvider(typeof(ExifFileTypeDescriptionProvider))]
	public abstract class ImageFile
	{
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="ImageFile"/> class.
		/// </summary>
		protected ImageFile ()
		{
			Format = ImageFileFormat.Unknown;
			Properties = new ExifPropertyCollection ();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Returns the format of the <see cref="ImageFile"/>.
		/// </summary>
		public ImageFileFormat Format { get; protected set; }
		/// <summary>
		/// Gets the collection of Exif properties contained in the <see cref="ImageFile"/>.
		/// </summary>
		public ExifPropertyCollection Properties { get; private set; }
		/// <summary>
		/// Gets or sets the embedded thumbnail image.
		/// </summary>
		public ImageFile Thumbnail { get; set; }
		/// <summary>
		/// Gets or sets the Exif property with the given key.
		/// </summary>
		/// <param name="key">The Exif tag associated with the Exif property.</param>
		public ExifProperty this[ExifTag key] {
			get { return Properties[key]; }
			set { Properties[key] = value; }
		}
		#endregion

		#region Instance Methods
		/// <summary>
		/// Converts the <see cref="ImageFile"/> to a <see cref="System.Drawing.Image"/>.
		/// </summary>
		/// <returns>Returns a <see cref="System.Drawing.Image"/> containing image data.</returns>
		public abstract Image ToImage ();

		/// <summary>
		/// Saves the <see cref="ImageFile"/> to the specified file.
		/// </summary>
		/// <param name="filename">A string that contains the name of the file.</param>
		public virtual void Save (string filename)
		{
			using (FileStream stream = new FileStream (filename, FileMode.Create, FileAccess.Write, FileShare.None)) {
				Save (stream);
			}
		}

		/// <summary>
		/// Saves the <see cref="ImageFile"/> to the specified stream.
		/// </summary>
		/// <param name="stream">A <see cref="Sytem.IO.Stream"/> to save image data to.</param>
		public abstract void Save (Stream stream);
		#endregion

		#region Static Methods
		/// <summary>
		/// Creates an <see cref="ImageFile"/> from the specified file.
		/// </summary>
		/// <param name="filename">A string that contains the name of the file.</param>
		/// <returns>The <see cref="ImageFile"/> created from the file.</returns>
		public static ImageFile FromFile (string filename)
		{
			using (FileStream stream = new FileStream (filename, FileMode.Open, FileAccess.Read, FileShare.Read)) {
				return FromStream (stream);
			}
		}

		/// <summary>
		/// Creates an <see cref="ImageFile"/> from the specified data stream.
		/// </summary>
		/// <param name="stream">A <see cref="Sytem.IO.Stream"/> that contains image data.</param>
		/// <returns>The <see cref="ImageFile"/> created from the file.</returns>
		public static ImageFile FromStream (Stream stream)
		{
			stream.Seek (0, SeekOrigin.Begin);
			byte[] header = new byte[8];
			stream.Seek (0, SeekOrigin.Begin);
			if (stream.Read (header, 0, header.Length) != header.Length)
				throw new NotValidImageFileException ();
			
			// JPEG
			if (header[0] == 0xFF && header[1] == 0xD8)
				return new JPEGFile (stream);
			
			// TIFF
			string tiffHeader = Encoding.ASCII.GetString (header, 0, 4);
			if (tiffHeader == "MM\x00\x2a" || tiffHeader == "II\x2a\x00")
				return new TIFFFile (stream);
			
			throw new NotValidImageFileException ();
		}
		#endregion
	}
}
