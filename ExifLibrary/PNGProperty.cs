using System;
using System.Text;

namespace ExifLibrary
{
    /// <summary>
    /// Represents an Latin-1 [ISO-8859-1] string. (PNG Specification: tEXt, zTXt)
    /// </summary>
    public class PNGText : ExifProperty
    {
        protected string mValue;
        protected override object _Value { get { return Value; } set { Value = (string)value; } }
        public new string Value { get { return mValue; } set { mValue = value; } }

        public string Keyword { get; private set; }
        public bool Compressed { get; private set; }

        static public implicit operator string(PNGText obj) { return obj.mValue; }

        public override string ToString() { return mValue; }

        public PNGText(ExifTag tag, string keyword, string value, bool compressed)
            : base(tag)
        {
            Keyword = keyword;
            mValue = value;
            Compressed = compressed;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                Encoding latin1 = Encoding.GetEncoding(28591);
                if (Compressed)
                {
                    byte[] keyword = latin1.GetBytes(Keyword);
                    byte[] value = Utility.CompressString(mValue, latin1);

                    byte[] data = new byte[keyword.Length + 2 + value.Length];
                    Array.Copy(keyword, 0, data, 0, keyword.Length);
                    data[keyword.Length] = 0; // Null separator
                    data[keyword.Length + 1] = 0; // Compression method, 0 for zlib
                    Array.Copy(value, 0, data, keyword.Length + 2, value.Length);

                    return new ExifInterOperability((ushort)mTag, 2, (uint)data.Length, data);
                }
                else
                {
                    byte[] keyword = latin1.GetBytes(Keyword);
                    byte[] value = latin1.GetBytes(mValue);

                    byte[] data = new byte[keyword.Length + 1 + value.Length];
                    Array.Copy(keyword, 0, data, 0, keyword.Length);
                    data[keyword.Length] = 0; // Null separator
                    Array.Copy(value, 0, data, keyword.Length + 1, value.Length);

                    return new ExifInterOperability((ushort)mTag, 2, (uint)data.Length, data);
                }
            }
        }
    }

    /// <summary>
    /// Represents an internationalized Latin-1 [ISO-8859-1] string. (PNG Specification: iTXt)
    /// </summary>
    public class PNGInternationalText : ExifProperty
    {
        protected string mValue;
        protected override object _Value { get { return Value; } set { Value = (string)value; } }
        public new string Value { get { return mValue; } set { mValue = value; } }

        public string Keyword { get; private set; }
        public string Language { get; private set; }
        public string TranslatedKeyword { get; private set; }
        public bool Compressed { get; private set; }

        static public implicit operator string(PNGInternationalText obj) { return obj.mValue; }

        public override string ToString() { return mValue; }

        public PNGInternationalText(ExifTag tag, string keyword, string value, bool compressed, string language, string translatedKeyword)
            : base(tag)
        {
            Keyword = keyword;
            mValue = value;
            Compressed = compressed;
            Language = language;
            TranslatedKeyword = translatedKeyword;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                Encoding latin1 = Encoding.GetEncoding(28591);
                byte[] keyword = latin1.GetBytes(Keyword);
                byte[] value = new byte[0];
                if (Compressed)
                    value = Utility.CompressString(mValue, Encoding.UTF8);
                else
                    value = Encoding.UTF8.GetBytes(mValue);
                byte[] language = latin1.GetBytes(Language);
                byte[] translatedKeyword = Encoding.UTF8.GetBytes(TranslatedKeyword);

                byte[] data = new byte[keyword.Length + 3 + language.Length + 1 + translatedKeyword.Length + 1 + value.Length];
                Array.Copy(keyword, 0, data, 0, keyword.Length);
                data[keyword.Length] = 0; // Null separator
                data[keyword.Length + 1] = (byte)(Compressed ? 1 : 0); // Compressed flag
                data[keyword.Length + 2] = 0; // Compression method, 0 for zlib
                Array.Copy(language, 0, data, keyword.Length + 3, language.Length);
                data[keyword.Length + 3 + language.Length] = 0; // Null separator
                Array.Copy(translatedKeyword, 0, data, keyword.Length + 3 + language.Length + 1, translatedKeyword.Length);
                data[keyword.Length + 3 + language.Length + 1 + translatedKeyword.Length] = 0; // Null separator
                Array.Copy(value, 0, data, keyword.Length + 3 + language.Length + 1 + translatedKeyword.Length + 1, value.Length);

                return new ExifInterOperability((ushort)mTag, 2, (uint)data.Length, data);
            }
        }
    }

    /// <summary>
    /// Represents time stamp information. (PNG Specification: tIME)
    /// </summary>
    public class PNGTimeStamp : ExifProperty
    {
        protected DateTime mValue;
        protected override object _Value { get { return Value; } set { Value = (DateTime)value; } }
        public new DateTime Value { get { return mValue; } set { mValue = value; } }

        static public implicit operator DateTime(PNGTimeStamp obj) { return obj.mValue; }

        public override string ToString() { return mValue.ToString("yyyy.MM.dd HH:mm:ss"); }

        public PNGTimeStamp(ExifTag tag, DateTime value)
            : base(tag)
        {
            mValue = value;
        }

        public override ExifInterOperability Interoperability
        {
            get
            {
                byte[] valueBytes = new byte[7];
                byte[] yearBytes = ExifBitConverter.BigEndian.GetBytes((ushort)mValue.Year);
                Array.Copy(yearBytes, valueBytes, 2);
                valueBytes[2] = (byte)mValue.Month;
                valueBytes[3] = (byte)mValue.Day;
                valueBytes[4] = (byte)mValue.Hour;
                valueBytes[5] = (byte)mValue.Minute;
                valueBytes[6] = (byte)mValue.Second;
                return new ExifInterOperability((ushort)mTag, 2, (uint)7, valueBytes);
            }
        }
    }
}
