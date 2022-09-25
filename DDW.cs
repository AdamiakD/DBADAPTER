using System;
using System.Collections;
using System.Data;
using System.IO;

namespace Dbadapter
{
    class DDW
    {
        public static int encoding = 852;

        public delegate byte[] ConvertMethodHandler(object obj, ref DDW.FieldDescriptor descriptor);

        public DDW() : this(null) { }


        public DDW(Stream stream)
        {
            this._stream = stream;
            this._fieldDescriptors = new ArrayList();
        }

        public static Boolean IsConvertible(TypeCode dataTypeCode, FieldType fieldType)
        {
            switch (dataTypeCode)
            {
                case TypeCode.String:

                    if (fieldType == FieldType.Character)
                        return true;
                    else
                        return false;

                case TypeCode.DateTime:

                    if (fieldType == FieldType.Date)
                        return true;
                    else
                        return false;


                case TypeCode.Boolean:

                    if (fieldType == FieldType.Logical)
                        return true;
                    else
                        return false;

                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:

                    if (fieldType == FieldType.Numeric)
                        return true;
                    else
                        return false;

                default:

                    return false;
            }
        }

        public static ConvertMethodHandler GetConvertMethod(TypeCode dataTypeCode, FieldType fieldType)
        {

            switch (dataTypeCode)
            {
                case TypeCode.String:

                    switch (fieldType)
                    {
                        case FieldType.Character:

                            return new ConvertMethodHandler(StringToCharacter);

                        default:

                            return null;
                    }

                case TypeCode.DateTime:

                    switch (fieldType)
                    {
                        case FieldType.Date:

                            return new ConvertMethodHandler(DateTimeToDate);

                        default:

                            return null;
                    }

                case TypeCode.Boolean:

                    switch (fieldType)
                    {
                        case FieldType.Logical:

                            return new ConvertMethodHandler(BooleanToLogical);

                        default:

                            return null;
                    }

                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Byte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:

                    switch (fieldType)
                    {
                        case FieldType.Numeric:

                            return new ConvertMethodHandler(DecimalToNumeric);

                        default:

                            return null;
                    }

                default:
                    switch (fieldType)
                    {
                        case FieldType.Character:

                            return new ConvertMethodHandler(StringToCharacter);

                        default:

                            return null;
                    }

            }
        }

        // String to Character (C).

        public static byte[] StringToCharacter(object obj, ref FieldDescriptor descriptor)
        {
            String s = String.Format("{0,-" + descriptor.FieldLength.ToString() + "}", obj.ToString());

            if (s.Length > descriptor.FieldLength) 
            {
            	s = String.Format("{0,-" + "250" + "}", obj.ToString());
            	//throw new ConverOverflowException();
            }

            return GetEncodingBytes(s);

        }

        // DateTime to Date (D)

        public static byte[] DateTimeToDate(object obj, ref FieldDescriptor descriptor)
        {
            DateTime d = System.Convert.ToDateTime(obj);

            string s = d.ToString("yyyyMMdd");

            return GetEncodingBytes(s);
        }

        // Boolean to Logical (L)

        public static byte[] BooleanToLogical(object obj, ref FieldDescriptor descriptor)
        {
            Boolean l = System.Convert.ToBoolean(obj);

            if (l)
                return new byte[1] { 0x84 }; // T
            else
                return new byte[1] { 0x70 }; // F
        }

        // SByte, Int16, Int32, Int64, Byte, UInt16, UInt32, UInt64, Single, Double, Decimal to Number (N)

        public static byte[] DecimalToNumeric(object obj, ref FieldDescriptor descriptor)
        {
            decimal n = System.Convert.ToDecimal(obj);

            string s = String.Format("{0," + descriptor.FieldLength.ToString() + "}", n.ToString("D" + descriptor.FieldDecimalCount)).Replace(",", ".");

            if (s.Length > descriptor.FieldLength) throw new ConverOverflowException();

            return GetEncodingBytes(s);
        }

        private Stream _stream;
        private Int32 _recordsInTable;
        //private FileCodePage _codePage;
        private ArrayList _fieldDescriptors;

        public Stream Stream
        {
            get { return this._stream; }
            set { this._stream = value; }
        }

        public Int32 RecordsInTable
        {
            get { return this._recordsInTable; }
            set { this._recordsInTable = value; }
        }

        //public FileCodePage CodePage
        //{
        //    get { return this._codePage; }
        //    set { this._codePage = value; }
        //}

        public void AddFieldDescriptor(FieldDescriptor fieldDescriptor)
        {
            this._fieldDescriptors.Add(fieldDescriptor);
        }

        public void AddFieldDescriptor(string fieldName, FieldType fieldType,
                                       byte fieldLength, byte fieldDecimalCount,
                                       DataColumn dataColumn)
        {
            FieldDescriptor fieldDescriptor = new FieldDescriptor();

            fieldDescriptor.FieldName = fieldName;
            fieldDescriptor.FieldType = fieldType;
            fieldDescriptor.FieldLength = fieldLength;
            fieldDescriptor.FieldDecimalCount = fieldDecimalCount;
            fieldDescriptor.DataColumn = dataColumn;

            this._fieldDescriptors.Add(fieldDescriptor);
        }

        public class ConverMethodFoundException : Exception
        {
            public ConverMethodFoundException()
            {
            }
            public ConverMethodFoundException(string message)
                : base(message)
            {
            }
            public ConverMethodFoundException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class FieldNameOverflowException : Exception
        {
            public FieldNameOverflowException()
            {
            }
            public FieldNameOverflowException(string message)
                : base(message)
            {
            }
            public FieldNameOverflowException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class ConverOverflowException : Exception
        {
            public ConverOverflowException()
            {
            }
            public ConverOverflowException(string message)
                : base(message)
            {
            }
            public ConverOverflowException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class NotEnableWriteException : Exception
        {
            public NotEnableWriteException()
            {
            }
            public NotEnableWriteException(string message)
                : base(message)
            {
            }
            public NotEnableWriteException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }

        public class FieldDescriptor
        {
            private string _fieldName;
            private FieldType _fieldType;
            private byte _fieldLength;
            private byte _fieldDecimalCount;
            private DataColumn _dataColumn;
            internal DDW.ConvertMethodHandler _convertMetod;

            public string FieldName
            {
                get { return this._fieldName; }
                set { this._fieldName = value; }
            }

            public FieldType FieldType
            {
                get { return this._fieldType; }
                set
                {
                    this._fieldType = value;
                    this.SetConvertMetod();
                }
            }

            public byte FieldLength
            {
                get { return this._fieldLength; }
                set { this._fieldLength = value; }
            }

            public byte FieldDecimalCount
            {
                get { return this._fieldDecimalCount; }
                set { this._fieldDecimalCount = value; }
            }

            public DataColumn DataColumn
            {
                get { return this._dataColumn; }
                set
                {
                    this._dataColumn = value;
                    this.SetConvertMetod();
                }
            }


            public FieldDescriptor()
                : this("", FieldType.Character, 20, 0, null) { }

            public FieldDescriptor(string fieldName, FieldType fieldType, byte fieldLength)
                : this(fieldName, fieldType, fieldLength, 0, null) { }

            public FieldDescriptor(string fieldName, FieldType fieldType,
                                   byte fieldLength,
                                   DataColumn dataColumn)
                : this(fieldName, fieldType, fieldLength, 0, dataColumn) { }

            public FieldDescriptor(string fieldName, FieldType fieldType,
                                   byte fieldLength, byte fieldDecimalCount,
                                   DataColumn dataColumn)
            {
            	this._fieldName = fieldName;
                this._fieldType = fieldType;
                this._fieldLength = fieldLength;
                this._fieldDecimalCount = fieldDecimalCount;
                this._dataColumn = dataColumn;
                this.SetConvertMetod();
            }

            private void SetConvertMetod()
            {
                if (this._dataColumn != null)
                {
                    this._convertMetod = DDW.GetConvertMethod(
                        Type.GetTypeCode(this._dataColumn.DataType), this._fieldType);

                    if (this._convertMetod == null)
                    {
                        string exceptionMesage = "There is no method for converting value from " +
               Type.GetTypeCode(this._dataColumn.DataType).ToString() + " in " + this._fieldType.ToString() + ".";

                        throw new ConverMethodFoundException(exceptionMesage);

                    }
                }
            }
        }

        public enum FieldType
        {
            Character = 0,
            Date = 1,
            Logical = 2,
            Numeric = 3,
        }

        //public enum FileCodePage
        //{

        //    c_437 = 0,
        //    c_850 = 1,
        //    c_10000 = 2,
        //    c_1250 = 3,
        //    c_865 = 4,
        //    c_895 = 5,
        //    c_852 = 6,
        //    c_861 = 7,
        //    c_620 = 8,
        //    c_866 = 9,
        //    c_1251 = 10
        //}

        private static byte[] GetEncodingBytes(string s)
        {
            return System.Text.Encoding.GetEncoding(encoding).GetBytes(s);
        }

        private void WriteFieldDescriptor(FieldDescriptor fieldDescriptor)
        {
            if (fieldDescriptor.FieldName == null) throw new NotEnableWriteException("FieldDescriptor.FieldName = null");
            if (fieldDescriptor.FieldName == "") throw new NotEnableWriteException("FieldDescriptor.FieldName = \"\"");
            if (fieldDescriptor._convertMetod == null) throw new NotEnableWriteException("FieldDescriptor.ConvertMetod = null");

            // Table Field Descriptor Bytes
            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 0-10  11 bytes   Field name in ASCII (zero-filled).

            byte[] fieldName = System.Text.Encoding.ASCII.GetBytes(fieldDescriptor.FieldName.Replace("Ö","O").Replace(":", "").Replace("?", "").ToUpper());

            if (fieldName.Length > 11) throw new FieldNameOverflowException();

            for (int i = 0; i < 11; i++)
                if (i < fieldName.Length)
                    this._stream.WriteByte(fieldName[i]);
                else
                    this._stream.WriteByte(0x00);

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 11    1 byte     Field type in ASCII (C, D, L, N).

            switch (fieldDescriptor.FieldType)
            {
                case FieldType.Character:

                    this._stream.WriteByte(0x43); // C - Character 
                    break;

                case FieldType.Date:

                    this._stream.WriteByte(0x44); // D - Date
                    break;

                case FieldType.Logical:

                    this._stream.WriteByte(0x4C); // L - Logical
                    break;

                case FieldType.Numeric:

                    this._stream.WriteByte(0x4E); // N - Numeric
                    break;
            }

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 12-15 4 bytes    Reserved bytes.

            this._stream.Write(new byte[4], 0, 4);

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 16    1 bytes    Field length in binary.

            this._stream.WriteByte(fieldDescriptor.FieldLength);

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 17    1 bytes    Field decimal count in binary.

            this._stream.WriteByte(fieldDescriptor.FieldDecimalCount);

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 18-31 1 bytes    Reserved bytes.

            this._stream.Write(new byte[14], 0, 14);
        }


        public void WriteHeader(int cp)
        {
            if (this._stream == null) throw new NotEnableWriteException("DBFWrite.Stream = null");

            if (this._fieldDescriptors == null)
                throw new NotEnableWriteException("DBFWrite.FieldDescriptors = null");
            else
                if (this._fieldDescriptors.Count == 0)
                    throw new NotEnableWriteException("DBFWrite.FieldDescriptors.Length = 0");

            // The table file header
            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 0     1 byte     dBase table file version.
            //                  0x03 - dBase III PLUS without a memo.

            this._stream.WriteByte(0x03);

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 1-3   3 byte     Date of lst update; in YYMMDD format.

            DateTime lastUpdateFile = DateTime.Now;

            this._stream.WriteByte(byte.Parse(lastUpdateFile.Year.ToString().Remove(0, 2)));
            this._stream.WriteByte(byte.Parse(lastUpdateFile.Month.ToString()));
            this._stream.WriteByte(byte.Parse(lastUpdateFile.Day.ToString()));

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 4-7   32-bit     Number of records in the table.

            this._stream.WriteByte((byte)(this._recordsInTable & 0x000000FF));
            this._stream.WriteByte((byte)((this._recordsInTable & 0x0000FF00) / 0xFF));
            this._stream.WriteByte((byte)((this._recordsInTable & 0x00FF0000) / 0xFFFF));
            this._stream.WriteByte((byte)((this._recordsInTable & 0xFF000000) / 0xFFFFFF));

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 8-9   16-bit     Number of bytes in the header.

            Int16 bytesInHeader = (Int16)(32 + 32 * this._fieldDescriptors.Count + 1);

            this._stream.WriteByte((byte)(bytesInHeader & 0x000000FF));
            this._stream.WriteByte((byte)((bytesInHeader & 0x0000FF00) / 0xFF));

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 10-11 16-bit     Number of bytes in the record.

            // The records follow the header in the table file. Data records are preceded
            // by one byte, that is, a space (0x20) if the record is not deleted, an
            // asterisk (0x2A) if the record is deleted. Fields are packed into records
            // withouts field separators orrecord terminators.

            Int32 bytesInRecord = 1;

            foreach (FieldDescriptor fieldDescriptor in this._fieldDescriptors)
                bytesInRecord += fieldDescriptor.FieldLength;

            this._stream.WriteByte((byte)(bytesInRecord & 0x000000FF));
            this._stream.WriteByte((byte)((bytesInRecord & 0x0000FF00) / 0xFF));

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 12-28 17 bytes   Reserved bytes.

            this._stream.Write(new byte[17], 0, 17);

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 29    1 bytes    Code page.

            switch (cp)
            {

                //*  0x01 437    U.S. MS-DOS
                //* 0x69 620*    Mazovia (Polish) MS-DOS
                //* 0x6A 737*    Greek MS-DOS (437G)
                //* 0x02 850    International MS-DOS
                //* 0x64 852    Eastern European MS-DOS
                //* 0x67 861    Icelandic MS-DOS
                //* 0x66 865    Nordic MS-DOS
                //* 0x65 866    Russian MS-DOS
                //* 0x68 895    Kamenicky (Czech) MS-DOS
                //* 0x6B 857    Turkish MS-DOS
                //* 0xC8 1250   Turkish MS-DOS
                //* 0xC9 1251   Russian Windows
                //* 0x03 1252   Windows ANSI
                //* 0xCB 1253   Greek Windows
                //* 0xCA 1254   Turkish Windows
                //* 0x04 10000  Standard Macintosh
                //* 0x98 10006  Greek Macintosh
                //* 0x96 10007*  Russian Macintosh
                //* 0x97 10029  Eastern European Macintosh


                case 1252:

                    this._stream.WriteByte(0x03);
                    break;

                case 1251:

                    this._stream.WriteByte(0xC9);
                    break;


                case 866:

                    this._stream.WriteByte(0x65);
                    break;

                case 437:

                    this._stream.WriteByte(0x01);
                    break;

                case 850:

                    this._stream.WriteByte(0x02);
                    break;

                case 10000:

                    this._stream.WriteByte(0x04);
                    break;

                case 865:

                    this._stream.WriteByte(0x66);
                    break;

                case 895:

                    this._stream.WriteByte(0x20);
                    break;

                case 852:

                    this._stream.WriteByte(0x64);
                    break;

                case 1250:

                    this._stream.WriteByte(0xC8);
                    break;

                case 861:

                    this._stream.WriteByte(0x67);
                    break;

                case 620:

                    this._stream.WriteByte(0x69);
                    break;

                default:
                    this._stream.WriteByte(0x00);
                    break;
            }

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 30-31 2 bytes    Reserved bytes.

            this._stream.WriteByte(0x00);
            this._stream.WriteByte(0x00);

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // 32-n  32 bytes   Field descriptor array. 
            //       each    

            for (int i = 0; i < this._fieldDescriptors.Count; i++)
                WriteFieldDescriptor((FieldDescriptor)this._fieldDescriptors[i]);

            // Byte  Contents   Descriptor
            // ----- --------   ----------------------------------
            // n+1   1 byte     0x0D stored as the field terminator.

            this._stream.WriteByte(0x0D);
        }

        public void WriteRecord(DataRow row, int enc)
        {
            if (enc == 1250) enc = 852;
            //if (enc == 1252) enc = 850;
            //if (enc == 1251) enc = 866;
            encoding = enc;
            this._stream.WriteByte(0x20);

            for (int i = 0; i < this._fieldDescriptors.Count; i++)
            {
                FieldDescriptor fieldDescriptor = (FieldDescriptor)this._fieldDescriptors[i];

                if (fieldDescriptor._convertMetod != null)
                {
                    byte[] bytes = fieldDescriptor._convertMetod(row[fieldDescriptor.DataColumn], ref fieldDescriptor);
                    this._stream.Write(bytes, 0, bytes.Length);
                }
            }
        }

    }
}
