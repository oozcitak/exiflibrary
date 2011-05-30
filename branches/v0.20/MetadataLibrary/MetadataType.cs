using System;

namespace MetadataLibrary
{
	/// <summary>
	/// Represents the type of metadata.
	/// </summary>
	public enum MetadataType
	{
		/// <summary>
		/// The data type is not recognized or it cannot be represented as a generic type.
		/// </summary>
		Unknown,
		/// <summary>
		/// A custom value type. See tag description for more information.
		/// </summary>
		Custom,
		/// <summary>
		/// An 8-bit unsigned integer.
		/// </summary>
		UByte,
		/// <summary>
		/// An 8-bit signed integer.
		/// </summary>
		SByte,
		/// <summary>
		/// An 16-bit unsigned integer.
		/// </summary>
		UShort,
		/// <summary>
		/// An 16-bit signed integer.
		/// </summary>
		SShort,
		/// <summary>
		/// An 32-bit unsigned integer.
		/// </summary>
		UInt,
		/// <summary>
		/// An 32-bit signed integer.
		/// </summary>
		SInt,
		/// <summary>
		/// An 64-bit unsigned integer.
		/// </summary>
		ULong,
		/// <summary>
		/// An 64-bit signed integer.
		/// </summary>
		SLong,
		/// <summary>
		/// An 32-bit floating-point value.
		/// </summary>
		Float,
		/// <summary>
		/// An 64-bit floating-point value.
		/// </summary>
		Double,
		/// <summary>
		/// A string of characters.
		/// </summary>
		String,
		/// <summary>
		/// A date time value. 
		/// </summary>
		DateTime,
		/// <summary>
		/// An enumarated value. See tag description for more information. 
		/// </summary>
		Enum
	}
}
