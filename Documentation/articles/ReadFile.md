---
uid: Articles.ReadFile
title: Reading Image Files
---
# Reading Image Files #

To read an image file you can use the @ExifLibrary.ImageFile.FromFile(System.String) and @ExifLibrary.ImageFile.FromStream(System.IO.Stream) static methods:
```cs
var file = ImageFile.FromFile("path_to_image");
foreach(var property in file.Properties)
{
    Console.WriteLine(property.Name);
}
```

There are also asynchronous versions of these methods:
```cs
ExifLibrary.ImageFile.FromFileAsync("path_to_image").ContinueWith(t =>
{
    var file = t.Result;
    foreach(var property in file.Properties)
    {
        Console.WriteLine(property.Name);
    }
});
```