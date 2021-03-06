using System.Windows.Forms;

using Microsoft.VisualBasic;

using System;

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace UOCFilenet
{
    internal class clsRegPersist
    {

        public void SaveSettings(string sAppName, string sSection, frmSettings fFrm)
        {
            //UPGRADE_WARNING:Form property fFrm.Controls has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            foreach (Control oCtrl in fFrm.Controls)

            {
                if (oCtrl is TextBox)
                {
                    Interaction.SaveSetting(sAppName, sSection, oCtrl.Name, ((System.Windows.Forms.TextBox)oCtrl).Text);
                }
            }
        }
        public void GetSettings(string sAppName, string sSection, Form fFrm)
        {
            //FSQ20070507. Code moved to GetSetting
            foreach (Control oCtrl in fFrm.Controls)
            {
                GetSetting(sAppName, sSection, oCtrl);
            }
        }
        //FSQ20070507. Added in order to go through all controls recursively
        private void GetSetting(string sAppName, string sSection, Control ctrl)
        {
            if (ctrl is TextBox)
            {
                string sTemp = String.Empty;
                sTemp = Interaction.GetSetting(sAppName, sSection, ctrl.Name, String.Empty);
                //FSQ20070525. UPGRADE_WARNING:Controls method Controls.Item has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
                //FSQ20070525. UPGRADE_WARNING:Couldn't resolve default property of object fFrm.Controls(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                //FSQ20070507. 
                //fFrm.Controls[oCtrl.Name] = sTemp;
                ((System.Windows.Forms.TextBox)ctrl).Text = sTemp;
            }
            foreach (Control oCtrl in ctrl.Controls)
            {
                GetSetting(sAppName, sSection, oCtrl);
            }
        }
        public void DeleteSettings(string sAppName, string sSection)
        {
            try
            {
                Interaction.DeleteSetting(sAppName, sSection, String.Empty);
            }
            catch
            {
            }
        }
    }
}