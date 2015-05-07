# Release Notes #

## v0.18 Pre-Alpha (1 March 2013) ##

  * Converting to System.Drawing.Image does not try to dispose the source stream. ([Issue 40](https://code.google.com/p/exiflibrary/issues/detail?id=40))
  * Provide an optional text encoding paramater to be used with metadata fields with unknown encoding. ([Issue 41](https://code.google.com/p/exiflibrary/issues/detail?id=41))
  * Disable "Embed Thumbnail" button on demo project when there is no source image. ([Issue 33](https://code.google.com/p/exiflibrary/issues/detail?id=33))

## v0.17 Pre-Alpha (22 August 2012) ##

  * DateTime parser is now more forgiving. ([Issue 36](https://code.google.com/p/exiflibrary/issues/detail?id=36))
  * Do not try to preserve the maker note offset if we are already past it. ([Issue 39](https://code.google.com/p/exiflibrary/issues/detail?id=39))
  * Fixed IFD offsets while writing TIFF files.
  * Added a maximum iteration limit to fraction classes. ([Issue 37](https://code.google.com/p/exiflibrary/issues/detail?id=37))

## v0.16 Pre-Alpha (24 March 2011) ##

  * Added Set support for windows strings. ([Issue 32](https://code.google.com/p/exiflibrary/issues/detail?id=32))

# Release Notes #

## v0.15 Pre-Alpha (29 December 2010) ##

  * Added convenience setter methods to ExifPropertyCollection. They try to infer Exif type from the given arguments. Use with care, because they don't stop you (for now) from assigning unrelated values to tags (You can set the GPS longitude to a DateTime value for example).
  * Rational values now check for 0 denominators. ([Issue 28](https://code.google.com/p/exiflibrary/issues/detail?id=28))
  * Added support for TIFF Files. ([Issue 4](https://code.google.com/p/exiflibrary/issues/detail?id=4)) Note that the base class is now named ImageFile. **This is a breaking change**

## v0.14 Pre-Alpha (07 October 2010) ##

  * Setting property items when the collection already has the key had no effect. This is now fixed.

## v0.13 Pre-Alpha (23 August 2010) ##

  * Signed assembly. ([Issue 23](https://code.google.com/p/exiflibrary/issues/detail?id=23))

## v0.12 Pre-Alpha (03 August 2010) ##

  * Single digit date time values in Exif fields are now read correctly. ([Issue 21](https://code.google.com/p/exiflibrary/issues/detail?id=21))

## v0.11 Pre-Alpha (10 February 2010) ##

  * Fixed an unboxing issue in ExifProperty Value property setters ([Issue 14](https://code.google.com/p/exiflibrary/issues/detail?id=14)).
  * Fixed a bug where the thumbnail could not be written if the image did not already have a thumbnail ([Issue 16](https://code.google.com/p/exiflibrary/issues/detail?id=16)).

## v0.10 Pre-Alpha (02 February 2010) ##

  * Fixed a bug the SubjectDistance tag tried to overwrite the SubjectDistanceRange tag ([Issue 13](https://code.google.com/p/exiflibrary/issues/detail?id=13))
  * Fixed a bug in tag data conversion for tags with multiple components ([Issue 15](https://code.google.com/p/exiflibrary/issues/detail?id=15)).

## v0.9 Pre-Alpha (20 January 2010) ##

  * Fixed a bug where user comment fields were trimmed if shorter than 8 bytes. ([Issue 12](https://code.google.com/p/exiflibrary/issues/detail?id=12))

## v0.8 Pre-Alpha ##

  * Fixed an overflow bug in fraction calculations ([Issue 11](https://code.google.com/p/exiflibrary/issues/detail?id=11)).
  * Fixed a bug where user comment fields were trimmed after the first null character. ([Issue 12](https://code.google.com/p/exiflibrary/issues/detail?id=12))

## v0.7 Pre-Alpha ##

  * Fixed an overflow bug in fraction calculations.

## v0.6 Pre-Alpha ##

  * Fixed a bug where reading a Unicode UserComment field trimmed the field value after the first byte.

## v0.5 Pre-Alpha ##

  * Fixed a bug in fraction arithmetic operations.

## v0.4 Pre-Alpha ##

  * Fixed a bug when writing an empty APPn section wrote the section marker where it should skip the entire section.
  * JFIF and JFXX metadata is now fully supported.

## v0.3 Pre-Alpha ##

  * JFIF metadata is partially supported.

## v0.2 Pre-Alpha ##

  * Fixed a bug when writing an image without metadata threw an exception. Without the metadata the library defaulted to big-endian byte-order instead of platform byte-order.

## v0.1 Pre-Alpha ##

First public release.