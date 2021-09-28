---
uid: Articles.Properties
title: Metadata Properties
---
# Metadata Properties #

## Getting Properties ##

To read a metadata property you need to tell the library the type of property data. For example, to get the value of ISO speed rating, which is unsigned short:
```cs
var file = ImageFile.FromFile("path_to_image");
var isoTag = file.Properties.Get<ExifUShort>(ExifTag.ISOSpeedRatings);
```

Similarly, to get the flash property which is an enum:
```cs
var file = ImageFile.FromFile("path_to_image");
var flashTag = file.Properties.Get<ExifEnumProperty<Flash>>(ExifTag.Flash);
```

Or the GPS latitude which is a custom type:
```cs
var file = ImageFile.FromFile("path_to_image");
var latTag = file.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLatitude);
```

See the documentation for property data types.

There is also a non-generic method to get metadata:
```cs
var file = ImageFile.FromFile("path_to_image");
ExifProperty tag = file.Properties.Get(ExifTag.DateTime);
DateTime dateTime = (tag as ExifDateTime).Value;
```

Properties can also be retrieved by index or tag:
```cs
var file = ImageFile.FromFile("path_to_image");
ExifProperty tag1 = file.Properties[0];
ExifProperty tag2 = file.Properties[ExifTag.ISOSpeedRatings];
```

## Enumerating Properties ##

The [property collection](xref:ExifLibrary.ExifPropertyCollection`1) of an image file can be enumerated sequentially:
```cs
var file = ImageFile.FromFile("path_to_image");
foreach(var property in file.Properties)
{
    Console.WriteLine(property.Name);
}
```

## Adding and Modifying Properties ##

Although the [property collection](xref:ExifLibrary.ExifPropertyCollection`1) of an image file is a list, it also provides dictionary-like access to set properties by their tags:
```cs
var file = ImageFile.FromFile("path_to_image");
file.Properties.Set(ExifTag.ISOSpeedRatings, <ushort>200);
```
The @ExifLibrary.ExifPropertyCollection`1.Set(`0) method overwrites a property with the same tag or adds a new property if there is no existing property with the given tag. The @ExifLibrary.ExifPropertyCollection`1.Add(`0) method, on the other hand, adds the given property without checking if there is an existing property. So, it can potentially create duplicate properties. This is compliant with the standard, but not probably what you want.

Also, note the explicit cast to `ushort` in the above example. Without the cast, the data type would be `int`, which would be the wrong data type for the `ISOSpeedRatings` tag.

## Removing Properties ##

Properties can be removed by index or tag:
```cs
var file = ImageFile.FromFile("path_to_image");
file.Properties.RemoveAt(0);
file.Properties.Remove(ExifTag.ISOSpeedRatings);
```

The entire property collection can be cleared. Note however, this will potentially make the file unusable.
```cs
var file = ImageFile.FromFile("path_to_image");
file.Properties.Clear();
```

A better alternative to clear metadata is to use the @ExifLibrary.ImageFile.Crush method which keeps essential properties:
```cs
var file = ImageFile.FromFile("path_to_image");
file.Crush();
```
`Crush` uses a built-in whitelist.
