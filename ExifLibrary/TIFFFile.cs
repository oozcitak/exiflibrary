﻿using System;
using System.Collections.Generic;
using System.IO;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the binary view of a TIFF file.
    /// </summary>
    public class TIFFFile : ImageFile
    {
        /// <summary>
        /// The whitelist of tags to keep.
        /// </summary>
        private static Dictionary<ExifTag, bool> WhiteList = new Dictionary<ExifTag, bool>()
        {
            { ExifTag.BitsPerSample, false },
            { ExifTag.CellLength, false },
            { ExifTag.CellWidth, false },
            { ExifTag.ColorMap, false },
            { ExifTag.Compression, false },
            { ExifTag.DotRange, false },
            { ExifTag.ExtraSamples, false },
            { ExifTag.FillOrder, false },
            { ExifTag.FreeByteCounts, false },
            { ExifTag.FreeOffsets, false },
            { ExifTag.GrayResponseCurve, false },
            { ExifTag.GrayResponseUnit, false },
            { ExifTag.HalftoneHints, false },
            { ExifTag.ImageLength, false },
            { ExifTag.ImageWidth, false },
            { ExifTag.InkNames, false },
            { ExifTag.InkSet, false },
            { ExifTag.JPEGACTables, false },
            { ExifTag.JPEGDCTables, false },
            { ExifTag.JPEGInterchangeFormat, false },
            { ExifTag.JPEGInterchangeFormatLength, false },
            { ExifTag.JPEGLosslessPredictors, false },
            { ExifTag.JPEGPointTransforms, false },
            { ExifTag.JPEGProc, false },
            { ExifTag.JPEGQTables, false },
            { ExifTag.JPEGRestartInterval, false },
            { ExifTag.MaxSampleValue, false },
            { ExifTag.MinSampleValue, false },
            { ExifTag.NewSubfileType, false },
            { ExifTag.NumberOfInks, false },
            { ExifTag.Orientation, false },
            { ExifTag.PhotometricInterpretation, false },
            { ExifTag.PlanarConfiguration, false },
            { ExifTag.Predictor, false },
            { ExifTag.PrimaryChromaticities, false },
            { ExifTag.ReferenceBlackWhite, false },
            { ExifTag.ResolutionUnit, false },
            { ExifTag.RowsPerStrip, false },
            { ExifTag.SampleFormat, false },
            { ExifTag.SamplesPerPixel, false },
            { ExifTag.SMaxSampleValue, false },
            { ExifTag.SMinSampleValue, false },
            { ExifTag.StripByteCounts, false },
            { ExifTag.StripOffsets, false },
            { ExifTag.SubfileType, false },
            { ExifTag.T4Options, false },
            { ExifTag.T6Options, false },
            { ExifTag.Threshholding, false },
            { ExifTag.TileByteCounts, false },
            { ExifTag.TileLength, false },
            { ExifTag.TileOffsets, false },
            { ExifTag.TileWidth, false },
            { ExifTag.TransferFunction, false },
            { ExifTag.TransferRange, false },
            { ExifTag.WhitePoint, false },
            { ExifTag.XPosition, false },
            { ExifTag.XResolution, false },
            { ExifTag.YCbCrCoefficients, false },
            { ExifTag.YCbCrPositioning, false },
            { ExifTag.YCbCrSubSampling, false },
            { ExifTag.YPosition, false },
            { ExifTag.YResolution, false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TIFFFile"/> class from the
        /// specified data stream.
        /// </summary>
        /// <param name="stream">A stream that contains image data.</param>
        /// <param name="encoding">The encoding to be used for text metadata when the source encoding is unknown.</param>
        protected internal TIFFFile(MemoryStream stream, System.Text.Encoding encoding)
        {
            Format = ImageFileFormat.TIFF;
            IFDs = new List<ImageFileDirectory>();
            Encoding = encoding;

            // Read the entire stream
            byte[] data = Utility.GetStreamBytes(stream);

            // Read the TIFF header
            TIFFHeader = TIFFHeader.FromBytes(data, 0);
            uint nextIFDOffset = TIFFHeader.IFDOffset;
            if (nextIFDOffset == 0)
                throw new NotValidTIFFileException("The first IFD offset is zero.");

            // Read IFDs in order
            while (nextIFDOffset != 0)
            {
                ImageFileDirectory ifd = ImageFileDirectory.FromBytes(data, nextIFDOffset, TIFFHeader.ByteOrder);
                nextIFDOffset = ifd.NextIFDOffset;
                IFDs.Add(ifd);
            }

            // Process IFDs
            // TODO: Add support for multiple frames
            foreach (ImageFileDirectoryEntry field in IFDs[0].Fields)
            {
                Properties.Add(ExifPropertyFactory.Get(field.Tag, field.Type, field.Count, field.Data, BitConverterEx.SystemByteOrder, IFD.Zeroth, Encoding));
            }
        }

        /// <summary>
        /// Gets the image file directories.
        /// </summary>
        public List<ImageFileDirectory> IFDs { get; private set; }

        /// <summary>
        /// Gets the TIFF header.
        /// </summary>
        public TIFFHeader TIFFHeader { get; private set; }

        /// <summary>
        /// Saves the <see cref="ImageFile"/> to the given stream.
        /// </summary>
        /// <param name="stream">The data stream used to save the image.</param>
        protected override void SaveInternal(MemoryStream stream)
        {
            BitConverterEx conv = BitConverterEx.SystemEndian;

            // Write TIFF header
            uint ifdoffset = 8;
            // Byte order
            stream.Write((BitConverterEx.SystemByteOrder == BitConverterEx.ByteOrder.LittleEndian ? new byte[] { 0x49, 0x49 } : new byte[] { 0x4D, 0x4D }), 0, 2);
            // TIFF ID
            stream.Write(conv.GetBytes((ushort)42), 0, 2);
            // Offset to 0th IFD, will be corrected below
            stream.Write(conv.GetBytes(ifdoffset), 0, 4);

            // Write IFD sections
            for (int i = 0; i < IFDs.Count; i++)
            {
                ImageFileDirectory ifd = IFDs[i];

                // Update zeroth IFD fields from image properties
                if (i == 0)
                {
                    var ifdZeroth = new Dictionary<ushort, ImageFileDirectoryEntry>();
                    foreach (var prop in Properties)
                    {
                        if (prop.IFD == IFD.Zeroth)
                        {
                            var interop = prop.Interoperability;
                            if (ifdZeroth.TryGetValue(interop.TagID, out var field))
                            {
                                field.Count = interop.Count;
                                field.Data = interop.Data;
                            }
                            else
                            {
                                ifdZeroth.Add(interop.TagID, new ImageFileDirectoryEntry(interop.TagID, (ushort)interop.TypeID, interop.Count, interop.Data));
                            }
                        }
                    }

                    ifd.Fields.Clear();
                    ifd.Fields.AddRange(ifdZeroth.Values);
                }

                // Save the location of IFD offset
                long ifdLocation = stream.Position - 4;

                // Write strips first
                byte[] stripOffsets = new byte[4 * ifd.Strips.Count];
                byte[] stripLengths = new byte[4 * ifd.Strips.Count];
                uint stripOffset = ifdoffset;
                for (int j = 0; j < ifd.Strips.Count; j++)
                {
                    byte[] stripData = ifd.Strips[j].Data;
                    byte[] oBytes = BitConverter.GetBytes(stripOffset);
                    byte[] lBytes = BitConverter.GetBytes((uint)stripData.Length);
                    Array.Copy(oBytes, 0, stripOffsets, 4 * j, 4);
                    Array.Copy(lBytes, 0, stripLengths, 4 * j, 4);
                    stream.Write(stripData, 0, stripData.Length);
                    stripOffset += (uint)stripData.Length;
                }

                // Remove old strip tags
                for (int j = ifd.Fields.Count - 1; j > 0; j--)
                {
                    ushort tag = ifd.Fields[j].Tag;
                    if (tag == 273 || tag == 279)
                        ifd.Fields.RemoveAt(j);
                }
                // Write new strip tags
                ifd.Fields.Add(new ImageFileDirectoryEntry(273, 4, (uint)ifd.Strips.Count, stripOffsets));
                ifd.Fields.Add(new ImageFileDirectoryEntry(279, 4, (uint)ifd.Strips.Count, stripLengths));

                // Write fields after strips
                ifdoffset = stripOffset;

                // Correct IFD offset
                long currentLocation = stream.Position;
                stream.Seek(ifdLocation, SeekOrigin.Begin);
                stream.Write(conv.GetBytes(ifdoffset), 0, 4);
                stream.Seek(currentLocation, SeekOrigin.Begin);

                // Offset to field data
                uint dataOffset = ifdoffset + 2 + (uint)ifd.Fields.Count * 12 + 4;

                // Field count
                stream.Write(conv.GetBytes((ushort)ifd.Fields.Count), 0, 2);

                // Fields
                foreach (ImageFileDirectoryEntry field in ifd.Fields)
                {
                    // Tag
                    stream.Write(conv.GetBytes(field.Tag), 0, 2);
                    // Type
                    stream.Write(conv.GetBytes(field.Type), 0, 2);
                    // Count
                    stream.Write(conv.GetBytes(field.Count), 0, 4);

                    // Field data
                    byte[] data = field.Data;
                    if (data.Length <= 4)
                    {
                        stream.Write(data, 0, data.Length);
                        for (int j = data.Length; j < 4; j++)
                            stream.WriteByte(0);
                    }
                    else
                    {
                        stream.Write(conv.GetBytes(dataOffset), 0, 4);
                        long currentOffset = stream.Position;
                        stream.Seek(dataOffset, SeekOrigin.Begin);
                        stream.Write(data, 0, data.Length);
                        dataOffset += (uint)data.Length;
                        stream.Seek(currentOffset, SeekOrigin.Begin);
                    }
                }

                // Offset to next IFD
                ifdoffset = dataOffset;
                stream.Write(conv.GetBytes(i == IFDs.Count - 1 ? 0 : ifdoffset), 0, 4);
            }
        }

        /// <summary>
        /// Decreases file size by removing all metadata.
        /// </summary>
        public override void Crush()
        {
            Properties.Clear();

            // Remove tags.
            foreach (ImageFileDirectory ifd in IFDs)
            {
                ifd.Fields.RemoveAll((field) =>
                {
                    return (!WhiteList.ContainsKey((ExifTag)field.Tag));
                });
            }
        }
    }
}