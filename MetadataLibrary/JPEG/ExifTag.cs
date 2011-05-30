using System;

namespace MetadataLibrary
{
	/// <summary>
	/// Identifies JPEG/Exif metadata.
	/// </summary>
	public class ExifTag : Tag
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="ifd">The IFD that contains this field.</param>
		/// <param name="id">The tag that identifies the field.</param>
		/// <param name="type">Field type.</param>
		/// <param name="readAs">The type or types to read the data as.</param>
		/// <param name="writeAs">The type to write the data as.</param>
		/// <param name="count">Count of values.</param>
		internal ExifTag (IFD ifd, ushort id, MetadataType type, ExifType readAs, ExifType writeAs, uint count)
		{
			IFD = ifd;
			ID = id;
			Type = type;
			ReadAsType = readAs;
			WriteAsType = writeAs;
			if (count == 0) {
				IsArray = false;
				IsVariable = false;
				Count = 0;
			} else {
				IsArray = true;
				IsVariable = false;
				Count = count;
			}
		}
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="ifd">The IFD that contains this field.</param>
		/// <param name="id">The tag that identifies the field.</param>
		/// <param name="type">Field type.</param>
		/// <param name="readAs">The type or types to read the data as.</param>
		/// <param name="writeAs">The type to write the data as.</param>
		/// <param name="variable">Count of values is variable.</param>
		internal ExifTag (IFD ifd, ushort id, MetadataType type, ExifType readAs, ExifType writeAs, bool variable)
		{
			IFD = ifd;
			ID = id;
			Type = type;
			ReadAsType = readAs;
			WriteAsType = writeAs;
			IsArray = true;
			IsVariable = true;
			Count = 0;
		}
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="ifd">The IFD that contains this field.</param>
		/// <param name="id">The tag that identifies the field.</param>
		/// <param name="type">Field type.</param>
		/// <param name="readAs">The type or types to read the data as.</param>
		/// <param name="writeAs">The type to write the data as.</param>
		internal ExifTag (IFD ifd, ushort id, MetadataType type, ExifType readAs, ExifType writeAs)
		{
			IFD = ifd;
			ID = id;
			Type = type;
			ReadAsType = readAs;
			WriteAsType = writeAs;
			IsArray = true;
			IsVariable = true;
			Count = 0;
		}
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="ifd">The IFD that contains this field.</param>
		/// <param name="id">The tag that identifies the field.</param>
		/// <param name="type">Field type.</param>
		/// <param name="readAndWriteAs">The type to read and write the data as.</param>
		/// <param name="count">Count of values.</param>
		internal ExifTag (IFD ifd, ushort id, MetadataType type, ExifType readAndWriteAs, uint count) : this(ifd, id, type, readAndWriteAs, readAndWriteAs, count)
		{
			;
		}
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="ifd">The IFD that contains this field.</param>
		/// <param name="id">The tag that identifies the field.</param>
		/// <param name="type">Field type.</param>
		/// <param name="readAndWriteAs">The type to read and write the data as.</param>
		/// <param name="variable">Count of values is variable.</param>
		internal ExifTag (IFD ifd, ushort id, MetadataType type, ExifType readAndWriteAs, bool variable) : this(ifd, id, type, readAndWriteAs, readAndWriteAs, variable)
		{
			;
		}
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="ifd">The IFD that contains this field.</param>
		/// <param name="id">The tag that identifies the field.</param>
		/// <param name="type">Field type.</param>
		/// <param name="readAndWriteAs">The type to read and write the data as.</param>
		internal ExifTag (IFD ifd, ushort id, MetadataType type, ExifType readAndWriteAs) : this(ifd, id, type, readAndWriteAs, readAndWriteAs)
		{
			;
		}
		#endregion

		#region Properties
		/// <summary>
		/// The IFD that contains this field.
		/// </summary>
		internal IFD IFD { get; set; }
		/// <summary>
		/// The tag that identifies the field.
		/// </summary>
		internal ushort ID { get; set; }
		/// <summary>
		/// The type or types to read the data as.
		/// </summary>
		internal ExifType ReadAsType { get; set; }
		/// <summary>
		/// The type to write the data as.
		/// </summary>
		internal ExifType WriteAsType { get; set; }
		/// <summary>
		/// Count of values.
		/// </summary>
		internal uint Count { get; set; }
		/// <summary>
		/// Count of values is variable.
		/// </summary>
		internal bool IsVariable { get; set; }
		#endregion
	}
}

