using System;

namespace MetadataLibrary
{
	/// <summary>
	/// Extended types for JFIF metadata tags.
	/// </summary>
	internal enum JFIFType
	{
		/// <summary>
		/// An 8-bit unsigned integer.
		/// </summary>
		Byte,
		/// <summary>
		/// An 8-bit byte containing one 7-bit ASCII code.
		/// </summary>
		ASCII,
		/// <summary>
		/// A 16-bit (2-byte) unsigned integer.
		/// </summary>
		Short,
	}
}
