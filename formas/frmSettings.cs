using System.Windows.Forms; 

using System; 

using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace UOCFilenet
{
	internal partial class frmSettings
		: System.Windows.Forms.Form
		{
		
			private void  btnCancel_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Hide();
			}
			
			private void  btnOk_Click( Object eventSender,  EventArgs eventArgs)
			{
					this.Close();
			}
			
			private void  cmdClear_Click( Object eventSender,  EventArgs eventArgs)
			{
                //AIS-469 FGUEVARA
                //Control oCtrl = null;
				@Globals.goPersist.DeleteSettings(@Globals.gsAppName, @Globals.gsSectionName);
				ClearEntries(this);
			}
			
			public void  cmdRefresh_Click()
			{
					ClearEntries(this);
					@Globals.goPersist.GetSettings(@Globals.gsAppName, @Globals.gsSectionName, this);
			}
			
			private void  cmdSave_Click( Object eventSender,  EventArgs eventArgs)
			{
					@Globals.goPersist.SaveSettings(@Globals.gsAppName, @Globals.gsSectionName, this);
			}
			private void  ClearEntries( frmSettings fFrm)
			{
					//UPGRADE_WARNING:Form property frmSettings.Controls has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
					foreach (Control oCtrl in Artinsoft.VB6.Gui.ContainerHelper.Controls(this))
					{
						if (oCtrl is TextBox)
						{
							((System.Windows.Forms.TextBox) oCtrl).Text = "";
						}
					}
			}
		}
}