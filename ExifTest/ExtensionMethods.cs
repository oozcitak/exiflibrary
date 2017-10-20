using ExifLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExifTest
{
    public static class ExtensionMethods
    {
        public static Image ToImage(this ImageFile img)
        {
            MemoryStream stream = new MemoryStream();
            img.Save(stream);
            return Image.FromStream(stream);
        }
    }
}
