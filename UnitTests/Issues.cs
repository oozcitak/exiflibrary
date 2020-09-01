using System;
using Xunit;
using ExifLibrary;
using System.Linq;

namespace UnitTests
{
    public class Issues
    {
        [Fact(DisplayName = "An item with the same key has already been added.")]
        public void Issue66()
        {
            var originalDateTime = new DateTime(2019, 12, 07, 19, 34, 35, DateTimeKind.Local);
            var modifiedDateTime = new DateTime(2019, 11, 07, 19, 34, 35, DateTimeKind.Local);

            var srcImage = TestHelpers.TestImagePath(".", "issue-66.jpg");
            var dstImage = TestHelpers.TestImagePath(".", "issue-66e.jpg");
            var file = ImageFile.FromFile(srcImage);

            var dateTimeProperty = file.Properties.FirstOrDefault(p => p.Name == "DateTime");

            if (dateTimeProperty?.Value is DateTime dt)
            {
                if (dt.Date == originalDateTime.Date)
                {
                    dateTimeProperty.Value = modifiedDateTime;
                }
                else
                {
                    dateTimeProperty.Value = originalDateTime;
                }
            }

            ;

            var exception = Record.Exception(() => file.Save(dstImage));
            Assert.Null(exception);
        }

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
