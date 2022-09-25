using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics; 

namespace Dbadapter
{
    public class EDW
    {
        public static void exportToExcel(DataRow[] dr ,DataTable source, string fileName, int czypola)
        {

            System.IO.StreamWriter excelDoc;
            string sheet = Path.GetFileNameWithoutExtension(fileName).ToString().Replace("-", "_");
            if (Path.GetExtension(fileName) == ".xlsx")
				sheet = sheet + "_xlsx";
            
            excelDoc = new System.IO.StreamWriter(fileName.Replace("[" + sheet + "]", ""));
            const string startExcelXML = "<?xml version=\"1.0\" standalone=\"yes\"?>\r\n<Workbook " +
                  "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                  " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                  "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                  "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                  "office:spreadsheet\">\r\n <Styles>\r\n " +
                  "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                  "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                  "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                  "\r\n <Protection/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"1\" ss:Size=\"10\"/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                  " ss:Format=\"@\"/>\r\n <Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"0\" ss:Size=\"9\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                  "ss:Format=\"0.0000\"/>\r\n <Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"0\" ss:Size=\"9\"/>\r\n</Style>\r\n " +
                  "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                  "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                  "ss:Format=\"mm/dd/yyyy;@\"/>\r\n <Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"0\" ss:Size=\"9\"/>\r\n</Style>\r\n " +
                  "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            //int sheetCount = 1;
            excelDoc.Write(startExcelXML);
            excelDoc.Write("<Worksheet ss:Name=\"" + sheet + "\">\n");
            excelDoc.Write("<Table>\n");
            if (czypola == 1)
            {
                excelDoc.Write("<Row>\n");
                for (int x = 0; x < source.Columns.Count; x++)
                {
                    excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                    //if (czypola == 0) excelDoc.Write("");
                    excelDoc.Write(source.Columns[x].ColumnName);
                    excelDoc.Write("</Data></Cell>\n");
                }
                excelDoc.Write("</Row>\n");
            }
            foreach (DataRow x in dr)
            {
                rowCount++;
                ////if the number of rows is > 64000 create a new page to continue output
                //if (rowCount == 64000)
                //{
                //    rowCount = 0;
                //    sheetCount++;
                //    excelDoc.Write("</Table>\n");
                //    excelDoc.Write(" </Worksheet>\n");
                //    excelDoc.Write("<Worksheet ss:Name=\"" + sheet + sheetCount + "\">");
                //    excelDoc.Write("<Table>");
                //}
                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                for (int y = 0; y < source.Columns.Count; y++)
                {
                    System.Type rowType;
                    rowType = x[y].GetType();
                    switch (rowType.ToString())
                    {
                        case "System.String":
                            string XMLstring = x[y].ToString();
                            XMLstring = XMLstring.Trim();
                            XMLstring = XMLstring.Replace("&", "&");
                            XMLstring = XMLstring.Replace(">", ">");
                            XMLstring = XMLstring.Replace("<", "<");
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                           "<Data ss:Type=\"String\">");
                            excelDoc.Write(XMLstring);
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.DateTime":
                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                            //The Following Code puts the date stored in XMLDate 
                            //to the format above
                            DateTime XMLDate = (DateTime)x[y];
                            string XMLDatetoString = ""; //Excel Converted Date
                            XMLDatetoString = XMLDate.Year.ToString() +
                                 "-" +
                                 (XMLDate.Month < 10 ? "0" +
                                 XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                 "-" +
                                 (XMLDate.Day < 10 ? "0" +
                                 XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                 "T" +
                                 (XMLDate.Hour < 10 ? "0" +
                                 XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                 ":" +
                                 (XMLDate.Minute < 10 ? "0" +
                                 XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                 ":" +
                                 (XMLDate.Second < 10 ? "0" +
                                 XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                 ".000";
                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                         "<Data ss:Type=\"DateTime\">");
                            excelDoc.Write(XMLDatetoString);
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.Boolean":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                        "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                    "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                  "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.DBNull":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                  "<Data ss:Type=\"String\">");
                            excelDoc.Write("");
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        default:
                            throw (new Exception(rowType.ToString() + " not handled."));
                    }
                }
                excelDoc.Write("</Row>\n");
            }
            excelDoc.Write("</Table>\n");
            excelDoc.Write(" </Worksheet>\n");
            excelDoc.Write(endExcelXML);
            excelDoc.Close();
        }

        public static void exportToExcelKon(DataRow[] dr, DataTable source, string fileName, int czypola)
        {

            System.IO.StreamWriter excelDoc;
            string sheet = Path.GetFileNameWithoutExtension(fileName).ToString().Replace("-", "_");
            if (Path.GetExtension(fileName) == ".xlsx")
				sheet = sheet + "_xlsx";	
            
            excelDoc = new System.IO.StreamWriter(fileName.Replace("[" + sheet + "]", ""));

            const string startExcelXML = "<?xml version=\"1.0\" standalone=\"yes\"?>\r\n<Workbook " +
                  "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                  " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                  "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                  "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                  "office:spreadsheet\">\r\n" +
                  "<ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">\r\n" +
                  //"<WindowHeight>10005</WindowHeight>\r\n" +
                  //"<WindowWidth>10005</WindowWidth>\r\n" +
                  //"<WindowTopX>120</WindowTopX>\r\n" +
                  //"<WindowTopY>135</WindowTopY>\r\n" +
                  "<ProtectStructure>False</ProtectStructure>\r\n" +
                  "<ProtectWindows>False</ProtectWindows>\r\n" +
                  "</ExcelWorkbook>\r\n" +
                  "<Styles>\r\n " +
                  "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                  "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                  "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                  "\r\n <Protection/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"1\" ss:Size=\"10\"/>\r\n </Style>\r\n " +
                  "<Style ss:ID=\"StringLiteral\">\r\n <Alignment ss:Vertical=\"Justify\" ss:ShrinkToFit=\"1\" ss:WrapText=\"1\"/> \r\n<NumberFormat" +
                  " ss:Format=\"@\"/>\r\n" +
                  "<Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"1\" ss:Size=\"9\"/>\r\n </Style>\r\n" +
                  "<Style ss:ID=\"StringLiteral2\">\r\n <Alignment ss:Vertical=\"Justify\" ss:ShrinkToFit=\"1\" ss:WrapText=\"1\"/> \r\n<NumberFormat" +
                  " ss:Format=\"@\"/>\r\n" +
                    "<Borders>\n" +
                    "<Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"2\"/>\n" +
                    "<Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"2\"/>\n" +
                    "<Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"2\"/>\n" +
                    "<Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"2\"/>\n" +
                    "</Borders>\n" +
                  "<Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"0\" ss:Size=\"9\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                  "ss:Format=\"0.0000\"/>\r\n <Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"0\" ss:Size=\"9\"/>\r\n</Style>\r\n " +
                  "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                  "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                  "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                  "ss:Format=\"mm/dd/yyyy;@\"/>\r\n <Font " +
                  "ss:FontName=\"Courier New\" ss:Bold=\"0\" ss:Size=\"9\"/>\r\n</Style>\r\n " +
                  "<Style ss:ID=\"s2\">\r\n" +
                  "<Alignment ss:Vertical=\"Justify\" ss:ShrinkToFit=\"1\" ss:WrapText=\"1\"/>\r\n" +
                  "</Style>\r\n" +
                  "<Style ss:ID=\"s1\">\r\n" +
                  "<Alignment ss:Vertical=\"Justify\" ss:ShrinkToFit=\"1\" ss:WrapText=\"1\"/>\r\n" +
                  "</Style>\r\n" +
                  "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            //int sheetCount = 1;
            excelDoc.Write(startExcelXML);
            excelDoc.Write("<Worksheet ss:Name=\"" + sheet + "\">\n");
            if (czypola == 1) excelDoc.Write("<Names>\r\n" +
                 "<NamedRange ss:Name=\"Print_Titles\" ss:RefersTo=\"=" + sheet + "!R1:R11\"/>\r\n" +
                 "</Names>\r\n" +
                 "<Table ss:ExpandedColumnCount=\"7\" ss:ExpandedRowCount=\"1000\" x:FullColumns=\"1\" " +
                 "x:FullRows=\"1\" ss:StyleID=\"s1\" ss:DefaultColumnWidth=\"520.5\">\r\n" +
                 "<Column ss:StyleID=\"s1\" ss:Width=\"134.25\"/>\r\n" +
                 "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"227.25\"/>\r\n" +
                 "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"57.75\"/>\r\n" +
                 "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"162.75\"/>\r\n" +
                 "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"42\"/>\r\n" +
                 "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"42.75\"/>\r\n" +
                 "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"40.5\"/>\r\n");
            if (czypola == 0) excelDoc.Write("<Names>\r\n" +
                       "<NamedRange ss:Name=\"Print_Titles\" ss:RefersTo=\"=" + sheet + "!R1:R11\"/>\r\n" +
                       "</Names>\r\n" +
                       "<Table ss:ExpandedColumnCount=\"7\" ss:ExpandedRowCount=\"1000\" x:FullColumns=\"1\" " +
                       "x:FullRows=\"1\" ss:StyleID=\"s1\" ss:DefaultColumnWidth=\"520.5\">\r\n" +
                       "<Column ss:StyleID=\"s1\" ss:Width=\"134.25\"/>\r\n" +
                       "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"137.25\"/>\r\n" +
                       "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"57.75\"/>\r\n" +
                       "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"192.75\"/>\r\n" +
                       "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"62\"/>\r\n" +
                       "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"62.75\"/>\r\n" +
                       "<Column ss:StyleID=\"s1\" ss:AutoFitWidth=\"0\" ss:Width=\"60.5\"/>\r\n");
            string stringliteral = "";
            foreach (DataRow x in dr)
            {
                if (rowCount < 10) stringliteral = "StringLiteral";
                else stringliteral = "StringLiteral2";

                rowCount++;

                ////if the number of rows is > 64000 create a new page to continue output
                //if (rowCount == 64000)
                //{
                //    rowCount = 0;
                //    sheetCount++;
                //    excelDoc.Write("</Table>\n");
                //    excelDoc.Write(" </Worksheet>\n");
                //    excelDoc.Write("<Worksheet ss:Name=\"" + sheet + sheetCount + "\">");
                //    excelDoc.Write("<Table>");
                //}
                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                for (int y = 0; y < source.Columns.Count; y++)
                {
                    System.Type rowType;
                    rowType = x[y].GetType();
                    switch (rowType.ToString())
                    {
                        case "System.String":
                            string XMLstring = x[y].ToString();
                            //XMLstring = XMLstring.Trim();
                            XMLstring = XMLstring.Replace("&", "&");
                            XMLstring = XMLstring.Replace(">", ">");
                            XMLstring = XMLstring.Replace("<", "<");
                            excelDoc.Write("<Cell ss:StyleID=\"" + stringliteral + "\">" +
                                           "<Data ss:Type=\"String\">");
                            excelDoc.Write(XMLstring);
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.DateTime":
                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                            //The Following Code puts the date stored in XMLDate 
                            //to the format above
                            DateTime XMLDate = (DateTime)x[y];
                            string XMLDatetoString = ""; //Excel Converted Date
                            XMLDatetoString = XMLDate.Year.ToString() +
                                 "-" +
                                 (XMLDate.Month < 10 ? "0" +
                                 XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                 "-" +
                                 (XMLDate.Day < 10 ? "0" +
                                 XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                 "T" +
                                 (XMLDate.Hour < 10 ? "0" +
                                 XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                 ":" +
                                 (XMLDate.Minute < 10 ? "0" +
                                 XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                 ":" +
                                 (XMLDate.Second < 10 ? "0" +
                                 XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                 ".000";
                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                         "<Data ss:Type=\"DateTime\">");
                            excelDoc.Write(XMLDatetoString);
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.Boolean":
                            excelDoc.Write("<Cell ss:StyleID=\"" + stringliteral + "\">" +
                                        "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                    "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                  "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        case "System.DBNull":
                            excelDoc.Write("<Cell ss:StyleID=\"" + stringliteral + "\">" +
                                  "<Data ss:Type=\"String\">");
                            excelDoc.Write("");
                            excelDoc.Write("</Data></Cell>\n");
                            break;
                        default:
                            throw (new Exception(rowType.ToString() + " not handled."));
                    }
                }
                excelDoc.Write("</Row>\n");
            }
            excelDoc.Write("</Table>\n");
            string parsestr = "<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">\n" +
            "<PageSetup>\n" +
            "<Layout x:Orientation=\"Landscape\"/>\n" +
            "<Header x:Margin=\"0.51181102362204722\"/>\n" +
            "<Footer x:Margin=\"0.51181102362204722\" x:Data=\"Page &amp;P of &amp;N\"/>" +
            "<PageMargins x:Bottom=\"0.78740157480314965\" x:Left=\"0.59055118110236227\" " +
            "x:Right=\"0.59055118110236227\" x:Top=\"0.59055118110236227\"/>\n" +
            "</PageSetup>\n" +
            "<Print>\n" +
            "<ValidPrinterInfo/>\n" +
            "<PaperSizeIndex>9</PaperSizeIndex>\r\n" +
            "<HorizontalResolution>600</HorizontalResolution>\n" +
            "<VerticalResolution>600</VerticalResolution>\n" +
            "</Print>\n" +
            "<Selected/>\n" +
            "<Panes>\n" +
            "<Pane>\n" +
            "<Number>3</Number>\n" +
            "<RangeSelection>R1:R65536</RangeSelection>\n" +
            "</Pane>\r\n" +
            "</Panes>\r\n" +
            "<ProtectObjects>False</ProtectObjects>\n" +
            "<ProtectScenarios>False</ProtectScenarios>\n" +
            "</WorksheetOptions>\n";
            excelDoc.Write(parsestr);
            excelDoc.Write("</Worksheet>\n");
            excelDoc.Write(endExcelXML);
            excelDoc.Close();
        }
    }
}
