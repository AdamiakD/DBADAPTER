using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Dbadapter
{
    public partial class CPC : Form
    {
        List<StringBuilder> myText = new List<StringBuilder>();
        List<string> strTxtFileName = new List<string>();
        int indexFile = 0;
        int indexFileMinus = 0;
        int oldIndex = 0;
        int icp = 0;
        string strTxtFileDir = "";
        string[] files = new string[500];
        int wcp = 0;
        string bufor = ".cptmp.tmp";

        public CPC()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            _myTextCons.Font = _fontDialog1.Font;
            _myTextCons2.Font = _fontDialog1.Font; 
            File.Delete(".cptmp.tmp");
            _openFileDialog1.FileName = "*.*";
            _openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            _openFileDialog1.FilterIndex = 2;

            if (_openFileDialog1.ShowDialog() == DialogResult.OK)
            {
            	indexFileMinus += indexFile;
            	indexFile = 0;
            	pliki(_openFileDialog1.FileNames,indexFileMinus);             	              
            }
            else
            {
                return;
            }
            
        }

        void pliki (string [] strTxtFilePath, int iflag)
		{   
            string line;
            foreach (string item in strTxtFilePath)
            {   
                files[indexFile + iflag] = strTxtFilePath[indexFile];
                strTxtFileName.Add(Path.GetFileName(strTxtFilePath[indexFile]));
                strTxtFileDir = Path.GetDirectoryName(strTxtFilePath[0]);

                _checkedListBox1.Items.Add(strTxtFileName[indexFile + iflag], CheckState.Checked);
                

                StreamReader sr = new StreamReader(strTxtFilePath[indexFile], Encoding.Default);
                int intline = 0;
                while ((line = sr.ReadLine()) != null ^ intline == 100)
                {
                    myText.Add(new StringBuilder());
                    myText[indexFile + iflag].Append(line + "\n");
                    intline ++;
                }
                sr.Close();
                intline = 0;
                indexFile++;
                _checkedListBox1.SelectedIndex = (indexFile - 1) + iflag;
                _myTextCons.Text = myText[(indexFile - 1) + iflag].ToString();
                _myTextCons.Font = _fontDialog1.Font;
                _myTextCons2.Font = _fontDialog1.Font; 
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _info.Text = Path.GetFileName(files[_checkedListBox1.SelectedIndex]);
            _myTextCons.Text = myText[_checkedListBox1.SelectedIndex].ToString();
            if (oldIndex != _checkedListBox1.SelectedIndex)
            {
                _myTextCons.Text = myText[_checkedListBox1.SelectedIndex].ToString();
            }
            oldIndex = _checkedListBox1.SelectedIndex;
            conversja();
        }

        private void font_Click(object sender, EventArgs e)
        {
            try
            {
                _fontDialog1.ShowDialog();
                _myTextCons.Font = _fontDialog1.Font;
                _myTextCons2.Font = _fontDialog1.Font;
                _font.Text = _myTextCons.Font.Name;
                _font.Text = _myTextCons2.Font.Name;
                _font.Font = new System.Drawing.Font(_fontDialog1.Font.Name, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            
            }
            catch
            {
                return;
            }	   
        }

        private void wordwrap_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_myTextCons.WordWrap)
                {
                    case true:
                        _myTextCons.WordWrap = false;
                        _myTextCons2.WordWrap = false;
                        break;
                    case false:
                        _myTextCons.WordWrap = true;
                        _myTextCons2.WordWrap = true;
                        break;
                }
            }
            catch
            {
                return;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _info.Text = _listBox1.Text;
            conversja();
        }

        private void cpoutput_Click(object sender, EventArgs e)
        {
            wcp = Convert.ToInt32(_cpoutput.Text.Remove(6).Trim());
        }

        private void encode_Click(object sender, EventArgs e)
        {
            wcp = Convert.ToInt32(_cpoutput.Text.Remove(6).Trim());
            int i = 0;
            _progressBar.Visible = true;
            _progressBar.Maximum = indexFile + 1;
            _progressBar.Value = 1;
            _progressBar.Step = 1;
            int converted = 0;

            foreach (string item in files)
            {
                _info.Visible = true;
                if (File.Exists(files[i]))
                {
                    if (_checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        string spath = Path.GetDirectoryName(files[i]) + "\\_" + Path.GetFileName(files[i]);
                        try
                        {
                            string[] readText = File.ReadAllLines(files[i], Encoding.GetEncoding(icp));
                            File.Delete(spath);
                            File.WriteAllLines(spath, readText, Encoding.GetEncoding(wcp));
                            _progressBar.PerformStep();
                            _info.Text = spath;
                            _checkedListBox1.SelectedIndex = i;
                            converted++;
                        }
                        catch
                        {
                            _progressBar.Visible = false;
                            //MessageBox.Show("File: " + Path.GetFileName(files[i]) + " has not been converted");
                            _info.Text = "File " + Path.GetFileName(files[i]) + " has not been converted";
                            return;
                        }
                    }
                    i++;
                }   
            }
            if (converted == 1)
            {
                _info.Text = i.ToString() + " file has been converted";
            }
            else
            {
                _info.Text = converted.ToString() + " files has been converted";
            }
            _progressBar.Visible = false;
            //MessageBox.Show("       DONE       ");
        }

        private void conversja()
        {
        	wcp = Convert.ToInt32(_cpoutput.Text.Remove(6).Trim());
            File.WriteAllText(bufor, _myTextCons.Text, Encoding.Default);

            if (_listBox1.Text == "")
            {
                _listBox1.Text = "852      ibm852             Central European (DOS)";
            }
            icp = Convert.ToInt32(_listBox1.Text.Remove(6).Trim());
            string unicodeString = File.ReadAllText(bufor, Encoding.GetEncoding(icp));

            _myTextCons2.Text = unicodeString;
            int asdf = _myTextCons.Text.CompareTo(_myTextCons2.Text);
            //_myTextCons.Font = _fontDialog1.Font;
            //_myTextCons2.Font = _fontDialog1.Font; 
        }

        private void _myTextCons_Select(object sender, EventArgs e)
        {
            _myTextCons.HideSelection = false;
            _myTextCons2.HideSelection = false;
            int selstart = _myTextCons.SelectionStart;
            int sellen = _myTextCons.SelectionLength;
            _myTextCons2.Select(selstart, sellen);
            //_myTextCons2.SelectionBackColor = System.Drawing.Color.Red;
        }

        private void _myTextCons2_Select(object sender, EventArgs e)
        {
            _myTextCons.HideSelection = false;
            _myTextCons2.HideSelection = false;
            int selstart = _myTextCons2.SelectionStart;
            int sellen = _myTextCons2.SelectionLength;
            _myTextCons.Select(selstart, sellen);
            //_myTextCons.SelectionBackColor = System.Drawing.Color.Yellow;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ABT myAbout = new ABT();
            myAbout.Show();
        }

        private void ClearButon_Click(object sender, EventArgs e)
        {
            _myTextCons.Text = "";
            _myTextCons2.Text = "";
            indexFile = 0;
            indexFileMinus = 0;
            myText.Clear();
            strTxtFileName.Clear();
            oldIndex = 0;
            icp = 0;
            strTxtFileDir = "";
            wcp = 0;
            int intitem = 0;
            foreach(string item in files)
            {
                files[intitem] = "";
                intitem++;
            }
            _checkedListBox1.Items.Clear();
        }
    }
}
