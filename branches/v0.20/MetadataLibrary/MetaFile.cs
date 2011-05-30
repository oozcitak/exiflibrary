using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace MetadataLibrary
{
	/// <summary>
	/// Represents the base class for file formats 
	/// with metadata.
	/// </summary>
	public class MetaFile : IDictionary<Tag, object>, IEnumerable, ICollection<KeyValuePair<Tag, object>>, IEnumerable<KeyValuePair<Tag, object>>
	{
		#region Member Variables
		private Dictionary<Tag, object> tags;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		protected MetaFile ()
		{
			FileType = FileType.Unknown;
			tags = new Dictionary<Tag, object> ();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the number of elements contained in the collection.
		/// </summary>
		public int Count {
			get { return tags.Count; }
		}
		/// <summary>
		/// Gets a collection containing the keys in this collection.
		/// </summary>
		public ICollection<Tag> Keys {
			get { return tags.Keys; }
		}
		/// <summary>
		/// Gets or sets the metadata with the given tag.
		/// </summary>
		/// <param name="key">The name identifying the metadata.</param>
		public object this[Tag key] {
			get { return tags[key]; }
			set { tags[key] = value; }
		}
		/// <summary>
		/// Returns the file type.
		/// </summary>
		public FileType FileType { get; protected set; }
		/// <summary>
		/// Gets a collection containing the values in this collection.
		/// </summary>
		public ICollection<object> Values {
			get { return tags.Values; }
		}
		#endregion

		#region Instance Methods
		/// <summary>
		/// Adds the specified item to the collection.
		/// </summary>
		/// <param name="key">The tag identifying the metadata.</param>
		/// <param name="item">The metadata to add to the collection.</param>
		public void Add (Tag key, object value)
		{
			tags.Add (key, value);
		}
		/// <summary>
		/// Removes all items from the collection.
		/// </summary>
		public void Clear ()
		{
			tags.Clear ();
		}
		/// <summary>
		/// Determines whether the collection contains a metadata element with the specified tag.
		/// </summary>
		/// <param name="key">The tag to locate in the collection.</param>
		/// <returns>
		/// true if the collection contains an element with the key; otherwise, false.
		/// </returns>
		public bool ContainsKey (Tag key)
		{
			return tags.ContainsKey (key);
		}
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to
		/// iterate through the collection.
		/// </returns>
		public IEnumerator<KeyValuePair<Tag, object>> GetEnumerator ()
		{
			return tags.GetEnumerator ();
		}
		/// <summary>
		/// Removes the metadata element with the specified tag from the collection.
		/// </summary>
		/// <param name="key">The tag of the element to remove.</param>
		/// <returns>
		/// true if the element is successfully removed; otherwise, false.
		/// This method also returns false if <paramref name="key"/> was not found
		/// in the original collection.
		/// </returns>
		public bool Remove (Tag key)
		{
			return tags.Remove (key);
		}
		/// <summary>
		/// Gets the metadata associated with the specified tag.
		/// </summary>
		/// <param name="key">The tag whose value to get.</param>
		/// <param name="value">When this method returns, the value associated with the specified tag,
		/// if the key is found; otherwise, the default value for the type of the
		/// <paramref name="value"/> parameter. This parameter is passed uninitialized.</param>
		/// <returns>
		/// true if the collection contains an element with the specified key; otherwise, false.
		/// </returns>
		public bool TryGetValue (Tag key, out object value)
		{
			return tags.TryGetValue (key, out value);
		}
		#endregion

		#region Explicit Interface Members
		/// <summary>
		/// Adds an element with the provided key and value to the collection.
		/// </summary>
		/// <param name="item">The object to add to the collection.</param>
		void ICollection<KeyValuePair<Tag, object>>.Add (KeyValuePair<Tag, object> item)
		{
			Add (item.Key, item.Value);
		}
		/// <summary>
		/// Determines if the collection contains the given item.
		/// </summary>
		/// <param name="item">The object to search for in the collection.</param>
		/// <returns>
		/// true if <paramref name="item"/> was found; otherwise, false.
		/// </returns>
		bool ICollection<KeyValuePair<Tag, object>>.Contains (KeyValuePair<Tag, object> item)
		{
			throw new NotImplementedException ();
		}
		/// <summary>
		/// Copies the elements of the collection to an <see cref="T:System.Array"/>, 
		/// starting at a particular index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array"/> 
		/// that is the destination of the elements copied from ther collection.</param>
		/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at 
		/// which copying begins.</param>
		void ICollection<KeyValuePair<Tag, object>>.CopyTo (KeyValuePair<Tag, object>[] array, int arrayIndex)
		{
			throw new NotImplementedException ();
		}
		/// <summary>
		/// Removes the first occurrence of a specific object from the collection.
		/// </summary>
		/// <param name="item">The object to remove from the collection.</param>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the collection;
		/// otherwise, false. This method also returns false if <paramref name="item"/> is not 
		/// found in the original collection.
		/// </returns>
		bool ICollection<KeyValuePair<Tag, object>>.Remove (KeyValuePair<Tag, object> item)
		{
			throw new NotImplementedException ();
		}
		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An enumerator that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}
		/// <summary>
		/// Gets a value indicating whether the collection is read-only.
		/// </summary>
		/// <returns>true if the collection is read-only; otherwise, false.</returns>
		bool ICollection<KeyValuePair<Tag, object>>.IsReadOnly {
			get { return false; }
		}
		#endregion
	}
}

