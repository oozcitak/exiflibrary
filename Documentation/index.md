---
uid: Home
title: Home
---
# Introduction #

ExifLibrary is a .NET Standard library for extracting image metadata.

# Installation #

If you are using [NuGet](https://nuget.org/) search for `ExifLibNet` in the NuGet Package Manager or install the assembly from the package manager console with:

`PM> Install-Package ExifLibNet`

# Quick Start #

To read an image file and extract metadata:

```cs
var file = ImageFile.FromFile("path_to_image");

// the type of the ISO speed rating tag value is unsigned short
// see documentation for tag data types
var isoTag = file.Properties.Get<ExifUShort>(ExifTag.ISOSpeedRatings);

// the flash tag's value is an enum
var flashTag = data.Properties.Get<ExifEnumProperty<Flash>>(ExifTag.Flash);

// GPS latitude is a custom type with three rational values
// representing degrees/minutes/seconds of the latitude 
var latTag = data.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLatitude);
```

To add metadata:

```cs
var file = ImageFile.FromFile("path_to_image");
// note the explicit cast to ushort
file.Properties.Set(ExifTag.ISOSpeedRatings, <ushort>200);
```

To save the image with metadata:
```cs
file.Save("path_to_image");
```
