using System;
using Xunit;
using ExifLibrary;

namespace UnitTests
{
    public class Issues
    {
        [Fact]
        public void Issue77()
        {
            var srcImage = ImageFile.FromFile(TestHelpers.TestImagePath(".", "issue-77.jpg"));
            var dstImage = ImageFile.FromFile(TestHelpers.TestImagePath(".", "issue-77e.jpg"));

            Assert.False(dstImage.Properties.Contains(ExifTag.ExposureTime));
            dstImage.Properties.Set(srcImage.Properties.Get(ExifTag.ExposureTime));
            Assert.True(dstImage.Properties.Contains(ExifTag.ExposureTime));
        }
    }
}
