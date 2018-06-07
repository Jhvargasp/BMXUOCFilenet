using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using static FileNet.Api.Core.Factory;
using FileNet.Api.Core;
using FileNet.Api.Constants;
using FileNet.Api.Property;
using FileNet.Api.Meta;
using FileNet.Api.Query;
using FileNet.Api.Collection;
using System.Collections;

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


        //private ADODB.Recordset oRS = null;
        IRepositoryRowSet oRS = null;
        //AIS-469 FGUEVARA
        //private ADODB.Connection oMiBD = null;
        private ADODB.Command CmdEjec = new ADODB.Command();
        private string sConnect = String.Empty;
        private string sQuery = String.Empty;
        //private IDMObjects.Library oQueryLib = null;

        //private IDMObjects.PropertyDescriptions oPropDescs = null;
        private FileNet.Api.Collection.IPropertyDescriptionList oPropDescs = null;
        private Collection cColHeadings = new Collection();
        // If we keep the library as a global variable, we can
        // cache data like property descriptions and column headings
        public void BindToLib(IObjectStore objObjectStore, Collection pColHeadings, string sClass)
        {
            string[] sClasses = new string[2];
            IClassDescription objClassDesc = ClassDescription.FetchInstance(objObjectStore, sClass, null);
            oPropDescs = objClassDesc.PropertyDescriptions;
            foreach (string oTmp in pColHeadings)
            {
                // Weed out any bogus labels the caller passed us
                try
                {
                    if (oPropDescs.Contains(oTmp))
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

        public void UpdateQuery(IObjectStore objObjectStore, string sClass, DataGridView IDMLView) //AxIDMListView.AxIDMListView
        {
            string[] sClasses = new string[2];
            //IDMObjects.PropertyDescription PropDesc = null;
            sClasses[0] = sClass;
            bool Salvar = false;
            //string DirWinTemp = "C:\\APPS\\CreditoEmpresarial\\";
            string DirWinTemp = @Globals.DirLog;
            //oQueryLib = oNewLib;
            //oPropDescs = (IDMObjects.PropertyDescriptions)oQueryLib.FilterPropertyDescriptions(IDMObjects.idmObjectType.idmObjTypeDocument, sClasses);
            IClassDescription objClassDesc = ClassDescription.FetchInstance(objObjectStore, sClass, null);
            oPropDescs = objClassDesc.PropertyDescriptions;

            if (IDMLView.RowCount == 0)
            {
                //@Globals.fncParmIniSet("UOCFileNet", "Execute", "5", DirWinTemp + "UOCFileNet.ini");
                //@Globals.fncParmIniSet("Error", "ErrNumber", "5", DirWinTemp + "UOCFileNet.ini");
                //@Globals.fncParmIniSet("Error", "DescError", "Error No hay Imágenes con esos parámetros", DirWinTemp + "UOCFileNet.ini");
                //@Globals.fncParmIniSet("Cadena", "Cadena", Interaction.Command().Trim(), DirWinTemp + "UOCFileNet.ini");
                MessageBox.Show("Error No hay Imágenes con esos parámetros");
                return;
            }
            for (int i = 1; i <= IDMLView.RowCount; i++)
            {
              //  IDMLView.SelectItem(i);
                //TODO validate with Filenet
                @Globals.oDocument = (IDocument)objObjectStore.FetchObject("Document", (String)IDMLView.Rows[i].Cells[0].Value,null);
                switch (@Globals.VarCom)
                {
                    case 1:
                        String pName = "F_PAGES";
                        IPropertyDescription propertyDescription = getPropertyDescriptionByName(oPropDescs,pName);
                        if (propertyDescription.IsReadOnly==false)
                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue( @Globals.Pag);
                            Salvar = true;
                        }

                        break;
                    case 2:
                         pName = "NumCliente";
                        if (FrmFileNET.DefInstance.TxtCriterio[0].Text.Length > 0)
                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(FrmFileNET.DefInstance.TxtCriterio[0].Text);
                            Salvar = true;
                        }


                        pName = "Contrato";
                        if (FrmFileNET.DefInstance.TxtCriterio[2].Text.Length > 0)
                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(FrmFileNET.DefInstance.TxtCriterio[2].Text);
                            Salvar = true;
                        }

                        pName = "Linea";
                        if (FrmFileNET.DefInstance.TxtCriterio[3].Text.Length > 0)
                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(FrmFileNET.DefInstance.TxtCriterio[3].Text);
                            Salvar = true;
                        }
                        
                        pName = "FolioS403";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(@Globals.XFolioS403);
                            Salvar = true;
                        }

                        pName = "CalificaOnDemand";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(0);
                            @Globals.oDocument.Properties.FindProperty("Status").SetObjectValue(1);
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
                        pName = "CalificaOnDemand";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && @Globals.XCalifOnd.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(@Globals.XCalifOnd);
                            @Globals.oDocument.Properties.FindProperty("Status").SetObjectValue((@Globals.XCalifOnd));
                            Salvar = true;
                        }


                        pName = "FechaOperacion";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && @Globals.XFechaOp.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(@Globals.XFechaOp);
                            Salvar = true;
                        }


                        pName = "Instrumento";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && @Globals.XInst.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(@Globals.XInst);
                            Salvar = true;
                        }

                                               
                        pName = "Producto";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && @Globals.XProd.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(@Globals.XProd);
                            Salvar = true;
                        }

                        pName = "FolioS403";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && @Globals.XFolioS403.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(@Globals.XFolioS403);
                            Salvar = true;
                        }

                        pName = "NumCliente";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && FrmFileNET.DefInstance.TxtCriterio[0].Text.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(FrmFileNET.DefInstance.TxtCriterio[0].Text);
                            Salvar = true;
                        }
                        
                        pName = "Contrato";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && FrmFileNET.DefInstance.TxtCriterio[2].Text.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(FrmFileNET.DefInstance.TxtCriterio[2].Text);
                            Salvar = true;
                        }

                        pName = "Linea";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && FrmFileNET.DefInstance.TxtCriterio[3].Text.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(FrmFileNET.DefInstance.TxtCriterio[3].Text);
                            Salvar = true;
                        }

                        if (Double.Parse(@Globals.TipoDoc) != 999)
                        {
                            pName = "TipoDoc";
                            propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                            if (propertyDescription.IsReadOnly == false && Conversion.Val(@Globals.TipoDoc) > 0)

                            {
                                @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(@Globals.TipoDoc);
                                Salvar = true;
                            }

                        }
                       
                        pName = "XfolioS";
                        propertyDescription = getPropertyDescriptionByName(oPropDescs, pName);
                        if (propertyDescription.IsReadOnly == false && @Globals.XFile.Length > 0)

                        {
                            @Globals.oDocument.Properties.FindProperty(pName).SetObjectValue(Conversion.Str(@Globals.XFile));
                            Salvar = true;
                        }

                        if (Salvar)
                        {
                            //TODO set security
                            //@Globals.oDocument.Permissions[1].GranteeName = "SicUsrG:CredEmp:Banamex"; //Read
                            //@Globals.oDocument.Permissions[2].GranteeName = "OperatorG:CredEmp:Banamex"; //Write
                            //@Globals.oDocument.Permissions[3].GranteeName = "OperatorG:CredEmp:Banamex"; //AccessAX
                        }

                        break;
                }
                if (Salvar)
                {
                    @Globals.oDocument.Save(RefreshMode.REFRESH);
                    if (@Globals.VarCom == 3 || @Globals.VarCom == 6)
                    {
                        @Globals.fncParmIniSet("UOCFileNet", "Execute", "1", DirWinTemp + "UOCFileNet.ini");
                    }
                }
            }
            if (Salvar)
            {
                @Globals.oDocument.Refresh();
                //oRS.Requery(-1);
            }
        }

        private IPropertyDescription getPropertyDescriptionByName(IPropertyDescriptionList oPropDescs, string pName)
        {
            IEnumerator itr = oPropDescs.GetEnumerator ();
            while (itr.MoveNext())
            {
                IPropertyDescription pds = (IPropertyDescription)itr.Current;
                if (pds.Name == pName)
                {
                    return pds;
                }
            }
            return null;

        }

        // Private subroutine for building up IDMListView
        private void ShowResults(ref DataGridView IDMLView) //AxIDMListView.AxIDMListView
        {
            bool OnErrorResumeNext = false;
            double VarPaso = 0;
            // Do basic IDMLView initialization
            //TODO validate AxIDMListView with Filenet
            //IDMLView.DefaultLibrary = oQueryLib;
            IDMLView.Rows.Clear();
            if (cColHeadings.Count > 0)
            {
                //IDMLView.ClearColumnHeaders(oQueryLib);
                try
                {
                    OnErrorResumeNext = true;
                    if (cColHeadings != null)
                    {
                        foreach (string oTmp in cColHeadings)
                        {
                            //IDMLView.AddColumnHeader(oQueryLib, oPropDescs[oTmp]);
                        }
                    }
                    //IDMLView.SwitchColumnHeaders(oQueryLib);
                    //IDMLView.View = IDMListView.idmView.idmViewReport;
                }
                catch (Exception e)
                {
                    throw new Exception("On Error Resume Next not handled propertly: " + e.Message);
                }
            }
            else
            {
                //IDMLView.View = IDMListView.idmView.idmViewList;
            }
            // Now for the easy part - slam in the actual items
           
            if ( !oRS.IsEmpty() )
            {
                int i = 0;
                foreach (IRepositoryRow row in oRS)
                {
                    string[] rowData = { row.Properties.GetProperty("Id").GetIdValue().ToString(),
                        row.Properties.GetProperty("XfolioP").GetStringValue(),
                    row.Properties.GetProperty("FolioS403").GetStringValue(),
                    row.Properties.GetProperty("SecLote").GetStringValue(),
                    row.Properties.GetProperty("Instrumento").GetStringValue(),
                    row.Properties.GetProperty("Producto").GetStringValue(),
                    row.Properties.GetProperty("XfolioS").GetStringValue(),
                    row.Properties.GetProperty("CalificaOnDemand").GetStringValue(),
                    row.Properties.GetProperty("FechaOperacion").GetStringValue(),
                    row.Properties.GetProperty("StatusImagen").GetStringValue(),
                    row.Properties.GetProperty("Status").GetStringValue(),
                    row.Properties.GetProperty("Linea").GetStringValue(),
                    row.Properties.GetProperty("Contrato").GetStringValue(),
                    row.Properties.GetProperty("NumCliente").GetStringValue(),
                    row.Properties.GetProperty("Folio").GetStringValue(),
                    row.Properties.GetProperty("TipoDoc").GetStringValue(),
                    row.Properties.GetProperty("UOC").GetStringValue()};
                    if (i > 20) {
                        break;
                    }
                    i++;
                    IDMLView.Rows.Add(rowData);
                }
               
                //  IDMLView.AddItems(oRS.Fields["ObjSet"].Value, 1);
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
        public IObjectStore objObjectStore;

        // Executes query using passed params, places results in
        // passed IDMListView control
        // Calls must be preceded by a BindToLib
        public void ExecQuery(ref  DataGridView IDMLView, string sWhereClause, string sFolderName, int iMaxRows)//AxIDMListView.AxIDMListView
        {
           
            if (objObjectStore != null)
            {
                // Build the string necessary to bind to the database connection
                //sConnect = "provider=FnDBProvider;data source=" + oQueryLib.Name + ";Prompt=4;SystemType=" + ((int)oQueryLib.SystemType) + ";";
                // Build the query string

                //sQuery = "SELECT * FROM FnDocument ";
                String mySQLString = "SELECT * FROM ExpedientesDC  ";
                SearchSQL sqlObject = new SearchSQL();
                

                // The SearchSQL instance (sqlObject) can then be specified in the 
                // SearchScope parameter list to execute the search. Uses fetchRows to test the SQL 
                // statement.
                SearchScope searchScope = new SearchScope(objObjectStore);
            
                if (sWhereClause.Length > 0)
                {
                    sQuery = sQuery + "WHERE VersionStatus=1 AND " + sWhereClause;
                    //sQuery = sQuery + "WHERE VersionStatus=1 ";
                }

                // Set up the properties on the record set
                //if (oRS != null)
                //{
                    oRS = null;
                //}
                //Set oMiBD = New ADODB.Connection
                //oMiBD.ConnectionString = sConnect
                //oMiBD.Open
                //oRS = new ADODB.Recordset();

                //oRS.let_ActiveConnection(sConnect);
                //oRS.Properties["SupportsObjSet"].Value = true;
                if (iMaxRows > 0)
                {
                    //searchScope.
                    //oRS.MaxRecords = iMaxRows;
                    sQuery = sQuery + " OPTIONS ( BATCHSIZE "+iMaxRows+" )";
                }
                //oRS.Properties["SearchFolderName"].Value = sFolderName;
                // All set up - pull the trigger
                //oRS.LockType = ADODB.LockTypeEnum.adLockOptimistic;
                //oRS.Open sQuery, oMiBD, adOpenKeyset, , adCmdText
                //oRS.Open sQuery, oMiBD, adOpenKeyset
                //oRS.Open(sQuery, Type.Missing, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockUnspecified, -1);

                sqlObject.SetQueryString(mySQLString + sQuery);
                //sqlObject.SetQueryString(mySQLString);
                oRS = searchScope.FetchRows(sqlObject, null, null, true);

                
                ShowResults(ref IDMLView);
            }
            else
            {
                MessageBox.Show("Must set library!", Application.ProductName);
            }
        }
    }
}