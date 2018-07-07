using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace UOCFilenet
{
    public partial class FrmFileNET
    {

        #region "Upgrade Support "
        private static FrmFileNET m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static FrmFileNET DefInstance
        {

            get
            {
                if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
                {
                    m_InitializingDefInstance = true;
                    m_vb6FormDefInstance = new FrmFileNET();
                    //AIS-666 ebonilla
                    m_vb6FormDefInstance.Closed += new System.EventHandler(m_vb6FormDefInstance.releaseResources);
                    m_InitializingDefInstance = false;
                }
                return m_vb6FormDefInstance;
            }
            set
            {
                m_vb6FormDefInstance = value;
            }
        }

        #endregion
        #region "Windows Form Designer generated code "
        public FrmFileNET()
            : base()
        {
            //This call is required by the Windows Form Designer.
            InitializeComponent();
            InitializeIDMViewerCtrl1();
            InitializeLblUoc();
            InitializeIDMListView1();
            InitializeCboUoc();
            InitializeLblCriterio();
            InitializeTxtCriterio();
            Form_Initialize_Renamed();

            /*if (!m_InitializingDefInstance)
            {
                m_vb6FormDefInstance = this;
                m_vb6FormDefInstance.Closed += new System.EventHandler(m_vb6FormDefInstance.releaseResources);
            }*/

        }
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode]
        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(Disposing);
        }
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.TextBox[] CboUoc = new System.Windows.Forms.TextBox[2];
        //public AxIDMListView.AxIDMListView[] IDMListView1 = new AxIDMListView.AxIDMListView[2];
        //public AxIDMViewerCtrl.AxIDMViewerCtrl[] IDMViewerCtrl1 = new AxIDMViewerCtrl.AxIDMViewerCtrl[4];
        public System.Windows.Forms.Label[] LblCriterio = new System.Windows.Forms.Label[6];
        public System.Windows.Forms.Label[] LblUoc = new System.Windows.Forms.Label[2];
        public System.Windows.Forms.TextBox[] TxtCriterio = new System.Windows.Forms.TextBox[6];
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileNET));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnTextBridge = new System.Windows.Forms.Button();
            this.BtnMail = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnRotar2 = new System.Windows.Forms.Button();
            this.BtnRotar1 = new System.Windows.Forms.Button();
            this.BtnZoomOut = new System.Windows.Forms.Button();
            this.BtnZoomIn = new System.Windows.Forms.Button();
            this.BtnZoom = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.SSPanel1 = new System.Windows.Forms.Panel();
            this._CboUoc_1 = new System.Windows.Forms.TextBox();
            this._CboUoc_0 = new System.Windows.Forms.TextBox();
            this.TxtSubFol2 = new System.Windows.Forms.TextBox();
            this.LblsubFol2 = new System.Windows.Forms.Label();
            this.TxtSubFol1 = new System.Windows.Forms.TextBox();
            this.LblSubFolio1 = new System.Windows.Forms.Label();
            this._TxtCriterio_5 = new System.Windows.Forms.TextBox();
            this._TxtCriterio_4 = new System.Windows.Forms.TextBox();
            this._TxtCriterio_3 = new System.Windows.Forms.TextBox();
            this._TxtCriterio_2 = new System.Windows.Forms.TextBox();
            this._TxtCriterio_1 = new System.Windows.Forms.TextBox();
            this._TxtCriterio_0 = new System.Windows.Forms.TextBox();
            this.Command1 = new System.Windows.Forms.Button();
            this._LblUoc_1 = new System.Windows.Forms.Label();
            this._LblUoc_0 = new System.Windows.Forms.Label();
            this._LblCriterio_5 = new System.Windows.Forms.Label();
            this._LblCriterio_4 = new System.Windows.Forms.Label();
            this._LblCriterio_3 = new System.Windows.Forms.Label();
            this._LblCriterio_2 = new System.Windows.Forms.Label();
            this._LblCriterio_1 = new System.Windows.Forms.Label();
            this._LblCriterio_0 = new System.Windows.Forms.Label();
            this.SSPanel2 = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.Highlight = new System.Windows.Forms.Button();
            this.ShowAnnotations = new System.Windows.Forms.CheckBox();
            this.AddNote = new System.Windows.Forms.Button();
            this.Reject = new System.Windows.Forms.Button();
            this.Approve = new System.Windows.Forms.Button();
            this.BtnNave = new System.Windows.Forms.Button();
            this.DocumentID = new System.Windows.Forms.Label();
            this.SPCont2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XfolioP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FolioS403 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instrumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XFolioS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSTab1 = new System.Windows.Forms.TabControl();
            this._SSTab1_TabPage0 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SPCont = new System.Windows.Forms.SplitContainer();
            this.SSPanel1.SuspendLayout();
            this.SSPanel2.SuspendLayout();
            this.SPCont2.Panel1.SuspendLayout();
            this.SPCont2.Panel2.SuspendLayout();
            this.SPCont2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SSTab1.SuspendLayout();
            this._SSTab1_TabPage0.SuspendLayout();
            this.SPCont.Panel1.SuspendLayout();
            this.SPCont.Panel2.SuspendLayout();
            this.SPCont.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSalir.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnSalir.Location = new System.Drawing.Point(0, 0);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(156, 26);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.Text = "Salir";
            this.ToolTip1.SetToolTip(this.BtnSalir, "Salir");
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_ClickEvent);
            // 
            // BtnTextBridge
            // 
            this.BtnTextBridge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnTextBridge.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnTextBridge.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTextBridge.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnTextBridge.Location = new System.Drawing.Point(5, 423);
            this.BtnTextBridge.Name = "BtnTextBridge";
            this.BtnTextBridge.Size = new System.Drawing.Size(142, 17);
            this.BtnTextBridge.TabIndex = 40;
            this.BtnTextBridge.Text = "Mandar Archivo Texto";
            this.ToolTip1.SetToolTip(this.BtnTextBridge, "Mandar por Correo Electrónico");
            this.BtnTextBridge.UseVisualStyleBackColor = false;
            this.BtnTextBridge.Visible = false;
            this.BtnTextBridge.Click += new System.EventHandler(this.BtnTextBridge_ClickEvent);
            // 
            // BtnMail
            // 
            this.BtnMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMail.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnMail.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMail.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnMail.Location = new System.Drawing.Point(5, 403);
            this.BtnMail.Name = "BtnMail";
            this.BtnMail.Size = new System.Drawing.Size(142, 19);
            this.BtnMail.TabIndex = 39;
            this.BtnMail.Text = "Mandar por Correo";
            this.ToolTip1.SetToolTip(this.BtnMail, "Mandar por Correo Electrónico");
            this.BtnMail.UseVisualStyleBackColor = false;
            this.BtnMail.Click += new System.EventHandler(this.BtnMail_ClickEvent);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnDelete.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnDelete.Location = new System.Drawing.Point(4, 194);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(142, 21);
            this.BtnDelete.TabIndex = 29;
            this.BtnDelete.Text = "Borrar Imágen";
            this.ToolTip1.SetToolTip(this.BtnDelete, "Borra Imágen Activa");
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_ClickEvent);
            // 
            // BtnRotar2
            // 
            this.BtnRotar2.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnRotar2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRotar2.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnRotar2.Location = new System.Drawing.Point(77, 361);
            this.BtnRotar2.Name = "BtnRotar2";
            this.BtnRotar2.Size = new System.Drawing.Size(70, 17);
            this.BtnRotar2.TabIndex = 25;
            this.BtnRotar2.Text = "Rotar <-";
            this.ToolTip1.SetToolTip(this.BtnRotar2, "Rotar <-");
            this.BtnRotar2.UseVisualStyleBackColor = false;
            this.BtnRotar2.Visible = false;
            this.BtnRotar2.Click += new System.EventHandler(this.BtnRotar2_ClickEvent);
            // 
            // BtnRotar1
            // 
            this.BtnRotar1.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnRotar1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRotar1.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnRotar1.Location = new System.Drawing.Point(6, 361);
            this.BtnRotar1.Name = "BtnRotar1";
            this.BtnRotar1.Size = new System.Drawing.Size(70, 17);
            this.BtnRotar1.TabIndex = 24;
            this.BtnRotar1.Text = "Rotar ->";
            this.ToolTip1.SetToolTip(this.BtnRotar1, "Rotar ->");
            this.BtnRotar1.UseVisualStyleBackColor = false;
            this.BtnRotar1.Visible = false;
            this.BtnRotar1.Click += new System.EventHandler(this.BtnRotar1_ClickEvent);
            // 
            // BtnZoomOut
            // 
            this.BtnZoomOut.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnZoomOut.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnZoomOut.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnZoomOut.Location = new System.Drawing.Point(77, 325);
            this.BtnZoomOut.Name = "BtnZoomOut";
            this.BtnZoomOut.Size = new System.Drawing.Size(70, 17);
            this.BtnZoomOut.TabIndex = 21;
            this.BtnZoomOut.Text = "Zoom Out";
            this.ToolTip1.SetToolTip(this.BtnZoomOut, "zoom Out");
            this.BtnZoomOut.UseVisualStyleBackColor = false;
            this.BtnZoomOut.Visible = false;
            this.BtnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_ClickEvent);
            // 
            // BtnZoomIn
            // 
            this.BtnZoomIn.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnZoomIn.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnZoomIn.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnZoomIn.Location = new System.Drawing.Point(6, 325);
            this.BtnZoomIn.Name = "BtnZoomIn";
            this.BtnZoomIn.Size = new System.Drawing.Size(70, 17);
            this.BtnZoomIn.TabIndex = 20;
            this.BtnZoomIn.Text = "Zoom In";
            this.ToolTip1.SetToolTip(this.BtnZoomIn, "Zoom In");
            this.BtnZoomIn.UseVisualStyleBackColor = false;
            this.BtnZoomIn.Visible = false;
            this.BtnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_ClickEvent);
            // 
            // BtnZoom
            // 
            this.BtnZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnZoom.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnZoom.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnZoom.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnZoom.Location = new System.Drawing.Point(6, 306);
            this.BtnZoom.Name = "BtnZoom";
            this.BtnZoom.Size = new System.Drawing.Size(141, 17);
            this.BtnZoom.TabIndex = 13;
            this.BtnZoom.Text = "Zoom";
            this.ToolTip1.SetToolTip(this.BtnZoom, "zoom normal");
            this.BtnZoom.UseVisualStyleBackColor = false;
            this.BtnZoom.Visible = false;
            this.BtnZoom.Click += new System.EventHandler(this.BtnZoom_ClickEvent);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnPrint.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnPrint.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnPrint.Location = new System.Drawing.Point(4, 382);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnPrint.Size = new System.Drawing.Size(142, 20);
            this.BtnPrint.TabIndex = 28;
            this.BtnPrint.Text = "Imprimir";
            this.ToolTip1.SetToolTip(this.BtnPrint, "Imprimir Imágen Activa");
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // SSPanel1
            // 
            this.SSPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel1.Controls.Add(this._CboUoc_1);
            this.SSPanel1.Controls.Add(this._CboUoc_0);
            this.SSPanel1.Controls.Add(this.TxtSubFol2);
            this.SSPanel1.Controls.Add(this.LblsubFol2);
            this.SSPanel1.Controls.Add(this.TxtSubFol1);
            this.SSPanel1.Controls.Add(this.LblSubFolio1);
            this.SSPanel1.Controls.Add(this.BtnSalir);
            this.SSPanel1.Controls.Add(this._TxtCriterio_5);
            this.SSPanel1.Controls.Add(this._TxtCriterio_4);
            this.SSPanel1.Controls.Add(this._TxtCriterio_3);
            this.SSPanel1.Controls.Add(this._TxtCriterio_2);
            this.SSPanel1.Controls.Add(this._TxtCriterio_1);
            this.SSPanel1.Controls.Add(this._TxtCriterio_0);
            this.SSPanel1.Controls.Add(this.Command1);
            this.SSPanel1.Controls.Add(this._LblUoc_1);
            this.SSPanel1.Controls.Add(this._LblUoc_0);
            this.SSPanel1.Controls.Add(this._LblCriterio_5);
            this.SSPanel1.Controls.Add(this._LblCriterio_4);
            this.SSPanel1.Controls.Add(this._LblCriterio_3);
            this.SSPanel1.Controls.Add(this._LblCriterio_2);
            this.SSPanel1.Controls.Add(this._LblCriterio_1);
            this.SSPanel1.Controls.Add(this._LblCriterio_0);
            this.SSPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.SSPanel1.Location = new System.Drawing.Point(0, 0);
            this.SSPanel1.Name = "SSPanel1";
            this.SSPanel1.Size = new System.Drawing.Size(160, 264);
            this.SSPanel1.TabIndex = 2;
            // 
            // _CboUoc_1
            // 
            this._CboUoc_1.AcceptsReturn = true;
            this._CboUoc_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._CboUoc_1.BackColor = System.Drawing.SystemColors.Window;
            this._CboUoc_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._CboUoc_1.Enabled = false;
            this._CboUoc_1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CboUoc_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._CboUoc_1.Location = new System.Drawing.Point(61, 95);
            this._CboUoc_1.MaxLength = 18;
            this._CboUoc_1.Name = "_CboUoc_1";
            this._CboUoc_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CboUoc_1.Size = new System.Drawing.Size(85, 18);
            this._CboUoc_1.TabIndex = 50;
            // 
            // _CboUoc_0
            // 
            this._CboUoc_0.AcceptsReturn = true;
            this._CboUoc_0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._CboUoc_0.BackColor = System.Drawing.SystemColors.Window;
            this._CboUoc_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._CboUoc_0.Enabled = false;
            this._CboUoc_0.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CboUoc_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._CboUoc_0.Location = new System.Drawing.Point(61, 34);
            this._CboUoc_0.MaxLength = 18;
            this._CboUoc_0.Name = "_CboUoc_0";
            this._CboUoc_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CboUoc_0.Size = new System.Drawing.Size(85, 18);
            this._CboUoc_0.TabIndex = 49;
            // 
            // TxtSubFol2
            // 
            this.TxtSubFol2.AcceptsReturn = true;
            this.TxtSubFol2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSubFol2.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSubFol2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtSubFol2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubFol2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtSubFol2.Location = new System.Drawing.Point(62, 133);
            this.TxtSubFol2.MaxLength = 18;
            this.TxtSubFol2.Name = "TxtSubFol2";
            this.TxtSubFol2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtSubFol2.Size = new System.Drawing.Size(85, 18);
            this.TxtSubFol2.TabIndex = 48;
            // 
            // LblsubFol2
            // 
            this.LblsubFol2.AutoSize = true;
            this.LblsubFol2.BackColor = System.Drawing.SystemColors.Window;
            this.LblsubFol2.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblsubFol2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblsubFol2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblsubFol2.Location = new System.Drawing.Point(9, 137);
            this.LblsubFol2.Name = "LblsubFol2";
            this.LblsubFol2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblsubFol2.Size = new System.Drawing.Size(53, 11);
            this.LblsubFol2.TabIndex = 47;
            this.LblsubFol2.Text = "Sub Folio:";
            this.LblsubFol2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TxtSubFol1
            // 
            this.TxtSubFol1.AcceptsReturn = true;
            this.TxtSubFol1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSubFol1.BackColor = System.Drawing.SystemColors.Window;
            this.TxtSubFol1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtSubFol1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubFol1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtSubFol1.Location = new System.Drawing.Point(62, 70);
            this.TxtSubFol1.MaxLength = 18;
            this.TxtSubFol1.Name = "TxtSubFol1";
            this.TxtSubFol1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtSubFol1.Size = new System.Drawing.Size(85, 18);
            this.TxtSubFol1.TabIndex = 46;
            // 
            // LblSubFolio1
            // 
            this.LblSubFolio1.AutoSize = true;
            this.LblSubFolio1.BackColor = System.Drawing.SystemColors.Window;
            this.LblSubFolio1.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblSubFolio1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSubFolio1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblSubFolio1.Location = new System.Drawing.Point(9, 74);
            this.LblSubFolio1.Name = "LblSubFolio1";
            this.LblSubFolio1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblSubFolio1.Size = new System.Drawing.Size(53, 11);
            this.LblSubFolio1.TabIndex = 45;
            this.LblSubFolio1.Text = "Sub Folio:";
            this.LblSubFolio1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _TxtCriterio_5
            // 
            this._TxtCriterio_5.AcceptsReturn = true;
            this._TxtCriterio_5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TxtCriterio_5.BackColor = System.Drawing.SystemColors.Window;
            this._TxtCriterio_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._TxtCriterio_5.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TxtCriterio_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._TxtCriterio_5.Location = new System.Drawing.Point(62, 114);
            this._TxtCriterio_5.MaxLength = 18;
            this._TxtCriterio_5.Name = "_TxtCriterio_5";
            this._TxtCriterio_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TxtCriterio_5.Size = new System.Drawing.Size(85, 18);
            this._TxtCriterio_5.TabIndex = 8;
            this._TxtCriterio_5.TextChanged += new System.EventHandler(this.TxtCriterio_TextChanged);
            this._TxtCriterio_5.Enter += new System.EventHandler(this.TxtCriterio_Enter);
            // 
            // _TxtCriterio_4
            // 
            this._TxtCriterio_4.AcceptsReturn = true;
            this._TxtCriterio_4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TxtCriterio_4.BackColor = System.Drawing.SystemColors.Window;
            this._TxtCriterio_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._TxtCriterio_4.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TxtCriterio_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._TxtCriterio_4.Location = new System.Drawing.Point(62, 208);
            this._TxtCriterio_4.MaxLength = 5;
            this._TxtCriterio_4.Name = "_TxtCriterio_4";
            this._TxtCriterio_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TxtCriterio_4.Size = new System.Drawing.Size(85, 18);
            this._TxtCriterio_4.TabIndex = 30;
            this._TxtCriterio_4.TextChanged += new System.EventHandler(this.TxtCriterio_TextChanged);
            this._TxtCriterio_4.Enter += new System.EventHandler(this.TxtCriterio_Enter);
            // 
            // _TxtCriterio_3
            // 
            this._TxtCriterio_3.AcceptsReturn = true;
            this._TxtCriterio_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TxtCriterio_3.BackColor = System.Drawing.SystemColors.Window;
            this._TxtCriterio_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._TxtCriterio_3.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TxtCriterio_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._TxtCriterio_3.Location = new System.Drawing.Point(62, 190);
            this._TxtCriterio_3.MaxLength = 9;
            this._TxtCriterio_3.Name = "_TxtCriterio_3";
            this._TxtCriterio_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TxtCriterio_3.Size = new System.Drawing.Size(85, 18);
            this._TxtCriterio_3.TabIndex = 11;
            this._TxtCriterio_3.TextChanged += new System.EventHandler(this.TxtCriterio_TextChanged);
            this._TxtCriterio_3.Enter += new System.EventHandler(this.TxtCriterio_Enter);
            // 
            // _TxtCriterio_2
            // 
            this._TxtCriterio_2.AcceptsReturn = true;
            this._TxtCriterio_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TxtCriterio_2.BackColor = System.Drawing.SystemColors.Window;
            this._TxtCriterio_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._TxtCriterio_2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TxtCriterio_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._TxtCriterio_2.Location = new System.Drawing.Point(62, 172);
            this._TxtCriterio_2.MaxLength = 12;
            this._TxtCriterio_2.Name = "_TxtCriterio_2";
            this._TxtCriterio_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TxtCriterio_2.Size = new System.Drawing.Size(85, 18);
            this._TxtCriterio_2.TabIndex = 9;
            this._TxtCriterio_2.TextChanged += new System.EventHandler(this.TxtCriterio_TextChanged);
            this._TxtCriterio_2.Enter += new System.EventHandler(this.TxtCriterio_Enter);
            // 
            // _TxtCriterio_1
            // 
            this._TxtCriterio_1.AcceptsReturn = true;
            this._TxtCriterio_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TxtCriterio_1.BackColor = System.Drawing.SystemColors.Window;
            this._TxtCriterio_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._TxtCriterio_1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TxtCriterio_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._TxtCriterio_1.Location = new System.Drawing.Point(62, 53);
            this._TxtCriterio_1.MaxLength = 18;
            this._TxtCriterio_1.Name = "_TxtCriterio_1";
            this._TxtCriterio_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TxtCriterio_1.Size = new System.Drawing.Size(85, 18);
            this._TxtCriterio_1.TabIndex = 6;
            this._TxtCriterio_1.TextChanged += new System.EventHandler(this.TxtCriterio_TextChanged);
            this._TxtCriterio_1.Enter += new System.EventHandler(this.TxtCriterio_Enter);
            // 
            // _TxtCriterio_0
            // 
            this._TxtCriterio_0.AcceptsReturn = true;
            this._TxtCriterio_0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TxtCriterio_0.BackColor = System.Drawing.SystemColors.Window;
            this._TxtCriterio_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._TxtCriterio_0.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TxtCriterio_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._TxtCriterio_0.Location = new System.Drawing.Point(62, 153);
            this._TxtCriterio_0.MaxLength = 0;
            this._TxtCriterio_0.Name = "_TxtCriterio_0";
            this._TxtCriterio_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TxtCriterio_0.Size = new System.Drawing.Size(85, 18);
            this._TxtCriterio_0.TabIndex = 4;
            this._TxtCriterio_0.TextChanged += new System.EventHandler(this.TxtCriterio_TextChanged);
            this._TxtCriterio_0.Enter += new System.EventHandler(this.TxtCriterio_Enter);
            // 
            // Command1
            // 
            this.Command1.BackColor = System.Drawing.SystemColors.Highlight;
            this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Command1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Command1.Enabled = false;
            this.Command1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command1.ForeColor = System.Drawing.SystemColors.Window;
            this.Command1.Location = new System.Drawing.Point(0, 236);
            this.Command1.Name = "Command1";
            this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Command1.Size = new System.Drawing.Size(156, 24);
            this.Command1.TabIndex = 3;
            this.Command1.Text = "Buscar";
            this.Command1.UseVisualStyleBackColor = false;
            this.Command1.Click += new System.EventHandler(this.Command1_Click);
            // 
            // _LblUoc_1
            // 
            this._LblUoc_1.BackColor = System.Drawing.SystemColors.Window;
            this._LblUoc_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblUoc_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblUoc_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblUoc_1.Location = new System.Drawing.Point(9, 96);
            this._LblUoc_1.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this._LblUoc_1.Name = "_LblUoc_1";
            this._LblUoc_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblUoc_1.Size = new System.Drawing.Size(53, 13);
            this._LblUoc_1.TabIndex = 43;
            this._LblUoc_1.Text = "UOCC:";
            this._LblUoc_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _LblUoc_0
            // 
            this._LblUoc_0.BackColor = System.Drawing.SystemColors.Window;
            this._LblUoc_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblUoc_0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblUoc_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblUoc_0.Location = new System.Drawing.Point(9, 35);
            this._LblUoc_0.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this._LblUoc_0.Name = "_LblUoc_0";
            this._LblUoc_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblUoc_0.Size = new System.Drawing.Size(53, 13);
            this._LblUoc_0.TabIndex = 41;
            this._LblUoc_0.Text = "UOCC:";
            this._LblUoc_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _LblCriterio_5
            // 
            this._LblCriterio_5.AutoSize = true;
            this._LblCriterio_5.BackColor = System.Drawing.SystemColors.Window;
            this._LblCriterio_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblCriterio_5.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblCriterio_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblCriterio_5.Location = new System.Drawing.Point(1, 118);
            this._LblCriterio_5.Name = "_LblCriterio_5";
            this._LblCriterio_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblCriterio_5.Size = new System.Drawing.Size(61, 11);
            this._LblCriterio_5.TabIndex = 38;
            this._LblCriterio_5.Text = "Folio2 UOC:";
            this._LblCriterio_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _LblCriterio_4
            // 
            this._LblCriterio_4.AutoSize = true;
            this._LblCriterio_4.BackColor = System.Drawing.SystemColors.Window;
            this._LblCriterio_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblCriterio_4.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblCriterio_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblCriterio_4.Location = new System.Drawing.Point(6, 212);
            this._LblCriterio_4.Name = "_LblCriterio_4";
            this._LblCriterio_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblCriterio_4.Size = new System.Drawing.Size(56, 11);
            this._LblCriterio_4.TabIndex = 31;
            this._LblCriterio_4.Text = "Folio S403:";
            this._LblCriterio_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _LblCriterio_3
            // 
            this._LblCriterio_3.AutoSize = true;
            this._LblCriterio_3.BackColor = System.Drawing.SystemColors.Window;
            this._LblCriterio_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblCriterio_3.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblCriterio_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblCriterio_3.Location = new System.Drawing.Point(29, 194);
            this._LblCriterio_3.Name = "_LblCriterio_3";
            this._LblCriterio_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblCriterio_3.Size = new System.Drawing.Size(33, 11);
            this._LblCriterio_3.TabIndex = 10;
            this._LblCriterio_3.Text = "Linea:";
            this._LblCriterio_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _LblCriterio_2
            // 
            this._LblCriterio_2.AutoSize = true;
            this._LblCriterio_2.BackColor = System.Drawing.SystemColors.Window;
            this._LblCriterio_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblCriterio_2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblCriterio_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblCriterio_2.Location = new System.Drawing.Point(14, 176);
            this._LblCriterio_2.Name = "_LblCriterio_2";
            this._LblCriterio_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblCriterio_2.Size = new System.Drawing.Size(48, 11);
            this._LblCriterio_2.TabIndex = 7;
            this._LblCriterio_2.Text = "Contrato:";
            this._LblCriterio_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _LblCriterio_1
            // 
            this._LblCriterio_1.AutoSize = true;
            this._LblCriterio_1.BackColor = System.Drawing.SystemColors.Window;
            this._LblCriterio_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblCriterio_1.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblCriterio_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblCriterio_1.Location = new System.Drawing.Point(1, 57);
            this._LblCriterio_1.Name = "_LblCriterio_1";
            this._LblCriterio_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblCriterio_1.Size = new System.Drawing.Size(61, 11);
            this._LblCriterio_1.TabIndex = 5;
            this._LblCriterio_1.Text = "Folio1 UOC:";
            this._LblCriterio_1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _LblCriterio_0
            // 
            this._LblCriterio_0.AutoSize = true;
            this._LblCriterio_0.BackColor = System.Drawing.SystemColors.Window;
            this._LblCriterio_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._LblCriterio_0.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LblCriterio_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LblCriterio_0.Location = new System.Drawing.Point(22, 156);
            this._LblCriterio_0.Name = "_LblCriterio_0";
            this._LblCriterio_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LblCriterio_0.Size = new System.Drawing.Size(40, 11);
            this._LblCriterio_0.TabIndex = 3;
            this._LblCriterio_0.Text = "Cliente:";
            this._LblCriterio_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SSPanel2
            // 
            this.SSPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.SSPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel2.Controls.Add(this.BtnPrint);
            this.SSPanel2.Controls.Add(this.BtnSalvar);
            this.SSPanel2.Controls.Add(this.Highlight);
            this.SSPanel2.Controls.Add(this.ShowAnnotations);
            this.SSPanel2.Controls.Add(this.AddNote);
            this.SSPanel2.Controls.Add(this.Reject);
            this.SSPanel2.Controls.Add(this.Approve);
            this.SSPanel2.Controls.Add(this.BtnZoom);
            this.SSPanel2.Controls.Add(this.BtnZoomIn);
            this.SSPanel2.Controls.Add(this.BtnZoomOut);
            this.SSPanel2.Controls.Add(this.BtnNave);
            this.SSPanel2.Controls.Add(this.BtnRotar1);
            this.SSPanel2.Controls.Add(this.BtnRotar2);
            this.SSPanel2.Controls.Add(this.BtnDelete);
            this.SSPanel2.Controls.Add(this.BtnMail);
            this.SSPanel2.Controls.Add(this.BtnTextBridge);
            this.SSPanel2.Controls.Add(this.DocumentID);
            this.SSPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SSPanel2.ForeColor = System.Drawing.SystemColors.Window;
            this.SSPanel2.Location = new System.Drawing.Point(0, 264);
            this.SSPanel2.Name = "SSPanel2";
            this.SSPanel2.Size = new System.Drawing.Size(160, 448);
            this.SSPanel2.TabIndex = 13;
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnSalvar.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnSalvar.Location = new System.Drawing.Point(7, 280);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnSalvar.Size = new System.Drawing.Size(139, 18);
            this.BtnSalvar.TabIndex = 27;
            this.BtnSalvar.Text = "Guardar Notas";
            this.BtnSalvar.UseVisualStyleBackColor = false;
            this.BtnSalvar.Visible = false;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // Highlight
            // 
            this.Highlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Highlight.BackColor = System.Drawing.SystemColors.Highlight;
            this.Highlight.Cursor = System.Windows.Forms.Cursors.Default;
            this.Highlight.Enabled = false;
            this.Highlight.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Highlight.ForeColor = System.Drawing.SystemColors.Window;
            this.Highlight.Location = new System.Drawing.Point(7, 262);
            this.Highlight.Name = "Highlight";
            this.Highlight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Highlight.Size = new System.Drawing.Size(139, 17);
            this.Highlight.TabIndex = 18;
            this.Highlight.Text = "Resaltar";
            this.Highlight.UseVisualStyleBackColor = false;
            this.Highlight.Visible = false;
            this.Highlight.Click += new System.EventHandler(this.Highlight_Click);
            // 
            // ShowAnnotations
            // 
            this.ShowAnnotations.BackColor = System.Drawing.SystemColors.Highlight;
            this.ShowAnnotations.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowAnnotations.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAnnotations.ForeColor = System.Drawing.SystemColors.Window;
            this.ShowAnnotations.Location = new System.Drawing.Point(6, 4);
            this.ShowAnnotations.Name = "ShowAnnotations";
            this.ShowAnnotations.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowAnnotations.Size = new System.Drawing.Size(137, 13);
            this.ShowAnnotations.TabIndex = 17;
            this.ShowAnnotations.Text = "Despliega Anotaciones";
            this.ShowAnnotations.UseVisualStyleBackColor = false;
            this.ShowAnnotations.Visible = false;
            this.ShowAnnotations.CheckedChanged += new System.EventHandler(this.ShowAnnotations_CheckedChanged);
            this.ShowAnnotations.CheckStateChanged += new System.EventHandler(this.ShowAnnotations_CheckStateChanged);
            // 
            // AddNote
            // 
            this.AddNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNote.BackColor = System.Drawing.SystemColors.Highlight;
            this.AddNote.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddNote.Enabled = false;
            this.AddNote.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNote.ForeColor = System.Drawing.SystemColors.Window;
            this.AddNote.Location = new System.Drawing.Point(7, 244);
            this.AddNote.Name = "AddNote";
            this.AddNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AddNote.Size = new System.Drawing.Size(139, 17);
            this.AddNote.TabIndex = 16;
            this.AddNote.Text = "Agrega Nota";
            this.AddNote.UseVisualStyleBackColor = false;
            this.AddNote.Visible = false;
            this.AddNote.Click += new System.EventHandler(this.AddNote_Click);
            // 
            // Reject
            // 
            this.Reject.BackColor = System.Drawing.SystemColors.Highlight;
            this.Reject.Cursor = System.Windows.Forms.Cursors.Default;
            this.Reject.Enabled = false;
            this.Reject.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reject.ForeColor = System.Drawing.SystemColors.Window;
            this.Reject.Location = new System.Drawing.Point(77, 226);
            this.Reject.Name = "Reject";
            this.Reject.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Reject.Size = new System.Drawing.Size(69, 17);
            this.Reject.TabIndex = 15;
            this.Reject.Text = "Cancelar";
            this.Reject.UseVisualStyleBackColor = false;
            this.Reject.Visible = false;
            this.Reject.Click += new System.EventHandler(this.Reject_Click);
            // 
            // Approve
            // 
            this.Approve.BackColor = System.Drawing.SystemColors.Highlight;
            this.Approve.Cursor = System.Windows.Forms.Cursors.Default;
            this.Approve.Enabled = false;
            this.Approve.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Approve.ForeColor = System.Drawing.SystemColors.Window;
            this.Approve.Location = new System.Drawing.Point(7, 224);
            this.Approve.Name = "Approve";
            this.Approve.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Approve.Size = new System.Drawing.Size(69, 17);
            this.Approve.TabIndex = 14;
            this.Approve.Text = "Aprobar";
            this.Approve.UseVisualStyleBackColor = false;
            this.Approve.Visible = false;
            this.Approve.Click += new System.EventHandler(this.Approve_Click);
            // 
            // BtnNave
            // 
            this.BtnNave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNave.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnNave.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNave.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnNave.Location = new System.Drawing.Point(6, 343);
            this.BtnNave.Name = "BtnNave";
            this.BtnNave.Size = new System.Drawing.Size(141, 17);
            this.BtnNave.TabIndex = 22;
            this.BtnNave.Text = "Navegador";
            this.BtnNave.UseVisualStyleBackColor = false;
            this.BtnNave.Visible = false;
            this.BtnNave.Click += new System.EventHandler(this.BtnNave_ClickEvent);
            // 
            // DocumentID
            // 
            this.DocumentID.BackColor = System.Drawing.SystemColors.Control;
            this.DocumentID.Cursor = System.Windows.Forms.Cursors.Default;
            this.DocumentID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DocumentID.Location = new System.Drawing.Point(6, 158);
            this.DocumentID.Name = "DocumentID";
            this.DocumentID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DocumentID.Size = new System.Drawing.Size(97, 17);
            this.DocumentID.TabIndex = 26;
            this.DocumentID.Visible = false;
            // 
            // SPCont2
            // 
            this.SPCont2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SPCont2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPCont2.Location = new System.Drawing.Point(0, 0);
            this.SPCont2.Name = "SPCont2";
            this.SPCont2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SPCont2.Panel1
            // 
            this.SPCont2.Panel1.Controls.Add(this.dataGridView1);
            this.SPCont2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.SPCont2_Panel1_Paint);
            // 
            // SPCont2.Panel2
            // 
            this.SPCont2.Panel2.Controls.Add(this.SSTab1);
            this.SPCont2.Size = new System.Drawing.Size(776, 716);
            this.SPCont2.SplitterDistance = 80;
            this.SPCont2.SplitterWidth = 2;
            this.SPCont2.TabIndex = 39;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Image,
            this.XfolioP,
            this.Folio,
            this.FolioS403,
            this.Instrumento,
            this.Linea,
            this.NumCliente,
            this.Producto,
            this.TipoDoc,
            this.UOC,
            this.XFolioS,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(772, 76);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Image
            // 
            this.Image.HeaderText = "ID Imagen";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            // 
            // XfolioP
            // 
            this.XfolioP.HeaderText = "XfolioP";
            this.XfolioP.Name = "XfolioP";
            this.XfolioP.ReadOnly = true;
            // 
            // Folio
            // 
            this.Folio.HeaderText = "FolioS403";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            // 
            // FolioS403
            // 
            this.FolioS403.HeaderText = "SecLote";
            this.FolioS403.Name = "FolioS403";
            this.FolioS403.ReadOnly = true;
            // 
            // Instrumento
            // 
            this.Instrumento.HeaderText = "Instrumento";
            this.Instrumento.Name = "Instrumento";
            this.Instrumento.ReadOnly = true;
            // 
            // Linea
            // 
            this.Linea.HeaderText = "Producto";
            this.Linea.Name = "Linea";
            this.Linea.ReadOnly = true;
            // 
            // NumCliente
            // 
            this.NumCliente.HeaderText = "XfolioS";
            this.NumCliente.Name = "NumCliente";
            this.NumCliente.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "CalificaOnDemand";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // TipoDoc
            // 
            this.TipoDoc.HeaderText = "FechaOperacion";
            this.TipoDoc.Name = "TipoDoc";
            this.TipoDoc.ReadOnly = true;
            // 
            // UOC
            // 
            this.UOC.HeaderText = "StatusImagen";
            this.UOC.Name = "UOC";
            this.UOC.ReadOnly = true;
            // 
            // XFolioS
            // 
            this.XFolioS.HeaderText = "Status";
            this.XFolioS.Name = "XFolioS";
            this.XFolioS.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Linea";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Contrato";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "NumCliente";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Folio";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "TipoDoc";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "UOC";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // SSTab1
            // 
            this.SSTab1.Controls.Add(this._SSTab1_TabPage0);
            this.SSTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SSTab1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSTab1.ItemSize = new System.Drawing.Size(42, 17);
            this.SSTab1.Location = new System.Drawing.Point(0, 0);
            this.SSTab1.Name = "SSTab1";
            this.SSTab1.SelectedIndex = 0;
            this.SSTab1.Size = new System.Drawing.Size(772, 630);
            this.SSTab1.TabIndex = 34;
            this.SSTab1.SelectedIndexChanged += new System.EventHandler(this.SSTab1_SelectedIndexChanged);
            // 
            // _SSTab1_TabPage0
            // 
            this._SSTab1_TabPage0.Controls.Add(this.webBrowser1);
            this._SSTab1_TabPage0.Location = new System.Drawing.Point(4, 21);
            this._SSTab1_TabPage0.Name = "_SSTab1_TabPage0";
            this._SSTab1_TabPage0.Size = new System.Drawing.Size(764, 605);
            this._SSTab1_TabPage0.TabIndex = 0;
            this._SSTab1_TabPage0.Text = "Docto 1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(764, 605);
            this.webBrowser1.TabIndex = 0;
            // 
            // SPCont
            // 
            this.SPCont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SPCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPCont.Location = new System.Drawing.Point(0, 0);
            this.SPCont.Margin = new System.Windows.Forms.Padding(2);
            this.SPCont.Name = "SPCont";
            // 
            // SPCont.Panel1
            // 
            this.SPCont.Panel1.Controls.Add(this.SPCont2);
            // 
            // SPCont.Panel2
            // 
            this.SPCont.Panel2.Controls.Add(this.SSPanel2);
            this.SPCont.Panel2.Controls.Add(this.SSPanel1);
            this.SPCont.Size = new System.Drawing.Size(942, 716);
            this.SPCont.SplitterDistance = 776;
            this.SPCont.SplitterWidth = 2;
            this.SPCont.TabIndex = 38;
            // 
            // FrmFileNET
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(942, 716);
            this.Controls.Add(this.SPCont);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "FrmFileNET";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UOC FILENET .Net";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmFileNET_Activated);
            this.Closed += new System.EventHandler(this.FrmFileNET_Closed);
            this.Load += new System.EventHandler(this.FrmFileNET_Load);
            this.SSPanel1.ResumeLayout(false);
            this.SSPanel1.PerformLayout();
            this.SSPanel2.ResumeLayout(false);
            this.SPCont2.Panel1.ResumeLayout(false);
            this.SPCont2.Panel2.ResumeLayout(false);
            this.SPCont2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.SSTab1.ResumeLayout(false);
            this._SSTab1_TabPage0.ResumeLayout(false);
            this.SPCont.Panel1.ResumeLayout(false);
            this.SPCont.Panel2.ResumeLayout(false);
            this.SPCont.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        void InitializeIDMViewerCtrl1()
        {
            /*this.IDMViewerCtrl1[0] = _IDMViewerCtrl1_0;
            this.IDMViewerCtrl1[1] = _IDMViewerCtrl1_1;
            this.IDMViewerCtrl1[2] = _IDMViewerCtrl1_2;
            this.IDMViewerCtrl1[3] = _IDMViewerCtrl1_3;*/
        }
        void InitializeLblUoc()
        {
            this.LblUoc[1] = _LblUoc_1;
            this.LblUoc[0] = _LblUoc_0;
        }
        void InitializeIDMListView1()
        {
            /*this.IDMListView1[0] = _IDMListView1_0;
            this.IDMListView1[1] = _IDMListView1_1; */
        }
        void InitializeCboUoc()
        {
            this.CboUoc[1] = _CboUoc_1;
            this.CboUoc[0] = _CboUoc_0;
        }
        void InitializeLblCriterio()
        {
            this.LblCriterio[5] = _LblCriterio_5;
            this.LblCriterio[4] = _LblCriterio_4;
            this.LblCriterio[3] = _LblCriterio_3;
            this.LblCriterio[2] = _LblCriterio_2;
            this.LblCriterio[1] = _LblCriterio_1;
            this.LblCriterio[0] = _LblCriterio_0;
        }
        void InitializeTxtCriterio()
        {
            this.TxtCriterio[5] = _TxtCriterio_5;
            this.TxtCriterio[4] = _TxtCriterio_4;
            this.TxtCriterio[3] = _TxtCriterio_3;
            this.TxtCriterio[2] = _TxtCriterio_2;
            this.TxtCriterio[1] = _TxtCriterio_1;
            this.TxtCriterio[0] = _TxtCriterio_0;
        }

        #endregion
        //private AxIDMListView.AxIDMListView _IDMListView1_1;
        //private AxIDMListView.AxIDMListView _IDMListView1_0;
        //private AxIDMViewerCtrl.AxIDMViewerCtrl _IDMViewerCtrl1_0;
        //private AxIDMViewerCtrl.AxIDMViewerCtrl _IDMViewerCtrl1_1;
        //private ViewImages.ViewImage viewImage1;
        //private ViewImages.ViewImage viewImage2;
        //private C1.Win.C1SplitContainer.C1SplitContainer c1SplitContainer1;
        //private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel1;
        //private AxIDMViewerCtrl.AxIDMViewerCtrl _IDMViewerCtrl1_2;
        //private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel2;
        //private AxIDMViewerCtrl.AxIDMViewerCtrl _IDMViewerCtrl1_3;
        public System.Windows.Forms.Panel SSPanel1;
        private System.Windows.Forms.TextBox TxtSubFol2;
        private System.Windows.Forms.Label LblsubFol2;
        private System.Windows.Forms.TextBox TxtSubFol1;
        private System.Windows.Forms.Label LblSubFolio1;
        public System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TextBox _TxtCriterio_5;
        private System.Windows.Forms.TextBox _TxtCriterio_4;
        private System.Windows.Forms.TextBox _TxtCriterio_3;
        private System.Windows.Forms.TextBox _TxtCriterio_2;
        private System.Windows.Forms.TextBox _TxtCriterio_1;
        private System.Windows.Forms.TextBox _TxtCriterio_0;
        public System.Windows.Forms.Button Command1;
        private System.Windows.Forms.Label _LblUoc_1;
        private System.Windows.Forms.Label _LblUoc_0;
        private System.Windows.Forms.Label _LblCriterio_5;
        private System.Windows.Forms.Label _LblCriterio_4;
        private System.Windows.Forms.Label _LblCriterio_3;
        private System.Windows.Forms.Label _LblCriterio_2;
        private System.Windows.Forms.Label _LblCriterio_1;
        private System.Windows.Forms.Label _LblCriterio_0;
        public System.Windows.Forms.Panel SSPanel2;
        public System.Windows.Forms.Button BtnPrint;
        public System.Windows.Forms.Button BtnSalvar;
        public System.Windows.Forms.Button Highlight;
        public System.Windows.Forms.CheckBox ShowAnnotations;
        public System.Windows.Forms.Button AddNote;
        public System.Windows.Forms.Button Reject;
        public System.Windows.Forms.Button Approve;
        public System.Windows.Forms.Button BtnZoom;
        public System.Windows.Forms.Button BtnZoomIn;
        public System.Windows.Forms.Button BtnZoomOut;
        public System.Windows.Forms.Button BtnNave;
        public System.Windows.Forms.Button BtnRotar1;
        public System.Windows.Forms.Button BtnRotar2;
        public System.Windows.Forms.Button BtnDelete;
        public System.Windows.Forms.Button BtnMail;
        public System.Windows.Forms.Button BtnTextBridge;
        public System.Windows.Forms.Label DocumentID;
        private System.Windows.Forms.SplitContainer SPCont2;
        public System.Windows.Forms.TabControl SSTab1;
        private System.Windows.Forms.TabPage _SSTab1_TabPage0;
        private System.Windows.Forms.SplitContainer SPCont;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn XfolioP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolioS403;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instrumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linea;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn XFolioS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TextBox _CboUoc_1;
        private System.Windows.Forms.TextBox _CboUoc_0;
        // private AxIDMListView.AxIDMListView IDMListView2;
    }
}