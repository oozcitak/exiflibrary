# Introduction #

ExifLibrary is a .NET library for extracting/editing metadata contained in JPEG/Exif files. ExifLibrary requires the .NET Framework 2.0.

# Using the Library #

To extract Exif metadata from a JPEG/Exif image, create an instance of the ImageFile class with the path to the image file. The ImageFile class reads the APP1 section, and extracts all Exif tags and also the embedded thumbnail (if any). For ease of use, the library converts Exif tags to either .NET native types or custom classes. Date fields are returned as DateTime structures, GPS coordinates are wrapped with custom !GPSLatitudeLongitude classes, etc.

```
// Extract exif metadata
ImageFile file = ImageFile.FromFile("path_to_my_image");

// Read metadata
foreach (ExifProperty item in file.Properties.Values)
{
    // Do something with meta data
}

// Get the thumbnail image
Image thumb = file.ThumbnailImage;
```

You can modify the metadata and save your changes.

```
// Extract exif metadata
ImageFile file = ImageFile.FromFile("path_to_my_image");

// Set the date time to now
file.Properties.Set(ExifTag.DateTime, DateTime.Now);
// Set GPS location to 22d 0m 0s
file.Properties.Set(ExifTag.GPSLatitude, 22.0, 0.0, 0.0);

// Save exif metadata with the image
file.Save("path_to_my_image");
```

You can add new metadata.

```
// Extract exif metadata
ImageFile file = ImageFile.FromFile("path_to_my_image");

// Add the Exif Artist tag
file.Properties.Set(ExifTag.Artist, "Me");

// Save exif metadata with the image
file.Save("path_to_my_image");
```

You can also clear the metadata.

```
// Extract exif metadata
ImageFile file = ImageFile.FromFile("path_to_my_image");

// Clear metadata
file.Properties.Clear();

// Save exif metadata with the image
file.Save("path_to_my_image");
```

# Known Issues #

There is a known issue with JPEG images with embedded TIFF thumbnails. The current version of ExifLibrary does not read or write TIFF thumbnails.