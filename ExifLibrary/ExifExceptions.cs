﻿using System;

namespace ExifLibrary
{
    /// <summary>
    /// The exception that is thrown when the 0th IFD section does not contain any fields.
    /// </summary>
    public class IFD0IsEmptyException : Exception
    {
        public IFD0IsEmptyException()
            : base("0th IFD section cannot be empty.")
        {
            ;
        }

        public IFD0IsEmptyException(string message)
            : base(message)
        {
            ;
        }
    }

    /// <summary>
    /// The exception that is thrown when the format of the JPEG/Exif file
    /// could not be understood.
    /// </summary>
    public class NotValidExifFileException : Exception
    {
        public NotValidExifFileException()
            : base("Not a valid JPEG/Exif file.")
        {
            ;
        }

        public NotValidExifFileException(string message)
            : base(message)
        {
            ;
        }
    }

    /// <summary>
    /// The exception that is thrown when the format of the GIF file
    /// could not be understood.
    /// </summary>
    public class NotValidGIFFileException : Exception
    {
        public NotValidGIFFileException()
            : base("Not a valid GIF file.")
        {
            ;
        }

        public NotValidGIFFileException(string message)
            : base(message)
        {
            ;
        }
    }

    /// <summary>
    /// The exception that is thrown when an invalid enum type is given to an
    /// ExifEnumProperty.
    /// </summary>
    public class UnknownEnumTypeException : Exception
    {
        public UnknownEnumTypeException()
            : base("Unknown enum type.")
        {
            ;
        }

        public UnknownEnumTypeException(string message)
            : base(message)
        {
            ;
        }
    }

    /// <summary>
    /// The exception that is thrown when the IFD section ID could not be understood.
    /// </summary>
    public class UnknownIFDSectionException : Exception
    {
        public UnknownIFDSectionException()
            : base("Unknown IFD section.")
        {
            ;
        }

        public UnknownIFDSectionException(string message)
            : base(message)
        {
            ;
        }
    }
}