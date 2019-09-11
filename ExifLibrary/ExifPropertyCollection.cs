using System;
using System.Collections.Generic;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a collection of <see cref="ExifLibrary.ExifProperty"/> objects.
    /// </summary>
    public class ExifPropertyCollection<T> : IList<T> where T : ExifProperty
    {
        #region Member Variables
        private List<T> items;
        private Dictionary<ExifTag, List<T>> lookup;
        #endregion

        #region Constructor
        internal ExifPropertyCollection()
        {
            items = new List<T>();
            lookup = new Dictionary<ExifTag, List<T>>();
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
        /// Adds an <see cref="ExifLibrary.ExifProperty"/>.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            AddItem(item);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, byte value)
        {
            AddItem(new ExifByte(key, value));
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, string value, Encoding encoding)
        {
            if (key == ExifTag.WindowsTitle || key == ExifTag.WindowsComment || key == ExifTag.WindowsAuthor || key == ExifTag.WindowsKeywords || key == ExifTag.WindowsSubject)
            {
                AddItem(new WindowsByteString(key, value));
            }
            else if (key == ExifTag.UserComment)
            {
                AddItem(new ExifEncodedString(key, value, encoding));
            }
            else
            {
                AddItem(new ExifAscii(key, value, encoding));
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
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, ushort value)
        {
            AddItem(new ExifUShort(key, value));
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, int value)
        {
            AddItem(new ExifSInt(key, value));
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, uint value)
        {
            AddItem(new ExifUInt(key, value));
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, float value)
        {
            AddItem(new ExifURational(key, new MathEx.UFraction32(value)));
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, double value)
        {
            AddItem(new ExifURational(key, new MathEx.UFraction32(value)));
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, object value)
        {
            Type type = value.GetType();
            Type etype = typeof(ExifEnumProperty<>).MakeGenericType(new Type[] { type });
            object prop = Activator.CreateInstance(etype, new object[] { key, value });
            AddItem((ExifProperty)prop);
        }
        /// <summary>
        /// Adds an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Add(ExifTag key, DateTime value)
        {
            AddItem(new ExifDateTime(key, value));
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
            AddItem(new ExifURationalArray(key, new MathEx.UFraction32[] { new MathEx.UFraction32(d), new MathEx.UFraction32(m), new MathEx.UFraction32(s) }));
        }
        #endregion

        #region ExifProperty Collection Getters
        /// <summary>
        /// Gets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to get.</param>
        /// <returns>The item with the given tag cast to the specified 
        /// type. If the tag does not exist, or it cannot be cast to the
        /// given type it returns null.</returns>
        public U Get<U>(ExifTag key) where U : ExifProperty
        {
            return GetItem(key) as U;
        }
        /// <summary>
        /// Gets the <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// </summary>
        /// <param name="key">The tag to get.</param>
        /// <returns>The item with the given tag cast to the specified 
        /// type. If the tag does not exist, or it cannot be cast to the
        /// given type it returns null.</returns>
        public ExifProperty Get(ExifTag key)
        {
            return GetItem(key);
        }
        #endregion

        #region ExifProperty Collection Setters
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="item">The item to set.</param>
        public void Set(T item)
        {
            SetItem(item);
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, byte value)
        {
            SetItem(new ExifByte(key, value));
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, string value, Encoding encoding)
        {
            if (key == ExifTag.WindowsTitle || key == ExifTag.WindowsComment || key == ExifTag.WindowsAuthor || key == ExifTag.WindowsKeywords || key == ExifTag.WindowsSubject)
            {
                SetItem(new WindowsByteString(key, value));
            }
            else if (key == ExifTag.UserComment)
            {
                SetItem(new ExifEncodedString(key, value, encoding));
            }
            else
            {
                SetItem(new ExifAscii(key, value, encoding));
            }
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, string value)
        {
            Add(key, value, Encoding.UTF8);
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, ushort value)
        {
            SetItem(new ExifUShort(key, value));
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, int value)
        {
            SetItem(new ExifSInt(key, value));
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, uint value)
        {
            SetItem(new ExifUInt(key, value));
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, float value)
        {
            SetItem(new ExifURational(key, new MathEx.UFraction32(value)));
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, double value)
        {
            SetItem(new ExifURational(key, new MathEx.UFraction32(value)));
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, object value)
        {
            Type type = value.GetType();
            Type etype = typeof(ExifEnumProperty<>).MakeGenericType(new Type[] { type });
            object prop = Activator.CreateInstance(etype, new object[] { key, value });
            SetItem((ExifProperty)prop);
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="value">The value of tag.</param>
        public void Set(ExifTag key, DateTime value)
        {
            SetItem(new ExifDateTime(key, value));
        }
        /// <summary>
        /// Sets an <see cref="ExifLibrary.ExifProperty"/> with the specified key.
        /// Note that if there are multiple items with the same key, all of them will be
        /// replaced by the given item.
        /// </summary>
        /// <param name="key">The tag to set.</param>
        /// <param name="d">Angular degrees (or clock hours for a timestamp).</param>
        /// <param name="m">Angular minutes (or clock minutes for a timestamp).</param>
        /// <param name="s">Angular seconds (or clock seconds for a timestamp).</param>
        public void Set(ExifTag key, float d, float m, float s)
        {
            SetItem(new ExifURationalArray(key, new MathEx.UFraction32[] { new MathEx.UFraction32(d), new MathEx.UFraction32(m), new MathEx.UFraction32(s) }));
        }
        #endregion

        #region Instance Methods
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            items.Clear();
            lookup.Clear();
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
            List<T> foundItems;
            if (lookup.TryGetValue(item.Tag, out foundItems))
            {
                return foundItems.Contains(item);
            }
            return false;
        }
        /// <summary>
        /// Determines whether the collection contains an element with the specified tag.
        /// </summary>
        /// <param name="tag">The tag to locate in the collection.</param>
        /// <returns>
        /// true if the collection contains an element with the tag; otherwise, false.
        /// </returns>
        public bool Contains(ExifTag tag)
        {
            return lookup.ContainsKey(tag);
        }
        /// <summary>
        /// Removes the given element from the collection.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns>
        /// true if the element is successfully removed; otherwise, false.  
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="item"/> is null.</exception>
        public bool Remove(T item)
        {
            bool contains = items.Remove(item);
            List<T> foundItems;
            if (lookup.TryGetValue(item.Tag, out foundItems))
            {
                foundItems.Remove(item);
            }
            return contains;
        }
        /// <summary>
        /// Removes the item at the given index.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            var item = items[index];
            items.RemoveAt(index);
            List<T> foundItems;
            if (lookup.TryGetValue(item.Tag, out foundItems))
            {
                foundItems.Remove(item);
            }
        }
        /// <summary>
        /// Removes the given elements from the collection.
        /// </summary>
        /// <param name="itemsToRemove">The list of elements to remove.</param>
        public void Remove(IEnumerable<T> itemsToRemove)
        {
            foreach (var item in itemsToRemove)
            {
                items.Remove(item);
                List<T> foundItems;
                if (lookup.TryGetValue(item.Tag, out foundItems))
                {
                    foundItems.Remove(item);
                }
            }
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
            Remove(toRemove);
        }
        /// <summary>
        /// Removes all items with the given tag from the collection.
        /// </summary>
        /// <param name="ifd">The IFD section to remove.</param>
        public void Remove(ExifTag tag)
        {
            List<T> toRemove;
            if (lookup.TryGetValue(tag, out toRemove))
            {
                foreach (var item in toRemove)
                {
                    items.Remove(item);
                }
                lookup[tag] = new List<T>();
            }
        }
        /// <summary>
        /// Removes all items with the given tags from the collection.
        /// </summary>
        /// <param name="ifd">The IFD section to remove.</param>
        public void Remove(IEnumerable<ExifTag> tags)
        {
            foreach (var tag in tags)
            {
                Remove(tag);
            }
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
            List<T> lookupitems;
            if (lookup.TryGetValue(item.Tag, out lookupitems))
            {
                lookupitems.Add(item);
            }
            else
            {
                lookup[item.Tag] = new List<T>() { item };
            }
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

        #region Internal Methods
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">an item to add to the collection</param>
        protected void AddItem(ExifProperty item)
        {
            var genericItem = item as T;
            items.Add(genericItem);
            List<T> lookupitems;
            if (lookup.TryGetValue(item.Tag, out lookupitems))
            {
                lookupitems.Add(genericItem);
            }
            else
            {
                lookup[item.Tag] = new List<T>() { genericItem };
            }
        }
        /// <summary>
        /// Gets an item with the given tag from the collection.
        /// If there are multiple items with the same tag, returns the first
        /// item with the given tag.
        /// </summary>
        /// <param name="tag">the tag ıf an item to get from the collection</param>
        protected ExifProperty GetItem(ExifTag tag)
        {
            List<T> lookupitems;
            if (lookup.TryGetValue(tag, out lookupitems))
            {
                if (lookupitems.Count != 0)
                    return lookupitems[0];
                else
                    return null;
            }
            return null;
        }
        /// <summary>
        /// Gets a list of items with the given tag from the collection.
        /// </summary>
        /// <param name="tag">the tag ıf an item to get from the collection</param>
        protected List<ExifProperty> GetItems(ExifTag tag)
        {
            List<T> lookupitems;
            if (lookup.TryGetValue(tag, out lookupitems))
            {
                return lookupitems as List<ExifProperty>;
            }
            return new List<ExifProperty>();
        }
        /// <summary>
        /// Sets an item in the collection.
        /// If there are multiple items with the same tag, replaces all items 
        /// with the given item.
        /// </summary>
        /// <param name="item">an item to set in the collection</param>
        protected void SetItem(ExifProperty item)
        {
            List<T> lookupitems;
            if (lookup.TryGetValue(item.Tag, out lookupitems))
            {
                foreach (var existingItem in lookupitems)
                {
                    items.Remove(existingItem);
                }
            }
            var genericItem = item as T;
            items.Add(genericItem);
            lookup[item.Tag] = new List<T>() { genericItem };
        }
        #endregion
    }
}
