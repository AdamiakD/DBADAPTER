using System.IO;

namespace Dbadapter
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            File.Delete(".cptmp.tmp");
            m_notifyicon.Visible = false;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        	this.grpData = new System.Windows.Forms.GroupBox();
        	this.ileLabel = new System.Windows.Forms.Label();
        	this.ileTextBox = new System.Windows.Forms.TextBox();
        	this.labelSprawdz = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.labelIlosc = new System.Windows.Forms.Label();
        	this.labelOpis = new System.Windows.Forms.Label();
        	this.labelNr = new System.Windows.Forms.Label();
        	this.textBoxOpis = new System.Windows.Forms.TextBox();
        	this.textBoxNr = new System.Windows.Forms.TextBox();
        	this.labelRm = new System.Windows.Forms.Label();
        	this.buttonRm = new System.Windows.Forms.Button();
        	this.comboBoxRm = new System.Windows.Forms.ComboBox();
        	this.dataGrid1 = new System.Windows.Forms.DataGrid();
        	this.dataGridViewRaport = new System.Windows.Forms.DataGridView();
        	this.cboSheet = new System.Windows.Forms.ComboBox();
        	this.grdActiveSheet = new System.Windows.Forms.DataGridView();
        	this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.otworzSkrot = new System.Windows.Forms.ToolStripMenuItem();
        	this.zapiszSkrot = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
        	this.licznikSkrot = new System.Windows.Forms.ToolStripMenuItem();
        	this.jobSkrot = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        	this.podgladStrukturySkrot = new System.Windows.Forms.ToolStripMenuItem();
        	this.resetAllSkrot = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        	this.narzedzia = new System.Windows.Forms.ToolStripMenuItem();
        	this.liniaKomSkrot = new System.Windows.Forms.ToolStripMenuItem();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.toolStripTextBox1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.openDialog = new System.Windows.Forms.OpenFileDialog();
        	this._statusstrip_down = new System.Windows.Forms.StatusStrip();
        	this._progressBar = new System.Windows.Forms.ToolStripProgressBar();
        	this.licznik = new System.Windows.Forms.ToolStripStatusLabel();
        	this._info = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
        	this.toolStripLiniaKom = new System.Windows.Forms.ToolStrip();
        	this.expresja = new System.Windows.Forms.ToolStripLabel();
        	this.commandText = new System.Windows.Forms.ToolStripTextBox();
        	this.toolStripButtonOK = new System.Windows.Forms.ToolStripButton();
        	this.UsunFiltr = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButtonAcctpFilter = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSortuj = new System.Windows.Forms.ToolStrip();
        	this.wybierzpolaStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this.sortComboBox1 = new System.Windows.Forms.ToolStripComboBox();
        	this.wybierzsortpolatoolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this.AscDesc = new System.Windows.Forms.ToolStripComboBox();
        	this.sortTextBox1 = new System.Windows.Forms.ToolStripTextBox();
        	this.sortujStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
        	this.biezacyPlikSort = new System.Windows.Forms.ToolStripMenuItem();
        	this.wszystkiePlikiSort = new System.Windows.Forms.ToolStripMenuItem();
        	this.menuGlowne = new System.Windows.Forms.ToolStrip();
        	this.cmdLoad = new System.Windows.Forms.ToolStripSplitButton();
        	this.SaveButton = new System.Windows.Forms.ToolStripButton();
        	this.StrukturaButton = new System.Windows.Forms.ToolStripDropDownButton();
        	this.importujStruktureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.struktBiezacy = new System.Windows.Forms.ToolStripMenuItem();
        	this.struktWszystkie = new System.Windows.Forms.ToolStripMenuItem();
        	this.expRaportSzczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.raport = new System.Windows.Forms.ToolStripButton();
        	this.toolsButton = new System.Windows.Forms.ToolStripButton();
        	this.Projekty = new System.Windows.Forms.ToolStripDropDownButton();
        	this.CpCon = new System.Windows.Forms.ToolStripButton();
        	this.jobButton = new System.Windows.Forms.ToolStripButton();
        	this.licznikButton = new System.Windows.Forms.ToolStripSplitButton();
        	this.clean = new System.Windows.Forms.ToolStripButton();
        	this.about = new System.Windows.Forms.ToolStripButton();
        	this.toolStripRaportZnaczik = new System.Windows.Forms.ToolStrip();
        	this.toolStripText = new System.Windows.Forms.ToolStripLabel();
        	this.znaczikTextBox = new System.Windows.Forms.ToolStripTextBox();
        	this.csvNaglowki = new System.Windows.Forms.ToolStripLabel();
        	this.csvNaglowkiComboBox1 = new System.Windows.Forms.ToolStripComboBox();
        	this.toolStripNarzedzia = new System.Windows.Forms.ToolStrip();
        	this.Sortuj = new System.Windows.Forms.ToolStripButton();
        	this.lp = new System.Windows.Forms.ToolStripDropDownButton();
        	this.bieżącyPlikLp = new System.Windows.Forms.ToolStripMenuItem();
        	this.wszystkiePlikiLp = new System.Windows.Forms.ToolStripMenuItem();
        	this.nupTextBox1 = new System.Windows.Forms.ToolStripTextBox();
        	this.nup = new System.Windows.Forms.ToolStripDropDownButton();
        	this.bieżącyPlikNup = new System.Windows.Forms.ToolStripMenuItem();
        	this.wszystkiePlikiNup = new System.Windows.Forms.ToolStripMenuItem();
        	this.odwroc = new System.Windows.Forms.ToolStripDropDownButton();
        	this.biezacyPlikOdwr = new System.Windows.Forms.ToolStripMenuItem();
        	this.wszystkiePlikiOdwr = new System.Windows.Forms.ToolStripMenuItem();
        	this.scalTab = new System.Windows.Forms.ToolStripButton();
        	this.toolStripDodajKol = new System.Windows.Forms.ToolStripMenuItem();
        	this.bieżącyPlikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.wszystkiePlikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ssy = new System.Windows.Forms.ToolStripDropDownButton();
        	this.rMusterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.rekordyKontrolneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.wzoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.wybierzPole = new System.Windows.Forms.ToolStripDropDownButton();
        	this.wczytajPoprawki = new System.Windows.Forms.ToolStripMenuItem();
        	this.wczytajDnp = new System.Windows.Forms.ToolStripMenuItem();
        	this.deduplikacja = new System.Windows.Forms.ToolStripMenuItem();
        	this.usuńKolumnęToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.wolaczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.plecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.poprComboBox2 = new System.Windows.Forms.ToolStripTextBox();
        	this.poprComboBox = new System.Windows.Forms.ToolStripComboBox();
        	this.toolStripOpen = new System.Windows.Forms.ToolStrip();
        	this.toolStripLabelOpen = new System.Windows.Forms.ToolStripLabel();
        	this.cpOpen = new System.Windows.Forms.ToolStripComboBox();
        	this.toolStripZapisz = new System.Windows.Forms.ToolStrip();
        	this.zapiszbuttonglowny = new System.Windows.Forms.ToolStripDropDownButton();
        	this.bieżącyPlikzapisz = new System.Windows.Forms.ToolStripMenuItem();
        	this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.xMLBiezacy = new System.Windows.Forms.ToolStripMenuItem();
        	this.dBFBiezacy = new System.Windows.Forms.ToolStripMenuItem();
        	this.xLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.wszystkiePlikizapisz = new System.Windows.Forms.ToolStripMenuItem();
        	this.cSVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.sDFToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.xMWszystkie = new System.Windows.Forms.ToolStripMenuItem();
        	this.dBFWszystkie = new System.Windows.Forms.ToolStripMenuItem();
        	this.xLSAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.cpLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this._cpoutput = new System.Windows.Forms.ToolStripComboBox();
        	this.poolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this.poolComboBox1 = new System.Windows.Forms.ToolStripComboBox();
        	this.SeparatorCSV = new System.Windows.Forms.ToolStripLabel();
        	this.SepCSVBox = new System.Windows.Forms.ToolStripTextBox();
        	this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	this.grpData.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaport)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.grdActiveSheet)).BeginInit();
        	this.contextMenuStrip2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.contextMenuStrip1.SuspendLayout();
        	this._statusstrip_down.SuspendLayout();
        	this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
        	this.toolStripContainer1.ContentPanel.SuspendLayout();
        	this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
        	this.toolStripContainer1.SuspendLayout();
        	this.toolStripLiniaKom.SuspendLayout();
        	this.toolStripSortuj.SuspendLayout();
        	this.menuGlowne.SuspendLayout();
        	this.toolStripRaportZnaczik.SuspendLayout();
        	this.toolStripNarzedzia.SuspendLayout();
        	this.toolStripOpen.SuspendLayout();
        	this.toolStripZapisz.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// grpData
        	// 
        	this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.grpData.BackColor = System.Drawing.SystemColors.Control;
        	this.grpData.Controls.Add(this.ileLabel);
        	this.grpData.Controls.Add(this.ileTextBox);
        	this.grpData.Controls.Add(this.labelSprawdz);
        	this.grpData.Controls.Add(this.button1);
        	this.grpData.Controls.Add(this.labelIlosc);
        	this.grpData.Controls.Add(this.labelOpis);
        	this.grpData.Controls.Add(this.labelNr);
        	this.grpData.Controls.Add(this.textBoxOpis);
        	this.grpData.Controls.Add(this.textBoxNr);
        	this.grpData.Controls.Add(this.labelRm);
        	this.grpData.Controls.Add(this.buttonRm);
        	this.grpData.Controls.Add(this.comboBoxRm);
        	this.grpData.Controls.Add(this.dataGrid1);
        	this.grpData.Controls.Add(this.dataGridViewRaport);
        	this.grpData.Controls.Add(this.cboSheet);
        	this.grpData.Controls.Add(this.grdActiveSheet);
        	this.grpData.Controls.Add(this.pictureBox1);
        	this.grpData.Enabled = false;
        	this.grpData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.grpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.grpData.ForeColor = System.Drawing.Color.Black;
        	this.grpData.Location = new System.Drawing.Point(3, 0);
        	this.grpData.Name = "grpData";
        	this.grpData.Size = new System.Drawing.Size(976, 403);
        	this.grpData.TabIndex = 0;
        	this.grpData.TabStop = false;
        	// 
        	// ileLabel
        	// 
        	this.ileLabel.AutoSize = true;
        	this.ileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.ileLabel.Location = new System.Drawing.Point(343, 95);
        	this.ileLabel.Name = "ileLabel";
        	this.ileLabel.Size = new System.Drawing.Size(195, 13);
        	this.ileLabel.TabIndex = 16;
        	this.ileLabel.Text = "Co ile (wypełniać w razie konieczności):";
        	this.ileLabel.Visible = false;
        	// 
        	// ileTextBox
        	// 
        	this.ileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.ileTextBox.Location = new System.Drawing.Point(343, 111);
        	this.ileTextBox.Name = "ileTextBox";
        	this.ileTextBox.Size = new System.Drawing.Size(205, 20);
        	this.ileTextBox.TabIndex = 15;
        	this.ileTextBox.Visible = false;
        	// 
        	// labelSprawdz
        	// 
        	this.labelSprawdz.AutoSize = true;
        	this.labelSprawdz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.labelSprawdz.ForeColor = System.Drawing.Color.Red;
        	this.labelSprawdz.Location = new System.Drawing.Point(406, 49);
        	this.labelSprawdz.Name = "labelSprawdz";
        	this.labelSprawdz.Size = new System.Drawing.Size(142, 13);
        	this.labelSprawdz.TabIndex = 14;
        	this.labelSprawdz.Text = "Sprawdź tożsamość struktur!";
        	this.labelSprawdz.Visible = false;
        	// 
        	// button1
        	// 
        	this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.button1.Location = new System.Drawing.Point(495, 244);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(53, 23);
        	this.button1.TabIndex = 13;
        	this.button1.Text = "Cancel";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Visible = false;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// labelIlosc
        	// 
        	this.labelIlosc.AutoSize = true;
        	this.labelIlosc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.labelIlosc.Location = new System.Drawing.Point(343, 49);
        	this.labelIlosc.Name = "labelIlosc";
        	this.labelIlosc.Size = new System.Drawing.Size(60, 13);
        	this.labelIlosc.TabIndex = 12;
        	this.labelIlosc.Text = "Ilość tabeli:";
        	this.labelIlosc.Visible = false;
        	// 
        	// labelOpis
        	// 
        	this.labelOpis.AutoSize = true;
        	this.labelOpis.Location = new System.Drawing.Point(343, 192);
        	this.labelOpis.Name = "labelOpis";
        	this.labelOpis.Size = new System.Drawing.Size(72, 13);
        	this.labelOpis.TabIndex = 11;
        	this.labelOpis.Text = "Opis projektu:";
        	this.labelOpis.Visible = false;
        	// 
        	// labelNr
        	// 
        	this.labelNr.AutoSize = true;
        	this.labelNr.Location = new System.Drawing.Point(343, 143);
        	this.labelNr.Name = "labelNr";
        	this.labelNr.Size = new System.Drawing.Size(62, 13);
        	this.labelNr.TabIndex = 10;
        	this.labelNr.Text = "Nr projektu:";
        	this.labelNr.Visible = false;
        	// 
        	// textBoxOpis
        	// 
        	this.textBoxOpis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.textBoxOpis.Location = new System.Drawing.Point(343, 208);
        	this.textBoxOpis.Name = "textBoxOpis";
        	this.textBoxOpis.Size = new System.Drawing.Size(205, 20);
        	this.textBoxOpis.TabIndex = 9;
        	this.textBoxOpis.Visible = false;
        	// 
        	// textBoxNr
        	// 
        	this.textBoxNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.textBoxNr.Location = new System.Drawing.Point(343, 159);
        	this.textBoxNr.Name = "textBoxNr";
        	this.textBoxNr.Size = new System.Drawing.Size(205, 20);
        	this.textBoxNr.TabIndex = 8;
        	this.textBoxNr.Visible = false;
        	// 
        	// labelRm
        	// 
        	this.labelRm.AutoSize = true;
        	this.labelRm.Location = new System.Drawing.Point(340, 12);
        	this.labelRm.Name = "labelRm";
        	this.labelRm.Size = new System.Drawing.Size(77, 13);
        	this.labelRm.TabIndex = 7;
        	this.labelRm.Text = "Wybierz opcje:";
        	this.labelRm.Visible = false;
        	// 
        	// buttonRm
        	// 
        	this.buttonRm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.buttonRm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.buttonRm.Location = new System.Drawing.Point(343, 244);
        	this.buttonRm.Name = "buttonRm";
        	this.buttonRm.Size = new System.Drawing.Size(135, 23);
        	this.buttonRm.TabIndex = 6;
        	this.buttonRm.UseVisualStyleBackColor = true;
        	this.buttonRm.Visible = false;
        	this.buttonRm.Click += new System.EventHandler(this.buttonRm_Click);
        	// 
        	// comboBoxRm
        	// 
        	this.comboBoxRm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.comboBoxRm.FormattingEnabled = true;
        	this.comboBoxRm.Items.AddRange(new object[] {
        	        	        	"Bieżąca tabela",
        	        	        	"Wszystkie tabele"});
        	this.comboBoxRm.Location = new System.Drawing.Point(343, 63);
        	this.comboBoxRm.Name = "comboBoxRm";
        	this.comboBoxRm.Size = new System.Drawing.Size(205, 21);
        	this.comboBoxRm.TabIndex = 5;
        	this.comboBoxRm.Text = "Bieżąca tabela";
        	this.comboBoxRm.Visible = false;
        	this.comboBoxRm.SelectedIndexChanged += new System.EventHandler(this.comboBoxRm_SelectedIndexChanged);
        	// 
        	// dataGrid1
        	// 
        	this.dataGrid1.AlternatingBackColor = System.Drawing.SystemColors.Control;
        	this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.dataGrid1.BackColor = System.Drawing.SystemColors.Control;
        	this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
        	this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
        	this.dataGrid1.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.dataGrid1.CaptionText = "Mapowanie";
        	this.dataGrid1.DataMember = "";
        	this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        	this.dataGrid1.Location = new System.Drawing.Point(1, 9);
        	this.dataGrid1.Name = "dataGrid1";
        	this.dataGrid1.RowHeadersVisible = false;
        	this.dataGrid1.RowHeaderWidth = 0;
        	this.dataGrid1.Size = new System.Drawing.Size(969, 388);
        	this.dataGrid1.TabIndex = 4;
        	this.dataGrid1.Visible = false;
        	// 
        	// dataGridViewRaport
        	// 
        	this.dataGridViewRaport.AllowUserToAddRows = false;
        	this.dataGridViewRaport.AllowUserToDeleteRows = false;
        	this.dataGridViewRaport.AllowUserToResizeColumns = false;
        	this.dataGridViewRaport.AllowUserToResizeRows = false;
        	this.dataGridViewRaport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.dataGridViewRaport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        	this.dataGridViewRaport.BackgroundColor = System.Drawing.SystemColors.Control;
        	this.dataGridViewRaport.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.dataGridViewRaport.ColumnHeadersVisible = false;
        	dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
        	dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
        	dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        	this.dataGridViewRaport.DefaultCellStyle = dataGridViewCellStyle1;
        	this.dataGridViewRaport.Location = new System.Drawing.Point(6, 12);
        	this.dataGridViewRaport.Name = "dataGridViewRaport";
        	this.dataGridViewRaport.ReadOnly = true;
        	this.dataGridViewRaport.RowHeadersVisible = false;
        	this.dataGridViewRaport.Size = new System.Drawing.Size(965, 385);
        	this.dataGridViewRaport.TabIndex = 3;
        	this.dataGridViewRaport.Visible = false;
        	// 
        	// cboSheet
        	// 
        	this.cboSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.cboSheet.BackColor = System.Drawing.Color.White;
        	this.cboSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cboSheet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.cboSheet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.cboSheet.ForeColor = System.Drawing.Color.Black;
        	this.cboSheet.FormattingEnabled = true;
        	this.cboSheet.Location = new System.Drawing.Point(6, 12);
        	this.cboSheet.Name = "cboSheet";
        	this.cboSheet.Size = new System.Drawing.Size(964, 21);
        	this.cboSheet.TabIndex = 1;
        	this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
        	// 
        	// grdActiveSheet
        	// 
        	this.grdActiveSheet.AllowDrop = true;
        	this.grdActiveSheet.AllowUserToOrderColumns = true;
        	this.grdActiveSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.grdActiveSheet.BackgroundColor = System.Drawing.SystemColors.Control;
        	this.grdActiveSheet.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.grdActiveSheet.ColumnHeadersHeight = 22;
        	this.grdActiveSheet.ContextMenuStrip = this.contextMenuStrip2;
        	this.grdActiveSheet.Font = new System.Drawing.Font("Courier New", 9F);
        	this.grdActiveSheet.GridColor = System.Drawing.SystemColors.Control;
        	this.grdActiveSheet.Location = new System.Drawing.Point(6, 39);
        	this.grdActiveSheet.Name = "grdActiveSheet";
        	dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 9F);
        	dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
        	dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        	this.grdActiveSheet.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
        	this.grdActiveSheet.RowHeadersWidth = 22;
        	this.grdActiveSheet.Size = new System.Drawing.Size(964, 358);
        	this.grdActiveSheet.TabIndex = 0;
        	this.grdActiveSheet.Visible = false;
        	this.grdActiveSheet.Sorted += new System.EventHandler(this.grdActiveSheet_Sorted);
        	this.grdActiveSheet.Click += new System.EventHandler(this.grpdatagridview_Click);
        	this.grdActiveSheet.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop_Click);
        	this.grdActiveSheet.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter_Click);
        	// 
        	// contextMenuStrip2
        	// 
        	this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.otworzSkrot,
        	        	        	this.zapiszSkrot,
        	        	        	this.toolStripSeparator8,
        	        	        	this.licznikSkrot,
        	        	        	this.jobSkrot,
        	        	        	this.toolStripSeparator6,
        	        	        	this.podgladStrukturySkrot,
        	        	        	this.resetAllSkrot,
        	        	        	this.toolStripSeparator7,
        	        	        	this.narzedzia,
        	        	        	this.liniaKomSkrot});
        	this.contextMenuStrip2.Name = "contextMenuStrip1";
        	this.contextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	this.contextMenuStrip2.ShowCheckMargin = true;
        	this.contextMenuStrip2.ShowImageMargin = false;
        	this.contextMenuStrip2.Size = new System.Drawing.Size(215, 198);
        	// 
        	// otworzSkrot
        	// 
        	this.otworzSkrot.Name = "otworzSkrot";
        	this.otworzSkrot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
        	this.otworzSkrot.Size = new System.Drawing.Size(214, 22);
        	this.otworzSkrot.Text = "Wczytaj";
        	this.otworzSkrot.Click += new System.EventHandler(this.cmdLoad_Click2);
        	// 
        	// zapiszSkrot
        	// 
        	this.zapiszSkrot.Name = "zapiszSkrot";
        	this.zapiszSkrot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
        	this.zapiszSkrot.Size = new System.Drawing.Size(214, 22);
        	this.zapiszSkrot.Text = "Zapisz";
        	this.zapiszSkrot.Click += new System.EventHandler(this.SaveButton_Click);
        	// 
        	// toolStripSeparator8
        	// 
        	this.toolStripSeparator8.Name = "toolStripSeparator8";
        	this.toolStripSeparator8.Size = new System.Drawing.Size(211, 6);
        	// 
        	// licznikSkrot
        	// 
        	this.licznikSkrot.Name = "licznikSkrot";
        	this.licznikSkrot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
        	this.licznikSkrot.Size = new System.Drawing.Size(214, 22);
        	this.licznikSkrot.Text = "Licznik";
        	this.licznikSkrot.Click += new System.EventHandler(this.licznikButton_Click);
        	// 
        	// jobSkrot
        	// 
        	this.jobSkrot.Name = "jobSkrot";
        	this.jobSkrot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
        	this.jobSkrot.Size = new System.Drawing.Size(214, 22);
        	this.jobSkrot.Text = "Job";
        	this.jobSkrot.Click += new System.EventHandler(this.jobButton_Click);
        	// 
        	// toolStripSeparator6
        	// 
        	this.toolStripSeparator6.Name = "toolStripSeparator6";
        	this.toolStripSeparator6.Size = new System.Drawing.Size(211, 6);
        	// 
        	// podgladStrukturySkrot
        	// 
        	this.podgladStrukturySkrot.Name = "podgladStrukturySkrot";
        	this.podgladStrukturySkrot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
        	this.podgladStrukturySkrot.Size = new System.Drawing.Size(214, 22);
        	this.podgladStrukturySkrot.Text = "Podgląd struktury";
        	this.podgladStrukturySkrot.Click += new System.EventHandler(this.raport_Click);
        	// 
        	// resetAllSkrot
        	// 
        	this.resetAllSkrot.Name = "resetAllSkrot";
        	this.resetAllSkrot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
        	this.resetAllSkrot.Size = new System.Drawing.Size(214, 22);
        	this.resetAllSkrot.Text = "Reset All";
        	this.resetAllSkrot.Click += new System.EventHandler(this.clean_Click);
        	// 
        	// toolStripSeparator7
        	// 
        	this.toolStripSeparator7.Name = "toolStripSeparator7";
        	this.toolStripSeparator7.Size = new System.Drawing.Size(211, 6);
        	// 
        	// narzedzia
        	// 
        	this.narzedzia.Name = "narzedzia";
        	this.narzedzia.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Z)));
        	this.narzedzia.Size = new System.Drawing.Size(214, 22);
        	this.narzedzia.Text = "Narzędzia";
        	this.narzedzia.Click += new System.EventHandler(this.toolsButton_Click);
        	// 
        	// liniaKomSkrot
        	// 
        	this.liniaKomSkrot.Name = "liniaKomSkrot";
        	this.liniaKomSkrot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
        	this.liniaKomSkrot.Size = new System.Drawing.Size(214, 22);
        	this.liniaKomSkrot.Text = "Filtr";
        	this.liniaKomSkrot.Click += new System.EventHandler(this.liniaKomSkrot_Click);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        	this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
        	this.pictureBox1.Location = new System.Drawing.Point(928, 238);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(46, 144);
        	this.pictureBox1.TabIndex = 2;
        	this.pictureBox1.TabStop = false;
        	// 
        	// contextMenuStrip1
        	// 
        	this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripTextBox1});
        	this.contextMenuStrip1.Name = "contextMenuStrip1";
        	this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	this.contextMenuStrip1.ShowCheckMargin = true;
        	this.contextMenuStrip1.ShowImageMargin = false;
        	this.contextMenuStrip1.Size = new System.Drawing.Size(160, 26);
        	// 
        	// toolStripTextBox1
        	// 
        	this.toolStripTextBox1.Name = "toolStripTextBox1";
        	this.toolStripTextBox1.Size = new System.Drawing.Size(159, 22);
        	this.toolStripTextBox1.Text = "Kopiuj do pliku";
        	this.toolStripTextBox1.Click += new System.EventHandler(this.expRaportSzczToolStripMenuItem_Click);
        	// 
        	// openDialog
        	// 
        	this.openDialog.DefaultExt = "xls";
        	this.openDialog.Filter = "Excel files|*.xls";
        	this.openDialog.Multiselect = true;
        	this.openDialog.Title = "Choose an Excel file to open";
        	// 
        	// _statusstrip_down
        	// 
        	this._statusstrip_down.BackColor = System.Drawing.SystemColors.Control;
        	this._statusstrip_down.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this._progressBar,
        	        	        	this.licznik,
        	        	        	this._info});
        	this._statusstrip_down.Location = new System.Drawing.Point(0, 427);
        	this._statusstrip_down.Name = "_statusstrip_down";
        	this._statusstrip_down.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	this._statusstrip_down.Size = new System.Drawing.Size(981, 22);
        	this._statusstrip_down.TabIndex = 3;
        	// 
        	// _progressBar
        	// 
        	this._progressBar.AutoSize = false;
        	this._progressBar.BackColor = System.Drawing.Color.White;
        	this._progressBar.ForeColor = System.Drawing.Color.DarkRed;
        	this._progressBar.Name = "_progressBar";
        	this._progressBar.Size = new System.Drawing.Size(100, 16);
        	this._progressBar.Step = 1;
        	this._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this._progressBar.Value = 2;
        	this._progressBar.Visible = false;
        	// 
        	// licznik
        	// 
        	this.licznik.Name = "licznik";
        	this.licznik.Size = new System.Drawing.Size(416, 17);
        	this.licznik.Spring = true;
        	this.licznik.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// _info
        	// 
        	this._info.Name = "_info";
        	this._info.Size = new System.Drawing.Size(416, 17);
        	this._info.Spring = true;
        	this._info.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// toolStripContainer1
        	// 
        	// 
        	// toolStripContainer1.BottomToolStripPanel
        	// 
        	this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStripSortuj);
        	this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStripLiniaKom);
        	// 
        	// toolStripContainer1.ContentPanel
        	// 
        	this.toolStripContainer1.ContentPanel.Controls.Add(this.grpData);
        	this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(981, 402);
        	this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
        	this.toolStripContainer1.Name = "toolStripContainer1";
        	this.toolStripContainer1.Size = new System.Drawing.Size(981, 427);
        	this.toolStripContainer1.TabIndex = 5;
        	this.toolStripContainer1.Text = "toolStripContainer1";
        	// 
        	// toolStripContainer1.TopToolStripPanel
        	// 
        	this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuGlowne);
        	this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripNarzedzia);
        	this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripOpen);
        	this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripRaportZnaczik);
        	this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripZapisz);
        	this.toolStripContainer1.TopToolStripPanel.Click += new System.EventHandler(this.XLS2CSV_Load);
        	// 
        	// toolStripLiniaKom
        	// 
        	this.toolStripLiniaKom.BackColor = System.Drawing.SystemColors.Control;
        	this.toolStripLiniaKom.Dock = System.Windows.Forms.DockStyle.None;
        	this.toolStripLiniaKom.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStripLiniaKom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.expresja,
        	        	        	this.commandText,
        	        	        	this.toolStripButtonOK,
        	        	        	this.UsunFiltr,
        	        	        	this.toolStripButtonAcctpFilter});
        	this.toolStripLiniaKom.Location = new System.Drawing.Point(0, 0);
        	this.toolStripLiniaKom.Name = "toolStripLiniaKom";
        	this.toolStripLiniaKom.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	this.toolStripLiniaKom.Size = new System.Drawing.Size(584, 25);
        	this.toolStripLiniaKom.Stretch = true;
        	this.toolStripLiniaKom.TabIndex = 0;
        	this.toolStripLiniaKom.Visible = false;
        	// 
        	// expresja
        	// 
        	this.expresja.Name = "expresja";
        	this.expresja.Size = new System.Drawing.Size(73, 22);
        	this.expresja.Text = " Zapytanie:";
        	// 
        	// commandText
        	// 
        	this.commandText.AcceptsReturn = true;
        	this.commandText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
        	this.commandText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
        	this.commandText.AutoToolTip = true;
        	this.commandText.BackColor = System.Drawing.Color.White;
        	this.commandText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.commandText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.commandText.ForeColor = System.Drawing.Color.Black;
        	this.commandText.Name = "commandText";
        	this.commandText.Size = new System.Drawing.Size(300, 25);
        	this.commandText.ToolTipText = "pole1 (+ pole2...), operator(=,<>,<,>...), \'wartość\' ";
        	// 
        	// toolStripButtonOK
        	// 
        	this.toolStripButtonOK.BackColor = System.Drawing.Color.Transparent;
        	this.toolStripButtonOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.toolStripButtonOK.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOK.Image")));
        	this.toolStripButtonOK.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonOK.Name = "toolStripButtonOK";
        	this.toolStripButtonOK.Size = new System.Drawing.Size(64, 22);
        	this.toolStripButtonOK.Text = " Podgląd ";
        	this.toolStripButtonOK.Click += new System.EventHandler(this.toolStripButtonOK_Click);
        	// 
        	// UsunFiltr
        	// 
        	this.UsunFiltr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.UsunFiltr.Image = ((System.Drawing.Image)(resources.GetObject("UsunFiltr.Image")));
        	this.UsunFiltr.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.UsunFiltr.Name = "UsunFiltr";
        	this.UsunFiltr.Size = new System.Drawing.Size(76, 22);
        	this.UsunFiltr.Text = " Czyść filtr ";
        	this.UsunFiltr.Click += new System.EventHandler(this.toolStripButtonUsunFiltr_Click);
        	// 
        	// toolStripButtonAcctpFilter
        	// 
        	this.toolStripButtonAcctpFilter.BackColor = System.Drawing.Color.Transparent;
        	this.toolStripButtonAcctpFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.toolStripButtonAcctpFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.toolStripButtonAcctpFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAcctpFilter.Image")));
        	this.toolStripButtonAcctpFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonAcctpFilter.Name = "toolStripButtonAcctpFilter";
        	this.toolStripButtonAcctpFilter.Size = new System.Drawing.Size(66, 22);
        	this.toolStripButtonAcctpFilter.Text = " Zapisz filtr ";
        	this.toolStripButtonAcctpFilter.ToolTipText = " Zapisz filtr ";
        	this.toolStripButtonAcctpFilter.Click += new System.EventHandler(this.toolStripButtonAcctpFilter_Click);
        	// 
        	// toolStripSortuj
        	// 
        	this.toolStripSortuj.BackColor = System.Drawing.Color.Transparent;
        	this.toolStripSortuj.Dock = System.Windows.Forms.DockStyle.None;
        	this.toolStripSortuj.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStripSortuj.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.wybierzpolaStripLabel1,
        	        	        	this.sortComboBox1,
        	        	        	this.wybierzsortpolatoolStripLabel1,
        	        	        	this.AscDesc,
        	        	        	this.sortTextBox1,
        	        	        	this.sortujStripButton1});
        	this.toolStripSortuj.Location = new System.Drawing.Point(0, 0);
        	this.toolStripSortuj.Name = "toolStripSortuj";
        	this.toolStripSortuj.Size = new System.Drawing.Size(698, 25);
        	this.toolStripSortuj.Stretch = true;
        	this.toolStripSortuj.TabIndex = 2;
        	this.toolStripSortuj.Visible = false;
        	// 
        	// wybierzpolaStripLabel1
        	// 
        	this.wybierzpolaStripLabel1.Name = "wybierzpolaStripLabel1";
        	this.wybierzpolaStripLabel1.Size = new System.Drawing.Size(90, 22);
        	this.wybierzpolaStripLabel1.Text = " Wybierz pola:";
        	// 
        	// sortComboBox1
        	// 
        	this.sortComboBox1.BackColor = System.Drawing.Color.White;
        	this.sortComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.sortComboBox1.ForeColor = System.Drawing.Color.Black;
        	this.sortComboBox1.Name = "sortComboBox1";
        	this.sortComboBox1.Size = new System.Drawing.Size(105, 25);
        	this.sortComboBox1.SelectedIndexChanged += new System.EventHandler(this.sortIndexChanged_Click);
        	// 
        	// wybierzsortpolatoolStripLabel1
        	// 
        	this.wybierzsortpolatoolStripLabel1.Name = "wybierzsortpolatoolStripLabel1";
        	this.wybierzsortpolatoolStripLabel1.Size = new System.Drawing.Size(68, 22);
        	this.wybierzsortpolatoolStripLabel1.Text = "Sort pola: ";
        	// 
        	// AscDesc
        	// 
        	this.AscDesc.BackColor = System.Drawing.Color.White;
        	this.AscDesc.ForeColor = System.Drawing.Color.Black;
        	this.AscDesc.Items.AddRange(new object[] {
        	        	        	"Ascending",
        	        	        	"Descending"});
        	this.AscDesc.Name = "AscDesc";
        	this.AscDesc.Size = new System.Drawing.Size(80, 25);
        	this.AscDesc.Text = "Ascending";
        	this.AscDesc.SelectedIndexChanged += new System.EventHandler(this.ascendingindexChanged_Click);
        	// 
        	// sortTextBox1
        	// 
        	this.sortTextBox1.BackColor = System.Drawing.Color.White;
        	this.sortTextBox1.ForeColor = System.Drawing.Color.Black;
        	this.sortTextBox1.Name = "sortTextBox1";
        	this.sortTextBox1.Size = new System.Drawing.Size(300, 25);
        	// 
        	// sortujStripButton1
        	// 
        	this.sortujStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.sortujStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.biezacyPlikSort,
        	        	        	this.wszystkiePlikiSort});
        	this.sortujStripButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.sortujStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("sortujStripButton1.Image")));
        	this.sortujStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.sortujStripButton1.Name = "sortujStripButton1";
        	this.sortujStripButton1.ShowDropDownArrow = false;
        	this.sortujStripButton1.Size = new System.Drawing.Size(46, 22);
        	this.sortujStripButton1.Text = "Sortuj";
        	// 
        	// biezacyPlikSort
        	// 
        	this.biezacyPlikSort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.biezacyPlikSort.Name = "biezacyPlikSort";
        	this.biezacyPlikSort.Size = new System.Drawing.Size(142, 22);
        	this.biezacyPlikSort.Text = "Bieżący plik";
        	this.biezacyPlikSort.Click += new System.EventHandler(this.biezacyPlikSort_Click);
        	// 
        	// wszystkiePlikiSort
        	// 
        	this.wszystkiePlikiSort.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.wszystkiePlikiSort.Name = "wszystkiePlikiSort";
        	this.wszystkiePlikiSort.Size = new System.Drawing.Size(142, 22);
        	this.wszystkiePlikiSort.Text = "Wszystkie pliki";
        	this.wszystkiePlikiSort.Click += new System.EventHandler(this.wszystkiePlikiSort_Click);
        	// 
        	// menuGlowne
        	// 
        	this.menuGlowne.BackColor = System.Drawing.Color.Transparent;
        	this.menuGlowne.Dock = System.Windows.Forms.DockStyle.None;
        	this.menuGlowne.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.menuGlowne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.cmdLoad,
        	        	        	this.SaveButton,
        	        	        	this.StrukturaButton,
        	        	        	this.raport,
        	        	        	this.toolsButton,
        	        	        	this.Projekty,
        	        	        	this.CpCon,
        	        	        	this.jobButton,
        	        	        	this.licznikButton,
        	        	        	this.clean,
        	        	        	this.about});
        	this.menuGlowne.Location = new System.Drawing.Point(0, 0);
        	this.menuGlowne.Name = "menuGlowne";
        	this.menuGlowne.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        	this.menuGlowne.Size = new System.Drawing.Size(981, 25);
        	this.menuGlowne.Stretch = true;
        	this.menuGlowne.TabIndex = 0;
        	// 
        	// cmdLoad
        	// 
        	this.cmdLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.cmdLoad.Font = new System.Drawing.Font("Tahoma", 8.25F);
        	this.cmdLoad.ForeColor = System.Drawing.Color.Black;
        	this.cmdLoad.Image = ((System.Drawing.Image)(resources.GetObject("cmdLoad.Image")));
        	this.cmdLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.cmdLoad.Name = "cmdLoad";
        	this.cmdLoad.Size = new System.Drawing.Size(58, 22);
        	this.cmdLoad.Text = "Otwórz";
        	this.cmdLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.cmdLoad.ButtonClick += new System.EventHandler(this.cmdLoad_Click2);
        	this.cmdLoad.DropDownOpening += new System.EventHandler(this.cmdLoad_Click);
        	// 
        	// SaveButton
        	// 
        	this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
        	this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.SaveButton.Name = "SaveButton";
        	this.SaveButton.Size = new System.Drawing.Size(48, 22);
        	this.SaveButton.Text = "Zapisz";
        	this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
        	// 
        	// StrukturaButton
        	// 
        	this.StrukturaButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.StrukturaButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.importujStruktureToolStripMenuItem,
        	        	        	this.struktBiezacy,
        	        	        	this.struktWszystkie,
        	        	        	this.expRaportSzczToolStripMenuItem});
        	this.StrukturaButton.Image = ((System.Drawing.Image)(resources.GetObject("StrukturaButton.Image")));
        	this.StrukturaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.StrukturaButton.Name = "StrukturaButton";
        	this.StrukturaButton.ShowDropDownArrow = false;
        	this.StrukturaButton.Size = new System.Drawing.Size(65, 22);
        	this.StrukturaButton.Text = "Struktura";
        	this.StrukturaButton.Click += new System.EventHandler(this.StrukturaButton_Click);
        	// 
        	// importujStruktureToolStripMenuItem
        	// 
        	this.importujStruktureToolStripMenuItem.Name = "importujStruktureToolStripMenuItem";
        	this.importujStruktureToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
        	this.importujStruktureToolStripMenuItem.Text = "Importuj strukture bieżącego pliku";
        	this.importujStruktureToolStripMenuItem.Click += new System.EventHandler(this.importujStruktureToolStripMenuItem_Click);
        	// 
        	// struktBiezacy
        	// 
        	this.struktBiezacy.Name = "struktBiezacy";
        	this.struktBiezacy.Size = new System.Drawing.Size(302, 22);
        	this.struktBiezacy.Text = "Exportuj strukturę bieżącego pliku";
        	this.struktBiezacy.Click += new System.EventHandler(this.struktBiezacy_Click);
        	// 
        	// struktWszystkie
        	// 
        	this.struktWszystkie.Name = "struktWszystkie";
        	this.struktWszystkie.Size = new System.Drawing.Size(302, 22);
        	this.struktWszystkie.Text = "Exportuj strukturę wszystkich plikiów";
        	this.struktWszystkie.Click += new System.EventHandler(this.struktWszystkie_Click);
        	// 
        	// expRaportSzczToolStripMenuItem
        	// 
        	this.expRaportSzczToolStripMenuItem.Name = "expRaportSzczToolStripMenuItem";
        	this.expRaportSzczToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
        	this.expRaportSzczToolStripMenuItem.Text = "Exportuj raport szczegółowy ze strktury";
        	this.expRaportSzczToolStripMenuItem.Click += new System.EventHandler(this.expRaportSzczToolStripMenuItem_Click);
        	// 
        	// raport
        	// 
        	this.raport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.raport.Image = ((System.Drawing.Image)(resources.GetObject("raport.Image")));
        	this.raport.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.raport.Name = "raport";
        	this.raport.Size = new System.Drawing.Size(56, 22);
        	this.raport.Text = "Podgląd";
        	this.raport.Click += new System.EventHandler(this.raport_Click);
        	// 
        	// toolsButton
        	// 
        	this.toolsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.toolsButton.Image = ((System.Drawing.Image)(resources.GetObject("toolsButton.Image")));
        	this.toolsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolsButton.Name = "toolsButton";
        	this.toolsButton.Size = new System.Drawing.Size(67, 22);
        	this.toolsButton.Text = "Narzędzia";
        	this.toolsButton.Click += new System.EventHandler(this.toolsButton_Click);
        	// 
        	// Projekty
        	// 
        	this.Projekty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.Projekty.Image = ((System.Drawing.Image)(resources.GetObject("Projekty.Image")));
        	this.Projekty.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.Projekty.Name = "Projekty";
        	this.Projekty.ShowDropDownArrow = false;
        	this.Projekty.Size = new System.Drawing.Size(59, 22);
        	this.Projekty.Text = "Projekty";
        	// 
        	// CpCon
        	// 
        	this.CpCon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.CpCon.Image = ((System.Drawing.Image)(resources.GetObject("CpCon.Image")));
        	this.CpCon.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.CpCon.Name = "CpCon";
        	this.CpCon.Size = new System.Drawing.Size(89, 22);
        	this.CpCon.Text = "CP Converter";
        	this.CpCon.Click += new System.EventHandler(this.CpCon_Click);
        	// 
        	// jobButton
        	// 
        	this.jobButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.jobButton.Image = ((System.Drawing.Image)(resources.GetObject("jobButton.Image")));
        	this.jobButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.jobButton.Name = "jobButton";
        	this.jobButton.Size = new System.Drawing.Size(30, 22);
        	this.jobButton.Text = "Job";
        	this.jobButton.Click += new System.EventHandler(this.jobButton_Click);
        	// 
        	// licznikButton
        	// 
        	this.licznikButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.licznikButton.Font = new System.Drawing.Font("Tahoma", 8.25F);
        	this.licznikButton.Image = ((System.Drawing.Image)(resources.GetObject("licznikButton.Image")));
        	this.licznikButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.licznikButton.Name = "licznikButton";
        	this.licznikButton.Size = new System.Drawing.Size(53, 22);
        	this.licznikButton.Text = "Licznik";
        	this.licznikButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.licznikButton.ButtonClick += new System.EventHandler(this.licznikButton_Click);
        	this.licznikButton.DropDownOpening += new System.EventHandler(this.licznikButton_Click2);
        	// 
        	// clean
        	// 
        	this.clean.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.clean.Image = ((System.Drawing.Image)(resources.GetObject("clean.Image")));
        	this.clean.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.clean.Name = "clean";
        	this.clean.Size = new System.Drawing.Size(43, 22);
        	this.clean.Text = "Reset";
        	this.clean.Click += new System.EventHandler(this.clean_Click);
        	// 
        	// about
        	// 
        	this.about.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.about.Image = ((System.Drawing.Image)(resources.GetObject("about.Image")));
        	this.about.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.about.Name = "about";
        	this.about.Size = new System.Drawing.Size(34, 22);
        	this.about.Text = "Info";
        	this.about.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.about.ToolTipText = "Info";
        	this.about.Click += new System.EventHandler(this.about_Click);
        	// 
        	// toolStripRaportZnaczik
        	// 
        	this.toolStripRaportZnaczik.BackColor = System.Drawing.Color.Transparent;
        	this.toolStripRaportZnaczik.Dock = System.Windows.Forms.DockStyle.None;
        	this.toolStripRaportZnaczik.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStripRaportZnaczik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripText,
        	        	        	this.znaczikTextBox,
        	        	        	this.csvNaglowki,
        	        	        	this.csvNaglowkiComboBox1});
        	this.toolStripRaportZnaczik.Location = new System.Drawing.Point(0, 25);
        	this.toolStripRaportZnaczik.Name = "toolStripRaportZnaczik";
        	this.toolStripRaportZnaczik.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	this.toolStripRaportZnaczik.Size = new System.Drawing.Size(531, 25);
        	this.toolStripRaportZnaczik.Stretch = true;
        	this.toolStripRaportZnaczik.TabIndex = 3;
        	this.toolStripRaportZnaczik.Visible = false;
        	// 
        	// toolStripText
        	// 
        	this.toolStripText.Name = "toolStripText";
        	this.toolStripText.Size = new System.Drawing.Size(199, 22);
        	this.toolStripText.Text = " Znacznik struktury dynamicznej:";
        	// 
        	// znaczikTextBox
        	// 
        	this.znaczikTextBox.BackColor = System.Drawing.Color.White;
        	this.znaczikTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.znaczikTextBox.ForeColor = System.Drawing.Color.Black;
        	this.znaczikTextBox.Name = "znaczikTextBox";
        	this.znaczikTextBox.Size = new System.Drawing.Size(30, 25);
        	this.znaczikTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	// 
        	// csvNaglowki
        	// 
        	this.csvNaglowki.Name = "csvNaglowki";
        	this.csvNaglowki.Size = new System.Drawing.Size(220, 22);
        	this.csvNaglowki.Text = "   Pliki(i) CSV i XLS* mają nagłówki: ";
        	// 
        	// csvNaglowkiComboBox1
        	// 
        	this.csvNaglowkiComboBox1.BackColor = System.Drawing.Color.White;
        	this.csvNaglowkiComboBox1.ForeColor = System.Drawing.Color.Black;
        	this.csvNaglowkiComboBox1.Items.AddRange(new object[] {
        	        	        	"TAK",
        	        	        	"NIE"});
        	this.csvNaglowkiComboBox1.Name = "csvNaglowkiComboBox1";
        	this.csvNaglowkiComboBox1.Size = new System.Drawing.Size(75, 25);
        	this.csvNaglowkiComboBox1.Text = "TAK";
        	// 
        	// toolStripNarzedzia
        	// 
        	this.toolStripNarzedzia.BackColor = System.Drawing.Color.Transparent;
        	this.toolStripNarzedzia.Dock = System.Windows.Forms.DockStyle.None;
        	this.toolStripNarzedzia.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStripNarzedzia.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.Sortuj,
        	        	        	this.lp,
        	        	        	this.nupTextBox1,
        	        	        	this.nup,
        	        	        	this.odwroc,
        	        	        	this.scalTab,
        	        	        	this.toolStripDodajKol,
        	        	        	this.ssy,
        	        	        	this.wybierzPole,
        	        	        	this.poprComboBox2,
        	        	        	this.poprComboBox});
        	this.toolStripNarzedzia.Location = new System.Drawing.Point(0, 25);
        	this.toolStripNarzedzia.Name = "toolStripNarzedzia";
        	this.toolStripNarzedzia.Size = new System.Drawing.Size(652, 25);
        	this.toolStripNarzedzia.Stretch = true;
        	this.toolStripNarzedzia.TabIndex = 5;
        	this.toolStripNarzedzia.Visible = false;
        	// 
        	// Sortuj
        	// 
        	this.Sortuj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.Sortuj.Image = ((System.Drawing.Image)(resources.GetObject("Sortuj.Image")));
        	this.Sortuj.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.Sortuj.Name = "Sortuj";
        	this.Sortuj.Size = new System.Drawing.Size(46, 22);
        	this.Sortuj.Text = "Sortuj";
        	this.Sortuj.Click += new System.EventHandler(this.Sortuj_Click);
        	// 
        	// lp
        	// 
        	this.lp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.lp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.bieżącyPlikLp,
        	        	        	this.wszystkiePlikiLp});
        	this.lp.Font = new System.Drawing.Font("Tahoma", 8.25F);
        	this.lp.ForeColor = System.Drawing.Color.Black;
        	this.lp.Image = ((System.Drawing.Image)(resources.GetObject("lp.Image")));
        	this.lp.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.lp.Name = "lp";
        	this.lp.ShowDropDownArrow = false;
        	this.lp.Size = new System.Drawing.Size(56, 22);
        	this.lp.Text = "Dodaj Lp ";
        	this.lp.ToolTipText = "Dodaj Lp ";
        	// 
        	// bieżącyPlikLp
        	// 
        	this.bieżącyPlikLp.Name = "bieżącyPlikLp";
        	this.bieżącyPlikLp.Size = new System.Drawing.Size(142, 22);
        	this.bieżącyPlikLp.Text = "Bieżący plik";
        	this.bieżącyPlikLp.Click += new System.EventHandler(this.biezacyPlikLp_Click);
        	// 
        	// wszystkiePlikiLp
        	// 
        	this.wszystkiePlikiLp.Name = "wszystkiePlikiLp";
        	this.wszystkiePlikiLp.Size = new System.Drawing.Size(142, 22);
        	this.wszystkiePlikiLp.Text = "Wszystkie pliki";
        	this.wszystkiePlikiLp.Click += new System.EventHandler(this.wszystkiePlikiLp_Click);
        	// 
        	// nupTextBox1
        	// 
        	this.nupTextBox1.BackColor = System.Drawing.Color.White;
        	this.nupTextBox1.Font = new System.Drawing.Font("Tahoma", 8F);
        	this.nupTextBox1.ForeColor = System.Drawing.Color.Black;
        	this.nupTextBox1.Name = "nupTextBox1";
        	this.nupTextBox1.Size = new System.Drawing.Size(20, 25);
        	this.nupTextBox1.Text = "2";
        	this.nupTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	// 
        	// nup
        	// 
        	this.nup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.nup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.bieżącyPlikNup,
        	        	        	this.wszystkiePlikiNup});
        	this.nup.Font = new System.Drawing.Font("Tahoma", 8.25F);
        	this.nup.ForeColor = System.Drawing.Color.Black;
        	this.nup.Image = ((System.Drawing.Image)(resources.GetObject("nup.Image")));
        	this.nup.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.nup.Name = "nup";
        	this.nup.ShowDropDownArrow = false;
        	this.nup.Size = new System.Drawing.Size(27, 22);
        	this.nup.Text = "Up ";
        	this.nup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// bieżącyPlikNup
        	// 
        	this.bieżącyPlikNup.Name = "bieżącyPlikNup";
        	this.bieżącyPlikNup.Size = new System.Drawing.Size(142, 22);
        	this.bieżącyPlikNup.Text = "Bieżący plik";
        	this.bieżącyPlikNup.Click += new System.EventHandler(this.biezacyPlikNup_Click);
        	// 
        	// wszystkiePlikiNup
        	// 
        	this.wszystkiePlikiNup.Name = "wszystkiePlikiNup";
        	this.wszystkiePlikiNup.Size = new System.Drawing.Size(142, 22);
        	this.wszystkiePlikiNup.Text = "Wszystkie pliki";
        	this.wszystkiePlikiNup.Click += new System.EventHandler(this.wszystkiePlikiNup_Click);
        	// 
        	// odwroc
        	// 
        	this.odwroc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.biezacyPlikOdwr,
        	        	        	this.wszystkiePlikiOdwr});
        	this.odwroc.Name = "odwroc";
        	this.odwroc.ShowDropDownArrow = false;
        	this.odwroc.Size = new System.Drawing.Size(54, 22);
        	this.odwroc.Text = "Odwróć";
        	// 
        	// biezacyPlikOdwr
        	// 
        	this.biezacyPlikOdwr.Name = "biezacyPlikOdwr";
        	this.biezacyPlikOdwr.Size = new System.Drawing.Size(158, 22);
        	this.biezacyPlikOdwr.Text = "Biezacy plik";
        	this.biezacyPlikOdwr.Click += new System.EventHandler(this.biezacyPlikOdwr_Click);
        	// 
        	// wszystkiePlikiOdwr
        	// 
        	this.wszystkiePlikiOdwr.Name = "wszystkiePlikiOdwr";
        	this.wszystkiePlikiOdwr.Size = new System.Drawing.Size(158, 22);
        	this.wszystkiePlikiOdwr.Text = "Wszystkie pliki";
        	this.wszystkiePlikiOdwr.Click += new System.EventHandler(this.wszystkiePlikiOdwr_Click);
        	// 
        	// scalTab
        	// 
        	this.scalTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.scalTab.Image = ((System.Drawing.Image)(resources.GetObject("scalTab.Image")));
        	this.scalTab.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.scalTab.Name = "scalTab";
        	this.scalTab.Size = new System.Drawing.Size(74, 22);
        	this.scalTab.Text = "Scal tabele";
        	this.scalTab.Click += new System.EventHandler(this.scalTab_Click);
        	// 
        	// toolStripDodajKol
        	// 
        	this.toolStripDodajKol.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.bieżącyPlikToolStripMenuItem,
        	        	        	this.wszystkiePlikiToolStripMenuItem});
        	this.toolStripDodajKol.Name = "toolStripDodajKol";
        	this.toolStripDodajKol.Size = new System.Drawing.Size(70, 25);
        	this.toolStripDodajKol.Text = "BazaDba";
        	this.toolStripDodajKol.ToolTipText = "Dodaje nazwe bazy w pole BAZADBA";
        	// 
        	// bieżącyPlikToolStripMenuItem
        	// 
        	this.bieżącyPlikToolStripMenuItem.Name = "bieżącyPlikToolStripMenuItem";
        	this.bieżącyPlikToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
        	this.bieżącyPlikToolStripMenuItem.Text = "Bieżący plik";
        	this.bieżącyPlikToolStripMenuItem.Click += new System.EventHandler(this.biezacyPlikToolStripMenuItem_Click);
        	// 
        	// wszystkiePlikiToolStripMenuItem
        	// 
        	this.wszystkiePlikiToolStripMenuItem.Name = "wszystkiePlikiToolStripMenuItem";
        	this.wszystkiePlikiToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
        	this.wszystkiePlikiToolStripMenuItem.Text = "Wszystkie pliki";
        	this.wszystkiePlikiToolStripMenuItem.Click += new System.EventHandler(this.wszystkiePlikiToolStripMenuItem_Click);
        	// 
        	// ssy
        	// 
        	this.ssy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.ssy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.rMusterToolStripMenuItem,
        	        	        	this.rekordyKontrolneToolStripMenuItem,
        	        	        	this.wzoryToolStripMenuItem});
        	this.ssy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.ssy.Image = ((System.Drawing.Image)(resources.GetObject("ssy.Image")));
        	this.ssy.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.ssy.Name = "ssy";
        	this.ssy.Size = new System.Drawing.Size(60, 22);
        	this.ssy.Text = "Kontrola";
        	// 
        	// rMusterToolStripMenuItem
        	// 
        	this.rMusterToolStripMenuItem.Name = "rMusterToolStripMenuItem";
        	this.rMusterToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
        	this.rMusterToolStripMenuItem.Text = "R-Muster";
        	this.rMusterToolStripMenuItem.Click += new System.EventHandler(this.rMusterToolStripMenuItem_Click);
        	// 
        	// rekordyKontrolneToolStripMenuItem
        	// 
        	this.rekordyKontrolneToolStripMenuItem.Name = "rekordyKontrolneToolStripMenuItem";
        	this.rekordyKontrolneToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
        	this.rekordyKontrolneToolStripMenuItem.Text = "Rekordy kontrolne";
        	this.rekordyKontrolneToolStripMenuItem.Click += new System.EventHandler(this.rekordyKontrolneToolStripMenuItem_Click);
        	// 
        	// wzoryToolStripMenuItem
        	// 
        	this.wzoryToolStripMenuItem.Name = "wzoryToolStripMenuItem";
        	this.wzoryToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
        	this.wzoryToolStripMenuItem.Text = "Wzory";
        	this.wzoryToolStripMenuItem.Click += new System.EventHandler(this.wzoryToolStripMenuItem_Click);
        	// 
        	// wybierzPole
        	// 
        	this.wybierzPole.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.wczytajPoprawki,
        	        	        	this.wczytajDnp,
        	        	        	this.deduplikacja,
        	        	        	this.usuńKolumnęToolStripMenuItem,
        	        	        	this.wolaczToolStripMenuItem,
        	        	        	this.plecToolStripMenuItem});
        	this.wybierzPole.Name = "wybierzPole";
        	this.wybierzPole.Size = new System.Drawing.Size(136, 22);
        	this.wybierzPole.Text = "Operacja na polach:";
        	this.wybierzPole.ToolTipText = "Zaznacz pole(a) z listy obok i wybierz opcję";
        	// 
        	// wczytajPoprawki
        	// 
        	this.wczytajPoprawki.Name = "wczytajPoprawki";
        	this.wczytajPoprawki.Size = new System.Drawing.Size(169, 22);
        	this.wczytajPoprawki.Text = "Znajdź poprawki";
        	this.wczytajPoprawki.ToolTipText = "Wczytaj poprawki z pola obok ";
        	this.wczytajPoprawki.Click += new System.EventHandler(this.wczytajPoprawki_Click);
        	// 
        	// wczytajDnp
        	// 
        	this.wczytajDnp.Name = "wczytajDnp";
        	this.wczytajDnp.Size = new System.Drawing.Size(169, 22);
        	this.wczytajDnp.Text = "Usuń dnp";
        	this.wczytajDnp.ToolTipText = "Wczytaj dnp z pola obok i je odrzuć";
        	this.wczytajDnp.Click += new System.EventHandler(this.wczytajDnp_Click);
        	// 
        	// deduplikacja
        	// 
        	this.deduplikacja.Name = "deduplikacja";
        	this.deduplikacja.Size = new System.Drawing.Size(169, 22);
        	this.deduplikacja.Text = "Wybierz duplikty";
        	this.deduplikacja.ToolTipText = "Znajdź duplikaty w polu obok";
        	this.deduplikacja.Click += new System.EventHandler(this.deduplikacja_Click);
        	// 
        	// usuńKolumnęToolStripMenuItem
        	// 
        	this.usuńKolumnęToolStripMenuItem.Name = "usuńKolumnęToolStripMenuItem";
        	this.usuńKolumnęToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
        	this.usuńKolumnęToolStripMenuItem.Text = "Usuń kolumny";
        	this.usuńKolumnęToolStripMenuItem.ToolTipText = "Usuń kolumne";
        	this.usuńKolumnęToolStripMenuItem.Click += new System.EventHandler(this.usunKolumne_Click);
        	// 
        	// wolaczToolStripMenuItem
        	// 
        	this.wolaczToolStripMenuItem.Name = "wolaczToolStripMenuItem";
        	this.wolaczToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
        	this.wolaczToolStripMenuItem.Text = "Dodaj wołacz";
        	this.wolaczToolStripMenuItem.Click += new System.EventHandler(this.wolaczToolStripMenuItem_Click);
        	// 
        	// plecToolStripMenuItem
        	// 
        	this.plecToolStripMenuItem.Name = "plecToolStripMenuItem";
        	this.plecToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
        	this.plecToolStripMenuItem.Text = "Dodaj płec";
        	this.plecToolStripMenuItem.Click += new System.EventHandler(this.plecToolStripMenuItem_Click);
        	// 
        	// poprComboBox2
        	// 
        	this.poprComboBox2.AutoToolTip = true;
        	this.poprComboBox2.BackColor = System.Drawing.Color.DarkGray;
        	this.poprComboBox2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.poprComboBox2.ForeColor = System.Drawing.Color.White;
        	this.poprComboBox2.Name = "poprComboBox2";
        	this.poprComboBox2.Size = new System.Drawing.Size(0, 25);
        	this.poprComboBox2.ToolTipText = "Wybierz pole niezbędbe do zastosowania poniższych opcji";
        	this.poprComboBox2.TextChanged += new System.EventHandler(this.textChanged_Click);
        	// 
        	// poprComboBox
        	// 
        	this.poprComboBox.AutoToolTip = true;
        	this.poprComboBox.BackColor = System.Drawing.Color.White;
        	this.poprComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.poprComboBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.poprComboBox.ForeColor = System.Drawing.Color.Black;
        	this.poprComboBox.Name = "poprComboBox";
        	this.poprComboBox.Size = new System.Drawing.Size(100, 25);
        	this.poprComboBox.ToolTipText = "Wybierz pole niezbędbe do zastosowania poniższych opcji";
        	this.poprComboBox.SelectedIndexChanged += new System.EventHandler(this.IndexChanged_Click);
        	// 
        	// toolStripOpen
        	// 
        	this.toolStripOpen.BackColor = System.Drawing.Color.Transparent;
        	this.toolStripOpen.Dock = System.Windows.Forms.DockStyle.None;
        	this.toolStripOpen.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStripOpen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripLabelOpen,
        	        	        	this.cpOpen});
        	this.toolStripOpen.Location = new System.Drawing.Point(0, 25);
        	this.toolStripOpen.Name = "toolStripOpen";
        	this.toolStripOpen.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	this.toolStripOpen.Size = new System.Drawing.Size(581, 25);
        	this.toolStripOpen.Stretch = true;
        	this.toolStripOpen.TabIndex = 4;
        	this.toolStripOpen.Visible = false;
        	// 
        	// toolStripLabelOpen
        	// 
        	this.toolStripLabelOpen.Name = "toolStripLabelOpen";
        	this.toolStripLabelOpen.Size = new System.Drawing.Size(126, 22);
        	this.toolStripLabelOpen.Text = " Code Page (Input): ";
        	// 
        	// cpOpen
        	// 
        	this.cpOpen.AutoCompleteCustomSource.AddRange(new string[] {
        	        	        	"",
        	        	        	"37       IBM037             IBM EBCDIC (US-Canada)",
        	        	        	"437      IBM437             OEM United States",
        	        	        	"500      IBM500             IBM EBCDIC (International)",
        	        	        	"708      ASMO-708           Arabic (ASMO 708)",
        	        	        	"720      DOS-720            Arabic (DOS)",
        	        	        	"737      ibm737             Greek (DOS)",
        	        	        	"775      ibm775             Baltic (DOS)",
        	        	        	"850      ibm850             Western European (DOS)",
        	        	        	"852      ibm852             Central European (DOS)",
        	        	        	"855      IBM855             OEM Cyrillic",
        	        	        	"857      ibm857             Turkish (DOS)",
        	        	        	"858      IBM00858           OEM Multilingual Latin I",
        	        	        	"860      IBM860             Portuguese (DOS)",
        	        	        	"861      ibm861             Icelandic (DOS)",
        	        	        	"862      DOS-862            Hebrew (DOS)",
        	        	        	"863      IBM863             French Canadian (DOS)",
        	        	        	"864      IBM864             Arabic (864)",
        	        	        	"865      IBM865             Nordic (DOS)",
        	        	        	"866      cp866              Cyrillic (DOS)",
        	        	        	"869      ibm869             Greek, Modern (DOS)",
        	        	        	"870      IBM870             IBM EBCDIC (Multilingual Latin-2)",
        	        	        	"874      windows-874        Thai (Windows)",
        	        	        	"875      cp875              IBM EBCDIC (Greek Modern)",
        	        	        	"932      shift_jis          Japanese (Shift-JIS)",
        	        	        	"936      gb2312             Chinese Simplified (GB2312)",
        	        	        	"949      ks_c_5601-1987     Korean",
        	        	        	"950      big5               Chinese Traditional (Big5)",
        	        	        	"1026     IBM1026            IBM EBCDIC (Turkish Latin-5)",
        	        	        	"1047     IBM01047           IBM Latin-1",
        	        	        	"1140     IBM01140           IBM EBCDIC (US-Canada-Euro)",
        	        	        	"1141     IBM01141           IBM EBCDIC (Germany-Euro)",
        	        	        	"1142     IBM01142           IBM EBCDIC (Denmark-Norway-Euro)",
        	        	        	"1143     IBM01143           IBM EBCDIC (Finland-Sweden-Euro)",
        	        	        	"1144     IBM01144           IBM EBCDIC (Italy-Euro)",
        	        	        	"1145     IBM01145           IBM EBCDIC (Spain-Euro)",
        	        	        	"1146     IBM01146           IBM EBCDIC (UK-Euro)",
        	        	        	"1147     IBM01147           IBM EBCDIC (France-Euro)",
        	        	        	"1148     IBM01148           IBM EBCDIC (International-Euro)",
        	        	        	"1149     IBM01149           IBM EBCDIC (Icelandic-Euro)",
        	        	        	"1200     utf-16             Unicode",
        	        	        	"1201     unicodeFFFE        Unicode (Big-Endian)",
        	        	        	"1250     windows-1250       Central European (Windows)",
        	        	        	"1251     windows-1251       Cyrillic (Windows)",
        	        	        	"1252     Windows-1252       Western European (Windows)",
        	        	        	"1253     windows-1253       Greek (Windows)",
        	        	        	"1254     windows-1254       Turkish (Windows)",
        	        	        	"1255     windows-1255       Hebrew (Windows)",
        	        	        	"1256     windows-1256       Arabic (Windows)",
        	        	        	"1257     windows-1257       Baltic (Windows)",
        	        	        	"1258     windows-1258       Vietnamese (Windows)",
        	        	        	"1361     Johab              Korean (Johab)",
        	        	        	"10000    macintosh          Western European (Mac)",
        	        	        	"10001    x-mac-japanese     Japanese (Mac)",
        	        	        	"10002    x-mac-chinesetrad  Chinese Traditional (Mac)",
        	        	        	"10003    x-mac-korean       Korean (Mac)",
        	        	        	"10004    x-mac-arabic       Arabic (Mac)",
        	        	        	"10005    x-mac-hebrew       Hebrew (Mac)",
        	        	        	"10006    x-mac-greek        Greek (Mac)",
        	        	        	"10007    x-mac-cyrillic     Cyrillic (Mac)",
        	        	        	"10008    x-mac-chinesesimp  Chinese Simplified (Mac)",
        	        	        	"10010    x-mac-romanian     Romanian (Mac)",
        	        	        	"10017    x-mac-ukrainian    Ukrainian (Mac)",
        	        	        	"10021    x-mac-thai         Thai (Mac)",
        	        	        	"10029    x-mac-ce           Central European (Mac)",
        	        	        	"10079    x-mac-icelandic    Icelandic (Mac)",
        	        	        	"10081    x-mac-turkish      Turkish (Mac)",
        	        	        	"10082    x-mac-croatian     Croatian (Mac)",
        	        	        	"20000    x-Chinese-CNS      Chinese Traditional (CNS)",
        	        	        	"20001    x-cp20001          TCA Taiwan",
        	        	        	"20002    x-Chinese-Eten     Chinese Traditional (Eten)",
        	        	        	"20003    x-cp20003          IBM5550 Taiwan",
        	        	        	"20004    x-cp20004          TeleText Taiwan",
        	        	        	"20005    x-cp20005          Wang Taiwan",
        	        	        	"20105    x-IA5              Western European (IA5)",
        	        	        	"20106    x-IA5-German       German (IA5)",
        	        	        	"20107    x-IA5-Swedish      Swedish (IA5)",
        	        	        	"20108    x-IA5-Norwegian    Norwegian (IA5)",
        	        	        	"20127    us-ascii           US-ASCII",
        	        	        	"20261    x-cp20261          T.61",
        	        	        	"20269    x-cp20269          ISO-6937",
        	        	        	"20273    IBM273             IBM EBCDIC (Germany)",
        	        	        	"20277    IBM277             IBM EBCDIC (Denmark-Norway)",
        	        	        	"20278    IBM278             IBM EBCDIC (Finland-Sweden)",
        	        	        	"20280    IBM280             IBM EBCDIC (Italy)",
        	        	        	"20284    IBM284             IBM EBCDIC (Spain)",
        	        	        	"20285    IBM285             IBM EBCDIC (UK)",
        	        	        	"20290    IBM290             IBM EBCDIC (Japanese katakana)",
        	        	        	"20297    IBM297             IBM EBCDIC (France)",
        	        	        	"20420    IBM420             IBM EBCDIC (Arabic)",
        	        	        	"20423    IBM423             IBM EBCDIC (Greek)",
        	        	        	"20424    IBM424             IBM EBCDIC (Hebrew)",
        	        	        	"20833    x-EBCDIC           IBM EBCDIC (Korean Extended)",
        	        	        	"20838    IBM-Thai           IBM EBCDIC (Thai)",
        	        	        	"20866    koi8-r             Cyrillic (KOI8-R)",
        	        	        	"20871    IBM871             IBM EBCDIC (Icelandic)",
        	        	        	"20880    IBM880             IBM EBCDIC (Cyrillic Russian)",
        	        	        	"20905    IBM905             IBM EBCDIC (Turkish)",
        	        	        	"20924    IBM00924           IBM Latin-1",
        	        	        	"20932    EUC-JP             Japanese (JIS 0208-1990 and 0212-1990)",
        	        	        	"20936    x-cp20936          Chinese Simplified (GB2312-80)",
        	        	        	"20949    x-cp20949          Korean Wansung",
        	        	        	"21025    cp1025             IBM EBCDIC (Cyrillic Serbian-Bulgarian)",
        	        	        	"21866    koi8-u             Cyrillic (KOI8-U)",
        	        	        	"28591    iso-8859-1         Western European (ISO)",
        	        	        	"28592    iso-8859-2         Central European (ISO)",
        	        	        	"28593    iso-8859-3         Latin 3 (ISO)",
        	        	        	"28594    iso-8859-4         Baltic (ISO)",
        	        	        	"28595    iso-8859-5         Cyrillic (ISO)",
        	        	        	"28596    iso-8859-6         Arabic (ISO)",
        	        	        	"28597    iso-8859-7         Greek (ISO)",
        	        	        	"28598    iso-8859-8         Hebrew (ISO-Visual)",
        	        	        	"28599    iso-8859-9         Turkish (ISO)",
        	        	        	"28603    iso-8859-13        Estonian (ISO)",
        	        	        	"28605    iso-8859-15        Latin 9 (ISO)",
        	        	        	"29001    x-Europa           Europa",
        	        	        	"38598    iso-8859-8-i       Hebrew (ISO-Logical)",
        	        	        	"50220    iso-2022-jp        Japanese (JIS)",
        	        	        	"50221    csISO2022JP        Japanese (JIS-Allow 1 byte Kana) ",
        	        	        	"50222    iso-2022-jp        Japanese (JIS-Allow 1 byte Kana - SO/SI)",
        	        	        	"50225    iso-2022-kr        Korean (ISO)",
        	        	        	"50227    x-cp50227          Chinese Simplified (ISO-2022)",
        	        	        	"51932    euc-jp             Japanese (EUC)",
        	        	        	"51936    EUC-CN             Chinese Simplified (EUC)",
        	        	        	"51949    euc-kr             Korean (EUC)",
        	        	        	"52936    hz-gb-2312         Chinese Simplified (HZ)",
        	        	        	"54936    GB18030            Chinese Simplified (GB18030)",
        	        	        	"57002    x-iscii-de         ISCII Devanagari",
        	        	        	"57003    x-iscii-be         ISCII Bengali",
        	        	        	"57004    x-iscii-ta         ISCII Tamil",
        	        	        	"57005    x-iscii-te         ISCII Telugu",
        	        	        	"57006    x-iscii-as         ISCII Assamese",
        	        	        	"57007    x-iscii-or         ISCII Oriya",
        	        	        	"57008    x-iscii-ka         ISCII Kannada",
        	        	        	"57009    x-iscii-ma         ISCII Malayalam",
        	        	        	"57010    x-iscii-gu         ISCII Gujarati",
        	        	        	"57011    x-iscii-pa         ISCII Punjabi",
        	        	        	"65000    utf-7              Unicode (UTF-7)",
        	        	        	"65001    utf-8              Unicode (UTF-8)"});
        	this.cpOpen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
        	this.cpOpen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        	this.cpOpen.BackColor = System.Drawing.Color.White;
        	this.cpOpen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cpOpen.Font = new System.Drawing.Font("Courier New", 9.360001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.cpOpen.ForeColor = System.Drawing.Color.DimGray;
        	this.cpOpen.Items.AddRange(new object[] {
        	        	        	"",
        	        	        	"37       IBM037             IBM EBCDIC (US-Canada)",
        	        	        	"437      IBM437             OEM United States",
        	        	        	"500      IBM500             IBM EBCDIC (International)",
        	        	        	"708      ASMO-708           Arabic (ASMO 708)",
        	        	        	"720      DOS-720            Arabic (DOS)",
        	        	        	"737      ibm737             Greek (DOS)",
        	        	        	"775      ibm775             Baltic (DOS)",
        	        	        	"850      ibm850             Western European (DOS)",
        	        	        	"852      ibm852             Central European (DOS)",
        	        	        	"855      IBM855             OEM Cyrillic",
        	        	        	"857      ibm857             Turkish (DOS)",
        	        	        	"858      IBM00858           OEM Multilingual Latin I",
        	        	        	"860      IBM860             Portuguese (DOS)",
        	        	        	"861      ibm861             Icelandic (DOS)",
        	        	        	"862      DOS-862            Hebrew (DOS)",
        	        	        	"863      IBM863             French Canadian (DOS)",
        	        	        	"864      IBM864             Arabic (864)",
        	        	        	"865      IBM865             Nordic (DOS)",
        	        	        	"866      cp866              Cyrillic (DOS)",
        	        	        	"869      ibm869             Greek, Modern (DOS)",
        	        	        	"870      IBM870             IBM EBCDIC (Multilingual Latin-2)",
        	        	        	"874      windows-874        Thai (Windows)",
        	        	        	"875      cp875              IBM EBCDIC (Greek Modern)",
        	        	        	"932      shift_jis          Japanese (Shift-JIS)",
        	        	        	"936      gb2312             Chinese Simplified (GB2312)",
        	        	        	"949      ks_c_5601-1987     Korean",
        	        	        	"950      big5               Chinese Traditional (Big5)",
        	        	        	"1026     IBM1026            IBM EBCDIC (Turkish Latin-5)",
        	        	        	"1047     IBM01047           IBM Latin-1",
        	        	        	"1140     IBM01140           IBM EBCDIC (US-Canada-Euro)",
        	        	        	"1141     IBM01141           IBM EBCDIC (Germany-Euro)",
        	        	        	"1142     IBM01142           IBM EBCDIC (Denmark-Norway-Euro)",
        	        	        	"1143     IBM01143           IBM EBCDIC (Finland-Sweden-Euro)",
        	        	        	"1144     IBM01144           IBM EBCDIC (Italy-Euro)",
        	        	        	"1145     IBM01145           IBM EBCDIC (Spain-Euro)",
        	        	        	"1146     IBM01146           IBM EBCDIC (UK-Euro)",
        	        	        	"1147     IBM01147           IBM EBCDIC (France-Euro)",
        	        	        	"1148     IBM01148           IBM EBCDIC (International-Euro)",
        	        	        	"1149     IBM01149           IBM EBCDIC (Icelandic-Euro)",
        	        	        	"1200     utf-16             Unicode",
        	        	        	"1201     unicodeFFFE        Unicode (Big-Endian)",
        	        	        	"1250     windows-1250       Central European (Windows)",
        	        	        	"1251     windows-1251       Cyrillic (Windows)",
        	        	        	"1252     Windows-1252       Western European (Windows)",
        	        	        	"1253     windows-1253       Greek (Windows)",
        	        	        	"1254     windows-1254       Turkish (Windows)",
        	        	        	"1255     windows-1255       Hebrew (Windows)",
        	        	        	"1256     windows-1256       Arabic (Windows)",
        	        	        	"1257     windows-1257       Baltic (Windows)",
        	        	        	"1258     windows-1258       Vietnamese (Windows)",
        	        	        	"1361     Johab              Korean (Johab)",
        	        	        	"10000    macintosh          Western European (Mac)",
        	        	        	"10001    x-mac-japanese     Japanese (Mac)",
        	        	        	"10002    x-mac-chinesetrad  Chinese Traditional (Mac)",
        	        	        	"10003    x-mac-korean       Korean (Mac)",
        	        	        	"10004    x-mac-arabic       Arabic (Mac)",
        	        	        	"10005    x-mac-hebrew       Hebrew (Mac)",
        	        	        	"10006    x-mac-greek        Greek (Mac)",
        	        	        	"10007    x-mac-cyrillic     Cyrillic (Mac)",
        	        	        	"10008    x-mac-chinesesimp  Chinese Simplified (Mac)",
        	        	        	"10010    x-mac-romanian     Romanian (Mac)",
        	        	        	"10017    x-mac-ukrainian    Ukrainian (Mac)",
        	        	        	"10021    x-mac-thai         Thai (Mac)",
        	        	        	"10029    x-mac-ce           Central European (Mac)",
        	        	        	"10079    x-mac-icelandic    Icelandic (Mac)",
        	        	        	"10081    x-mac-turkish      Turkish (Mac)",
        	        	        	"10082    x-mac-croatian     Croatian (Mac)",
        	        	        	"20000    x-Chinese-CNS      Chinese Traditional (CNS)",
        	        	        	"20001    x-cp20001          TCA Taiwan",
        	        	        	"20002    x-Chinese-Eten     Chinese Traditional (Eten)",
        	        	        	"20003    x-cp20003          IBM5550 Taiwan",
        	        	        	"20004    x-cp20004          TeleText Taiwan",
        	        	        	"20005    x-cp20005          Wang Taiwan",
        	        	        	"20105    x-IA5              Western European (IA5)",
        	        	        	"20106    x-IA5-German       German (IA5)",
        	        	        	"20107    x-IA5-Swedish      Swedish (IA5)",
        	        	        	"20108    x-IA5-Norwegian    Norwegian (IA5)",
        	        	        	"20127    us-ascii           US-ASCII",
        	        	        	"20261    x-cp20261          T.61",
        	        	        	"20269    x-cp20269          ISO-6937",
        	        	        	"20273    IBM273             IBM EBCDIC (Germany)",
        	        	        	"20277    IBM277             IBM EBCDIC (Denmark-Norway)",
        	        	        	"20278    IBM278             IBM EBCDIC (Finland-Sweden)",
        	        	        	"20280    IBM280             IBM EBCDIC (Italy)",
        	        	        	"20284    IBM284             IBM EBCDIC (Spain)",
        	        	        	"20285    IBM285             IBM EBCDIC (UK)",
        	        	        	"20290    IBM290             IBM EBCDIC (Japanese katakana)",
        	        	        	"20297    IBM297             IBM EBCDIC (France)",
        	        	        	"20420    IBM420             IBM EBCDIC (Arabic)",
        	        	        	"20423    IBM423             IBM EBCDIC (Greek)",
        	        	        	"20424    IBM424             IBM EBCDIC (Hebrew)",
        	        	        	"20833    x-EBCDIC           IBM EBCDIC (Korean Extended)",
        	        	        	"20838    IBM-Thai           IBM EBCDIC (Thai)",
        	        	        	"20866    koi8-r             Cyrillic (KOI8-R)",
        	        	        	"20871    IBM871             IBM EBCDIC (Icelandic)",
        	        	        	"20880    IBM880             IBM EBCDIC (Cyrillic Russian)",
        	        	        	"20905    IBM905             IBM EBCDIC (Turkish)",
        	        	        	"20924    IBM00924           IBM Latin-1",
        	        	        	"20932    EUC-JP             Japanese (JIS 0208-1990 and 0212-1990)",
        	        	        	"20936    x-cp20936          Chinese Simplified (GB2312-80)",
        	        	        	"20949    x-cp20949          Korean Wansung",
        	        	        	"21025    cp1025             IBM EBCDIC (Cyrillic Serbian-Bulgarian)",
        	        	        	"21866    koi8-u             Cyrillic (KOI8-U)",
        	        	        	"28591    iso-8859-1         Western European (ISO)",
        	        	        	"28592    iso-8859-2         Central European (ISO)",
        	        	        	"28593    iso-8859-3         Latin 3 (ISO)",
        	        	        	"28594    iso-8859-4         Baltic (ISO)",
        	        	        	"28595    iso-8859-5         Cyrillic (ISO)",
        	        	        	"28596    iso-8859-6         Arabic (ISO)",
        	        	        	"28597    iso-8859-7         Greek (ISO)",
        	        	        	"28598    iso-8859-8         Hebrew (ISO-Visual)",
        	        	        	"28599    iso-8859-9         Turkish (ISO)",
        	        	        	"28603    iso-8859-13        Estonian (ISO)",
        	        	        	"28605    iso-8859-15        Latin 9 (ISO)",
        	        	        	"29001    x-Europa           Europa",
        	        	        	"38598    iso-8859-8-i       Hebrew (ISO-Logical)",
        	        	        	"50220    iso-2022-jp        Japanese (JIS)",
        	        	        	"50221    csISO2022JP        Japanese (JIS-Allow 1 byte Kana) ",
        	        	        	"50222    iso-2022-jp        Japanese (JIS-Allow 1 byte Kana - SO/SI)",
        	        	        	"50225    iso-2022-kr        Korean (ISO)",
        	        	        	"50227    x-cp50227          Chinese Simplified (ISO-2022)",
        	        	        	"51932    euc-jp             Japanese (EUC)",
        	        	        	"51936    EUC-CN             Chinese Simplified (EUC)",
        	        	        	"51949    euc-kr             Korean (EUC)",
        	        	        	"52936    hz-gb-2312         Chinese Simplified (HZ)",
        	        	        	"54936    GB18030            Chinese Simplified (GB18030)",
        	        	        	"57002    x-iscii-de         ISCII Devanagari",
        	        	        	"57003    x-iscii-be         ISCII Bengali",
        	        	        	"57004    x-iscii-ta         ISCII Tamil",
        	        	        	"57005    x-iscii-te         ISCII Telugu",
        	        	        	"57006    x-iscii-as         ISCII Assamese",
        	        	        	"57007    x-iscii-or         ISCII Oriya",
        	        	        	"57008    x-iscii-ka         ISCII Kannada",
        	        	        	"57009    x-iscii-ma         ISCII Malayalam",
        	        	        	"57010    x-iscii-gu         ISCII Gujarati",
        	        	        	"57011    x-iscii-pa         ISCII Punjabi",
        	        	        	"65000    utf-7              Unicode (UTF-7)",
        	        	        	"65001    utf-8              Unicode (UTF-8)"});
        	this.cpOpen.Name = "cpOpen";
        	this.cpOpen.Size = new System.Drawing.Size(450, 25);
        	this.cpOpen.SelectedIndexChanged += new System.EventHandler(this.cpOpen_Click);
        	// 
        	// toolStripZapisz
        	// 
        	this.toolStripZapisz.BackColor = System.Drawing.Color.Transparent;
        	this.toolStripZapisz.Dock = System.Windows.Forms.DockStyle.None;
        	this.toolStripZapisz.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStripZapisz.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.zapiszbuttonglowny,
        	        	        	this.toolStripSeparator1,
        	        	        	this.cpLabel1,
        	        	        	this._cpoutput,
        	        	        	this.poolStripLabel1,
        	        	        	this.poolComboBox1,
        	        	        	this.SeparatorCSV,
        	        	        	this.SepCSVBox});
        	this.toolStripZapisz.Location = new System.Drawing.Point(0, 25);
        	this.toolStripZapisz.Name = "toolStripZapisz";
        	this.toolStripZapisz.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	this.toolStripZapisz.Size = new System.Drawing.Size(869, 25);
        	this.toolStripZapisz.Stretch = true;
        	this.toolStripZapisz.TabIndex = 1;
        	this.toolStripZapisz.Visible = false;
        	// 
        	// zapiszbuttonglowny
        	// 
        	this.zapiszbuttonglowny.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.zapiszbuttonglowny.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.bieżącyPlikzapisz,
        	        	        	this.wszystkiePlikizapisz});
        	this.zapiszbuttonglowny.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.zapiszbuttonglowny.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.zapiszbuttonglowny.Name = "zapiszbuttonglowny";
        	this.zapiszbuttonglowny.ShowDropDownArrow = false;
        	this.zapiszbuttonglowny.Size = new System.Drawing.Size(47, 22);
        	this.zapiszbuttonglowny.Text = "Zapisz";
        	this.zapiszbuttonglowny.ToolTipText = "Zapisz";
        	// 
        	// bieżącyPlikzapisz
        	// 
        	this.bieżącyPlikzapisz.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.cSVToolStripMenuItem,
        	        	        	this.sDFToolStripMenuItem,
        	        	        	this.xMLBiezacy,
        	        	        	this.dBFBiezacy,
        	        	        	this.xLSToolStripMenuItem});
        	this.bieżącyPlikzapisz.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.bieżącyPlikzapisz.Name = "bieżącyPlikzapisz";
        	this.bieżącyPlikzapisz.Size = new System.Drawing.Size(142, 22);
        	this.bieżącyPlikzapisz.Text = "Bieżący plik";
        	// 
        	// cSVToolStripMenuItem
        	// 
        	this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
        	this.cSVToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
        	this.cSVToolStripMenuItem.Text = "CSV";
        	this.cSVToolStripMenuItem.Click += new System.EventHandler(this.cSVToolStripMenuItem_Click);
        	// 
        	// sDFToolStripMenuItem
        	// 
        	this.sDFToolStripMenuItem.Name = "sDFToolStripMenuItem";
        	this.sDFToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
        	this.sDFToolStripMenuItem.Text = "SDF";
        	this.sDFToolStripMenuItem.Click += new System.EventHandler(this.sDFToolStripMenuItem_Click);
        	// 
        	// xMLBiezacy
        	// 
        	this.xMLBiezacy.Name = "xMLBiezacy";
        	this.xMLBiezacy.Size = new System.Drawing.Size(93, 22);
        	this.xMLBiezacy.Text = "XML";
        	this.xMLBiezacy.Click += new System.EventHandler(this.xMLBiezacy_Click);
        	// 
        	// dBFBiezacy
        	// 
        	this.dBFBiezacy.Name = "dBFBiezacy";
        	this.dBFBiezacy.Size = new System.Drawing.Size(93, 22);
        	this.dBFBiezacy.Text = "DBF";
        	this.dBFBiezacy.Click += new System.EventHandler(this.dBFBiezacy_Click);
        	// 
        	// xLSToolStripMenuItem
        	// 
        	this.xLSToolStripMenuItem.Name = "xLSToolStripMenuItem";
        	this.xLSToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
        	this.xLSToolStripMenuItem.Text = "XLS";
        	this.xLSToolStripMenuItem.Click += new System.EventHandler(this.xLSToolStripMenuItem_Click);
        	// 
        	// wszystkiePlikizapisz
        	// 
        	this.wszystkiePlikizapisz.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.cSVToolStripMenuItem1,
        	        	        	this.sDFToolStripMenuItem1,
        	        	        	this.xMWszystkie,
        	        	        	this.dBFWszystkie,
        	        	        	this.xLSAllToolStripMenuItem1});
        	this.wszystkiePlikizapisz.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this.wszystkiePlikizapisz.Name = "wszystkiePlikizapisz";
        	this.wszystkiePlikizapisz.Size = new System.Drawing.Size(142, 22);
        	this.wszystkiePlikizapisz.Text = "Wszystkie pliki";
        	// 
        	// cSVToolStripMenuItem1
        	// 
        	this.cSVToolStripMenuItem1.Name = "cSVToolStripMenuItem1";
        	this.cSVToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
        	this.cSVToolStripMenuItem1.Text = "CSV";
        	this.cSVToolStripMenuItem1.Click += new System.EventHandler(this.cSVToolStripMenuItem1_Click);
        	// 
        	// sDFToolStripMenuItem1
        	// 
        	this.sDFToolStripMenuItem1.Name = "sDFToolStripMenuItem1";
        	this.sDFToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
        	this.sDFToolStripMenuItem1.Text = "SDF";
        	this.sDFToolStripMenuItem1.Click += new System.EventHandler(this.sDFToolStripMenuItem1_Click);
        	// 
        	// xMWszystkie
        	// 
        	this.xMWszystkie.Name = "xMWszystkie";
        	this.xMWszystkie.Size = new System.Drawing.Size(93, 22);
        	this.xMWszystkie.Text = "XML";
        	this.xMWszystkie.Click += new System.EventHandler(this.xMLWszystkie_Click);
        	// 
        	// dBFWszystkie
        	// 
        	this.dBFWszystkie.Name = "dBFWszystkie";
        	this.dBFWszystkie.Size = new System.Drawing.Size(93, 22);
        	this.dBFWszystkie.Text = "DBF";
        	this.dBFWszystkie.Click += new System.EventHandler(this.dBFWszystkie_Click);
        	// 
        	// xLSAllToolStripMenuItem1
        	// 
        	this.xLSAllToolStripMenuItem1.Name = "xLSAllToolStripMenuItem1";
        	this.xLSAllToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
        	this.xLSAllToolStripMenuItem1.Text = "XLS";
        	this.xLSAllToolStripMenuItem1.Click += new System.EventHandler(this.xLSAllToolStripMenuItem1_Click);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        	// 
        	// cpLabel1
        	// 
        	this.cpLabel1.Name = "cpLabel1";
        	this.cpLabel1.Size = new System.Drawing.Size(82, 22);
        	this.cpLabel1.Text = "  Code Page:";
        	// 
        	// _cpoutput
        	// 
        	this._cpoutput.AutoCompleteCustomSource.AddRange(new string[] {
        	        	        	"",
        	        	        	"37       IBM037             IBM EBCDIC (US-Canada)",
        	        	        	"437      IBM437             OEM United States",
        	        	        	"500      IBM500             IBM EBCDIC (International)",
        	        	        	"708      ASMO-708           Arabic (ASMO 708)",
        	        	        	"720      DOS-720            Arabic (DOS)",
        	        	        	"737      ibm737             Greek (DOS)",
        	        	        	"775      ibm775             Baltic (DOS)",
        	        	        	"850      ibm850             Western European (DOS)",
        	        	        	"852      ibm852             Central European (DOS)",
        	        	        	"855      IBM855             OEM Cyrillic",
        	        	        	"857      ibm857             Turkish (DOS)",
        	        	        	"858      IBM00858           OEM Multilingual Latin I",
        	        	        	"860      IBM860             Portuguese (DOS)",
        	        	        	"861      ibm861             Icelandic (DOS)",
        	        	        	"862      DOS-862            Hebrew (DOS)",
        	        	        	"863      IBM863             French Canadian (DOS)",
        	        	        	"864      IBM864             Arabic (864)",
        	        	        	"865      IBM865             Nordic (DOS)",
        	        	        	"866      cp866              Cyrillic (DOS)",
        	        	        	"869      ibm869             Greek, Modern (DOS)",
        	        	        	"870      IBM870             IBM EBCDIC (Multilingual Latin-2)",
        	        	        	"874      windows-874        Thai (Windows)",
        	        	        	"875      cp875              IBM EBCDIC (Greek Modern)",
        	        	        	"932      shift_jis          Japanese (Shift-JIS)",
        	        	        	"936      gb2312             Chinese Simplified (GB2312)",
        	        	        	"949      ks_c_5601-1987     Korean",
        	        	        	"950      big5               Chinese Traditional (Big5)",
        	        	        	"1026     IBM1026            IBM EBCDIC (Turkish Latin-5)",
        	        	        	"1047     IBM01047           IBM Latin-1",
        	        	        	"1140     IBM01140           IBM EBCDIC (US-Canada-Euro)",
        	        	        	"1141     IBM01141           IBM EBCDIC (Germany-Euro)",
        	        	        	"1142     IBM01142           IBM EBCDIC (Denmark-Norway-Euro)",
        	        	        	"1143     IBM01143           IBM EBCDIC (Finland-Sweden-Euro)",
        	        	        	"1144     IBM01144           IBM EBCDIC (Italy-Euro)",
        	        	        	"1145     IBM01145           IBM EBCDIC (Spain-Euro)",
        	        	        	"1146     IBM01146           IBM EBCDIC (UK-Euro)",
        	        	        	"1147     IBM01147           IBM EBCDIC (France-Euro)",
        	        	        	"1148     IBM01148           IBM EBCDIC (International-Euro)",
        	        	        	"1149     IBM01149           IBM EBCDIC (Icelandic-Euro)",
        	        	        	"1200     utf-16             Unicode",
        	        	        	"1201     unicodeFFFE        Unicode (Big-Endian)",
        	        	        	"1250     windows-1250       Central European (Windows)",
        	        	        	"1251     windows-1251       Cyrillic (Windows)",
        	        	        	"1252     Windows-1252       Western European (Windows)",
        	        	        	"1253     windows-1253       Greek (Windows)",
        	        	        	"1254     windows-1254       Turkish (Windows)",
        	        	        	"1255     windows-1255       Hebrew (Windows)",
        	        	        	"1256     windows-1256       Arabic (Windows)",
        	        	        	"1257     windows-1257       Baltic (Windows)",
        	        	        	"1258     windows-1258       Vietnamese (Windows)",
        	        	        	"1361     Johab              Korean (Johab)",
        	        	        	"10000    macintosh          Western European (Mac)",
        	        	        	"10001    x-mac-japanese     Japanese (Mac)",
        	        	        	"10002    x-mac-chinesetrad  Chinese Traditional (Mac)",
        	        	        	"10003    x-mac-korean       Korean (Mac)",
        	        	        	"10004    x-mac-arabic       Arabic (Mac)",
        	        	        	"10005    x-mac-hebrew       Hebrew (Mac)",
        	        	        	"10006    x-mac-greek        Greek (Mac)",
        	        	        	"10007    x-mac-cyrillic     Cyrillic (Mac)",
        	        	        	"10008    x-mac-chinesesimp  Chinese Simplified (Mac)",
        	        	        	"10010    x-mac-romanian     Romanian (Mac)",
        	        	        	"10017    x-mac-ukrainian    Ukrainian (Mac)",
        	        	        	"10021    x-mac-thai         Thai (Mac)",
        	        	        	"10029    x-mac-ce           Central European (Mac)",
        	        	        	"10079    x-mac-icelandic    Icelandic (Mac)",
        	        	        	"10081    x-mac-turkish      Turkish (Mac)",
        	        	        	"10082    x-mac-croatian     Croatian (Mac)",
        	        	        	"20000    x-Chinese-CNS      Chinese Traditional (CNS)",
        	        	        	"20001    x-cp20001          TCA Taiwan",
        	        	        	"20002    x-Chinese-Eten     Chinese Traditional (Eten)",
        	        	        	"20003    x-cp20003          IBM5550 Taiwan",
        	        	        	"20004    x-cp20004          TeleText Taiwan",
        	        	        	"20005    x-cp20005          Wang Taiwan",
        	        	        	"20105    x-IA5              Western European (IA5)",
        	        	        	"20106    x-IA5-German       German (IA5)",
        	        	        	"20107    x-IA5-Swedish      Swedish (IA5)",
        	        	        	"20108    x-IA5-Norwegian    Norwegian (IA5)",
        	        	        	"20127    us-ascii           US-ASCII",
        	        	        	"20261    x-cp20261          T.61",
        	        	        	"20269    x-cp20269          ISO-6937",
        	        	        	"20273    IBM273             IBM EBCDIC (Germany)",
        	        	        	"20277    IBM277             IBM EBCDIC (Denmark-Norway)",
        	        	        	"20278    IBM278             IBM EBCDIC (Finland-Sweden)",
        	        	        	"20280    IBM280             IBM EBCDIC (Italy)",
        	        	        	"20284    IBM284             IBM EBCDIC (Spain)",
        	        	        	"20285    IBM285             IBM EBCDIC (UK)",
        	        	        	"20290    IBM290             IBM EBCDIC (Japanese katakana)",
        	        	        	"20297    IBM297             IBM EBCDIC (France)",
        	        	        	"20420    IBM420             IBM EBCDIC (Arabic)",
        	        	        	"20423    IBM423             IBM EBCDIC (Greek)",
        	        	        	"20424    IBM424             IBM EBCDIC (Hebrew)",
        	        	        	"20833    x-EBCDIC           IBM EBCDIC (Korean Extended)",
        	        	        	"20838    IBM-Thai           IBM EBCDIC (Thai)",
        	        	        	"20866    koi8-r             Cyrillic (KOI8-R)",
        	        	        	"20871    IBM871             IBM EBCDIC (Icelandic)",
        	        	        	"20880    IBM880             IBM EBCDIC (Cyrillic Russian)",
        	        	        	"20905    IBM905             IBM EBCDIC (Turkish)",
        	        	        	"20924    IBM00924           IBM Latin-1",
        	        	        	"20932    EUC-JP             Japanese (JIS 0208-1990 and 0212-1990)",
        	        	        	"20936    x-cp20936          Chinese Simplified (GB2312-80)",
        	        	        	"20949    x-cp20949          Korean Wansung",
        	        	        	"21025    cp1025             IBM EBCDIC (Cyrillic Serbian-Bulgarian)",
        	        	        	"21866    koi8-u             Cyrillic (KOI8-U)",
        	        	        	"28591    iso-8859-1         Western European (ISO)",
        	        	        	"28592    iso-8859-2         Central European (ISO)",
        	        	        	"28593    iso-8859-3         Latin 3 (ISO)",
        	        	        	"28594    iso-8859-4         Baltic (ISO)",
        	        	        	"28595    iso-8859-5         Cyrillic (ISO)",
        	        	        	"28596    iso-8859-6         Arabic (ISO)",
        	        	        	"28597    iso-8859-7         Greek (ISO)",
        	        	        	"28598    iso-8859-8         Hebrew (ISO-Visual)",
        	        	        	"28599    iso-8859-9         Turkish (ISO)",
        	        	        	"28603    iso-8859-13        Estonian (ISO)",
        	        	        	"28605    iso-8859-15        Latin 9 (ISO)",
        	        	        	"29001    x-Europa           Europa",
        	        	        	"38598    iso-8859-8-i       Hebrew (ISO-Logical)",
        	        	        	"50220    iso-2022-jp        Japanese (JIS)",
        	        	        	"50221    csISO2022JP        Japanese (JIS-Allow 1 byte Kana) ",
        	        	        	"50222    iso-2022-jp        Japanese (JIS-Allow 1 byte Kana - SO/SI)",
        	        	        	"50225    iso-2022-kr        Korean (ISO)",
        	        	        	"50227    x-cp50227          Chinese Simplified (ISO-2022)",
        	        	        	"51932    euc-jp             Japanese (EUC)",
        	        	        	"51936    EUC-CN             Chinese Simplified (EUC)",
        	        	        	"51949    euc-kr             Korean (EUC)",
        	        	        	"52936    hz-gb-2312         Chinese Simplified (HZ)",
        	        	        	"54936    GB18030            Chinese Simplified (GB18030)",
        	        	        	"57002    x-iscii-de         ISCII Devanagari",
        	        	        	"57003    x-iscii-be         ISCII Bengali",
        	        	        	"57004    x-iscii-ta         ISCII Tamil",
        	        	        	"57005    x-iscii-te         ISCII Telugu",
        	        	        	"57006    x-iscii-as         ISCII Assamese",
        	        	        	"57007    x-iscii-or         ISCII Oriya",
        	        	        	"57008    x-iscii-ka         ISCII Kannada",
        	        	        	"57009    x-iscii-ma         ISCII Malayalam",
        	        	        	"57010    x-iscii-gu         ISCII Gujarati",
        	        	        	"57011    x-iscii-pa         ISCII Punjabi",
        	        	        	"65000    utf-7              Unicode (UTF-7)",
        	        	        	"65001    utf-8              Unicode (UTF-8)"});
        	this._cpoutput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
        	this._cpoutput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        	this._cpoutput.BackColor = System.Drawing.Color.White;
        	this._cpoutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this._cpoutput.Font = new System.Drawing.Font("Courier New", 9.360001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._cpoutput.ForeColor = System.Drawing.Color.DimGray;
        	this._cpoutput.Items.AddRange(new object[] {
        	        	        	"",
        	        	        	"37       IBM037             IBM EBCDIC (US-Canada)",
        	        	        	"437      IBM437             OEM United States",
        	        	        	"500      IBM500             IBM EBCDIC (International)",
        	        	        	"708      ASMO-708           Arabic (ASMO 708)",
        	        	        	"720      DOS-720            Arabic (DOS)",
        	        	        	"737      ibm737             Greek (DOS)",
        	        	        	"775      ibm775             Baltic (DOS)",
        	        	        	"850      ibm850             Western European (DOS)",
        	        	        	"852      ibm852             Central European (DOS)",
        	        	        	"855      IBM855             OEM Cyrillic",
        	        	        	"857      ibm857             Turkish (DOS)",
        	        	        	"858      IBM00858           OEM Multilingual Latin I",
        	        	        	"860      IBM860             Portuguese (DOS)",
        	        	        	"861      ibm861             Icelandic (DOS)",
        	        	        	"862      DOS-862            Hebrew (DOS)",
        	        	        	"863      IBM863             French Canadian (DOS)",
        	        	        	"864      IBM864             Arabic (864)",
        	        	        	"865      IBM865             Nordic (DOS)",
        	        	        	"866      cp866              Cyrillic (DOS)",
        	        	        	"869      ibm869             Greek, Modern (DOS)",
        	        	        	"870      IBM870             IBM EBCDIC (Multilingual Latin-2)",
        	        	        	"874      windows-874        Thai (Windows)",
        	        	        	"875      cp875              IBM EBCDIC (Greek Modern)",
        	        	        	"932      shift_jis          Japanese (Shift-JIS)",
        	        	        	"936      gb2312             Chinese Simplified (GB2312)",
        	        	        	"949      ks_c_5601-1987     Korean",
        	        	        	"950      big5               Chinese Traditional (Big5)",
        	        	        	"1026     IBM1026            IBM EBCDIC (Turkish Latin-5)",
        	        	        	"1047     IBM01047           IBM Latin-1",
        	        	        	"1140     IBM01140           IBM EBCDIC (US-Canada-Euro)",
        	        	        	"1141     IBM01141           IBM EBCDIC (Germany-Euro)",
        	        	        	"1142     IBM01142           IBM EBCDIC (Denmark-Norway-Euro)",
        	        	        	"1143     IBM01143           IBM EBCDIC (Finland-Sweden-Euro)",
        	        	        	"1144     IBM01144           IBM EBCDIC (Italy-Euro)",
        	        	        	"1145     IBM01145           IBM EBCDIC (Spain-Euro)",
        	        	        	"1146     IBM01146           IBM EBCDIC (UK-Euro)",
        	        	        	"1147     IBM01147           IBM EBCDIC (France-Euro)",
        	        	        	"1148     IBM01148           IBM EBCDIC (International-Euro)",
        	        	        	"1149     IBM01149           IBM EBCDIC (Icelandic-Euro)",
        	        	        	"1200     utf-16             Unicode",
        	        	        	"1201     unicodeFFFE        Unicode (Big-Endian)",
        	        	        	"1250     windows-1250       Central European (Windows)",
        	        	        	"1251     windows-1251       Cyrillic (Windows)",
        	        	        	"1252     Windows-1252       Western European (Windows)",
        	        	        	"1253     windows-1253       Greek (Windows)",
        	        	        	"1254     windows-1254       Turkish (Windows)",
        	        	        	"1255     windows-1255       Hebrew (Windows)",
        	        	        	"1256     windows-1256       Arabic (Windows)",
        	        	        	"1257     windows-1257       Baltic (Windows)",
        	        	        	"1258     windows-1258       Vietnamese (Windows)",
        	        	        	"1361     Johab              Korean (Johab)",
        	        	        	"10000    macintosh          Western European (Mac)",
        	        	        	"10001    x-mac-japanese     Japanese (Mac)",
        	        	        	"10002    x-mac-chinesetrad  Chinese Traditional (Mac)",
        	        	        	"10003    x-mac-korean       Korean (Mac)",
        	        	        	"10004    x-mac-arabic       Arabic (Mac)",
        	        	        	"10005    x-mac-hebrew       Hebrew (Mac)",
        	        	        	"10006    x-mac-greek        Greek (Mac)",
        	        	        	"10007    x-mac-cyrillic     Cyrillic (Mac)",
        	        	        	"10008    x-mac-chinesesimp  Chinese Simplified (Mac)",
        	        	        	"10010    x-mac-romanian     Romanian (Mac)",
        	        	        	"10017    x-mac-ukrainian    Ukrainian (Mac)",
        	        	        	"10021    x-mac-thai         Thai (Mac)",
        	        	        	"10029    x-mac-ce           Central European (Mac)",
        	        	        	"10079    x-mac-icelandic    Icelandic (Mac)",
        	        	        	"10081    x-mac-turkish      Turkish (Mac)",
        	        	        	"10082    x-mac-croatian     Croatian (Mac)",
        	        	        	"20000    x-Chinese-CNS      Chinese Traditional (CNS)",
        	        	        	"20001    x-cp20001          TCA Taiwan",
        	        	        	"20002    x-Chinese-Eten     Chinese Traditional (Eten)",
        	        	        	"20003    x-cp20003          IBM5550 Taiwan",
        	        	        	"20004    x-cp20004          TeleText Taiwan",
        	        	        	"20005    x-cp20005          Wang Taiwan",
        	        	        	"20105    x-IA5              Western European (IA5)",
        	        	        	"20106    x-IA5-German       German (IA5)",
        	        	        	"20107    x-IA5-Swedish      Swedish (IA5)",
        	        	        	"20108    x-IA5-Norwegian    Norwegian (IA5)",
        	        	        	"20127    us-ascii           US-ASCII",
        	        	        	"20261    x-cp20261          T.61",
        	        	        	"20269    x-cp20269          ISO-6937",
        	        	        	"20273    IBM273             IBM EBCDIC (Germany)",
        	        	        	"20277    IBM277             IBM EBCDIC (Denmark-Norway)",
        	        	        	"20278    IBM278             IBM EBCDIC (Finland-Sweden)",
        	        	        	"20280    IBM280             IBM EBCDIC (Italy)",
        	        	        	"20284    IBM284             IBM EBCDIC (Spain)",
        	        	        	"20285    IBM285             IBM EBCDIC (UK)",
        	        	        	"20290    IBM290             IBM EBCDIC (Japanese katakana)",
        	        	        	"20297    IBM297             IBM EBCDIC (France)",
        	        	        	"20420    IBM420             IBM EBCDIC (Arabic)",
        	        	        	"20423    IBM423             IBM EBCDIC (Greek)",
        	        	        	"20424    IBM424             IBM EBCDIC (Hebrew)",
        	        	        	"20833    x-EBCDIC           IBM EBCDIC (Korean Extended)",
        	        	        	"20838    IBM-Thai           IBM EBCDIC (Thai)",
        	        	        	"20866    koi8-r             Cyrillic (KOI8-R)",
        	        	        	"20871    IBM871             IBM EBCDIC (Icelandic)",
        	        	        	"20880    IBM880             IBM EBCDIC (Cyrillic Russian)",
        	        	        	"20905    IBM905             IBM EBCDIC (Turkish)",
        	        	        	"20924    IBM00924           IBM Latin-1",
        	        	        	"20932    EUC-JP             Japanese (JIS 0208-1990 and 0212-1990)",
        	        	        	"20936    x-cp20936          Chinese Simplified (GB2312-80)",
        	        	        	"20949    x-cp20949          Korean Wansung",
        	        	        	"21025    cp1025             IBM EBCDIC (Cyrillic Serbian-Bulgarian)",
        	        	        	"21866    koi8-u             Cyrillic (KOI8-U)",
        	        	        	"28591    iso-8859-1         Western European (ISO)",
        	        	        	"28592    iso-8859-2         Central European (ISO)",
        	        	        	"28593    iso-8859-3         Latin 3 (ISO)",
        	        	        	"28594    iso-8859-4         Baltic (ISO)",
        	        	        	"28595    iso-8859-5         Cyrillic (ISO)",
        	        	        	"28596    iso-8859-6         Arabic (ISO)",
        	        	        	"28597    iso-8859-7         Greek (ISO)",
        	        	        	"28598    iso-8859-8         Hebrew (ISO-Visual)",
        	        	        	"28599    iso-8859-9         Turkish (ISO)",
        	        	        	"28603    iso-8859-13        Estonian (ISO)",
        	        	        	"28605    iso-8859-15        Latin 9 (ISO)",
        	        	        	"29001    x-Europa           Europa",
        	        	        	"38598    iso-8859-8-i       Hebrew (ISO-Logical)",
        	        	        	"50220    iso-2022-jp        Japanese (JIS)",
        	        	        	"50221    csISO2022JP        Japanese (JIS-Allow 1 byte Kana) ",
        	        	        	"50222    iso-2022-jp        Japanese (JIS-Allow 1 byte Kana - SO/SI)",
        	        	        	"50225    iso-2022-kr        Korean (ISO)",
        	        	        	"50227    x-cp50227          Chinese Simplified (ISO-2022)",
        	        	        	"51932    euc-jp             Japanese (EUC)",
        	        	        	"51936    EUC-CN             Chinese Simplified (EUC)",
        	        	        	"51949    euc-kr             Korean (EUC)",
        	        	        	"52936    hz-gb-2312         Chinese Simplified (HZ)",
        	        	        	"54936    GB18030            Chinese Simplified (GB18030)",
        	        	        	"57002    x-iscii-de         ISCII Devanagari",
        	        	        	"57003    x-iscii-be         ISCII Bengali",
        	        	        	"57004    x-iscii-ta         ISCII Tamil",
        	        	        	"57005    x-iscii-te         ISCII Telugu",
        	        	        	"57006    x-iscii-as         ISCII Assamese",
        	        	        	"57007    x-iscii-or         ISCII Oriya",
        	        	        	"57008    x-iscii-ka         ISCII Kannada",
        	        	        	"57009    x-iscii-ma         ISCII Malayalam",
        	        	        	"57010    x-iscii-gu         ISCII Gujarati",
        	        	        	"57011    x-iscii-pa         ISCII Punjabi",
        	        	        	"65000    utf-7              Unicode (UTF-7)",
        	        	        	"65001    utf-8              Unicode (UTF-8)"});
        	this._cpoutput.Name = "_cpoutput";
        	this._cpoutput.Size = new System.Drawing.Size(420, 25);
        	this._cpoutput.SelectedIndexChanged += new System.EventHandler(this.cpSqve_Click);
        	// 
        	// poolStripLabel1
        	// 
        	this.poolStripLabel1.Name = "poolStripLabel1";
        	this.poolStripLabel1.Size = new System.Drawing.Size(52, 22);
        	this.poolStripLabel1.Text = "    Pool:";
        	// 
        	// poolComboBox1
        	// 
        	this.poolComboBox1.BackColor = System.Drawing.Color.White;
        	this.poolComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.poolComboBox1.ForeColor = System.Drawing.Color.Black;
        	this.poolComboBox1.Name = "poolComboBox1";
        	this.poolComboBox1.Size = new System.Drawing.Size(90, 25);
        	// 
        	// SeparatorCSV
        	// 
        	this.SeparatorCSV.Name = "SeparatorCSV";
        	this.SeparatorCSV.Size = new System.Drawing.Size(148, 22);
        	this.SeparatorCSV.Text = "    Separator zapisu csv:";
        	// 
        	// SepCSVBox
        	// 
        	this.SepCSVBox.BackColor = System.Drawing.Color.White;
        	this.SepCSVBox.ForeColor = System.Drawing.Color.Black;
        	this.SepCSVBox.Name = "SepCSVBox";
        	this.SepCSVBox.Size = new System.Drawing.Size(15, 25);
        	this.SepCSVBox.Text = "|";
        	this.SepCSVBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	// 
        	// openFileDialog1
        	// 
        	this.openFileDialog1.FileName = "openFileDialog1";
        	// 
        	// Main
        	// 
        	this.AllowDrop = true;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.SystemColors.Control;
        	this.ClientSize = new System.Drawing.Size(981, 449);
        	this.ContextMenuStrip = this.contextMenuStrip2;
        	this.Controls.Add(this.toolStripContainer1);
        	this.Controls.Add(this._statusstrip_down);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "Main";
        	this.Text = "DBADAPTER";
        	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        	this.Click += new System.EventHandler(this.XLS2CSV_Load);
        	this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop_Click);
        	this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter_Click);
        	this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Click);
        	this.grpData.ResumeLayout(false);
        	this.grpData.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaport)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.grdActiveSheet)).EndInit();
        	this.contextMenuStrip2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.contextMenuStrip1.ResumeLayout(false);
        	this._statusstrip_down.ResumeLayout(false);
        	this._statusstrip_down.PerformLayout();
        	this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
        	this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
        	this.toolStripContainer1.ContentPanel.ResumeLayout(false);
        	this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
        	this.toolStripContainer1.TopToolStripPanel.PerformLayout();
        	this.toolStripContainer1.ResumeLayout(false);
        	this.toolStripContainer1.PerformLayout();
        	this.toolStripLiniaKom.ResumeLayout(false);
        	this.toolStripLiniaKom.PerformLayout();
        	this.toolStripSortuj.ResumeLayout(false);
        	this.toolStripSortuj.PerformLayout();
        	this.menuGlowne.ResumeLayout(false);
        	this.menuGlowne.PerformLayout();
        	this.toolStripRaportZnaczik.ResumeLayout(false);
        	this.toolStripRaportZnaczik.PerformLayout();
        	this.toolStripNarzedzia.ResumeLayout(false);
        	this.toolStripNarzedzia.PerformLayout();
        	this.toolStripOpen.ResumeLayout(false);
        	this.toolStripOpen.PerformLayout();
        	this.toolStripZapisz.ResumeLayout(false);
        	this.toolStripZapisz.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView grdActiveSheet;
        private System.Windows.Forms.ComboBox cboSheet;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.StatusStrip _statusstrip_down;
        private System.Windows.Forms.ToolStripProgressBar _progressBar;
        private System.Windows.Forms.ToolStripStatusLabel _info;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip menuGlowne;
        private System.Windows.Forms.ToolStripDropDownButton StrukturaButton;
        private System.Windows.Forms.ToolStripMenuItem importujStruktureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem struktBiezacy;
        private System.Windows.Forms.ToolStripMenuItem struktWszystkie;
        private System.Windows.Forms.ToolStripButton about;
        private System.Windows.Forms.ToolStrip toolStripZapisz;
        private System.Windows.Forms.ToolStripLabel poolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox poolComboBox1;
        private System.Windows.Forms.ToolStripDropDownButton zapiszbuttonglowny;
        private System.Windows.Forms.ToolStripMenuItem bieżącyPlikzapisz;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wszystkiePlikizapisz;
        private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sDFToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel licznik;
        private System.Windows.Forms.ToolStripButton clean;
        private System.Windows.Forms.DataGridView dataGridViewRaport;
        private System.Windows.Forms.ToolStripButton raport;
        private System.Windows.Forms.ToolStripMenuItem expRaportSzczToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLBiezacy;
        private System.Windows.Forms.ToolStripMenuItem xMWszystkie;
        private System.Windows.Forms.ToolStripMenuItem dBFBiezacy;
        private System.Windows.Forms.ToolStripMenuItem dBFWszystkie;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBox1;
        private System.Windows.Forms.ToolStripSplitButton licznikButton;
        private System.Windows.Forms.ToolStrip toolStripRaportZnaczik;
        private System.Windows.Forms.ToolStripLabel toolStripText;
        private System.Windows.Forms.ToolStripTextBox znaczikTextBox;
        private System.Windows.Forms.ToolStrip toolStripOpen;
        private System.Windows.Forms.ToolStripLabel toolStripLabelOpen;
        public System.Windows.Forms.ToolStripComboBox cpOpen;
        private System.Windows.Forms.ToolStripSplitButton cmdLoad;
        private System.Windows.Forms.ToolStrip toolStripLiniaKom;
        private System.Windows.Forms.ToolStripTextBox commandText;
        private System.Windows.Forms.ToolStripButton toolStripButtonOK;
        private System.Windows.Forms.ToolStripButton toolStripButtonAcctpFilter;
        private System.Windows.Forms.ToolStripButton UsunFiltr;
        private System.Windows.Forms.ToolStripButton jobButton;
        private System.Windows.Forms.ToolStripLabel expresja;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripLabel cpLabel1;
        private System.Windows.Forms.ToolStripComboBox _cpoutput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem liniaKomSkrot;
        private System.Windows.Forms.ToolStripMenuItem otworzSkrot;
        private System.Windows.Forms.ToolStripMenuItem zapiszSkrot;
        private System.Windows.Forms.ToolStripMenuItem podgladStrukturySkrot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem licznikSkrot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem resetAllSkrot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem jobSkrot;
        private System.Windows.Forms.ToolStrip toolStripNarzedzia;
        private System.Windows.Forms.ToolStripButton toolsButton;
        private System.Windows.Forms.ToolStripMenuItem narzedzia;
        private System.Windows.Forms.ToolStripLabel csvNaglowki;
        private System.Windows.Forms.ToolStripComboBox csvNaglowkiComboBox1;
        private System.Windows.Forms.ToolStripLabel SeparatorCSV;
        private System.Windows.Forms.ToolStripTextBox SepCSVBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripDodajKol;
        private System.Windows.Forms.ToolStripMenuItem bieżącyPlikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wszystkiePlikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xLSAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStripSortuj;
        private System.Windows.Forms.ToolStripLabel wybierzpolaStripLabel1;
        private System.Windows.Forms.ToolStripComboBox sortComboBox1;
        private System.Windows.Forms.ToolStripLabel wybierzsortpolatoolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox AscDesc;
        private System.Windows.Forms.ToolStripTextBox sortTextBox1;
        private System.Windows.Forms.ToolStripDropDownButton sortujStripButton1;
        private System.Windows.Forms.ToolStripMenuItem biezacyPlikSort;
        private System.Windows.Forms.ToolStripMenuItem wszystkiePlikiSort;
        private System.Windows.Forms.ToolStripComboBox poprComboBox;
        private System.Windows.Forms.ToolStripDropDownButton wybierzPole;
        private System.Windows.Forms.ToolStripMenuItem wczytajPoprawki;
        private System.Windows.Forms.ToolStripMenuItem wczytajDnp;
        private System.Windows.Forms.ToolStripMenuItem deduplikacja;
        private System.Windows.Forms.ToolStripMenuItem usuńKolumnęToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton lp;
        private System.Windows.Forms.ToolStripMenuItem bieżącyPlikLp;
        private System.Windows.Forms.ToolStripMenuItem wszystkiePlikiLp;
        private System.Windows.Forms.ToolStripTextBox nupTextBox1;
        private System.Windows.Forms.ToolStripDropDownButton nup;
        private System.Windows.Forms.ToolStripMenuItem bieżącyPlikNup;
        private System.Windows.Forms.ToolStripMenuItem wszystkiePlikiNup;
        private System.Windows.Forms.ToolStripDropDownButton odwroc;
        private System.Windows.Forms.ToolStripMenuItem biezacyPlikOdwr;
        private System.Windows.Forms.ToolStripMenuItem wszystkiePlikiOdwr;
        private System.Windows.Forms.ToolStripDropDownButton Projekty;
        private System.Windows.Forms.ToolStripMenuItem wolaczToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plecToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox poprComboBox2;
        private System.Windows.Forms.ToolStripButton Sortuj;
        private System.Windows.Forms.ToolStripButton scalTab;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button buttonRm;
        private System.Windows.Forms.Label labelRm;
        private System.Windows.Forms.TextBox textBoxNr;
        private System.Windows.Forms.Label labelIlosc;
        private System.Windows.Forms.Label labelOpis;
        private System.Windows.Forms.Label labelNr;
        private System.Windows.Forms.TextBox textBoxOpis;
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.ComboBox comboBoxRm;
        private System.Windows.Forms.Label labelSprawdz;
        private System.Windows.Forms.ToolStripDropDownButton ssy;
        private System.Windows.Forms.ToolStripMenuItem rMusterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rekordyKontrolneToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton CpCon;
        private System.Windows.Forms.ToolStripMenuItem wzoryToolStripMenuItem;
        private System.Windows.Forms.TextBox ileTextBox;
        private System.Windows.Forms.Label ileLabel;
    }
}

