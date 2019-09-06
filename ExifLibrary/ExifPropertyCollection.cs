using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a collection of <see cref="ExifLibrary.ExifProperty"/> objects.
    /// </summary>
    public class ExifPropertyCollection : GenericPropertyCollection<ExifProperty>
    {

    }

    /// <summary>
    /// Represents a generic collection of <see cref="ExifLibrary.ExifProperty"/> objects.
    /// </summary>
    public class GenericPropertyCollection<T> : IList<T> where T : ExifProperty
    {
        #region Member Variables
        private List<T> items;
        #endregion

        #region Constructor
        internal GenericPropertyCollection()
        {
            items = new List<T>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public int Count
        {
            get { return items.Count; }
        }
        /// <summary>
        /// Gets or sets the <see cref="ExifLibrary.ExifProperty"/> with the specified index.
        /// </summary>
        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="ExifLibrary.ExifProperty"/> with the specified tag.
        /// Note that this method iterates through the entire collection to find an item with
        /// the given tag.
        /// </summary>
        public T this[ExifTag tag]
        {
            get { return Get<T>(tag); }
            set { Set(tag, value); }
        }
        #endregion

        #region ExifProperty Collection Adders
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, byte value)
        {
            items.Add(new ExifByte(key, value) as T);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, string value, Encoding encoding)
        {
            if (key == ExifTag.WindowsTitle || key == ExifTag.WindowsTitle || key == ExifTag.WindowsComment || key == ExifTag.WindowsAuthor || key == ExifTag.WindowsKeywords || key == ExifTag.WindowsSubject)
            {
                items.Add(new WindowsByteString(key, value) as T);
            }
            else if (key == ExifTag.UserComment)
            {
                items.Add(new ExifEncodedString(key, value, encoding) as T);
            }
            else
            {
                items.Add(new ExifAscii(key, value, encoding) as T);
            }
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, string value)
        {
            Add(key, value, Encoding.UTF8);
        }
        /// <summary>
        ///Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, ushort value)
        {
            items.Add(new ExifUShort(key, value) as T);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, int value)
        {
            items.Add(new ExifSInt(key, value) as T);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, uint value)
        {
            items.Add(new ExifUInt(key, value) as T);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, float value)
        {
            items.Add(new ExifURational(key, new MathEx.UFraction32(value)) as T);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, double value)
        {
            items.Add(new ExifURational(key, new MathEx.UFraction32(value)) as T);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, object value)
        {
            Type type = value.GetType();
            //if (type.IsEnum)
            //{
            Type etype = typeof(ExifEnumProperty<>).MakeGenericType(new Type[] { type });
            object prop = Activator.CreateInstance(etype, new object[] { key, value });
            items.Add((ExifProperty)prop as T);
            //}
            //else
            //    throw new ArgumentException("No exif property exists for this tag.", "value");
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, DateTime value)
        {
            items.Add(new ExifDateTime(key, value) as T);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="d">Angular degrees (or clock hours for a timestamp).</param>
        /// <param name="m">Angular minutes (or clock minutes for a timestamp).</param>
        /// <param name="s">Angular seconds (or clock seconds for a timestamp).</param>
        public void Add(ExifTag key, float d, float m, float s)
        {
            items.Add(new ExifURationalArray(key, new MathEx.UFraction32[] { new MathEx.UFraction32(d), new MathEx.UFraction32(m), new MathEx.UFraction32(s) }) as T);
        }
        #endregion

        #region ExifProperty Collection Getters
        /// <summary>
        /// Gets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that this method iterates through the entire collection to find
        /// and item with the given tag.
        /// </summary>
        /// <param name="key">The tag to get.</param>
        /// <returns>The item with the given tag cast to the specified 
        /// type. If the tag does not exist, or it cannot be cast to the
        /// given type it returns null.</returns>
        public T Get<T>(ExifTag key) where T : ExifProperty
        {
            foreach (var item in items)
            {
                if (item.Tag == key)
                {
                    return item as T;
                }
            }
            return null;
        }
        #endregion

        #region ExifProperty Collection Setters
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, byte value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, string value, Encoding encoding)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, string value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, ushort value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, int value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, uint value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, float value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, double value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, object value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, DateTime value)
        {
            Remove(key);
            Add(key, value);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="d">Angular degrees (or clock hours for a timestamp).</param>
        /// <param name="m">Angular minutes (or clock minutes for a timestamp).</param>
        /// <param name="s">Angular seconds (or clock seconds for a timestamp).</param>
        public void Set(ExifTag key, float d, float m, float s)
        {
            Remove(key);
            Add(key, d, m, s);
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Adds the specified item to the collection.
        /// </summary>
        /// <param name="item">The <see cref="ExifLibrary.ExifProperty"/> to add to the collection.</param>
        public void Add(T item)
        {
            items.Add(item);
        }
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }
        /// <summary>
        /// Determines whether the collection contains the given element.
        /// </summary>
        /// <param name="item">The item to locate in the collection.</param>
        /// <returns>
        /// true if the collection contains the given element; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="item"/> is null.</exception>
        public bool Contains(T item)
        {
            return items.Contains(item);
        }
        /// <summary>
        /// Determines whether the collection contains an element with the specified tag.
        /// Note that this method iterated through the entire collection to find an item
        /// with the given tag.
        /// </summary>
        /// <param name="tag">The tag to locate in the collection.</param>
        /// <returns>
        /// true if the collection contains an element with the tag; otherwise, false.
        /// </returns>
        public bool Contains(ExifTag tag)
        {
            foreach (var item in items)
            {
                if (item.Tag == tag) return true;
            }
            return false;
        }
        /// <summary>
        /// Removes the given element from the collection.
        /// </summary>
        /// <param name="ite">The element to remove.</param>
        /// <returns>
        /// true if the element is successfully removed; otherwise, false.  
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="item"/> is null.</exception>
        public bool Remove(T item)
        {
            return items.Remove(item);
        }
        /// <summary>
        /// Removes the item at the given index.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }
        /// <summary>
        /// Removes all items with the given IFD from the collection.
        /// </summary>
        /// <param name="ifd">The IFD section to remove.</param>
        public void Remove(IFD ifd)
        {
            List<T> toRemove = new List<T>();
            foreach (T item in items)
            {
                if (item.IFD == ifd)
                    toRemove.Add(item);
            }
            foreach (T tag in toRemove)
                items.Remove(tag);
        }
        /// <summary>
        /// Removes all items with the given tag from the collection.
        /// Note that this iterates through the entire collection to
        /// find the item with the given tag.
        /// </summary>
        /// <param name="ifd">The IFD section to remove.</param>
        public void Remove(ExifTag tag)
        {
            List<T> toRemove = new List<T>();
            foreach (T item in items)
            {
                if (item.Tag == tag)
                    toRemove.Add(item);
            }
            foreach (T item in toRemove)
                items.Remove(item);
        }
        /// <summary>
        /// Removes all items with the given tags from the collection.
        /// Note that this iterates through the entire collection to
        /// find the items with the given tags.
        /// </summary>
        /// <param name="ifd">The IFD section to remove.</param>
        public void Remove(IEnumerable<ExifTag> tags)
        {
            HashSet<ExifTag> tagSet = new HashSet<ExifTag>(tags);
            List<T> toRemove = new List<T>();
            foreach (T item in items)
            {
                if (tagSet.Contains(item.Tag))
                    toRemove.Add(item);
            }
            foreach (T item in toRemove)
                items.Remove(item);
        }
        /// <summary>
        /// Removes all tags from the collection except those in the 
        /// given whitelist.
        /// Note that this iterates through the entire collection to
        /// find the items with the given tags.
        /// </summary>
        /// <param name="ifd">The IFD section to remove.</param>
        public void Keep(IEnumerable<ExifTag> whiteList)
        {
            HashSet<ExifTag> tagSet = new HashSet<ExifTag>(whiteList);
            List<T> toRemove = new List<T>();
            foreach (T item in items)
            {
                if (!tagSet.Contains(item.Tag))
                    toRemove.Add(item);
            }
            foreach (T item in toRemove)
                items.Remove(item);
        }
        /// <summary>
        /// Returns the index of the given item.
        /// </summary>
        /// <param name="item">The item to look for in the collection.</param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }
        /// <summary>
        /// Returns an enumerator to iterate the collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        #endregion

        #region Hidden Interface
        void IList<T>.Insert(int index, T item)
        {
            items.Insert(index, item);
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
