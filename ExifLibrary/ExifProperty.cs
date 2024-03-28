using System;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents an ASCII string. (EXIF Specification: ASCII)
    /// </summary>
    public class ExifAscii : ExifProperty
    {
        protected string mValue;

        public ExifAscii(ExifTag tag, string value, Encoding encoding)
            : base(tag)
        {
            mValue = value;
            Encoding = encoding;
        }

        protected override object _Value
        { get { return Value; } set { Value = (string)value; } }

        public Encoding Encoding { get; private set; }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.ASCII, (uint)mValue.Length + 1, ExifBitConverter.GetBytes(mValue, true, Encoding));
            }
        }

        public new string Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator string(ExifAscii obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue; }
    }

    /// <summary>
    /// Represents an 8-bit unsigned integer. (EXIF Specification: BYTE)
    /// </summary>
    public class ExifByte : ExifProperty
    {
        protected byte mValue;

        public ExifByte(ExifTag tag, byte value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = Convert.ToByte(value); } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.BYTE, 1, new byte[] { mValue });
            }
        }

        public new byte Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator byte(ExifByte obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of 8-bit unsigned integers. (EXIF Specification: BYTE with count > 1)
    /// </summary>
    public class ExifByteArray : ExifProperty
    {
        protected byte[] mValue;

        public ExifByteArray(ExifTag tag, byte[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (byte[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.BYTE, (uint)mValue.Length, mValue);
            }
        }

        public new byte[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator byte[](ExifByteArray obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (byte b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a 64-bit floating number. (EXIF Specification: DOUBLE)
    /// </summary>
    public class ExifDouble : ExifProperty
    {
        protected double mValue;

        public ExifDouble(ExifTag tag, double value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = Convert.ToDouble(value); } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.DOUBLE, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder, BitConverterEx.SystemByteOrder));
            }
        }

        public new double Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator double(ExifDouble obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of 64-bit floating numbers.
    /// (EXIF Specification: DOUBLE with count > 1)
    /// </summary>
    public class ExifDoubleArray : ExifProperty
    {
        protected double[] mValue;

        public ExifDoubleArray(ExifTag tag, double[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (double[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.DOUBLE, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new double[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator double[](ExifDoubleArray obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (float b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a 32-bit floating number. (EXIF Specification: FLOAT)
    /// </summary>
    public class ExifFloat : ExifProperty
    {
        protected float mValue;

        public ExifFloat(ExifTag tag, float value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = Convert.ToSingle(value); } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.FLOAT, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder, BitConverterEx.SystemByteOrder));
            }
        }

        public new float Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator float(ExifFloat obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of 32-bit floating numbers.
    /// (EXIF Specification: FLOAT with count > 1)
    /// </summary>
    public class ExifFloatArray : ExifProperty
    {
        protected float[] mValue;

        public ExifFloatArray(ExifTag tag, float[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (float[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.FLOAT, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new float[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator float[](ExifFloatArray obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (float b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents the abstract base class for an Exif property.
    /// </summary>
    public abstract class ExifProperty
    {
        protected IFD mIFD;

        protected string mName;

        protected ExifTag mTag;

        /// <summary>
        /// Initializes a new instanceof the <see cref="ExifProperty"/> class.
        /// </summary>
        /// <param name="tag">The Exif tag.</param>
        public ExifProperty(ExifTag tag)
        {
            mTag = tag;
            mIFD = ExifTagFactory.GetTagIFD(tag);
        }

        protected abstract object _Value { get; set; }

        /// <summary>
        /// Gets the IFD section contaning this property.
        /// </summary>
        public IFD IFD
        { get { return mIFD; } }

        /// <summary>
        /// Gets interoperability data for this property.
        /// </summary>
        public abstract ExifInterOperability Interoperability { get; }

        /// <summary>
        /// Gets or sets the name of this property.
        /// </summary>
        public string Name
        {
            get
            {
                if (mName == null || mName.Length == 0)
                    return ExifTagFactory.GetTagName(mTag);
                else
                    return mName;
            }
            set
            {
                mName = value;
            }
        }

        /// <summary>
        /// Gets the Exif tag associated with this property.
        /// </summary>
        public ExifTag Tag
        { get { return mTag; } }

        /// <summary>
        /// Gets or sets the value of this property.
        /// </summary>
        public object Value
        { get { return _Value; } set { _Value = value; } }
    }

    /// <summary>
    /// Represents an 8-bit signed integer. (EXIF Specification: SBYTE)
    /// </summary>
    public class ExifSByte : ExifProperty
    {
        protected sbyte mValue;

        public ExifSByte(ExifTag tag, sbyte value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = Convert.ToSByte(value); } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SBYTE, 1, new byte[] { (byte)mValue });
            }
        }

        public new sbyte Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator sbyte(ExifSByte obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of 8-bit signed integers. (EXIF Specification: SBYTE with count > 1)
    /// </summary>
    public class ExifSByteArray : ExifProperty
    {
        protected sbyte[] mValue;

        public ExifSByteArray(ExifTag tag, sbyte[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (sbyte[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                byte[] data = new byte[mValue.Length];
                Buffer.BlockCopy(mValue, 0, data, 0, mValue.Length);
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SBYTE, (uint)data.Length, data);
            }
        }

        public new sbyte[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator sbyte[](ExifSByteArray obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (sbyte b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a 32-bit signed integer. (EXIF Specification: SLONG)
    /// </summary>
    public class ExifSInt : ExifProperty
    {
        protected int mValue;

        public ExifSInt(ExifTag tag, int value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = Convert.ToInt32(value); } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SLONG, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder, BitConverterEx.SystemByteOrder));
            }
        }

        public new int Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator int(ExifSInt obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of 32-bit signed integers.
    /// (EXIF Specification: SLONG with count > 1)
    /// </summary>
    public class ExifSIntArray : ExifProperty
    {
        protected int[] mValue;

        public ExifSIntArray(ExifTag tag, int[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (int[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SLONG, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new int[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator int[](ExifSIntArray obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (int b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a rational number defined with a 32-bit signed numerator
    /// and denominator. (EXIF Specification: SRATIONAL)
    /// </summary>
    public class ExifSRational : ExifProperty
    {
        protected MathEx.Fraction32 mValue;

        public ExifSRational(ExifTag tag, int numerator, int denominator)
            : base(tag)
        {
            mValue = new MathEx.Fraction32(numerator, denominator);
        }

        public ExifSRational(ExifTag tag, MathEx.Fraction32 value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (MathEx.Fraction32)value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SRATIONAL, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new MathEx.Fraction32 Value
        { get { return mValue; } set { mValue = value; } }

        public static explicit operator float(ExifSRational obj)
        { return (float)obj.mValue; }

        public int[] ToArray()
        {
            return new int[] { mValue.Numerator, mValue.Denominator };
        }

        public float ToFloat()
        { return (float)mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of signed rational numbers.
    /// (EXIF Specification: SRATIONAL with count > 1)
    /// </summary>
    public class ExifSRationalArray : ExifProperty
    {
        protected MathEx.Fraction32[] mValue;

        public ExifSRationalArray(ExifTag tag, MathEx.Fraction32[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (MathEx.Fraction32[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SRATIONAL, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new MathEx.Fraction32[] Value
        { get { return mValue; } set { mValue = value; } }

        static public explicit operator float[](ExifSRationalArray obj)
        {
            float[] result = new float[obj.mValue.Length];
            for (int i = 0; i < obj.mValue.Length; i++)
                result[i] = (float)obj.mValue[i];
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (MathEx.Fraction32 b in mValue)
            {
                sb.Append(b.ToString());
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a 16-bit signed integer. (EXIF Specification: SSHORT)
    /// </summary>
    public class ExifSShort : ExifProperty
    {
        protected short mValue;

        public ExifSShort(ExifTag tag, short value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = Convert.ToInt16(value); } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SSHORT, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder, BitConverterEx.SystemByteOrder));
            }
        }

        public new short Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator short(ExifSShort obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of 16-bit signed integers.
    /// (EXIF Specification: SSHORT with count > 1)
    /// </summary>
    public class ExifSShortArray : ExifProperty
    {
        protected short[] mValue;

        public ExifSShortArray(ExifTag tag, short[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (short[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SSHORT, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new short[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator short[](ExifSShortArray obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (ushort b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a 32-bit unsigned integer. (EXIF Specification: LONG)
    /// </summary>
    public class ExifUInt : ExifProperty
    {
        protected uint mValue;

        public ExifUInt(ExifTag tag, uint value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = Convert.ToUInt32(value); } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.LONG, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder, BitConverterEx.SystemByteOrder));
            }
        }

        public new uint Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator uint(ExifUInt obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of 32-bit unsigned integers.
    /// (EXIF Specification: LONG with count > 1)
    /// </summary>
    public class ExifUIntArray : ExifProperty
    {
        protected uint[] mValue;

        public ExifUIntArray(ExifTag tag, uint[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (uint[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.LONG, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new uint[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator uint[](ExifUIntArray obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (uint b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a byte array that can take any value. (EXIF Specification: UNDEFINED)
    /// </summary>
    public class ExifUndefined : ExifProperty
    {
        protected byte[] mValue;

        public ExifUndefined(ExifTag tag, byte[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (byte[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.UNDEFINED, (uint)mValue.Length, mValue);
            }
        }

        public new byte[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator byte[](ExifUndefined obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (byte b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a rational number defined with a 32-bit unsigned numerator
    /// and denominator. (EXIF Specification: RATIONAL)
    /// </summary>
    public class ExifURational : ExifProperty
    {
        protected MathEx.UFraction32 mValue;

        public ExifURational(ExifTag tag, uint numerator, uint denominator)
            : base(tag)
        {
            mValue = new MathEx.UFraction32(numerator, denominator);
        }

        public ExifURational(ExifTag tag, MathEx.UFraction32 value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (MathEx.UFraction32)value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.RATIONAL, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new MathEx.UFraction32 Value
        { get { return mValue; } set { mValue = value; } }

        public static explicit operator float(ExifURational obj)
        { return (float)obj.mValue; }

        public uint[] ToArray()
        {
            return new uint[] { mValue.Numerator, mValue.Denominator };
        }

        public float ToFloat()
        { return (float)mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of unsigned rational numbers.
    /// (EXIF Specification: RATIONAL with count > 1)
    /// </summary>
    public class ExifURationalArray : ExifProperty
    {
        protected MathEx.UFraction32[] mValue;

        public ExifURationalArray(ExifTag tag, MathEx.UFraction32[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (MathEx.UFraction32[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.RATIONAL, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new MathEx.UFraction32[] Value
        { get { return mValue; } set { mValue = value; } }

        static public explicit operator float[](ExifURationalArray obj)
        {
            float[] result = new float[obj.mValue.Length];
            for (int i = 0; i < obj.mValue.Length; i++)
                result[i] = (float)obj.mValue[i];
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (MathEx.UFraction32 b in mValue)
            {
                sb.Append(b.ToString());
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a 16-bit unsigned integer. (EXIF Specification: SHORT)
    /// </summary>
    public class ExifUShort : ExifProperty
    {
        protected ushort mValue;

        public ExifUShort(ExifTag tag, ushort value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = Convert.ToUInt16(value); } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SHORT, 1, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder, BitConverterEx.SystemByteOrder));
            }
        }

        public new ushort Value
        { get { return mValue; } set { mValue = value; } }

        public static implicit operator ushort(ExifUShort obj)
        { return obj.mValue; }

        public override string ToString()
        { return mValue.ToString(); }
    }

    /// <summary>
    /// Represents an array of 16-bit unsigned integers.
    /// (EXIF Specification: SHORT with count > 1)
    /// </summary>
    public class ExifUShortArray : ExifProperty
    {
        protected ushort[] mValue;

        public ExifUShortArray(ExifTag tag, ushort[] value)
            : base(tag)
        {
            mValue = value;
        }

        protected override object _Value
        { get { return Value; } set { Value = (ushort[])value; } }

        public override ExifInterOperability Interoperability
        {
            get
            {
                return new ExifInterOperability(ExifTagFactory.GetTagID(mTag), InterOpType.SHORT, (uint)mValue.Length, ExifBitConverter.GetBytes(mValue, BitConverterEx.SystemByteOrder));
            }
        }

        public new ushort[] Value
        { get { return mValue; } set { mValue = value; } }

        static public implicit operator ushort[](ExifUShortArray obj)
        {
            return obj.mValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach (ushort b in mValue)
            {
                sb.Append(b);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }
}