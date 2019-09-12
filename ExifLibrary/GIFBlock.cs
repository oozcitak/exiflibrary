using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    #region Enums
    /// <summary>
    /// Represents a GIF block separator.
    /// </summary>
    public enum GIFSeparator : byte
    {
        /// <summary>
        /// Image descriptor
        /// </summary>
        ImageDescriptor = 0x2C,
        /// <summary>
        /// Extension block
        /// </summary>
        Extension = 0x21,
        /// <summary>
        /// Terminator block
        /// </summary>
        Terminator = 0x3B
    }

    /// <summary>
    /// Represents a GIF extension block label.
    /// </summary>
    public enum GIFExtensionLabel : byte
    {
        /// <summary>
        /// Graphic control extension
        /// </summary>
        GraphicControlExtension = 0xF9,
        /// <summary>
        /// Comment extension
        /// </summary>
        CommentExtension = 0xFE,
        /// <summary>
        /// Plain text extension
        /// </summary>
        PlainTextExtension = 0x01,
        /// <summary>
        /// Application extension
        /// </summary>
        ApplicationExtension = 0xFF
    }
    #endregion

    #region GIFBlock
    /// <summary>
    /// Represents a block of GIF data.
    /// </summary>
    public abstract class GIFBlock
    {
        #region Properties
        /// <summary>
        /// Gets the block separator.
        /// </summary>
        public GIFSeparator Separator { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFBlock"/> class.
        /// </summary>
        /// <param name="separator">Separator byte.</param>
        protected GIFBlock(byte separator)
        {
            Separator = (GIFSeparator)separator;
        }
        #endregion
    }

    /// <summary>
    /// Represents a GIF terminator block.
    /// </summary>
    public class GIFTerminator : GIFBlock
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFTerminator"/> class.
        /// </summary>
        public GIFTerminator() : base(0x3B)
        {

        }
        #endregion
    }

    /// <summary>
    /// Represents a GIF image descriptor.
    /// </summary>
    public class GIFImageDescriptor : GIFBlock
    {
        #region Properties
        /// <summary>
        /// Gets the left position of the image.
        /// </summary>
        public ushort Left { get; set; }
        /// <summary>
        /// Gets the top position of the image.
        /// </summary>
        public ushort Top { get; set; }
        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        public ushort Width { get; set; }
        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        public ushort Height { get; set; }

        /// <summary>
        /// Gets the reserved bits.
        /// </summary>
        public byte Reserved { get; set; }
        /// <summary>
        /// Gets the size of the local color table.
        /// </summary>
        public byte SizeOfLCT { get; set; }
        /// <summary>
        /// Gets whether the image contains a local color table.
        /// </summary>
        public bool HasLCT { get; set; }
        /// <summary>
        /// Gets whether the local color table is sorted.
        /// </summary>
        public bool IsLCTSorted { get; set; }
        /// <summary>
        /// Gets the local color table.
        /// </summary>
        public byte[,] LCT { get; set; }

        /// <summary>
        /// Gets whether the image is interlaced.
        /// </summary>
        public bool IsInterlaced { get; set; }

        /// <summary>
        /// Gets the initial number of bits used for LZW codes in the image data.
        /// </summary>
        public byte LZWMinimumCodeSize { get; set; }
        /// <summary>
        /// Gets the image table.
        /// </summary>
        public byte[][] ImageData { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFImageDescriptor"/> class.
        /// </summary>
        public GIFImageDescriptor() : base(0x2C)
        {
            LCT = new byte[0, 3];
            ImageData = new byte[0][] { };
        }
        #endregion
    }
    #endregion

    #region GIFExtensionBlock
    /// <summary>
    /// Represents a GIF graphic control extension.
    /// </summary>
    public class GIFExtensionBlock : GIFBlock
    {
        #region Properties
        /// <summary>
        /// Gets the extension label.
        /// </summary>
        public GIFExtensionLabel Label { get; set; }
        /// <summary>
        /// Gets the extension data.
        /// </summary>
        public byte[][] Data { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFExtensionBlock"/> class.
        /// </summary>
        /// <param name="label">Extension label</param>
        public GIFExtensionBlock(byte label) : base(0x21)
        {
            Label = (GIFExtensionLabel)label;
            Data = new byte[0][] { };
        }
        #endregion
    }

    /// <summary>
    /// Represents a GIF graphic control extension.
    /// </summary>
    public class GIFGraphicControlExtension : GIFExtensionBlock
    {
        #region Properties
        /// <summary>
        /// Gets the reserved bits.
        /// </summary>
        public byte Reserved { get; set; }
        /// <summary>
        /// Indicates the way in which the graphic is to be treated after being displayed.
        /// </summary>
        public byte DisposalMethod { get; set; }
        /// <summary>
        /// Indicates whether or not user input is expected before continuing.
        /// </summary>
        public bool UserInputFlag { get; set; }
        /// <summary>
        /// Indicates whether a transparency index is given in the Transparent Index field.
        /// </summary>
        public bool TransparentColorFlag { get; set; }

        /// <summary>
        /// Specifies the number of hundredths(1/100) of a second to wait before continuing with the 
        /// processing of the Data Stream.
        /// </summary>
        public ushort DelayTime { get; set; }
        /// <summary>
        /// The index of the transparent color.
        /// </summary>
        public byte TransparentColorIndex { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFGraphicControlExtension"/> class.
        /// </summary>
        public GIFGraphicControlExtension() : base(0xF9)
        {

        }
        #endregion
    }

    /// <summary>
    /// Represents comments about the graphics, credits, descriptions or any
    /// other type of non-control and non-graphic data.
    /// </summary>
    public class GIFCommentExtension : GIFExtensionBlock
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFImageDescriptor"/> class.
        /// </summary>
        public GIFCommentExtension() : base(0xFE)
        {

        }
        #endregion
    }

    /// <summary>
    /// Represents textual data and the parameters necessary to render that data as a 
    /// graphic, in a simple form.
    /// </summary>
    public class GIFPlainTextExtension : GIFExtensionBlock
    {
        #region Properties
        /// <summary>
        /// Gets the left position of the text.
        /// </summary>
        public ushort Left { get; set; }
        /// <summary>
        /// Gets the top position of the text.
        /// </summary>
        public ushort Top { get; set; }
        /// <summary>
        /// Gets the width of the text grid.
        /// </summary>
        public ushort Width { get; set; }
        /// <summary>
        /// Gets the height of the text grid.
        /// </summary>
        public ushort Height { get; set; }
        /// <summary>
        /// Gets the width of each cell in the grid.
        /// </summary>
        public byte CellWidth { get; set; }
        /// <summary>
        /// Gets the height of each cell in the grid.
        /// </summary>
        public byte CellHeight { get; set; }

        /// <summary>
        /// Gets the color index of the text foreground color.
        /// </summary>
        public byte ForegroundColorIndex { get; set; }
        /// <summary>
        /// Gets the color index of the text background color.
        /// </summary>
        public byte BackgroundColorIndex { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFPlainTextExtension"/> class.
        /// </summary>
        public GIFPlainTextExtension() : base(0x01)
        {

        }
        #endregion
    }

    /// <summary>
    /// Represents application-specific information.
    /// </summary>
    public class GIFApplicationExtension : GIFExtensionBlock
    {
        #region Properties
        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        public byte[] ApplicationIdentifier { get; set; }
        /// <summary>
        /// Gets the authentication code.
        /// </summary>
        public byte[] AuthenticationCode { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFApplicationExtension"/> class.
        /// </summary>
        public GIFApplicationExtension() : base(0xFF)
        {

        }
        #endregion
    }
    #endregion
}
