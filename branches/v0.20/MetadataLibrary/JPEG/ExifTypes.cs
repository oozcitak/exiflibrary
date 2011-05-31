using System;

namespace MetadataLibrary
{
	/// <summary>
	/// Represents the page number and page count.
	/// </summary>
	public struct PageNumber
	{
		/// <summary>
		/// Get or sets the current page number.
		/// </summary>
		public ushort Current { get; set; }
		/// <summary>
		/// Gets or sets the total number of pages.
		/// </summary>
		public ushort Total { get; set; }

		/// <summary>
		/// Initializes a new instance of the struct.
		/// </summary>
		/// <param name="current">The current page number.</param>
		/// <param name="total">The total number of pages.</param>
		public PageNumber (ushort current, ushort total)
		{
			Current = current;
			Total = total;
		}		
	}
}

