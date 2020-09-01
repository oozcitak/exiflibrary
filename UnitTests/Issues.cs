using System;
using Xunit;
using ExifLibrary;

namespace UnitTests
{
    public class Issues
    {
        [Fact(DisplayName = "Exceptions when trying to set value of type UFraction32")]
        public void Issue77()
        {
            var srcImage = ImageFile.FromFile(TestHelpers.TestImagePath(".", "issue-77.jpg"));
            var dstImage = ImageFile.FromFile(TestHelpers.TestImagePath(".", "issue-77e.jpg"));

            Assert.False(dstImage.Properties.Contains(ExifTag.ExposureTime));
            dstImage.Properties.Set(srcImage.Properties.Get(ExifTag.ExposureTime));
            Assert.True(dstImage.Properties.Contains(ExifTag.ExposureTime));
        }

        [Fact(DisplayName = "Image that won't load in exiflibrary")]
        public void Issue79()
        {
            var exception = Record.Exception(() => ImageFile.FromFile(TestHelpers.TestImagePath(".", "issue-79.jpg")));
            Assert.Null(exception);
        }
    }
}
