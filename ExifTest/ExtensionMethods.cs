using ExifLibrary;
using System.Drawing;
using System.IO;

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
