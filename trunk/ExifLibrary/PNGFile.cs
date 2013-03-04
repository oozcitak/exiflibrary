using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the binary view of a PNG file.
    /// </summary>
    public class PNGFile : ImageFile
    {
        #region Properties
        /// <summary>
        /// Gets or sets the chunks contained in the <see cref="PNGFile"/>.
        /// </summary>
        public List<PNGChunk> Chunks { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="JPEGFile"/> class from the
        /// specified data stream.
        /// </summary>
        /// <param name="stream">A <see cref="Sytem.IO.Stream"/> that contains image data.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        protected internal PNGFile(Stream stream, System.Text.Encoding encoding)
        {
            Format = ImageFileFormat.PNG;
            Chunks = new List<PNGChunk>();
            Encoding = encoding;
            BitConverterEx conv = BitConverterEx.BigEndian;

            // Skip header
            stream.Seek(8, SeekOrigin.Begin);

            // Read chunks in order until we reach the end of file.
            while (stream.Position != stream.Length)
            {
                // Length of chunk data
                byte[] lengthBytes = new byte[4];
                if (stream.Read(lengthBytes, 0, 4) != 4)
                    throw new NotValidPNGFileException();
                uint length = conv.ToUInt32(lengthBytes, 0);

                // Chunk type
                byte[] typeBytes = new byte[4];
                if (stream.Read(typeBytes, 0, 4) != 4)
                    throw new NotValidPNGFileException();
                string type = Encoding.ASCII.GetString(typeBytes);

                // Chunk data
                byte[] data = Utility.GetStreamBytes(stream, length);

                // CRC of type name and data
                byte[] crcBytes = new byte[4];
                if (stream.Read(crcBytes, 0, 4) != 4)
                    throw new NotValidPNGFileException();
                uint crc = conv.ToUInt32(crcBytes, 0);

                // Add to chunks list
                PNGChunk chunk = new PNGChunk(type, data);
                if (chunk.CRC != crc)
                    throw new NotValidPNGFileException();
                Chunks.Add(chunk);
            }

            ReadPNGMetadata();
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Decreases file size by removing all ancillary chunks.
        /// </summary>
        public override void Crush()
        {
            Properties.Clear();

            Chunks.RemoveAll(c => !c.IsCritical);
        }

        /// <summary>
        /// Saves the <see cref="ImageFile"/> to the given stream.
        /// </summary>
        /// <param name="stream">The data stream used to save the image.</param>
        public override void Save(Stream stream)
        {
            // Add end chunk if it does not exist
            if (Chunks[Chunks.Count - 1].Type != "IEND")
            {
                Chunks.Add(new PNGChunk("IEND", new byte[0]));
            }

            // Save metadata
            WritePNGMetadata();

            BitConverterEx conv = BitConverterEx.BigEndian;

            // Write header
            stream.WriteByte(0x89);
            stream.WriteByte(0x50);
            stream.WriteByte(0x4E);
            stream.WriteByte(0x47);
            stream.WriteByte(0x0D);
            stream.WriteByte(0x0A);
            stream.WriteByte(0x1A);
            stream.WriteByte(0x0A);

            // Write chunks in order
            foreach (PNGChunk chunk in Chunks)
            {
                // Length of chunk data
                stream.Write(conv.GetBytes((uint)chunk.Data.LongLength), 0, 4);

                // Chunk type
                stream.Write(Encoding.ASCII.GetBytes(chunk.Type), 0, 4);

                // Chunk data
                long rem = chunk.Data.LongLength;
                long offset = 0;
                byte[] b = new byte[32768];
                while (rem > 0)
                {
                    int len = (int)Math.Min(rem, b.LongLength);
                    Array.Copy(chunk.Data, offset, b, 0, len);
                    stream.Write(b, 0, len);
                    rem -= len;
                    offset += len;
                }

                // CRC of type name and data
                stream.Write(conv.GetBytes(chunk.CRC), 0, 4);
            }
        }
        #endregion

        #region Private Helper Methods
        /// <summary>
        /// Reads the metadata from chunks.
        /// </summary>
        private void ReadPNGMetadata()
        {
            // Find the [ISO-8859-1] encoding (codepage: 28591)
            Encoding latin1 = Encoding.GetEncoding(28591);

            // tEXt and zTXt
            foreach (PNGChunk textChunk in Chunks.FindAll(c => c.Type == "tEXt" || c.Type == "zTXt"))
            {
                for (long i = 0; i < textChunk.Data.Length; i++)
                {
                    if (textChunk.Data[i] == 0)
                    {
                        long sepIndex = i;

                        byte[] keywordBytes = new byte[sepIndex];
                        Array.Copy(textChunk.Data, 0, keywordBytes, 0, keywordBytes.Length);
                        string keyword = latin1.GetString(keywordBytes);

                        if (textChunk.Type == "tEXt")
                        {
                            byte[] valueBytes = new byte[textChunk.Data.Length - (sepIndex + 1)];
                            Array.Copy(textChunk.Data, sepIndex + 1, valueBytes, 0, valueBytes.Length);
                            string value = latin1.GetString(valueBytes);
                            Properties.Add(new PNGText(TagFromKeyword(keyword), keyword, value, false));
                        }
                        else
                        {
                            byte[] valueBytes = new byte[textChunk.Data.Length - (sepIndex + 2)];
                            Array.Copy(textChunk.Data, sepIndex + 2, valueBytes, 0, valueBytes.Length);
                            string value = Utility.DecompressString(valueBytes, latin1);
                            Properties.Add(new PNGText(TagFromKeyword(keyword), keyword, value, true));
                        }

                        break;
                    }
                }
            }

            // iTXt
            foreach (PNGChunk textChunk in Chunks.FindAll(c => c.Type == "iTXt"))
            {
                for (long i = 0; i < textChunk.Data.Length; i++)
                {
                    if (textChunk.Data[i] == 0)
                    {
                        long sepIndex = i;

                        byte[] keywordBytes = new byte[sepIndex];
                        Array.Copy(textChunk.Data, 0, keywordBytes, 0, keywordBytes.Length);
                        string keyword = latin1.GetString(keywordBytes);

                        bool compressed = (textChunk.Data[sepIndex + 1] == 1);

                        for (long j = sepIndex + 3; j < textChunk.Data.Length; j++)
                        {
                            if (textChunk.Data[j] == 0)
                            {
                                long sepLangIndex = j;
                                byte[] langBytes = new byte[sepLangIndex - (sepIndex + 3)];
                                Array.Copy(textChunk.Data, sepIndex + 3, langBytes, 0, langBytes.Length);
                                string lang = latin1.GetString(langBytes);

                                for (long k = sepLangIndex + 1; k < textChunk.Data.Length; k++)
                                {
                                    if (textChunk.Data[k] == 0)
                                    {
                                        long sepTransIndex = k;
                                        byte[] transBytes = new byte[sepTransIndex - (sepLangIndex + 1)];
                                        Array.Copy(textChunk.Data, sepLangIndex + 1, transBytes, 0, transBytes.Length);
                                        string trans = Encoding.UTF8.GetString(transBytes);

                                        byte[] valueBytes = new byte[textChunk.Data.Length - (sepTransIndex + 1)];
                                        Array.Copy(textChunk.Data, sepTransIndex + 1, valueBytes, 0, valueBytes.Length);
                                        string value = string.Empty;
                                        if (compressed)
                                            value = Utility.DecompressString(valueBytes, Encoding.UTF8);
                                        else
                                            value = Encoding.UTF8.GetString(valueBytes);

                                        Properties.Add(new PNGInternationalText(TagFromKeyword(keyword), keyword, value, compressed, lang, trans));

                                        break;
                                    }
                                }

                                break;
                            }
                        }

                        break;
                    }
                }
            }

            // tIME
            foreach (PNGChunk timeChunk in Chunks.FindAll(c => c.Type == "tIME"))
            {
                ushort year = ExifBitConverter.BigEndian.ToUInt16(timeChunk.Data, 0);
                DateTime mtime = new DateTime(year, timeChunk.Data[2], timeChunk.Data[3], timeChunk.Data[4], timeChunk.Data[5], timeChunk.Data[6]);
                Properties.Add(new PNGTimeStamp(ExifTag.PNGTimeStamp, mtime));
            }
        }

        /// <summary>
        /// Returns the tag corresponding to the given keyword.
        /// </summary>
        /// <param name="keyword">The keyword to match.</param>
        private ExifTag TagFromKeyword(string keyword)
        {
            if (string.Compare(keyword, "Title", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGTitle;
            else if (string.Compare(keyword, "Author", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGAuthor;
            else if (string.Compare(keyword, "Description", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGDescription;
            else if (string.Compare(keyword, "Copyright", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGCopyright;
            else if (string.Compare(keyword, "Creation Time", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGCreationTime;
            else if (string.Compare(keyword, "Software", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGSoftware;
            else if (string.Compare(keyword, "Disclaimer", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGDisclaimer;
            else if (string.Compare(keyword, "Warning", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGWarning;
            else if (string.Compare(keyword, "Source", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGSource;
            else if (string.Compare(keyword, "Comment", StringComparison.InvariantCultureIgnoreCase) == 0)
                return ExifTag.PNGComment;
            else
                return ExifTag.PNGText;
        }
        /// <summary>
        /// Writes metadata back into PNG chunks.
        /// </summary>
        private void WritePNGMetadata()
        {
            // Remove old chunks
            Chunks.RemoveAll(c => c.Type == "tEXt" || c.Type == "zTXt" || c.Type == "iTXt" || c.Type == "tIME");

            // Add chunks
            foreach (ExifProperty prop in Properties)
            {
                if (prop is PNGText)
                {
                    PNGText exprop = prop as PNGText;
                    if (!exprop.Compressed)
                        Chunks.Insert(Chunks.Count - 1, new PNGChunk("tEXt", prop.Interoperability.Data));
                    else
                        Chunks.Insert(Chunks.Count - 1, new PNGChunk("zTXt", prop.Interoperability.Data));
                }
                else if (prop is PNGInternationalText)
                {
                    PNGInternationalText exprop = prop as PNGInternationalText;
                    Chunks.Insert(Chunks.Count - 1, new PNGChunk("iTXt", prop.Interoperability.Data));
                }
                else if (prop is PNGTimeStamp)
                {
                    PNGTimeStamp exprop = prop as PNGTimeStamp;
                    Chunks.Insert(Chunks.Count - 1, new PNGChunk("tIME", prop.Interoperability.Data));
                }
            }
        }
        #endregion
    }
}
