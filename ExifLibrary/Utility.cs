using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;

namespace ExifLibrary
{
    /// <summary>
    /// Contains utility functions.
    /// </summary>
    public class Utility
    {
        #region File I/O
        /// <summary>
        /// Reads the entire stream and returns its contents as a byte array.
        /// </summary>
        /// <param name="stream">The <see cref="System.IO.Stream"/> to read.</param>
        /// <returns>Contents of the <paramref name="stream"/> as a byte array.</returns>
        public static byte[] GetStreamBytes(Stream stream)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                stream.Seek(0, SeekOrigin.Begin);

                byte[] b = new byte[32768];
                int r;
                while ((r = stream.Read(b, 0, b.Length)) > 0)
                    mem.Write(b, 0, r);

                return mem.ToArray();
            }
        }

        /// <summary>
        /// Reads the stream into the given byte array.
        /// </summary>
        /// <param name="stream">The <see cref="System.IO.Stream"/> to read.</param>
        /// <param name="rem">The number of bytes to read.</param>
        /// <returns>Contents of the <paramref name="stream"/> as a byte array.</returns>
        public static byte[] GetStreamBytes(Stream stream, long rem)
        {
            using (MemoryStream mem = new MemoryStream())
            {
                byte[] b = new byte[32768];
                int r;
                while (rem > 0 && (r = stream.Read(b, 0, (int)Math.Min(rem, b.LongLength))) > 0)
                {
                    mem.Write(b, 0, r);
                    rem = rem - r;
                }

                return mem.ToArray();
            }
        }
        #endregion

        #region Crypto
        public static class CRC32
        {
            // Table of CRCs of all 8-bit messages.
            private static ulong[] table = null;

            /// <summary>
            /// Make the table for a fast CRC.
            /// </summary>
            private static void Initialize()
            {
                table = new ulong[256];

                for (int n = 0; n < 256; n++)
                {
                    ulong c = (ulong)n;
                    for (int k = 0; k < 8; k++)
                    {
                        if ((c & 1) != 0)
                            c = 0xedb88320L ^ (c >> 1);
                        else
                            c = c >> 1;
                    }
                    table[n] = c;
                }
            }

            /// <summary>
            /// Updates a running CRC with the given bytes. The CRC
            /// should be initialized to all 1's, and the transmitted value
            /// is the 1's complement of the final running CRC (see the
            /// CRC routine below).
            /// </summary>
            /// <param name="crc">Initial CRC.</param>
            /// <param name="buffer">The bytes to calculate the CRC of.</param>
            /// <returns>Checksum as 1's complement of the final running CRC.</returns>
            private static ulong UpdateCRC(ulong crc, byte[] buffer)
            {
                ulong c = crc;

                if (table == null)
                    Initialize();

                for (int n = 0; n < buffer.Length; n++)
                {
                    c = table[(c ^ buffer[n]) & 0xff] ^ (c >> 8);
                }
                return c;
            }

            /// <summary>
            /// Return the CRC of the given bytes.
            /// </summary>
            /// <param name="buf">The bytes to calculate the CRC of.</param>
            /// <returns>CRC checksum.</returns>
            public static ulong CRC(byte[] buffer)
            {
                return UpdateCRC(0xffffffffL, buffer) ^ 0xffffffffL;
            }

            /// <summary>
            /// Return the CRC of the given bytes.
            /// </summary>
            /// <param name="crc">Initial CRC.</param>
            /// <param name="buf">The bytes to calculate the CRC of.</param>
            /// <returns>CRC checksum.</returns>
            public static ulong Hash(ulong crc, byte[] buffer)
            {
                crc ^= 0xffffffffL;

                return UpdateCRC(crc, buffer) ^ 0xffffffffL;
            }
        }
        #endregion

        #region Compression
        /// <summary>
        /// Compresses the given string.
        /// </summary>
        /// <param name="text">Input string.</param>
        /// <param name="encoding">Text encoding.</param>
        /// <returns>The compressed bytes.</returns>
        public static byte[] CompressString(String text, Encoding encoding)
        {
            using (MemoryStream stream = new MemoryStream())
            using (DeflateStream zip = new DeflateStream(stream, CompressionMode.Compress))
            using (StreamWriter writer = new StreamWriter(zip, encoding))
            {
                writer.Write(text);
                return stream.ToArray();
            }
        }
        /// <summary>
        /// Compresses the given bytes representing a string.
        /// </summary>
        /// <param name="input">Input data.</param>
        /// <param name="encoding">Text encoding.</param>
        /// <returns>The decompressed string.</returns>
        public static string DecompressString(byte[] input, Encoding encoding)
        {
            using (MemoryStream stream = new MemoryStream(input))
            {
                //stream.Seek(2, SeekOrigin.Begin); // Skip zlib flags
                int b1 = stream.ReadByte();
                int b2 = stream.ReadByte();
                using (DeflateStream zip = new DeflateStream(stream, CompressionMode.Decompress))
                using (StreamReader reader = new StreamReader(zip, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion

        #region Arrays
        /// <summary>
        /// Splits the given byte array at seperators.
        /// </summary>
        /// <param name="data">Input array.</param>
        /// <param name="seperator">Separator byte.</param>
        /// <returns>Sub arrays splitted at the separator.</returns>
        public static List<byte[]> SplitByteArray(byte[] data, byte seperator)
        {
            List<byte[]> output = new List<byte[]>();
            long lastSepIndex = -1;
            long sepIndex = -1;
            for (long i = 0; i < data.LongLength; i++)
            {
                if (data[i] == seperator)
                {
                    sepIndex = i;
                    byte[] subArray = new byte[sepIndex - (lastSepIndex + 1)];
                    Array.Copy(data, lastSepIndex + 1, subArray, 0, subArray.LongLength);
                    lastSepIndex = sepIndex;
                    output.Add(subArray);
                }
            }
            if (lastSepIndex < data.LongLength - 1)
            {
                sepIndex = data.LongLength - 1;
                byte[] subArray = new byte[sepIndex - (lastSepIndex + 1)];
                Array.Copy(data, lastSepIndex + 1, subArray, 0, subArray.LongLength);
                lastSepIndex = sepIndex;
                output.Add(subArray);
            }
            return output;
        }
        #endregion
    }
}
