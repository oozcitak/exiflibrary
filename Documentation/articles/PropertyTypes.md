---
uid: Articles.PropertyTypes
title: Property Types
---
# Property Types #

To read a metadata property you need to tell the library the type of property data. For example, to get the value of ISO speed rating, which is unsigned short:
```cs
var file = ImageFile.FromFile("path_to_image");

var isoTag = file.Properties.Get<ExifUShort>(ExifTag.ISOSpeedRatings);
```

Similarly, to get the flash property which is an enum:
```cs
var flashTag = data.Properties.Get<ExifEnumProperty<Flash>>(ExifTag.Flash);
```

Or the GPS latitude which is a custom type:
```cs
var latTag = data.Properties.Get<GPSLatitudeLongitude>(ExifTag.GPSLatitude);
```

## Known Types ##

Metadata properties understood by the library are listed below:

### JPEG/Exif Metadata ###

Exif Tag | Tag ID | Tag ID (Hex) | Property Type | Value Type
---------|--------|--------------|---------------|-----------
[ApertureValue](xref:ExifLibrary.ExifTag.ApertureValue) | 37378 | 0x9202 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[Artist](xref:ExifLibrary.ExifTag.Artist) | 315 | 0x013B | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[BitsPerSample](xref:ExifLibrary.ExifTag.BitsPerSample) | 258 | 0x0102 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[3]
[BrightnessValue](xref:ExifLibrary.ExifTag.BrightnessValue) | 37379 | 0x9203 | [ExifSRational](xref:ExifLibrary.ExifSRational) | [MathEx.Fraction32](xref:ExifLibrary.MathEx.Fraction32)
[CellLength](xref:ExifLibrary.ExifTag.CellLength) | 265 | 0x0109 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[CellWidth](xref:ExifLibrary.ExifTag.CellWidth) | 264 | 0x0108 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[CFAPattern](xref:ExifLibrary.ExifTag.CFAPattern) | 41730 | 0xA302 | [ExifUndefined](xref:ExifLibrary.ExifUndefined) | byte[]
[ColorMap](xref:ExifLibrary.ExifTag.ColorMap) | 320 | 0x0140 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[3*(2^BitsPerSample)]
[ColorSpace](xref:ExifLibrary.ExifTag.ColorSpace) | 40961 | 0xA001 | [ExifEnumProperty\<ColorSpace>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(ColorSpace)](xref:ExifLibrary.ColorSpace)
[ComponentsConfiguration](xref:ExifLibrary.ExifTag.ComponentsConfiguration) | 37121 | 0x9101 | [ExifUndefined](xref:ExifLibrary.ExifUndefined) | byte[4]
[CompressedBitsPerPixel](xref:ExifLibrary.ExifTag.CompressedBitsPerPixel) | 37122 | 0x9102 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[Compression](xref:ExifLibrary.ExifTag.Compression) | 259 | 0x0103 | [ExifEnumProperty\<Compression>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(Compression)](xref:ExifLibrary.Compression)
[Contrast](xref:ExifLibrary.ExifTag.Contrast) | 41992 | 0xA408 | [ExifEnumProperty\<Contrast>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(Contrast)](xref:ExifLibrary.Contrast)
[Copyright](xref:ExifLibrary.ExifTag.Copyright) | 33432 | 0x8298 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[CustomRendered](xref:ExifLibrary.ExifTag.CustomRendered) | 41985 | 0xA401 | [ExifEnumProperty\<CustomRendered>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(CustomRendered)](xref:ExifLibrary.CustomRendered)
[DateTime](xref:ExifLibrary.ExifTag.DateTime) | 306 | 0x0132 | [ExifDateTime](xref:ExifLibrary.ExifDateTime) | DateTime
[DateTimeDigitized](xref:ExifLibrary.ExifTag.DateTimeDigitized) | 36868 | 0x9004 | [ExifDateTime](xref:ExifLibrary.ExifDateTime) | DateTime
[DateTimeOriginal](xref:ExifLibrary.ExifTag.DateTimeOriginal) | 36867 | 0x9003 | [ExifDateTime](xref:ExifLibrary.ExifDateTime) | DateTime
[DeviceSettingDescription](xref:ExifLibrary.ExifTag.DeviceSettingDescription) | 41995 | 0xA40B | [ExifUndefined](xref:ExifLibrary.ExifUndefined) | byte[]
[DigitalZoomRatio](xref:ExifLibrary.ExifTag.DigitalZoomRatio) | 41988 | 0xA404 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[DocumentName](xref:ExifLibrary.ExifTag.DocumentName) | 269 | 0x010D | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[DotRange](xref:ExifLibrary.ExifTag.DotRange) | 336 | 0x0150 | [ExifByteArray](xref:ExifLibrary.ExifByteArray) or [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | byte[2 or 2\*NumberOfInks] or ushort[2 or 2\*NumberOfInks]
[ExifVersion](xref:ExifLibrary.ExifTag.ExifVersion) | 36864 | 0x9000 | [ExifVersion](xref:ExifLibrary.ExifVersion) | string
[ExposureBiasValue](xref:ExifLibrary.ExifTag.ExposureBiasValue) | 37380 | 0x9204 | [ExifSRational](xref:ExifLibrary.ExifSRational) | [MathEx.Fraction32](xref:ExifLibrary.MathEx.Fraction32)
[ExposureIndex](xref:ExifLibrary.ExifTag.ExposureIndex) | 41493 | 0xA215 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[ExposureMode](xref:ExifLibrary.ExifTag.ExposureMode) | 41986 | 0xA402 | [ExifEnumProperty\<ExposureMode>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(ExposureMode)](xref:ExifLibrary.ExposureMode)
[ExposureProgram](xref:ExifLibrary.ExifTag.ExposureProgram) | 34850 | 0x8822 | [ExifEnumProperty\<ExposureProgram>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(ExposureProgram)](xref:ExifLibrary.ExposureProgram)
[ExposureTime](xref:ExifLibrary.ExifTag.ExposureTime) | 33434 | 0x829A | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[ExtraSamples](xref:ExifLibrary.ExifTag.ExtraSamples) | 338 | 0x0152 | [ExifByteArray](xref:ExifLibrary.ExifByteArray) | byte[]
[FileSource](xref:ExifLibrary.ExifTag.FileSource) | 41728 | 0xA300 | [ExifEnumProperty\<FileSource>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(FileSource)](xref:ExifLibrary.FileSource)
[FillOrder](xref:ExifLibrary.ExifTag.FillOrder) | 266 | 0x010A | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[Flash](xref:ExifLibrary.ExifTag.Flash) | 37385 | 0x9209 | [ExifEnumProperty\<Flash>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(Flash)](xref:ExifLibrary.Flash)
[FlashEnergy](xref:ExifLibrary.ExifTag.FlashEnergy) | 41483 | 0xA20B | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[FlashpixVersion](xref:ExifLibrary.ExifTag.FlashpixVersion) | 40960 | 0xA000 | [ExifVersion](xref:ExifLibrary.ExifVersion) | string
[FNumber](xref:ExifLibrary.ExifTag.FNumber) | 33437 | 0x829D | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[FocalLength](xref:ExifLibrary.ExifTag.FocalLength) | 37386 | 0x920A | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[FocalLengthIn35mmFilm](xref:ExifLibrary.ExifTag.FocalLengthIn35mmFilm) | 41989 | 0xA405 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[FocalPlaneResolutionUnit](xref:ExifLibrary.ExifTag.FocalPlaneResolutionUnit) | 41488 | 0xA210 | [ExifEnumProperty\<ResolutionUnit>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(ResolutionUnit)](xref:ExifLibrary.ResolutionUnit)
[FocalPlaneXResolution](xref:ExifLibrary.ExifTag.FocalPlaneXResolution) | 41486 | 0xA20E | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[FocalPlaneYResolution](xref:ExifLibrary.ExifTag.FocalPlaneYResolution) | 41487 | 0xA20F | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[FreeByteCounts](xref:ExifLibrary.ExifTag.FreeByteCounts) | 289 | 0x0121 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[]
[FreeOffsets](xref:ExifLibrary.ExifTag.FreeOffsets) | 288 | 0x0120 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[]
[GainControl](xref:ExifLibrary.ExifTag.GainControl) | 41991 | 0xA407 | [ExifEnumProperty\<GainControl>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GainControl)](xref:ExifLibrary.GainControl)
[GPSAltitude](xref:ExifLibrary.ExifTag.GPSAltitude) | 6 | 0x0006 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[GPSAltitudeRef](xref:ExifLibrary.ExifTag.GPSAltitudeRef) | 5 | 0x0005 | [ExifEnumProperty\<GPSAltitudeRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSAltitudeRef)](xref:ExifLibrary.GPSAltitudeRef)
[GPSAreaInformation](xref:ExifLibrary.ExifTag.GPSAreaInformation) | 28 | 0x001C | [ExifUndefined](xref:ExifLibrary.ExifUndefined) | byte[]
[GPSDateStamp](xref:ExifLibrary.ExifTag.GPSDateStamp) | 29 | 0x001D | [ExifDate](xref:ExifLibrary.ExifDate) | [MathEx.UFraction32[3](Hour, Minute, Second)](xref:ExifLibrary.MathEx.UFraction32)
[GPSDestBearing](xref:ExifLibrary.ExifTag.GPSDestBearing) | 24 | 0x0018 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[GPSDestBearingRef](xref:ExifLibrary.ExifTag.GPSDestBearingRef) | 23 | 0x0017 | [ExifEnumProperty\<GPSDirectionRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSDirectionRef)](xref:ExifLibrary.GPSDirectionRef)
[GPSDestDistance](xref:ExifLibrary.ExifTag.GPSDestDistance) | 26 | 0x001A | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[GPSDestDistanceRef](xref:ExifLibrary.ExifTag.GPSDestDistanceRef) | 25 | 0x0019 | [ExifEnumProperty\<GPSDistanceRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSDistanceRef)](xref:ExifLibrary.GPSDistanceRef)
[GPSDestLatitude](xref:ExifLibrary.ExifTag.GPSDestLatitude) | 20 | 0x0014 | [GPSLatitudeLongitude](xref:ExifLibrary.GPSLatitudeLongitude) | [MathEx.UFraction32[3](Degrees, Minutes, Seconds)](xref:ExifLibrary.MathEx.UFraction32)
[GPSDestLatitudeRef](xref:ExifLibrary.ExifTag.GPSDestLatitudeRef) | 19 | 0x0013 | [ExifEnumProperty\<GPSLatitudeRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSLatitudeRef)](xref:ExifLibrary.GPSLatitudeRef)
[GPSDestLongitude](xref:ExifLibrary.ExifTag.GPSDestLongitude) | 22 | 0x0016 | [GPSLatitudeLongitude](xref:ExifLibrary.GPSLatitudeLongitude) | [MathEx.UFraction32[3](Degrees, Minutes, Seconds)](xref:ExifLibrary.MathEx.UFraction32)
[GPSDestLongitudeRef](xref:ExifLibrary.ExifTag.GPSDestLongitudeRef) | 21 | 0x0015 | [ExifEnumProperty\<GPSLongitudeRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSLongitudeRef)](xref:ExifLibrary.GPSLongitudeRef)
[GPSDifferential](xref:ExifLibrary.ExifTag.GPSDifferential) | 30 | 0x001E | [ExifEnumProperty\<GPSDifferential>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSDifferential)](xref:ExifLibrary.GPSDifferential)
[GPSDOP](xref:ExifLibrary.ExifTag.GPSDOP) | 11 | 0x000B | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[GPSImgDirection](xref:ExifLibrary.ExifTag.GPSImgDirection) | 17 | 0x0011 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[GPSImgDirectionRef](xref:ExifLibrary.ExifTag.GPSImgDirectionRef) | 16 | 0x0010 | [ExifEnumProperty\<GPSDirectionRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSDirectionRef)](xref:ExifLibrary.GPSDirectionRef)
[GPSLatitude](xref:ExifLibrary.ExifTag.GPSLatitude) | 2 | 0x0002 | [GPSLatitudeLongitude](xref:ExifLibrary.GPSLatitudeLongitude) | [MathEx.UFraction32[3](Degrees, Minutes, Seconds)](xref:ExifLibrary.MathEx.UFraction32)
[GPSLatitudeRef](xref:ExifLibrary.ExifTag.GPSLatitudeRef) | 1 | 0x0001 | [ExifEnumProperty\<GPSLatitudeRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSLatitudeRef)](xref:ExifLibrary.GPSLatitudeRef)
[GPSLongitude](xref:ExifLibrary.ExifTag.GPSLongitude) | 4 | 0x0004 | [GPSLatitudeLongitude](xref:ExifLibrary.GPSLatitudeLongitude) | [MathEx.UFraction32[3](Degrees, Minutes, Seconds)](xref:ExifLibrary.MathEx.UFraction32)
[GPSLongitudeRef](xref:ExifLibrary.ExifTag.GPSLongitudeRef) | 3 | 0x0003 | [ExifEnumProperty\<GPSLongitudeRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSLongitudeRef)](xref:ExifLibrary.GPSLongitudeRef)
[GPSMapDatum](xref:ExifLibrary.ExifTag.GPSMapDatum) | 18 | 0x0012 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[GPSMeasureMode](xref:ExifLibrary.ExifTag.GPSMeasureMode) | 10 | 0x000A | [ExifEnumProperty\<GPSMeasureMode>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSMeasureMode)](xref:ExifLibrary.GPSMeasureMode)
[GPSProcessingMethod](xref:ExifLibrary.ExifTag.GPSProcessingMethod) | 27 | 0x001B | [ExifUndefined](xref:ExifLibrary.ExifUndefined) | byte[]
[GPSSatellites](xref:ExifLibrary.ExifTag.GPSSatellites) | 8 | 0x0008 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[GPSSpeed](xref:ExifLibrary.ExifTag.GPSSpeed) | 13 | 0x000D | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[GPSSpeedRef](xref:ExifLibrary.ExifTag.GPSSpeedRef) | 12 | 0x000C | [ExifEnumProperty\<GPSSpeedRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSSpeedRef)](xref:ExifLibrary.GPSSpeedRef)
[GPSStatus](xref:ExifLibrary.ExifTag.GPSStatus) | 9 | 0x0009 | [ExifEnumProperty\<GPSStatus>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSStatus)](xref:ExifLibrary.GPSStatus)
[GPSTimeStamp](xref:ExifLibrary.ExifTag.GPSTimeStamp) | 7 | 0x0007 | [GPSTimeStamp](xref:ExifLibrary.GPSTimeStamp) | [MathEx.UFraction32[3](Hour, Minute, Second)](xref:ExifLibrary.MathEx.UFraction32)
[GPSTrack](xref:ExifLibrary.ExifTag.GPSTrack) | 15 | 0x000F | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[GPSTrackRef](xref:ExifLibrary.ExifTag.GPSTrackRef) | 14 | 0x000E | [ExifEnumProperty\<GPSDirectionRef>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(GPSDirectionRef)](xref:ExifLibrary.GPSDirectionRef)
[GPSVersionID](xref:ExifLibrary.ExifTag.GPSVersionID) | 0 | 0x0000 | [ExifVersion](xref:ExifLibrary.ExifVersion) | string
[GrayResponseCurve](xref:ExifLibrary.ExifTag.GrayResponseCurve) | 291 | 0x0123 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[2^BitsPerSample]
[GrayResponseUnit](xref:ExifLibrary.ExifTag.GrayResponseUnit) | 290 | 0x0122 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[HalftoneHints](xref:ExifLibrary.ExifTag.HalftoneHints) | 321 | 0x0141 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[2]
[HostComputer](xref:ExifLibrary.ExifTag.HostComputer) | 316 | 0x013C | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[ImageDescription](xref:ExifLibrary.ExifTag.ImageDescription) | 270 | 0x010E | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[ImageLength](xref:ExifLibrary.ExifTag.ImageLength) | 257 | 0x0101 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[ImageUniqueID](xref:ExifLibrary.ExifTag.ImageUniqueID) | 42016 | 0xA420 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[33]
[ImageWidth](xref:ExifLibrary.ExifTag.ImageWidth) | 256 | 0x0100 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[InkNames](xref:ExifLibrary.ExifTag.InkNames) | 333 | 0x014D | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[InkSet](xref:ExifLibrary.ExifTag.InkSet) | 332 | 0x014C | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[ISOSpeedRatings](xref:ExifLibrary.ExifTag.ISOSpeedRatings) | 34855 | 0x8827 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[]
[JPEGACTables](xref:ExifLibrary.ExifTag.JPEGACTables) | 521 | 0x0209 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[SamplesPerPixel]
[JPEGDCTables](xref:ExifLibrary.ExifTag.JPEGDCTables) | 520 | 0x0208 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[SamplesPerPixel]
[JPEGInterchangeFormat](xref:ExifLibrary.ExifTag.JPEGInterchangeFormat) | 513 | 0x0201 | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[JPEGInterchangeFormatLength](xref:ExifLibrary.ExifTag.JPEGInterchangeFormatLength) | 514 | 0x0202 | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[JPEGLosslessPredictors](xref:ExifLibrary.ExifTag.JPEGLosslessPredictors) | 517 | 0x0205 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[JPEGPointTransforms](xref:ExifLibrary.ExifTag.JPEGPointTransforms) | 518 | 0x0206 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[JPEGProc](xref:ExifLibrary.ExifTag.JPEGProc) | 512 | 0x0200 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[JPEGQTables](xref:ExifLibrary.ExifTag.JPEGQTables) | 519 | 0x0207 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[SamplesPerPixel]
[JPEGRestartInterval](xref:ExifLibrary.ExifTag.JPEGRestartInterval) | 515 | 0x0203 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[LightSource](xref:ExifLibrary.ExifTag.LightSource) | 37384 | 0x9208 | [ExifEnumProperty\<LightSource>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(LightSource)](xref:ExifLibrary.LightSource)
[Make](xref:ExifLibrary.ExifTag.Make) | 271 | 0x010F | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[MakerNote](xref:ExifLibrary.ExifTag.MakerNote) | 37500 | 0x927C | [ExifUndefined](xref:ExifLibrary.ExifUndefined) | byte[]
[MaxApertureValue](xref:ExifLibrary.ExifTag.MaxApertureValue) | 37381 | 0x9205 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[MaxSampleValue](xref:ExifLibrary.ExifTag.MaxSampleValue) | 281 | 0x0119 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[MeteringMode](xref:ExifLibrary.ExifTag.MeteringMode) | 37383 | 0x9207 | [ExifEnumProperty\<MeteringMode>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(MeteringMode)](xref:ExifLibrary.MeteringMode)
[MinSampleValue](xref:ExifLibrary.ExifTag.MinSampleValue) | 280 | 0x0118 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[Model](xref:ExifLibrary.ExifTag.Model) | 272 | 0x0110 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[NewSubfileType](xref:ExifLibrary.ExifTag.NewSubfileType) | 254 | 0x00FE | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[NumberOfInks](xref:ExifLibrary.ExifTag.NumberOfInks) | 334 | 0x014E | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[OECF](xref:ExifLibrary.ExifTag.OECF) | 34856 | 0x8828 | [ExifUndefined](xref:ExifLibrary.ExifUndefined) | byte[]
[Orientation](xref:ExifLibrary.ExifTag.Orientation) | 274 | 0x0112 | [ExifEnumProperty\<Orientation>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(Orientation)](xref:ExifLibrary.Orientation)
[PageName](xref:ExifLibrary.ExifTag.PageName) | 285 | 0x011D | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[PageNumber](xref:ExifLibrary.ExifTag.PageNumber) | 297 | 0x0129 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[2]
[PhotometricInterpretation](xref:ExifLibrary.ExifTag.PhotometricInterpretation) | 262 | 0x0106 | [ExifEnumProperty\<PhotometricInterpretation>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(PhotometricInterpretation)](xref:ExifLibrary.PhotometricInterpretation)
[PixelXDimension](xref:ExifLibrary.ExifTag.PixelXDimension) | 40962 | 0xA002 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[PixelYDimension](xref:ExifLibrary.ExifTag.PixelYDimension) | 40963 | 0xA003 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[PlanarConfiguration](xref:ExifLibrary.ExifTag.PlanarConfiguration) | 284 | 0x011C | [ExifEnumProperty\<PlanarConfiguration>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(PlanarConfiguration)](xref:ExifLibrary.PlanarConfiguration)
[Predictor](xref:ExifLibrary.ExifTag.Predictor) | 317 | 0x013D | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[PrimaryChromaticities](xref:ExifLibrary.ExifTag.PrimaryChromaticities) | 319 | 0x013F | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[6]](xref:ExifLibrary.MathEx.UFraction32)
[ReferenceBlackWhite](xref:ExifLibrary.ExifTag.ReferenceBlackWhite) | 532 | 0x0214 | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[6]](xref:ExifLibrary.MathEx.UFraction32)
[RelatedSoundFile](xref:ExifLibrary.ExifTag.RelatedSoundFile) | 40964 | 0xA004 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[13]
[ResolutionUnit](xref:ExifLibrary.ExifTag.ResolutionUnit) | 296 | 0x0128 | [ExifEnumProperty\<ResolutionUnit>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(ResolutionUnit)](xref:ExifLibrary.ResolutionUnit)
[RowsPerStrip](xref:ExifLibrary.ExifTag.RowsPerStrip) | 278 | 0x0116 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[SampleFormat](xref:ExifLibrary.ExifTag.SampleFormat) | 339 | 0x0153 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[SamplesPerPixel](xref:ExifLibrary.ExifTag.SamplesPerPixel) | 277 | 0x0115 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[Saturation](xref:ExifLibrary.ExifTag.Saturation) | 41993 | 0xA409 | [ExifEnumProperty\<Saturation>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(Saturation)](xref:ExifLibrary.Saturation)
[SceneCaptureType](xref:ExifLibrary.ExifTag.SceneCaptureType) | 41990 | 0xA406 | [ExifEnumProperty\<SceneCaptureType>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(SceneCaptureType)](xref:ExifLibrary.SceneCaptureType)
[SceneType](xref:ExifLibrary.ExifTag.SceneType) | 41729 | 0xA301 | [ExifEnumProperty\<SceneType>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(SceneType)](xref:ExifLibrary.SceneType)
[SensingMethod](xref:ExifLibrary.ExifTag.SensingMethod) | 41495 | 0xA217 | [ExifEnumProperty\<SensingMethod>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(SensingMethod)](xref:ExifLibrary.SensingMethod)
[Sharpness](xref:ExifLibrary.ExifTag.Sharpness) | 41994 | 0xA40A | [ExifEnumProperty\<Sharpness>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(Sharpness)](xref:ExifLibrary.Sharpness)
[ShutterSpeedValue](xref:ExifLibrary.ExifTag.ShutterSpeedValue) | 37377 | 0x9201 | [ExifSRational](xref:ExifLibrary.ExifSRational) | [MathEx.Fraction32](xref:ExifLibrary.MathEx.Fraction32)
[SMaxSampleValue](xref:ExifLibrary.ExifTag.SMaxSampleValue) | 341 | 0x0155 | [Any] | Any[SamplesPerPixel]
[SMinSampleValue](xref:ExifLibrary.ExifTag.SMinSampleValue) | 340 | 0x0154 | [Any] | Any[SamplesPerPixel]
[Software](xref:ExifLibrary.ExifTag.Software) | 305 | 0x0131 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[SpatialFrequencyResponse](xref:ExifLibrary.ExifTag.SpatialFrequencyResponse) | 41484 | 0xA20C | [ExifUndefined](xref:ExifLibrary.ExifUndefined) | byte[]
[SpectralSensitivity](xref:ExifLibrary.ExifTag.SpectralSensitivity) | 34852 | 0x8824 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[StripByteCounts](xref:ExifLibrary.ExifTag.StripByteCounts) | 279 | 0x0117 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) or [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | ushort[] or uint[]
[StripOffsets](xref:ExifLibrary.ExifTag.StripOffsets) | 273 | 0x0111 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) or [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | ushort[] or uint[]
[SubfileType](xref:ExifLibrary.ExifTag.SubfileType) | 255 | 0x00FF | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[SubjectArea](xref:ExifLibrary.ExifTag.SubjectArea) | 37396 | 0x9214 | [ExifPointSubjectArea](xref:ExifLibrary.ExifPointSubjectArea) or [ExifCircularSubjectArea](xref:ExifLibrary.ExifCircularSubjectArea) or [ExifRectangularSubjectArea](xref:ExifLibrary.ExifRectangularSubjectArea) | ushort[2] \(X, Y), ushort[3] \(X, Y, Diameter), ushort[4] \(X, Y, Width, Height)
[SubjectDistance](xref:ExifLibrary.ExifTag.SubjectDistance) | 37382 | 0x9206 | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[SubjectDistanceRange](xref:ExifLibrary.ExifTag.SubjectDistanceRange) | 41996 | 0xA40C | [ExifEnumProperty\<SubjectDistanceRange>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(SubjectDistanceRange)](xref:ExifLibrary.SubjectDistanceRange)
[SubjectLocation](xref:ExifLibrary.ExifTag.SubjectLocation) | 41492 | 0xA214 | [ExifPointSubjectArea](xref:ExifLibrary.ExifPointSubjectArea) | ushort[2] \(X, Y)
[SubSecTime](xref:ExifLibrary.ExifTag.SubSecTime) | 37520 | 0x9290 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[SubSecTimeDigitized](xref:ExifLibrary.ExifTag.SubSecTimeDigitized) | 37522 | 0x9292 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[SubSecTimeOriginal](xref:ExifLibrary.ExifTag.SubSecTimeOriginal) | 37521 | 0x9291 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[T4Options](xref:ExifLibrary.ExifTag.T4Options) | 292 | 0x0124 | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[T6Options](xref:ExifLibrary.ExifTag.T6Options) | 293 | 0x0125 | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[TargetPrinter](xref:ExifLibrary.ExifTag.TargetPrinter) | 337 | 0x0151 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string[]
[Threshholding](xref:ExifLibrary.ExifTag.Threshholding) | 263 | 0x0107 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[TileByteCounts](xref:ExifLibrary.ExifTag.TileByteCounts) | 325 | 0x0145 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) or [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | ushort[TilesPerImage] or uint[TilesPerImage]
[TileLength](xref:ExifLibrary.ExifTag.TileLength) | 323 | 0x0143 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[TileOffsets](xref:ExifLibrary.ExifTag.TileOffsets) | 324 | 0x0144 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[TilesPerImage]
[TileWidth](xref:ExifLibrary.ExifTag.TileWidth) | 322 | 0x0142 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[TransferFunction](xref:ExifLibrary.ExifTag.TransferFunction) | 301 | 0x012D | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[3*256]
[TransferRange](xref:ExifLibrary.ExifTag.TransferRange) | 342 | 0x0156 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[6]
[UserComment](xref:ExifLibrary.ExifTag.UserComment) | 37510 | 0x9286 | [ExifEncodedString](xref:ExifLibrary.ExifEncodedString) | string
[WhiteBalance](xref:ExifLibrary.ExifTag.WhiteBalance) | 41987 | 0xA403 | [ExifEnumProperty\<WhiteBalance>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(WhiteBalance)](xref:ExifLibrary.WhiteBalance)
[WhitePoint](xref:ExifLibrary.ExifTag.WhitePoint) | 318 | 0x013E | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[2]](xref:ExifLibrary.MathEx.UFraction32)
[XPosition](xref:ExifLibrary.ExifTag.XPosition) | 286 | 0x011E | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[]](xref:ExifLibrary.MathEx.UFraction32)
[XResolution](xref:ExifLibrary.ExifTag.XResolution) | 282 | 0x011A | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[YCbCrCoefficients](xref:ExifLibrary.ExifTag.YCbCrCoefficients) | 529 | 0x0211 | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[3]](xref:ExifLibrary.MathEx.UFraction32)
[YCbCrPositioning](xref:ExifLibrary.ExifTag.YCbCrPositioning) | 531 | 0x0213 | [ExifEnumProperty\<YCbCrPositioning>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(YCbCrPositioning)](xref:ExifLibrary.YCbCrPositioning)
[YCbCrSubSampling](xref:ExifLibrary.ExifTag.YCbCrSubSampling) | 530 | 0x0212 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[2]
[YPosition](xref:ExifLibrary.ExifTag.YPosition) | 287 | 0x011F | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[]](xref:ExifLibrary.MathEx.UFraction32)
[YResolution](xref:ExifLibrary.ExifTag.YResolution) | 283 | 0x011B | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
