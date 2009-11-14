using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the JFIF version as a 16 bit unsigned integer. (EXIF Specification: SHORT) 
    /// </summary>
    public class JFIFVersion : ExifUShort
    {
        /// <summary>
        /// Gets the major version.
        /// </summary>
        public byte Major { get { return (byte)(mValue >> 8); } }
        /// <summary>
        /// Gets the minor version.
        /// </summary>
        public byte Minor { get { return (byte)(mValue - (mValue >> 8) * 256); } }

        public JFIFVersion(ExifTag tag, ushort value)
            : base(tag, value)
        {
            ;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1:00}", Major, Minor);
        }
    }
}
