using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Excel;

namespace Dbadapter
{
    public partial class Main : Form
    {
        #region declaration
        DataTable dtss = new DataTable("Source");
        private int cp = 1250;
        private Encoding enc = Encoding.GetEncoding(1250);
        //private EDR.EDR spreadsheet = null;
        private DataTable[] dtArr = new DataTable[1000];
        private DataTable[] dtCnt = new DataTable[1000];
        private DataTable dtAll = new DataTable();
        private DataTable[] ssRaport = new DataTable[1000];
        public int indexSheet = 0;
        private string order = "";
        private string sort = "";
        const string raportshow = "C:/WINDOWS/system32/notepad.exe";
        private int[] sdfliczkol = new int[1000];
        private int l = 0;
        private int i = 0;
        private int lrap = 0;
        private int irap = 0;
        private string oldfieldsort = "";
        private int ilekolumn = 0;
        private int totallenghtstru = 0;
        private ArrayList files;
        private DataTable dtc;
        private ArrayList fieldvalue;
        private ArrayList brakivalue;
        private NotifyIcon m_notifyicon = new NotifyIcon();
        private DataView dvfilter = new DataView();
        private ArrayList shellfiles = new ArrayList();
		
        public Main(string [] args)
        {
            InitializeComponent();
            //cpOpen.Text = "1252     Windows-1252       Western European (Windows)";
            files = new ArrayList();
            fieldvalue = new ArrayList();
            brakivalue = new ArrayList();
//            dtefilter();

			//ikona();
			
            if (args.Length > 0) 
            {
            	if(args[0].Trim().Substring(0,1)!="-")
            		pliki(args);
            	else
            	{
            		command(args);
            		Process.GetCurrentProcess().Kill();
            	}        	
            }
        }
        #endregion 

      

        //#region procedures
        void command(string[] cl)
        {	
        	string[] cp_inout = new string[2];
        	int ccp = cl[0].IndexOf("-CP",0);
        	string param1 = cl[0].Substring(ccp);
        	param1 = param1.Substring(0,param1.IndexOf(" ",0)).Replace("-CP","");
        	cp_inout = param1.Split('|');
        	
        	ccp = cl[0].IndexOf("-EXT",0);
        	string param2 = cl[0].Substring(ccp);
        	param2 = param2.Substring(0,param2.IndexOf(" ",0)).Replace("-EXT","");
        	//MessageBox.Show(param2);
        	
        	ccp = cl[0].IndexOf("-DB",0);
        	string param3 = cl[0].Substring(ccp);
        	param3 = param3.Substring(0).Replace("-DB","");
        	//MessageBox.Show(param3);
        	
        	ccp = cl[0].IndexOf("-ARC",0);
        	int narc = 0;
        	string param4 = cl[0].Substring(ccp);
        	param4 = param4.Substring(0,param4.IndexOf(" ",0)).Replace("-ARC","");
        	if(param4.Trim() == "")
        		param4 = "1";
        	
        	narc = Convert.ToInt16(param4)-1;
        	//MessageBox.Show(narc.ToString());
        	
        	cl[0] = param3;
        	
        	foreach (string clistitem in cpOpen.Items)
        	{
        		if(clistitem.IndexOf(cp_inout[0].Trim())>-1)
        		{
        		   	cpOpen.Text = clistitem;
        		   	_cpoutput.Text = clistitem;
        		    //MessageBox.Show(_cpoutput.Text);
        		    goto wyjdz1;
        		}
        	}
        	wyjdz1:
        	
        	if(cp_inout[1].Trim() != "")
        	{
	        	foreach (string clistitem in _cpoutput.Items)
	        	{
	        		if(clistitem.IndexOf(cp_inout[1].Trim())>-1)
	        		{
	        		   	_cpoutput.Text = clistitem;
	        		    goto wyjdz2;
	        		}
	        	}
        	}
        	wyjdz2:
        	
        	if(cp_inout[0].Trim() != "")
				cp = Convert.ToInt32(cp_inout[0].Trim());
        	
        	pliki(cl);
        	
        	try{cboSheet.SelectedIndex = narc;}
        	catch {}
        	
        	
        	if(param2.ToUpper().Trim()=="DBF")
        		copydbf(narc, 1);

        	if(param2.ToUpper().Trim()=="CSV")
        		copy(narc, 0);
        	
        	if(param2.ToUpper().Trim()=="XML")
        		copyxml(narc);
        	
        	//raportogolny(narc);
        }
        
        private void jobstart(string jpath)
        {

            StreamReader srjob = new StreamReader(jpath);
            string line;
            try
            {
                while ((line = srjob.ReadLine()) != null)
                {
                    if (line.Substring(0, 1) == "|")
                    {
                        if (line.Split('|')[1] == "program")
                        {
                            simpleRun(line.Split('|')[2], "", 1);
                        }
                        if (line.Split('|')[1] == "message")
                        {
                            MessageBox.Show(line.Split('|')[2]);
                        }
                        if (line.Split('|')[1] == "open")
                        {
                            wczytaj(0);
                            if (cboSheet.Items.Count == 0) return;
                        }
                        if (line.Split('|')[1] == "sort")
                        {
                            for (int i = 0; i < cboSheet.Items.Count; i++)
                            {
                                sortowanie(line.Split('|')[2], line.Split('|')[3], i, 0, 1);
                            }
                        }
                        if (line.Split('|')[1] == "lp")
                        {
                            for (int i = 0; i < cboSheet.Items.Count; i++)
                            {
                                lpdodaj(i);
                            }
                        }
                        if (line.Split('|')[1] == "odwracanie")
                        {
                            for (int i = 0; i < cboSheet.Items.Count; i++)
                            {
                                odwracanie(i);
                            }
                        }
                        if (line.Split('|')[1] == "nup")
                        {
                            nupTextBox1.Text = line.Split('|')[2];
                            for (int i = 0; i < cboSheet.Items.Count; i++)
                            {
                                nupowanie(i);
                            }
                        }
                        if (line.Split('|')[1] == "save")
                        {
                            string text = line.Split('|')[3];
                            if (text != "")
                            {
                                poolComboBox1.Text = text;
                            }
                            if (line.Split('|')[2] == "dbf")
                            {
                                raportszczegolowy(2, "dbf");
                                for (int i = 0; i < cboSheet.Items.Count; i++)
                                {
                                    copydbf(i,0);
                                }
                            }
                            if (line.Split('|')[2] == "csv")
                            {
                                raportszczegolowy(2, "txt");
                                for (int i = 0; i < cboSheet.Items.Count; i++)
                                {
                                    copy(i, 0);
                                }
                            }
                            if (line.Split('|')[2] == "sdf")
                            {
                                raportszczegolowy(2, "txt");
                                for (int i = 0; i < cboSheet.Items.Count; i++)
                                {
                                    copy(i, 1);
                                }
                            }
                            if (line.Split('|')[2] == "xml")
                            {
                                raportszczegolowy(2, "xml");
                                for (int i = 0; i < cboSheet.Items.Count; i++)
                                {
                                    copyxml(i);
                                }
                            }
                            if (line.Split('|')[2] == "xls")
                            {
                                raportszczegolowy(2, "xls");
                                for (int i = 0; i < cboSheet.Items.Count; i++)
                                {
                                    copyxls(i);
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Wykonano joba " + Path.GetFileNameWithoutExtension(jpath));
                _info.Text = "Wykonano joba " + Path.GetFileNameWithoutExtension(jpath);
            }
            catch (Exception ex)
            {
                _info.Text = "Nie wykonano joba " + Path.GetFileNameWithoutExtension(jpath);
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }

        }

        private void czyscwszystko()
        {
            csvNaglowkiComboBox1.Text = "TAK";
            this.Text = "DBADAPTER";
            poolComboBox1.Items.Clear();
            sortComboBox1.Items.Clear();
            poprComboBox.Items.Clear();
            poprComboBox2.Text = "";
            //spreadsheet = null;
            licznik.Text = "";
            _info.Text = "";
            commandText.Text = "";
            poprComboBox.Text = "";
            poprComboBox2.Text = "";
            i = 0;
            l = 0;
            irap = 0;
            lrap = 0;
            grpData.Enabled = false;
            czyscRm();
            for (int tab = 0; tab < dtArr.Length; tab++)
            {
                dtArr[tab] = null;
                if( ssRaport[tab] != null) ssRaport[tab].Clear();
            }
            for (int tab = 0; tab < dtCnt.Length; tab++)
            {
                dtCnt[tab] = null;
            }
            grdActiveSheet.DataSource = "";
            grdActiveSheet.Visible = false;
            cboSheet.Items.Clear();
            dataGridViewRaport.Visible = false;
            raport.CheckState = CheckState.Unchecked;
            SaveButton.CheckState = CheckState.Unchecked;
            toolsButton.CheckState = CheckState.Unchecked;
        }

        public void czyscwszystko2()
        {
            files.Clear();
            licznik.Text = "";
            _info.Text = "";
            irap = 0;
            lrap = 0;
            for (int tab = 0; tab < dtCnt.Length; tab++)
            {
                dtCnt[tab] = null;
            }
        }

        protected ArrayList GetFiles(DragEventArgs e)
        {
            ArrayList files = new ArrayList();


            Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
            if (data != null)
            {
                foreach (string fn in data)
                {
                    string ext = Path.GetExtension(fn).ToLower();
                    if (ext != "")
                    {
                        files.Add(fn);
                    }
                    else
                    {
                        string[] dirFiles = Directory.GetFiles(fn);
                        foreach (string fn2 in dirFiles)
                        {
                            files.Add(fn2);
                        }
                    }
                }
            }
            return files;
        }

        private void raportszczegolowy(int export, string rozsz)
        {
            try
            {
                progressbarstart(cboSheet.Items.Count);
                DataTable dtRap = new DataTable(Path.GetDirectoryName(dtArr[0].TableName));
                dtRap.Columns.Add("");
                for (int ctmp = 0; ctmp < 5; ctmp++)
                {
                    dtRap.Rows.Add();
                }
                dtRap.Rows[0][0] = "Name:";
                dtRap.Rows[1][0] = "Rows:";
                dtRap.Rows[2][0] = "Columns:";
                dtRap.Rows[3][0] = "Lenght:";
                dtRap.Rows[4][0] = "Fields:";
                for (int dbcount = 0; dbcount < cboSheet.Items.Count; dbcount++)
                {
                    progressbarstep();
                    dtRap.Columns.Add("Table" + (dbcount + 1).ToString());
                    if (export == 2) dtRap.Rows[0][dbcount + 1] = "_" + Path.GetFileNameWithoutExtension(dtArr[dbcount].TableName.ToString()) + "." + rozsz;
                    else dtRap.Rows[0][dbcount + 1] = Path.GetFileName(dtArr[dbcount].TableName.ToString());
                    dtRap.Rows[1][dbcount + 1] = dtArr[dbcount].Rows.Count.ToString();
                    dtRap.Rows[2][dbcount + 1] = dtArr[dbcount].Columns.Count.ToString();
                    int lp = dbcount + 1;
                    int[] collen = columnlenght(dtArr[dbcount]);
                    int totallen = 0;
                    foreach (int item in collen)
                    {
                        totallen += item;
                    }
                    dtRap.Rows[3][dbcount + 1] = totallen + 1;
                    int iColCount = dtArr[dbcount].Columns.Count;
                    for (int i = 0; i < iColCount; i++)
                    {
                        int ii = i + 1;
                        string rapfield = (ii.ToString() + ". ").PadRight(4) + dtArr[dbcount].Columns[i].ColumnName.Split('\n')[0].ToString().Replace("s:", "").PadRight(20) + collen[i].ToString().PadLeft(5);
                        try
                        {
                            dtRap.Rows[i + 4][dbcount + 1] = rapfield;
                            dtRap.Rows[i + 5][0] = " ";
                        }
                        catch
                        {
                            dtRap.Rows.Add(i + 4);
                            dtRap.Rows[i + 4][dbcount + 1] = rapfield;
                            dtRap.Rows[i + 5][0] = " ";
                        }
                    }
                }
                dtRap.Rows.RemoveAt(dtRap.Rows.Count - 1);
                if (export != 2)
                {
                    dataGridViewRaport.DataSource = dtRap;
                }
                if (export == 1)
                {
                    DataRow[] drrap;
                    drrap = dtRap.Select();
                    string rappath = Path.GetDirectoryName(dtArr[indexSheet].TableName) + "\\_report_detail_" + DateTime.Now.Date.ToString().Replace(" 00:00:00", "") + ".xls";
                    progressbarstep();
                    EDW.exportToExcel(drrap, dtRap, rappath, 0);
                    _info.Text = "Raport gotowy";
                }
                if (export == 2)
                {
                    try
                    {
                        DataRow[] drrap;
                        drrap = dtRap.Select();
                        string rappath = "x:/!_raporty/saved/" + Path.GetDirectoryName(dtArr[indexSheet].TableName).Replace("\\", ".").Replace(":", "") + "_" + DateTime.Now.ToString().Replace(":", ".").Replace(" ", "_") + ".xls";
                        progressbarstep();
                        EDW.exportToExcel(drrap, dtRap, rappath, 0);
                    }
                    catch
                    {
                    }
                }
 
                progressbarend();
            }
            catch
            {
                progressbarend();
            }
        }

        private void czysc(int zapisz, int sorting, int rap, int iopen, int tools)
        {
            raport.CheckState = CheckState.Unchecked;
            dataGridViewRaport.Visible = false;
            if (sorting == 1)
            {
                toolStripSortuj.Visible = false;
            }
            if (zapisz == 1)
            {
                toolStripZapisz.Visible = false;
                SaveButton.CheckState = CheckState.Unchecked;
            }
            if (rap == 1)
            {
                toolStripRaportZnaczik.Visible = false;
                raport.CheckState = CheckState.Unchecked;
            }
            if (iopen == 1)
            {
                toolStripOpen.Visible = false;
            }
            if (tools == 1)
            {
                toolStripNarzedzia.Visible = false;
                toolsButton.CheckState = CheckState.Unchecked;
            }
            _info.Text = ""; 
            
        }

        private void actvark(object sender)
        {
            try
            {
                dataGridViewRaport.Visible = false;
                toolStripRaportZnaczik.Visible = false;
                toolStripOpen.Visible = false;
                raport.CheckState = CheckState.Unchecked;
                order = "";
                _info.Text = "";
                if (((ComboBox)sender).SelectedItem == null) return;
                indexSheet = ((ComboBox)sender).SelectedIndex;
                grdActiveSheet.DataSource = dtArr[indexSheet];
                poolComboBox1.Items.Clear();
                sortComboBox1.Items.Clear();
                poprComboBox.Items.Clear();
                poprComboBox.Text = dtArr[indexSheet].Columns[0].ColumnName;
                poprComboBox2.Text = "";
                liczcolrec();
                commandText.AutoCompleteCustomSource.Add(" = ");
                commandText.AutoCompleteCustomSource.Add(" <> ");
                commandText.AutoCompleteCustomSource.Add(" < ");
                commandText.AutoCompleteCustomSource.Add(" > ");
                poprComboBox.Items.Add("");
                poolComboBox1.Items.Add("");
                for (int colcnt = 0; colcnt < dtArr[indexSheet].Columns.Count; colcnt++)
                {
                    string columnname = dtArr[indexSheet].Columns[colcnt].ColumnName;
                    commandText.AutoCompleteCustomSource.Add(columnname);
                    sortComboBox1.Items.Add(columnname);
                    poolComboBox1.Items.Add(columnname);
                    poprComboBox.Items.Add(columnname);
                }
                poprComboBox2.Text = poprComboBox.Text;
                this.Text = "DBADAPTER: " + Path.GetFileName(dtArr[indexSheet].TableName.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }

        }

        private void liczcolrec()
        {
            licznik.Text = "Rec: " + dtArr[indexSheet].Rows.Count.ToString() + "  Col: " + dtArr[indexSheet].Columns.Count.ToString();
        }

        private void wczytaj(int rodzaj)
        {
            openDialog.Title = "Wybierz plik(i)";
            openDialog.FileName = "*.*";
            openDialog.Filter = "All files (*.*)|*.*|Excell files (*.xls)|*.xls|Csv files (*.csv)|*.csv|Dbf files (*.dbf)|*.dbf|Txt files (*.txt)|*.txt|Xml files (*.xml)|*.xml";
            openDialog.FilterIndex = 0;
            if (openDialog.ShowDialog() != DialogResult.OK) return;
            openDialog.Dispose();
            
            
            if (rodzaj == 0)
            {
                //dla baz danych
                _info.Text = "";
                i = 0;
                l = 0;
                cboSheet.Items.Clear();
                grdActiveSheet.DataSource = "";
                grdActiveSheet.Visible = false;
                grpData.Enabled = false;
                czyscwszystko();
                pliki(openDialog.FileNames);
                Show();
            }
            if (rodzaj == 1)
            {
                //dla licznika
                irap = 0;
                lrap = 0;
                plikilicznik(openDialog.FileNames);
            }
        }


        public void pliki(string[] strTxtFilePath)
        {
            _info.Text = "WczytujÍ plik(i)...";
            dataGridViewRaport.Visible = false;
            grdActiveSheet.Visible = true;
            try
            {
                progressbarstart(strTxtFilePath.Length);
                foreach (string item in strTxtFilePath)
                {
                    if (item.Trim().Substring(0, 1) != "-")
                    {
                        progressbarstep();
                        konwersja(1250, cpOpen.Text);
                        dtc = new DataTable();
                        string ext = Path.GetExtension(strTxtFilePath[l]).ToLower();
                        string path = Path.GetDirectoryName(strTxtFilePath[l]).ToLower() + "\\" + Path.GetFileNameWithoutExtension(strTxtFilePath[l]).ToLower();
                        if (ext == ".jdb")
                        {
                            jobstart(strTxtFilePath[l]);
                            i++;
                        }


                        if (ext.Trim().Substring(0,4) == ".xls")
                        {
                            string cell = "";
                            FileStream fs = new FileStream(strTxtFilePath[l], FileMode.Open, FileAccess.Read, FileShare.Read);
							
                            Excel.IExcelDataReader excelReader;
                            if (ext == ".xlsx")
                           		excelReader = Excel.ExcelReaderFactory.CreateOpenXmlReader(fs);
                            else
                            	excelReader = Excel.ExcelReaderFactory.CreateBinaryReader(fs);

                            fs.Close();
                            excelReader.IsFirstRowAsColumnNames = false;
                            DataSet ds = excelReader.AsDataSet();

                            cboSheet.DisplayMember = "TableName";
                            excelReader.Close();
							int mess_byl = 0;
                            foreach (DataTable dt in ds.Tables)
                            {
                                dt.TableName = path + "_" + dt.TableName + ext;
                                dtc.Columns.Clear();
                                if (dt.Rows.Count != 0)
                                {
                                    int iColCount = dt.Columns.Count;
                                    DataRow drr = dt.Rows[0];
                                    for (int iii = 0; iii < iColCount; iii++)
                                    {
                                        if (!Convert.IsDBNull(drr[iii]))
                                        {
                                        	cell = drr[iii].ToString();
                                            dt.Columns[iii].ColumnName = robcell(cell);
                                        }
                                        else
                                        {
                                        	if(mess_byl==0)
                                        	{
                                        		MessageBox.Show("Sπ puste pola w pierwszym rekordzie excela Do poprawienia!");
                                        		mess_byl=1;
                                        	}
                                        }
                                    }
                                    //dt.Rows.RemoveAt(dt.Rows.Count - 1);
                                    dt.Rows.RemoveAt(0);
                                    cboSheet.Items.Add(dt);
                                    dtArr[i] = dt;
                                    dtArr[i].TableName = dt.TableName;
                                    i++;
                               }
                          }
                     }


                    if (ext == ".mdb")
                    {

                        string strConnectionString = "";
                        cboSheet.DisplayMember = "TableName";

                        if (ext == ".dbf")
                        {
                            strConnectionString = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" + Path.GetDirectoryName(strTxtFilePath[l]) + ";";
                        }
                        else
                        {
                            strConnectionString = @"Driver={Microsoft Access Driver (*.mdb)};Dbq=" + Path.GetDirectoryName(strTxtFilePath[l]) + ";";
                        }
                        OdbcDataAdapter oDar = new OdbcDataAdapter("SELECT * FROM " + Path.GetFileName(strTxtFilePath[l]), strConnectionString);
                        DataTable dtdbf = new DataTable();
                        string tabname = strTxtFilePath[l].ToString();
                        dtdbf.TableName = tabname;
                        oDar.Fill(dtdbf);
                        cboSheet.Items.Add(dtdbf);
                        dtArr[i] = dtdbf;
                        dtArr[i].TableName = tabname;
                        i++;
                    }
                    if (ext == ".dbf")
                    {
                        cboSheet.DisplayMember = "TableName";
                        konwersja(852, cpOpen.Text);
                        DBaseFileReader dbr = new DBaseFileReader(strTxtFilePath[l]);
                        string tabname = strTxtFilePath[l].ToString();
                        dtArr[i] = dbr.DB(enc);
                        dtArr[i].TableName = tabname;
                        cboSheet.Items.Add(dtArr[i]);
                        i++;
                    }
                    if (ext == ".xml")
                    {
                        cboSheet.DisplayMember = "TableName";
                        DataSet ds = new DataSet();
                        ds.ReadXml(strTxtFilePath[l], XmlReadMode.Auto);
                        string tabname = strTxtFilePath[l].ToString();
                        dtArr[i] = ds.Tables[0];
                        dtArr[i].TableName = tabname;
                        cboSheet.Items.Add(dtArr[i]);
                        i++;
                    }
                    if (ext != ".dbf" & ext != ".xls" & ext != ".mdb" & ext != ".xml" & ext != ".jdb" & ext != ".xlsx")
                    {
                        cboSheet.DisplayMember = "TableName";
                        StreamReader sr1 = new StreamReader(strTxtFilePath[l], enc);
                        string line = "";
                        string templine = "";
                        int g = 0;
                        int czysdf = 0;
                        DataTable dtcsv = new DataTable();
                        string cell = "";
                        int szukajsep = -1;
                        char sep = ';';
                        while ((line = sr1.ReadLine()) != null)
                        {  
                            int s = 0;
                            if (szukajsep == -1)
                            {
	                            string[] separator = new string[] { "|", ";", ",", "\t" };
	                            do
	                            {
	                                szukajsep = line.IndexOf(separator[s]);
	                                sep = Convert.ToChar(separator[s]);
	                                s++;
	                            }
	                            while (szukajsep == -1 & s < separator.Length);
                            }
                            if (g == 0)
                            {
                                if (szukajsep == -1)
                                {
                                    czysdf = 1;
                                    templine = line;
                                    if (MessageBox.Show("Nie wykryto separatora w pliku " + strTxtFilePath[l] + ". Chcesz pobraÊ strukturÍ?", "Uwaga!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        openFileDialog1.FileName = "*.pdi";
                                        openFileDialog1.Filter = "Pdi files (*.pdi)|*.pdi|All files (*.*)|*.*";
                                        openFileDialog1.FilterIndex = 0;
                                    powtorz:
                                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                                        {
                                            liczznaki(dtcsv, 0);
                                            if (line.Length != totallenghtstru)
                                            {
                                                int roznicadl = line.Length - totallenghtstru;
                                                if (MessageBox.Show("D≥ugoúÊ rekordu jest rÛøna o " + roznicadl.ToString() + " znakÛw od sumy dlugoúci pÛl struktury! WczytaÊ powtÛrnie?", "Uwaga!", MessageBoxButtons.YesNo) == DialogResult.Yes) goto powtorz;
                                                else
                                                {
                                                    czysdf = 2;
                                                    dtcsv.Columns.Add("Column0");
                                                }
                                            }
                                            else
                                            {
                                                liczznaki(dtcsv, 1);
                                            }
                                        }
                                        else
                                        {
                                            progressbarend();
                                            return;
                                            //czysdf = 2;
                                            //dtcsv.Columns.Add("Column0");
                                        }
                                    }
                                    else
                                    {
                                        czysdf = 2;
                                        dtcsv.Columns.Add("Column0");
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show("Dane \"" + strTxtFilePath[l] + "\"" + " rozseparowaÊ znakiem \"" + sep + "\"?", "WczytyjÍ plik csv...", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                    	szukajsep = 1;
                                        ilekolumn = line.Split(sep).Length;
                                        for (int k = 0; k < ilekolumn; k++)
                                        {
                                            cell = line.Split(sep)[k].ToString();
                                            dtcsv.Columns.Add(robcell(cell));
                                        }
                                    }
                                    else
                                    {
                                        templine = line;
                                        czysdf = 2;
                                        dtcsv.Columns.Add("Column0");
                                    }
                                }
                            }
                            else
                            {
                                if (czysdf == 0)
                                {
                                    dtcsv.Rows.Add();
                                    DataRow dr = dtcsv.Rows[g - 1];
 
                                    List<string> parse_record = new List<string>();
                                    if (sep == ';')
                                   		parse_record = csvParse_semicolon(line);
 									if (sep == '|')
                                   		parse_record = csvParse_line(line);  
									if (sep == ',')
                                   		parse_record = csvParse_coma(line); 
									if (sep == '\t')
                                   		parse_record = csvParse_tab(line);									
                                    
									if (parse_record.Count != dtcsv.Columns.Count)
										MessageBox.Show("Jest dodatkowy separator! " + parse_record.Count.ToString() + "/" + dtcsv.Columns.Count.ToString() + "\n" + line);
									
                                    for (int k = 0; k < parse_record.Count; k++)
                                    {	
                                        cell = parse_record[k].Trim('"');
                                        dr[k] = cell.TrimEnd();
                                    }
                                }                            
                            }
                            if (czysdf == 1)
                            {
                                int liczpoz = 0;
                                dtcsv.Rows.Add();
                                cell = line.Substring(liczpoz, sdfliczkol[0]);
                                DataRow dr = dtcsv.Rows[g];
                                dr[0] = cell;
                                for (int k = 1; k < ilekolumn; k++)
                                {
                                    liczpoz += sdfliczkol[k - 1];
                                    cell = line.Substring(liczpoz, sdfliczkol[k]);
                                    dr[k] = cell;
                                }
                            }
                            if (czysdf == 2)
                            {
                                dtcsv.Rows.Add();
                                DataRow dr2 = dtcsv.Rows[g];
                                dr2[0] = line;
                            }
                            g++;
                        }
                        string tabname = strTxtFilePath[l].ToString();
                        dtArr[i] = dtcsv;
                        dtArr[i].TableName = tabname;
                        cboSheet.Items.Add(dtArr[i]);
                        i++;
                        sr1.Close();
                    }                  
                    if (cboSheet.Items.Count == 0)
                    {
                        _info.Text = "";
                        progressbarend();
                        return;
                    }
                    grpData.Enabled = true;
                    cboSheet.SelectedIndex = 0;
                    l++;
                }
                
                _info.Text = "Wczytano plik(i)";
                progressbarend();
                }
                
            }
            catch (Exception ex)
            {
                _info.Text = "";
                progressbarend();
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }
        
        public static List<string> csvParse_line(string line)
	    {
	        const char escapeChar = '"';
	        const char splitChar = '|';
	        bool inEscape = false;
	        bool priorEscape = false;
	
	        List<string> result = new List<string>();
	        StringBuilder sb = new StringBuilder();
	        for (int i = 0; i < line.Length; i++)
	        {
	            char c = line[i];
	            char przed = new char();
	            char po = new char();
	            try {
	            	przed = line[i+1];}
	            catch{}
	            
	            try{
	            	po = line[i-1];}
	            catch {}
				
	            if (c == escapeChar && priorEscape == false)
	            {
	            	if (przed != splitChar && i - 1 > 0)
	            	{
	            		if (po != splitChar && i + 1 < line.Length)
	            		{
			                c = '®';
			                inEscape = false;
	            		}
	            	}
				}
	            
	            switch (c)
	            {
	                case escapeChar:
	                    if (!inEscape)
	                        inEscape = true;
	                    else
	                    {
	                        if (!priorEscape)
	                        {
	                            if (i + 1 < line.Length && line[i + 1] == escapeChar)
	                                priorEscape = true;
	                            else
	                                inEscape = false;
	                        }
	                        else
	                        {
	                            sb.Append(c);
	                            priorEscape = false;
	                        }
	                    }
	                    break;
	                case splitChar:
	                    if (inEscape) //if in escape
	                        sb.Append(c);
	                    else
	                    {
	                        result.Add(sb.ToString());
	                        sb.Length = 0;
	                    }
	                    break;
	                default:
	                    sb.Append(c);
	                    break;
	            }
	        }
	
	        if (sb.Length > 0)
	            result.Add(sb.ToString());
	        else
				result.Add("");
	
	        return result;
	    }
        
        public static List<string> csvParse_semicolon(string line)
	    {
	        const char escapeChar = '"';
	        const char splitChar = ';';
	        bool inEscape = false;
	        bool priorEscape = false;
	
	        List<string> result = new List<string>();
	        StringBuilder sb = new StringBuilder();
	        for (int i = 0; i < line.Length; i++)
	        {
	            char c = line[i];
	            char przed = new char();
	            char po = new char();
	            try {
	            	przed = line[i+1];}
	            catch{}
	            
	            try{
	            	po = line[i-1];}
	            catch {}
				
	            if (c == escapeChar && priorEscape == false)
	            {
	            	if (przed != splitChar && i - 1 > 0)
	            	{
	            		if (po != splitChar && i + 1 < line.Length)
	            		{
			                c = '®';
			                inEscape = false;
	            		}
	            	}
				}
	            
	            switch (c)
	            {
	                case escapeChar:
	                    if (!inEscape)
	                        inEscape = true;
	                    else
	                    {
	                        if (!priorEscape)
	                        {
	                            if (i + 1 < line.Length && line[i + 1] == escapeChar)
	                                priorEscape = true;
	                            else
	                                inEscape = false;
	                        }
	                        else
	                        {
	                            sb.Append(c);
	                            priorEscape = false;
	                        }
	                    }
	                    break;
	                case splitChar:
	                    if (inEscape) //if in escape
	                        sb.Append(c);
	                    else
	                    {
	                        result.Add(sb.ToString());
	                        sb.Length = 0;
	                    }
	                    break;
	                default:
	                    sb.Append(c);
	                    break;
	            }
	        }
	
	        if (sb.Length > 0)
	            result.Add(sb.ToString());
	        else
				result.Add("");
	        
	        return result;
	    }
     
        public static List<string> csvParse_coma(string line)
	    {
	        const char escapeChar = '"';
	        const char splitChar = ',';
	        bool inEscape = false;
	        bool priorEscape = false;
	
	        List<string> result = new List<string>();
	        StringBuilder sb = new StringBuilder();
	        for (int i = 0; i < line.Length; i++)
	        {
	            char c = line[i];
	            char przed = new char();
	            char po = new char();
	            try {
	            	przed = line[i+1];}
	            catch{}
	            
	            try{
	            	po = line[i-1];}
	            catch {}
				
	            if (c == escapeChar && priorEscape == false)
	            {
	            	if (przed != splitChar && i - 1 > 0)
	            	{
	            		if (po != splitChar && i + 1 < line.Length)
	            		{
			                c = '®';
			                inEscape = false;
	            		}
	            	}
				}
	            
	            switch (c)
	            {
	                case escapeChar:
	                    if (!inEscape)
	                        inEscape = true;
	                    else
	                    {
	                        if (!priorEscape)
	                        {
	                            if (i + 1 < line.Length && line[i + 1] == escapeChar)
	                                priorEscape = true;
	                            else
	                                inEscape = false;
	                        }
	                        else
	                        {
	                            sb.Append(c);
	                            priorEscape = false;
	                        }
	                    }
	                    break;
	                case splitChar:
	                    if (inEscape) //if in escape
	                        sb.Append(c);
	                    else
	                    {
	                        result.Add(sb.ToString());
	                        sb.Length = 0;
	                    }
	                    break;
	                default:
	                    sb.Append(c);
	                    break;
	            }
	        }
	
	        if (sb.Length > 0)
	            result.Add(sb.ToString());
	        else
				result.Add("");
	
	        return result;
	    }
        
        public static List<string> csvParse_tab(string line)
	    {
	        const char escapeChar = '"';
	        const char splitChar = '\t';
	        bool inEscape = false;
	        bool priorEscape = false;
	
	        List<string> result = new List<string>();
	        StringBuilder sb = new StringBuilder();
	        for (int i = 0; i < line.Length; i++)
	        {
	            char c = line[i];
	            char przed = new char();
	            char po = new char();
	            try {
	            	przed = line[i+1];}
	            catch{}
	            
	            try{
	            	po = line[i-1];}
	            catch {}
				
	            if (c == escapeChar && priorEscape == false)
	            {
	            	if (przed != splitChar && i - 1 > 0)
	            	{
	            		if (po != splitChar && i + 1 < line.Length)
	            		{
			                c = '®';
			                inEscape = false;
	            		}
	            	}
				}
	            
	            switch (c)
	            {
	                case escapeChar:
	                    if (!inEscape)
	                        inEscape = true;
	                    else
	                    {
	                        if (!priorEscape)
	                        {
	                            if (i + 1 < line.Length && line[i + 1] == escapeChar)
	                                priorEscape = true;
	                            else
	                                inEscape = false;
	                        }
	                        else
	                        {
	                            sb.Append(c);
	                            priorEscape = false;
	                        }
	                    }
	                    break;
	                case splitChar:
	                    if (inEscape) //if in escape
	                        sb.Append(c);
	                    else
	                    {
	                        result.Add(sb.ToString());
	                        sb.Length = 0;
	                    }
	                    break;
	                default:
	                    sb.Append(c);
	                    break;
	            }
	        }
	
	        if (sb.Length > 0)
	            result.Add(sb.ToString());
	        else
				result.Add("");
	
	        return result;
	    }


        private void konwersja(int cpt, string textboxtext)
        {
            try
            {
                cp = Convert.ToInt32(textboxtext.Remove(6).Trim());
            }
            catch
            {
                cp = cpt;
            }
            enc = Encoding.GetEncoding(cp);
        }


        private void liczznaki(DataTable dtcsv, int ruszbaze)
        {
            int x = 0;
            StreamReader sr2 = new StreamReader(openFileDialog1.OpenFile(), Encoding.Default);
            string line1 = ""; ;
            totallenghtstru = 0;
            int fillernext = 0;
            while ((line1 = sr2.ReadLine()) != null)
            {
                if (line1 == "\t") continue;
                if (line1 == "") continue;
                if (line1.Substring(0, 1) == ";") continue;
                line1 = line1.Replace("\t", " ").ToUpper().TrimStart();
                string trimline = line1.Replace("\t", "");
                trimline = trimline.Substring(0, 5).Trim();
                int tab = 0;
                int tab2 = 0;
                if (trimline.ToUpper() == "ALPHA" | trimline.ToUpper() == "NUMER" | trimline.ToUpper() == "FILLE")
                {
                powtorka:
                    tab = (line1.Substring(tab, line1.Length - tab).IndexOf(" L") + 2);
                    tab2 += tab;
                    string strliczba = line1.Substring(tab2, line1.Length - tab2);
                    strliczba += ";";
                    try
                    {
                        sdfliczkol[x] = Convert.ToInt32(strliczba.Split(';')[0]);
                    }
                    catch
                    {
                        goto powtorka;
                    }
                    string newfield = line1.Replace("ALPHA ", "").Replace("NUMERIC ", "").TrimStart().TrimEnd();
                    newfield = newfield.Split(' ')[0];
                    if (newfield == "FILLER")
                    {
                        newfield = newfield + fillernext.ToString();
                        fillernext++;
                    }
                    if (ruszbaze == 1) dtcsv.Columns.Add(robcell(newfield.Trim()));
                    totallenghtstru += sdfliczkol[x];
                    x++;
                    ilekolumn = x;
                }
            }
            sr2.Close();
        }

        private string robcell(string cell)
        {
            string[] dowyrzucenia = new string[] { "\"", ",", ".", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", ";", "\n", "\t", " ", ",", "/", "\\", "+", "\"", "'", "`", "Ω", ":" };
            string[] literyzle = new string[] { "•", "π", "∆", "Ê", " ", "Í", "£", "≥", "”", "Û", "å", "ú", "è", "ü", "Ø", "ø" };
            string[] literydobre = new string[] { "A", "a", "C", "c", "E", "e", "L", "l", "O", "o", "S", "s", "Z", "z", "Z", "z" };
            for (int w = 0; w < dowyrzucenia.Length; w++)
            {
                try
                {
                    cell = cell.Replace(dowyrzucenia[w], "");
                    cell = cell.Replace(literyzle[w], literydobre[w]);
                }
                catch
                {
                }
            }
            int dlcell = cell.Length;
            if (dlcell > 10)
            {
                cell = cell.Substring(0,10);
            }
            int endcell = 1;
            cell = cell.PadRight(10, ' ');
            //DataTable dtcell = new DataTable();
            try
            {
            powtorz:
                foreach (DataColumn dc in dtc.Columns)
                {
                    if (cell == dc.ColumnName)
                    {
                        endcell++;
                        string strendcell = endcell.ToString();
                        cell = cell.Substring(0, 8) + strendcell.PadLeft(2, '0');
                        goto powtorz;
                    }
                }
            }
            catch
            {
            }
            dtc.Columns.Add(cell);
            cell = cell.Replace(" ", "");
            return cell;
        }

        private void ssrap(int n, string sspath, string ssext)
        {
            if (ssRaport[n] != null)
            {
                DataRow[] drrap;
                drrap = ssRaport[n].Select();
                string rappath = sspath + "_rmuster.xls";
                progressbarstep();
                EDW.exportToExcelKon(drrap, ssRaport[n], rappath, 0);
            }
        }

        private void copyxml(int k)
        {
            try
            {
                progressbarstart(2);
                _info.Text = "ZapisujÍ plik...";
                string path = Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName) + ".xml";
                dtArr[k].WriteXml(path, XmlWriteMode.WriteSchema, true);
                progressbarend();
                _info.Text = "Plik(i) zosta≥ zapisany";
                ssrap(k, Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName), ".xml");
            }
            catch (Exception ex)
            {
                progressbarend();
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void copy(int k, int sdf)
        {
//            try
//            {
                _info.Text = "ZapisujÍ plik...";
                
                progressbarstart(dtArr[k].Rows.Count);
                foreach (string wartosc in countarray(k, poolComboBox1.Text))
                {
                    DataRow[] dr3;
                    string selectstring = poolComboBox1.Text + " = '" + wartosc + "'";
                    if (poolComboBox1.Text != "")
                    {
                        dr3 = dtArr[k].Select(selectstring);
                    }
                    else
                    {
                        dr3 = dtArr[k].Select();
                    }
                    string errpath = Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName) + wartosc + ".err";
                    File.Delete(errpath);
                    string path = Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName) + wartosc;
                    if (sdf == 0) path += ".csv";
                    else path += ".txt";
                    StreamWriter sw = new StreamWriter(path, false, enc);
                    int iColCount = dtArr[k].Columns.Count;
                    int[] collen = columnlenght(dtArr[k]);
                    if (sdf == 0)
                    {
                        for (int i = 0; i < iColCount; i++)
                        {
                            string fieldname = dtArr[k].Columns[i].ColumnName;
                            sw.Write(fieldname);
                            if (i < iColCount - 1)
                            {
                                sw.Write(SepCSVBox);
                            }
                        }
                        sw.Write(sw.NewLine);
                    }
                    int c = 0;
                    string cell = "";
                    int ileblad = 0;
                    int czyblad = 0;
					string zawartosc = "";
                    string separatorsdf = SepCSVBox.ToString();
                    foreach (DataRow dr in dr3)
                    {
                        for (int i = 0; i < iColCount; i++)
                        {
                        	zawartosc = dr[i].ToString().Replace("\n", " ").Replace("\t", " ").Replace("\\", "/").Replace("\"", "®").Trim();
                    		cell = "";
                        	if(zawartosc.Length > 0)
                        	 	{
	                        	if (zawartosc.Substring(0,1) == "\"" && zawartosc.Substring(zawartosc.Length-1,1) == "\"")
	                    		    {
	                    		    	cell = zawartosc; 
	                    		    }
	                    		else 
		                    		{
		                    			cell = "\"" + zawartosc + "\"";
		                    		}
                        		}
                            else
                            	cell = "\"" + "\"";
                            
                            //if (cell.StartsWith("\"") == true & cell.EndsWith("\"") == true)
                            //{
                            //    cell = "\"" + cell.Substring(1, cell.Length - 2).Replace("\"", "") + "\"";
                            //}
                            //else
                            //{
                            //    cell = cell.Replace("\"", "");
                            //}
                            if (sdf == 0)
                            {
                                if (!Convert.IsDBNull(dr[i]))
                                {
                                    if (cell.IndexOf(separatorsdf) != -1)
                                    {
                                        if (ileblad == 0)
                                        {
                                            if (MessageBox.Show("Znaleziono separator w stringu. Czy sprawdzaÊ poprawnoúÊ zapisu csv z separatorem \"" + separatorsdf + "\"?", "Uwaga!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                            {
                                                czyblad = 1;
                                            }
                                        }
                                        if (czyblad == 1)
                                        {
                                            StreamWriter swerr = new StreamWriter(errpath, true, enc);
                                            swerr.Write("Row: " + (c + 1) + ",  Column: " + dr.Table.Columns[i].ColumnName + ",  Cell: " + dr[i].ToString());
                                            MessageBox.Show("Row: " + (c + 1) + "\nColumn: " + dr.Table.Columns[i].ColumnName + "\nCell: " + dr[i].ToString() + "\nZapisano do: " + errpath);
                                            swerr.Write(swerr.NewLine);
                                            swerr.Close();
                                        }
                                        ileblad++;
                                    }
                                    sw.Write(cell.TrimEnd());
                                }
                            }
                            else
                            {
                                sw.Write(cell.PadRight(collen[i]));
                            }
                            if (i < iColCount - 1 & sdf == 0)
                            {
                                sw.Write(SepCSVBox);
                            }
                        }
                        c++;
                        progressbarstep();
                        sw.Write(sw.NewLine);
                    }
                    sw.Close();
                }
                progressbarend();
                ssrap(k, Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName), ".txt");
                _info.Text = "Plik(i) zosta≥ zapisany";
//            }
//            catch (Exception ex)
//            {
//                progressbarend();
//                MessageBox.Show("B≥πd: \n" + ex.Message);
//            }
        }

        private ArrayList countarray(int k, string pole)
        {
            fieldvalue.Clear();
            string field = pole;
            if (pole != "")
            {
                fieldvalue.Add(dtArr[k].Rows[0][field].ToString().TrimEnd());
                foreach (DataRow dt2 in dtArr[k].Rows)
                {
                    string polewartosc = dt2[field].ToString().TrimEnd();
                    if (fieldvalue.IndexOf(polewartosc) == -1)
                    {
                        fieldvalue.Add(polewartosc);
                    }
                }
            }
            if (fieldvalue.Count == 0) fieldvalue.Add("");
            return fieldvalue;
        }

        private void copyxls(int k)
        {
            try
            {  
                progressbarstart(dtArr[k].Rows.Count);
                _info.Text = "ZapisujÍ plik...";
                int icount = 0;
                foreach (string wartosc in countarray(k, poolComboBox1.Text))
                {
                    DataRow[] dr3;
                    string selectstring = poolComboBox1.Text + " = '" + wartosc + "'";
                    if (poolComboBox1.Text != "")
                    {
                        dr3 = dtArr[k].Select(selectstring);
                    }
                    else
                    {
                        dr3 = dtArr[k].Select();
                    }
                    string path = "";
                    if(Path.GetExtension(dtArr[k].TableName).ToUpper().IndexOf("XLS") > -1)
                    {
                    	path = Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName) + wartosc + Path.GetExtension(dtArr[k].TableName);
                    }
                    else
                    {
                    	path = Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName) + wartosc + ".xls";
                    }
                        
                    progressbarstep();
                    EDW.exportToExcel(dr3, dtArr[k], path, 1);
                    icount++;
                }

                progressbarend();
                ssrap(k, Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName), ".xls");
                _info.Text = "Plik(i) zosta≥ zapisany";
            }
            catch (Exception ex)
            {
                progressbarend();
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void copydbf(int k, int repl)
        {
//            try
//            {
                progressbarstart(dtArr[k].Rows.Count);
                _info.Text = "ZapisujÍ plik...";
                foreach (string wartosc in countarray(k, poolComboBox1.Text))
                {
                    DataRow[] dr3;

                    string selectstring = poolComboBox1.Text + " = '" + wartosc + "'";
                    if (poolComboBox1.Text != "")
                    {
                        dr3 = dtArr[k].Select(selectstring);
                    }
                    else
                    {
                        dr3 = dtArr[k].Select();
                    }
                    string path = Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName) + wartosc + ".dbf";
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                    DDW dbfw = new DDW(fs);
                    dbfw.RecordsInTable = dr3.Length;
                    int[] collen = columnlenght(dtArr[k]);
                    int iii = 0;
                    
                    foreach (DataColumn dc in dtArr[k].Columns)
                    {
                    	dbfw.AddFieldDescriptor(dc.ColumnName, DDW.FieldType.Character, Convert.ToByte(collen[iii].ToString()), 0, dc);
                        iii++;
                    }
                    if (_cpoutput.Text == "")
                    {
                        cp = 852;
                    }
                    dbfw.WriteHeader(cp);
                    foreach (DataRow dr in dr3)
                    {
                    	if (repl != 0){
                    	int rr=0;
	                    	foreach (DataColumn dc in dtArr[k].Columns)
		                    {
	                    		dr[rr] = dr[rr].ToString().Replace("\"", "®");
		                    	rr++;
	                    	}
                    	}
                        dbfw.WriteRecord(dr, cp);
                        progressbarstep();
                    }
                    fs.Close();
                }

                progressbarend();
                _info.Text = "Plik(i) zosta≥ zapisany";
                ssrap(k, Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName), ".dbf");
//            }
//            catch (Exception ex)
//            {
//                progressbarend();
//                MessageBox.Show("B≥πd: \n" + ex.Message);
//            }
        }

        private void mapujRm(int czyRm)
        {
            dtss.Clear();
            dataGrid1.DataSource = null;
            dataGrid1.Select();
            labelNr.Visible = true;
            textBoxNr.Visible = true;
            labelRm.Visible = true;
            labelOpis.Visible = true;
            textBoxOpis.Visible = true;
            ileLabel.Visible = true;
            ileTextBox.Visible = true;
            if (czyRm == 2)
            {
                labelRm.Visible = false;
                labelOpis.Visible = false;
                textBoxOpis.Visible = false;
                ileLabel.Visible = false;
                ileTextBox.Visible = false;
                labelNr.Text = "IloúÊ wzorÛw:";
                textBoxNr.Text = "100";
            }
            else
            {
                labelNr.Text = "Nr projektu:";
                textBoxNr.Text = "";
            }
            labelSprawdz.Visible = true;
            labelSprawdz.Visible = false;
            comboBoxRm.Visible = true;
            labelIlosc.Visible = true;
            buttonRm.Visible = true;
            button1.Visible = true;
            dataGrid1.Visible = true;
            if (comboBoxRm.Text == "Wszystkie tabele")
            {
                labelSprawdz.Visible = true;
            }
            try
            {
                dtss.Columns.Add("ID");
                dtss.Columns.Add("Kolumny");
                dtss.Columns.Add("Mapuj");
            }
            catch
            {
            }
            int introw = 0;
            try
            {
                foreach (DataColumn dc in dtArr[indexSheet].Columns)
                {
                    dtss.Rows.Add();
                    dtss.Rows[introw]["ID"] = "0";
                    dtss.Rows[introw]["Kolumny"] = dc.ColumnName;
                    dtss.Rows[introw]["Mapuj"] = "";
                    introw++;
                }
            }
            catch
            {
                _info.Text = "Wczytaj Dane";
            }

            try
            {
                DataTable dtmap = new DataTable();
                if (czyRm == 0)
                {
                    buttonRm.Text = "Generuj Rmustery";
                    dtmap.Columns.Add("ID");
                    dtmap.Columns.Add("Mapuj");
                    dtmap.Rows.Add();
                    dtmap.Rows[0]["ID"] = "0";
                    dtmap.Rows[0]["Mapuj"] = "";
                    dtmap.Rows.Add();
                    dtmap.Rows[1]["ID"] = "0";
                    dtmap.Rows[1]["Mapuj"] = "[NULL]";
                    dtmap.Rows.Add();
                    dtmap.Rows[2]["ID"] = "0";
                    dtmap.Rows[2]["Mapuj"] = "Mail Solution";
                    dtmap.Rows.Add();
                    dtmap.Rows[3]["ID"] = "0";
                    dtmap.Rows[3]["Mapuj"] = "Wodociagowa 10";
                    dtmap.Rows.Add();
                    dtmap.Rows[4]["ID"] = "0";
                    dtmap.Rows[4]["Mapuj"] = "Wodociagowa";
                    dtmap.Rows.Add();
                    dtmap.Rows[5]["ID"] = "0";
                    dtmap.Rows[5]["Mapuj"] = "10";
                    dtmap.Rows.Add();
                    dtmap.Rows[6]["ID"] = "0";
                    dtmap.Rows[6]["Mapuj"] = "32-700";
                    dtmap.Rows.Add();
                    dtmap.Rows[7]["ID"] = "0";
                    dtmap.Rows[7]["Mapuj"] = "32700";
                    dtmap.Rows.Add();
                    dtmap.Rows[8]["ID"] = "0";
                    dtmap.Rows[8]["Mapuj"] = "Bochnia";
                    dtmap.Rows.Add();
                    dtmap.Rows[9]["ID"] = "0";
                    dtmap.Rows[9]["Mapuj"] = "32-700 Bochnia";
                    dtmap.Rows.Add();
                    dtmap.Rows[10]["ID"] = "0";
                    dtmap.Rows[10]["Mapuj"] = "32700 Bochnia";
                    dtmap.Rows.Add();
                    dtmap.Rows[11]["ID"] = "0";
                    dtmap.Rows[11]["Mapuj"] = "0000000";
                    dtmap.Rows.Add();
                    dtmap.Rows[12]["ID"] = "0";
                    dtmap.Rows[12]["Mapuj"] = "Mail";
                    dtmap.Rows.Add();
                    dtmap.Rows[13]["ID"] = "0";
                    dtmap.Rows[13]["Mapuj"] = "Solution";
                    dtmap.Rows.Add();
                    dtmap.Rows[14]["ID"] = "0";
                    dtmap.Rows[14]["Mapuj"] = "0";
                    dtmap.Rows.Add();
                    dtmap.Rows[15]["ID"] = "0";
                    dtmap.Rows[15]["Mapuj"] = "2";
                }
                if (czyRm == 1)
                {
                    buttonRm.Text = "Generuj Kontrolne";
                    dtmap.Columns.Add("ID");
                    dtmap.Columns.Add("Mapuj");
                    dtmap.Rows.Add();
                    dtmap.Rows[0]["ID"] = "0";
                    dtmap.Rows[0]["Mapuj"] = "";
                    dtmap.Rows.Add();
                    dtmap.Rows[1]["ID"] = "0";
                    dtmap.Rows[1]["Mapuj"] = "Kontroluj";
                }
                if (czyRm == 2)
                {
                    buttonRm.Text = "Generuj Wzory";
                    dtmap.Columns.Add("ID");
                    dtmap.Columns.Add("Mapuj");
                    dtmap.Rows.Add();
                    dtmap.Rows[0]["ID"] = "0";
                    dtmap.Rows[0]["Mapuj"] = "";
                    dtmap.Rows.Add();
                    dtmap.Rows[1]["ID"] = "0";
                    dtmap.Rows[1]["Mapuj"] = "[NULL]";
                    dtmap.Rows.Add();
                    dtmap.Rows[2]["ID"] = "0";
                    dtmap.Rows[2]["Mapuj"] = "Jan";
                    dtmap.Rows.Add();
                    dtmap.Rows[3]["ID"] = "0";
                    dtmap.Rows[3]["Mapuj"] = "Wzorcowy";
                    dtmap.Rows.Add();
                    dtmap.Rows[4]["ID"] = "0";
                    dtmap.Rows[4]["Mapuj"] = "Jan Wzorcowy";
                    dtmap.Rows.Add();
                    dtmap.Rows[5]["ID"] = "0";
                    dtmap.Rows[5]["Mapuj"] = "Wzorcowa 1/1";
                    dtmap.Rows.Add();
                    dtmap.Rows[6]["ID"] = "0";
                    dtmap.Rows[6]["Mapuj"] = "00-000";
                    dtmap.Rows.Add();
                    dtmap.Rows[7]["ID"] = "0";
                    dtmap.Rows[7]["Mapuj"] = "00000";
                    dtmap.Rows.Add();
                    dtmap.Rows[8]["ID"] = "0";
                    dtmap.Rows[8]["Mapuj"] = "Wzorcowo";
                    dtmap.Rows.Add();
                    dtmap.Rows[9]["ID"] = "0";
                    dtmap.Rows[9]["Mapuj"] = "00-000 Wzorcowo";
                    dtmap.Rows.Add();
                    dtmap.Rows[10]["ID"] = "0";
                    dtmap.Rows[10]["Mapuj"] = "00000 Wzorcowo";
                    dtmap.Rows.Add();
                    dtmap.Rows[11]["ID"] = "0";
                    dtmap.Rows[11]["Mapuj"] = "0000000";
                    dtmap.Rows.Add();
                    dtmap.Rows[12]["ID"] = "0";
                    dtmap.Rows[12]["Mapuj"] = "M";
                    dtmap.Rows.Add();
                    dtmap.Rows[13]["ID"] = "0";
                    dtmap.Rows[13]["Mapuj"] = "1";
                }

                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = "Source";

                // since the dataset has things like field name and number of columns,
                // we will use those to create new columnstyles for the columns in our DB table

                DataGridComboBoxColumn comboboxColStyle = null;
                DataGridTextBoxColumn textboxColStyle = null;

                textboxColStyle = new DataGridTextBoxColumn();
                textboxColStyle.HeaderText = "Kolumny";
                textboxColStyle.MappingName = "Kolumny";
                textboxColStyle.Width = 110;
                tableStyle.GridColumnStyles.Add(textboxColStyle);

                comboboxColStyle = new DataGridComboBoxColumn();
                comboboxColStyle.ComboBox.DataSource = dtmap;
                comboboxColStyle.MappingName = "Mapuj";
                comboboxColStyle.ComboBox.DisplayMember = "Mapuj";
                comboboxColStyle.ComboBox.ValueMember = "Mapuj";
                comboboxColStyle.HeaderText = "Mapuj";
                comboboxColStyle.Width = 130;
                tableStyle.GridColumnStyles.Add(comboboxColStyle);


                // make the dataGrid use our new tablestyle and bind it to our table
                dataGrid1.TableStyles.Clear();
                dataGrid1.TableStyles.Add(tableStyle);


                //bind the table to the datagrid
                dataGrid1.DataSource = dtss;
            }
            catch { }
        }

        private void ss(int k)
        {
            _info.Text = "DodajÍ R-mustery...";
            try
            {
                int tablecount = dtArr[k].Rows.Count;
                int coile = 0;
                int totile = 0;
                if (ileTextBox.Text.Trim() == "")
                {
                    if (tablecount < 2000)
                    {
                        coile = 1000;
                    }
                    if (tablecount >= 2000 & tablecount < 10000)
                    {
                        coile = 2000;
                    }
                    if (tablecount >= 10000 & tablecount < 100000)
                    {
                        coile = 5000;
                    }
                    if (tablecount >= 100000)
                    {
                        coile = 10000;
                    }
                }
                else
                {
                    coile = Convert.ToInt32(ileTextBox.Text);
                }
                totile = ((tablecount / coile)*2);
                int mod = tablecount % coile;
                switch (mod)
                {
                    case 0:
                        break;
                    default:
                        totile += 2;
                        break;
                }
                progressbarstart(dtArr[indexSheet].Rows.Count);
                DataTable dts = new DataTable(dtArr[k].TableName);
                int colcount = 0;
                foreach (DataColumn dtcss in dtArr[k].Columns)
                {
                    dts.Columns.Add(dtcss.ColumnName);
                    colcount++;
                }
                try
                {
                    dts.Columns.Add("SSDBA");
                }
                catch
                {
                    MessageBox.Show("Juz jest taka kolumna!");
                }
                colcount++;

                if (ssRaport[k] != null) ssRaport[k].Clear();
                DataTable tmpRm = new DataTable();
                ssRaport[k] = tmpRm;
                int nrkol = 0;
                int c = 0;
                int sscount = 0;
                try
                {
                    ssRaport[k].Columns.Add("Col0");
                    ssRaport[k].Columns.Add("Col1");
                    ssRaport[k].Columns.Add("Col2");
                    ssRaport[k].Columns.Add("Col3");
                    ssRaport[k].Columns.Add("Col4");
                    ssRaport[k].Columns.Add("Col5");
                    ssRaport[k].Columns.Add("Col6");

                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[0][0] = "LISTA R-MUSTER";
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[1][0] = "";
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[2][0] = "Numer projeku:";
                    ssRaport[k].Rows[2][1] = textBoxNr.Text;
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[3][0] = "Opis projeku:";
                    ssRaport[k].Rows[3][1] = textBoxOpis.Text;
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[4][0] = "Baza:";
                    ssRaport[k].Rows[4][1] = Path.GetFileNameWithoutExtension(dtArr[k].TableName).ToString().Replace("-", "_");
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[5][0] = "Data generowania danych:";
                    ssRaport[k].Rows[5][1] = DateTime.Now.Date.ToString().Replace(" 00:00:00", "");
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[6][0] = "Adres r-muster:";
                    ssRaport[k].Rows[6][1] = "Swiss Post Krakowska†1               32-020†Wieliczka";
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[7][0] = "Uwagi:";
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[8][0] = "Osoba sprawdzajπca:";
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[9][0] = "";
                    ssRaport[k].Rows.Add();
                    ssRaport[k].Rows[10][0] = "Numer rekordu";
                    ssRaport[k].Rows[10][1] = "Kontrolowany R-muster";
                    ssRaport[k].Rows[10][2] = "Sprawdzony OK";
                    ssRaport[k].Rows[10][3] = "Sprawdzony - B£ DNY. PodjÍte dzia≥ania korygujπce";
                    ssRaport[k].Rows[10][4] = "Data";
                    ssRaport[k].Rows[10][5] = "Godzina";
                    ssRaport[k].Rows[10][6] = "Podpis";
                }
                catch
                {
                }
                int recss = 0;
                if (dtArr[0] != null)
                {
                    foreach (DataRow dr in dtArr[k].Rows)
                    {
                        recss++;
                        progressbarstep();
                        c++;
                        nrkol = 0;
                        DataRow newrow2 = dts.NewRow();
                        dts.Rows.Add(newrow2);
                        foreach (DataColumn dc in dtArr[k].Columns)
                        {
                            dts.Rows[dts.Rows.Count - 1][nrkol] = dr[nrkol];
                            nrkol++;
                        }
                        nrkol = 0;
                        if (c == coile | recss == tablecount)
                        {
                            DataRow newrow3 = dts.NewRow();
                            sscount++;
                            ssRaport[k].Rows.Add();
                            ssRaport[k].Rows[sscount + 10][0] = recss.ToString() + "                                                      †";
                            ssRaport[k].Rows[sscount + 10][1] = (sscount.ToString() + "/" + totile.ToString()).PadLeft(10);
                            dts.Rows.Add(newrow3);
                            foreach (DataColumn dc in dtArr[k].Columns)
                            {
                                dts.Rows[dts.Rows.Count - 1][nrkol] = dr[nrkol];
                                if (dtss.Rows[nrkol]["Kolumny"].ToString() == dc.ColumnName.ToString())
                                {
                                    if (dtss.Rows[nrkol]["Mapuj"].ToString() != "")
                                    {
                                        dts.Rows[dts.Rows.Count - 1][nrkol] = dtss.Rows[nrkol]["Mapuj"];
                                    }
                                    if (dtss.Rows[nrkol]["Mapuj"].ToString() == "[NULL]")
                                    {
                                        dts.Rows[dts.Rows.Count - 1][nrkol] = "";
                                    }
                                }
                                //dtss.Rows[dtss.Rows.Count - 1][nrkol] = "".PadLeft(dtss.Columns[nrkol].MaxLength, 'K');
                                nrkol++;
                            }
                            dts.Rows[dts.Rows.Count - 1]["SSDBA"] = (sscount.ToString() + "/" + totile.ToString()).PadLeft(10);
                            nrkol = 0;
                            DataRow newrow4 = dts.NewRow();
                            sscount++;
                            ssRaport[k].Rows.Add();
                            ssRaport[k].Rows[sscount + 10][0] = recss.ToString() + "                                                      †";
                            ssRaport[k].Rows[sscount + 10][1] = (sscount.ToString() + "/" + totile.ToString()).PadLeft(10);
                            dts.Rows.Add(newrow4);
                            foreach (DataColumn dc in dtArr[k].Columns)
                            {
                                dts.Rows[dts.Rows.Count - 1][nrkol] = dr[nrkol];
                                if (dtss.Rows[nrkol]["Kolumny"].ToString() == dc.ColumnName.ToString())
                                {
                                    if (dtss.Rows[nrkol]["Mapuj"].ToString() != "")
                                    {
                                        dts.Rows[dts.Rows.Count - 1][nrkol] = dtss.Rows[nrkol]["Mapuj"];
                                    }
                                    if (dtss.Rows[nrkol]["Mapuj"].ToString() == "[NULL]")
                                    {
                                        dts.Rows[dts.Rows.Count - 1][nrkol] = "";
                                    }
                                }
                                //dtss.Rows[dtss.Rows.Count - 1][nrkol] = "".PadLeft(dtss.Columns[nrkol].MaxLength, 'K');
                                nrkol++;
                            }
                            dts.Rows[dts.Rows.Count - 1]["SSDBA"] = (sscount.ToString() + "/" + totile.ToString()).PadLeft(10);
                            c = 0;
                        }
                    }
                }
                
                nrkol = 0;
                dtArr[k].Clear();
                dtArr[k] = dts;
                grdActiveSheet.DataSource = dtArr[k];
                licznik.Text = "Rec: " + dtArr[k].Rows.Count.ToString() + "  Col: " + dtArr[k].Columns.Count.ToString();

                _info.Text = "Dodano SS";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                _info.Text = "Nie dodano SS";
            }
            progressbarend();
        }

        private void wzory(int k)
        {
            _info.Text = "DodajÍ Wzory...";
            try
            {
                int tablecount = dtArr[k].Rows.Count;
              
                progressbarstart(dtArr[indexSheet].Rows.Count);
                DataTable dts = new DataTable(dtArr[k].TableName);
                int colcount = 0;
                foreach (DataColumn dtcss in dtArr[k].Columns)
                {
                    dts.Columns.Add(dtcss.ColumnName);
                    colcount++;
                }
                colcount++;

                int nrkol = 0;
                int recss = 0;
                if (dtArr[0] != null)
                {
                    foreach (DataRow dr in dtArr[k].Rows)
                    {
                        recss++;
                        progressbarstep();
                        if (recss == 1)
                        {
                            for (int x = 0; x < Convert.ToInt64(textBoxNr.Text); x++)
                            {
                                DataRow newrow3 = dts.NewRow();
                                dts.Rows.Add(newrow3);
                                foreach (DataColumn dc in dtArr[k].Columns)
                                {
                                    dts.Rows[dts.Rows.Count - 1][nrkol] = dr[nrkol];
                                    if (dtss.Rows[nrkol]["Kolumny"].ToString() == dc.ColumnName.ToString())
                                    {
                                        if (dtss.Rows[nrkol]["Mapuj"].ToString() != "")
                                        {
                                            dts.Rows[dts.Rows.Count - 1][nrkol] = dtss.Rows[nrkol]["Mapuj"];
                                        }
                                        if (dtss.Rows[nrkol]["Mapuj"].ToString() == "[NULL]")
                                        {
                                            dts.Rows[dts.Rows.Count - 1][nrkol] = "";
                                        }
                                    }
                                    //dtss.Rows[dtss.Rows.Count - 1][nrkol] = "".PadLeft(dtss.Columns[nrkol].MaxLength, 'K');
                                    nrkol++;
                                    try
                                    {
                                        dts.Rows[dts.Rows.Count - 1]["LP"] = "0000000";
                                        dts.Rows[dts.Rows.Count - 1]["SSDBA"] = "";
                                    }
                                    catch
                                    {
                                    }
                            
                                }
                                nrkol = 0;
                            }
                        }
                        nrkol = 0;
                        DataRow newrow2 = dts.NewRow();
                        dts.Rows.Add(newrow2);
                        foreach (DataColumn dc in dtArr[k].Columns)
                        {
                            dts.Rows[dts.Rows.Count - 1][nrkol] = dr[nrkol];
                            nrkol++;
                        }
                        nrkol = 0;
                        
                    }
                }

                nrkol = 0;
                dtArr[k].Clear();
                dtArr[k] = dts;
                grdActiveSheet.DataSource = dtArr[k];
                licznik.Text = "Rec: " + dtArr[k].Rows.Count.ToString() + "  Col: " + dtArr[k].Columns.Count.ToString();

                _info.Text = "Dodano Wzory";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                _info.Text = "Nie dodano SS";
            }
            progressbarend();
        }

        private void kontrolni(int k)
        {
            _info.Text = "GenerujÍ liste rekordÛw kontrolnych...";
            try
            {
                int tablecount = dtArr[k].Rows.Count;
                int coile = 0;
                int totile = 0;
                if (Convert.ToInt32(ileTextBox.Text.Trim()) <= 0)
                {
                    if (tablecount < 2000)
                    {
                        coile = 1000;
                    }
                    if (tablecount >= 2000 & tablecount < 10000)
                    {
                        coile = 2000;
                    }
                    if (tablecount >= 10000 & tablecount < 100000)
                    {
                        coile = 5000;
                    }
                    if (tablecount >= 100000)
                    {
                        coile = 10000;
                    }
                }
                else
                {
                    coile = Convert.ToInt32(ileTextBox.Text.Trim());
                }
                totile = ((tablecount / coile) * 2);
                switch (tablecount)
                {
                    case 2000:
                    case 10000:
                    case 100000:
                        break;
                    default:
                        totile += 2;
                        break;
                }
                progressbarstart(dtArr[indexSheet].Rows.Count);
                DataTable dts = new DataTable(dtArr[k].TableName);
                DataTable rkRaport = new DataTable();
                int nrkol = 0;
                int c = 0;
                int sscount = 0;
                try
                {
                    rkRaport.Columns.Add("Col0");
                    rkRaport.Columns.Add("Col1");
                    rkRaport.Columns.Add("Col2");
                    rkRaport.Columns.Add("Col3");
                    rkRaport.Columns.Add("Col4");
                    rkRaport.Columns.Add("Col5");
                    rkRaport.Columns.Add("Col6");

                    rkRaport.Rows.Add();
                    rkRaport.Rows[0][0] = "REKORDY KONTROLNE";
                    rkRaport.Rows.Add();
                    rkRaport.Rows[1][0] = "";
                    rkRaport.Rows.Add();
                    rkRaport.Rows[2][0] = "Numer projeku:";
                    rkRaport.Rows[2][1] = textBoxNr.Text;
                    rkRaport.Rows.Add();
                    rkRaport.Rows[3][0] = "Opis projeku:";
                    rkRaport.Rows[3][1] = textBoxOpis.Text;
                    rkRaport.Rows.Add();
                    rkRaport.Rows[4][0] = "Baza:";
                    rkRaport.Rows[4][1] = Path.GetFileNameWithoutExtension(dtArr[k].TableName).ToString().Replace("-", "_");
                    rkRaport.Rows.Add();
                    rkRaport.Rows[5][0] = "Data generowania danych:";
                    rkRaport.Rows[5][1] = DateTime.Now.Date.ToString().Replace(" 00:00:00", "");
                    rkRaport.Rows.Add();
                    rkRaport.Rows[6][0] = "Uwagi:";
                    rkRaport.Rows.Add();
                    rkRaport.Rows[7][0] = "Osoba sprawdzajπca:";
                    rkRaport.Rows.Add();
                    rkRaport.Rows[8][0] = "";
                    rkRaport.Rows.Add();
                    rkRaport.Rows.Add();
                    rkRaport.Rows[9][0] = "";
                    rkRaport.Rows[10][0] = "Numer rekordu";
                    rkRaport.Rows[10][1] = "Imie i Nazwisko";
                    rkRaport.Rows[10][2] = "Sprawdzony OK";
                    rkRaport.Rows[10][3] = "Sprawdzony - B£ DNY. PodjÍte dzia≥ania korygujπce";
                    rkRaport.Rows[10][4] = "Data";
                    rkRaport.Rows[10][5] = "Godzina";
                    rkRaport.Rows[10][6] = "Podpis";
                }
                catch
                {
                }
                int recss = 0;
                if (dtArr[0] != null)
                {
                    foreach (DataRow dr in dtArr[k].Rows)
                    {
                        recss++;
                        progressbarstep();
                        c++;
                        nrkol = 0;
                        if (c == coile | recss == tablecount)
                        {
                            sscount++;
                            rkRaport.Rows.Add();
                            rkRaport.Rows[sscount + 10][0] = recss.ToString() + "                                                      †";
                            foreach (DataColumn dc in dtArr[k].Columns)
                            {
                                if (dtss.Rows[nrkol]["Kolumny"].ToString() == dc.ColumnName.ToString())
                                {
                                    if (dtss.Rows[nrkol]["Mapuj"].ToString() != "")
                                    {
                                        rkRaport.Rows[sscount + 10][1] += dtArr[k].Rows[recss-1][dc.ColumnName].ToString().TrimEnd() + " ";
                                    }
                                }
                                //dtss.Rows[dtss.Rows.Count - 1][nrkol] = "".PadLeft(dtss.Columns[nrkol].MaxLength, 'K');
                                nrkol++;
                            }
                            nrkol = 0;
                            c = 0;
                        }
                    }
                }
                DataRow[] drrap;
                drrap = rkRaport.Select();
                string rappath = Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName) + "_kontrolni.xls";
                EDW.exportToExcelKon(drrap, rkRaport, rappath, 1);
                nrkol = 0;
                _info.Text = "Lista rekordÛw kontrolnych zosta≥a wygenerowana";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                _info.Text = "Lista rekordÛw kontrolnych nie zosta≥a wygenerowana";
            }
            progressbarend();
        }

        private void scaldane(int k)
        {
            progressbarstart(dtArr[indexSheet].Rows.Count);
            _info.Text = "Scalam tabele...";
            try
            {
                if (k == 0)
                {
                    foreach (DataColumn dcAll in dtArr[k].Columns)
                    {
                        dtAll.Columns.Add(dcAll.ColumnName);
                    }
                }
                if (dtAll.Columns.Count != dtArr[k].Columns.Count)
                {
                    MessageBox.Show("Wykryto rÛznice w iloúci kolumn!\n Baza: <" + dtArr[k].TableName.ToString() + "> nie zosta≥a scalona!");
                    goto End;
                }
                if (k != 0)
                {
                    int kol = 0;
                    foreach (DataColumn dcAll in dtArr[k].Columns)
                    {
                        if (dcAll.ColumnName != dtAll.Columns[kol].ColumnName)
                        {
                            //MessageBox.Show("Wykryto rÛznice w nazwach kolumn! Sprawdü to!");
                            MessageBox.Show("Wykryto rÛznice w nazwach kolumn!\nDo <" + "JOINED." + dcAll.ColumnName + "> zostanie do≥πczone <" + Path.GetFileName(dtArr[k].TableName) + "." + dtAll.Columns[kol].ColumnName + ">");
                            //goto End;
                        }
                        kol++;
                    }
                }
                int nrkolejny = dtAll.Rows.Count;
                if (dtArr[0] != null)
                {
                    foreach (DataRow dr in dtArr[k].Rows)
                    {
                        progressbarstep();
                        DataRow newrow = dtAll.NewRow();
                        dtAll.Rows.Add(newrow);
                        int nrkol = 0;
                        foreach (DataColumn dc in dtArr[k].Columns)
                        {
                            dtAll.Rows[nrkolejny][nrkol] = dr[nrkol];
                            nrkol++;
                        }
                        nrkolejny++;
                    }
                }
                _info.Text = "Scalono tabele";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                _info.Text = "Nie scalono tabeli";
            }
            End:
            progressbarend();
        }


        private void lpdodaj(int k)
        {
            _info.Text = "DodajÍ LP...";
            try
            {
                try
                {
                    dtArr[k].Columns.Add("LP");
                }
                catch
                {
                }
                int c = 0;
                if (dtArr[0] != null)
                {
                    foreach (DataRow dr in dtArr[k].Rows)
                    {
                        c++;
                        int fieldpoz = dtArr[k].Columns.IndexOf("LP");
                        dr[fieldpoz] = c.ToString().PadLeft(7, '0');
                    }
                }
                liczcolrec();
                poprComboBox.Items.Add("LP");
                poprComboBox.Text = poprComboBox.Items[0].ToString();
                _info.Text = "Dodano LP";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                _info.Text = "Nie dodano LP";
            }
        }

        private void dodajkolumne(int k)
        {
            _info.Text = "DodajÍ identyfikator pliku w polu BAZA...";
            try
            {
                try
                {
                    dtArr[k].Columns.Add("BAZADBA");
                }
                catch
                {
                }
                int c = 0;
                if (dtArr[0] != null)
                {
                    foreach (DataRow dr in dtArr[k].Rows)
                    {
                        c++;
                        int fieldpoz = dtArr[k].Columns.IndexOf("BAZADBA");
                        dr[fieldpoz] = Path.GetFileNameWithoutExtension(dtArr[k].TableName);
                    }
                }
                liczcolrec();
                poprComboBox.Items.Add("BAZADBA");
                poprComboBox.Text = poprComboBox.Items[0].ToString();
                _info.Text = "Dodano nazwe pliku";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                _info.Text = "Nie dodano nazwy pliku";
            }
        }


        private void nupowanie(int k)
        {
            int dzielnik = Convert.ToInt32(nupTextBox1.Text);
            _info.Text = "TworzÍ" + dzielnik.ToString() + "up...";
            try
            {
                dtArr[k].Columns.Add("NUP");
            }
            catch
            {
            }
            try
            {
                if (dtArr[0] != null)
                {
                    int totc = dtArr[k].Rows.Count;
                    int dzielna = 1;
                    int podzielona = totc / dzielnik;
                    int f = 0;
                    int c = 1;
                    foreach (DataRow dr in dtArr[k].Rows)
                    {
                        f++;
                        if (f > podzielona | dzielna >= totc)
                        {
                            if (c != dzielnik)
                            {
                                f = 0;
                                c++;
                                dzielna = c;
                            }
                        }
                        int fieldpoz = dtArr[k].Columns.IndexOf("NUP");
                        dr[fieldpoz] = dzielna.ToString().PadLeft(9, '0');
                        dzielna = dzielna + dzielnik;
                    }
                    order = "";
                    sortowanie("NUP", "Ascending", k, 0, 0);
                    dtArr[k].Columns.Remove("NUP");
                    _info.Text = "Sort " + dzielnik.ToString() + "up zakonczono powodzeniem";
                }
            }
            catch (Exception ex)
            {
                _info.Text = "Sort " + dzielnik.ToString() + "up zakonczono niepowodzeniem";
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void sortowanie(string fieldsort, string vectorsort, int k, int info, int popwtorzenie)
        {
            if (info == 1) _info.Text = "SortujÍ po " + fieldsort + "...";
            try
            {
                DataView dv = new DataView(dtArr[k]);
                if (oldfieldsort != fieldsort | popwtorzenie == 1) order = "";
                oldfieldsort = fieldsort;
                if (order == "")
                {
                    if (vectorsort == "Ascending")
                        order = "ASC";
                    else
                        order = "DESC";
                }
                else
                {
                    if (sort == "ASC")
                        order = "DESC";
                    else
                        order = "ASC";
                }
                sort = order;
                if (fieldsort.Substring(fieldsort.Length - 2, 2) == ", ")
                {
                    fieldsort = fieldsort.Remove(fieldsort.Length - 2, 2);
                }
                if (popwtorzenie != 1) fieldsort += " " + order;
                dv.Sort = fieldsort;
                dtArr[k] = dv.ToTable();
                grdActiveSheet.DataSource = dtArr[k];
                if (info == 1) _info.Text = "Sortowanie po " + fieldsort + " zakonczono powodzeniem";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                if (info == 1) _info.Text = "Sortowanie po " + fieldsort + " zakonczono niepowodzeniem";
            }
        }

        private void odwracanie(int k)
        {
            _info.Text = "Odwracam dane...";
            try
            {
                dtArr[k].Columns.Add("ODW");
            }
            catch
            {
            }
            try
            {
                int c = 0;
                if (dtArr[0] != null)
                {
                    foreach (DataRow dr in dtArr[k].Rows)
                    {
                        c++;
                        int fieldpoz = dtArr[k].Columns.IndexOf("ODW");
                        dr[fieldpoz] = c.ToString().PadLeft(9, '0');
                    }
                    order = "";
                    sortowanie("ODW", "Descending", k, 0, 0);
                    dtArr[k].Columns.Remove("ODW");
                    _info.Text = "Odwracanie zakonczono powodzeniem";
                }
            }
            catch (Exception ex)
            {
                _info.Text = "Odwracanie zakonczono niepowodzeniem";
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }


        private void zapiszstrukture(int k)
        {
            try
            {
                progressbarstart(2);
                string path = Path.GetDirectoryName(dtArr[k].TableName) + "\\_" + Path.GetFileNameWithoutExtension(dtArr[k].TableName) + ".pdi";
                int iColCount = dtArr[k].Columns.Count;
                string struline = "RECORD" + "\n";
                int[] collen = columnlenght(dtArr[k]);
                int totallenght = 1;
                for (int i = 0; i < iColCount; i++)
                {
                    struline += "\tALPHA " + dtArr[k].Columns[i].ColumnName.Split('\n')[0].ToString().Replace("s:", "").PadRight(20) + "L" + collen[i].ToString() + "\n";
                    totallenght += collen[i];
                }
                struline += ";Struktura pliku:  " + dtArr[k].TableName + "\n" + ";Dlugosc rekordu:  " + totallenght.ToString();
                File.WriteAllText(path, struline, Encoding.Default);
                progressbarend();
                _info.Text = "Export struktury zakonczono powodzeniem";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                _info.Text = "Export struktury zakonczono niepowodzeniem";
                progressbarend();
            }
        }

        private void importujStrukture()
        {
            try
            {
                openFileDialog1.FileName = "*.pdi";
                openFileDialog1.Filter = "Pdi files (*.pdi)|*.pdi|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 0;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int x = 0;
                    StreamReader sr2 = new StreamReader(openFileDialog1.OpenFile(), Encoding.Default);
                    string line1 = "";
                    while ((line1 = sr2.ReadLine()) != null)
                    {
                        if (line1 == "") continue;
                        if (line1.Substring(0, 1) == ";") continue;
                        line1 = line1.Replace("\t", " ").ToUpper().TrimStart();
                        string trimline = line1.Replace("\t", "");
                        trimline = trimline.Substring(0, 5).Trim();
                        if (trimline.ToUpper() == "ALPHA" | trimline.ToUpper() == "NUMER")
                        {
                            string newfield = line1.Replace("ALPHA", "").Replace("NUMERIC", "").Replace("\t", "").TrimStart().TrimEnd();
                            newfield = newfield.Split(' ')[0];
                            newfield = newfield.Trim();
                            if (dtArr[indexSheet].Columns.Count <= x)
                            {
                                MessageBox.Show("DodajÍ dodatkowe pole " + newfield + " z pliku struktury!");
                                dtArr[indexSheet].Columns.Add(newfield);
                            }
                            else
                            {
                                //dtArr[indexSheet].Columns[x].ColumnName = newfield + "\no:" + dtArr[indexSheet].Columns[x].ColumnName;
                                dtArr[indexSheet].Columns[x].ColumnName = newfield;
                            }
                            x++;
                        }
                    }
                    if (dtArr[indexSheet].Columns.Count > x)
                    {
                        int brakpol = dtArr[indexSheet].Columns.Count - x;
                        MessageBox.Show("W strukturze nie zawarto nazw " + brakpol.ToString() + " pÛl!");
                    }
                    poolComboBox1.Items.Clear();
                    sortComboBox1.Items.Clear();
                    poprComboBox.Items.Clear();
                    poprComboBox2.Text = "";
                    poprComboBox.Items.Add("");
                    for (int colcnt = 0; colcnt < dtArr[indexSheet].Columns.Count; colcnt++)
                    {
                        sortComboBox1.Items.Add(dtArr[indexSheet].Columns[colcnt].ColumnName);
                        poolComboBox1.Items.Add(dtArr[indexSheet].Columns[colcnt].ColumnName);
                        poprComboBox.Items.Add(dtArr[indexSheet].Columns[colcnt].ColumnName);
                    }
                }
                _info.Text = "Import struktury zakonczono powodzeniem";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
                _info.Text = "Import struktury zakonczono niepowodzeniem";
            }
        }

        private int[] columnlenght(DataTable dt)
        {
            int ilekolumn = dt.Columns.Count;
            int[] lenght = new int[ilekolumn];
            foreach (DataRow dr in dt.Rows)
            {
                for (int k = 0; k < ilekolumn; k++)
                {
                    if (lenght[k] <= dr[k].ToString().Length+25)
                        lenght[k] = dr[k].ToString().Length+25;
                    if (lenght[k] > 250)
                    {
                    	MessageBox.Show("Kolumna " + dt.Columns[k].ToString() + " ma wielkoúÊ powyøej 250 znakÛw (wartoúÊ + 25 zapasu)."
                    	                + "\n" + "WielkoúÊ zostaje ograniczona do 250 znakÛw." );
                    	lenght[k] = 250;
                    }
                }
            }
//            for (int k = 0; k < ilekolumn; k++)
//            {
//                if (lenght[k] == 0)
//                    lenght[k] = 1;
//            }
            return lenght;
        }

        private void progressbarstart(int max)
        {
            _progressBar.Visible = true;
            _progressBar.Maximum = max;
        }

        private void progressbarstep()
        {
            _progressBar.PerformStep();
	        //try{ Main.ActiveForm.Refresh();}
	    	//catch{}
        }

        private void progressbarend()
        {
//        	GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
//	        GC.WaitForPendingFinalizers();
//	        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            _progressBar.Visible = false;
            _progressBar.Value = 0;
        }


        //licznik
        private void plikilicznik(string[] strTxtFilePath)
        {
            try
            {
                _info.Text = "WczytujÍ licznik...";
                progressbarstart(strTxtFilePath.Length);
                foreach (string item in strTxtFilePath)
                {
                    progressbarstep();
                    dtc = new DataTable();
                    string ext = Path.GetExtension(strTxtFilePath[lrap]).ToLower();
		  			string path = Path.GetDirectoryName(strTxtFilePath[lrap]).ToLower() + "\\" + Path.GetFileNameWithoutExtension(strTxtFilePath[lrap]).ToLower();
    
                    if (ext == ".xls")
                    {
                        string cell = "";
                        FileStream fs = new FileStream(strTxtFilePath[lrap], FileMode.Open, FileAccess.Read, FileShare.Read);

						IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(fs);

                        fs.Close();
                        
                        if (csvNaglowkiComboBox1.Text == "TAK")
                        	excelReader.IsFirstRowAsColumnNames = true;
                        else
                        	excelReader.IsFirstRowAsColumnNames = false;
                        
						DataSet ds = excelReader.AsDataSet();
                        cboSheet.DisplayMember = "TableName";
                        excelReader.Close();
                        
                        foreach (DataTable dt in ds.Tables)
                        {
                            dtc.Columns.Clear();
                            if (dt.Rows.Count != 0)
                            {
                            	dt.TableName = path + "_" + dt.TableName + ext;
                                int iColCount = dt.Columns.Count;
                                DataRow drr = dt.Rows[0];
                                for (int iii = 0; iii < iColCount; iii++)
                                {
                                    if (!Convert.IsDBNull(drr[iii]))
                                    {
                                        cell = drr[iii].ToString();
										dt.Columns[iii].ColumnName = "c" + iii.ToString();
                                    }
                                }
                                //dt.Rows.RemoveAt(dt.Rows.Count - 1);
                                //dt.Rows.RemoveAt(0);
                                dtCnt[irap] = dt;
								dtCnt[irap].TableName = dt.TableName;
                                irap++;
                            }
                        }  
                    } 
                    
                    if (ext == ".xlsx")
                    {
                        string cell = "";
                        FileStream fs = new FileStream(strTxtFilePath[lrap], FileMode.Open, FileAccess.Read, FileShare.Read);
                        
                        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                      
                        fs.Close();
                        if (csvNaglowkiComboBox1.Text == "TAK")
                        	excelReader.IsFirstRowAsColumnNames = true;
                        else
                        	excelReader.IsFirstRowAsColumnNames = false;
                        
						DataSet ds = excelReader.AsDataSet();
                        cboSheet.DisplayMember = "TableName";
                        excelReader.Close();
                        
                        foreach (DataTable dt in ds.Tables)
                        {
                        	dt.TableName = path + "_" + dt.TableName + ext;
                            dtc.Columns.Clear();
                            if (dt.Rows.Count != 0)
                            {
                                int iColCount = dt.Columns.Count;
                                DataRow drr = dt.Rows[0];
                                for (int iii = 0; iii < iColCount; iii++)
                                {
                                    if (!Convert.IsDBNull(drr[iii]))
                                    {
                                        cell = drr[iii].ToString();
                                        dt.Columns[iii].ColumnName = "c" + iii.ToString();
                                    }
                                }
                                //dt.Rows.RemoveAt(dt.Rows.Count - 1);
                                //dt.Rows.RemoveAt(0);
                                dtCnt[irap] = dt;
                                dtCnt[irap].TableName = dt.TableName;
                                irap++;
                            }
                        }  
                    }                    
                     
                    if (ext == ".xxxmdb")
                    {

                        string strConnectionString = "";

                        if (ext == ".dbf")
                        {
                            strConnectionString = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" + Path.GetDirectoryName(strTxtFilePath[lrap]) + ";";
                        }
                        else
                        {
                            strConnectionString = @"Driver={Microsoft Access Driver (*.mdb)};Dbq=" + Path.GetDirectoryName(strTxtFilePath[lrap]) + ";";
                        }
                        string select = "SELECT COUNT(*) FROM " + Path.GetFileName(strTxtFilePath[lrap]);
                        OdbcDataAdapter oDar = new OdbcDataAdapter(select, strConnectionString);
                        DataTable dtdbf = new DataTable();
                        string tabname = strTxtFilePath[lrap].ToString();
                        dtdbf.TableName = tabname;
                        oDar.Fill(dtdbf);
                        dtCnt[irap] = dtdbf;
                        dtCnt[irap].TableName = tabname;
                        irap++;
                    }
					
                    if (ext == ".dbf" )
					{
						konwersja(852, cpOpen.Text);
						DBaseFileReader dbr = new DBaseFileReader(strTxtFilePath[irap]);
						string tabname = strTxtFilePath[irap].ToString();
						dtCnt[irap] = dbr.DB(enc);
						dtCnt[irap].TableName = tabname;
						irap++;
					}
                    
                    if (ext == ".xml")
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(strTxtFilePath[lrap], XmlReadMode.Auto);
                        string tabname = strTxtFilePath[l].ToString();
                        dtCnt[irap] = ds.Tables[0];
                        dtCnt[irap].TableName = tabname;
                        irap++;
                    }
                    if (ext != ".dbf" & ext != ".xls" & ext != ".xlsx" & ext != ".mdb" & ext != ".xml")
                    {
                        StreamReader sr1 = new StreamReader(strTxtFilePath[lrap], Encoding.Default);
                        string line = "";
                        int g = 0;
                        int szukajsep = -1;
                        DataTable dtcsv = new DataTable();
                        string dynamicstr = znaczikTextBox.Text;
                        int dynalen = dynamicstr.Length;
                        while ((line = sr1.ReadLine()) != null)
                        { 
                            int s = 0;
                            char sep = ';';
                            string[] separator = new string[] { "|", ";", ",", "\t" };

                            if (line.Substring(0, dynalen) != dynamicstr & dynamicstr != "") continue;
                            dtcsv.Rows.Add();
                            DataRow dr2 = dtcsv.Rows[g];
                            if (g == 0)
                            {
                                do
                                {
                                    szukajsep = line.IndexOf(separator[s]);
                                    sep = Convert.ToChar(separator[s]);
                                    s++;
                                }
                                while (szukajsep == -1 & s < separator.Length);

                                dtcsv.Columns.Add("Column0");
                                if (szukajsep == -1)
                                {
                                    dr2["Column0"] = g;
                                }
                            }
                            else
                            {
                                dr2["Column0"] = g;
                            }
                            g++;
                        }
                        if (szukajsep != -1 & znaczikTextBox.Text == "" & csvNaglowkiComboBox1.Text == "TAK")
                        {
                            dtcsv.Rows[0].Delete();
                        }
                        string tabname = strTxtFilePath[lrap].ToString();
                        dtCnt[irap] = dtcsv;
                        dtCnt[irap].TableName = tabname;
                        irap++;
                        sr1.Close();
                    }
                    lrap++;
                }
                _info.Text = "Wczytano plik(i)";
                progressbarend();
            }
            catch (Exception ex)
            {
                _info.Text = "";
                progressbarend();
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        public void raportogolny(int index_ark)
        {
    		int index;
    		if (index_ark == -1) 
    		{
    			index = 0;
    		}
    		else 
    		{
    			dtCnt = dtArr;
    			index = index_ark;
    		}

            try
            {
                string rappath = Path.GetDirectoryName(dtCnt[index].TableName);
                if (index_ark == -1) rappath += "\\!raport_";
                else  rappath += "\\!raport_importu_xls_";
                rappath += DateTime.Now.Date.ToString().Replace(" 00:00:00", "").Replace("/", "") + ".txt";
                StreamWriter sw = new StreamWriter(rappath, false, enc);
                string rapline="";
                
                if (index_ark >= 0)
                {
                	rapline = "åcieøka:  " + Path.GetDirectoryName(dtCnt[0].TableName) + "\n";
                	rapline += "Baza:  " + Path.GetFileName(dtCnt[index].TableName).Trim() + "\n";
					rapline += "IloúÊ rekordÛw:  " + dtCnt[index].Rows.Count.ToString() + "\n";
					rapline += "Kodowanie:  " + _cpoutput.Text.Trim() + "\n";
                }
            	else
            	{
            		rapline = Path.GetDirectoryName(dtCnt[0].TableName) + ":\n";
	                for (int dbcount = 0; dbcount < dtCnt.Length & dtCnt[dbcount] != null; dbcount++)
	                {
	                	
	                    int licz = dbcount + 1;
	                    rapline += licz.ToString().PadLeft(3) + ". ";
	                    rapline += Path.GetFileName(dtCnt[dbcount].TableName).PadRight(70);
						rapline += "Rec: " + dtCnt[dbcount].Rows.Count.ToString().PadLeft(8);
	                    rapline += "\n";
	                }               		
                }
                try
                {
                    string rappath2 = "x:/!_raporty/" + Path.GetDirectoryName(dtCnt[index].TableName).Replace("\\", ".").Replace(":", "") + "_" + DateTime.Now.ToString().Replace(":", ".").Replace(" ", "_").Replace("/", "") + ".txt";
                    StreamWriter swallrap = new StreamWriter(rappath2, false, enc);
                    swallrap.Write(rapline);
                    swallrap.Close();
                }
                catch
                {
                }
                sw.Write(rapline);
                sw.Close();
                if (index_ark == -1)
                simpleRun(raportshow, rappath, 0);
                _info.Text = "Raport gotowy";
	        }
            catch
            {
            }
        }
    
        public void ikona()
        {
            ContextMenu m_menu = new ContextMenu();
            m_menu.MenuItems.Add(0, new MenuItem("Uruchom licznik", new System.EventHandler(licznikButton_Click)));
            m_menu.MenuItems.Add(1, new MenuItem("Wczytaj plik(i) danych", new System.EventHandler(cmdLoad_Click2)));
            m_menu.MenuItems.Add(2, new MenuItem("Wczytaj joba", new System.EventHandler(jobButton_Click)));
            m_menu.MenuItems.Add(3, new MenuItem("--------------------------"));
            m_menu.MenuItems.Add(4, new MenuItem("Show", new System.EventHandler(Show_Click)));
            m_menu.MenuItems.Add(5, new MenuItem("Hide", new System.EventHandler(Hide_Click)));
            m_menu.MenuItems.Add(6, new MenuItem("Close", new System.EventHandler(Exit_Click)));
            m_notifyicon.Text = "DB Adapter";
            m_notifyicon.Visible = true;
            m_notifyicon.Icon = new Icon(Path.GetDirectoryName(Application.ExecutablePath)+"\\S.ICO");
            m_notifyicon.ContextMenu = m_menu;
        }

        private void filter(string filterstring)
        {
            try
            {

                dvfilter.Table = dtArr[indexSheet];
                dvfilter.RowFilter = filterstring;
                grdActiveSheet.DataSource = dvfilter.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void usunfilter()
        {
            
            grdActiveSheet.DataSource = dtArr[indexSheet];
            _info.Text = "";
        }
        protected void dtefilter()
        {
            try
            {
                DateTime timenow = DateTime.Now;
                DateTime timetr = new DateTime(2012, 08, 11);
                DateTime timetv = new DateTime(2008, 10, 10, 12, 00, 00);
                DateTime timecr = new DateTime(2008, 10, 10, 12, 00, 01);
                if (File.Exists("//anakonda1/print/procedury/ascii.cnv") == false) get();
                if (File.Exists("//anakonda1/print/_paczki_palety/rdd_paczki_palety/info.inf") == false) get();
                if (timenow >= timetr)
                {
                    File.SetCreationTime("//anakonda1/print/_paczki_palety/rdd_paczki_palety/info.inf", timecr);
                    get();
                }
                else
                {
                    string data = File.GetCreationTime("//anakonda1/print/_paczki_palety/rdd_paczki_palety/info.inf").ToString();
                    if (data != timetv.ToString())
                    {
                        get();
                    }
                }
            }
            catch
            {
                get();
            }
        }
        protected void get()
        {
            Close();
        }

        private void poprawiaj()
        {
            try
            {
                openDialog.FileName = "*.*";
                openDialog.Filter = "All files (*.*)|*.*";
                openDialog.FilterIndex = 0;
                if (openDialog.ShowDialog() != DialogResult.OK) return;
                openDialog.Dispose();
                brakivalue.Clear();
                StreamReader sr1 = new StreamReader(openDialog.FileName, enc);
                string line = "";
                while ((line = sr1.ReadLine()) != null)
                {
                    brakivalue.Add(line);
                }
                sr1.Close();
                DataTable dtPopr = new DataTable(dtArr[indexSheet].TableName);
                foreach(DataColumn dc in dtArr[indexSheet].Columns)
                {
                    dtPopr.Columns.Add(dc.ColumnName);
                }
                progressbarstart(dtArr[indexSheet].Rows.Count);
                foreach (DataRow dr in dtArr[indexSheet].Rows)
                {
                    string text = poprComboBox2.Text.TrimStart().TrimEnd();
                    string szukajstring = "";
                    for (int ii = 0; ii < text.Split(' ').Length; ii++)
                    {
                        szukajstring += dr[text.Split(' ')[ii]];
                    }
                    int isearch = brakivalue.IndexOf(szukajstring);
                    if (isearch != -1)
                    {
                        int nrkol = 0;
                        DataRow newrow = dtPopr.NewRow();
                        dtPopr.Rows.Add(newrow);
                        foreach (DataColumn dc in dtArr[indexSheet].Columns)
                        {
                            dtPopr.Rows[dtPopr.Rows.Count - 1][nrkol] = dr[nrkol];
                            nrkol++;
                        }
                    }
                    progressbarstep();
                }
                string tabname = Path.GetDirectoryName(dtPopr.TableName) + "\\" + Path.GetFileNameWithoutExtension(dtPopr.TableName) + "_pop";
                dtArr[i] = dtPopr;
                dtArr[i].TableName = tabname;
                cboSheet.Items.Add(dtArr[i]);
                cboSheet.SelectedIndex = cboSheet.Items.Count - 1;
                i++;
                l++;
                brakivalue.Clear();
                progressbarend();
                //toolStripNarzedzia.Visible = false;
            }
            catch (Exception ex)
            {
                progressbarend();
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void dnp()
        {
            try
            {
                openDialog.FileName = "*.*";
                openDialog.Filter = "All files (*.*)|*.*";
                openDialog.FilterIndex = 0;
                if (openDialog.ShowDialog() != DialogResult.OK) return;
                openDialog.Dispose();
                brakivalue.Clear();
                StreamReader sr1 = new StreamReader(openDialog.FileName, enc);
                string line = "";
                while ((line = sr1.ReadLine()) != null)
                {
                    brakivalue.Add(line);
                }
                sr1.Close();
                DataTable dtPopr = new DataTable(dtArr[indexSheet].TableName);
                foreach (DataColumn dc in dtArr[indexSheet].Columns)
                {
                    dtPopr.Columns.Add(dc.ColumnName);
                }
                progressbarstart(dtArr[indexSheet].Rows.Count);
                foreach (DataRow dr in dtArr[indexSheet].Rows)
                {
                    string text = poprComboBox2.Text.TrimStart().TrimEnd();
                    string szukajstring = "";
                    for (int ii = 0; ii < text.Split(' ').Length; ii++)
                    {
                        szukajstring += dr[text.Split(' ')[ii]];
                    } 
                    int isearch = brakivalue.IndexOf(szukajstring);
                    if (isearch == -1)
                    {
                        int nrkol = 0;
                        DataRow newrow = dtPopr.NewRow();
                        dtPopr.Rows.Add(newrow);
                        foreach (DataColumn dc in dtArr[indexSheet].Columns)
                        {
                            dtPopr.Rows[dtPopr.Rows.Count - 1][nrkol] = dr[nrkol];
                            nrkol++;
                        }
                    }
                    progressbarstep();
                }
                string tabname = Path.GetDirectoryName(dtPopr.TableName) + "\\" + Path.GetFileNameWithoutExtension(dtPopr.TableName) + "_dnp";
                dtArr[i] = dtPopr;
                dtArr[i].TableName = tabname;
                cboSheet.Items.Add(dtArr[i]);
                cboSheet.SelectedIndex = cboSheet.Items.Count - 1;
                i++;
                l++;
                brakivalue.Clear();
                progressbarend();
                //toolStripNarzedzia.Visible = false;
            }
            catch (Exception ex)
            {
                progressbarend();
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void imiona(string rodzaj)
        {
            try
            {
                ArrayList namevalue = new ArrayList();
                ArrayList namevalue2 = new ArrayList();
                namevalue.Clear();
                string namesource = "c:\\Program Files\\Dbadapter\\imiona.txt";
                StreamReader sr1 = new StreamReader(namesource, Encoding.GetEncoding(1250));
                string line = "";
                while ((line = sr1.ReadLine()) != null)
                {
                    namevalue.Add(line.Split('|')[0].ToUpper());
                    if (rodzaj == "PLECDBA")
                        namevalue2.Add(line.Split('|')[1]);
                    if (rodzaj == "WOLACZDBA")
                        namevalue2.Add(line.Split('|')[2]);
                }
                sr1.Close();
                DataTable dtPopr = new DataTable(dtArr[indexSheet].TableName);
                foreach (DataColumn dc in dtArr[indexSheet].Columns)
                {
                    dtPopr.Columns.Add(dc.ColumnName);
                }
                try
                {
                    dtArr[indexSheet].Columns.Add(rodzaj);
                    dtPopr.Columns.Add(rodzaj);
                }
                catch
                {
                }
                progressbarstart(dtArr[indexSheet].Rows.Count);
                foreach (DataRow dr in dtArr[indexSheet].Rows)
                {
                    int z = 0;
                    int p = 0;
                    int isearch = 0;
                    string value = dr[poprComboBox2.Text.Split(' ')[0]].ToString().TrimStart().TrimEnd();
                    int ile = 0;
                    if (value != "")
                    {
                        do
                        {
                            z++;
                            ile = value.IndexOf(" ", ile + 1);
                        }
                        while (ile != -1);
                    }
                    try
                    {
                        do
                        {
                            int s = 0;
                            char sep = ' ';
                            string[] separator = new string[] { " ", "-", ";", "|", "*", "&" };
                            do
                            {
                                sep = Convert.ToChar(separator[s]);
                                try
                                {
                                    isearch = namevalue.IndexOf(value.Split(sep)[p].ToUpper());
                                }
                                catch
                                {
                                    isearch = -1;
                                }
                                s++;
                            }
                            while (isearch == -1 & s < separator.Length);
                            p++;
                        }
                        while (isearch == -1 & p <= z);
                    }
                    catch
                    {
                        isearch = -1;
                    }
                    if (isearch != -1)
                    {
                        int fieldpoz = dtArr[indexSheet].Columns.IndexOf(rodzaj);
                        dr[fieldpoz] = namevalue2[isearch].ToString();
                    }
                    if (isearch == -1)
                    {
                        int nrkol = 0;
                        DataRow newrow = dtPopr.NewRow();
                        dtPopr.Rows.Add(newrow);
                        foreach (DataColumn dc in dtArr[indexSheet].Columns)
                        {
                            dtPopr.Rows[dtPopr.Rows.Count - 1][nrkol] = dr[nrkol];
                            nrkol++;
                        }
                    }
                    progressbarstep();
                }
                string tabname = Path.GetDirectoryName(dtPopr.TableName) + "\\" + Path.GetFileNameWithoutExtension(dtPopr.TableName) + "_empty"+Path.GetExtension(dtPopr.TableName);
                dtArr[i] = dtPopr;
                dtArr[i].TableName = tabname;
                if (dtArr[i].Rows.Count != 0)
                {
                    cboSheet.Items.Add(dtArr[i]);
                    cboSheet.SelectedIndex = cboSheet.Items.Count - 1;
                    i++;
                    l++;
                }
                namevalue.Clear();
                progressbarend();
                //toolStripNarzedzia.Visible = false;
            }
            catch (Exception ex)
            {
                progressbarend();
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void deduplikuj()
        {
            try
            {
                DataTable dtDup1 = new DataTable(dtArr[indexSheet].TableName);
                DataTable dtDup2 = new DataTable(dtArr[indexSheet].TableName);
                brakivalue.Clear();
                //string field = grdActiveSheet.Columns[grdActiveSheet.SelectedCells[0].ColumnIndex].Name;
                
                foreach (DataColumn dc in dtArr[indexSheet].Columns)
                {
                    dtDup1.Columns.Add(dc.ColumnName);
                    dtDup2.Columns.Add(dc.ColumnName);
                }
                progressbarstart(dtArr[indexSheet].Rows.Count);
                foreach (DataRow dr in dtArr[indexSheet].Rows)
                {
                    string text = poprComboBox2.Text.TrimStart().TrimEnd();
                    string fieldid = "";
                    for (int ii = 0; ii < text.Split(' ').Length; ii++)
                    {
                        fieldid += dr[text.Split(' ')[ii]];
                    } 
                    if (fieldid != "")
                    {
                        if (brakivalue.IndexOf(fieldid) == -1)
                        {
                            brakivalue.Add(fieldid);
                            int nrkol = 0;
                            DataRow newrow1 = dtDup1.NewRow();
                            dtDup1.Rows.Add(newrow1);
                            foreach (DataColumn dc in dtArr[indexSheet].Columns)
                            {
                                dtDup1.Rows[dtDup1.Rows.Count - 1][nrkol] = dr[nrkol];
                                nrkol++;
                            }
                        }
                        else
                        {
                            int nrkol1 = 0;
                            DataRow newrow2 = dtDup2.NewRow();
                            dtDup2.Rows.Add(newrow2);
                            foreach (DataColumn dc in dtArr[indexSheet].Columns)
                            {
                                dtDup2.Rows[dtDup2.Rows.Count - 1][nrkol1] = dr[nrkol1];
                                nrkol1++;
                            }
                        }
                    }
                    progressbarstep();
                }
                string tabname2 = Path.GetDirectoryName(dtDup2.TableName) + "\\" + Path.GetFileNameWithoutExtension(dtDup2.TableName) + "_duplikaty";
                dtArr[i] = dtDup2;
                dtArr[i].TableName = tabname2;
                cboSheet.Items.Add(dtArr[i]);
                cboSheet.SelectedIndex = cboSheet.Items.Count - 1;
                i++;
                l++;
                string tabname1 = Path.GetDirectoryName(dtDup1.TableName) + "\\" + Path.GetFileNameWithoutExtension(dtDup1.TableName) + "_ddp";
                dtArr[i] = dtDup1;
                dtArr[i].TableName = tabname1;
                cboSheet.Items.Add(dtArr[i]);
                cboSheet.SelectedIndex = cboSheet.Items.Count - 1;
                i++;
                l++;
                brakivalue.Clear();
                progressbarend();
                //toolStripNarzedzia.Visible = false;
            }
            catch (Exception ex)
            {
                progressbarend();
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void simpleRun(string progpath, string programopen, int waitexit)
        {
            System.Diagnostics.ProcessStartInfo psi =
              new System.Diagnostics.ProcessStartInfo(progpath, programopen);
            psi.RedirectStandardOutput = true;
            psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            System.Diagnostics.Process listFiles;
            listFiles = System.Diagnostics.Process.Start(psi);
            System.IO.StreamReader myOutput = listFiles.StandardOutput;
            if (waitexit == 1)
            {
                listFiles.WaitForExit();
            }
        }

        //#endregion procedures;




        #region handlers

        private void expRaportSzczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raportszczegolowy(1,"");
        }

        private void raport_Click(object sender, EventArgs e)
        {
            //czysc(0, 0, 0, 1, 1);
            if (dtArr[0] != null)
            {
                if (dataGridViewRaport.Visible == true)
                {
                    raport.CheckState = CheckState.Unchecked;
                    dataGridViewRaport.Visible = false;
                }
                else
                {
                    raport.CheckState = CheckState.Indeterminate;
                    raportszczegolowy(0,"");
                    dataGridViewRaport.Visible = true;
                }
            }
        }

        private void DragDrop_Click(object sender, DragEventArgs e)
        {
            files = GetFiles(e);
            string[] dragfiles = new string[files.Count];
            int dragi = 0;
            foreach (string item in files)
            {
                dragfiles[dragi++] = item;
            }
            plikilicznik(dragfiles);
            raportogolny(-1);
            czyscwszystko2();
        }

        public void counter()
        {

        }

        private void licznikButton_Click(object sender, EventArgs e)
        {
            czyscwszystko2();
            toolStripRaportZnaczik.Visible = false;
            wczytaj(1);
            raportogolny(-1);
        }

        private void licznikButton_Click2(object sender, EventArgs e)
        {
            czysc(1, 1, 0, 1, 1);
            if (toolStripRaportZnaczik.Visible == true) toolStripRaportZnaczik.Visible = false;
            else toolStripRaportZnaczik.Visible = true; 
        }

        private void DragEnter_Click(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void MouseDown_Click(object sender, MouseEventArgs e)
        {
        }

        private void clean_Click(object sender, EventArgs e)
        {
            czysc(1, 1, 1, 1, 1);
            cpOpen.Text = "";
            _cpoutput.Text = "";
            czyscwszystko();
        }

        protected void Exit_Click(Object sender, System.EventArgs e)
        {
            Close();
        }

        protected void Hide_Click(Object sender, System.EventArgs e)
        {
            Hide();
        }

        protected void Show_Click(Object sender, System.EventArgs e)
        {
            Show();
        }

        private void XLS2CSV_Load(object sender, EventArgs e)
        {
            czysc(0, 0, 1, 1, 0);
        }      

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            czysc(1, 1, 1, 0, 1);
            if (toolStripOpen.Visible == true)
            {
                toolStripOpen.Visible = false;
            }
            else
            {
                toolStripOpen.Visible = true;
            }
        }

        private void cmdLoad_Click2(object sender, EventArgs e)
        {
            toolStripOpen.Visible = false;
            czysc(0, 0, 1, 1, 0);
            wczytaj(0);
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            poolComboBox1.Text = "";
            sortTextBox1.Text = "";
            sortComboBox1.Text = "";
            actvark(sender);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            czysc(0, 1, 1, 1, 1);
            _cpoutput.Text = cpOpen.Text;
            if (cpOpen.Text == "") _cpoutput.Text = "";
            if (toolStripZapisz.Visible == true)
            {
                toolStripZapisz.Visible = false;
                SaveButton.CheckState = CheckState.Unchecked;
            }
            else
            {
                toolStripZapisz.Visible = true;
                SaveButton.CheckState = CheckState.Indeterminate;
            }
        }
        private void xLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"xls");
            czysc(0, 0, 1, 1, 0);
            copyxls(indexSheet);
        }

        private void xLSAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2, "xls");
            czysc(0, 0, 1, 1, 0);
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                copyxls(i);
            }
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"txt");
            czysc(0, 0, 1, 1, 0);
            copy(indexSheet, 0);
        }

        private void sDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"txt");
            czysc(0, 0, 1, 1, 0);
            copy(indexSheet, 1);
        }

        private void cSVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"txt");
            czysc(0, 0, 1, 1, 0);
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                copy(i, 0);
            }
        }

        private void biezacyPlikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dodajkolumne(indexSheet);
        }

        private void wszystkiePlikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                dodajkolumne(i);
            }
        }

        private void sDFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"txt");
            czysc(0, 0, 1, 1, 0);
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                copy(i, 1);
            }
        }

        private void xMLBiezacy_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"xml");
            czysc(0, 0, 1, 1, 0);
            copyxml(indexSheet);
        }

        private void dBFBiezacy_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"dbf");
            czysc(0, 0, 1, 1, 0);
            copydbf(indexSheet,0);
        }

        private void dBFWszystkie_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"dbf");
            czysc(0, 0, 1, 1, 0);
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                copydbf(i,0);
            }
        }

        private void xMLWszystkie_Click(object sender, EventArgs e)
        {
            raportszczegolowy(2,"xml");
            czysc(0, 0, 1, 1, 0);
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                copyxml(i);
            }
        }

        private void cpSqve_Click(object sender, EventArgs e)
        {
            try
            {
              konwersja(1250, _cpoutput.Text);
            }
            catch
            {
                MessageBox.Show("Failed to read file: \n" + "Wybieø wlaúciwπ stronÍ kodowπ zapisu!");
            }
        }

        private void cpOpen_Click(object sender, EventArgs e)
        {
            try
            {
                konwersja(1250, cpOpen.Text);
            }
            catch
            {
                MessageBox.Show("Failed to read file: \n" + "Wybieø wlaúciwπ stronÍ kodowπ zapisu!");
            }
        }

        private void about_Click(object sender, EventArgs e)
        {
            ABT myAbout = new ABT();
            myAbout.Show();
        }

        private void grdActiveSheet_Sorted(object sender, EventArgs e)
        {
            sortowanie(grdActiveSheet.SortedColumn.Name, grdActiveSheet.SortOrder.ToString(), indexSheet, 1, 0);
        }

        private void biezacyPlikLp_Click(object sender, EventArgs e)
        {
            lpdodaj(indexSheet);
        }

        private void wszystkiePlikiLp_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                lpdodaj(i);
            }
        }

        private void biezacyPlikNup_Click(object sender, EventArgs e)
        {
            nupowanie(indexSheet);

        }

        private void wszystkiePlikiNup_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                nupowanie(i);
            }
        }

        private void struktBiezacy_Click(object sender, EventArgs e)
        {
            zapiszstrukture(indexSheet);
        }

        private void struktWszystkie_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                zapiszstrukture(i);
            }
        }

        private void importujStruktureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importujStrukture();
        }

        private void lp_Click(object sender, EventArgs e)
        {
            czysc(0, 0, 1, 1, 0);
        }

        private void nupTextBox1_Click(object sender, EventArgs e)
        {
            czysc(0, 0, 1, 1, 0);
        }

        private void nup_Click(object sender, EventArgs e)
        {
            czysc(0, 0, 1, 1, 0);
        }

        private void StrukturaButton_Click(object sender, EventArgs e)
        {
            czysc(0, 0, 1, 1, 0);
        }

        private void sortIndexChanged_Click(object sender, EventArgs e)
        {
            try
            {
                if (sortTextBox1.Text.Substring(sortTextBox1.Text.Length - 2, 2) == ", ")
                {
                    sortTextBox1.Text += sortComboBox1.Text + " ";
                }
            }
            catch
            {
                sortTextBox1.Text += sortComboBox1.Text + " ";
            }
        }

        private void ascendingindexChanged_Click(object sender, EventArgs e)
        {
            try
            {
                string asc = "";
                if (AscDesc.Text == "Ascending") asc = "ASC, ";
                else asc = "DESC, ";
                if (sortTextBox1.Text.Substring(sortTextBox1.Text.Length - 2, 2) != ", ")
                {
                    sortTextBox1.Text += asc;
                }
            }
            catch
            {
            }
        }

        private void Sortuj_Click(object sender, EventArgs e)
        {
            //czysc(1, 0, 1, 1, 1);
            if (toolStripSortuj.Visible == true)
            {
                toolStripSortuj.Visible = false;
                Sortuj.CheckState = CheckState.Unchecked;
            }
            else
            {
                toolStripSortuj.Visible = true;
                Sortuj.CheckState = CheckState.Indeterminate;
            }
        }

        private void biezacyPlikSort_Click(object sender, EventArgs e)
        {
            czysc(0, 0, 1, 1, 0);
            sortowanie(sortTextBox1.Text, AscDesc.Text, indexSheet, 1, 1);
        }

        private void wszystkiePlikiSort_Click(object sender, EventArgs e)
        {
            czysc(0, 0, 1, 1, 0);
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                sortowanie(sortTextBox1.Text, AscDesc.Text, i, 1, 1);
            }
        }

        private void biezacyPlikOdwr_Click(object sender, EventArgs e)
        {
            odwracanie(indexSheet);
        }

        private void wszystkiePlikiOdwr_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cboSheet.Items.Count; i++)
            {
                odwracanie(i);
            }
        }

        private void usunKolumne_Click(object sender, EventArgs e)
        {
            try
            {
                string text = poprComboBox2.Text;
                for (int ii = 0; ii < text.Split(' ').Length; ii++)
                {
                    string pole = text.Split(' ')[ii];
                    dtArr[indexSheet].Columns.Remove(pole);
                    poprComboBox.Items.Remove(pole);
                    commandText.AutoCompleteCustomSource.Add(pole);
                    poprComboBox.Text = poprComboBox.Items[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void toolStripButtonOK_Click(object sender, EventArgs e)
        {
            filter(commandText.Text);
            _info.Text = "";
        }

        private void poprawkiButton_Click(object sender, EventArgs e)
        {
            poprawiaj();
        }

        private void toolStripButtonAcctpFilter_Click(object sender, EventArgs e)
        {
            try
            {
                dtArr[indexSheet] = dvfilter.ToTable();
                grdActiveSheet.DataSource = dtArr[indexSheet];
                licznik.Text = "Rec: " + dtArr[indexSheet].Rows.Count.ToString() + "  Col: " + dtArr[indexSheet].Columns.Count.ToString();
                _info.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("B≥πd: \n" + ex.Message);
            }
        }

        private void toolStripButtonUsunFiltr_Click(object sender, EventArgs e)
        {
            commandText.Text = "";
            usunfilter();
        }

        private void jobButton_Click(object sender, EventArgs e)
        {
             openDialog.FileName = "*.jdb";
            openDialog.Filter = "Job dbadapter files (*.jdb)|*.jdb|All files (*.*)|*.*";
            openDialog.FilterIndex = 0;
            if (openDialog.ShowDialog() != DialogResult.OK) return;
            openDialog.Dispose();
            jobstart(openDialog.FileName);
        }

        private void wczytajPoprawki_Click(object sender, EventArgs e)
        {
            if (poprComboBox.Text != "")
            {
                poprawiaj();
            }
            else
            {
                MessageBox.Show("Wybierz pole");
            }
        }

        private void wczytajDnp_Click(object sender, EventArgs e)
        {
            if (poprComboBox.Text != "")
            {
                dnp();
            }
            else
            {
                MessageBox.Show("Wybierz pole");
            }
        }

        private void deduplikacja_Click(object sender, EventArgs e)
        {
            if (poprComboBox2.Text != "")
            {
                deduplikuj();
            }
            else
            {
                MessageBox.Show("Wybierz pole");
            }
        }

        private void liniaKomSkrot_Click(object sender, EventArgs e)
        {
            if (toolStripLiniaKom.Visible == false) toolStripLiniaKom.Visible = true;
            else toolStripLiniaKom.Visible = false;
        }

        private void toolsButton_Click(object sender, EventArgs e)
        {
            czysc(1, 1, 1, 1, 0);
            if (toolStripNarzedzia.Visible == false)
            {
                toolStripNarzedzia.Visible = true;
                toolsButton.CheckState = CheckState.Indeterminate;
            }
            else
            {
                toolStripNarzedzia.Visible = false;
                toolsButton.CheckState = CheckState.Unchecked;
            }
        }

        private void grpdatagridview_Click(object sender, EventArgs e)
        {
            czysc(0, 0, 1, 1, 0);
        }

        private void wolaczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imiona("WOLACZDBA");
        }

        private void plecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imiona("PLECDBA");
        }

        private void IndexChanged_Click(object sender, EventArgs e)
        {
            if (poprComboBox2.Text != "") poprComboBox2.Text += " " + poprComboBox.Text;
            if (poprComboBox2.Text == "") poprComboBox2.Text = poprComboBox.Text;
            if (poprComboBox.Text == "") poprComboBox2.Text = "";
        }

        private void textChanged_Click(object sender, EventArgs e)
        {
            int size = (poprComboBox2.Text.Length+1);
            if (poprComboBox2.Text == "") size = 0;
            this.poprComboBox2.Size = new System.Drawing.Size(size*7, 25); 
        }

        private void scalTab_Click(object sender, EventArgs e)
        {
            dtAll.Clear();
            dtAll.Columns.Clear();
            string tabname1 = Path.GetDirectoryName(dtArr[0].TableName) + "\\" + Path.GetFileNameWithoutExtension(dtArr[indexSheet].TableName) + "_joined";
            for (int ii = 0; ii < cboSheet.Items.Count; ii++)
            {
                if (dtArr[ii].TableName != tabname1)
                {
                    scaldane(ii);
                }
            }
            dtArr[i] = dtAll;
            dtArr[i].TableName = tabname1;
            cboSheet.Items.Add(dtArr[i]);
            cboSheet.SelectedIndex = cboSheet.Items.Count - 1;
            i++;
            l++;
        }

        private void rMusterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtArr[0] != null)
            {
                mapujRm(0);
            }
        }


        private void rekordyKontrolneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtArr[0] != null)
            {
                mapujRm(1);
            }
        }

        private void wzoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //labelRm.Visible = false;
            //labelIlosc.Visible = false;
            //labelOpis.Visible = false;
            //labelNr.Visible = false;
            //textBoxNr.Visible = false;
            //textBoxOpis.Visible = false;
            //button1.Visible = false;
            //labelSprawdz.Visible = false;

            if (dtArr[0] != null)
            {
                mapujRm(2);
            }
        }

        private void buttonRm_Click(object sender, EventArgs e)
        {
            int rm = 0;
            if (buttonRm.Text == "Generuj Kontrolne") rm = 1;
            if (buttonRm.Text == "Generuj Wzory") rm = 2;
            dataGrid1.Visible = false;
            buttonRm.Visible = false;
            comboBoxRm.Visible = false;
            labelRm.Visible = false;
            labelIlosc.Visible = false;
            labelOpis.Visible = false;
            labelNr.Visible = false;
            textBoxNr.Visible = false;
            textBoxOpis.Visible = false;
            button1.Visible = false;
            labelSprawdz.Visible = false;
            ileTextBox.Visible = false;
            ileLabel.Visible = false;
            if (rm == 0)
            {
                if (comboBoxRm.Text == "Wszystkie tabele")
                {
                    for (int i = 0; i < cboSheet.Items.Count; i++)
                    {
                        ss(i);
                    }
                }
                else
                {
                    ss(indexSheet);
                }
            }
            if (rm == 1)
            {
                if (comboBoxRm.Text == "Wszystkie tabele")
                {
                    for (int i = 0; i < cboSheet.Items.Count; i++)
                    {
                        kontrolni(i);
                    }
                }
                else
                {
                    kontrolni(indexSheet);
                }
            }
            if (rm == 2)
            {
                if (comboBoxRm.Text == "Wszystkie tabele")
                {
                    for (int i = 0; i < cboSheet.Items.Count; i++)
                    {
                        wzory(i);
                    }
                }
                else
                {
                    wzory(indexSheet);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            czyscRm();
        }

        private void czyscRm()
        {

            dataGrid1.Visible = false;
            buttonRm.Visible = false;
            comboBoxRm.Visible = false;
            labelRm.Visible = false;
            labelIlosc.Visible = false;
            labelOpis.Visible = false;
            labelNr.Visible = false;
            textBoxNr.Visible = false;
            textBoxOpis.Visible = false;
            button1.Visible = false;
            labelSprawdz.Visible = false;
            ileTextBox.Visible = false;
            ileLabel.Visible = false;
            dtss.Clear();
        }

        private void comboBoxRm_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelSprawdz.Visible = false;
            if (comboBoxRm.Text == "Wszystkie tabele")
            {
                labelSprawdz.Visible = true;
            }
        }

        private void CpCon_Click(object sender, EventArgs e)
        {
            CPC mycp = new CPC();
            mycp.Show();
        }

        #endregion handlers;

    }
}
