using System.Globalization;
using System.Threading;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System;
using BulkLoader;

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using FileNet.Api.Core;
using FileNet.Api.Meta;
using FileNet.Api.Collection;

namespace UOCFilenet
{

    public partial class FrmFileNET
        : System.Windows.Forms.Form
    {

        //class ExitEnvironmentException : Exception { }
        CEConnection ceConnection = new CEConnection();
        public string DirWinTemp = String.Empty;
        public string XArchivo = String.Empty;
        byte Bande = 0;
        byte DocAct = 0;
        short Rotar = 0;

        private string Procesa_Folio(string FolioD, string UOCX, string XSubFol)
        {
            string sWhere = "F_DOCTYPE = 'IMAGE'";
            //sWhere = sWhere & " AND F_DOCCLASSNAME = '" & gfSettings.txtResDocClass & "'"
            sWhere = sWhere + " AND F_DOCCLASSNAME = 'ExpedientesDC'";
            if (Double.Parse(@Globals.UOC) > 0)
            {
                sWhere = sWhere + " AND UOC = '" + UOCX + "'";
            }
            //Since we're looking at annotations, just grab images
            switch (@Globals.VarCom)
            {
                case 1:
                case 4:
                case 5:
                case 8:
                case 9:
                case 10://Select 
                    if (Conversion.Val(TxtCriterio[0].Text) > 0 && TxtCriterio[0].Text.Trim().Length > 0)
                    {
                        sWhere = sWhere + " AND NumCliente = '" + TxtCriterio[0].Text + "'";
                    }
                    if (Conversion.Val(TxtCriterio[1].Text) > 0 && TxtCriterio[1].Text.Trim().Length > 0)
                    {
                        //XFolio = TxtCriterio(1)
                        sWhere = sWhere + " AND Folio = '" + FolioD + "'";
                    }
                    if (Conversion.Val(TxtCriterio[2].Text) > 0 && TxtCriterio[2].Text.Trim().Length > 0)
                    {
                        sWhere = sWhere + " AND Contrato = '" + TxtCriterio[2].Text + "'";
                    }
                    if (Conversion.Val(TxtCriterio[3].Text) > 0 && TxtCriterio[3].Text.Trim().Length > 0)
                    {
                        sWhere = sWhere + " AND Linea = '" + TxtCriterio[3].Text + "'";
                    }
                    //AVG Ini Sept-2015
                    if (Conversion.Val(XSubFol) > 0 && XSubFol.Trim().Length > 0)
                    {
                        if (@Globals.VarCom == 9) sWhere = sWhere + " AND XfolioP >= '" + XSubFol.ToString()  + "'";
                        else sWhere = sWhere + " AND XfolioP = '" + XSubFol.ToString() + "'";
                    }
                    //AVG Fin Sept-2015
                    break;

                case 2:
                case 3:
                case 6:  //Update 
                    if (Conversion.Val(TxtCriterio[1].Text) > 0 && TxtCriterio[1].Text.Trim().Length > 0)
                    {
                        sWhere = sWhere + " AND Folio = '" + TxtCriterio[1].Text + "'";
                    }
                    //AVG Ini Sept-2015
                    if (Conversion.Val(XSubFol) > 0 && XSubFol.Trim().Length > 0)
                    {
                        sWhere = sWhere + " AND XFolioP = '" + XSubFol.ToString() + "'";
                    }
                    //AVG Fin Sept-2015
                    break;
            }
            return sWhere;
        }

        private void SetLVHeaders(Collection cHeadings, Collection cPropNames)
        {
            string[] asClasses = new string[2];
            //asClasses(0) = gfSettings.txtResDocClass
            asClasses[0] = "ExpedientesDC";
            //Set goPropDescs = oLibrary.FilterPropertyDescriptions(idmObjTypeDocument, _
            //'asClasses)
            @Globals.goPropDescs = ceConnection.getPropertiesDescriptions(oLibrary, asClasses);
                //(IDMObjects.PropertyDescriptions)@Globals.oLibrary.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, asClasses);
            //IDMListView1[DocAct].ClearColumnHeaders(oLibrary);
            //IDMListView1[DocAct].ClearItems();
            foreach (IPropertyDescription oPropDesc in @Globals.goPropDescs)
            {
                if (oPropDesc.Name.Substring(0, Math.Min(oPropDesc.Name.Length, 2)) != "F_" && (oPropDesc.Name == "UOC" || oPropDesc.Name == "Folio" || oPropDesc.Name == "Contrato" || oPropDesc.Name == "NumCliente" || oPropDesc.Name == "Linea" || oPropDesc.Name == "TipoDoc" || oPropDesc.Name == "FolioS403" || oPropDesc.Name == "Producto" || oPropDesc.Name == "Instrumento" || oPropDesc.Name == "XfolioS"))
                {
                    if (Bande == 0)
                    {
              //          IDMListView1[DocAct].AddColumnHeader(oLibrary, oPropDesc);
                        cHeadings.Add(oPropDesc.DisplayName, null, null, null);
                        cPropNames.Add(oPropDesc.Name, null, null, null);
                    }
                }
            }
            Bande = 1;
            //IDMListView1[DocAct].SwitchColumnHeaders(oLibrary);
        }

        //Dim oLibrary As IDMObjects.Library
        IObjectStore oLibrary;
        private bool ConnectToLibraries()
        {
            bool result = false;
            try
            {

                RestoreSettings(true);
                // Make sure we have some valid library ID's
                if (@Globals.gfSettings.txtIMSLibName.Text == "")
                {
                    RestoreSettings(true);
                }
                if (@Globals.gfSettings.txtIMSLibName.Text == "")
                {
                    MessageBox.Show(this, "You must first set the runtime parameters!", Application.ProductName);
                    return false;
                }
                // We may have been here before, so clean up any old library
                // connections
                if (@Globals.gbISLogOff)
                {
                    //TOdo perform logout
                    //oLibrary.l.Logoff();
                }
                oLibrary = null;

                // Hook up to the IMS library
                //@Globals.oLibrary.SystemType = IDMObjects.idmSysTypeOptions.idmSysTypeIS;
                //oLibrary.Name = @Globals.gfSettings.txtIMSLibName.Text;

                
                //if (!@Globals.oLibrary.GetState(IDMObjects.idmLibraryState.idmLibraryLoggedOn))
                {
                    //@Globals.oLibrary.Logon(@Globals.gfSettings.txtIMSUser, @Globals.gfSettings.txtIMSPassword, Type.Missing, IDMObjects.idmLibraryLogon.idmLogonOptNoUI);
                    ceConnection.EstablishCredentials(@Globals.gfSettings.txtIMSUser.Text, @Globals.gfSettings.txtIMSPassword.Text,
                        @Globals.gfSettings.textResUrl.Text, @Globals.gfSettings.txtIMSLibName.Text);
                    oLibrary= ceConnection.FetchOS(@Globals.gfSettings.txtIMSLibName.Text);
                    @Globals.gbISLogOff = true;
                }
                //else
                {
                   // @Globals.gbISLogOff = false;
                }
                return true;
            }
            catch (Exception excep)
            {

                MessageBox.Show(this, excep.Message, Application.ProductName);
                result = false;
            }
            return result;
        }
        // Routine for restoring Registry settings dealing with
        // IDMLibrary information
        private void RestoreSettings(bool bForceUi)
        {
            if (bForceUi)
            {
                @Globals.goPersist.GetSettings(@Globals.gsAppName, @Globals.gsSectionName, @Globals.gfSettings);
                @Globals.gfSettings.ShowDialog();
            }
            else
            {
                @Globals.goPersist.GetSettings(@Globals.gsAppName, @Globals.gsSectionName, @Globals.gfSettings);
            }
        }

        private void BtnDelete_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            if (MessageBox.Show(this, "Estas Seguro de Borrar la Imágen de FileNET ?", "¿Barrar Archivo?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                @Globals.oDocument.Delete();
                this.Close();
            }
        }

        private void BtnMail_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            
                //TODO define what does email option
            //@Globals.oDocument.Send(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, (IDMObjects.idmSendOptions)(((int)IDMObjects.idmSendOptions.idmSendWithUI) + ((int)IDMObjects.idmSendOptions.idmSendCopy)));

        }

        private void BtnNave_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            /*if (IDMViewerCtrl1[DocAct].ShowNavigator == true)
            {
                IDMViewerCtrl1[DocAct].ShowNavigator = false;
            }
            else
            {
                IDMViewerCtrl1[DocAct].ShowNavigator = true;
            }
            IDMViewerCtrl1[DocAct].NavigatorWindowWidth = 175;
            IDMViewerCtrl1[DocAct].NavigatorWindowHeight = 175; */
        }

        private void BtnPrint_Click(Object eventSender, EventArgs eventArgs)
        {
            //IDMViewerCtrl1[DocAct].LocalPrint.DoPrint(true);
        }

        private void BtnRotar1_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            if (Rotar == 270)
            {
                Rotar = 0;
            }
            else
            {
                Rotar += 90;
            }
            //IDMViewerCtrl1[DocAct].Rotation = Rotar;

            if (DocAct == 0)
            {
               // viewImage1.FlitHorizontal();
            }
            else if (DocAct == 1)
            {
               // viewImage2.FlitHorizontal();
            }
        }

        private void BtnRotar2_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            if (Rotar == 0)
            {
                Rotar = 270;
            }
            else
            {
                Rotar -= 90;
            }
            //IDMViewerCtrl1[DocAct].Rotation = Rotar;
            if (DocAct == 0)
            {
                //viewImage1.FlitVertical();
            }
            else if (DocAct == 1)
            {
                //viewImage2.FlitVertical();
            }
        }

        private void BtnSalir_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
             string tempRefParam = Globals.TmpImg + "*.tmp";
             bool Borrados = KillFile(ref tempRefParam) != 0;
             if (!Borrados)
             {
                 FileSystem.PrintLine(1, "No pude borrar imagenes existentes Imgtmp");
             }
             this.Close();
        }
        //AIS-666 ebonilla
        private void releaseResources(Object eventSender, EventArgs eventArgs)
        {
            m_vb6FormDefInstance = null;
        }


        private void BtnSalvar_Click(Object eventSender, EventArgs eventArgs)
        {
            //UPGRADE_TODO:Member PageNumber is not defined in type IDMViewerCtrl.IDMViewerCtrl. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1067"'
           // int pg = IDMViewerCtrl1[DocAct].PageNumber;
            if (DocAct == 0 || DocAct == 2)
            {
                //@Globals.oDocument.Save();
                MessageBox.Show("Save file...");
            }
            else
            {
//                @Globals.oDocument2.Save();
                MessageBox.Show("Save file...");
            }
            //IDMListView2.ClearItems();
            ShowAnnotations_Click(ShowAnnotations, new EventArgs());
            if (DocAct == 0 || DocAct == 2)
            {
                //UPGRADE_TODO:Member Document is not defined in type IDMViewerCtrl.IDMViewerCtrl. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1067"'
                //UPGRADE_WARNING:oDocument of type IDMObjects.Document is being forced to Scalar. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1068"'
                //AIS - DVega
                //Artinsoft.VB6.Utils.ReflectionHelper.SetMember(IDMViewerCtrl1[DocAct], "Document", @Globals.oDocument);
                //IDMViewerCtrl1[DocAct].Document = @Globals.oDocument;
                MessageBox.Show("IDMViewerCtrl1 document...");

                DocumentID.Text = @Globals.oDocument.Name;
            }
            else
            {
                //UPGRADE_TODO:Member Document is not defined in type IDMViewerCtrl.IDMViewerCtrl. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1067"'
                //UPGRADE_WARNING:oDocument2 of type IDMObjects.Document is being forced to Scalar. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1068"'
                //AIS - DVega   
                //Artinsoft.VB6.Utils.ReflectionHelper.SetMember(IDMViewerCtrl1[DocAct], "Document", @Globals.oDocument2);
                //IDMViewerCtrl1[DocAct].Document = @Globals.oDocument2;
                MessageBox.Show("IDMViewerCtrl1 document...");
                DocumentID.Text = @Globals.oDocument2.Name;
            }
            //if (pg > 1)
            {
                //UPGRADE_TODO:Member PageNumber is not defined in type IDMViewerCtrl.IDMViewerCtrl. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1067"'
                //AIS - DVega
                //Artinsoft.VB6.Utils.ReflectionHelper.SetMember(IDMViewerCtrl1[DocAct], "PageNumber", pg);
               // IDMViewerCtrl1[DocAct].PageNumber = pg;
            }
            //else
            {
                //UPGRADE_TODO:Member PageNumber is not defined in type IDMViewerCtrl.IDMViewerCtrl. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1067"'
                //AIS - DVega
                //Artinsoft.VB6.Utils.ReflectionHelper.SetMember(IDMViewerCtrl1[DocAct], "PageNumber", 1);
             //   IDMViewerCtrl1[DocAct].PageNumber = 1;
            }
        }

        private void BtnTextBridge_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
            bool OnErrorResumeNext = false;
            string Cade = String.Empty;
            string Cade1 = String.Empty;
            if (XArchivo.Trim().Length > 0)
            {
                OnErrorResumeNext = true;
                try
                {
                    File.Delete(XArchivo);
                }
                catch
                {
                }
            }
            try
            {
                if (DocAct == 1)
                {
                    //TODO not defined operation
                    //Cade = @Globals.oDocument2.GetCachedFile(0, "", Type.Missing);
                }
                else
                {
                    //TODO not defined operation
                    //Cade = @Globals.oDocument.GetCachedFile(0, "", Type.Missing);
                }
            }
            catch (Exception e1)
            {
                if (!OnErrorResumeNext)
                    throw e1;
            }

            string Cade2 = Cade;
            try
            {
                Cade1 = @Globals.GetFileName(ref Cade2);
            }
            catch (Exception e2)
            {
                if (!OnErrorResumeNext)
                    throw e2;
            }
            int PosPunto = Cade1.IndexOf(".FOB");
            Cade1 = @Globals.TmpImg + Cade1.Substring(0, Math.Min(Cade1.Length, PosPunto)) + ".tif";
            // Copia el archivo de cache a Ubicacion de trabajo
            try
            {
                File.Copy(Cade, Cade1);
            }
            catch (Exception e3)
            {
                if (!OnErrorResumeNext)
                    throw e3;
            }
            XArchivo = Cade1;
            Cade1 = Path.GetDirectoryName(Application.ExecutablePath) + "\\TextBridge\\Bin\\TextBridge.Exe " + XArchivo;
            //MsgBox Cade1
            try
            {
                double VarPaso = Process.Start(Cade1).Id;
            }
            catch
            {
            }
        }

        private void BtnZoom_ClickEvent(Object eventSender, EventArgs eventArgs)
        {            
           // IDMViewerCtrl1[DocAct].CustomZoom = 1;
            if (DocAct == 0)
            {
               // viewImage1.ZoomReset();
            }
            else if (DocAct == 1)
            {
                //viewImage2.ZoomReset();
            }
        }

        private void BtnZoomIn_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
           // IDMViewerCtrl1[DocAct].ZoomIn();

            if (DocAct == 0)
            {
                //viewImage1.ZoomIn(); 
            }
            else if (DocAct == 1)
            {
                //viewImage2.ZoomIn();
            }
        }

        private void BtnZoomOut_ClickEvent(Object eventSender, EventArgs eventArgs)
        {
           // IDMViewerCtrl1[DocAct].ZoomOut();
            if (DocAct == 0)
            {
                //viewImage1.ZoomOut();
            }
            else if (DocAct == 1)
            {
                //viewImage2.ZoomOut();
            }
        }

        //private void  CloseBtn_Click()
        //{
        //        this.Hide();
        //}

        private void Form_Initialize_Renamed()
        {
            //Dim CommandLine
            //object Temp1 = null;
            //object Temp2 = null;
            //AIS -DVega: Desaparece la conversion de String a Int32
            if (String.IsNullOrEmpty(@Globals.CommandLine))
                @Globals.CommandLine = Interaction.Command().Trim(); //Trim(UCase(Command()))
            //Set goPropDescs = New IDMObjects.PropertyDescriptions
            //MsgBox CommandLine
            @Globals.VarCom = 0; // Instrunción default para Consulta
            @Globals.UOC = "5065";
            @Globals.UOC1 = "5065";
            @Globals.TipoDoc = "999";
            @Globals.XFolio = "0";
            @Globals.XFolio2 = "0";
            @Globals.XFolioS403 = "0";
            @Globals.XProd = "400";
            @Globals.XInst = "1";
            @Globals.XFile = "000014429277/00";
            DocAct = 0;
            @Globals.XCalifOnd = "1";
            @Globals.XFechaOp = "09/17/1970";

        }

        // On start-up, populate the combo box with candidate libraries
        private void FrmFileNET_Load(Object eventSender, EventArgs eventArgs)
        {
            ConnectToLibraries();
            setHeaderColumnNames();
            if (true)
            {
                return;
            }

            /*@Globals.oLibraries = (IDMObjects.ObjectSet)@Globals.oNeighborhood.Libraries;
            IDMObjects.Library oLib;
            oLib = new IDMObjects.Library();//Activator.CreateInstance(Type.GetTypeFromProgID("idmObjects.Library"));
            oLib = (IDMObjects.Library)Activator.CreateInstance(Type.GetTypeFromProgID("idmObjects.Library"));
            oLib.SystemType = IDMObjects.idmSysTypeOptions.idmSysTypeIS;*/
            /*
            @Globals.oLibraries = (IDMObjects.ObjectSet)@Globals.oNeighborhood.Libraries;
            IDMObjects.Library oLib = (IDMObjects.Library)Activator.CreateInstance(Type.GetTypeFromProgID("idmObjects.Library"));
            oLib.SystemType = IDMObjects.idmSysTypeOptions.idmSysTypeIS;
            */


            byte Bande = 0;
            @Globals.gbISLogOff = false;



            string tempRefParam = Globals.TmpImg + "*.tif";
            bool Borrados = KillFile(ref tempRefParam) != 0;
            if (!Borrados)
            {
                FileSystem.PrintLine(1, "No pude borrar imagenes existentes ImgTiff");
            }

            tempRefParam = Globals.TmpImg + "*.tmp";
            Borrados = KillFile(ref tempRefParam) != 0;
            if (!Borrados)
            {
                FileSystem.PrintLine(1, "No pude borrar imagenes existentes Imgtmp");
            }

            DirWinTemp = @Globals.DirLog;

            @Globals.Genera_Archivo_Control();

            string Libreria = "";// @Globals.fncParmIniGet("C406090", "FileNET", @Globals.DirConf + "C406090.ini");

            if ((Libreria == null) || (Libreria.Length == 0))
            {
                MessageBox.Show(this, "No se encuentra el archivo de inicio de FileNET", Application.ProductName);
                oLibrary = null;
                //@Globals.fncParmIniSet("UOCFileNet", "Execute", "2", DirWinTemp + "UOCFileNet.ini");
                //@Globals.fncParmIniSet("Error", "ErrNumber", "2", DirWinTemp + "UOCFileNet.ini");
                //@Globals.fncParmIniSet("Error", "DescError", "No se encuentra el archivo de inicio de FileNET", DirWinTemp + "UOCFileNet.ini");
                //AIS-867 ebonilla
                //throw new ExitEnvironmentException();
                //Environment.Exit(0);
            }

            /*
            for (int i = 1; i <= ((int)@Globals.oLibraries.Count); i++)
            {                                
                if ((((IDMObjects.Library)@Globals.oLibraries[i]).Name) == "DefaultIMS:" + Libreria)
                {
                    Bande = 1;
                    oLib = (IDMObjects.Library)@Globals.oLibraries[i];
                    break;
                }
            }

            if (Bande == 0)
            {
                oLib.Name = Libreria;
            }
            */

            Llena_Paramatros(1);
            if (@Globals.VarCom == 7 || @Globals.VarCom == 8)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }

            if (@Globals.VarCom == 0)
            {
                MessageBox.Show(this, "Parámetros No decuados para Ejecutar el Programa", Application.ProductName);
                oLibrary = null;
                @Globals.fncParmIniSet("UOCFileNet", "Execute", "3", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Error", "ErrNumber", "3", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Error", "DescError", "Parámetros No decuados para Ejecutar el Programa", DirWinTemp + "UOCFileNet.ini");
                this.Close();
            }

            MyLogon(""); // Hace LOGON a librería
            if (!(oLibrary.RootFolder.FolderName.Contains("/")))
            {
                MessageBox.Show(this, "Error en logon a librería", Application.ProductName);
                @Globals.gbISLogOff = false;
                @Globals.fncParmIniSet("UOCFileNet", "Execute", "4", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Error", "ErrNumber", "4", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Error", "DescError", "Error en logon a librería", DirWinTemp + "UOCFileNet.ini");
                //throw new ExitEnvironmentException();
                Environment.Exit(0);
            }
            else
            {
                @Globals.gbISLogOff = true;
                //@Globals.oLibrary = oLib; // Hace la librería global por flexibilidad
            }
           
            Command1.Enabled = true;
            Llena_Paramatros(2);

            //AVG Ini 25-04-2012
            Llena_UOCs();
            //AVG Fin 25-04-2012

            //Clear the list view items
            //IDMListView1[DocAct].ClearItems();
            //Clear viewer
            //IDMViewerCtrl1[DocAct].Clear();
            //Clear annotation list
            //IDMListView2.ClearItems();
            //Blank out the document id
            DocumentID.Text = "";
            SSPanel2.Visible = false;
            BtnPrint.Enabled = false;
            BtnDelete.Enabled = false;
            /*DirWinTemp = @Globals.GetWindowsDir();
            if (@Globals.DirExist(DirWinTemp + "Temp") == -1)
            {
                DirWinTemp = DirWinTemp + "Temp\\";
            }*/

            // AVG Ini Sept 2013
            // Se agrega 
            if (@Globals.VarCom == 7) // Modo de Espera para hacer actualizaciones en segundo plano
            {
                @Globals.fncParmIniSet("UOCFileNet", "Execute", "7", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Error", "ErrNumber", "7", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Error", "DescError", "Logon en modo de espera", DirWinTemp + "UOCFileNet.ini");
                this.Visible = false;
                this.Hide();

            }
            if (@Globals.VarCom == 8 || @Globals.VarCom == 2 || @Globals.VarCom == 3 || @Globals.VarCom == 6 || @Globals.VarCom == 9 || @Globals.VarCom == 10)
            {
                this.Visible = false;
                this.Hide();
            }
            // AVG Ini Sept 2013
            if (@Globals.VarCom == 4)
            {
                BtnPrint.Enabled = true;
            }
            if (@Globals.VarCom == 5)
            {
                BtnPrint.Enabled = true;
                BtnDelete.Enabled = true;
            }
            Bande = 0;
            Rotar = 0;
            string UOC_Temp = @Globals.UOC;
            //AVG Ini 25-04-2012
            //@Globals.LLena_CboUoc(ref UOC_Temp, CboUoc[0]);
            //AVG Fin 25-04-2012
            if (Conversion.Val(@Globals.UOC) > 0)
            {
                CboUoc[0].Text = @Globals.UOC;
            }
            UOC_Temp = @Globals.UOC1;
            //AVG Ini 25-04-2012
            //@Globals.LLena_CboUoc(ref UOC_Temp, CboUoc[1]);
            //AVG Fin 25-04-2012
            if (Conversion.Val(@Globals.UOC1) > 0)
            {
                CboUoc[1].Text = @Globals.UOC1;
            }
            XArchivo = String.Empty;
            oLibrary = null;

            if (@Globals.VarCom >= 1 && @Globals.VarCom <= 6 && (Conversion.Val(@Globals.XFolio) > 0 || Conversion.Val(@Globals.XFolio2) > 0))
            {
                Command1_Click(Command1, eventArgs);
            }

            // AVG Ini Sept 2013
            if (@Globals.VarCom == 8  && (Conversion.Val(@Globals.XFolio) > 0 || Conversion.Val(@Globals.XFolio2) > 0))
            {
                Command1_Click(Command1, eventArgs);
            }
            // AVG Fin Sept 2013

            // AVG Ini Sept-2015
            if (@Globals.VarCom == 9  && Conversion.Val(@Globals.XFolio) > 0 && Conversion.Val(@Globals.SubFol1) > 0)
            {
                Command1_Click(Command1, eventArgs);
            }
            // AVG Fin Sept-2015

            // AVG Ini  2017
            if (@Globals.VarCom == 10 && (Conversion.Val(@Globals.XFolio) > 0 || Conversion.Val(@Globals.XFolio2) > 0))
            {
                Command1_Click(Command1, eventArgs);
            }
            // AVG Fin 2017
            
        }

        // Fire off a query to populate our IDMListView
        private void Command1_Click(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                double tmpDouble = 0;
                Collection cHeadings = new Collection();
                clsSimpleQuery oQuery = new clsSimpleQuery();
                int i = 0;
               
                /*IDMListView1[0].ClearItems();
                IDMListView1[1].ClearItems();
                IDMListView2.ClearItems();
                IDMViewerCtrl1[0].Clear();
                IDMViewerCtrl1[1].Clear();
                IDMViewerCtrl1[2].Clear();
                IDMViewerCtrl1[3].Clear(); */
                ShowAnnotations.CheckState = CheckState.Unchecked;
                if (String.IsNullOrEmpty(TxtCriterio[0].Text) && String.IsNullOrEmpty(TxtCriterio[1].Text) && String.IsNullOrEmpty(TxtCriterio[2].Text) && String.IsNullOrEmpty(TxtCriterio[3].Text) && String.IsNullOrEmpty(TxtCriterio[4].Text) && String.IsNullOrEmpty(TxtCriterio[5].Text))
                {
                    MessageBox.Show(this, "Faltan Paramétros para realizar la Busqueda", Application.ProductName);
                    return;
                }
                if (Conversion.Val(TxtCriterio[1].Text) > 0)
                {
                    @Globals.XFolio = (TxtCriterio[1].Text);
                }
                if (Conversion.Val(CboUoc[0].Text) > 0)
                {
                    @Globals.UOC = Conversion.Val(CboUoc[0].Text).ToString();
                }
                //AVG Ini Sept-2015
                if (Conversion.Val(TxtSubFol1.Text) > 0 && TxtSubFol1.Text.Trim().Length > 0)
                {
                    @Globals.SubFol1 = TxtSubFol1.Text.Trim();
                }
                else
                {
                    @Globals.SubFol1 = string.Empty;
                }
                if (Conversion.Val(TxtSubFol2.Text) > 0 && TxtSubFol2.Text.Trim().Length > 0)
                {
                    @Globals.SubFol2 = TxtSubFol2.Text.Trim();
                }
                else @Globals.SubFol2 = string.Empty;
                //string sWhere = Procesa_Folio(@Globals.XFolio, @Globals.UOC);
                string sWhere = Procesa_Folio(@Globals.XFolio, @Globals.UOC, @Globals.SubFol1);
                //AVG Fin Sept-2015                

                if (Conversion.Val(@Globals.XFolio2) > 0)
                {
                    @Globals.XFolio2 = TxtCriterio[5].Text;
                }
                string sClass = "ExpedientesDC";
                @Globals.gcHeadings = new Collection();
                @Globals.gcPropNames = new Collection();
                SetLVHeaders(@Globals.gcHeadings, @Globals.gcPropNames);
                @Globals.clsQuery.BindToLib(oLibrary, @Globals.gcHeadings, sClass);
                Cursor = Cursors.WaitCursor;
                //AxIDMListView.AxIDMListView tempRefParam = this.IDMListView1[0];
               // @Globals.clsQuery.ExecQuery(ref tempRefParam, sWhere, "", 20);
                SSPanel2.Visible = false;
                Cursor = Cursors.Arrow;
                Rotar = 0;
                if (@Globals.VarCom == 2 || @Globals.VarCom == 3 || @Globals.VarCom == 6)
                { //update parameters
                    this.Hide();
                    //@Globals.clsQuery.UpdateQuery(oLibrary, sClass, IDMListView1[DocAct]);
                    this.Close();
                    Environment.Exit(0);
                }
                Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 0, false);
                Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 1, false);
                Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 2, false);
                if (@Globals.VarCom == 1 || @Globals.VarCom == 4 || @Globals.VarCom == 5)
                {

                    if ((Double.TryParse(@Globals.XFolio, out tmpDouble) && (tmpDouble > 0))
                        || ((!Double.TryParse(@Globals.XFolio, out tmpDouble)) && (@Globals.XFolio != null)))
                    {
                        i = 0;
                       // if (IDMListView1[i].CountItems() > 0)
                        {
                         //   IDMListView1[i].SelectItem(1);
                            IDMListView1_DblClick(i);
                            int tempRefParam2 = i + 2;
                            IDMListView1_DblClick(tempRefParam2);
                            Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 0, true);                            
                           // @Globals.clsQuery.UpdateQuery(oLibrary, sClass, IDMListView1[DocAct]);
                            //IDMViewerCtrl1[i].ZoomMode = IDMViewerCtrl.idmZoomMode.idmZoomModeFitToWidth;
                            try
                            {
                                @Globals.Pag = 1;// IDMViewerCtrl1[i].Pages.Count;
                            }
                            catch {
                                @Globals.Pag = 1;
                            }
                        }
                    }

                    if ((Double.TryParse(@Globals.XFolio2, out tmpDouble) && (tmpDouble > 0))
                        || ((!Double.TryParse(@Globals.XFolio2, out tmpDouble)) && (@Globals.XFolio2 != null)))
                    {
                        if (Conversion.Val(CboUoc[1].Text) > 0)
                        {
                            @Globals.UOC1 = Conversion.Val(CboUoc[1].Text).ToString();
                        }

                        //AVG Ini Sept-2015
                        //sWhere = Procesa_Folio(@Globals.XFolio2, @Globals.UOC1);
                        sWhere = Procesa_Folio(@Globals.XFolio2, @Globals.UOC1, @Globals.SubFol2);
                        //AVG Fin Sept-2015

                        //AxIDMListView.AxIDMListView tempRefParam3 = this.IDMListView1[1];
                       // @Globals.clsQuery.ExecQuery(ref tempRefParam3, sWhere, "", 20);
                        i = 1;
                        //if (IDMListView1[i].CountItems() > 0)
                        {
                          //  IDMListView1[i].SelectItem(1);
                            IDMListView1_DblClick(i);
                            int tempRefParam4 = i + 2;
                            IDMListView1_DblClick(tempRefParam4);
                            Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 1, true);
                            Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 2, true);                            
                            //@Globals.clsQuery.UpdateQuery(oLibrary, sClass, IDMListView1[DocAct]);
                            //IDMViewerCtrl1[i].ZoomMode = IDMViewerCtrl.idmZoomMode.idmZoomModeFitToWidth;
                            @Globals.Pag = 0;// IDMViewerCtrl1[i].Pages.Count;
                            try
                            {
                                @Globals.Pag = 1;// IDMViewerCtrl1[i].Pages.Count;
                            }
                            catch
                            {
                                @Globals.Pag = 1;
                            }
                        }
                    }
                }

                // AVG Ini Sept 2013
                if (@Globals.VarCom == 8)  // Exporta las imágenes a un directorio
                {
                    this.Hide();
                    string[] sClasses = new string[2];
                    sClasses[0] = sClass;

                    IPropertyDescriptionList oPropDescs = null;
                    oPropDescs =ceConnection.getPropertiesDescriptions(oLibrary, sClasses);
                    if ((Double.TryParse(@Globals.XFolio, out tmpDouble) && (tmpDouble > 0))
                        || ((!Double.TryParse(@Globals.XFolio, out tmpDouble)) && (@Globals.XFolio != null)))
                    {
                        i = 0;
                        string Cade1 = String.Empty;
                        string Cade = String.Empty;
                        string cade2 = String.Empty;
                        string XtipDoc = String.Empty;
                        byte PosPunto = 0;

                       // for (i = 0; i < IDMListView1[0].CountItems(); i++)
                        {
                         //   IDMListView1[0].SelectItem(i + 1);
                            IDMListView1_DblClick(0);
                            IDMListView1_DblClick(2);
                            Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 0, true);

                            //Cade = @Globals.oDocument.GetCachedFile(0, "", null);
                            MessageBox.Show("Get Cached file...");
                            cade2 = Cade;
                            Cade1 = @Globals.GetFileName(ref cade2);
                            PosPunto = (byte)Cade1.IndexOf(".FOB");
                            XtipDoc = @Globals.oDocument.Properties.GetProperty("TipoDoc").GetObjectValue().ToString();
                            Cade1 = @Globals.TmpImg + Cade1.Substring(0, Math.Min(Cade1.Length, PosPunto)) + "-" + XtipDoc.Trim() + ".tif";

                            if (File.Exists(Cade1))
                            {
                                try
                                {
                                    File.Delete(Cade1);
                                }
                                catch { }
                            }
                            // Copia el archivo de cache a Ubicacion de trabajo
                            try
                            {
                                File.Copy(Cade, Cade1, true);
                                File.SetAttributes(Cade1, FileAttributes.Normal);
                            }
                            catch { }
                        }
                       // if (IDMListView1[0].CountItems() == 0)
                        {
                            @Globals.fncParmIniSet("UOCFileNet", "Execute", "8", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Error", "ErrNumber", "8", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Error", "DescError", "Error No hay Imágenes con esos parámetros", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Cadena", "Cadena", Interaction.Command().Trim(), DirWinTemp + "UOCFileNet.ini");
                        }
                       // else
                        {
                            @Globals.fncParmIniSet("UOCFileNet", "Execute", "1", DirWinTemp + "UOCFileNet.ini");
                        }
                    }
                    this.Close();
                    Environment.Exit(0);
                }
                // AVG Fin Sept 2013

                // AVG Ini Sept-2015
                if (@Globals.VarCom == 9)  // Borra las Imágenes de un Folio y SubFolio
                {
                    this.Hide();
                    string[] sClasses = new string[2];
                    sClasses[0] = sClass;

                    IPropertyDescriptionList oPropDescs = null;
                    oPropDescs = ceConnection.getPropertiesDescriptions(oLibrary, sClasses);
                    if ((Double.TryParse(@Globals.XFolio, out tmpDouble) && (tmpDouble > 0))
                        || ((!Double.TryParse(@Globals.XFolio, out tmpDouble)) && (@Globals.XFolio != null)))
                    {

                       // for (i = 0; i < IDMListView1[0].CountItems(); i++)
                        {
                           // IDMListView1[0].SelectItem(i + 1);
                            IDMListView1_DblClick(0);
                            IDMListView1_DblClick(2);
                            Artinsoft.VB6.Gui.SSTabHelper.SetTabEnabled(SSTab1, 0, true);
                            try
                            {
                                @Globals.oDocument.Delete();
                            }
                            catch { }
                        }
                       // if (IDMListView1[0].CountItems() == 0)
                        {
                            @Globals.fncParmIniSet("UOCFileNet", "Execute", "9", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Error", "ErrNumber", "9", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Error", "DescError", "Error No hay Imágenes con esos parámetros", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Cadena", "Cadena", Interaction.Command().Trim(), DirWinTemp + "UOCFileNet.ini");
                        }
                       // else
                        {
                            @Globals.fncParmIniSet("UOCFileNet", "Execute", "1", DirWinTemp + "UOCFileNet.ini");
                        }
                    }
                    this.Close();
                    Environment.Exit(0);
                }
                // AVG Fin Sept-2015

                // AVG Ini 2017
                if (@Globals.VarCom == 10)  // Valida que si está el Folio
                {
                    this.Hide();
                    string[] sClasses = new string[2];
                    sClasses[0] = sClass;

                    IPropertyDescriptionList oPropDescs = null;
                    oPropDescs = ceConnection.getPropertiesDescriptions(oLibrary, sClasses);
                    if ((Double.TryParse(@Globals.XFolio, out tmpDouble) && (tmpDouble > 0))
                        || ((!Double.TryParse(@Globals.XFolio, out tmpDouble)) && (@Globals.XFolio != null)))
                    {

                       // if (IDMListView1[0].CountItems() == 0)
                        {
                            @Globals.fncParmIniSet("UOCFileNet", "Execute", "10", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Error", "ErrNumber", "10", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Error", "DescError", "Error No hay Imágenes con esos parámetros", DirWinTemp + "UOCFileNet.ini");
                            @Globals.fncParmIniSet("Cadena", "Cadena", Interaction.Command().Trim(), DirWinTemp + "UOCFileNet.ini");
                        }
                        //else
                        {
                            @Globals.fncParmIniSet("UOCFileNet", "Execute", "1", DirWinTemp + "UOCFileNet.ini");
                        }
                    }
                    this.Close();
                    Environment.Exit(0);
                }
                // AVG Fin 2017

            }
            catch { }
        }

        private void setHeaderColumnNames()
        {
            /* dataGridView1.Columns[0].HeaderText = " ";
             dataGridView1.Columns[1].HeaderText = "Contrato";
             dataGridView1.Columns[2].HeaderText = "Folio";
             dataGridView1.Columns[3].HeaderText = "Folio S403";
             dataGridView1.Columns[4].HeaderText = "Instrumento";
             dataGridView1.Columns[5].HeaderText = "Linea";
             dataGridView1.Columns[6].HeaderText = "NumCliente";
             dataGridView1.Columns[7].HeaderText = "Producto";
             dataGridView1.Columns[8].HeaderText = "TipoDoc";
             dataGridView1.Columns[9].HeaderText = "UOC";
             dataGridView1.Columns[9].HeaderText = "XFolioS";
             */

            dataGridView1.ColumnCount = 5;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(dataGridView1.Font, FontStyle.Bold);

            //dataGridView1.Name = "dataGridView1";
            dataGridView1.Location = new Point(8, 8);
            dataGridView1.Size = new Size(500, 250);
            dataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.RowHeadersVisible = false;

            /*dataGridView1.Columns[0].Name = "Release Date";
            dataGridView1.Columns[1].Name = "Track";
            dataGridView1.Columns[2].Name = "Title";
            dataGridView1.Columns[3].Name = "Artist";
            dataGridView1.Columns[4].Name = "Album";*/
            dataGridView1.Columns[4].DefaultCellStyle.Font =
                new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Italic);

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.Dock = DockStyle.Fill;

           /* dataGridView1.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                dataGridView1_CellFormatting);
                */
            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            dataGridView1.Rows.Add(row0);
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);
            // dataGridView1.DataMember.Insert(1, "bbb");


        }



        //private void Command1_Click(Button Command1, EventArgs eventArgs)
        //{
        //    Collection cHeadings = new Collection();
        //    clsSimpleQuery oQuery = new clsSimpleQuery();
        //    int i = 0;
        //    //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMListView1().ClearItems. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //    IDMListView1[0].ClearItems();
        //    //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMListView1().ClearItems. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //    IDMListView1[1].ClearItems();
        //    IDMListView2.ClearItems();
        //    //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMViewerCtrl1().Clear. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //    IDMViewerCtrl1[0].Clear();
        //    //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMViewerCtrl1().Clear. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //    IDMViewerCtrl1[1].Clear();
        //    //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMViewerCtrl1().Clear. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //    IDMViewerCtrl1[2].Clear();
        //    //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMViewerCtrl1().Clear. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //    IDMViewerCtrl1[3].Clear();
        //    ShowAnnotations.CheckState = CheckState.Unchecked;
        //    //FSQ20070525. UPGRADE_ISSUE:IsEmpty function is not supported. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
        //    if ((TxtCriterio[0].TextLength == 0) && (TxtCriterio[1].TextLength == 0) && (TxtCriterio[2].TextLength == 0) && (TxtCriterio[3].TextLength == 0) && (TxtCriterio[4].TextLength == 0) && (TxtCriterio[5].TextLength == 0))
        //    {
        //        MessageBox.Show(this, "Faltan Paramétros para realizar la Busqueda", Application.ProductName);
        //        return;
        //    }
        //    if (Conversion.Val(TxtCriterio[1].Text) > 0)
        //    {
        //        @Globals.XFolio = (TxtCriterio[1].Text);
        //    }
        //    if (Conversion.Val(CboUoc[0].Text) > 0)
        //    {
        //        @Globals.UOC = Conversion.Val(CboUoc[0].Text).ToString();
        //    }
        //    string sWhere = Procesa_Folio(@Globals.XFolio, @Globals.UOC);
        //    if (Conversion.Val(@Globals.XFolio2) > 0)
        //    {
        //        @Globals.XFolio2 = TxtCriterio[5].Text;
        //    }
        //    //MsgBox "swhere :" & sWhere
        //    //sClass = gfSettings.txtResDocClass
        //    string sClass = "ExpedientesDC";
        //    @Globals.gcHeadings = new Collection();
        //    @Globals.gcPropNames = new Collection();
        //    SetLVHeaders(@Globals.gcHeadings, @Globals.gcPropNames);
        //    @Globals.clsQuery.BindToLib(@Globals.oLibrary, @Globals.gcHeadings, sClass);
        //    Cursor = Cursors.WaitCursor;
        //    AxIDMListView.AxIDMListView tempRefParam = this.IDMListView1[0];
        //    @Globals.clsQuery.ExecQuery(ref tempRefParam, sWhere, "", 20);
        //    //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object SSPanel2.Visible. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //    SSPanel2.Visible = false;
        //    Cursor = Cursors.Arrow;
        //    Rotar = 0;
        //    if (@Globals.VarCom == 2 || @Globals.VarCom == 3 || @Globals.VarCom == 6)
        //    { // update parameters
        //        @Globals.clsQuery.UpdateQuery(@Globals.oLibrary, sClass, IDMListView1[DocAct]);
        //        this.Close();
        //    }

        //    SupportClass.TabControlSupportClass.SetTabEnabled(SSTab1, 0, false);
        //    SupportClass.TabControlSupportClass.SetTabEnabled(SSTab1, 1, false);
        //    SupportClass.TabControlSupportClass.SetTabEnabled(SSTab1, 2, false);
        //    if (@Globals.VarCom == 1 || @Globals.VarCom == 4 || @Globals.VarCom == 5)
        //    {
        //        if (@Globals.XFolio != null)
        //        //if (Double.Parse(@Globals.XFolio) > 0)
        //        {
        //            i = 0;
        //            //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMListView1(i).CountItems. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //            if (IDMListView1[i].CountItems() > 0)
        //            {
        //                //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMListView1().SelectItem. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //                IDMListView1[i].SelectItem(1);
        //                IDMListView1_DblClick(i);
        //                int tempRefParam2 = i + 2;
        //                IDMListView1_DblClick(tempRefParam2);
        //                SupportClass.TabControlSupportClass.SetTabEnabled(SSTab1, 0, true);
        //                @Globals.Pag = IDMViewerCtrl1[i].Pages.Count;
        //                @Globals.clsQuery.UpdateQuery(@Globals.oLibrary, sClass, IDMListView1[DocAct]);
        //            }
        //        }
        //        if (Double.Parse(@Globals.XFolio2) > 0)
        //        {
        //            if (Conversion.Val(CboUoc[1].Text) > 0)
        //            {
        //                @Globals.UOC1 = Conversion.Val(CboUoc[1].Text).ToString();
        //            }
        //            sWhere = Procesa_Folio(@Globals.XFolio2, @Globals.UOC1);
        //            AxIDMListView.AxIDMListView tempRefParam3 = this.IDMListView1[1];
        //            @Globals.clsQuery.ExecQuery(ref tempRefParam3, sWhere, "", 20);
        //            i = 1;
        //            //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMListView1(i).CountItems. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //            if (IDMListView1[i].CountItems() > 0)
        //            {
        //                //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object IDMListView1().SelectItem. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        //                IDMListView1[i].SelectItem(1);
        //                IDMListView1_DblClick(i);
        //                int tempRefParam4 = i + 2;
        //                IDMListView1_DblClick(tempRefParam4);
        //                SupportClass.TabControlSupportClass.SetTabEnabled(SSTab1, 1, true);
        //                SupportClass.TabControlSupportClass.SetTabEnabled(SSTab1, 2, true);
        //                @Globals.Pag = IDMViewerCtrl1[i].Pages.Count;
        //                @Globals.clsQuery.UpdateQuery(@Globals.oLibrary, sClass, IDMListView1[DocAct]);
        //            }
        //        }
        //    }
        //}

        // Log off from libraries on termination
        private void FrmFileNET_Closed(Object eventSender, EventArgs eventArgs)
        {
            //TODO perform logout
            /*if (@Globals.gbISLogOff)
            {
                if (oLibrary.GetState(IDMObjects.idmLibraryState.idmLibraryLoggedOn))
                {
                    @Globals.oLibrary.Logoff();
                }
            }
            */
            if (XArchivo.Trim().Length > 0)
            {
                try
                {
                    File.Delete(XArchivo);
                }
                catch
                {
                }
            }
            //AIS-867 ebonilla
            this.Dispose(); 
        }

        private void IDMListView1_DblClick(object sender, EventArgs e)
        {
           // IDMListView1_DblClick(Array.IndexOf(IDMListView1, sender));
        }


        //AIS - DVega: Borrado de ref
        private void IDMListView1_DblClick(int Index)
        {
            // Double click to view the document
            int IndexTemp = 0;
            if (Index > 1)
            {
                IndexTemp = Index - 2;
            }
            else
            {
                IndexTemp = Index;
            }

            //TODO perform click
            MessageBox.Show("Show...." + Index);
            /*if (IndexTemp == 0 && IDMListView1[IndexTemp].SelectedItem != null)
            {
                @Globals.oDocument = (IDMObjects.Document)IDMListView1[IndexTemp].SelectedItem;
                IDMListView2.ClearItems();
                IDMViewerCtrl1[Index].Document = @Globals.oDocument;
                IDMViewerCtrl1[Index].Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                //ShowAnnotations_Click(ShowAnnotations, new EventArgs());
                DocumentID.Text = @Globals.oDocument.Name;
                SSPanel2.Visible = true;
                IDMViewerCtrl1[Index].Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                IDMViewerCtrl1[Index].Rotation = Rotar;
                ExportArchivo(1);
            }
            else
            {
                @Globals.oDocument2 = (IDMObjects.Document)IDMListView1[IndexTemp].SelectedItem;
                IDMListView2.ClearItems();
                IDMViewerCtrl1[Index].Document = @Globals.oDocument2;
                IDMViewerCtrl1[Index].Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                //ShowAnnotations_Click(ShowAnnotations, new EventArgs());
                DocumentID.Text = @Globals.oDocument2.Name;
                SSPanel2.Visible = true;
                IDMViewerCtrl1[Index].Brightness = (IDMViewerCtrl.idmBrightness)IDMObjects.idmBrightness.idmBrightnessDarker;
                IDMViewerCtrl1[Index].Rotation = Rotar;
                ExportArchivo(2);
            }*/
        }

        // Double click on annotation => advance Viewer to correct page
        private void IDMListView2_DblClick(object sender, EventArgs e)
        {
            //TODO perform click
            MessageBox.Show("Show anotations...." );
            /*IDMObjects.Annotation oAnno = null;
            if (IDMListView2.SelectedItem != null)
            {
                oAnno = (IDMObjects.Annotation)IDMListView2.SelectedItem;
                try
                {
                    //UPGRADE_TODO:Member PageNumber is not defined in type IDMViewerCtrl.IDMViewerCtrl. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1067"'
                    int temppage = int.Parse(oAnno.Properties["F_MULTIPAGETIFFPAGENUMBER"].Value.ToString());
                    try { IDMViewerCtrl1[DocAct].PageNumber = temppage; }
                    catch { }
                }
                catch
                {
                }
            }*/
        }

        private void IDMViewerCtrl1_ClickEvent(object sender, EventArgs e)
        {
            //IDMViewerCtrl1_Click(Array.IndexOf(IDMViewerCtrl1, sender));
        }


        private void IDMViewerCtrl1_Click(int Index)
        {
            DocAct = (byte)Index;
        }

        // Populate the annotations list for selected document
        private void ShowAnnotations_Click(Object eventSender, EventArgs eventArgs)
        {

            //TODO perform click
            MessageBox.Show("Show anotations...." );
            /*
            IDMObjects.ObjectSet oAnnos = null;
            if ((ShowAnnotations.CheckState == CheckState.Checked) && (IDMViewerCtrl1[DocAct].IsOperationSupported(IDMViewerCtrl.idmDocumentOperation.idmOpAnnotations)))
            {
                IDMViewerCtrl1[DocAct].ShowAnnotations = true;
                if (DocAct == 0 || DocAct == 2)
                {
                    if (@Globals.oDocument.GetState(IDMObjects.idmDocState.idmDocAnnotated))
                    {
                        oAnnos = (IDMObjects.ObjectSet)@Globals.oDocument.Annotations;
                        if (oAnnos.Count != 0)
                        {
                            IDMListView2.AddItems(oAnnos, -1);
                        }
                    }
                }
                else
                {
                    if (@Globals.oDocument2.GetState(IDMObjects.idmDocState.idmDocAnnotated))
                    {
                        oAnnos = (IDMObjects.ObjectSet)@Globals.oDocument2.Annotations;
                        if (oAnnos.Count != 0)
                        {
                            IDMListView2.AddItems(oAnnos, -1);
                        }
                    }
                }
                Approve.Enabled = true;
                Approve.Visible = true;
                Reject.Enabled = true;
                Reject.Visible = true;
                AddNote.Enabled = true;
                AddNote.Visible = true;
                Highlight.Enabled = true;
                Highlight.Visible = true;
                IDMListView2.Enabled = true;
                IDMListView2.Visible = true;
                BtnSalvar.Visible = true;

                if (DocAct == 0)
                {
                    viewImage1.Visible = false;
                }
                else if (DocAct == 1)
                {
                    viewImage2.Visible = false;
                }
            }
            else
            {
                IDMViewerCtrl1[DocAct].ShowAnnotations = false;
                IDMListView2.ClearItems();
                Approve.Enabled = false;
                Approve.Visible = false;
                Reject.Enabled = false;
                Reject.Visible = false;
                AddNote.Enabled = false;
                AddNote.Visible = false;
                Highlight.Enabled = false;
                Highlight.Visible = false;
                IDMListView2.Enabled = false;
                IDMListView2.Visible = false;
                BtnSalvar.Visible = false;

                if (DocAct == 0)
                {
                    viewImage1.Visible = true;
                }
                else if (DocAct == 1)
                {
                    viewImage2.Visible = true;
                }
            }*/
        }
        private void ShowAnnotations_CheckStateChanged(Object eventSender, EventArgs eventArgs)
        {
            ShowAnnotations_Click(eventSender, eventArgs);
        }
        // Subroutines for handling annotation creation...
        private void AddNote_Click(Object eventSender, EventArgs eventArgs)
        {
            MessageBox.Show("add note...");
            /*
            IDMObjects.Annotation oAnno = new IDMObjects.Annotation();
            int pg = IDMViewerCtrl1[DocAct].PageNumber;
            if (DocAct == 0 || DocAct == 2)
            {
                try
                {
                    oAnno = (IDMObjects.Annotation)@Globals.oDocument.CreateAnnotation(1, "Text");
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    oAnno = (IDMObjects.Annotation)@Globals.oDocument2.CreateAnnotation(1, "Text");
                }
                catch
                {
                }
            }
            oAnno.Properties["F_LEFT"].Value = 0.5d;
            oAnno.Properties["F_TOP"].Value = 0.5d;
            oAnno.Properties["F_HEIGHT"].Value = 0.5d;
            oAnno.Properties["F_WIDTH"].Value = 1.5d;
            oAnno.Properties["F_FORECOLOR"].Value = ColorTranslator.ToOle(Color.Blue);
            oAnno.Properties["F_BACKCOLOR"].Value = ColorTranslator.ToOle(Color.White);
            oAnno.Properties["F_MULTIPAGETIFFPAGENUMBER"].Value = pg;
            //If oAnno.ShowPropertiesDialog = idmDialogExitCancel Then
            //    oAnno.Delete
            //End If
            oAnno.ShowPropertiesDialog(IDMObjects.idmTabSelect.idmTabSelectAll);
            if (DocAct == 0 || DocAct == 2)
            {
                @Globals.oDocument.Save();
                @Globals.oDocument.Refresh(IDMObjects.idmDocRefreshOptions.idmRefreshAnnotations);
            }
            else
            {
                @Globals.oDocument2.Save();
                @Globals.oDocument2.Refresh(IDMObjects.idmDocRefreshOptions.idmRefreshAnnotations);
            }
            IDMListView2.AddItem(oAnno, -1);
            */
        }
        private void MyCreateStamp(string AnnoText)
        {
            MessageBox.Show("add MyCreateStamp...");

            /*
            IDMObjects.Annotation oAnno = null;
            //UPGRADE_TODO:Member PageNumber is not defined in type IDMViewerCtrl.IDMViewerCtrl. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="vbup1067"'
            int pg = IDMViewerCtrl1[DocAct].PageNumber;
            if (DocAct == 0 || DocAct == 2)
            {
                oAnno = (IDMObjects.Annotation)@Globals.oDocument.CreateAnnotation(pg, "Stamp");
                oAnno.Properties["F_TEXT"].Value = AnnoText;
                oAnno.Properties["F_HASBORDER"].Value = true;
                @Globals.oDocument.Save();
                @Globals.oDocument.Refresh(IDMObjects.idmDocRefreshOptions.idmRefreshAnnotations);
            }
            else
            {
                oAnno = (IDMObjects.Annotation)@Globals.oDocument2.CreateAnnotation(pg, "Stamp");
                oAnno.Properties["F_TEXT"].Value = AnnoText;
                oAnno.Properties["F_HASBORDER"].Value = true;
                @Globals.oDocument2.Save();
                @Globals.oDocument2.Refresh(IDMObjects.idmDocRefreshOptions.idmRefreshAnnotations);
            }
            IDMListView2.AddItem(oAnno, -1);
            */
        }

        private void Highlight_Click(Object eventSender, EventArgs eventArgs)
        {
            //IDMViewerCtrl1[DocAct].LeftButtonAction = IDMViewerCtrl.idmAction.idmActionHighlight;
            //IDMViewerCtrl1[DocAct].Document.Save();
            MessageBox.Show("Save...");
        }

        private void Reject_Click(Object eventSender, EventArgs eventArgs)
        {
            MyCreateStamp("Cacelado");
        }

        private void Approve_Click(Object eventSender, EventArgs eventArgs)
        {
            MyCreateStamp("Aprobar");
        }

        private void SSTab1_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
        {
            int i = SSTab1.SelectedIndex;
            ShowAnnotations.Enabled = true;
            //IDMListView2.ClearItems();
            switch (i)
            {
                case 1:
                //    IDMListView1[0].Visible = false;
                  //  IDMListView1[1].Visible = true;
                    DocAct = (byte)SSTab1.SelectedIndex;
                    //ShowAnnotations.CheckState = CheckState.Checked;
                    //ShowAnnotations_Click(ShowAnnotations, new EventArgs());
                    break;
                case 0:
                    //IDMListView1[0].Visible = true;
                    //IDMListView1[1].Visible = false;
                    DocAct = (byte)SSTab1.SelectedIndex;
                    //IDMListView2.ClearItems();
                    //ShowAnnotations.CheckState = CheckState.Checked;
                    //ShowAnnotations_Click(ShowAnnotations, new EventArgs());
                    break;
                default:
                    //IDMListView1[0].Visible = false;
                    //IDMListView1[1].Visible = false;
                    DocAct = (byte)SSTab1.SelectedIndex;
                    ShowAnnotations.CheckState = CheckState.Unchecked;
                    ShowAnnotations.Enabled = false;
                    break;
            }
        }

        private void TxtCriterio_TextChanged(Object eventSender, EventArgs eventArgs)
        {
            double dbNumericTemp = 0;
            if (!Double.TryParse(TxtCriterio[Array.IndexOf(TxtCriterio, eventSender)].Text, NumberStyles.Number, CultureInfo.CurrentCulture.NumberFormat, out dbNumericTemp) && Strings.Len(TxtCriterio[Array.IndexOf(TxtCriterio, eventSender)].Text) > 0)
            {
                MessageBox.Show(this, "Debe escribir Números  " + TxtCriterio[Array.IndexOf(TxtCriterio, eventSender)].Text, "SRDC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtCriterio[Array.IndexOf(TxtCriterio, eventSender)].Text = String.Empty;
            }
        }

        private void TxtCriterio_Enter(Object eventSender, EventArgs eventArgs)
        {
            TxtCriterio[Array.IndexOf(TxtCriterio, eventSender)].SelectionStart = 0;
            TxtCriterio[Array.IndexOf(TxtCriterio, eventSender)].SelectionLength = (int)TxtCriterio[Array.IndexOf(TxtCriterio, eventSender)].Text.Length;
        }
        // Handle the logon, catch any errors here
        private void MyLogon(String oLibraryName)
        {
            try
            { // Enable error-handling routine.
                /*
                if (!(oLibrary.GetState(IDMObjects.idmLibraryState.idmLibraryLoggedOn)))
                {
                    //Module1.ObtPassSapuf();
                    if (@Globals.Pass_Sapuf.Trim().Length > 0)
                    {
                        oLibrary.Logon("c406_090", @Globals.Pass_Sapuf.Trim(), "", (IDMObjects.idmLibraryLogon)@Globals.dmLogonOptNoUI);
                        @Globals.gbISLogOff = true;
                    }
                }*/
                oLibrary = ceConnection.FetchOS(@Globals.gfSettings.txtIMSLibName.Text);
            }
            catch 
            {
                //MessageBox.Show(this, "Error en logon a librería", Application.ProductName);
               // @Globals.gbISLogOff = false;
               // @Globals.fncParmIniSet("UOCFileNet", "Execute", "4", DirWinTemp + "UOCFileNet.ini");
               // @Globals.fncParmIniSet("Error", "ErrNumber", "4", DirWinTemp + "UOCFileNet.ini");
                //@Globals.fncParmIniSet("Error", "DescError", "Error en logon a librería", DirWinTemp + "UOCFileNet.ini");
                //this.Close();
                //Environment.Exit(0);
            }
        }

        private void Llena_Paramatros(int opc)
        {
            int Temp1 = 0;
            int Temp2 = 0;

            if (Strings.Len(@Globals.CommandLine.ToString().Trim()) > 0)
            {
                //MessageBox.Show(this, @Globals.CommandLine.ToString().Trim(), Application.ProductName);
                switch (opc)
                {
                    case 1:
                        if (@Globals.CommandLine.ToString().IndexOf('{') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('{') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('}', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.Pass_Sapuf = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                                if (Temp1 > 2)
                                {
                                    @Globals.CommandLine = Strings.Mid(@Globals.CommandLine.ToString(), 1, Temp1 - 1);
                                }
                                else
                                {
                                    @Globals.CommandLine = Strings.Mid(@Globals.CommandLine.ToString(), Temp2 + 1, @Globals.CommandLine.Length - Temp2 );
                                }
                            }

                            //MessageBox.Show(this, @Globals.Pass_Sapuf, Application.ProductName);
                        }

                        if (@Globals.CommandLine.ToString().IndexOf('I') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('I') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('i', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.VarCom = Int32.Parse(Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1));
                            }
                            //MessageBox.Show(this, @Globals.VarCom.ToString(), Application.ProductName);
                        }

                        break;

                    default:
                        if (@Globals.CommandLine.ToString().IndexOf('U') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('U') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('u') + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.UOC = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }

                            //MessageBox.Show(this, @Globals.UOC, Application.ProductName);
                        }
                        if (@Globals.CommandLine.ToString().IndexOf('¡') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('¡') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('!') + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {

                                @Globals.UOC1 = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }

                            //MessageBox.Show(this, @Globals.UOC1, Application.ProductName);
                        }

                        if (@Globals.CommandLine.ToString().IndexOf('C') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('C') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('c', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                TxtCriterio[0].Text = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }

                            //MessageBox.Show(this, TxtCriterio[0].Text, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('F') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('F') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('f', Temp1) + 1);
                            TxtCriterio[1].Text = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.XFolio = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }

                            //MessageBox.Show(this, @Globals.XFolio, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('¿') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('¿') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('?', Temp1) + 1);
                            TxtCriterio[5].Text = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.XFolio2 = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }

                            //MessageBox.Show(this, @Globals.XFolio2, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('T') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('T') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('t', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                TxtCriterio[2].Text = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }

                            //MessageBox.Show(this, TxtCriterio[2].Text, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('L') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('L') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('l', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {

                                TxtCriterio[3].Text = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                            //MessageBox.Show(this, TxtCriterio[3].Text, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('S') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('S') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('s', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                TxtCriterio[4].Text = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                                @Globals.XFolioS403 = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                        }
                        //XProd, Xinst, XFile, XCalifOnd, XFechaOp
                        if (@Globals.CommandLine.ToString().IndexOf('P') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('P') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('p', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {

                                @Globals.XProd = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                            //MessageBox.Show(this, @Globals.XProd, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('[') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('[') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf(']', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.XInst = Conversion.Str(Conversion.Val(Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1)));
                            }
                            //MessageBox.Show(this, @Globals.XInst, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('X') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('X') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('x', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.XFile = Conversion.Str(Conversion.Val(Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1)));
                            }
                            //MessageBox.Show(this, @Globals.XFile, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('O') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('O') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('o', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.XCalifOnd = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                            //MessageBox.Show(this, @Globals.XCalifOnd, Application.ProductName);

                        }
                        if (@Globals.CommandLine.ToString().IndexOf('H') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('H') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('h', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.XFechaOp = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                            //MessageBox.Show(this, @Globals.XFechaOp, Application.ProductName);
                        }
                        if (@Globals.CommandLine.ToString().IndexOf('@') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('@') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('#', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.TipoDoc = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                            //MessageBox.Show(this, @Globals.TipoDoc, Application.ProductName);
                        }
                        //AVG Ini Sept-2015
                        if (@Globals.CommandLine.ToString().IndexOf('A') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('A') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('a', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.SubFol1 = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                            TxtSubFol1.Text = @Globals.SubFol1;
                        }
                        if (@Globals.CommandLine.ToString().IndexOf('Z') >= 0)
                        {
                            Temp1 = (@Globals.CommandLine.ToString().IndexOf('Z') + 1);
                            Temp2 = (@Globals.CommandLine.ToString().IndexOf('z', Temp1) + 1);
                            if (Temp1 > 0 && Temp2 > 0)
                            {
                                @Globals.SubFol2 = Strings.Mid(@Globals.CommandLine.ToString(), Temp1 + 1, (Temp2 - Temp1) - 1);
                            }
                            TxtSubFol2.Text = @Globals.SubFol2;
                        }
                        //AVG Fin Sept-2015

                        break;
                } //End Case
            }

        }


        private object Llena_UOCs()
        {
            string REGISTROACTUAL = String.Empty;

            string Archivo = @Globals.DirConf + "UOCs.ini";
            if (File.Exists(Archivo))
            {
                FileSystem.FileOpen(1, Archivo, OpenMode.Input, OpenAccess.Default, OpenShare.Default, -1);
                _CboUoc_0.Items.Clear();
                _CboUoc_1.Items.Clear();
                while (!FileSystem.EOF(1))
                {
                    REGISTROACTUAL = FileSystem.LineInput(1);
                    _CboUoc_0.Items.Add(REGISTROACTUAL);
                    _CboUoc_1.Items.Add(REGISTROACTUAL);
                }
                FileSystem.FileClose(1);
            }
            return null;
        }

        //AIS-867 ebonilla
        /*static int counter = 0;
        public static void Mostrar(String args)
        {
            Thread thr = new Thread(new ThreadStart(delegate { doRun(args, ++counter);} ));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
        }
        static void doRun(String args, int cntr)
        {
         
            AppDomain domain = AppDomain.CreateDomain("FrmFileNET" + cntr);
            try
            {
            Type t = typeof(FrmFileNET);
            FrmFileNET proxy = (FrmFileNET)domain.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName);
            proxy.setData(args);
            proxy.Init();
            proxy.ShowDialog();
            }
            catch (ExitEnvironmentException ex)
            {
                if (m_vb6FormDefInstance != null)
                {
                    m_vb6FormDefInstance = null;
                }
            }
            catch (Exception e)
            {
                if (m_vb6FormDefInstance != null)
                {
                    m_vb6FormDefInstance = null;
                }
            }
            AppDomain.Unload(domain);
        }
          
        public void setData(string args)
        {
            @Globals.CommandLine = args;
        }

        public void Init()
        {
           FrmFileNET frm = FrmFileNET.DefInstance;
        }*/

        [STAThread]
        static void Main(string [] ARGS)
        {

            //AVG Ini 14-01/2010
            @Globals.ValidaRegistry("C406_000", "DirWork", "%ALLUSERSPROFILE%\\Application Data\\C406_000\\");
            @Globals.DirWork = @Globals.LeeRegistry("C406_000", "DirWork");
            @Globals.ValidaRegistry("C406_000", "DirLog", "Logs\\");
            @Globals.DirLog = @Globals.DirWork + @Globals.LeeRegistry("C406_000", "DirLog");
            @Globals.ValidaRegistry("C406_000", "DirConf", "Conf\\");
            @Globals.DirConf = @Globals.DirWork + @Globals.LeeRegistry("C406_000", "DirConf");
            @Globals.ValidaRegistry("C406_000", "TmpImg", "TmpImg\\");
            @Globals.TmpImg = @Globals.DirWork + @Globals.LeeRegistry("C406_000", "TmpImg");
            //AVG Ini 14-01/2010

            Application.Run(FrmFileNET.DefInstance);
            //FrmFileNET.DefInstance.Show();
        }

        private void FrmFileNET_Activated(object sender, EventArgs e)
        {
            if (@Globals.VarCom == 7) // Se agrega
            {
                this.Visible = false;
                this.Hide();

            }
        }

        private void ExportArchivo(byte opc)
        {

            string Cade1 = String.Empty;
            string Cade = String.Empty;
            string cade2 = String.Empty;
            string XtipDoc = String.Empty;
            byte PosPunto = 0;
            string sClass = "ExpedientesDC";
            string[] sClasses = new string[2];
            sClasses[0] = sClass;
            IPropertyDescriptionList oPropDescs = null;
            oPropDescs=ceConnection.getPropertiesDescriptions(oLibrary, sClasses);
            //oPropDescs = (IDMObjects.PropertyDescriptions)@Globals.oLibrary.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses);

            if (opc == 1)
            {
                //Cade = @Globals.oDocument.GetCachedFile(0, "", null);
                MessageBox.Show("Get Cached file...");
            }
            else
            {
                //Cade = @Globals.oDocument2.GetCachedFile(0, "", null);
                MessageBox.Show("Get Cached file2...");
            }
            cade2 = Cade;
            Cade1 = @Globals.GetFileName(ref cade2);
            PosPunto = (byte)Cade1.IndexOf(".FOB");
            //XtipDoc = @Globals.oDocument.Properties[oPropDescs["TipoDoc"].Name].Value.ToString();
            //Cade1 = @Globals.TmpImg + Cade1.Substring(0, Math.Min(Cade1.Length, PosPunto)) + "-" + XtipDoc.Trim() + ".tif";            
            Cade1 = @Globals.TmpImg + "VisalImg" + opc.ToString() + ".tmp";
            if (File.Exists(Cade1))
            {
                try
                {
                    File.Delete(Cade1);
                }
                catch { }
            }
            // Copia el archivo de cache a Ubicacion de trabajo
            try
            {
                File.Copy(Cade, Cade1, true);
                File.SetAttributes(Cade1, FileAttributes.Normal);
            }
            catch { }

           /* if (opc == 1)
            {
                viewImage1.CloseDocument();
                viewImage1.pArchivo = Cade1;
                viewImage1.LoadDocument();
            }
            else
            {
                viewImage2.CloseDocument();
                viewImage2.pArchivo = Cade1;
                viewImage2.LoadDocument();
            }*/
        }

        private void ShowAnnotations_CheckedChanged(object sender, EventArgs e)
        {

        }

        static private int KillFile(ref  string sFileSpec)
        {
            int result = 0;

            string sFileName = String.Empty;
            string sDirName = String.Empty;
            string Msg = String.Empty;
            DialogResult iResult = (DialogResult)0;
            try
            {
                sDirName = sParsePath(sFileSpec);
                sFileName = FileSystem.Dir(sFileSpec, Microsoft.VisualBasic.FileAttribute.Normal);

                while (!string.IsNullOrEmpty(sFileName))
                {
                    try
                    {
                        File.Delete(sDirName + sFileName);
                        sFileName = FileSystem.Dir(sFileSpec, FileAttribute.Normal);
                    }
                    catch
                    {
                        sFileName = string.Empty;
                    }

                };

                return -1;
            }
            catch
            {
                switch (Information.Err().Number)
                {
                    case 53:
                    case 70:
                        Msg = "Disco protegido contra escritura. Desprotéjalo para poder borrar.";
                        MessageBox.Show(Msg, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception("'Resume' not supported");
                        break;
                    case 75:
                        (new FileInfo(sDirName + sFileName)).Attributes = 0;
                        throw new Exception("'Resume' not supported");
                        break;
                    default:
                        iResult = MessageBox.Show("Error: [" + Conversion.ErrorToString(0) + "]", "Atención", MessageBoxButtons.OK | MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        result = 0;
                        break;
                }
            }
            return result;
        }

        static private string sParsePath(string sPathIn)
        {

            int i = 0;

            for (i = sPathIn.Length; i >= 1; i--)
            {
                if ((":\\").IndexOf(sPathIn[i - 1].ToString()) >= 0)
                {
                    break;
                }
            }
            return sPathIn.Substring(0, Math.Min(sPathIn.Length, i));

        }

        private void SPCont2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}