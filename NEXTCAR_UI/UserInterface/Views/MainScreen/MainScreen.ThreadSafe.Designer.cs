using NEXTCAR_UI.DataClasses;
using NEXTCAR_UI.UserInterface.ViewObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Views.MainScreen
{
	public partial class MainScreen
	{
		// Thread-safe handling of the connection toggle button
		delegate void ToggleStateChangeCallback(ToggleButton ToggleButton, bool isTargetConnected);
		private void ToggleStateChange(ToggleButton ToggleButton, bool isTargetConnected)
		{
			if (ToggleButton.InvokeRequired)
			{
				ToggleStateChangeCallback callback = new ToggleStateChangeCallback(ToggleStateChange);
				this.Invoke(callback, new object[] { ToggleButton, isTargetConnected });
			}
			else
			{
				if (isTargetConnected == false)
				{
					ToggleButton.Text = ViewConstants.CONNECT_BUTTON_TEXT;
					ToggleButton.BackColor = ViewConstants.CONNECT_BUTTON_COLOR;
				}
				else
				{
					ToggleButton.Text = ViewConstants.DISCONNECT_BUTTON_TEXT;
					ToggleButton.BackColor = ViewConstants.DISCONNECT_BUTTON_COLOR;
				}
			}
		}

		// Thread-safe handling of the real time model text box
		delegate void RealTimeModelFilePathChangeCallback(RichTextBox richTextBox, string realTimeModelFilePath);
		private void RealTimeModelFilePathChange(RichTextBox richTextBox, string realTimeModelFilePath)
		{
			if (richTextBox.InvokeRequired)
			{
				RealTimeModelFilePathChangeCallback callback = new RealTimeModelFilePathChangeCallback(RealTimeModelFilePathChange);
				this.Invoke(callback, new object[] { richTextBox, realTimeModelFilePath });
			}
			else
			{
				richTextBox.Text = realTimeModelFilePath;
			}
		}

		// Thread-safe handling of the load application toggle button
		delegate void LoadApplicationToggleButtonChangeCallback(ToggleButton ToggleButton, string loadedModelName);
		private void LoadApplicationToggleButtonChange(ToggleButton ToggleButton, string loadedModelName)
		{
			if (ToggleButton.InvokeRequired)
			{
				LoadApplicationToggleButtonChangeCallback callback = new LoadApplicationToggleButtonChangeCallback(LoadApplicationToggleButtonChange);
				this.Invoke(callback, new object[] { ToggleButton, loadedModelName });
			}
			else
			{
				if(loadedModelName == null)
				{
					ToggleButton.Text = ViewConstants.LOAD_BUTTON_TEXT;
					ToggleButton.BackColor = ViewConstants.LOAD_MODEL_BUTTON_COLOR;
				}
				else
				{
					ToggleButton.Text = ViewConstants.UNLOAD_BUTTON_TEXT;
					ToggleButton.BackColor = ViewConstants.UNLOAD_MODEL_BUTTON_COLOR;
				}
			}
		}
	}
}
