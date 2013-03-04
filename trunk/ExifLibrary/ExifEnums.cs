using System;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a general indication of the kind of data contained in this subfile.
    /// </summary>
    [Flags]
    public enum NewSubfileType : uint
    {
        /// <summary>
        /// This image is a reduced resolution version of another image in the file.
        /// </summary>
        ReducedResolution = 1,
        /// <summary>
        /// The image is a single page of a multi-page image.
        /// </summary>
        MultiPage = 2,
        /// <summary>
        /// This image defines a transparency mask for another image in this file.
        /// </summary>
        TransparencyMask = 4,
        /// <summary>
        /// The IFD containing this tag is Mixed Raster Content (MRC) specific.
        /// </summary>
        MRCSpecific = 16
    }

    /// <summary>
    /// Represents a general indication of the kind of data contained in this subfile.
    /// </summary>
    public enum SubfileType : ushort
    {
        /// <summary>
        /// This image is a full resolution image.
        /// </summary>
        FullResolution = 1,
        /// <summary>
        /// This image is a reduced resolution version of another image in the file.
        /// </summary>
        ReducedResolution = 2,
        /// <summary>
        /// The image is a single page of a multi-page image.
        /// </summary>
        MultiPage = 3
    }

    /// <summary>
    /// Represenst the compression scheme used for the image data. 
    /// </summary>
    public enum Compression : ushort
    {
        /// <summary>
        /// No compression.
        /// </summary>
        Uncompressed = 1,
        /// <summary>
        /// CCITT modified Huffman RLE compression.
        /// </summary>
        CCITT1D = 2,
        /// <summary>
        /// CCITT Group 3 fax encoding.
        /// </summary>
        Group3Fax = 3,
        /// <summary>
        /// CCITT Group 4 fax encoding.
        /// </summary>
        Group4Fax = 4,
        /// <summary>
        /// LZW compression.
        /// </summary>
        LZW = 5,
        /// <summary>
        /// JPEG compression.
        /// </summary>
        JPEG = 6,
        /// <summary>
        /// PackBits compression, aka Macintosh RLE.
        /// </summary>
        PackBits = 32773
    }

    /// <summary>
    /// Represents the pixel composition.
    /// </summary>
    public enum PhotometricInterpretation : ushort
    {
        /// <summary>
        /// For bilevel and grayscale images: 0 is imaged as white.
        /// </summary>
        WhiteIsZero = 0,
        /// <summary>
        /// For bilevel and grayscale images: 0 is imaged as black.
        /// </summary>
        BlackIsZero = 1,
        /// <summary>
        /// RGB value of (0,0,0) represents black, and (255,255,255) represents white, 
        /// assuming 8-bit components. The components are stored in the indicated order: 
        /// first Red, then Green, then Blue.
        /// </summary>
        RGB = 2,
        /// <summary>
        /// Palette color. In this model, a color is described with a single component. 
        /// The value of the component is used as an index into the red, green and blue 
        /// curves in the ColorMap field to retrieve an RGB triplet that defines the color. 
        /// With a palette, ColorMap must be present and SamplesPerPixel must be 1.
        /// </summary>
        RGBPalette = 3,
        /// <summary>
        /// The image is used to define an irregularly shaped region of another image 
        /// in the same file. SamplesPerPixel and BitsPerSample must be 1. 
        /// PackBits compression is recommended. The 1-bits define the interior
        /// of the region; the 0-bits define the exterior of the region.
        /// </summary>
        TransparencyMask = 4,
        /// <summary>
        /// Seperated, usually CMYK.
        /// </summary>
        Seperated = 5,
        /// <summary>
        /// YCbCr color space.
        /// </summary>
        YCbCr = 6,
        /// <summary>
        /// CIE (L*, a*, b*) color space.
        /// </summary>
        CIELab = 8,
        /// <summary>
        /// ICC (L*, a*, b*) color space.
        /// </summary>
        ICCLab = 9,
        /// <summary>
        /// ITU (L*, a*, b*) color space.
        /// </summary>
        ITULab = 10,
        /// <summary>
        /// Color Filter Array color space.
        /// </summary>
        CFA = 32803,
        /// <summary>
        /// Linear Raw color space.
        /// </summary>
        LinearRaw = 34892,
        /// <summary>
        /// Pixar LogL color space.
        /// </summary>
        Pixar_LOGL = 32844,
        /// <summary>
        /// Pixar LogLUV color space.
        /// </summary>
        PixarLOGLUV = 32845
    }

    /// <summary>
    /// Represents the technique used to convert from gray to black and white pixels.
    /// </summary>
    public enum Threshholding : ushort
    {
        /// <summary>
        /// No dithering or halftoning has been applied to the image data.
        /// </summary>
        BiLevel = 1,
        /// <summary>
        /// An ordered dither or halftone technique has been applied to the image data.
        /// </summary>
        HalfTone = 2,
        /// <summary>
        /// A randomized process such as error diffusion has been applied to the image data.
        /// </summary>
        ErrorDiffuse = 3
    }

    /// <summary>
    /// Represents the logical order of bits within a byte.
    /// </summary>
    public enum FillOrder : ushort
    {
        /// <summary>
        /// Pixels with lower column values are stored in the higher-order bits of the byte.
        /// </summary>
        MSB2LSB = 1,
        /// <summary>
        /// Pixels with lower column values are stored in the lower-order bits of the byte.
        /// </summary>
        LSB2MSB = 2
    }

    /// <summary>
    /// Represents the image orientation.
    /// </summary>
    public enum Orientation : ushort
    {
        /// <summary>
        /// The 0th row is at the visual top of the image, and the 0th column is the
        /// visual left-hand side.
        /// </summary>
        Normal = 1,
        /// <summary>
        /// The 0th row is at the visual top of the image, and the 0th column is
        /// the visual right-hand side.
        /// </summary>
        MirroredVertically = 2,
        /// <summary>
        /// The 0th row is at the visual bottom of the image, and the 0th column is
        /// the visual right-hand side.
        /// </summary>
        Rotated180 = 3,
        /// <summary>
        /// The 0th row is at the visual bottom of the image, and the 0th column is
        /// the visual left-hand side.
        /// </summary>
        MirroredHorizontally = 4,
        /// <summary>
        /// The 0th row is the visual left-hand side of the image, and the 0th column
        /// is the visual top.
        /// </summary>
        RotatedLeftAndMirroredVertically = 5,
        /// <summary>
        /// The 0th row is the visual right-hand side of the image, and the 0th column
        /// is the visual top.
        /// </summary>
        RotatedRight = 6,
        /// <summary>
        /// The 0th row is the visual right-hand side of the image, and the 0th column
        /// is the visual bottom.
        /// </summary>
        RotatedLeft = 7,
        /// <summary>
        /// The 0th row is the visual left-hand side of the image, and the 0th column
        /// is the visual bottom.
        /// </summary>
        RotatedRightAndMirroredVertically = 8
    }

    /// <summary>
    /// Represents the recording format of pixel components.
    /// </summary>
    public enum PlanarConfiguration : ushort
    {
        /// <summary>
        /// Pixels are recorded in chunky format.
        /// </summary>
        ChunkyFormat = 1,
        /// <summary>
        /// Pixels are recorded in planar format.
        /// </summary>
        PlanarFormat = 2
    }

    /// <summary>
    /// Represents the precision of the information contained in the gray response curve.
    /// </summary>
    public enum GrayResponseUnit : ushort
    {
        /// <summary>
        /// Number represents tenths of a unit.
        /// </summary>
        Tenth = 1,
        /// <summary>
        /// Number represents hundredths of a unit.
        /// </summary>
        Hundreth = 2,
        /// <summary>
        /// Number represents thousandths of a unit.
        /// </summary>
        Thousandth = 3,
        /// <summary>
        /// Number represents ten-thousandths of a unit.
        /// </summary>
        TenThousandth = 4,
        /// <summary>
        /// Number represents hundred-thousandths of a unit.
        /// </summary>
        HundredThousandth = 5
    }

    /// <summary>
    /// Represents the options for Group 3 Fax compression.
    /// </summary>
    [Flags]
    public enum T4Options : uint
    {
        /// <summary>
        /// 2-dimensional coding (otherwise 1-dimensional is assumed).
        /// </summary>
        TwoDimensionalEncoding = 1,
        /// <summary>
        /// Uncompressed mode is used.
        /// </summary>
        Uncompressed = 2,
        /// <summary>
        /// Fill bits have been added before EOL codes such that EOL always
        /// ends on a byte boundary.
        /// </summary>
        FillBits = 4
    }

    /// <summary>
    /// Represents the options for Group 4 Fax compression.
    /// </summary>
    [Flags]
    public enum T6Options : uint
    {
        /// <summary>
        /// Uncompressed mode is used.
        /// </summary>
        Uncompressed = 2
    }

    /// <summary>
    /// The unit for measuring XResolution and YResolution.
    /// </summary>
    public enum ResolutionUnit : ushort
    {
        Inches = 2,
        Centimeters = 3
    }

    public enum YCbCrPositioning : ushort
    {
        Centered = 1,
        CoSited = 2
    }



    public enum ColorSpace : ushort
    {
        sRGB = 1,
        Uncalibrated = 0xfff
    }

    public enum ExposureProgram : ushort
    {
        NotDefined = 0,
        Manual = 1,
        Normal = 2,
        AperturePriority = 3,
        ShutterPriority = 4,
        /// <summary>
        /// Biased toward depth of field.
        /// </summary>
        Creative = 5,
        /// <summary>
        /// Biased toward fast shutter speed.
        /// </summary>
        Action = 6,
        /// <summary>
        /// For closeup photos with the background out of focus.
        /// </summary>
        Portrait = 7,
        /// <summary>
        /// For landscape photos with the background in focus.
        /// </summary>
        Landscape = 8
    }

    public enum MeteringMode : ushort
    {
        Unknown = 0,
        Average = 1,
        CenterWeightedAverage = 2,
        Spot = 3,
        MultiSpot = 4,
        Pattern = 5,
        Partial = 6,
        Other = 255
    }

    public enum LightSource : ushort
    {
        Unknown = 0,
        Daylight = 1,
        Fluorescent = 2,
        Tungsten = 3,
        Flash = 4,
        FineWeather = 9,
        CloudyWeather = 10,
        Shade = 11,
        /// <summary>
        /// D 5700 â€“ 7100K
        /// </summary>
        DaylightFluorescent = 12,
        /// <summary>
        /// N 4600 â€“ 5400K
        /// </summary>
        DayWhiteFluorescent = 13,
        /// <summary>
        /// W 3900 â€“ 4500K
        /// </summary>
        CoolWhiteFluorescent = 14,
        /// <summary>
        /// WW 3200 â€“ 3700K
        /// </summary>
        WhiteFluorescent = 15,
        StandardLightA = 17,
        StandardLightB = 18,
        StandardLightC = 19,
        D55 = 20,
        D65 = 21,
        D75 = 22,
        D50 = 23,
        ISOStudioTungsten = 24,
        OtherLightSource = 255
    }

    [Flags]
    public enum Flash : ushort
    {
        FlashDidNotFire = 0,
        StrobeReturnLightNotDetected = 4,
        StrobeReturnLightDetected = 2,
        FlashFired = 1,
        CompulsoryFlashMode = 8,
        AutoMode = 16,
        NoFlashFunction = 32,
        RedEyeReductionMode = 64
    }

    public enum SensingMethod : ushort
    {
        NotDefined = 1,
        OneChipColorAreaSensor = 2,
        TwoChipColorAreaSensor = 3,
        ThreeChipColorAreaSensor = 4,
        ColorSequentialAreaSensor = 5,
        TriLinearSensor = 7,
        ColorSequentialLinearSensor = 8
    }

    public enum FileSource : byte
    {
        // UNDEFINED
        DSC = 3
    }

    public enum SceneType : byte
    {
        // UNDEFINED
        DirectlyPhotographedImage = 1
    }

    public enum CustomRendered : ushort
    {
        NormalProcess = 0,
        CustomProcess = 1
    }

    public enum ExposureMode : ushort
    {
        Auto = 0,
        Manual = 1,
        AutoBracket = 2
    }

    public enum WhiteBalance : ushort
    {
        Auto = 0,
        Manual = 1
    }

    public enum SceneCaptureType : ushort
    {
        Standard = 0,
        Landscape = 1,
        Portrait = 2,
        NightScene = 3
    }

    public enum GainControl : ushort
    {
        None = 0,
        LowGainUp = 1,
        HighGainUp = 2,
        LowGainDown = 3,
        HighGainDown = 4
    }

    public enum Contrast : ushort
    {
        Normal = 0,
        Soft = 1,
        Hard = 2
    }

    public enum Saturation : ushort
    {
        Normal = 0,
        Low = 1,
        High = 2
    }

    public enum Sharpness : ushort
    {
        Normal = 0,
        Soft = 1,
        Hard = 2
    }

    public enum SubjectDistanceRange : ushort
    {
        Unknown = 0,
        Macro = 1,
        CloseView = 2,
        DistantView = 3
    }

    public enum GPSLatitudeRef : byte
    {
        // ASCII
        North = 78,
        // 'N'
        South = 83
        // 'S'
    }

    public enum GPSLongitudeRef : byte
    {
        // ASCII
        West = 87,
        // 'W'
        East = 69
        // 'E'
    }

    public enum GPSAltitudeRef : byte
    {
        AboveSeaLevel = 0,
        BelowSeaLevel = 1
    }

    public enum GPSStatus : byte
    {
        // ASCII
        MeasurementInProgress = 65,
        // 'A'
        MeasurementInteroperability = 86
        // 'V'
    }

    public enum GPSMeasureMode : byte
    {
        // ASCII
        TwoDimensional = 50,
        // '2'
        ThreeDimensional = 51
        // '3'
    }

    public enum GPSSpeedRef : byte
    {
        // ASCII
        KilometersPerHour = 75,
        // 'K'
        MilesPerHour = 77,
        // 'M'
        Knots = 78
        // 'N'
    }

    public enum GPSDirectionRef : byte
    {
        // ASCII
        TrueDirection = 84,
        // 'T'
        MagneticDirection = 77
        // 'M'
    }

    public enum GPSDistanceRef : byte
    {
        // ASCII
        Kilometers = 75,
        // 'K'
        Miles = 77,
        // 'M'
        Knots = 78
        // 'N'
    }

    public enum GPSDifferential : ushort
    {
        MeasurementWithoutDifferentialCorrection = 0,
        DifferentialCorrectionApplied = 1
    }
}
