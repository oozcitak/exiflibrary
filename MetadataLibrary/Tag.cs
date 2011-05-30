using System;

namespace MetadataLibrary
{
	/// <summary>
	/// Identifies metadata and describes how to read and write metadata.
	/// </summary>
	public class Tag
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="type">Type of metadata.</param>
		/// <param name="isArray">Whether the metadata is an array of values.</param>
		internal Tag (MetadataType type, bool isArray)
		{
			Type = type;
			IsArray = isArray;
		}
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="type">Type of metadata.</param>
		internal Tag (MetadataType type) : this(type, false)
		{
			;
		}
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		internal Tag () : this(MetadataType.Unknown)
		{
			;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the type of metadata.
		/// </summary>
		public MetadataType Type { get; protected set; }
		/// <summary>
		/// Gets whether the metadata is an array of values.
		/// </summary>
		public bool IsArray { get; protected set; }
		#endregion
	}
}

