---
uid: Articles.SaveFile
title: Saving Image Files
---
# Saving Image Files #

Once you read an image file and modify metadata you can save back the file using the @ExifLibrary.ImageFile.Save(System.String) and @ExifLibrary.ImageFile.Save(System.IO.Stream) methods:
```cs
var file = ImageFile.FromFile("path_to_image");
// remove all metadata
file.Crush();
file.Save("path_to_modified_image");
```

There are also an asynchronous versions of the save methods:
```cs
ExifLibrary.ImageFile.FromFileAsync("path_to_image").ContinueWith(t =>
{
    var file = t.Result;
    // remove all metadata
    file.Crush();
    return file.SaveAsync("path_to_modified_image");
}).ContinueWith(t =>
{
    Console.WriteLine("File crushed&saved.");
});
```