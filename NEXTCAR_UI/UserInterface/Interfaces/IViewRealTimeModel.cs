using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Interfaces
{
	public interface IViewRealTimeModel
	{
		event EventHandler ModelFileLocationTextChanged;
		event MouseEventHandler BrowseForModelFileButtonClicked;

		void UpdateRealTimeModelLocationTextBox(string updatedFilePath);
		void ChangeBuildModelButtonState(bool isButtonEnabled);
		void ChangeLoadModelButtonState(bool isButtonEnabled);
	}
}
