using System;

namespace MetadataLibrary
{
	/// <summary>
	/// Identifies JPEG/JFIF metadata.
	/// </summary>
	public class JFIFTag : Tag
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="type">Field type.</param>
		/// <param name="readAs">The type or types to read and write the data as.</param>
		internal JFIFTag (MetadataType type, JFIFType jfifType)
		{
			Type = type;
			JFIFType = jfifType;
		}
		#endregion

		#region Properties
		/// <summary>
		/// The type or types to read and write the data as.
		/// </summary>
		internal JFIFType JFIFType { get; set; }
		#endregion
	}
}

