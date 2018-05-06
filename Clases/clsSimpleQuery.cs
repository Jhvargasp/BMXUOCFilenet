using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace UOCFilenet
{
    internal class clsSimpleQuery
    {

        // This class is useful for generating background document
        // queries where there isn't a need for using one of the
        // FNQuery ActiveX controls.  This class encapsulates all the
        // ADO details while providing control over the filter
        // conditions in the query.

        // Instructions for use:
        //    1.  Call BindToLib passing a Library object and a
        //        collection of  headings you want to see in the
        //        IDMListView.  An empty collection implies that no
        //        column headings will be displayed.
        //    2.  Call ExecQuery, passing in the where clause, the
        //        folder constraints, the max number of rows, and
        //        the IDMListView control you want to populate.  A
        //        reminder on the where clause - literal string values
        //        must be bracketed with quotes, e.g. AccountName = 'Bruce'


        private ADODB.Recordset oRS = null;
        //AIS-469 FGUEVARA
        //private ADODB.Connection oMiBD = null;
        private ADODB.Command CmdEjec = new ADODB.Command();
        private string sConnect = String.Empty;
        private string sQuery = String.Empty;
        private IDMObjects.Library oQueryLib = null;
        private IDMObjects.PropertyDescriptions oPropDescs = null;
        private Collection cColHeadings = new Collection();
        // If we keep the library as a global variable, we can
        // cache data like property descriptions and column headings
        public void BindToLib(IDMObjects.Library oNewLib, Collection pColHeadings, string sClass)
        {
            string[] sClasses = new string[2];

            sClasses[0] = sClass;
            oQueryLib = oNewLib;
            oPropDescs = (IDMObjects.PropertyDescriptions)oQueryLib.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses);
            foreach (string oTmp in pColHeadings)
            {
                // Weed out any bogus labels the caller passed us
                try
                {
                    if (oPropDescs[oTmp] != null)
                    {
                        cColHeadings.Add(oTmp, null, null, null);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("On Error Resume Next not handled propertly: " + e.Message);
                }
            }
        }

        public void UpdateQuery(IDMObjects.Library oNewLib, string sClass, AxIDMListView.AxIDMListView IDMLView)
        {
            string[] sClasses = new string[2];
            //IDMObjects.PropertyDescription PropDesc = null;
            sClasses[0] = sClass;
            bool Salvar = false;
            //string DirWinTemp = "C:\\APPS\\CreditoEmpresarial\\";
            string DirWinTemp = @Globals.DirLog; 
            oQueryLib = oNewLib;
            oPropDescs = (IDMObjects.PropertyDescriptions)oQueryLib.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses);
            if (IDMLView.CountItems() == 0)
            {
                @Globals.fncParmIniSet("UOCFileNet", "Execute", "5", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Error", "ErrNumber", "5", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Error", "DescError", "Error No hay Imágenes con esos parámetros", DirWinTemp + "UOCFileNet.ini");
                @Globals.fncParmIniSet("Cadena", "Cadena", Interaction.Command().Trim(), DirWinTemp + "UOCFileNet.ini");
                return;
            }
            for (int i = 1; i <= IDMLView.CountItems(); i++)
            {
                IDMLView.SelectItem(i);
                @Globals.oDocument = (IDMObjects.Document)IDMLView.SelectedItem;
                switch (@Globals.VarCom)
                {
                    case 1:
                        if (!oPropDescs["F_PAGES"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            @Globals.oDocument.Properties[oPropDescs["F_PAGES"].Name].Value = @Globals.Pag;
                            Salvar = true;
                        }

                        break;
                    case 2:
                        if (!oPropDescs["NumCliente"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (FrmFileNET.DefInstance.TxtCriterio[0].Text.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["NumCliente"].Name].Value = FrmFileNET.DefInstance.TxtCriterio[0].Text;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["Contrato"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (FrmFileNET.DefInstance.TxtCriterio[2].Text.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["Contrato"].Name].Value = FrmFileNET.DefInstance.TxtCriterio[2].Text;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["Linea"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (FrmFileNET.DefInstance.TxtCriterio[3].Text.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["Linea"].Name].Value = FrmFileNET.DefInstance.TxtCriterio[3].Text;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["FolioS403"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            @Globals.oDocument.Properties[oPropDescs["FolioS403"].Name].Value = @Globals.XFolioS403;
                            Salvar = true;
                        }
                        if (!oPropDescs["CalificaOnDemand"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            @Globals.oDocument.Properties[oPropDescs["CalificaOnDemand"].Name].Value = 0;
                            @Globals.oDocument.Properties[oPropDescs["Status"].Name].Value = 1;
                            Salvar = true;
                        }
                        //Set CmdEjec = New ADODB.Command 
                        //Set CmdEjec.ActiveConnection = oMiBD 
                        //sQuery1 = "UPDATE FnDocument SET Cliente = '1' WHERE Folio='" & FrmFileNET.TxtCriterio(1) & "'" 
                        //CmdEjec.CommandText = sQuery1 
                        //CmdEjec.Execute , , adCmdText 
                        //oMiBD.Execute sQuery1, , adCmdText 
                        //CmdEjec.Execute 
                        //oRS!contrato = "1" 
                        //oRS.Update 
                        //Tampoco sirve con la siguiente sintaxis 
                        //oRS.Update oRS!contrato, 1 
                        break;
                    case 3:
                    case 6:
                        if (!oPropDescs["CalificaOnDemand"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (@Globals.XCalifOnd.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["CalificaOnDemand"].Name].Value = @Globals.XCalifOnd;
                                @Globals.oDocument.Properties[oPropDescs["Status"].Name].Value = @Globals.XCalifOnd;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["FechaOperacion"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (@Globals.XFechaOp.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["FechaOperacion"].Name].Value = @Globals.XFechaOp;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["Instrumento"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (@Globals.XInst.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["Instrumento"].Name].Value = @Globals.XInst;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["Producto"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (@Globals.XProd.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["Producto"].Name].Value = @Globals.XProd;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["FolioS403"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (@Globals.XFolioS403.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["FolioS403"].Name].Value = @Globals.XFolioS403;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["NumCliente"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (FrmFileNET.DefInstance.TxtCriterio[0].Text.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["NumCliente"].Name].Value = FrmFileNET.DefInstance.TxtCriterio[0].Text;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["Contrato"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (FrmFileNET.DefInstance.TxtCriterio[2].Text.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["Contrato"].Name].Value = FrmFileNET.DefInstance.TxtCriterio[2].Text;
                                Salvar = true;
                            }
                        }
                        if (!oPropDescs["Linea"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (FrmFileNET.DefInstance.TxtCriterio[3].Text.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["Linea"].Name].Value = FrmFileNET.DefInstance.TxtCriterio[3].Text;
                                Salvar = true;
                            }
                        }
                        if (Double.Parse(@Globals.TipoDoc) != 999)
                        {
                            if (!oPropDescs["TipoDoc"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                            {
                                if (Conversion.Val(@Globals.TipoDoc) > 0)
                                {
                                    @Globals.oDocument.Properties[oPropDescs["TipoDoc"].Name].Value = @Globals.TipoDoc;
                                    Salvar = true;
                                }
                            }
                        }
                        if (!oPropDescs["XfolioS"].GetState(IDMObjects.idmPropDescState.idmPropReadOnly))
                        {
                            if (@Globals.XFile.Length > 0)
                            {
                                @Globals.oDocument.Properties[oPropDescs["XfolioS"].Name].Value = Conversion.Str(@Globals.XFile);
                                Salvar = true;
                            }
                            else
                            {
                                Salvar = false;
                            }
                        }
                        if (Salvar)
                        {
                            @Globals.oDocument.Permissions[1].GranteeName = "SicUsrG:CredEmp:Banamex"; //Read
                            @Globals.oDocument.Permissions[2].GranteeName = "OperatorG:CredEmp:Banamex"; //Write
                            @Globals.oDocument.Permissions[3].GranteeName = "OperatorG:CredEmp:Banamex"; //AccessAX
                        }

                        break;
                }
                if (Salvar)
                {
                    @Globals.oDocument.Save();
                    if (@Globals.VarCom == 3 || @Globals.VarCom == 6)
                    {
                        @Globals.fncParmIniSet("UOCFileNet", "Execute", "1", DirWinTemp + "UOCFileNet.ini");
                    }
                }
            }
            if (Salvar)
            {
                @Globals.oDocument.Refresh(IDMObjects.idmDocRefreshOptions.idmRefreshAll);
                oRS.Requery(-1);
            }
        }

        // Private subroutine for building up IDMListView
        private void ShowResults(AxIDMListView.AxIDMListView IDMLView)
        {
            bool OnErrorResumeNext = false;
            double VarPaso = 0;
            // Do basic IDMLView initialization
            IDMLView.DefaultLibrary = oQueryLib;
            IDMLView.ClearItems();
            if (cColHeadings.Count > 0)
            {
                IDMLView.ClearColumnHeaders(oQueryLib);
                try
                {
                    OnErrorResumeNext = true;
                    if (cColHeadings != null)
                    {
                        foreach (string oTmp in cColHeadings)
                        {
                            IDMLView.AddColumnHeader(oQueryLib, oPropDescs[oTmp]);
                        }
                    }
                    IDMLView.SwitchColumnHeaders(oQueryLib);
                    IDMLView.View = IDMListView.idmView.idmViewReport;
                }
                catch (Exception e)
                {
                    throw new Exception("On Error Resume Next not handled propertly: " + e.Message);
                }
            }
            else
            {
                IDMLView.View = IDMListView.idmView.idmViewList;
            }
            // Now for the easy part - slam in the actual items
            if (oRS.RecordCount > 0)
            {
                IDMLView.AddItems(oRS.Fields["ObjSet"].Value, 1);
            }
            else
            {
                if (!OnErrorResumeNext)
                    throw new Exception((Constants.vbObjectError + 27).ToString() + ", UOCFileNet, " + null + ", " + null + ", " + null);

                if (@Globals.VarCom != 2 && @Globals.VarCom != 3 && @Globals.VarCom != 6 && @Globals.VarCom != 8 && @Globals.VarCom != 9 && @Globals.VarCom != 10)
                {
                    if (MessageBox.Show("No se encuentra el documento digitalizado,Deseas Buscarlo en Ondemand", "Buscar en Ondemand", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if ((((Conversion.Val(FrmFileNET.DefInstance.TxtCriterio[0].Text) > 0 || Conversion.Val(FrmFileNET.DefInstance.TxtCriterio[1].Text) > 0) ? -1 : 0) | ((int)Conversion.Val(FrmFileNET.DefInstance.TxtCriterio[2].Text))) != 0)
                        {
                            try
                            {
                                @Globals.XFolio = "!" + Conversion.Val(FrmFileNET.DefInstance.TxtCriterio[0].Text).ToString() + "¡@" + Conversion.Val(FrmFileNET.DefInstance.TxtCriterio[2].Text).ToString() + "%[" + Conversion.Val(FrmFileNET.DefInstance.CboUoc[0].Text).ToString() + Conversion.Str(FrmFileNET.DefInstance.TxtCriterio[1].Text).Trim() + "]";
                                ProcessStartInfo startInfo = new ProcessStartInfo(Path.GetDirectoryName(Application.ExecutablePath) + "\\VisualImg.exe " + @Globals.XFolio);
                                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                                VarPaso = Process.Start(startInfo).Id;
                            }
                            catch (Exception f)
                            {
                                if (!OnErrorResumeNext)
                                    throw f;
                            }
                        }
                    }
                }
                //End
            }

        }

        // Executes query using passed params, places results in
        // passed IDMListView control
        // Calls must be preceded by a BindToLib
        public void ExecQuery(ref  AxIDMListView.AxIDMListView IDMLView, string sWhereClause, string sFolderName, int iMaxRows)
        {

            if (oQueryLib != null)
            {
                // Build the string necessary to bind to the database connection
                sConnect = "provider=FnDBProvider;data source=" + oQueryLib.Name + ";Prompt=4;SystemType=" + ((int)oQueryLib.SystemType) + ";";
                // Build the query string

                sQuery = "SELECT * FROM FnDocument ";
                if (sWhereClause.Length > 0)
                {
                    sQuery = sQuery + "WHERE " + sWhereClause;
                }

                // Set up the properties on the record set
                if (oRS != null)
                {
                    oRS = null;
                }
                //Set oMiBD = New ADODB.Connection
                //oMiBD.ConnectionString = sConnect
                //oMiBD.Open
                oRS = new ADODB.Recordset();

                oRS.let_ActiveConnection(sConnect);
                oRS.Properties["SupportsObjSet"].Value = true;
                if (iMaxRows > 0)
                {
                    oRS.MaxRecords = iMaxRows;
                }
                oRS.Properties["SearchFolderName"].Value = sFolderName;
                // All set up - pull the trigger
                oRS.LockType = ADODB.LockTypeEnum.adLockOptimistic;
                //oRS.Open sQuery, oMiBD, adOpenKeyset, , adCmdText
                //oRS.Open sQuery, oMiBD, adOpenKeyset
                oRS.Open(sQuery, Type.Missing, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockUnspecified, -1);
                ShowResults(IDMLView);
            }
            else
            {
                MessageBox.Show("Must set library!", Application.ProductName);
            }
        }
    }
}