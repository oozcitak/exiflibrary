﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a JFIF thumbnail. (EXIF Specification: BYTE)
    /// </summary>
    public class JFIFThumbnailProperty : ExifProperty
    {
        protected JFIFThumbnail mValue;

        public JFIFThumbnailProperty(ExifTag tag, JFIFThumbnail value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (JFIFThumbnail)value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                if (mValue.Format == JFIFThumbnail.ImageFormat.BMP24Bit)
                    return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.BYTE, (uint)mValue.PixelData.Length, mValue.PixelData);
                else if (mValue.Format == JFIFThumbnail.ImageFormat.BMPPalette)
                {
                    byte[] data = new byte[mValue.Palette.Length + mValue.PixelData.Length];
                    Array.Copy(mValue.Palette, data, mValue.Palette.Length);
                    Array.Copy(mValue.PixelData, 0, data, mValue.Palette.Length, mValue.PixelData.Length);
                    return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.BYTE, (uint)data.Length, data);
                }
                else if (mValue.Format == JFIFThumbnail.ImageFormat.JPEG)
                    return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.BYTE, (uint)mValue.PixelData.Length, mValue.PixelData);
                else
                    throw new InvalidOperationException("Unknown thumbnail type.");
            }
        }

        public new JFIFThumbnail Value
        { get { return mValue; } set { mValue = value; } }

        public override string ToString()
        { return mValue.Format.ToString(); }
    }

    /// <summary>
    /// Represents the JFIF version as a 16 bit unsigned integer. (EXIF Specification: SHORT)
    /// </summary>
    public class JFIFVersion : ExifUShort
    {
        public JFIFVersion(ExifTag tag, ushort value)
                    : base(tag, value)
        {
            ;
        }

        public JFIFVersion(ExifTag tag, byte major, byte minor)
                    : base(tag, (ushort)(major * 256 + minor))
        {
            ;
        }

        /// <summary>
        /// Gets the major version.
        /// </summary>
        public byte Major
        { get { return (byte)(mValue >> 8); } }

        /// <summary>
        /// Gets the minor version.
        /// </summary>
        public byte Minor
        { get { return (byte)(mValue - (mValue >> 8) * 256); } }

        public override string ToString()
        {
            return string.Format("{0}.{1:00}", Major, Minor);
        }
    }
}