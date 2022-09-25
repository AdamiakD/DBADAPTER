using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;

namespace Dbadapter
{
    public class DBaseDataColumn
    {
        private string name;
        private Type dataType;
        private int maxLength;
        private int recordOffset;
        private int ordinal;
        private int fieldLength;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DBaseDataColumn"/> class.
        /// </summary>
        /// <param name="name">The column name.</param>
        public DBaseDataColumn(string name)
        {
            //Assert.IsNotNull(name, ErrorMessages.NULL_REFERENCE, "name");
            this.name = name;
            this.dataType = null;
            this.maxLength = -1;
            this.ordinal = 0;
        }

        /// <summary>
        /// Gets or sets the name of the column in the <see cref="T:System.Data.DataColumnCollection"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The name of the column.</returns>
        public string ColumnName
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of data stored in the column.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Type"></see> object that represents the column data type.</returns>
        public Type DataType
        {
            get
            {
                return this.dataType;
            }
            set
            {
                this.dataType = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum length of a text column.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The maximum length of the column in characters. If the column has no maximum length,
        /// the value is 1 (default).
        /// </returns>
        public int MaxLength
        {
            get
            {
                return maxLength;
            }
            set
            {
                maxLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the field length in bytes.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The number of bytes used to store field data.
        /// </returns>
        internal int FieldLength
        {
            get
            {
                return fieldLength;
            }
            set
            {
                fieldLength = value;
            }
        }


        /// <summary>
        /// Gets or sets the position of the column in the DBase file.
        /// </summary>
        /// <value>The position of the column in the DBase file.</value>
        public int Ordinal
        {
            get
            {
                return this.ordinal;
            }
            internal set
            {
                this.ordinal = value;
            }
        }

        /// <summary>
        /// Gets or sets the column data record offset.
        /// </summary>
        /// <value>The column data record offset.</value>
        internal int RecordOffset
        {
            get
            {
                return recordOffset;
            }
            set
            {
                recordOffset = value;
            }
        }
    }

    public class DBaseFileReader
    {
        private const byte RECORD_STATUS_VALID = 0x20;
        private Stream stream;
        private DBaseFileHeader header;
        private BinaryReader reader;
        private int currentRecord;
        private long[] offSets;
        private byte[] currentRecordData;
        private string filepath;

        private object ConvertValue(DBaseDataColumn col, string value)
        {
            if (col.DataType.Equals(typeof(string)))
            {
                return value;
            }
            else if (col.DataType.Equals(typeof(bool)))
            {
                return value.Equals("y", StringComparison.OrdinalIgnoreCase) ||
                  value.Equals("t", StringComparison.OrdinalIgnoreCase);
            }
            else if (col.DataType.Equals(typeof(double)))
            {
                return double.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture);
            }
            else if (col.DataType.Equals(typeof(long)))
            {
                return long.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
            }
            else if (col.DataType.Equals(typeof(int)))
            {
                return int.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
            }
            else if (col.DataType.Equals(typeof(DateTime)))
            {
                int year = int.Parse(value.Substring(0, 4), NumberStyles.Integer, CultureInfo.InvariantCulture);
                int month = int.Parse(value.Substring(4, 2), NumberStyles.Integer, CultureInfo.InvariantCulture);
                int day = int.Parse(value.Substring(6, 8), NumberStyles.Integer, CultureInfo.InvariantCulture);
                return new DateTime(year, month, day);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        private void Initialize()
        {
            // create and parse file header
            this.header = new DBaseFileHeader();
            this.header.Read(stream);
            this.offSets = new long[this.header.RecordCount];
            this.currentRecord = -1;

            // after reading the header we are at the first record offset
            this.offSets[0] = (long)stream.Position;

            this.reader = new BinaryReader(stream);
        }

        public DBaseFileReader(Stream stream)
        {
            //Assert.IsNotNull(stream, ErrorMessages.NULL_REFERENCE, "stream");
            this.stream = stream;
            Initialize();
        }

        public DBaseFileReader(string path)
        {
            //Assert.IsNotNull(path, ErrorMessages.NULL_REFERENCE, "path");
            filepath = path;
            this.stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            Initialize();
            stream.Close();
        }

        public DataTable DB(Encoding enc)
        {
            DataTable dtdbf = new DataTable();
            for (int colcount = 0; colcount < header.Columns.Count; colcount++)
            {
                dtdbf.Columns.Add(header.Columns[colcount].ColumnName);
            }
            int count = 0;
            
            string fileName = filepath;
			string txt = "";
			string response = string.Empty;
			int reclen = header.RecordLength;
			int headlen = -1;
			try
			{
			    using (FileStream fs = File.OpenRead(fileName))
			    {
			        byte[] byteArray0 = new byte[1024];
			        while (fs.Read(byteArray0, 0, byteArray0.Length) > 0)
			        {
						txt = txt + enc.GetString(byteArray0);
						if(txt.LastIndexOf('\x000D') > 0)
						{
							headlen = txt.IndexOf('\x0020');
							fs.Close();
							goto next;
						}
					
			        }
			    }
			}
			catch (Exception Ex)
			{
			    MessageBox.Show(Ex.ToString());
			}
			
			next:
			txt = "";
			int reccount = header.RecordCount;
			try
			{
 				using (FileStream fs2 = File.OpenRead(fileName))
			    {
			        byte[] byteArray1 = new byte[headlen];
					//int q = 0;
			        while (fs2.Read(byteArray1, 0, byteArray1.Length) > 0)
			        {
						goto next2;
			        }
			    
					next2:
					int i = 0;
			        byte[] byteArray2 = new byte[reclen];
			        while ( i < reccount)
			        {
						fs2.Read(byteArray2, 0, byteArray2.Length);
						string record = enc.GetString(byteArray2);
						dtdbf.Rows.Add();
                		int liczpoz = 1;
                		DataRow dr = dtdbf.Rows[i];
		                for (int k = 0; k < header.Columns.Count; k++)
		                {
		                    int filelen = header.Columns[k].FieldLength;
		                    string cell = record.Substring(liczpoz, filelen).TrimEnd();
		                    liczpoz += filelen;
		                    dr[k] = cell;
		                }
		                i++;
			        }
					fs2.Close();
			    }
			    
			}
			catch (Exception Ex)
			{
			    MessageBox.Show(Ex.ToString());
			}			
			count++;
            return dtdbf;
        }

        public DBaseFileHeader Header
        {
            get
            {
                return this.header;
            }
        }

        public object this[int index]
        {
            get
            {
                if (null == this.currentRecordData)
                {
                    this.currentRecordData = reader.ReadBytes(this.header.RecordLength);
                }

                DBaseDataColumn col = this.header[index];
                string s = Encoding.ASCII.GetString(this.currentRecordData,
                  col.RecordOffset, col.FieldLength);
                s = s.TrimEnd(' ', '\0');
                return ConvertValue(col, s);
            }
        }

        public object this[string name]
        {
            get
            {
                DBaseDataColumn col = this.header[name];
                return this[col.Ordinal];
            }
        }

        public bool Read()
        {
            if (this.currentRecord + 1 >= this.header.RecordCount)
            {
                return false;
            }

            if (-1 == this.currentRecord)
            {
                // at the first read, just increment the counter. After reading the dbf header we are
                // at the first position so we know the first record offset
                this.currentRecord = 0;
                this.stream.Seek(this.offSets[0], SeekOrigin.Current); // set stream to the record offset
                this.currentRecordData = null;
                return this.currentRecord < this.header.RecordCount;
            }

            // search for the next record
            this.currentRecordData = null;
            long offSet = this.offSets[this.currentRecord];
            while (true)
            {
                // seek to the begining of the next record
                this.stream.Seek(offSet + header.RecordLength, SeekOrigin.Begin);

                // get first byte to see if the record is deleted
                byte recordStatus = (byte)this.reader.PeekChar();
                if (recordStatus == RECORD_STATUS_VALID)
                {
                    this.currentRecord++;
                    this.offSets[this.currentRecord] = this.stream.Position;
                    break;
                }
            }

            this.currentRecordData = null;
            return true;
        }

        public bool Seek(int pos, SeekOrigin origin)
        {
            int nextPos = -1;

            // compute the next position
            switch (origin)
            {
                case SeekOrigin.Current:
                    nextPos = this.currentRecord + pos;
                    break;
                case SeekOrigin.Begin:
                    nextPos = pos;
                    break;
                case SeekOrigin.End:
                    nextPos = (this.header.RecordCount - 1) - pos;
                    break;
            }

            if (nextPos < 0 || nextPos >= this.header.RecordCount)
            {
                return false;
            }

            if (nextPos == this.currentRecord)
            {
                return true;
            }

            // search for the closest know offset
            int known = nextPos;
            while (known >= 0 && this.offSets[known] == 0)
            {
                known--;
            }

            // now move util getting to the correct position
            this.stream.Seek(offSets[known], SeekOrigin.Begin);
            this.currentRecord = known;
            while (known != nextPos)
            {
                this.Read();
                known++;
            }
            return true;
        }
    }

    public class DBaseFileHeader
    {
        private const byte DBF_SIGNATURE_BYTE = 0x03;
        private DateTime lastUpdateDate;
        private int recordCount;
        private int recordLength;
        private List<DBaseDataColumn> columns;
        private Dictionary<string, DBaseDataColumn> columnsNameIndex;

        public DBaseFileHeader()
        {
            this.columns = new List<DBaseDataColumn>();
            this.columnsNameIndex = new Dictionary<string, DBaseDataColumn>();
        }

        public IList<DBaseDataColumn> Columns
        {
            get
            {
                return this.columns;
            }
        }

        /// <summary>
        /// Gets the record count.
        /// </summary>
        /// <value>The record count.</value>
        internal int RecordCount
        {
            get
            {
                return this.recordCount;
            }
        }

        /// <summary>
        /// Gets the length of the record.
        /// </summary>
        /// <value>The length of the record.</value>
        internal int RecordLength
        {
            get
            {
                return this.recordLength;
            }
        }

        /// <summary>
        /// Gets the at the specified index.
        /// </summary>
        /// <value></value>
        public DBaseDataColumn this[int index]
        {
            get
            {
                return this.columns[index];
            }
        }

        /// <summary>
        /// Gets the with the specified name.
        /// </summary>
        /// <value></value>
        public DBaseDataColumn this[string name]
        {
            get
            {
                return this.columnsNameIndex[name];
            }
        }

        /// <summary>
        /// Reads the file header from the file with the given path
        /// </summary>
        /// <param name="file">The path of the file to read from</param>
        public void Read(string file)
        {
            //Assert.IsTrue(File.Exists(file), ErrorMessages.FILE_NOT_FOUND, file);

            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                Read(stream);
            }
        }

        /// <summary>
        /// Reads the file header from the given stream
        /// </summary>
        /// <param name="file">The stream to read from</param>
        public void Read(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);

            // check singature
            byte fileSig = reader.ReadByte();
            //Assert.IsTrue(fileSig == DBF_SIGNATURE_BYTE, ErrorMessages.GENERIC_INVALID_FILE_FORMAT);


            // parse the update date.
            int updateYear = reader.ReadByte();
            int updateMonth = reader.ReadByte();
            int updateDay = reader.ReadByte();

            // Y2K uncompliant
            if (updateYear > 90)
            {
                updateYear += 1900;
            }
            else
            {
                updateYear += 2000;
            }

            this.lastUpdateDate = new DateTime(updateYear, updateMonth, updateDay);

            // read the number of records
            this.recordCount = reader.ReadInt32();

            // get header and record length
            ushort headerLength = reader.ReadUInt16();
            recordLength = (int)reader.ReadUInt16();

            // calculate the field count
            // (headerLengt - descriptor size (32) - terminator (1)) / field descriptor size (32)
            int fieldCount = (headerLength - 33) / 32;

            // jump reserved bytes
            stream.Seek(20, SeekOrigin.Current);

            int recordOffset = 1;
            for (int i = 0; i < fieldCount; i++)
            {
                string name = Encoding.ASCII.GetString(reader.ReadBytes(11), 0, 11);
                name = name.TrimEnd(' ', '\0');
                DBaseDataColumn col = new DBaseDataColumn(name);

                char fieldType = reader.ReadChar();

                // use computed offset skip the one stored in the dbf
                stream.Seek(4, SeekOrigin.Current);
                col.RecordOffset = recordOffset;

                col.Ordinal = i;
                col.FieldLength = (int)reader.ReadByte();
                recordOffset += col.FieldLength;
                int fieldDecimalCount = (int)reader.ReadByte();

                // set data type
                switch (fieldType)
                {
                    case 'C':
                        col.DataType = typeof(string);
                        col.MaxLength = col.FieldLength;
                        break;
                    case 'N':
                        if (0 == fieldDecimalCount)
                        {
                            if (col.FieldLength < 10)
                            {
                                col.DataType = typeof(int);
                            }
                            else
                            {
                                col.DataType = typeof(long);
                            }
                        }
                        else
                        {
                            col.DataType = typeof(double);
                        }
                        break;
                    case 'F':
                        col.DataType = typeof(double);
                        break;
                    case 'L':
                        col.DataType = typeof(bool);
                        break;
                    case 'D':
                        col.DataType = typeof(DateTime);
                        break;
                    default:
                        col.DataType = typeof(string);
                        col.MaxLength = col.FieldLength;
                        break;
                }

                // add to collection
                try
                {
                	if (col.ColumnName.ToString().Replace("\r","").Trim() != "")
					{
						this.columns.Add(col);
						this.columnsNameIndex.Add(col.ColumnName, col);
					}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d: \n" + ex.Message + " Column Name: " + col.ColumnName);
                }

                // jump reserved bytes
                stream.Seek(14, SeekOrigin.Current);
            }

            // jump terminator byte
            stream.Seek(1, SeekOrigin.Current);
        }
    }
}
