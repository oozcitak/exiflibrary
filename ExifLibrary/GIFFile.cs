using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the binary view of a GIF file.
    /// </summary>
    public class GIFFile : ImageFile
    {
        #region Properties
        /// <summary>
        /// Gets the GIF version string. e.g. 89a
        /// </summary>
        public string Version { get; private set; }
        /// <summary>
        /// Gets the raster width in pixels.
        /// </summary>
        public ushort ScreenWidth { get; private set; }
        /// <summary>
        /// Gets the raster height in pixels.
        /// </summary>
        public ushort ScreenHeight { get; private set; }
        /// <summary>
        /// Gets the bumber of bits per primary color available.
        /// </summary>
        public byte ColorResolution { get; private set; }

        /// <summary>
        /// Gets the size of the global color table.
        /// </summary>
        public byte SizeOfGCT { get; private set; }
        /// <summary>
        /// Gets whether the file contains a global color table.
        /// </summary>
        public bool HasGCT { get; private set; }
        /// <summary>
        /// Gets whether the global color table is sorted.
        /// </summary>
        public bool IsGCTSorted { get; private set; }
        /// <summary>
        /// Gets the index of the backcolor in the global color table.
        /// </summary>
        public byte BackcolorIndex { get; private set; }
        /// <summary>
        /// Gets the global color table.
        /// </summary>
        public byte[,] GCT { get; private set; }

        /// <summary>
        /// Gets the pixel aspect ratio.
        /// The actual aspect ratio is calculated as: Aspect Ratio = (Pixel Aspect Ratio + 15) / 64.
        /// </summary>
        public byte PixelAspectRatio { get; private set; }

        /// <summary>
        /// Gets the blocks contained in the <see cref="GIFFile"/>.
        /// </summary>
        public List<GIFBlock> Blocks { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFFile"/> class from the
        /// specified data stream.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        protected internal GIFFile(MemoryStream stream, System.Text.Encoding encoding)
        {
            Format = ImageFileFormat.GIF;

            Blocks = new List<GIFBlock>();

            var conv = BitConverterEx.LittleEndian;
            stream.Seek(0, SeekOrigin.Begin);

            // version
            var versionBytes = Utility.GetStreamBytes(stream, 6);
            Version = Encoding.ASCII.GetString(versionBytes, 3, 3);

            // screen descriptor
            ScreenWidth = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
            ScreenHeight = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
            var sdByte = (byte)stream.ReadByte();
            // global color table flag in bit 7
            HasGCT = (sdByte & (1 << 7)) != 0;
            // color resolution in bits 6, 5, 4
            int b6 = (sdByte & (1 << 6));
            int b5 = (sdByte & (1 << 5));
            int b4 = (sdByte & (1 << 4));
            ColorResolution = (byte)(((b6 | b5 | b4) >> 4) + 1);
            // global color table sorted flag in bit 3
            IsGCTSorted = (sdByte & (1 << 3)) != 0;
            // global color table size bits 2, 1, 0
            int b2 = (sdByte & (1 << 2));
            int b1 = (sdByte & (1 << 1));
            int b0 = (sdByte & (1 << 0));
            SizeOfGCT = (byte)((b2 | b1 | b0) + 1);

            BackcolorIndex = (byte)stream.ReadByte();
            PixelAspectRatio = (byte)stream.ReadByte();

            // global color table
            GCT = ReadColorTable(stream, HasGCT ? MathEx.Power2(SizeOfGCT) : 0);

            // Search and read blocks until we reach the end of file.
            while (stream.Position != stream.Length)
            {
                int val = stream.ReadByte();
                if (val == -1) break;

                byte separator = (byte)val;
                if (separator == 0x3B)
                {
                    // end of image
                    Blocks.Add(new GIFTerminator());
                    break;
                }
                else if (separator == 0x2C)
                {
                    // image descriptor block
                    var block = new GIFImageDescriptor();
                    block.Left = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
                    block.Top = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
                    block.Width = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
                    block.Height = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);

                    var idByte = (byte)stream.ReadByte();
                    // local color table flag in bit 7
                    block.HasLCT = (idByte & (1 << 7)) != 0;
                    // interlaced flag in bit 6
                    block.IsInterlaced = (idByte & (1 << 6)) != 0;
                    // local color table sorted flag in bit 5
                    block.IsLCTSorted = (idByte & (1 << 5)) != 0;
                    // reserved value in bits 4, 3
                    int id4 = (idByte & (1 << 4));
                    int id3 = (idByte & (1 << 3));
                    block.Reserved = (byte)((id4 | id3) >> 3);
                    // local color table size bits 2, 1, 0
                    int id2 = (idByte & (1 << 2));
                    int id1 = (idByte & (1 << 1));
                    int id0 = (idByte & (1 << 0));
                    block.SizeOfLCT = (byte)((id2 | id1 | id0) + 1);

                    // local color table
                    block.LCT = ReadColorTable(stream, block.HasLCT ? MathEx.Power2(block.SizeOfLCT) : 0);

                    // raster data
                    block.LZWMinimumCodeSize = (byte)stream.ReadByte();
                    block.ImageData = ReadDataBlock(stream);

                    Blocks.Add(block);
                }
                else if (separator == 0x21)
                {
                    // extension block
                    val = stream.ReadByte();
                    if (val == -1) break;
                    var label = (byte)val;
                    if (label == 0xF9)
                    {
                        // graphic control extension
                        var size = stream.ReadByte();
                        var block = new GIFGraphicControlExtension();
                        var geByte = (byte)stream.ReadByte();
                        // reserved value in bits 7, 6, 5
                        int ge7 = (geByte & (1 << 7));
                        int ge6 = (geByte & (1 << 6));
                        int ge5 = (geByte & (1 << 5));
                        block.Reserved = (byte)((ge7 | ge6 | ge5) >> 5);
                        // disposal method in bits 4, 3, 2
                        int ge4 = (geByte & (1 << 4));
                        int ge3 = (geByte & (1 << 3));
                        int ge2 = (geByte & (1 << 2));
                        block.DisposalMethod = (byte)((ge4 | ge3 | ge2) >> 2);
                        // user input flag in bit 1
                        block.UserInputFlag = (geByte & (1 << 1)) != 0;
                        // transparent color flag in bit 0
                        block.TransparentColorFlag = (geByte & (1 << 0)) != 0;

                        block.DelayTime = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
                        block.TransparentColorIndex = (byte)stream.ReadByte();

                        var term = stream.ReadByte();

                        Blocks.Add(block);
                    }
                    else if (label == 0xFE)
                    {
                        // comment extension
                        var block = new GIFCommentExtension();

                        // comment data
                        block.Data = ReadDataBlock(stream);

                        Blocks.Add(block);
                    }
                    else if (label == 0x01)
                    {
                        // plain text extension
                        var block = new GIFPlainTextExtension();
                        var size = stream.ReadByte();
                        block.Left = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
                        block.Top = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
                        block.Width = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
                        block.Height = conv.ToUInt16(Utility.GetStreamBytes(stream, 2), 0);
                        block.CellWidth = (byte)stream.ReadByte();
                        block.CellHeight = (byte)stream.ReadByte();
                        block.ForegroundColorIndex = (byte)stream.ReadByte();
                        block.BackgroundColorIndex = (byte)stream.ReadByte();

                        // plain text data
                        block.Data = ReadDataBlock(stream);

                        Blocks.Add(block);
                    }
                    else if (label == 0xFF)
                    {
                        // application extension
                        var block = new GIFApplicationExtension();
                        var size = stream.ReadByte();
                        block.ApplicationIdentifier = Utility.GetStreamBytes(stream, 8);
                        block.AuthenticationCode = Utility.GetStreamBytes(stream, 3);

                        // application data
                        block.Data = ReadDataBlock(stream);

                        Blocks.Add(block);
                    }
                    else
                    {
                        // unkown extension block
                        var block = new GIFExtensionBlock(label);
                        block.Data = ReadDataBlock(stream);
                        Blocks.Add(block);
                    }
                }
                else
                {
                    // unknown block
                    throw new NotValidGIFFileException(string.Format("Unkown GIF block separator: 0x{0:X}", separator));
                }
            }

            // insert a terminator if it doesn't exist
            if (Blocks[Blocks.Count - 1].Separator != GIFSeparator.Terminator)
            {
                Blocks.Add(new GIFTerminator());
            }

            // process metadata
            ReadMetadata();
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Decreases file size by removing all ancillary chunks.
        /// </summary>
        public override void Crush()
        {
            Properties.Clear();

            Blocks.RemoveAll(b => b as GIFCommentExtension != null);
        }

        /// <summary>
        /// Saves the <see cref="ImageFile"/> to the given stream.
        /// </summary>
        /// <param name="stream">The data stream used to save the image.</param>
        protected override void SaveInternal(MemoryStream stream)
        {
            // process metadata
            WriteMetadata();

            var conv = BitConverterEx.LittleEndian;
            stream.Seek(0, SeekOrigin.Begin);

            // version
            stream.Write(Encoding.ASCII.GetBytes("GIF" + Version), 0, 6);

            // screen descriptor
            stream.Write(conv.GetBytes(ScreenWidth), 0, 2);
            stream.Write(conv.GetBytes(ScreenHeight), 0, 2);

            int val = 0;
            // global color table flag in bit 7
            if (HasGCT) val |= 1 << 7;
            // color resolution in bits 6, 5, 4
            val |= (ColorResolution - 1) << 4;
            // global color table sorted flag in bit 3
            if (IsGCTSorted) val |= 1 << 3;
            // global color table size bits 2, 1, 0
            val |= (SizeOfGCT - 1);
            stream.WriteByte((byte)val);

            stream.WriteByte(BackcolorIndex);
            stream.WriteByte(PixelAspectRatio);

            // global color table
            WriteColorTable(stream, GCT);

            // write blocks
            foreach (var block in Blocks)
            {
                // block separator
                stream.WriteByte((byte)block.Separator);

                if (block.Separator == GIFSeparator.ImageDescriptor)
                {
                    // image descriptor block
                    var idBlock = block as GIFImageDescriptor;
                    stream.Write(conv.GetBytes(idBlock.Left), 0, 2);
                    stream.Write(conv.GetBytes(idBlock.Top), 0, 2);
                    stream.Write(conv.GetBytes(idBlock.Width), 0, 2);
                    stream.Write(conv.GetBytes(idBlock.Height), 0, 2);

                    val = 0;
                    // local color table flag in bit 7
                    if (idBlock.HasLCT) val |= 1 << 7;
                    // interlaced flag in bit 6
                    if (idBlock.IsInterlaced) val |= 1 << 6;
                    // local color table sorted flag in bit 5
                    if (idBlock.IsLCTSorted) val |= 1 << 5;
                    // reserved value in bits 4, 3
                    val |= idBlock.Reserved << 3;
                    // local color table size bits 2, 1, 0
                    val |= (idBlock.SizeOfLCT - 1);
                    stream.WriteByte((byte)val);

                    // local color table
                    WriteColorTable(stream, idBlock.LCT);

                    // raster data
                    stream.WriteByte(idBlock.LZWMinimumCodeSize);
                    WriteDataBlock(stream, idBlock.ImageData);
                    // raster data terminator
                    stream.WriteByte(0);
                }
                else if (block.Separator == GIFSeparator.Terminator)
                {
                    // no data to write
                }
                else if (block.Separator == GIFSeparator.Extension)
                {
                    var extBlock = block as GIFExtensionBlock;

                    // extension block label
                    stream.WriteByte((byte)extBlock.Label);

                    if (extBlock.Label == GIFExtensionLabel.GraphicControlExtension)
                    {
                        // graphic control extension
                        var gceBlock = block as GIFGraphicControlExtension;

                        stream.WriteByte(4); // size

                        val = 0;
                        // reserved value in bits 7, 6, 5
                        val |= (gceBlock.Reserved) << 5;
                        // disposal method in bits 4, 3, 2
                        val |= (gceBlock.DisposalMethod) << 2;
                        // user input flag in bit 1
                        if (gceBlock.UserInputFlag) val |= 1 << 1;
                        // transparent color flag in bit 0
                        if (gceBlock.TransparentColorFlag) val |= 1 << 0;
                        stream.WriteByte((byte)val);

                        stream.Write(conv.GetBytes(gceBlock.DelayTime), 0, 2);
                        stream.WriteByte(gceBlock.TransparentColorIndex);
                    }
                    else if (extBlock.Label == GIFExtensionLabel.CommentExtension)
                    {
                        // comment extension
                        var ceBlock = block as GIFCommentExtension;
                        // no extension header to write
                        // block data is written below
                    }
                    else if (extBlock.Label == GIFExtensionLabel.PlainTextExtension)
                    {
                        // plain text extension
                        var pteBlock = block as GIFPlainTextExtension;

                        stream.WriteByte(12); // size
                        stream.Write(conv.GetBytes(pteBlock.Left), 0, 2);
                        stream.Write(conv.GetBytes(pteBlock.Top), 0, 2);
                        stream.Write(conv.GetBytes(pteBlock.Width), 0, 2);
                        stream.Write(conv.GetBytes(pteBlock.Height), 0, 2);
                        stream.WriteByte(pteBlock.CellWidth);
                        stream.WriteByte(pteBlock.CellHeight);
                        stream.WriteByte(pteBlock.ForegroundColorIndex);
                        stream.WriteByte(pteBlock.BackgroundColorIndex);
                    }
                    else if (extBlock.Label == GIFExtensionLabel.ApplicationExtension)
                    {
                        // application extension
                        var aeBlock = block as GIFApplicationExtension;
                        stream.WriteByte(11); // size
                        stream.Write(aeBlock.ApplicationIdentifier, 0, 8);
                        stream.Write(aeBlock.AuthenticationCode, 0, 3);
                    }

                    // write extension data
                    WriteDataBlock(stream, extBlock.Data);

                    // write extension block terminator
                    stream.WriteByte(0);
                }
                else
                {
                    throw new NotValidGIFFileException(string.Format("Unkown GIF block separator: 0x{0:X}", block.Separator));
                }
            }
        }
        #endregion

        #region Private Helper Methods
        /// <summary>
        /// Reads a GIF color table.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <param name="length">Length of color table.</param>
        protected byte[,] ReadColorTable(MemoryStream stream, int length)
        {
            var table = new byte[length, 3];
            for (int i = 0; i < length; i++)
            {
                table[i, 0] = (byte)stream.ReadByte();
                table[i, 1] = (byte)stream.ReadByte();
                table[i, 2] = (byte)stream.ReadByte();
            }
            return table;
        }
        /// <summary>
        /// Writes GIF color table.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <param name="table">Color table.</param>
        protected void WriteColorTable(MemoryStream stream, byte[,] table)
        {
            foreach (byte b in table)
            {
                stream.WriteByte(b);
            }
        }
        /// <summary>
        /// Reads data sub-blocks.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        protected byte[][] ReadDataBlock(MemoryStream stream)
        {
            List<byte[]> data = new List<byte[]>();
            while (true)
            {
                int val = stream.ReadByte();
                if (val == -1 || val == 0) break;
                byte count = (byte)val;
                data.Add(Utility.GetStreamBytes(stream, count));
            }
            return data.ToArray();
        }
        /// <summary>
        /// Writes data sub-blocks.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <param name="data">A data sub-block</param>
        protected void WriteDataBlock(MemoryStream stream, byte[][] data)
        {
            foreach (var subData in data)
            {
                stream.WriteByte((byte)subData.Length);
                stream.Write(subData, 0, subData.Length);
            }
        }
        /// <summary>
        /// Reads GIF metadata in extension blocks.
        /// </summary>
        protected void ReadMetadata()
        {
            for (int i = 0; i < Blocks.Count; i++)
            {
                var block = Blocks[i];
                var nextBlock = (i == Blocks.Count - 1 ? null : Blocks[i + 1]);
                var extension = block as GIFCommentExtension;
                if (extension == null) continue;
                using (var memStream = new MemoryStream())
                {
                    foreach (var subData in extension.Data)
                    {
                        memStream.Write(subData, 0, subData.Length);
                    }
                    Properties.Add(new GIFComment(ExifTag.GIFComment, Encoding.ASCII.GetString(memStream.ToArray()), nextBlock));
                }
            }
        }
        /// <summary>
        /// Writes GIF metadata into extension blocks.
        /// </summary>
        protected void WriteMetadata()
        {
            Blocks.RemoveAll(b => b as GIFCommentExtension != null);
            foreach (var prop in Properties)
            {
                if (prop.Tag == ExifTag.GIFComment)
                {
                    var gifComment = prop as GIFComment;
                    if (gifComment != null)
                    {
                        var block = new GIFCommentExtension();
                        var interop = gifComment.Interoperability;
                        if (interop.Count == 0) continue;
                        var subBlockCount = (interop.Count - 1) / 255 + 1;
                        block.Data = new byte[subBlockCount][];
                        int offset = 0;
                        for (int i = 0; i < subBlockCount; i++)
                        {
                            int count = Math.Min(255, interop.Data.Length - offset);
                            block.Data[i] = new byte[count];
                            Array.Copy(interop.Data, offset, block.Data[i], 0, count);
                            offset += count;
                        }

                        var insertBefore = gifComment.InsertBefore;
                        int index = insertBefore == null ? -1 : Blocks.IndexOf(insertBefore);
                        if (index == -1)
                        {
                            index = Blocks[Blocks.Count - 1].Separator == GIFSeparator.Terminator ? Blocks.Count - 1 : Blocks.Count;
                        }

                        Blocks.Insert(index, block);
                        index++;
                    }
                }
            }
        }
        #endregion
    }
}
