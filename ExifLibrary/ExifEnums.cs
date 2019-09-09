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
    /// Represents the compression scheme used for the image data. 
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
    /// Represents the unit for measuring XResolution and YResolution.
    /// </summary>
    public enum ResolutionUnit : ushort
    {
        /// <summary>
        /// Resolution is measured in inches.
        /// </summary>
        Inches = 2,
        /// <summary>
        /// Resolution is measured in centimeters.
        /// </summary>
        Centimeters = 3
    }

    /// <summary>
    /// Specifies the positioning of subsampled chrominance components 
    /// relative to luminance samples.
    /// </summary>
    public enum YCbCrPositioning : ushort
    {
        /// <summary>
        /// Centered.
        /// </summary>
        Centered = 1,
        /// <summary>
        /// Co-sited.
        /// </summary>
        CoSited = 2
    }

    /// <summary>
    /// Represents the color space specifier.
    /// </summary>
    public enum ColorSpace : ushort
    {
        /// <summary>
        /// The color space is sRGB.
        /// </summary>
        sRGB = 1,
        /// <summary>
        /// The color space is other than sRGB.
        /// </summary>
        Uncalibrated = 0xfff
    }

    /// <summary>
    /// Represents the program used by the camera to set exposure.
    /// </summary>
    public enum ExposureProgram : ushort
    {
        /// <summary>
        /// Exposure program is not defined.
        /// </summary>
        NotDefined = 0,
        /// <summary>
        /// Manual exposure.
        /// </summary>
        Manual = 1,
        /// <summary>
        /// Normal exposure program.
        /// </summary>
        Normal = 2,
        /// <summary>
        /// Aperture priority program.
        /// </summary>
        AperturePriority = 3,
        /// <summary>
        /// Shutter priority program.
        /// </summary>
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

    /// <summary>
    /// Represents the metering mode.
    /// </summary>
    public enum MeteringMode : ushort
    {
        /// <summary>
        /// Metering mode is unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Average metering mode.
        /// </summary>
        Average = 1,
        /// <summary>
        /// Center-weighted average metering mode.
        /// </summary>
        CenterWeightedAverage = 2,
        /// <summary>
        /// Spot metering mode.
        /// </summary>
        Spot = 3,
        /// <summary>
        /// Multi-spot metering mode.
        /// </summary>
        MultiSpot = 4,
        /// <summary>
        /// Pattern metering mode.
        /// </summary>
        Pattern = 5,
        /// <summary>
        /// Partial metering mode.
        /// </summary>
        Partial = 6,
        /// <summary>
        /// Other metering mode.
        /// </summary>
        Other = 255
    }

    /// <summary>
    /// Represents the type of light source.
    /// </summary>
    public enum LightSource : ushort
    {
        /// <summary>
        /// The type of light source is unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Daylight.
        /// </summary>
        Daylight = 1,
        /// <summary>
        /// Fluorescent light source.
        /// </summary>
        Fluorescent = 2,
        /// <summary>
        /// Tungsten light source.
        /// </summary>
        Tungsten = 3,
        /// <summary>
        /// Flash light source.
        /// </summary>
        Flash = 4,
        /// <summary>
        /// Fine weather light source.
        /// </summary>
        FineWeather = 9,
        /// <summary>
        /// Cloudy weather light source.
        /// </summary>
        CloudyWeather = 10,
        /// <summary>
        /// Shade light source.
        /// </summary>
        Shade = 11,
        /// <summary>
        /// Daylight fluorescent (D 5700 - 7100K)
        /// </summary>
        DaylightFluorescent = 12,
        /// <summary>
        /// Day white fluorescent (N 4600 - 5400K)
        /// </summary>
        DayWhiteFluorescent = 13,
        /// <summary>
        /// Cool white fluorescent (W 3900 - 4500K)
        /// </summary>
        CoolWhiteFluorescent = 14,
        /// <summary>
        /// White fluorescent (WW 3200 - 3700K)
        /// </summary>
        WhiteFluorescent = 15,
        /// <summary>
        /// Standard light A.
        /// </summary>
        StandardLightA = 17,
        /// <summary>
        /// Standard light B.
        /// </summary>
        StandardLightB = 18,
        /// <summary>
        /// Standard light C.
        /// </summary>
        StandardLightC = 19,
        /// <summary>
        /// D55.
        /// </summary>
        D55 = 20,
        /// <summary>
        /// D65.
        /// </summary>
        D65 = 21,
        /// <summary>
        /// D75.
        /// </summary>
        D75 = 22,
        /// <summary>
        /// D50.
        /// </summary>
        D50 = 23,
        /// <summary>
        /// Studio tungsten light source.
        /// </summary>
        ISOStudioTungsten = 24,
        /// <summary>
        /// Other light source.
        /// </summary>
        OtherLightSource = 255
    }

    /// <summary>
    /// Represents the status of the flash as a combination of the flags.
    /// </summary>
    [Flags]
    public enum Flash : ushort
    {
        /// <summary>
        /// Flash did not fire.
        /// </summary>
        FlashDidNotFire = 0,
        /// <summary>
        /// Flash fired.
        /// </summary>
        FlashFired = 1,
        /// <summary>
        /// Strobe return light was detected.
        /// </summary>
        StrobeReturnLightDetected = 2,
        /// <summary>
        /// Strobe return light was not detected.
        /// </summary>
        StrobeReturnLightNotDetected = 4,
        /// <summary>
        /// Compulsory flash mode.
        /// </summary>
        CompulsoryFlashMode = 8,
        /// <summary>
        /// Auto flash mode.
        /// </summary>
        AutoMode = 16,
        /// <summary>
        /// No flash function.
        /// </summary>
        NoFlashFunction = 32,
        /// <summary>
        /// Red eye reduction mode.
        /// </summary>
        RedEyeReductionMode = 64
    }

    /// <summary>
    /// Represents the type of image sensor.
    /// </summary>
    public enum SensingMethod : ushort
    {
        /// <summary>
        /// Image sensor type is not defined.
        /// </summary>
        NotDefined = 1,
        /// <summary>
        /// A one chip color area image sensor.
        /// </summary>
        OneChipColorAreaSensor = 2,
        /// <summary>
        /// A two chip color area image sensor.
        /// </summary>
        TwoChipColorAreaSensor = 3,
        /// <summary>
        /// A three chip color area image sensor.
        /// </summary>
        ThreeChipColorAreaSensor = 4,
        /// <summary>
        /// A color sequental area image sensor.
        /// </summary>
        ColorSequentialAreaSensor = 5,
        /// <summary>
        /// A tri-linear image sensor.
        /// </summary>
        TriLinearSensor = 7,
        /// <summary>
        /// A color sequental linear image sensor.
        /// </summary>
        ColorSequentialLinearSensor = 8
    }

    /// <summary>
    /// Represents the image source.
    /// </summary>
    public enum FileSource : byte
    {
        /// <summary>
        /// The image source is a DSC camera.
        /// </summary>
        DSC = 3
    }

    /// <summary>
    /// Represents the type of scene.
    /// </summary>
    public enum SceneType : byte
    {
        /// <summary>
        /// The image was directly photographed.
        /// </summary>
        DirectlyPhotographedImage = 1
    }

    /// <summary>
    /// Represents the use of special processing on image data.
    /// </summary>
    public enum CustomRendered : ushort
    {
        /// <summary>
        /// Normal process.
        /// </summary>
        NormalProcess = 0,
        /// <summary>
        /// Custom process.
        /// </summary>
        CustomProcess = 1
    }

    /// <summary>
    /// Represents the exposure mode.
    /// </summary>
    public enum ExposureMode : ushort
    {
        /// <summary>
        /// Auto exposure.
        /// </summary>
        Auto = 0,
        /// <summary>
        /// Manual exposure.
        /// </summary>
        Manual = 1,
        /// <summary>
        /// Auto bracket exposure.
        /// </summary>
        AutoBracket = 2
    }

    /// <summary>
    /// Represents the white balance mode.
    /// </summary>
    public enum WhiteBalance : ushort
    {
        /// <summary>
        /// Auto white balance.
        /// </summary>
        Auto = 0,
        /// <summary>
        /// Manual white balance.
        /// </summary>
        Manual = 1
    }

    /// <summary>
    /// Represents the scene capture type.
    /// </summary>
    public enum SceneCaptureType : ushort
    {
        /// <summary>
        /// Standard scene capture.
        /// </summary>
        Standard = 0,
        /// <summary>
        /// Lanscape scene capture.
        /// </summary>
        Landscape = 1,
        /// <summary>
        /// Portrait scene capture.
        /// </summary>
        Portrait = 2,
        /// <summary>
        /// Night scene capture.
        /// </summary>
        NightScene = 3
    }

    /// <summary>
    /// Represents the gain control.
    /// </summary>
    public enum GainControl : ushort
    {
        /// <summary>
        /// No gain control.
        /// </summary>
        None = 0,
        /// <summary>
        /// Low gain up.
        /// </summary>
        LowGainUp = 1,
        /// <summary>
        /// High gain up.
        /// </summary>
        HighGainUp = 2,
        /// <summary>
        /// Low gain down.
        /// </summary>
        LowGainDown = 3,
        /// <summary>
        /// High gain down.
        /// </summary>
        HighGainDown = 4
    }

    /// <summary>
    /// Represents the contrast setting.
    /// </summary>
    public enum Contrast : ushort
    {
        /// <summary>
        /// Normal contrast.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Soft contrast.
        /// </summary>
        Soft = 1,
        /// <summary>
        /// Hard contrast.
        /// </summary>
        Hard = 2
    }

    /// <summary>
    /// Represents the saturation setting.
    /// </summary>
    public enum Saturation : ushort
    {
        /// <summary>
        /// Normal saturation.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Low saturation.
        /// </summary>
        Low = 1,
        /// <summary>
        /// High saturation.
        /// </summary>
        High = 2
    }

    /// <summary>
    /// Represents the sharpness setting.
    /// </summary>
    public enum Sharpness : ushort
    {
        /// <summary>
        /// Normal sharpness.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Soft sharpness.
        /// </summary>
        Soft = 1,
        /// <summary>
        /// Hard sharpness.
        /// </summary>
        Hard = 2
    }

    /// <summary>
    /// Represents the range of subject distance.
    /// </summary>
    public enum SubjectDistanceRange : ushort
    {
        /// <summary>
        /// The range of subject distance is unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Macro setting.
        /// </summary>
        Macro = 1,
        /// <summary>
        /// Close view setting.
        /// </summary>
        CloseView = 2,
        /// <summary>
        /// Distant view setting.
        /// </summary>
        DistantView = 3
    }

    /// <summary>
    /// Indicates the GPS latitude reference relative to the equator.
    /// </summary>
    public enum GPSLatitudeRef : byte
    {
        /// <summary>
        /// Northern hemi-sphere.
        /// </summary>
        North = 78,
        /// <summary>
        /// Southern hemi-sphere.
        /// </summary>
        South = 83
    }

    /// <summary>
    /// Indicates the GPS longitude reference relative to the prime meridian.
    /// </summary>
    public enum GPSLongitudeRef : byte
    {
        /// <summary>
        /// West of prime meridian.
        /// </summary>
        West = 87,
        /// <summary>
        /// East of prime meridian.
        /// </summary>
        East = 69
    }

    /// <summary>
    /// Indicates the GPS longitude reference relative to the mean sea level.
    /// </summary>
    public enum GPSAltitudeRef : byte
    {
        /// <summary>
        /// Above the mean sea level.
        /// </summary>
        AboveSeaLevel = 0,
        /// <summary>
        /// Below the mean sea level.
        /// </summary>
        BelowSeaLevel = 1
    }

    /// <summary>
    /// Indicates the status of the GPS receiver.
    /// </summary>
    public enum GPSStatus : byte
    {
        /// <summary>
        /// Measurement is in progress
        /// </summary>
        MeasurementInProgress = 65,
        /// <summary>
        /// Measurement is in interoperability.
        /// </summary>
        MeasurementInteroperability = 86
    }

    /// <summary>
    /// Indicates the measurement mode of the GPS receiver.
    /// </summary>
    public enum GPSMeasureMode : byte
    {
        /// <summary>
        /// Measurement mode is two dimensional.
        /// </summary>
        TwoDimensional = 50,
        /// <summary>
        /// Measurement mode is three dimensional.
        /// </summary>
        ThreeDimensional = 51
    }

    /// <summary>
    /// Indicates the speed unit of the GPS receiver.
    /// </summary>
    public enum GPSSpeedRef : byte
    {
        /// <summary>
        /// Kilometers per hour.
        /// </summary>
        KilometersPerHour = 75,
        /// <summary>
        /// Miles per hour.
        /// </summary>
        MilesPerHour = 77,
        /// <summary>
        /// Knots (nautical miles per hour).
        /// </summary>
        Knots = 78
    }

    /// <summary>
    /// Indicates the direction mode of the GPS receiver.
    /// </summary>
    public enum GPSDirectionRef : byte
    {
        /// <summary>
        /// The direction is relative to true north.
        /// </summary>
        TrueDirection = 84,
        /// <summary>
        /// The direction is relative to magnetic north.
        /// </summary>
        MagneticDirection = 77
    }

    /// <summary>
    /// Indicates the distance unit of the GPS receiver.
    /// </summary>
    public enum GPSDistanceRef : byte
    {
        /// <summary>
        /// Kilometers.
        /// </summary>
        Kilometers = 75,
        /// <summary>
        /// Miles.
        /// </summary>
        Miles = 77,
        /// <summary>
        /// Knots (nautical miles).
        /// </summary>
        Knots = 78
    }

    /// <summary>
    /// Indicates the differential correction mode of the GPS receiver.
    /// </summary>
    public enum GPSDifferential : ushort
    {
        /// <summary>
        /// No differential correction.
        /// </summary>
        MeasurementWithoutDifferentialCorrection = 0,
        /// <summary>
        /// Differential correction was applied.
        /// </summary>
        DifferentialCorrectionApplied = 1
    }
}
