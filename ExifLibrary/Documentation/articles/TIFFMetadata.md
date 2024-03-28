---
uid: Articles.TIFFMetadata
title: TIFF Metadata
---

# TIFF Metadata #

Tag Name | Tag ID | Tag ID (Hex) | Property Type | Value Type
---------|--------|--------------|---------------|-----------
[Artist](xref:ExifLibrary.ExifTag.Artist) | 315 | 0x013B | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[BitsPerSample](xref:ExifLibrary.ExifTag.BitsPerSample) | 258 | 0x0102 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[3]
[CellLength](xref:ExifLibrary.ExifTag.CellLength) | 265 | 0x0109 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[CellWidth](xref:ExifLibrary.ExifTag.CellWidth) | 264 | 0x0108 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[ColorMap](xref:ExifLibrary.ExifTag.ColorMap) | 320 | 0x0140 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[3*(2^BitsPerSample)]
[Compression](xref:ExifLibrary.ExifTag.Compression) | 259 | 0x0103 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[Copyright](xref:ExifLibrary.ExifTag.Copyright) | 33432 | 0x8298 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[DateTime](xref:ExifLibrary.ExifTag.DateTime) | 306 | 0x0132 | [ExifDateTime](xref:ExifLibrary.ExifDateTime) | DateTime
[DocumentName](xref:ExifLibrary.ExifTag.DocumentName) | 269 | 0x010D | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[DotRange](xref:ExifLibrary.ExifTag.DotRange) | 336 | 0x0150 | [ExifByteArray](xref:ExifLibrary.ExifByteArray) or [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | byte[2 or 2\*NumberOfInks] or ushort[2 or 2\*NumberOfInks]
[ExtraSamples](xref:ExifLibrary.ExifTag.ExtraSamples) | 338 | 0x0152 | [ExifByteArray](xref:ExifLibrary.ExifByteArray) | byte[]
[FillOrder](xref:ExifLibrary.ExifTag.FillOrder) | 266 | 0x010A | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[FreeByteCounts](xref:ExifLibrary.ExifTag.FreeByteCounts) | 289 | 0x0121 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[]
[FreeOffsets](xref:ExifLibrary.ExifTag.FreeOffsets) | 288 | 0x0120 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[]
[GrayResponseCurve](xref:ExifLibrary.ExifTag.GrayResponseCurve) | 291 | 0x0123 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[2^BitsPerSample]
[GrayResponseUnit](xref:ExifLibrary.ExifTag.GrayResponseUnit) | 290 | 0x0122 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[HalftoneHints](xref:ExifLibrary.ExifTag.HalftoneHints) | 321 | 0x0141 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[2]
[HostComputer](xref:ExifLibrary.ExifTag.HostComputer) | 316 | 0x013C | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[ImageDescription](xref:ExifLibrary.ExifTag.ImageDescription) | 270 | 0x010E | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[ImageLength](xref:ExifLibrary.ExifTag.ImageLength) | 257 | 0x0101 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[ImageWidth](xref:ExifLibrary.ExifTag.ImageWidth) | 256 | 0x0100 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[InkNames](xref:ExifLibrary.ExifTag.InkNames) | 333 | 0x014D | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[InkSet](xref:ExifLibrary.ExifTag.InkSet) | 332 | 0x014C | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[JPEGACTables](xref:ExifLibrary.ExifTag.JPEGACTables) | 521 | 0x0209 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[SamplesPerPixel]
[JPEGDCTables](xref:ExifLibrary.ExifTag.JPEGDCTables) | 520 | 0x0208 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[SamplesPerPixel]
[JPEGInterchangeFormat](xref:ExifLibrary.ExifTag.JPEGInterchangeFormat) | 513 | 0x0201 | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[JPEGInterchangeFormatLength](xref:ExifLibrary.ExifTag.JPEGInterchangeFormatLength) | 514 | 0x0202 | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[JPEGLosslessPredictors](xref:ExifLibrary.ExifTag.JPEGLosslessPredictors) | 517 | 0x0205 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[JPEGPointTransforms](xref:ExifLibrary.ExifTag.JPEGPointTransforms) | 518 | 0x0206 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[JPEGProc](xref:ExifLibrary.ExifTag.JPEGProc) | 512 | 0x0200 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[JPEGQTables](xref:ExifLibrary.ExifTag.JPEGQTables) | 519 | 0x0207 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[SamplesPerPixel]
[JPEGRestartInterval](xref:ExifLibrary.ExifTag.JPEGRestartInterval) | 515 | 0x0203 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[Make](xref:ExifLibrary.ExifTag.Make) | 271 | 0x010F | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[MaxSampleValue](xref:ExifLibrary.ExifTag.MaxSampleValue) | 281 | 0x0119 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[MinSampleValue](xref:ExifLibrary.ExifTag.MinSampleValue) | 280 | 0x0118 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[Model](xref:ExifLibrary.ExifTag.Model) | 272 | 0x0110 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[NewSubfileType](xref:ExifLibrary.ExifTag.NewSubfileType) | 254 | 0x00FE | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[NumberOfInks](xref:ExifLibrary.ExifTag.NumberOfInks) | 334 | 0x014E | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[Orientation](xref:ExifLibrary.ExifTag.Orientation) | 274 | 0x0112 | [ExifEnumProperty\<Orientation>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(Orientation)](xref:ExifLibrary.Orientation)
[PageName](xref:ExifLibrary.ExifTag.PageName) | 285 | 0x011D | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[PageNumber](xref:ExifLibrary.ExifTag.PageNumber) | 297 | 0x0129 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[2]
[PhotometricInterpretation](xref:ExifLibrary.ExifTag.PhotometricInterpretation) | 262 | 0x0106 | [ExifEnumProperty\<PhotometricInterpretation>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(PhotometricInterpretation)](xref:ExifLibrary.PhotometricInterpretation)
[PlanarConfiguration](xref:ExifLibrary.ExifTag.PlanarConfiguration) | 284 | 0x011C | [ExifEnumProperty\<PlanarConfiguration>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(PlanarConfiguration)](xref:ExifLibrary.PlanarConfiguration)
[Predictor](xref:ExifLibrary.ExifTag.Predictor) | 317 | 0x013D | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[PrimaryChromaticities](xref:ExifLibrary.ExifTag.PrimaryChromaticities) | 319 | 0x013F | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[6]](xref:ExifLibrary.MathEx.UFraction32)
[ReferenceBlackWhite](xref:ExifLibrary.ExifTag.ReferenceBlackWhite) | 532 | 0x0214 | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[6]](xref:ExifLibrary.MathEx.UFraction32)
[ResolutionUnit](xref:ExifLibrary.ExifTag.ResolutionUnit) | 296 | 0x0128 | [ExifEnumProperty\<ResolutionUnit>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(ResolutionUnit)](xref:ExifLibrary.ResolutionUnit)
[RowsPerStrip](xref:ExifLibrary.ExifTag.RowsPerStrip) | 278 | 0x0116 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[SampleFormat](xref:ExifLibrary.ExifTag.SampleFormat) | 339 | 0x0153 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[SamplesPerPixel]
[SamplesPerPixel](xref:ExifLibrary.ExifTag.SamplesPerPixel) | 277 | 0x0115 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[SMaxSampleValue](xref:ExifLibrary.ExifTag.SMaxSampleValue) | 341 | 0x0155 | [Any] | Any[SamplesPerPixel]
[SMinSampleValue](xref:ExifLibrary.ExifTag.SMinSampleValue) | 340 | 0x0154 | [Any] | Any[SamplesPerPixel]
[Software](xref:ExifLibrary.ExifTag.Software) | 305 | 0x0131 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[StripByteCounts](xref:ExifLibrary.ExifTag.StripByteCounts) | 279 | 0x0117 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) or [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | ushort[] or uint[]
[StripOffsets](xref:ExifLibrary.ExifTag.StripOffsets) | 273 | 0x0111 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) or [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | ushort[] or uint[]
[SubfileType](xref:ExifLibrary.ExifTag.SubfileType) | 255 | 0x00FF | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[T4Options](xref:ExifLibrary.ExifTag.T4Options) | 292 | 0x0124 | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[T6Options](xref:ExifLibrary.ExifTag.T6Options) | 293 | 0x0125 | [ExifUInt](xref:ExifLibrary.ExifUInt) | uint
[TargetPrinter](xref:ExifLibrary.ExifTag.TargetPrinter) | 337 | 0x0151 | [ExifAscii](xref:ExifLibrary.ExifAscii) | string
[Threshholding](xref:ExifLibrary.ExifTag.Threshholding) | 263 | 0x0107 | [ExifUShort](xref:ExifLibrary.ExifUShort) | ushort
[TileByteCounts](xref:ExifLibrary.ExifTag.TileByteCounts) | 325 | 0x0145 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) or [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | ushort[TilesPerImage] or uint[TilesPerImage]
[TileLength](xref:ExifLibrary.ExifTag.TileLength) | 323 | 0x0143 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[TileOffsets](xref:ExifLibrary.ExifTag.TileOffsets) | 324 | 0x0144 | [ExifUIntArray](xref:ExifLibrary.ExifUIntArray) | uint[TilesPerImage]
[TileWidth](xref:ExifLibrary.ExifTag.TileWidth) | 322 | 0x0142 | [ExifUShort](xref:ExifLibrary.ExifUShort) or [ExifUInt](xref:ExifLibrary.ExifUInt) | ushort or uint
[TransferFunction](xref:ExifLibrary.ExifTag.TransferFunction) | 301 | 0x012D | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[3*256]
[TransferRange](xref:ExifLibrary.ExifTag.TransferRange) | 342 | 0x0156 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[6]
[WhitePoint](xref:ExifLibrary.ExifTag.WhitePoint) | 318 | 0x013E | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[2]](xref:ExifLibrary.MathEx.UFraction32)
[XPosition](xref:ExifLibrary.ExifTag.XPosition) | 286 | 0x011E | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[]](xref:ExifLibrary.MathEx.UFraction32)
[XResolution](xref:ExifLibrary.ExifTag.XResolution) | 282 | 0x011A | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
[YCbCrCoefficients](xref:ExifLibrary.ExifTag.YCbCrCoefficients) | 529 | 0x0211 | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[3]](xref:ExifLibrary.MathEx.UFraction32)
[YCbCrPositioning](xref:ExifLibrary.ExifTag.YCbCrPositioning) | 531 | 0x0213 | [ExifEnumProperty\<YCbCrPositioning>](xref:ExifLibrary.ExifEnumProperty`1) | enum [(YCbCrPositioning)](xref:ExifLibrary.YCbCrPositioning)
[YCbCrSubSampling](xref:ExifLibrary.ExifTag.YCbCrSubSampling) | 530 | 0x0212 | [ExifUShortArray](xref:ExifLibrary.ExifUShortArray) | ushort[2]
[YPosition](xref:ExifLibrary.ExifTag.YPosition) | 287 | 0x011F | [ExifURationalArray](xref:ExifLibrary.ExifURationalArray) | [MathEx.UFraction32[]](xref:ExifLibrary.MathEx.UFraction32)
[YResolution](xref:ExifLibrary.ExifTag.YResolution) | 283 | 0x011B | [ExifURational](xref:ExifLibrary.ExifURational) | [MathEx.UFraction32](xref:ExifLibrary.MathEx.UFraction32)
