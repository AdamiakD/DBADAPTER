using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Globalization;
using EDR.Core;
using System.Windows.Forms;
using System.Xml;

namespace EDR
{

    /// <summary>
    /// Main class implementation
    /// </summary>
    public class EDR
    {
        private Stream m_file = null;
        private XlsHeader m_hdr = null;
        private XlsBiffStream m_stream = null;
        private XlsWorkbookGlobals m_globals = null;
        private List<XlsWorksheet> m_sheets = new List<XlsWorksheet>();
        private DataSet m_workbookData = null;
        private ushort m_version = 0x0600;
        private Encoding m_encoding = Encoding.Default;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="file">Stream with source data</param>
        public EDR(Stream file, string path)
        {
            m_file = file; // new BufferedStream(file);
            m_hdr = XlsHeader.ReadHeader(m_file);
            XlsRootDirectory dir = new XlsRootDirectory(m_hdr);
            XlsDirectoryEntry workbookEntry = dir.FindEntry("Workbook");
            if (workbookEntry == null)
                workbookEntry = dir.FindEntry("Book");
            if (workbookEntry == null)
                throw new FileNotFoundException("B³¹d 'Streamu'");
            if (workbookEntry.EntryType != STGTY.STGTY_STREAM)
                throw new FormatException("Workbook directory entry is not a Stream");
            m_stream = new XlsBiffStream(m_hdr, workbookEntry.StreamFirstSector);
            ReadWorkbookGlobals();
            GC.Collect();
            m_workbookData = new DataSet();
            for (int i = 0; i < m_sheets.Count; i++)
                if (ReadWorksheet(m_sheets[i], path))
                    m_workbookData.Tables.Add(m_sheets[i].Data);
            m_globals.SST = null;
            m_globals = null;
            m_sheets = null;
            m_stream = null;
            m_hdr = null;
            GC.Collect();
        }

        /// <summary>
        /// DataSet with workbook data, Tables represent Sheets
        /// </summary>
        public DataSet WorkbookData
        {
            get { return m_workbookData; }
        }

        /// <summary>
        /// Private method, reads Workbook Globals section
        /// </summary>
        private void ReadWorkbookGlobals()
        {
            m_globals = new XlsWorkbookGlobals();
            m_stream.Seek(0, SeekOrigin.Begin);
            XlsBiffRecord rec = m_stream.Read();
            XlsBiffBOF bof = rec as XlsBiffBOF;
            if (bof == null || bof.Type != BIFFTYPE.WorkbookGlobals)
                throw new InvalidDataException("Stream zawiera b³êdne dane");
            m_version = bof.Version;
            m_encoding = Encoding.Unicode;
            bool isV8 = (m_version >= 0x600);
            bool sst = false;
            while ((rec = m_stream.Read()) != null)
            {
                switch (rec.ID)
                { 
                    case BIFFRECORDTYPE.INTERFACEHDR:
                        m_globals.InterfaceHdr = (XlsBiffInterfaceHdr)rec;
                        break;
                    case BIFFRECORDTYPE.BOUNDSHEET:
                        XlsBiffBoundSheet sheet = (XlsBiffBoundSheet)rec;
                        if (sheet.Type != XlsBiffBoundSheet.SheetType.Worksheet) break;
                        sheet.IsV8 = isV8;
                        sheet.UseEncoding = m_encoding;
                        m_sheets.Add(new XlsWorksheet(m_globals.Sheets.Count, sheet));
                        m_globals.Sheets.Add(sheet);
                        break;
                    case BIFFRECORDTYPE.MMS:
                        m_globals.MMS = rec;
                        break;
                    case BIFFRECORDTYPE.COUNTRY:
                        m_globals.Country = rec;
                        break;
                    case BIFFRECORDTYPE.CODEPAGE:
                        m_globals.CodePage = (XlsBiffSimpleValueRecord)rec;
                        m_encoding = Encoding.GetEncoding(m_globals.CodePage.Value);
                        break;
                    case BIFFRECORDTYPE.FONT:
                    case BIFFRECORDTYPE.FONT_V34:
                        m_globals.Fonts.Add(rec);
                        break;
                    case BIFFRECORDTYPE.FORMAT:
                    case BIFFRECORDTYPE.FORMAT_V23:
                        m_globals.Formats.Add(rec);
                        break;
                    case BIFFRECORDTYPE.XF:
                    case BIFFRECORDTYPE.XF_V4:
                    case BIFFRECORDTYPE.XF_V3:
                    case BIFFRECORDTYPE.XF_V2:
                        m_globals.ExtendedFormats.Add(rec);
                        break;
                    case BIFFRECORDTYPE.SST:
                        m_globals.SST = (XlsBiffSST)rec;
                        sst = true;
                        break;
                    case BIFFRECORDTYPE.CONTINUE:
                        if (!sst) break;
                        XlsBiffContinue contSST = (XlsBiffContinue)rec;
                        m_globals.SST.Append(contSST);
                        break;
                    case BIFFRECORDTYPE.EXTSST:
                        m_globals.ExtSST = rec;
                        sst = false;
                        break;
                    case BIFFRECORDTYPE.EOF:
                        if (m_globals.SST != null)
                            m_globals.SST.ReadStrings();
                        return;
                    default:
                        continue;
                }
            }
        }

        /// <summary>
        /// private method, reads sheet data
        /// </summary>
        /// <param name="sheet">Sheet object, whose data to read</param>
        /// <returns>True if sheet was read successfully, otherwise False</returns>
        private bool ReadWorksheet(XlsWorksheet sheet, string path)
        {
            m_stream.Seek((int)sheet.DataOffset, SeekOrigin.Begin);
            XlsBiffBOF bof = m_stream.Read() as XlsBiffBOF;
            if (bof == null || bof.Type != BIFFTYPE.Worksheet)
                return false;
            XlsBiffIndex idx = m_stream.Read() as XlsBiffIndex;
            bool isV8 = (m_version >= 0x600);
            if (idx != null)
            {
                idx.IsV8 = isV8;
                DataTable dt = new DataTable(sheet.Name);
                string pathname = Path.GetFileNameWithoutExtension(path) + "_" + sheet.Name.ToString() + Path.GetExtension(path);
                pathname = pathname.Replace(" ", "");
                dt.TableName = Path.GetDirectoryName(path) + "\\" + pathname;

                XlsBiffRecord trec;
                XlsBiffDimensions dims = null;
                do
                {
                    trec = m_stream.Read();
                    if (trec.ID == BIFFRECORDTYPE.DIMENSIONS)
                    {
                        dims = (XlsBiffDimensions)trec;
                        break;
                    }
                }
                while (trec.ID != BIFFRECORDTYPE.ROW);
                int maxCol = 256;
                int inmaxCol = 256;
                int fieldcounter = 0;
                dims.IsV8 = isV8;
                sheet.Dimensions = dims;

                uint[] dbCellAddrs1 = idx.DbCellAddresses;
                
                for (int i = 0; i < dbCellAddrs1.Length; i++)
                {
                   XlsBiffDbCell dbCell = (XlsBiffDbCell)m_stream.ReadAt((int)dbCellAddrs1[i]);
                   XlsBiffRow row = null;
                   int offs = (int)dbCell.RowAddress;
                   do
                   {
                       row = m_stream.ReadAt(offs) as XlsBiffRow;
                       if (row == null) break;
                       offs += row.Size;
                       maxCol = row.LastDefinedColumn;
                       fieldcounter++;
                       if (fieldcounter == 1) inmaxCol = maxCol;
                   }
                   while (row != null);
                }
                if (maxCol != inmaxCol) MessageBox.Show("SprawdŸ czy wczytano wszystkie dane!");
                for (int i = 0; i < inmaxCol; i++)
                    dt.Columns.Add("Column" + (i + 1).ToString(), typeof(string));
                sheet.Data = dt;
                uint maxRow = idx.LastExistingRow;
                if (idx.LastExistingRow <= idx.FirstExistingRow)
                    return true;
                dt.BeginLoadData();
                for (int i = 0; i <= maxRow; i++)
                    dt.Rows.Add(dt.NewRow());
                uint[] dbCellAddrs = idx.DbCellAddresses;
                for (int i = 0; i < dbCellAddrs.Length; i++)
                {
                    XlsBiffDbCell dbCell = (XlsBiffDbCell)m_stream.ReadAt((int)dbCellAddrs[i]);
                    XlsBiffRow row = null;
                    int offs = (int)dbCell.RowAddress;
                    do
                    {
                        row = m_stream.ReadAt(offs) as XlsBiffRow;
                        if (row == null) break;
                        offs += row.Size;
                    }
                    while (row != null);
                    while (true)
                    {
                        XlsBiffRecord rec = m_stream.ReadAt(offs);
                        offs += rec.Size;
                        if (rec is XlsBiffDbCell) break;
                        if (rec is XlsBiffEOF) break;
                        XlsBiffBlankCell cell = rec as XlsBiffBlankCell;
                        if (cell == null)
                        {
                            continue;
                        }
                        if (cell.ColumnIndex >= inmaxCol) continue;
                        if (cell.RowIndex > maxRow) continue;
                        switch (cell.ID)
                        {
                            case BIFFRECORDTYPE.INTEGER:
                            case BIFFRECORDTYPE.INTEGER_OLD:
                                dt.Rows[cell.RowIndex][cell.ColumnIndex] = ((XlsBiffIntegerCell)cell).Value.ToString();
                                break;
                            case BIFFRECORDTYPE.NUMBER:
                            case BIFFRECORDTYPE.NUMBER_OLD:
                                dt.Rows[cell.RowIndex][cell.ColumnIndex] = FormatNumber(((XlsBiffNumberCell)cell).Value);
                                break;
                            case BIFFRECORDTYPE.LABEL:
                            case BIFFRECORDTYPE.LABEL_OLD:
                            case BIFFRECORDTYPE.RSTRING:
                                dt.Rows[cell.RowIndex][cell.ColumnIndex] = ((XlsBiffLabelCell)cell).Value;
                                break;
                            case BIFFRECORDTYPE.LABELSST:
                                {
                                    string tmp = m_globals.SST.GetString(((XlsBiffLabelSSTCell)cell).SSTIndex);
                                    dt.Rows[cell.RowIndex][cell.ColumnIndex] = tmp;
                                }
                                break;
                            case BIFFRECORDTYPE.RK:
                                dt.Rows[cell.RowIndex][cell.ColumnIndex] = FormatNumber(((XlsBiffRKCell)cell).Value);
                                break;
                            case BIFFRECORDTYPE.MULRK:
                                for (ushort j = cell.ColumnIndex; j <= ((XlsBiffMulRKCell)cell).LastColumnIndex; j++)
                                    dt.Rows[cell.RowIndex][j] = FormatNumber(((XlsBiffMulRKCell)cell).GetValue(j));
                                break;
                            case BIFFRECORDTYPE.BLANK:
                            case BIFFRECORDTYPE.BLANK_OLD:
                            case BIFFRECORDTYPE.MULBLANK:
                                // Skip blank cells
                                break;
                            case BIFFRECORDTYPE.FORMULA:
                            case BIFFRECORDTYPE.FORMULA_OLD:
                                ((XlsBiffFormulaCell)cell).UseEncoding = m_encoding; 
                                object val = ((XlsBiffFormulaCell)cell).Value;
                                if (val == null)
                                    val = string.Empty;
                                else if (val is FORMULAERROR)
                                    val = "#" + ((FORMULAERROR)val).ToString();
                                else if (val is double)
                                    val = FormatNumber((double)val);
                                dt.Rows[cell.RowIndex][cell.ColumnIndex] = val.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }
                dt.EndLoadData();
            }
            else
            {
                return false;
            }

            return true;
        }

        private string FormatNumber(double x)
        {
            if (Math.Floor(x) == x)
                return Math.Floor(x).ToString();
            else
                return Math.Round(x, 2).ToString(CultureInfo.InvariantCulture);
        }

        public static DataTable ReadExcelXML(string ExcelXmlFile)
        {
            DataTable dt = new DataTable();
            XmlDocument xc = new XmlDocument();
            xc.Load(ExcelXmlFile);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xc.NameTable);
            nsmgr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
            nsmgr.AddNamespace("x", "urn:schemas-microsoft-com:office:excel");
            nsmgr.AddNamespace("ss", "urn:schemas-microsoft-com:office:spreadsheet");

            XmlElement xe = (XmlElement)xc.DocumentElement.SelectSingleNode("//ss:Worksheet/ss:Table", nsmgr);
            if (xe == null)
                return null;
            XmlNodeList xl = xe.SelectNodes("ss:Row", nsmgr);
            int Row = -1, Col = 0;
            Dictionary<int, string> cols = new Dictionary<int, string>();
            foreach (XmlElement xi in xl)
            {
                XmlNodeList xcells = xi.SelectNodes("ss:Cell", nsmgr);
                Col = 0;
                foreach (XmlElement xcell in xcells)
                {
                    if (Row == -1)
                    {
                        dt.Columns.Add(xcell.InnerText);
                        cols[Col++] = xcell.InnerText;
                    }
                    else
                    {
                        if (xcell.Attributes["ss:Index"] != null)
                        {
                            int idx = int.Parse(xcell.Attributes["ss:Index"].InnerText);
                            Col = idx - 1;
                        }

                        SetCol(dt, Row, (string)cols[Col++], xcell.InnerText, typeof(string));
                    }
                }
                Row++;
            }
            return dt;
        }

        public static int AddRow(DataTable dt, bool AcceptChanges)
        {
            object[] Values = new object[dt.Columns.Count];
            for (int Column = 0; Column < dt.Columns.Count; Column++)
            {
                if (!dt.Columns[Column].AllowDBNull)
                {
                    if (dt.Columns[Column].DefaultValue != null &&
                        dt.Columns[Column].DefaultValue != System.DBNull.Value)
                    {
                        Values[Column] = dt.Columns[Column].DefaultValue;
                    }
                }
            }
            dt.Rows.Add(Values);
            if (AcceptChanges)
            {
                dt.AcceptChanges();
            }
            return dt.Rows.Count - 1;
        }

        public static DataColumn SetCol(DataTable dt, int Row, string ColumnName,
                                        object Value, System.Type TypeOfValue)
        {
            if (dt == null || ColumnName == null || ColumnName == "")
                return null;

            if (Value == null)
                Value = System.DBNull.Value;

            int nIndex = -1;
            DataColumn dcol = null;
            //bool Added = false;
            if (dt.Columns.Contains(ColumnName))
            {
                dcol = dt.Columns[ColumnName];
            }
            else
            {
                dcol = dt.Columns.Add(ColumnName, TypeOfValue);

            }
            if (dcol.ReadOnly)
                dcol.ReadOnly = false;

            nIndex = dcol.Ordinal;
            //new empty row appended
            if (dt.Rows.Count == Row && Row >= 0)
            {
                AddRow(dt, false);
                //Added = true;
            }
            //one row
            if (Row >= 0)
            {
                dt.Rows[Row][nIndex] = Value;
            }
            else if (Row == -1)
            { //all rows
                try
                {
                    for (Row = 0; Row < dt.Rows.Count; Row++)
                    {
                        if (dt.Rows[Row].RowState == DataRowState.Deleted)
                        {
                            continue;
                        }
                        dt.Rows[Row][nIndex] = Value;
                    }
                }
                catch (Exception)
                {
                }
            }

            return dcol;
        }

    }
}
