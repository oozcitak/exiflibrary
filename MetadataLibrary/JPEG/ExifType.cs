using System;

namespace MetadataLibrary
{
	/// <summary>
	/// Extended types for Exif metadata tags.
	/// </summary>
	[Flags]
	internal enum ExifType : ushort
	{
		/// <summary>
		/// 1 = BYTE An 8-bit unsigned integer.
		/// </summary>
		Byte = 1,
		/// <summary>
		/// 2 = ASCII An 8-bit byte containing one 7-bit ASCII code.
		/// </summary>
		ASCII = 2,
		/// <summary>
		/// 3 = SHORT A 16-bit (2-byte) unsigned integer.
		/// </summary>
		Short = 4,
		/// <summary>
		/// 4 = LONG A 32-bit (4-byte) unsigned integer.
		/// </summary>
		Long = 8,
		/// <summary>
		/// 5 = RATIONAL Two LONGs. The first LONG is the numerator
		/// and the second LONG expresses the denominator.
		/// </summary>
		Rational = 16,
		/// <summary>
		/// 6 = BYTE An 8-bit unsigned integer.
		/// </summary>
		SByte = 32,
		/// <summary>
		/// 7 = UNDEFINED An 8-bit byte that can take any value depending on the field definition.
		/// </summary>
		Undefined = 64,
		/// <summary>
		/// 8 = SSHORT A 16-bit (2-byte) signed integer.
		/// </summary>
		SShort = 128,
		/// <summary>
		/// 9 = SLONG A 32-bit (4-byte) signed integer (2's complement notation). 
		/// </summary>
		SLong = 256,
		/// <summary>
		/// 10 = SRATIONAL Two SLONGs. The first SLONG is the numerator 
		/// and the second SLONG is the denominator. 
		/// </summary>
		SRational = 512,
		/// <summary>
		/// 11 = FLOAT An 32-bit single-precision floating-point number. 
		/// </summary>
		Float = 1024,
		/// <summary>
		/// 12 = DOUBLE An 64-bit double-precision floating-point number. 
		/// </summary>
		Double = 2048
	}
}
