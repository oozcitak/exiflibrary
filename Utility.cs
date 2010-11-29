using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExifLibrary
{
    /// <summary>
    /// Contains utility functions.
    /// </summary>
    public class Utility
    {
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
    }
}
