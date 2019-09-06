[![License](http://img.shields.io/npm/l/xmlbuilder.svg?style=flat-square)](http://opensource.org/licenses/MIT)
[![Nuget](https://img.shields.io/nuget/v/ExifLibNet.svg?style=flat-square)](https://www.nuget.org/packages/ExifLibNet)

[![Travis](https://img.shields.io/travis/oozcitak/exiflibrary.svg?style=flat-square)](https://travis-ci.org/oozcitak/exiflibrary)
[![AppVeyor](https://img.shields.io/appveyor/ci/oozcitak/exiflibrary.svg?style=flat-square)](https://ci.appveyor.com/project/oozcitak/exiflibrary)

ExifLibrary is a .Net Standard library for editing Exif metadata contained in image files.

# Installation #

If you are using [NuGet](https://nuget.org/) you can install the assembly with:

`PM> Install-Package ExifLibNet`

# Quick Start #

To read an image file and extract metadata:

```cs
var file = ImageFile.FromFile("path_to_image");
foreach (var item in file.Properties)
{
    if (item.Tag == ExifTag.ISOSpeedRatings)
    {
        var isoTag = item as ExifUShort;
        // the type of Value is unsigned short
        // see documentation for tag data types
        ushort iso = isoTag.Value;
    }
    else if (item.Tag == ExifTag.Flash)
    {
        var flashTag = item as ExifEnumProperty<Flash>;
        // Value is an enum property
        Flash flash = flashTag.Value;
    }
    else if (item.Tag == ExifTag.GPSLatitude)
    {
        var latTag = item as GPSLatitudeLongitude;
        // Value contains three rational numbers
        // representing degrees/minutes/seconds
        // of the latitude 
        MathEx.UFraction32[] lat = latTag.Value;
    }
}
```

To add metadata:

```cs
var file = ImageFile.FromFile("path_to_image");
file.Properties.Add(ExifTag.ISOSpeedRatings, 200);

```

To save the image with metadata:

```cs

file.Save("path_to_image");
```
