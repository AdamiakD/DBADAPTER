using System.IO;

namespace Dbadapter
{
    partial class CPC
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPC));
        	this._toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
        	this._statusstrip_down = new System.Windows.Forms.StatusStrip();
        	this._info = new System.Windows.Forms.ToolStripStatusLabel();
        	this._progressBar = new System.Windows.Forms.ToolStripProgressBar();
        	this._splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this._myTextCons = new System.Windows.Forms.RichTextBox();
        	this._checkedListBox1 = new System.Windows.Forms.CheckedListBox();
        	this._myTextCons2 = new System.Windows.Forms.RichTextBox();
        	this._listBox1 = new System.Windows.Forms.ListBox();
        	this._paneldown = new System.Windows.Forms.Panel();
        	this._textpanel3 = new System.Windows.Forms.Label();
        	this._textpanel4 = new System.Windows.Forms.Label();
        	this._panelup = new System.Windows.Forms.Panel();
        	this._textpanel1 = new System.Windows.Forms.Label();
        	this._textpanel2 = new System.Windows.Forms.Label();
        	this._toolStrip1_up = new System.Windows.Forms.ToolStrip();
        	this._open = new System.Windows.Forms.ToolStripButton();
        	this._encode = new System.Windows.Forms.ToolStripButton();
        	this.ClearButon = new System.Windows.Forms.ToolStripButton();
        	this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this._font = new System.Windows.Forms.ToolStripTextBox();
        	this._wordwrap = new System.Windows.Forms.ToolStripButton();
        	this._text_outputcp = new System.Windows.Forms.ToolStripLabel();
        	this._cpoutput = new System.Windows.Forms.ToolStripComboBox();
        	this._about = new System.Windows.Forms.ToolStripButton();
        	this._openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	this._fontDialog1 = new System.Windows.Forms.FontDialog();
        	this._toolStripContainer1.BottomToolStripPanel.SuspendLayout();
        	this._toolStripContainer1.ContentPanel.SuspendLayout();
        	this._toolStripContainer1.TopToolStripPanel.SuspendLayout();
        	this._toolStripContainer1.SuspendLayout();
        	this._statusstrip_down.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
        	this._splitContainer1.Panel1.SuspendLayout();
        	this._splitContainer1.Panel2.SuspendLayout();
        	this._splitContainer1.SuspendLayout();
        	this._paneldown.SuspendLayout();
        	this._panelup.SuspendLayout();
        	this._toolStrip1_up.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// _toolStripContainer1
        	// 
        	// 
        	// _toolStripContainer1.BottomToolStripPanel
        	// 
        	this._toolStripContainer1.BottomToolStripPanel.Controls.Add(this._statusstrip_down);
        	// 
        	// _toolStripContainer1.ContentPanel
        	// 
        	this._toolStripContainer1.ContentPanel.Controls.Add(this._splitContainer1);
        	this._toolStripContainer1.ContentPanel.Controls.Add(this._panelup);
        	this._toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1028, 531);
        	this._toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this._toolStripContainer1.Location = new System.Drawing.Point(0, 0);
        	this._toolStripContainer1.Name = "_toolStripContainer1";
        	this._toolStripContainer1.Size = new System.Drawing.Size(1028, 578);
        	this._toolStripContainer1.TabIndex = 0;
        	this._toolStripContainer1.Text = "toolStripContainer1";
        	// 
        	// _toolStripContainer1.TopToolStripPanel
        	// 
        	this._toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
        	this._toolStripContainer1.TopToolStripPanel.Controls.Add(this._toolStrip1_up);
        	this._toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	// 
        	// _statusstrip_down
        	// 
        	this._statusstrip_down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this._statusstrip_down.Dock = System.Windows.Forms.DockStyle.None;
        	this._statusstrip_down.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this._info,
        	        	        	this._progressBar});
        	this._statusstrip_down.Location = new System.Drawing.Point(0, 0);
        	this._statusstrip_down.Name = "_statusstrip_down";
        	this._statusstrip_down.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
        	this._statusstrip_down.Size = new System.Drawing.Size(1028, 22);
        	this._statusstrip_down.TabIndex = 0;
        	// 
        	// _info
        	// 
        	this._info.BackColor = System.Drawing.SystemColors.Control;
        	this._info.Name = "_info";
        	this._info.Size = new System.Drawing.Size(1013, 17);
        	this._info.Spring = true;
        	this._info.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// _progressBar
        	// 
        	this._progressBar.Name = "_progressBar";
        	this._progressBar.Size = new System.Drawing.Size(210, 16);
        	this._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this._progressBar.Visible = false;
        	// 
        	// _splitContainer1
        	// 
        	this._splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
        	this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this._splitContainer1.Location = new System.Drawing.Point(0, 28);
        	this._splitContainer1.Name = "_splitContainer1";
        	this._splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// _splitContainer1.Panel1
        	// 
        	this._splitContainer1.Panel1.Controls.Add(this._myTextCons);
        	this._splitContainer1.Panel1.Controls.Add(this._checkedListBox1);
        	// 
        	// _splitContainer1.Panel2
        	// 
        	this._splitContainer1.Panel2.Controls.Add(this._myTextCons2);
        	this._splitContainer1.Panel2.Controls.Add(this._listBox1);
        	this._splitContainer1.Panel2.Controls.Add(this._paneldown);
        	this._splitContainer1.Size = new System.Drawing.Size(1028, 503);
        	this._splitContainer1.SplitterDistance = 237;
        	this._splitContainer1.TabIndex = 0;
        	// 
        	// _myTextCons
        	// 
        	this._myTextCons.BackColor = System.Drawing.SystemColors.Window;
        	this._myTextCons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this._myTextCons.Dock = System.Windows.Forms.DockStyle.Fill;
        	this._myTextCons.Font = new System.Drawing.Font("Consolas", 9F);
        	this._myTextCons.ForeColor = System.Drawing.Color.Black;
        	this._myTextCons.Location = new System.Drawing.Point(301, 0);
        	this._myTextCons.Name = "_myTextCons";
        	this._myTextCons.Size = new System.Drawing.Size(727, 237);
        	this._myTextCons.TabIndex = 4;
        	this._myTextCons.Text = "";
        	this._myTextCons.WordWrap = false;
        	this._myTextCons.SelectionChanged += new System.EventHandler(this._myTextCons_Select);
        	// 
        	// _checkedListBox1
        	// 
        	this._checkedListBox1.BackColor = System.Drawing.Color.White;
        	this._checkedListBox1.Dock = System.Windows.Forms.DockStyle.Left;
        	this._checkedListBox1.Font = new System.Drawing.Font("Consolas", 9F);
        	this._checkedListBox1.FormattingEnabled = true;
        	this._checkedListBox1.IntegralHeight = false;
        	this._checkedListBox1.Location = new System.Drawing.Point(0, 0);
        	this._checkedListBox1.Name = "_checkedListBox1";
        	this._checkedListBox1.Size = new System.Drawing.Size(301, 237);
        	this._checkedListBox1.TabIndex = 0;
        	this._checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
        	// 
        	// _myTextCons2
        	// 
        	this._myTextCons2.BackColor = System.Drawing.Color.White;
        	this._myTextCons2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this._myTextCons2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this._myTextCons2.Font = new System.Drawing.Font("Consolas", 9F);
        	this._myTextCons2.ForeColor = System.Drawing.Color.Black;
        	this._myTextCons2.Location = new System.Drawing.Point(301, 27);
        	this._myTextCons2.Name = "_myTextCons2";
        	this._myTextCons2.Size = new System.Drawing.Size(727, 235);
        	this._myTextCons2.TabIndex = 1;
        	this._myTextCons2.Text = "";
        	this._myTextCons2.WordWrap = false;
        	this._myTextCons2.SelectionChanged += new System.EventHandler(this._myTextCons2_Select);
        	// 
        	// _listBox1
        	// 
        	this._listBox1.BackColor = System.Drawing.Color.White;
        	this._listBox1.Dock = System.Windows.Forms.DockStyle.Left;
        	this._listBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._listBox1.FormattingEnabled = true;
        	this._listBox1.HorizontalScrollbar = true;
        	this._listBox1.IntegralHeight = false;
        	this._listBox1.ItemHeight = 14;
        	this._listBox1.Items.AddRange(new object[] {
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
        	        	        	"936      gb2312             Chinese Simplified (GB2312)                   *",
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
        	        	        	"1200     utf-16             Unicode                                       *",
        	        	        	"1201     unicodeFFFE        Unicode (Big-Endian)                          *",
        	        	        	"1250     windows-1250       Central European (Windows)",
        	        	        	"1251     windows-1251       Cyrillic (Windows)",
        	        	        	"1252     Windows-1252       Western European (Windows)                    *",
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
        	        	        	"10003    x-mac-korean       Korean (Mac)                                  *",
        	        	        	"10004    x-mac-arabic       Arabic (Mac)",
        	        	        	"10005    x-mac-hebrew       Hebrew (Mac)",
        	        	        	"10006    x-mac-greek        Greek (Mac)",
        	        	        	"10007    x-mac-cyrillic     Cyrillic (Mac)",
        	        	        	"10008    x-mac-chinesesimp  Chinese Simplified (Mac)                      *",
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
        	        	        	"20127    us-ascii           US-ASCII                                      *",
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
        	        	        	"20936    x-cp20936          Chinese Simplified (GB2312-80)                *",
        	        	        	"20949    x-cp20949          Korean Wansung                                *",
        	        	        	"21025    cp1025             IBM EBCDIC (Cyrillic Serbian-Bulgarian)",
        	        	        	"21866    koi8-u             Cyrillic (KOI8-U)",
        	        	        	"28591    iso-8859-1         Western European (ISO)                        *",
        	        	        	"28592    iso-8859-2         Central European (ISO)",
        	        	        	"28593    iso-8859-3         Latin 3 (ISO)",
        	        	        	"28594    iso-8859-4         Baltic (ISO)",
        	        	        	"28595    iso-8859-5         Cyrillic (ISO)",
        	        	        	"28596    iso-8859-6         Arabic (ISO)",
        	        	        	"28597    iso-8859-7         Greek (ISO)",
        	        	        	"28598    iso-8859-8         Hebrew (ISO-Visual)                           *",
        	        	        	"28599    iso-8859-9         Turkish (ISO)",
        	        	        	"28603    iso-8859-13        Estonian (ISO)",
        	        	        	"28605    iso-8859-15        Latin 9 (ISO)",
        	        	        	"29001    x-Europa           Europa",
        	        	        	"38598    iso-8859-8-i       Hebrew (ISO-Logical)                          *",
        	        	        	"50220    iso-2022-jp        Japanese (JIS)                                *",
        	        	        	"50221    csISO2022JP        Japanese (JIS-Allow 1 byte Kana)              *",
        	        	        	"50222    iso-2022-jp        Japanese (JIS-Allow 1 byte Kana - SO/SI)      *",
        	        	        	"50225    iso-2022-kr        Korean (ISO)                                  *",
        	        	        	"50227    x-cp50227          Chinese Simplified (ISO-2022)                 *",
        	        	        	"51932    euc-jp             Japanese (EUC)                                *",
        	        	        	"51936    EUC-CN             Chinese Simplified (EUC)                      *",
        	        	        	"51949    euc-kr             Korean (EUC)                                  *",
        	        	        	"52936    hz-gb-2312         Chinese Simplified (HZ)                       *",
        	        	        	"54936    GB18030            Chinese Simplified (GB18030)                  *",
        	        	        	"57002    x-iscii-de         ISCII Devanagari                              *",
        	        	        	"57003    x-iscii-be         ISCII Bengali                                 *",
        	        	        	"57004    x-iscii-ta         ISCII Tamil                                   *",
        	        	        	"57005    x-iscii-te         ISCII Telugu                                  *",
        	        	        	"57006    x-iscii-as         ISCII Assamese                                *",
        	        	        	"57007    x-iscii-or         ISCII Oriya                                   *",
        	        	        	"57008    x-iscii-ka         ISCII Kannada                                 *",
        	        	        	"57009    x-iscii-ma         ISCII Malayalam                               *",
        	        	        	"57010    x-iscii-gu         ISCII Gujarati                                *",
        	        	        	"57011    x-iscii-pa         ISCII Punjabi                                 *",
        	        	        	"65000    utf-7              Unicode (UTF-7)                               *",
        	        	        	"65001    utf-8              Unicode (UTF-8)                               *"});
        	this._listBox1.Location = new System.Drawing.Point(0, 27);
        	this._listBox1.Name = "_listBox1";
        	this._listBox1.Size = new System.Drawing.Size(301, 235);
        	this._listBox1.TabIndex = 6;
        	this._listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
        	// 
        	// _paneldown
        	// 
        	this._paneldown.BackColor = System.Drawing.SystemColors.Control;
        	this._paneldown.Controls.Add(this._textpanel3);
        	this._paneldown.Controls.Add(this._textpanel4);
        	this._paneldown.Dock = System.Windows.Forms.DockStyle.Top;
        	this._paneldown.Location = new System.Drawing.Point(0, 0);
        	this._paneldown.Name = "_paneldown";
        	this._paneldown.Size = new System.Drawing.Size(1028, 27);
        	this._paneldown.TabIndex = 7;
        	// 
        	// _textpanel3
        	// 
        	this._textpanel3.BackColor = System.Drawing.Color.Transparent;
        	this._textpanel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._textpanel3.ForeColor = System.Drawing.Color.DimGray;
        	this._textpanel3.Location = new System.Drawing.Point(3, 7);
        	this._textpanel3.Name = "_textpanel3";
        	this._textpanel3.Size = new System.Drawing.Size(133, 23);
        	this._textpanel3.TabIndex = 1;
        	this._textpanel3.Text = "Input CP:";
        	// 
        	// _textpanel4
        	// 
        	this._textpanel4.BackColor = System.Drawing.Color.Transparent;
        	this._textpanel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._textpanel4.ForeColor = System.Drawing.Color.DimGray;
        	this._textpanel4.Location = new System.Drawing.Point(307, 7);
        	this._textpanel4.Name = "_textpanel4";
        	this._textpanel4.Size = new System.Drawing.Size(133, 23);
        	this._textpanel4.TabIndex = 0;
        	this._textpanel4.Text = "After Conversion:";
        	// 
        	// _panelup
        	// 
        	this._panelup.BackColor = System.Drawing.SystemColors.Control;
        	this._panelup.Controls.Add(this._textpanel1);
        	this._panelup.Controls.Add(this._textpanel2);
        	this._panelup.Dock = System.Windows.Forms.DockStyle.Top;
        	this._panelup.Location = new System.Drawing.Point(0, 0);
        	this._panelup.Name = "_panelup";
        	this._panelup.Size = new System.Drawing.Size(1028, 28);
        	this._panelup.TabIndex = 1;
        	// 
        	// _textpanel1
        	// 
        	this._textpanel1.BackColor = System.Drawing.Color.Transparent;
        	this._textpanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._textpanel1.ForeColor = System.Drawing.Color.DimGray;
        	this._textpanel1.Location = new System.Drawing.Point(3, 8);
        	this._textpanel1.Name = "_textpanel1";
        	this._textpanel1.Size = new System.Drawing.Size(133, 23);
        	this._textpanel1.TabIndex = 1;
        	this._textpanel1.Text = "Files:";
        	// 
        	// _textpanel2
        	// 
        	this._textpanel2.BackColor = System.Drawing.Color.Transparent;
        	this._textpanel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._textpanel2.ForeColor = System.Drawing.Color.DimGray;
        	this._textpanel2.Location = new System.Drawing.Point(307, 8);
        	this._textpanel2.Name = "_textpanel2";
        	this._textpanel2.Size = new System.Drawing.Size(133, 23);
        	this._textpanel2.TabIndex = 0;
        	this._textpanel2.Text = "Before Conversion:";
        	// 
        	// _toolStrip1_up
        	// 
        	this._toolStrip1_up.BackColor = System.Drawing.SystemColors.Control;
        	this._toolStrip1_up.Dock = System.Windows.Forms.DockStyle.None;
        	this._toolStrip1_up.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this._toolStrip1_up.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this._open,
        	        	        	this._encode,
        	        	        	this.ClearButon,
        	        	        	this.toolStripLabel1,
        	        	        	this._font,
        	        	        	this._wordwrap,
        	        	        	this._text_outputcp,
        	        	        	this._cpoutput,
        	        	        	this._about});
        	this._toolStrip1_up.Location = new System.Drawing.Point(0, 0);
        	this._toolStrip1_up.Name = "_toolStrip1_up";
        	this._toolStrip1_up.Size = new System.Drawing.Size(1028, 25);
        	this._toolStrip1_up.Stretch = true;
        	this._toolStrip1_up.TabIndex = 1;
        	// 
        	// _open
        	// 
        	this._open.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._open.Image = global::Dbadapter.Properties.Resources.openToolStripButton_Image;
        	this._open.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this._open.Name = "_open";
        	this._open.Size = new System.Drawing.Size(59, 23);
        	this._open.Text = "Open  ";
        	this._open.Click += new System.EventHandler(this.open_Click);
        	// 
        	// _encode
        	// 
        	this._encode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._encode.Image = ((System.Drawing.Image)(resources.GetObject("_encode.Image")));
        	this._encode.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this._encode.Name = "_encode";
        	this._encode.Size = new System.Drawing.Size(66, 22);
        	this._encode.Text = "Convert";
        	this._encode.ToolTipText = "Convert";
        	this._encode.Click += new System.EventHandler(this.encode_Click);
        	// 
        	// ClearButon
        	// 
        	this.ClearButon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this.ClearButon.Image = ((System.Drawing.Image)(resources.GetObject("ClearButon.Image")));
        	this.ClearButon.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.ClearButon.Name = "ClearButon";
        	this.ClearButon.Size = new System.Drawing.Size(76, 23);
        	this.ClearButon.Text = "  Clear All  ";
        	this.ClearButon.Click += new System.EventHandler(this.ClearButon_Click);
        	// 
        	// toolStripLabel1
        	// 
        	this.toolStripLabel1.ForeColor = System.Drawing.Color.DimGray;
        	this.toolStripLabel1.Name = "toolStripLabel1";
        	this.toolStripLabel1.Size = new System.Drawing.Size(48, 23);
        	this.toolStripLabel1.Text = "   Font:";
        	// 
        	// _font
        	// 
        	this._font.BackColor = System.Drawing.Color.White;
        	this._font.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	this._font.ForeColor = System.Drawing.Color.Black;
        	this._font.Name = "_font";
        	this._font.ReadOnly = true;
        	this._font.Size = new System.Drawing.Size(140, 26);
        	this._font.Text = "Arial";
        	this._font.ToolTipText = "Font Name";
        	this._font.Click += new System.EventHandler(this.font_Click);
        	// 
        	// _wordwrap
        	// 
        	this._wordwrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this._wordwrap.Image = ((System.Drawing.Image)(resources.GetObject("_wordwrap.Image")));
        	this._wordwrap.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this._wordwrap.Name = "_wordwrap";
        	this._wordwrap.Size = new System.Drawing.Size(71, 23);
        	this._wordwrap.Text = "WordWrap";
        	this._wordwrap.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
        	this._wordwrap.ToolTipText = "Word Wrap";
        	this._wordwrap.Click += new System.EventHandler(this.wordwrap_Click);
        	// 
        	// _text_outputcp
        	// 
        	this._text_outputcp.ForeColor = System.Drawing.Color.DimGray;
        	this._text_outputcp.Name = "_text_outputcp";
        	this._text_outputcp.Size = new System.Drawing.Size(82, 23);
        	this._text_outputcp.Text = "   Output CP:";
        	// 
        	// _cpoutput
        	// 
        	this._cpoutput.BackColor = System.Drawing.Color.White;
        	this._cpoutput.Font = new System.Drawing.Font("Consolas", 9F);
        	this._cpoutput.ForeColor = System.Drawing.Color.Black;
        	this._cpoutput.Items.AddRange(new object[] {
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
        	        	        	"936      gb2312             Chinese Simplified (GB2312)                   *",
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
        	        	        	"1200     utf-16             Unicode                                       *",
        	        	        	"1201     unicodeFFFE        Unicode (Big-Endian)                          *",
        	        	        	"1250     windows-1250       Central European (Windows)",
        	        	        	"1251     windows-1251       Cyrillic (Windows)",
        	        	        	"1252     Windows-1252       Western European (Windows)                    *",
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
        	        	        	"10003    x-mac-korean       Korean (Mac)                                  *",
        	        	        	"10004    x-mac-arabic       Arabic (Mac)",
        	        	        	"10005    x-mac-hebrew       Hebrew (Mac)",
        	        	        	"10006    x-mac-greek        Greek (Mac)",
        	        	        	"10007    x-mac-cyrillic     Cyrillic (Mac)",
        	        	        	"10008    x-mac-chinesesimp  Chinese Simplified (Mac)                      *",
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
        	        	        	"20127    us-ascii           US-ASCII                                      *",
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
        	        	        	"20936    x-cp20936          Chinese Simplified (GB2312-80)                *",
        	        	        	"20949    x-cp20949          Korean Wansung                                *",
        	        	        	"21025    cp1025             IBM EBCDIC (Cyrillic Serbian-Bulgarian)",
        	        	        	"21866    koi8-u             Cyrillic (KOI8-U)",
        	        	        	"28591    iso-8859-1         Western European (ISO)                        *",
        	        	        	"28592    iso-8859-2         Central European (ISO)",
        	        	        	"28593    iso-8859-3         Latin 3 (ISO)",
        	        	        	"28594    iso-8859-4         Baltic (ISO)",
        	        	        	"28595    iso-8859-5         Cyrillic (ISO)",
        	        	        	"28596    iso-8859-6         Arabic (ISO)",
        	        	        	"28597    iso-8859-7         Greek (ISO)",
        	        	        	"28598    iso-8859-8         Hebrew (ISO-Visual)                           *",
        	        	        	"28599    iso-8859-9         Turkish (ISO)",
        	        	        	"28603    iso-8859-13        Estonian (ISO)",
        	        	        	"28605    iso-8859-15        Latin 9 (ISO)",
        	        	        	"29001    x-Europa           Europa",
        	        	        	"38598    iso-8859-8-i       Hebrew (ISO-Logical)                          *",
        	        	        	"50220    iso-2022-jp        Japanese (JIS)                                *",
        	        	        	"50221    csISO2022JP        Japanese (JIS-Allow 1 byte Kana)              *",
        	        	        	"50222    iso-2022-jp        Japanese (JIS-Allow 1 byte Kana - SO/SI)      *",
        	        	        	"50225    iso-2022-kr        Korean (ISO)                                  *",
        	        	        	"50227    x-cp50227          Chinese Simplified (ISO-2022)                 *",
        	        	        	"51932    euc-jp             Japanese (EUC)                                *",
        	        	        	"51936    EUC-CN             Chinese Simplified (EUC)                      *",
        	        	        	"51949    euc-kr             Korean (EUC)                                  *",
        	        	        	"52936    hz-gb-2312         Chinese Simplified (HZ)                       *",
        	        	        	"54936    GB18030            Chinese Simplified (GB18030)                  *",
        	        	        	"57002    x-iscii-de         ISCII Devanagari                              *",
        	        	        	"57003    x-iscii-be         ISCII Bengali                                 *",
        	        	        	"57004    x-iscii-ta         ISCII Tamil                                   *",
        	        	        	"57005    x-iscii-te         ISCII Telugu                                  *",
        	        	        	"57006    x-iscii-as         ISCII Assamese                                *",
        	        	        	"57007    x-iscii-or         ISCII Oriya                                   *",
        	        	        	"57008    x-iscii-ka         ISCII Kannada                                 *",
        	        	        	"57009    x-iscii-ma         ISCII Malayalam                               *",
        	        	        	"57010    x-iscii-gu         ISCII Gujarati                                *",
        	        	        	"57011    x-iscii-pa         ISCII Punjabi                                 *",
        	        	        	"65000    utf-7              Unicode (UTF-7)                               *",
        	        	        	"65001    utf-8              Unicode (UTF-8)                               *"});
        	this._cpoutput.Name = "_cpoutput";
        	this._cpoutput.Size = new System.Drawing.Size(400, 25);
        	this._cpoutput.Text = "1250     windows-1250       Central European (Windows)";
        	this._cpoutput.Click += new System.EventHandler(this.cpoutput_Click);
        	// 
        	// _about
        	// 
        	this._about.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
        	this._about.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this._about.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this._about.Name = "_about";
        	this._about.Size = new System.Drawing.Size(25, 17);
        	this._about.Text = " ? ";
        	this._about.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
        	this._about.ToolTipText = "About";
        	this._about.Visible = false;
        	this._about.Click += new System.EventHandler(this.toolStripButton1_Click);
        	// 
        	// _openFileDialog1
        	// 
        	this._openFileDialog1.FileName = "openFileDialog1";
        	this._openFileDialog1.Multiselect = true;
        	// 
        	// _fontDialog1
        	// 
        	this._fontDialog1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
        	// 
        	// CPC
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
        	this.ClientSize = new System.Drawing.Size(1028, 578);
        	this.Controls.Add(this._toolStripContainer1);
        	this.DoubleBuffered = true;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "CPC";
        	this.Text = "CP Converter";
        	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        	this._toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
        	this._toolStripContainer1.BottomToolStripPanel.PerformLayout();
        	this._toolStripContainer1.ContentPanel.ResumeLayout(false);
        	this._toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
        	this._toolStripContainer1.TopToolStripPanel.PerformLayout();
        	this._toolStripContainer1.ResumeLayout(false);
        	this._toolStripContainer1.PerformLayout();
        	this._statusstrip_down.ResumeLayout(false);
        	this._statusstrip_down.PerformLayout();
        	this._splitContainer1.Panel1.ResumeLayout(false);
        	this._splitContainer1.Panel2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
        	this._splitContainer1.ResumeLayout(false);
        	this._paneldown.ResumeLayout(false);
        	this._panelup.ResumeLayout(false);
        	this._toolStrip1_up.ResumeLayout(false);
        	this._toolStrip1_up.PerformLayout();
        	this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ToolStripButton _open;
        //private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripContainer _toolStripContainer1;
        private System.Windows.Forms.OpenFileDialog _openFileDialog1;
        private System.Windows.Forms.FontDialog _fontDialog1;
        private System.Windows.Forms.StatusStrip _statusstrip_down;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.RichTextBox _myTextCons;
        private System.Windows.Forms.CheckedListBox _checkedListBox1;
        private System.Windows.Forms.RichTextBox _myTextCons2;
        private System.Windows.Forms.Panel _paneldown;
        private System.Windows.Forms.Label _textpanel3;
        private System.Windows.Forms.Label _textpanel4;
        private System.Windows.Forms.ListBox _listBox1;
        private System.Windows.Forms.ToolStrip _toolStrip1_up;
        private System.Windows.Forms.ToolStripTextBox _font;
        private System.Windows.Forms.ToolStripButton _wordwrap;
        private System.Windows.Forms.ToolStripLabel _text_outputcp;
        private System.Windows.Forms.ToolStripComboBox _cpoutput;
        private System.Windows.Forms.ToolStripButton _encode;
        private System.Windows.Forms.Panel _panelup;
        private System.Windows.Forms.Label _textpanel1;
        private System.Windows.Forms.Label _textpanel2;
        private System.Windows.Forms.ToolStripProgressBar _progressBar;
        private System.Windows.Forms.ToolStripStatusLabel _info;
        private System.Windows.Forms.ToolStripButton _about;
        private System.Windows.Forms.ToolStripButton ClearButon;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

