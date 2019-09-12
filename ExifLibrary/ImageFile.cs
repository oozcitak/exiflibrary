using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the base class for image files.
    /// </summary>
    public abstract class ImageFile
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFile"/> class.
        /// </summary>
        protected ImageFile()
        {
            Format = ImageFileFormat.Unknown;
            Properties = new ExifPropertyCollection<ExifProperty>();
            Encoding = Encoding.UTF8;
            Errors = new List<ImageError>();
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
        public ExifPropertyCollection<ExifProperty> Properties { get; private set; }
        /// <summary>
        /// Gets or sets the embedded thumbnail image.
        /// </summary>
        public byte[] Thumbnail { get; set; }
        /// <summary>
        /// Gets or sets the Exif property with the given key.
        /// </summary>
        /// <param name="key">The Exif tag associated with the Exif property.</param>
        public ExifProperty this[int index]
        {
            get { return Properties[index]; }
            set { Properties[index] = value; }
        }
        /// <summary>
        /// Gets the encoding used for text metadata when the source encoding is unknown.
        /// </summary>
        public Encoding Encoding { get; protected set; }
        /// <summary>
        /// Gets the errors encountered while reading/writing the image file.
        /// </summary>
        public List<ImageError> Errors { get; protected set; }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Saves the <see cref="ImageFile"/> to the specified file.
        /// </summary>
        /// <param name="filename">A string that contains the name of the file.</param>
        public virtual void Save(string filename)
        {
            using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Save(stream);
            }
        }

        /// <summary>
        /// Asynchronously saves the <see cref="ImageFile"/> to the specified stream.
        /// </summary>
        /// <param name="stream">A stream to save image data to.</param>
        public void Save(Stream stream)
        {
            var memStream = stream as MemoryStream;
            if (memStream != null)
            {
                SaveInternal(memStream);
            }
            else
            {
                using (memStream = new MemoryStream())
                {
                    SaveInternal(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);
                    memStream.CopyTo(stream);
                }
            }
        }

        /// <summary>
        /// Asynchronously saves the <see cref="ImageFile"/> to the specified file.
        /// </summary>
        /// <param name="filename">A string that contains the name of the file.</param>
        public virtual async Task SaveAsync(string filename)
        {
            using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                await SaveAsync(stream);
            }
        }

        /// <summary>
        /// Asynchronously saves the <see cref="ImageFile"/> to the specified stream.
        /// </summary>
        /// <param name="stream">A stream to save image data to.</param>
        public virtual async Task SaveAsync(Stream stream)
        {
            Save(stream);
        }

        /// <summary>
        /// Decreases file size by removing all metadata.
        /// </summary>
        public abstract void Crush();
        #endregion

        #region Static Methods
        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified file.
        /// </summary>
        /// <param name="filename">A string that contains the name of the file.</param>
        /// <returns>The <see cref="ImageFile"/> created from the file.</returns>
        public static ImageFile FromFile(string filename)
        {
            return FromFile(filename, Encoding.UTF8);
        }

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified file.
        /// </summary>
        /// <param name="filename">A string that contains the name of the file.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        /// <returns>The <see cref="ImageFile"/> created from the file.</returns>
        public static ImageFile FromFile(string filename, Encoding encoding)
        {
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return FromStream(stream, encoding);
            }
        }

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified data stream.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <returns>The <see cref="ImageFile"/> created from the stream.</returns>
        public static ImageFile FromStream(Stream stream)
        {
            return FromStream(stream, Encoding.UTF8);
        }

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified data stream.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        /// <returns>The <see cref="ImageFile"/> created from the stream.</returns>
        protected static ImageFile FromStream(Stream stream, Encoding encoding)
        {
            var memStream = stream as MemoryStream;
            if (memStream != null)
            {
                return FromStreamInternal(memStream, encoding);
            }
            else
            {
                using (memStream = new MemoryStream())
                {
                    stream.CopyTo(memStream);
                    memStream.Seek(0, SeekOrigin.Begin);
                    return FromStreamInternal(memStream, encoding);
                }
            }
        }

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified data.
        /// </summary>
        /// <param name="imageData">A buffer containing image data.</param>
        /// <returns>The <see cref="ImageFile"/> created from the buffer.</returns>
        public static ImageFile FromBuffer(byte[] imageData)
        {
            return FromBuffer(imageData, Encoding.UTF8);
        }

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified data.
        /// </summary>
        /// <param name="imageData">A buffer containing image data.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        /// <returns>The <see cref="ImageFile"/> created from the buffer.</returns>
        protected static ImageFile FromBuffer(byte[] imageData, Encoding encoding)
        {
            using (var memStream = new MemoryStream(imageData))
            {
                memStream.Seek(0, SeekOrigin.Begin);
                return FromStreamInternal(memStream, encoding);
            }
        }
        #endregion

        #region Static Async Methods
        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified file by asynchronously reading image data.
        /// </summary>
        /// <param name="filename">A string that contains the name of the file.</param>
        /// <returns>The <see cref="ImageFile"/> created from the file.</returns>
        public static async Task<ImageFile> FromFileAsync(string filename)
        {
            return await FromFileAsync(filename, Encoding.UTF8);
        }

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified file while while asynchronously reading image data.
        /// </summary>
        /// <param name="filename">A string that contains the name of the file.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        /// <returns>The <see cref="ImageFile"/> created from the file.</returns>
        public static async Task<ImageFile> FromFileAsync(string filename, Encoding encoding)
        {
            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            using (var memStream = new MemoryStream())
            {
                await stream.CopyToAsync(memStream);
                memStream.Seek(0, SeekOrigin.Begin);
                return await FromStreamAsync(memStream, encoding);
            }
        }

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified data stream by asynchronously reading image data.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <returns>The <see cref="ImageFile"/> created from the stream.</returns>
        public static async Task<ImageFile> FromStreamAsync(Stream stream)
        {
            return await FromStreamAsync(stream, Encoding.UTF8);
        }

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified data stream by asynchronously reading image data.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        /// <returns>The <see cref="ImageFile"/> created from the stream.</returns>
        public static async Task<ImageFile> FromStreamAsync(Stream stream, Encoding encoding)
        {
            return FromStream(stream, encoding);
        }
        #endregion

        #region Internal Methods
        /// <summary>
        /// Saves the <see cref="ImageFile"/> to the specified stream.
        /// </summary>
        /// <param name="stream">A stream to save image data to.</param>
        protected abstract void SaveInternal(MemoryStream stream);

        /// <summary>
        /// Creates an <see cref="ImageFile"/> from the specified data stream.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        /// <returns>The <see cref="ImageFile"/> created from the file.</returns>
        protected static ImageFile FromStreamInternal(MemoryStream stream, Encoding encoding)
        {
            byte[] header = new byte[8];
            stream.Seek(0, SeekOrigin.Begin);
            if (stream.Read(header, 0, header.Length) != header.Length)
                throw new NotValidImageFileException();

            // JPEG
            if (header[0] == 0xFF && header[1] == 0xD8)
                return new JPEGFile(stream, encoding);

            // TIFF
            string tiffHeader = Encoding.ASCII.GetString(header, 0, 4);
            if (tiffHeader == "MM\x00\x2a" || tiffHeader == "II\x2a\x00")
                return new TIFFFile(stream, encoding);

            // PNG
            if (header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47 &&
                header[4] == 0x0D && header[5] == 0x0A && header[6] == 0x1A && header[7] == 0x0A)
                return new PNGFile(stream, encoding);

            // GIF
            string gifHeader = Encoding.ASCII.GetString(header, 0, 3);
            if (gifHeader == "GIF")
                return new GIFFile(stream, encoding);

            throw new NotValidImageFileException();
        }
        #endregion
    }
}
