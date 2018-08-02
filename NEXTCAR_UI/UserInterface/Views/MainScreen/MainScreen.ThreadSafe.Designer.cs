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
		// Thread-safe handling of the toggle buttons
		delegate void ToggleButtonStateChangeCallback(ToggleButton toggleButton, bool isToggleButtonInDefaultState, bool isToggleButtonEnabled = true);
		private void ToggleButtonStateChange(ToggleButton toggleButton, bool isToggleButtonInDefaultState, bool isToggleButtonEnabled = true)
		{
			if (toggleButton.InvokeRequired)
			{
				ToggleButtonStateChangeCallback callback = new ToggleButtonStateChangeCallback(ToggleButtonStateChange);
				this.Invoke(callback, new object[] { toggleButton, isToggleButtonInDefaultState, isToggleButtonEnabled});
			}
			else
			{
				// Handle the ConnectToggleButton behavior
				if (toggleButton == ConnectToggleButton)
				{
					if (isToggleButtonInDefaultState)
					{
						toggleButton.Text = ViewConstants.CONNECT_BUTTON_TEXT;
						toggleButton.BackColor = ViewConstants.CONNECT_BUTTON_COLOR;
						toggleButton.GlowColor = ViewConstants.CONNECT_BUTTON_COLOR;
					}
					else
					{
						toggleButton.Text = ViewConstants.DISCONNECT_BUTTON_TEXT;
						toggleButton.BackColor = ViewConstants.DISCONNECT_BUTTON_COLOR;
						toggleButton.GlowColor = ViewConstants.DISCONNECT_BUTTON_COLOR;
					}
				}
				// Handle the LoadModelToggleButton behavior
				else if (toggleButton == LoadModelToggleButton)
				{
					if (isToggleButtonInDefaultState)
					{
						toggleButton.Text = ViewConstants.UNLOAD_BUTTON_TEXT;
						toggleButton.BackColor = ViewConstants.UNLOAD_MODEL_BUTTON_COLOR;
						toggleButton.GlowColor = ViewConstants.UNLOAD_MODEL_BUTTON_COLOR;
					}
					else
					{
						toggleButton.Text = ViewConstants.LOAD_BUTTON_TEXT;
						toggleButton.BackColor = ViewConstants.LOAD_MODEL_BUTTON_COLOR;
						toggleButton.GlowColor = ViewConstants.LOAD_MODEL_BUTTON_COLOR;
					}
				}
				// Handle the StartSimulationToggleButton behavior
				else if (toggleButton == StartSimulationToggleButton)
				{
					if (isToggleButtonInDefaultState)
					{
						toggleButton.BackColor = ViewConstants.START_SIMULATION_BUTTON_COLOR;
						toggleButton.GlowColor = ViewConstants.START_SIMULATION_BUTTON_COLOR;
						toggleButton.Text = ViewConstants.START_SIMULATION_BUTTON_TEXT;
					}
					else
					{
						toggleButton.BackColor = ViewConstants.STOP_SIMULATION_BUTTON_COLOR;
						toggleButton.GlowColor = ViewConstants.STOP_SIMULATION_BUTTON_COLOR;
						toggleButton.Text = ViewConstants.STOP_SIMULATION_BUTTON_TEXT;
					}
				}
				// Handle the StartLoggingToggleButton behavior
				else if (toggleButton == StartLoggingToggleButton)
				{
					if (isToggleButtonInDefaultState)
					{
						toggleButton.Text = ViewConstants.START_LOGGING_DATA_TEXT;
						toggleButton.BackColor = ViewConstants.START_LOGGING_BUTTON_COLOR;
						toggleButton.GlowColor = ViewConstants.START_LOGGING_BUTTON_COLOR;
					}
					else
					{
						toggleButton.Text = ViewConstants.STOP_LOGGING_DATA_TEXT;
						toggleButton.BackColor = ViewConstants.STOP_LOGGING_BUTTON_COLOR;
						toggleButton.GlowColor = ViewConstants.STOP_LOGGING_BUTTON_COLOR;
					}
				}

				// Handle enabling/disabling of all toggle buttons
				if (isToggleButtonEnabled) { toggleButton.Enabled = true; }
				else
				{
					toggleButton.Enabled = false;
					toggleButton.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
				}
			}
		}

		// Thread-safe handling of the buttons (these use the ToggleButton class but just act as regular buttons)
		delegate void ButtonStateChangeCallback(ToggleButton button, bool isButtonEnabled);
		private void ButtonStateChange(ToggleButton button, bool isButtonEnabled)
		{
			if (button.InvokeRequired)
			{
				ButtonStateChangeCallback callback = new ButtonStateChangeCallback(ButtonStateChange);
				this.Invoke(callback, new object[] { button, isButtonEnabled });
			}
			else
			{
				// Handle the BuildModelFileButton behavior
				if (button == BuildModelFileButton)
				{
					// TODO - not yet implemented
				}
				// Handle the RebootTargetPCButton behavior
				else if (button == RebootTargetPCButton)
				{
					if(isButtonEnabled)
					{
						button.BackColor = ViewConstants.ACTIVE_BUTTON_COLOR;
						button.GlowColor = ViewConstants.ACTIVE_BUTTON_COLOR;
						button.Enabled = true;
					}
					else
					{
						button.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
						button.Enabled = false;
					}
				}
			}
		}

		// Thread-safe handling of the rich text boxes
		delegate void RichTextBoxStateChangeCallback(
			RichTextBox richTextBox,
			bool isRichTextBoxActive,
			bool clearTextOnDisable = false,
			string newRichTextBoxText = null);
		private void RichTextBoxStateChange(
			RichTextBox richTextBox, 
			bool isRichTextBoxActive, 
			bool clearTextOnDisable=false, 
			string newRichTextBoxText = null)
		{
			if (richTextBox.InvokeRequired)
			{
				RichTextBoxStateChangeCallback callback = new RichTextBoxStateChangeCallback(RichTextBoxStateChange);
				this.Invoke(callback, new object[] { richTextBox, isRichTextBoxActive, clearTextOnDisable, newRichTextBoxText });
			}
			else
			{
				// Handle the IPaddressRichTextBox/PortRichTextBox/StopTimeRichTextBox/LoggingTimeRichTextBox behavior
				if ((richTextBox == IPaddressRichTextBox)
					|| (richTextBox == PortRichTextBox)
					|| (richTextBox == StopTimeRichTextBox)
					|| (richTextBox == LoggingTimeRichTextBox))
				{
					if(isRichTextBoxActive)
					{
						richTextBox.ReadOnly = false;
						richTextBox.BackColor = ViewConstants.RICHTEXTBOX_ENABLED_COLOR;
					}
					else
					{
						richTextBox.ReadOnly = true;
						richTextBox.BackColor = ViewConstants.RICHTEXTBOX_DISABLED_COLOR;
					}
				}
				// Handle the RealTimeModelFileLocationRichTextBox/LoadedModelRichTextBox behavior
				else if ((richTextBox == RealTimeModelFileLocationRichTextBox)
					|| (richTextBox == LoadedModelRichTextBox))
				{
					if (isRichTextBoxActive)
					{
						richTextBox.ReadOnly = true;
						richTextBox.BackColor = ViewConstants.RICHTEXTBOX_DISABLED_COLOR;
					}
					else
					{
						richTextBox.ReadOnly = true;
						richTextBox.BackColor = ViewConstants.RICHTEXTBOX_DISABLED_COLOR;
					}
				}

				// Handle clearing of text data on disable for all rich text boxes
				if (!isRichTextBoxActive && clearTextOnDisable) { richTextBox.Text = ""; }
				// Handle updating of text for all rich text boxes
				if(newRichTextBoxText!= null) { richTextBox.Text = newRichTextBoxText; }
			}
		}

		// Thread-safe handling of the Strip Status Values
		delegate void StatusStripValueChangedCallback(StatusStrip statusStrip, ToolStripStatusLabel toolStripStatusLabel, string newValue);
		private void StatusStripValueChanged(StatusStrip statusStrip, ToolStripStatusLabel toolStripStatusLabel, string newValue)
		{
			if (statusStrip.InvokeRequired)
			{
				StatusStripValueChangedCallback callback = new StatusStripValueChangedCallback(StatusStripValueChanged);
				this.Invoke(callback, new object[] { statusStrip, toolStripStatusLabel, newValue });
			}
			else
			{
				toolStripStatusLabel.Text = newValue;
			}
		}

		// Thread-safe handling of CheckBox enables
		delegate void CheckBoxEnableChangedCallback(CheckBox checkBox, bool isEnabled, bool clearDataIfDisabled);
		private void CheckBoxEnableChanged(CheckBox checkBox, bool isEnabled, bool clearDataIfDisabled)
		{
			if (checkBox.InvokeRequired)
			{
				CheckBoxEnableChangedCallback callback = new CheckBoxEnableChangedCallback(CheckBoxEnableChanged);
				this.Invoke(callback, new object[] { checkBox, isEnabled, clearDataIfDisabled });
			}
			else
			{
				if (isEnabled) { checkBox.Enabled = true; }
				else
				{
					checkBox.Enabled = false;
					if (clearDataIfDisabled) { checkBox.CheckState = CheckState.Unchecked; }
				}
			}
		}

		// Thread-safe handling of Progress Bar
		delegate void ProgessBarChangeCallback(ProgressBar progressBar, bool isVisible);
		private void ProgessBarChange(ProgressBar progressBar, bool isVisible)
		{
			if(progressBar.InvokeRequired)
			{
				ProgessBarChangeCallback callback = new ProgessBarChangeCallback(ProgessBarChange);
				this.Invoke(callback, new object[] { progressBar, isVisible });
			}
			else
			{
				progressBar.Visible = isVisible;
			}
		}
	}
}
