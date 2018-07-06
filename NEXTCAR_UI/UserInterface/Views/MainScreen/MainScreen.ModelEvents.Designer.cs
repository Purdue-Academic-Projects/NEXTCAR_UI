using NEXTCAR_UI.DataClasses;
using NEXTCAR_UI.UserInterface.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Views.MainScreen
{
    public partial class MainScreen : IViewRealTimeModel
    {
		public event EventHandler ModelFileLocationTextChanged;
		public event MouseEventHandler BrowseForModelFileButtonClicked;

		private void OnModelFileLocationTextChanged(object sender, EventArgs e)	{ ModelFileLocationTextChanged?.Invoke(sender, e); }
		private void OnBrowseForModelFileButtonClicked(object sender, MouseEventArgs e) { BrowseForModelFileButtonClicked?.Invoke(sender, e); }

		public void UpdateRealTimeModelLocationTextBox(string updatedFilePath)
		{
			this.RichTextBoxTextChange(this.RealTimeModelFileLocationRichTextBox, updatedFilePath);
		}

		public void ChangeBuildModelButtonState(bool isButtonEnabled)
		{
			if(isButtonEnabled==true)
			{
				this.BuildModelFileButton.Enabled = true;
				this.BuildModelFileButton.BackColor = ViewConstants.ACTIVE_BUTTON_COLOR;
			}
			else
			{
				this.BuildModelFileButton.Enabled = false;
				this.BuildModelFileButton.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
			}
		}
	}
}
