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
        public System.Windows.Forms.ComboBox[] CboUoc = new System.Windows.Forms.ComboBox[2];
        public AxIDMListView.AxIDMListView[] IDMListView1 = new AxIDMListView.AxIDMListView[2];
        public AxIDMViewerCtrl.AxIDMViewerCtrl[] IDMViewerCtrl1 = new AxIDMViewerCtrl.AxIDMViewerCtrl[4];
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
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnZoom = new System.Windows.Forms.Button();
            this.BtnZoomIn = new System.Windows.Forms.Button();
            this.BtnZoomOut = new System.Windows.Forms.Button();
            this.BtnRotar1 = new System.Windows.Forms.Button();
            this.BtnRotar2 = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnMail = new System.Windows.Forms.Button();
            this.BtnTextBridge = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.SPCont = new System.Windows.Forms.SplitContainer();
            this.SPCont2 = new System.Windows.Forms.SplitContainer();
            this.SSTab1 = new System.Windows.Forms.TabControl();
            this._SSTab1_TabPage0 = new System.Windows.Forms.TabPage();
            this.viewImage1 = new ViewImages.ViewImage();
            this._SSTab1_TabPage1 = new System.Windows.Forms.TabPage();
            this.viewImage2 = new ViewImages.ViewImage();
            this._SSTab1_TabPage2 = new System.Windows.Forms.TabPage();
            this.c1SplitContainer1 = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.c1SplitterPanel1 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.c1SplitterPanel2 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.SSPanel2 = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.Highlight = new System.Windows.Forms.Button();
            this.ShowAnnotations = new System.Windows.Forms.CheckBox();
            this.AddNote = new System.Windows.Forms.Button();
            this.Reject = new System.Windows.Forms.Button();
            this.Approve = new System.Windows.Forms.Button();
            this.BtnNave = new System.Windows.Forms.Button();
            this.DocumentID = new System.Windows.Forms.Label();
            this.SSPanel1 = new System.Windows.Forms.Panel();
            this.TxtSubFol2 = new System.Windows.Forms.TextBox();
            this.LblsubFol2 = new System.Windows.Forms.Label();
            this.TxtSubFol1 = new System.Windows.Forms.TextBox();
            this.LblSubFolio1 = new System.Windows.Forms.Label();
            this._CboUoc_1 = new System.Windows.Forms.ComboBox();
            this._CboUoc_0 = new System.Windows.Forms.ComboBox();
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
            this._IDMListView1_0 = new AxIDMListView.AxIDMListView();
            this._IDMListView1_1 = new AxIDMListView.AxIDMListView();
            this._IDMViewerCtrl1_0 = new AxIDMViewerCtrl.AxIDMViewerCtrl();
            this._IDMViewerCtrl1_1 = new AxIDMViewerCtrl.AxIDMViewerCtrl();
            this._IDMViewerCtrl1_2 = new AxIDMViewerCtrl.AxIDMViewerCtrl();
            this._IDMViewerCtrl1_3 = new AxIDMViewerCtrl.AxIDMViewerCtrl();
            this.IDMListView2 = new AxIDMListView.AxIDMListView();
            ((System.ComponentModel.ISupportInitialize)(this.SPCont)).BeginInit();
            this.SPCont.Panel1.SuspendLayout();
            this.SPCont.Panel2.SuspendLayout();
            this.SPCont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPCont2)).BeginInit();
            this.SPCont2.Panel1.SuspendLayout();
            this.SPCont2.Panel2.SuspendLayout();
            this.SPCont2.SuspendLayout();
            this.SSTab1.SuspendLayout();
            this._SSTab1_TabPage0.SuspendLayout();
            this._SSTab1_TabPage1.SuspendLayout();
            this._SSTab1_TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).BeginInit();
            this.c1SplitContainer1.SuspendLayout();
            this.c1SplitterPanel1.SuspendLayout();
            this.c1SplitterPanel2.SuspendLayout();
            this.SSPanel2.SuspendLayout();
            this.SSPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._IDMListView1_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMListView1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMViewerCtrl1_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMViewerCtrl1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMViewerCtrl1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMViewerCtrl1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDMListView2)).BeginInit();
            this.SuspendLayout();
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
            this.BtnZoom.Click += new System.EventHandler(this.BtnZoom_ClickEvent);
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
            this.BtnZoomIn.Click += new System.EventHandler(this.BtnZoomIn_ClickEvent);
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
            this.BtnZoomOut.Click += new System.EventHandler(this.BtnZoomOut_ClickEvent);
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
            this.BtnRotar1.Click += new System.EventHandler(this.BtnRotar1_ClickEvent);
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
            this.BtnRotar2.Click += new System.EventHandler(this.BtnRotar2_ClickEvent);
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
            this.BtnTextBridge.Click += new System.EventHandler(this.BtnTextBridge_ClickEvent);
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
            this.SPCont2.Panel1.Controls.Add(this._IDMListView1_0);
            this.SPCont2.Panel1.Controls.Add(this._IDMListView1_1);
            // 
            // SPCont2.Panel2
            // 
            this.SPCont2.Panel2.Controls.Add(this.SSTab1);
            this.SPCont2.Size = new System.Drawing.Size(776, 716);
            this.SPCont2.SplitterDistance = 80;
            this.SPCont2.SplitterWidth = 2;
            this.SPCont2.TabIndex = 39;
            // 
            // SSTab1
            // 
            this.SSTab1.Controls.Add(this._SSTab1_TabPage0);
            this.SSTab1.Controls.Add(this._SSTab1_TabPage1);
            this.SSTab1.Controls.Add(this._SSTab1_TabPage2);
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
            this._SSTab1_TabPage0.Controls.Add(this.viewImage1);
            this._SSTab1_TabPage0.Controls.Add(this._IDMViewerCtrl1_0);
            this._SSTab1_TabPage0.Location = new System.Drawing.Point(4, 21);
            this._SSTab1_TabPage0.Name = "_SSTab1_TabPage0";
            this._SSTab1_TabPage0.Size = new System.Drawing.Size(764, 605);
            this._SSTab1_TabPage0.TabIndex = 0;
            this._SSTab1_TabPage0.Text = "Docto 1";
            // 
            // viewImage1
            // 
            this.viewImage1.AutoScroll = true;
            this.viewImage1.AutoSize = true;
            this.viewImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewImage1.Location = new System.Drawing.Point(0, 0);
            this.viewImage1.Name = "viewImage1";
            this.viewImage1.pArchivo = "";
            this.viewImage1.Size = new System.Drawing.Size(764, 605);
            this.viewImage1.TabIndex = 34;
            // 
            // _SSTab1_TabPage1
            // 
            this._SSTab1_TabPage1.Controls.Add(this.viewImage2);
            this._SSTab1_TabPage1.Controls.Add(this._IDMViewerCtrl1_1);
            this._SSTab1_TabPage1.Location = new System.Drawing.Point(4, 21);
            this._SSTab1_TabPage1.Name = "_SSTab1_TabPage1";
            this._SSTab1_TabPage1.Size = new System.Drawing.Size(764, 605);
            this._SSTab1_TabPage1.TabIndex = 1;
            this._SSTab1_TabPage1.Text = "Docto 2";
            // 
            // viewImage2
            // 
            this.viewImage2.AutoScroll = true;
            this.viewImage2.AutoSize = true;
            this.viewImage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewImage2.Location = new System.Drawing.Point(0, 0);
            this.viewImage2.Name = "viewImage2";
            this.viewImage2.pArchivo = "";
            this.viewImage2.Size = new System.Drawing.Size(764, 605);
            this.viewImage2.TabIndex = 35;
            // 
            // _SSTab1_TabPage2
            // 
            this._SSTab1_TabPage2.Controls.Add(this.c1SplitContainer1);
            this._SSTab1_TabPage2.Location = new System.Drawing.Point(4, 21);
            this._SSTab1_TabPage2.Name = "_SSTab1_TabPage2";
            this._SSTab1_TabPage2.Size = new System.Drawing.Size(764, 605);
            this._SSTab1_TabPage2.TabIndex = 2;
            this._SSTab1_TabPage2.Text = "Docto 1 y 2";
            // 
            // c1SplitContainer1
            // 
            this.c1SplitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.c1SplitContainer1.CollapsingAreaColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.c1SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1SplitContainer1.FixedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(166)))), ((int)(((byte)(194)))));
            this.c1SplitContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.c1SplitContainer1.HeaderHeight = 15;
            this.c1SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.c1SplitContainer1.Name = "c1SplitContainer1";
            this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel1);
            this.c1SplitContainer1.Panels.Add(this.c1SplitterPanel2);
            this.c1SplitContainer1.Size = new System.Drawing.Size(764, 605);
            this.c1SplitContainer1.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(166)))), ((int)(((byte)(194)))));
            this.c1SplitContainer1.TabIndex = 37;
            this.c1SplitContainer1.ToolTipGradient = C1.Win.C1SplitContainer.ToolTipGradient.Blue;
            this.c1SplitContainer1.UseParentVisualStyle = false;
            // 
            // c1SplitterPanel1
            // 
            this.c1SplitterPanel1.AutoScroll = true;
            this.c1SplitterPanel1.Collapsible = true;
            this.c1SplitterPanel1.Controls.Add(this._IDMViewerCtrl1_2);
            this.c1SplitterPanel1.HeaderTextAlign = C1.Win.C1SplitContainer.PanelTextAlign.Center;
            this.c1SplitterPanel1.Height = 282;
            this.c1SplitterPanel1.Location = new System.Drawing.Point(0, 0);
            this.c1SplitterPanel1.Name = "c1SplitterPanel1";
            this.c1SplitterPanel1.Size = new System.Drawing.Size(764, 282);
            this.c1SplitterPanel1.SizeRatio = 48.087D;
            this.c1SplitterPanel1.TabIndex = 0;
            // 
            // c1SplitterPanel2
            // 
            this.c1SplitterPanel2.Collapsible = true;
            this.c1SplitterPanel2.Controls.Add(this._IDMViewerCtrl1_3);
            this.c1SplitterPanel2.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Bottom;
            this.c1SplitterPanel2.HeaderTextAlign = C1.Win.C1SplitContainer.PanelTextAlign.Center;
            this.c1SplitterPanel2.Height = 312;
            this.c1SplitterPanel2.Location = new System.Drawing.Point(0, 293);
            this.c1SplitterPanel2.MinHeight = 20;
            this.c1SplitterPanel2.MinWidth = 549;
            this.c1SplitterPanel2.Name = "c1SplitterPanel2";
            this.c1SplitterPanel2.Size = new System.Drawing.Size(764, 312);
            this.c1SplitterPanel2.SizeRatio = 20D;
            this.c1SplitterPanel2.TabIndex = 1;
            this.c1SplitterPanel2.Width = 764;
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
            this.SSPanel2.Controls.Add(this.IDMListView2);
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
            // SSPanel1
            // 
            this.SSPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel1.Controls.Add(this.TxtSubFol2);
            this.SSPanel1.Controls.Add(this.LblsubFol2);
            this.SSPanel1.Controls.Add(this.TxtSubFol1);
            this.SSPanel1.Controls.Add(this.LblSubFolio1);
            this.SSPanel1.Controls.Add(this.BtnSalir);
            this.SSPanel1.Controls.Add(this._CboUoc_1);
            this.SSPanel1.Controls.Add(this._CboUoc_0);
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
            // _CboUoc_1
            // 
            this._CboUoc_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._CboUoc_1.BackColor = System.Drawing.SystemColors.Window;
            this._CboUoc_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._CboUoc_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CboUoc_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CboUoc_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._CboUoc_1.Items.AddRange(new object[] {
            "4519",
            "4520",
            "4521",
            "2557",
            "3236"});
            this._CboUoc_1.Location = new System.Drawing.Point(62, 90);
            this._CboUoc_1.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this._CboUoc_1.Name = "_CboUoc_1";
            this._CboUoc_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CboUoc_1.Size = new System.Drawing.Size(85, 22);
            this._CboUoc_1.TabIndex = 44;
            // 
            // _CboUoc_0
            // 
            this._CboUoc_0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._CboUoc_0.BackColor = System.Drawing.SystemColors.Window;
            this._CboUoc_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._CboUoc_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._CboUoc_0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CboUoc_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._CboUoc_0.Items.AddRange(new object[] {
            "4519",
            "4520",
            "4521",
            "2557",
            "3236"});
            this._CboUoc_0.Location = new System.Drawing.Point(62, 30);
            this._CboUoc_0.Name = "_CboUoc_0";
            this._CboUoc_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CboUoc_0.Size = new System.Drawing.Size(85, 22);
            this._CboUoc_0.TabIndex = 42;
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
            // _IDMListView1_0
            // 
            this._IDMListView1_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this._IDMListView1_0.Location = new System.Drawing.Point(0, 0);
            this._IDMListView1_0.Name = "_IDMListView1_0";
            this._IDMListView1_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDMListView1_0.OcxState")));
            this._IDMListView1_0.Size = new System.Drawing.Size(772, 76);
            this._IDMListView1_0.TabIndex = 35;
            this._IDMListView1_0.DblClick += new System.EventHandler(this.IDMListView1_DblClick);
            // 
            // _IDMListView1_1
            // 
            this._IDMListView1_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._IDMListView1_1.Location = new System.Drawing.Point(3, 0);
            this._IDMListView1_1.Name = "_IDMListView1_1";
            this._IDMListView1_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDMListView1_1.OcxState")));
            this._IDMListView1_1.Size = new System.Drawing.Size(775, 71);
            this._IDMListView1_1.TabIndex = 39;
            this._IDMListView1_1.DblClick += new System.EventHandler(this.IDMListView1_DblClick);
            // 
            // _IDMViewerCtrl1_0
            // 
            this._IDMViewerCtrl1_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this._IDMViewerCtrl1_0.Enabled = true;
            this._IDMViewerCtrl1_0.Location = new System.Drawing.Point(0, 0);
            this._IDMViewerCtrl1_0.Name = "_IDMViewerCtrl1_0";
            this._IDMViewerCtrl1_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDMViewerCtrl1_0.OcxState")));
            this._IDMViewerCtrl1_0.Size = new System.Drawing.Size(764, 605);
            this._IDMViewerCtrl1_0.TabIndex = 33;
            this._IDMViewerCtrl1_0.ClickEvent += new System.EventHandler(this.IDMViewerCtrl1_ClickEvent);
            // 
            // _IDMViewerCtrl1_1
            // 
            this._IDMViewerCtrl1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._IDMViewerCtrl1_1.Enabled = true;
            this._IDMViewerCtrl1_1.Location = new System.Drawing.Point(0, 0);
            this._IDMViewerCtrl1_1.Name = "_IDMViewerCtrl1_1";
            this._IDMViewerCtrl1_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDMViewerCtrl1_1.OcxState")));
            this._IDMViewerCtrl1_1.Size = new System.Drawing.Size(764, 605);
            this._IDMViewerCtrl1_1.TabIndex = 34;
            this._IDMViewerCtrl1_1.ClickEvent += new System.EventHandler(this.IDMViewerCtrl1_ClickEvent);
            // 
            // _IDMViewerCtrl1_2
            // 
            this._IDMViewerCtrl1_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._IDMViewerCtrl1_2.Enabled = true;
            this._IDMViewerCtrl1_2.Location = new System.Drawing.Point(0, 0);
            this._IDMViewerCtrl1_2.Name = "_IDMViewerCtrl1_2";
            this._IDMViewerCtrl1_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDMViewerCtrl1_2.OcxState")));
            this._IDMViewerCtrl1_2.Size = new System.Drawing.Size(764, 282);
            this._IDMViewerCtrl1_2.TabIndex = 36;
            // 
            // _IDMViewerCtrl1_3
            // 
            this._IDMViewerCtrl1_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._IDMViewerCtrl1_3.Enabled = true;
            this._IDMViewerCtrl1_3.Location = new System.Drawing.Point(0, 0);
            this._IDMViewerCtrl1_3.Name = "_IDMViewerCtrl1_3";
            this._IDMViewerCtrl1_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDMViewerCtrl1_3.OcxState")));
            this._IDMViewerCtrl1_3.Size = new System.Drawing.Size(764, 312);
            this._IDMViewerCtrl1_3.TabIndex = 37;
            // 
            // IDMListView2
            // 
            this.IDMListView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IDMListView2.Location = new System.Drawing.Point(0, 23);
            this.IDMListView2.Name = "IDMListView2";
            this.IDMListView2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("IDMListView2.OcxState")));
            this.IDMListView2.Size = new System.Drawing.Size(154, 165);
            this.IDMListView2.TabIndex = 19;
            this.IDMListView2.Visible = false;
            this.IDMListView2.DblClick += new System.EventHandler(this.IDMListView2_DblClick);
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
            this.SPCont.Panel1.ResumeLayout(false);
            this.SPCont.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPCont)).EndInit();
            this.SPCont.ResumeLayout(false);
            this.SPCont2.Panel1.ResumeLayout(false);
            this.SPCont2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPCont2)).EndInit();
            this.SPCont2.ResumeLayout(false);
            this.SSTab1.ResumeLayout(false);
            this._SSTab1_TabPage0.ResumeLayout(false);
            this._SSTab1_TabPage0.PerformLayout();
            this._SSTab1_TabPage1.ResumeLayout(false);
            this._SSTab1_TabPage1.PerformLayout();
            this._SSTab1_TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1SplitContainer1)).EndInit();
            this.c1SplitContainer1.ResumeLayout(false);
            this.c1SplitterPanel1.ResumeLayout(false);
            this.c1SplitterPanel2.ResumeLayout(false);
            this.SSPanel2.ResumeLayout(false);
            this.SSPanel1.ResumeLayout(false);
            this.SSPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._IDMListView1_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMListView1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMViewerCtrl1_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMViewerCtrl1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMViewerCtrl1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDMViewerCtrl1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDMListView2)).EndInit();
            this.ResumeLayout(false);

        }
        void InitializeIDMViewerCtrl1()
        {
            this.IDMViewerCtrl1[0] = _IDMViewerCtrl1_0;
            this.IDMViewerCtrl1[1] = _IDMViewerCtrl1_1;
            this.IDMViewerCtrl1[2] = _IDMViewerCtrl1_2;
            this.IDMViewerCtrl1[3] = _IDMViewerCtrl1_3;
        }
        void InitializeLblUoc()
        {
            this.LblUoc[1] = _LblUoc_1;
            this.LblUoc[0] = _LblUoc_0;
        }
        void InitializeIDMListView1()
        {
            this.IDMListView1[0] = _IDMListView1_0;
            this.IDMListView1[1] = _IDMListView1_1;
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

        private System.Windows.Forms.SplitContainer SPCont;
        public System.Windows.Forms.Panel SSPanel1;
        private System.Windows.Forms.ComboBox _CboUoc_1;
        private System.Windows.Forms.ComboBox _CboUoc_0;
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
        public AxIDMListView.AxIDMListView IDMListView2;
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
        private AxIDMListView.AxIDMListView _IDMListView1_1;
        private AxIDMListView.AxIDMListView _IDMListView1_0;
        public System.Windows.Forms.TabControl SSTab1;
        private System.Windows.Forms.TabPage _SSTab1_TabPage0;
        private AxIDMViewerCtrl.AxIDMViewerCtrl _IDMViewerCtrl1_0;
        private System.Windows.Forms.TabPage _SSTab1_TabPage1;
        private AxIDMViewerCtrl.AxIDMViewerCtrl _IDMViewerCtrl1_1;
        private System.Windows.Forms.TabPage _SSTab1_TabPage2;
        public System.Windows.Forms.Button BtnSalir;
        private ViewImages.ViewImage viewImage1;
        private ViewImages.ViewImage viewImage2;
        private C1.Win.C1SplitContainer.C1SplitContainer c1SplitContainer1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private AxIDMViewerCtrl.AxIDMViewerCtrl _IDMViewerCtrl1_2;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private AxIDMViewerCtrl.AxIDMViewerCtrl _IDMViewerCtrl1_3;
        private System.Windows.Forms.TextBox TxtSubFol1;
        private System.Windows.Forms.Label LblSubFolio1;
        private System.Windows.Forms.TextBox TxtSubFol2;
        private System.Windows.Forms.Label LblsubFol2;

    }
}