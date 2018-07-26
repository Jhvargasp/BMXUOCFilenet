using System.Threading;
using Microsoft.VisualBasic;

using System.Windows.Forms;

using System.IO;

using System.Runtime.InteropServices;

using System;

using Microsoft.Win32;

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
using FileNet.Api.Collection;

namespace UOCFilenet
{
    class @Globals
    {
        //static public IDMObjects.Neighborhood oNeighborhood = new IDMObjects.Neighborhood();
        //static public IDMObjects.ObjectSet oLibraries = new IDMObjects.ObjectSet();
        //static public IDMObjects.Library oLibrary = new IDMObjects.Library();
        //static public frmSettings gfSettings = new frmSettings();
        //static public clsRegPersist goPersist = new clsRegPersist();
        //static public Collection gcPropNames = new Collection();


        //public const IDMObjects.idmLibraryLogon dmLogonOptNoUI = 0; // Do not display a user interface.
        public const int idmLogonOptServerNetworkNoUI = 16; // (&H10)   Log on in server mode and use network logon credentials; do not display a user interface.
        public const int idmLogonOptServerNoUI = 8; // Log on in server mode; do not display a user interface.
        public const int idmLogonOptUseNetworkNoUI = 2; // Use network logon credentials; do not display a user interface.
        public const int idmLogonOptUseNetworkWithUI = 4; // Use network logon credentials; display a user interface.
        public const int idmLogonOptWithUI = 1; // Display a logon user interface.

        /* Avg  Ini 14/01/20109 */
        public static string DirWork = string.Empty;
        public static string DirLog = string.Empty;
        public static string DirConf = string.Empty;
        public static string TmpImg = string.Empty;
        /* Avg  Fin 14/01/20109 */

            /*
        static private IDMObjects.Neighborhood _oNeighborhood;
        static public IDMObjects.Neighborhood oNeighborhood
        {
            get
            {
                if (_oNeighborhood == null)
                    _oNeighborhood = new IDMObjects.Neighborhood();

                return _oNeighborhood;
            }
            set
            {
                _oNeighborhood = value;
            }
        }

        static private IDMObjects.ObjectSet _oLibraries;
        static public IDMObjects.ObjectSet oLibraries
        {
            get
            {
                if (_oLibraries == null)
                    _oLibraries = new IDMObjects.ObjectSet();
                return _oLibraries;
            }
            set
            {
                _oLibraries = value;
            }
        }

        static private IDMObjects.Library _oLibrary;
        static public IDMObjects.Library oLibrary
        {
            get
            {
                if (_oLibrary == null)
                    _oLibrary = new IDMObjects.Library();

                return _oLibrary;
            }
            set
            {
                _oLibrary = value;
            }
        }
        */
        //static public IDMObjects.Document oDocument = new IDMObjects.Document();
        static public FileNet.Api.Core.IDocument oDocument;
        //static public IDMObjects.Document oDocument2 = new IDMObjects.Document();
        static public FileNet.Api.Core.IDocument oDocument2;


        static private frmSettings _gfSettings;
        static public frmSettings gfSettings
        {
            get
            {
                if (_gfSettings == null)
                    _gfSettings = new frmSettings();
                return _gfSettings;
            }
            set
            {
                _gfSettings = value;
            }
        }

        static private clsRegPersist _goPersist;
        static public clsRegPersist goPersist
        {
            get
            {
                if (_goPersist == null)
                    _goPersist = new clsRegPersist();

                return _goPersist;
            }
            set
            {
                _goPersist = value;
            }
        }

        static public Collection _gcPropNames;
        static public Collection gcPropNames
        {
            get
            {
                if (_gcPropNames == null)
                    _gcPropNames = new Collection();
                return _gcPropNames;
            }
            set
            {
                _gcPropNames = value;
            }
        }

        /*
        static private IDMError.ErrorManager _oErrManager = null;
        static public IDMError.ErrorManager oErrManager
        {
            get
            {
                if (_oErrManager == null)
                    _oErrManager = new IDMError.ErrorManager();

                return _oErrManager;
            }
            set
            {
                _oErrManager = value;
            }
        }
        */
        static public clsSimpleQuery clsQuery = new clsSimpleQuery();
        //static public IDMObjects.PropertyDescriptions goPropDescs = null;
        static public IPropertyDescriptionList goPropDescs = null;
        static public bool gbISLogOff = false;
        public const string gsAppName = "Sistema de Registro y Custodia de Doctos";
        public const string gsSectionName = "FileNET";
        static public Collection gcHeadings = null;
        
        static public string CommandLine = string.Empty;
        static public string XFolio = String.Empty;
        static public string XFolio2 = String.Empty;
        static public string UOC = String.Empty;
        static public string XFolioS403 = String.Empty;
        static public int VarCom = 0;
        static public string TipoDoc = String.Empty;
        static public string UOC1 = String.Empty;
        static public string XFechaOp = String.Empty;
        static public string XInst = String.Empty;
        static public long Pag = 0;
        static public string XFile = String.Empty;
        static public string XProd = String.Empty;
        static public string XCalifOnd = String.Empty;
        static public string Pass_Sapuf = String.Empty;
        //AVG Ini Sept-2015
        static public string SubFol1 = String.Empty;
        static public string SubFol2 = String.Empty;
        //AVG Fin Sept-2015



        public static string GetFileName(ref  string ScanString)
        {

            int PosSave = 0;
            bool ExitWhile = true;
            int Pos = 1;


            while (ExitWhile)
            {
                Pos = (int)Strings.InStr(Pos, ScanString, "\\", (CompareMethod)0);
                if (Pos == 0)
                {
                    break;
                }
                else
                {
                    Pos++;
                    PosSave = Pos - 1;
                }
            };
            return ScanString.Substring(PosSave).Trim();

        }

        public static int DirExist(string FN)
        {

            //FSQ20070507. Changed by try...catch
            //On Error Resume Next;

            try { FN = sFixDirString(FN).ToUpper(); }
            catch { }

            // Devuelve 0 (False) si no existe y -1 (True) si existe

            // En todos los directorios hay una entrada NUL
            //FSQ20070507. If there is an exception in the if statement the next instruction will
            //be executed, which happens to be return 0;
            try
            {
                //if (FileSystem.Dir(FN + "NUL", FileAttribute.Normal) == "")
                if (!Directory.Exists(FN))
                { //  DIR$="" significa que no lo ha encontrado
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static string sFixDirString(string sInComming)
        {


            string sTemp = sInComming;

            if (!sTemp.EndsWith("\\"))
            {
                return sTemp + "\\";
            }
            else
            {
                return sTemp;
            }

        }


        public static string GetWindowsDir()
        {


            string WinDir = Environment.GetEnvironmentVariable("windir");
            //int Res = (int)GetWindowsDirectory(ref WinDir, 20);
            //string File = WinDir.Substring(0, Math.Min(WinDir.Length, WinDir.IndexOf(" ")));
            return WinDir + "\\";//File.Trim() + "\\";

        }

        public static void LLena_CboUoc(ref  string XUoc, ComboBox XCbo)
        {
            XCbo.Items.Clear();
            if (XUoc == "2557")
            {
                XCbo.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(XUoc, (int)Conversion.Val(XUoc)));
            }
            else
            {
                XUoc = "4519";
                XCbo.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(XUoc, (int)Conversion.Val(XUoc)));
                XUoc = "4520";
                XCbo.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(XUoc, (int)Conversion.Val(XUoc)));
                XUoc = "4521";
                XCbo.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(XUoc, (int)Conversion.Val(XUoc)));
                XUoc = "3236";
                XCbo.Items.Add(new Microsoft.VisualBasic.Compatibility.VB6.ListBoxItem(XUoc, (int)Conversion.Val(XUoc)));
            }
            XCbo.SelectedIndex = -1;
        }

        public static string fncParmIniGet(string stanza, string keyname, string inifile)
        {
            string theResult = String.Empty;
            string @Default = "";
            byte[] result1 = new byte[255];

            //AIS-91 dvelasco
            long rc = API.KERNEL.GetPrivateProfileString(stanza, keyname, @Default, result1, result1.Length, Environment.CurrentDirectory+"/"+ inifile);

            System.Text.Encoding enc = System.Text.Encoding.ASCII;
            string myString = enc.GetString(result1);
            if (rc != 0)
            {
                theResult = myString.Trim();
                if (theResult.Length > 1)
                {
                    theResult = theResult.Substring(0, Math.Min(theResult.Length, (int)rc));//theResult.Length - 1));
                }
            }
            else
            {
                theResult = "";
            }
            return theResult;
        }

        static public void fncParmIniSet(string stanza, string keyname, string lpString, string inifile)
        {
            long rc = 0;// API.KERNEL.WritePrivateProfileString(stanza, keyname, lpString, inifile);
        }

        static public void ObtPassSapuf()
        {
            
            TuxServer.ClassSAPUF mClassSAPUF = new TuxServer.ClassSAPUF();
            //string DirWinTemp = "C:\\APPS\\CreditoEmpresarial\\";
            string DirWinTemp = DirLog;

            string VTemp = fncParmIniGet("C406090", "pSAPUF_MAQDEST", DirWinTemp + "C406090.ini");
            mClassSAPUF.pSAPUF_MAQDEST = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_USUDEST", DirWinTemp + "C406090.ini");
            mClassSAPUF.pSAPUF_USUDEST = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_TIPDEST", DirWinTemp + "C406090.ini");
            mClassSAPUF.pSAPUF_TIPDEST = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_APLDEST", DirWinTemp + "C406090.ini");
            mClassSAPUF.pSAPUF_APLDEST = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_APLORIG", DirWinTemp + "C406090.ini");
            mClassSAPUF.pSAPUF_APLORIG = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_BASEDATO", DirWinTemp + "C406090.ini");
            mClassSAPUF.pSAPUF_BASEDATO = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_TIMER", DirWinTemp + "C406090.ini");
            mClassSAPUF.pSAPUF_TIMER = VTemp;
            VTemp = fncParmIniGet("C406090", "pSAPUF_OPERACION", DirWinTemp + "C406090.ini");
            mClassSAPUF.pSAPUF_OPERACION = VTemp;
            mClassSAPUF.pSAPUF_PASS = "";

            //mClassSAPUF.pSAPUF_MAQDEST = "UCAMX8"
            //mClassSAPUF.pSAPUF_USUDEST = "c406_090"
            //mClassSAPUF.pSAPUF_TIPDEST = "AP"
            //mClassSAPUF.pSAPUF_APLDEST = "FileNet 4.0"
            //mClassSAPUF.pSAPUF_APLORIG = "C406_090"
            //mClassSAPUF.pSAPUF_BASEDATO = ""
            //mClassSAPUF.pSAPUF_PASS = Empty
            //mClassSAPUF.pSAPUF_OPERACION = "11"
            //mClassSAPUF.pSAPUF_TIMER = "9999"

            Pass_Sapuf = mClassSAPUF.ObtenPass_SAPUF();
            //MsgBox Pass_Sapuf
        }

        static public void Genera_Archivo_Control()
        {
            //string DirWinTemp = "C:\\APPS\\CreditoEmpresarial";
            string DirWinTemp = DirLog;

            try { File.Delete(DirWinTemp + "\\UOCFileNet.ini"); }
            catch { }
            try
            {
                FileSystem.FileOpen(1, DirWinTemp + "\\UOCFileNet.ini", OpenMode.Output, OpenAccess.Default, OpenShare.Default, -1);
                FileSystem.PrintLine(1, "[UOCFileNet]");
                FileSystem.PrintLine(1, "Execute=-1");
                FileSystem.PrintLine(1, "[Error]");
                FileSystem.PrintLine(1, "ErrNumber=0");
                FileSystem.PrintLine(1, "DescError=");
            }
            catch { }
            finally
            {
                try { FileSystem.FileClose(1); }
                catch { }
            }
        }

        /* Avg  Ini 14/01/20109 */
        public static string LeeRegistry(string NomAplicacion, string LlaveRegistry)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim();
            string[] ValoresReg;
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.OpenSubKey(RutaRegistry);
                ValoresReg = Key.GetValueNames();

                foreach (string ValorReg in ValoresReg)
                {
                    if (ValorReg == LlaveRegistry)
                    {
                        LlaveBuscada = Key.GetValue(ValorReg).ToString().Trim();
                        break;
                    }
                }
                if (LlaveBuscada.IndexOf("%ALLUSERSPROFILE%") == 0)
                {
                    string Cade = string.Empty;
                    Cade = LlaveBuscada.Substring(LlaveBuscada.IndexOf("\\", 2));
                    LlaveBuscada = Cade;
                    Cade = Environment.GetEnvironmentVariable("ALLUSERSPROFILE");
                    LlaveBuscada = Cade + LlaveBuscada;
                }
                return LlaveBuscada;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return string.Empty;
            }
        }

        public static string LeeRegistry(string NomAplicacion, string SubNomApl, string LlaveRegistry)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim() + "\\" + SubNomApl.Trim();
            string[] ValoresReg;
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.OpenSubKey(RutaRegistry);
                ValoresReg = Key.GetValueNames();

                foreach (string ValorReg in ValoresReg)
                {
                    if (ValorReg == LlaveRegistry)
                    {
                        LlaveBuscada = Key.GetValue(ValorReg).ToString().Trim();
                        break;
                    }
                }

                return LlaveBuscada;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return string.Empty;
            }
        }

        public static Boolean EscribeRegistry(string NomAplicacion, string LlaveRegistry, object ValorKey)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim();
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.CreateSubKey(RutaRegistry);
                Key.SetValue(LlaveRegistry, ValorKey);
                Key.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static Boolean EscribeRegistry(string NomAplicacion, string SubNomApl, string LlaveRegistry, object ValorKey)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim() + "\\" + SubNomApl.Trim();
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.CreateSubKey(RutaRegistry);
                Key.SetValue(LlaveRegistry, ValorKey);
                Key.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static void ValidaRegistry(string NomAplicacion, string LlaveRegistry, object ValorKey)
        {
            RegistryKey Key;
            string RutaRegistry = "Software\\Banamex" + "\\" + NomAplicacion.Trim();
            string[] ValoresReg;
            string LlaveBuscada = string.Empty;

            try
            {
                Key = Registry.CurrentUser.OpenSubKey(RutaRegistry);
                ValoresReg = Key.GetValueNames();

                foreach (string ValorReg in ValoresReg)
                {
                    if (ValorReg == LlaveRegistry)
                    {
                        LlaveBuscada = Key.GetValue(ValorReg).ToString().Trim();
                        break;
                    }
                }

                if (LlaveBuscada.Length == 0)
                {
                    EscribeRegistry(NomAplicacion, LlaveRegistry, ValorKey);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                EscribeRegistry("C406_000", "NumApp", "C406_000");
            }
        }
        /* Avg  Fin 14/01/20109 */

    }
}
