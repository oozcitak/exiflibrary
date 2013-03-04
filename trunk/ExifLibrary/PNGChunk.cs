using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents the memory view of a PNG chunk.
    /// </summary>
    public class PNGChunk
    {
        #region Properties
        /// <summary>
        /// The four character ASCII chunk name/type.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Chunk data.
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        ///  The CRC computed over the chunk type and chunk data
        /// </summary>
        public uint CRC { get; private set; }
        /// <summary>
        /// Determines if this is a critical chunk.
        /// </summary>
        public bool IsCritical { get { return (Type[0] >= 'A') && (Type[0] <= 'Z'); } }
        /// <summary>
        /// Determines if this is a public chunk.
        /// </summary>
        public bool IsPublic { get { return (Type[1] >= 'A') && (Type[1] <= 'Z'); } }
        /// <summary>
        /// Determines if the chunk may be safely copied 
        /// regardless of the extent of modifications to the file.
        /// </summary>
        public bool IsSafeToCopy { get { return (Type[3] >= 'a') && (Type[3] <= 'z'); } }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructs a PNGChunk represented by the type name and containing
        /// the given data.
        /// </summary>
        /// <param name="type">The type of chuck.</param>
        /// <param name="data">Chunk data.</param>
        public PNGChunk(string type, byte[] data)
        {
            Type = type;
            Data = data;

            UpdateCRC();
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Updates the CRC value.
        /// </summary>
        public void UpdateCRC()
        {
            CRC = (uint)Utility.CRC32.Hash(0, Encoding.ASCII.GetBytes(Type));
            CRC = (uint)Utility.CRC32.Hash(CRC, Data);
        }

        /// <summary>
        /// Returns a string representation of the current chunk.
        /// </summary>
        /// <returns>A System.String that represents the current chunk.</returns>
        public override string ToString()
        {
            return string.Format("{0} => Data: {1} bytes, CRC32: {2}", Type, Data.Length, CRC);
        }
        #endregion
    }
}
