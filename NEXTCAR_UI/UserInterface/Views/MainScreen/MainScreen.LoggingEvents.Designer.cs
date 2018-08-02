using NEXTCAR_UI.Business.Interfaces;

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
		public event EventHandler<LogTimeChangedEventArgs> UserEnteredLoggingTime;
		public event EventHandler<UseLogTimeChangedEventArgs> UseLogTimeCheckboxChanged;
		public event EventHandler StartLoggingToggleButtonClicked;

		private void OnUserEnteredLoggingTime(object sender, KeyEventArgs e)
		{
			double loggingTime = -1;
			if (e.KeyCode == Keys.Enter)
			{
				try
				{
					loggingTime = Convert.ToDouble(this.LoggingTimeRichTextBox.Text);
					if (loggingTime <= 0) { throw new Exception(); }
				}
				catch
				{
					this.LoggingTimeRichTextBox.Text = "";
					loggingTime = -1;
					System.Windows.Forms.MessageBox.Show("Logging Time entered was invalid!", "Invalid Log Time Entered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				finally
				{
					if(loggingTime != -1)
					{
						LogTimeChangedEventArgs args = new LogTimeChangedEventArgs(loggingTime);
						UserEnteredLoggingTime?.Invoke(sender, args);
					}
				}
			}
		}	

		private void OnUseLogTimeCheckboxChanged(object sender, EventArgs e)
		{
			bool isCheckBoxChecked = false;
			if(this.UseLogTimeCheckBox.Checked){ isCheckBoxChecked = true; }

			UseLogTimeChangedEventArgs args = new UseLogTimeChangedEventArgs(isCheckBoxChecked);
			UseLogTimeCheckboxChanged?.Invoke(sender, args);
		}

		private void OnStartLoggingToggleButtonClicked(object sender, EventArgs e)
		{
			StartLoggingToggleButtonClicked?.Invoke(sender, e);
		}

		public void ChangeControlLoggingTimeCheckBoxState(bool isEnabled, bool clearDataIfDisabled)
		{
			CheckBoxEnableChanged(this.UseLogTimeCheckBox, isEnabled, clearDataIfDisabled);
		}

		public void ChangeLoggingToggleButtonEnableState(bool isToggleButtonInDefaultState,bool isToggleButtonEnabled)
		{
			ToggleButtonStateChange(this.StartLoggingToggleButton, isToggleButtonInDefaultState, isToggleButtonEnabled);
		}

		public void ChangeLoggingTimeRichTextBoxState(bool isRichTextBoxActive, bool clearTextOnDisable, string newRichTextBoxText=null)
		{
			RichTextBoxStateChange(this.LoggingTimeRichTextBox, isRichTextBoxActive, clearTextOnDisable, newRichTextBoxText=null);
		}

		public void ChangeProgressBarState(bool isVisible)
		{
			ProgessBarChange(this.LoggingTimeProgressBar, isVisible);
		}
	}
}
