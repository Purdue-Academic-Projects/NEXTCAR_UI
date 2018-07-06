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
		delegate void ConnectionToggleStateChangeCallback(ToggleButton ToggleButton, bool isTargetConnected);
		private void ConnectionToggleStateChange(ToggleButton ToggleButton, bool isTargetConnected)
		{
			if (ToggleButton.InvokeRequired)
			{
				ConnectionToggleStateChangeCallback callback = new ConnectionToggleStateChangeCallback(ConnectionToggleStateChange);
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
		delegate void RichTextBoxTextChangeCallback(RichTextBox richTextBox, string newTextBoxText);
		private void RichTextBoxTextChange(RichTextBox richTextBox, string newTextBoxText)
		{
			if (richTextBox.InvokeRequired)
			{
				RichTextBoxTextChangeCallback callback = new RichTextBoxTextChangeCallback(RichTextBoxTextChange);
				this.Invoke(callback, new object[] { richTextBox, newTextBoxText });
			}
			else
			{
				richTextBox.Text = newTextBoxText;
			}
		}

		// Thread-safe handling of the load application toggle button
		delegate void LoadApplicationToggleButtonChangeCallback(ToggleButton ToggleButton, 
			bool isTargetConnected, 
			bool isRealTimeFileLoadedInTextbox,
			bool isModelLoadedOnTarget);
		private void LoadApplicationToggleButtonChange(ToggleButton ToggleButton, 
			bool isTargetConnected,
			bool isRealTimeFileLoadedInTextbox,
			bool isModelLoadedOnTarget)
		{
			if (ToggleButton.InvokeRequired)
			{
				LoadApplicationToggleButtonChangeCallback callback = new LoadApplicationToggleButtonChangeCallback(LoadApplicationToggleButtonChange);
				this.Invoke(callback, new object[] { ToggleButton, isTargetConnected, isRealTimeFileLoadedInTextbox, isModelLoadedOnTarget });
			}
			else
			{
				// If target is connected, determine whether the toggle button should display LOAD or UNLOAD
				if (isTargetConnected)
				{
					if (isModelLoadedOnTarget)
					{
						ToggleButton.Text = ViewConstants.UNLOAD_BUTTON_TEXT;
						ToggleButton.BackColor = ViewConstants.UNLOAD_MODEL_BUTTON_COLOR;
						ToggleButton.Enabled = true;
					}
					else
					{
						if (isRealTimeFileLoadedInTextbox)
						{
							ToggleButton.Text = ViewConstants.LOAD_BUTTON_TEXT;
							ToggleButton.BackColor = ViewConstants.LOAD_MODEL_BUTTON_COLOR;
							ToggleButton.Enabled = true;
						}
						else
						{
							ToggleButton.Text = ViewConstants.LOAD_BUTTON_TEXT;
							ToggleButton.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
							ToggleButton.Enabled = false;
						}
					}
				}
				// If target is not connected, reset toggle button back to default state
				else
				{
					ToggleButton.Text = ViewConstants.LOAD_BUTTON_TEXT;
					ToggleButton.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
					ToggleButton.Enabled = false;
				}
			}
		}

		// Thread-safe handling of the target reboot button
		delegate void TargetRebootButtonChangeCallback(ToggleButton ToggleButton, bool isTargetConnected);
		private void TargetRebootButtonChange(ToggleButton ToggleButton, bool isTargetConnected)
		{
			if (ToggleButton.InvokeRequired)
			{
				ConnectionToggleStateChangeCallback callback = new ConnectionToggleStateChangeCallback(TargetRebootButtonChange);
				this.Invoke(callback, new object[] { ToggleButton, isTargetConnected });
			}
			else
			{
				if (isTargetConnected == false)
				{
					ToggleButton.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
					ToggleButton.Enabled = false;
				}
				else
				{
					ToggleButton.BackColor = ViewConstants.ACTIVE_BUTTON_COLOR;
					ToggleButton.Enabled = true;
				}
			}
		}

		// Thread-safe handling of the simulation start toggle button
		delegate void StartSimulationToggleButtonChangeCallback(
			ToggleButton ToggleButton, 
			bool isTargetConnected, 
			bool isModelLoadedOnTarget, 
			bool isTargetRunning);
		private void StartSimulationToggleButtonChange(
			ToggleButton ToggleButton, 
			bool isTargetConnected,
			bool isModelLoadedOnTarget,
			bool isTargetRunning)
		{
			if (ToggleButton.InvokeRequired)
			{
				StartSimulationToggleButtonChangeCallback callback = new StartSimulationToggleButtonChangeCallback(StartSimulationToggleButtonChange);
				this.Invoke(callback, new object[] { ToggleButton, isTargetConnected, isModelLoadedOnTarget, isTargetRunning });
			}
			else
			{
				if(isTargetConnected && isModelLoadedOnTarget)
				{
					if (isTargetRunning)
					{
						ToggleButton.Enabled = true;
						ToggleButton.BackColor = ViewConstants.STOP_SIMULATION_BUTTON_COLOR;
						ToggleButton.Text = ViewConstants.STOP_SIMULATION_BUTTON_TEXT;
					}
					else
					{
						ToggleButton.Enabled = true;
						ToggleButton.BackColor = ViewConstants.START_SIMULATION_BUTTON_COLOR;
						ToggleButton.Text = ViewConstants.START_SIMULATION_BUTTON_TEXT;
					}
				}
				else
				{
					ToggleButton.Enabled = false;
					ToggleButton.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
					ToggleButton.Text = ViewConstants.START_SIMULATION_BUTTON_TEXT;
				}
			}
		}
	}
}
