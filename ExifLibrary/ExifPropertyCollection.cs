using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a collection of <see cref="ExifLibrary.ExifProperty"/> objects.
    /// </summary>
    public class ExifPropertyCollection : IList<ExifProperty>
    {
        #region Member Variables
        private List<ExifProperty> items;
        #endregion

        #region Constructor
        internal ExifPropertyCollection()
        {
            items = new List<ExifProperty>();
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
        public ExifProperty this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }
        #endregion

        #region ExifProperty Collection Setters
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, byte value)
        {
            items.Add(new ExifByte(key, value));
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, string value, Encoding encoding)
        {
            if (key == ExifTag.WindowsTitle || key == ExifTag.WindowsTitle || key == ExifTag.WindowsComment || key == ExifTag.WindowsAuthor || key == ExifTag.WindowsKeywords || key == ExifTag.WindowsSubject)
            {
                items.Add(new WindowsByteString(key, value));
            }
            else if (key == ExifTag.UserComment)
            {
                items.Add(new ExifEncodedString(key, value, encoding));
            }
            else
            {
                items.Add(new ExifAscii(key, value, encoding));
            }
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, string value)
        {
            Add(key, value, Encoding.Default);
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, ushort value)
        {
            items.Add(new ExifUShort(key, value));
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, int value)
        {
            items.Add(new ExifSInt(key, value));
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, uint value)
        {
            items.Add(new ExifUInt(key, value));
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, float value)
        {
            items.Add(new ExifURational(key, new MathEx.UFraction32(value)));
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, double value)
        {
            items.Add(new ExifURational(key, new MathEx.UFraction32(value)));
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, object value)
        {
            Type type = value.GetType();
            if (type.IsEnum)
            {
                Type etype = typeof(ExifEnumProperty<>).MakeGenericType(new Type[] { type });
                object prop = Activator.CreateInstance(etype, new object[] { key, value });
                items.Add((ExifProperty)prop);
            }
            else
                throw new ArgumentException("No exif property exists for this tag.", "value");
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, DateTime value)
        {
            items.Add(new ExifDateTime(key, value));
        }
        /// <summary>
        /// Sets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="d">Angular degrees (or clock hours for a timestamp).</param>
        /// <param name="m">Angular minutes (or clock minutes for a timestamp).</param>
        /// <param name="s">Angular seconds (or clock seconds for a timestamp).</param>
        public void Add(ExifTag key, float d, float m, float s)
        {
            items.Add(new ExifURationalArray(key, new MathEx.UFraction32[] { new MathEx.UFraction32(d), new MathEx.UFraction32(m), new MathEx.UFraction32(s) }));
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Adds the specified item to the collection.
        /// </summary>
        /// <param name="item">The <see cref="ExifLibrary.ExifProperty"/> to add to the collection.</param>
        public void Add(ExifProperty item)
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
        /// Determines whether the collection contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the collection.</param>
        /// <returns>
        /// true if the collection contains an element with the key; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="key"/> is null.</exception>
        public bool Contains(ExifProperty key)
        {
            return items.Contains(key);
        }
        /// <summary>
        /// Removes the element with the specified key from the collection.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>
        /// true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name="key"/> was not found in the original collection.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="key"/> is null.</exception>
        public bool Remove(ExifProperty key)
        {
            return items.Remove(key);
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
            List<ExifProperty> toRemove = new List<ExifProperty>();
            foreach (ExifProperty item in items)
            {
                if (item.IFD == ifd)
                    toRemove.Add(item);
            }
            foreach (ExifProperty tag in toRemove)
                items.Remove(tag);
        }
        /// <summary>
        /// Returns the index of the given item.
        /// </summary>
        /// <param name="item">The item to look for in the collection.</param>
        /// <returns></returns>
        public int IndexOf(ExifProperty item)
        {
            return items.IndexOf(item);
        }
        /// <summary>
        /// Returns an enumerator to iterate the collection.
        /// </summary>
        public IEnumerator<ExifProperty> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        #endregion

        #region Hidden Interface
        void IList<ExifProperty>.Insert(int index, ExifProperty item)
        {
            items.Insert(index, item);
        }

        void ICollection<ExifProperty>.CopyTo(ExifProperty[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        bool ICollection<ExifProperty>.IsReadOnly
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
