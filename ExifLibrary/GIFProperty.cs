using System;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents a 7-bit ASCII encoded comment string. (GIF Specification: Comment Extension)
    /// </summary>
    public class GIFComment : ExifProperty
    {
        protected string mValue;

        public GIFComment(ExifTag tag, string value, GIFBlock insertBefore = null) : base(tag)
        {
            mValue = value;
            InsertBefore = insertBefore;
        }

        protected override object _Value
        { get { return Value; } set { Value = (string)value; } }

        protected internal GIFBlock InsertBefore { get; private set; }

        public override ExifInterOperability Interoperability
        {
            get
            {
                byte[] data = Encoding.ASCII.GetBytes(mValue);

                return new ExifInterOperability((ushort)mTag, InterOpType.ASCII, (uint)data.Length, data);
            }
        }

        public new string Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator string(GIFComment obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue; }
    }
}