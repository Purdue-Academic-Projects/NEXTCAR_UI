using MathWorks.xPCTarget.FrameWork;

using NEXTCAR_UI.Business.Interfaces;
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
    public partial class MainScreen : IViewApplication
	{
		public event MouseEventHandler LoadModelToggleButtonClicked;
		public event MouseEventHandler RebootTargetPCButtonClicked;
		public event MouseEventHandler StartSimulationToggleButtonClicked;
		public event EventHandler<StopTimeChangedEventArgs> StopTimeTextChanged;

		private void OnLoadModelToggleButtonClicked(object sender, MouseEventArgs e) { LoadModelToggleButtonClicked?.Invoke(sender, e); }
		private void OnRebootTargetPCButtonClicked(object sender, MouseEventArgs e) { RebootTargetPCButtonClicked?.Invoke(sender, e); }
		private void OnStartSimulationToggleButtonClicked(object sender, MouseEventArgs e) { StartSimulationToggleButtonClicked?.Invoke(sender, e); }
		private void OnUserEnteredStopTime(object sender, KeyEventArgs e)
		{
			double stopTime = -1;
			if (e.KeyCode == Keys.Enter)
			{
				try
				{
					stopTime = Convert.ToDouble(this.StopTimeRichTextBox.Text);
					if (stopTime <= 0) { throw new Exception(); }
				}
				catch
				{
					this.StopTimeRichTextBox.Text = "";
					stopTime = -1;
					System.Windows.Forms.MessageBox.Show("Stop Time entered was invalid!", "Invalid Log Time Entered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				finally
				{
					if (stopTime != -1)
					{
						StopTimeChangedEventArgs args = new StopTimeChangedEventArgs(stopTime);
						StopTimeTextChanged?.Invoke(sender, args);
					}
				}
			}
		}

		public void ChangeLoadApplicationToggleButtonState(bool isToggleButtonInDefaultState, bool isToggleButtonEnabled)
		{
			ToggleButtonStateChange(this.LoadModelToggleButton, isToggleButtonInDefaultState, isToggleButtonEnabled);
		}

		public void ChangeSimulationStartToggleButtonState(bool isToggleButtonInDefaultState, bool isToggleButtonEnabled)
		{
			ToggleButtonStateChange(this.StartSimulationToggleButton, isToggleButtonInDefaultState, isToggleButtonEnabled);;
		}

		public void ChangeRebootButtonState(bool isButtonEnabled)
		{
			ButtonStateChange(this.RebootTargetPCButton, isButtonEnabled);
		}

		public void ChangeLoadedModelRichTextBoxState(bool isRichTextBoxActive, bool clearTextOnDisable)
		{
			RichTextBoxStateChange(this.LoadedModelRichTextBox, isRichTextBoxActive, clearTextOnDisable);
		}

		public void ChangeStopTimeRichTextBoxState(bool isRichTextBoxActive, bool clearTextOnDisable)
		{
			RichTextBoxStateChange(this.StopTimeRichTextBox, isRichTextBoxActive, clearTextOnDisable);
		}

		public void UpdateApplicationProperties(ApplicationPropertiesChangedEventArgs applicationProperties)
		{
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.TargetStatusToolStripStatus, applicationProperties.LoadedApplicationProperties.TargetStatus.ToString());
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.AverageTetToolStripStatus, applicationProperties.LoadedApplicationProperties.AverageTeT.ToString("#.######"));
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.CpuOverloadedToolStripStatus, applicationProperties.LoadedApplicationProperties.CpuOverload.ToString());
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.ExecutionTimeToolStripStatus, applicationProperties.LoadedApplicationProperties.ExecutionTime.ToString("#.#"));

			RichTextBoxStateChange(this.LoadedModelRichTextBox, this.LoadedModelRichTextBox.Enabled, false, applicationProperties.LoadedApplicationProperties.LoadedModelName.ToString());

			UpdateToolStripStatusColor(applicationProperties.LoadedApplicationProperties.TargetStatus, applicationProperties.LoadedApplicationProperties.CpuOverload);
		}

		public void UpdateMaximumTeTValue(double maximumTeT)
		{
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.MaximumTetToolStripStatus, maximumTeT.ToString("#.######"));
		}

		public void UpdateStopTimeValue(double stopTime)
		{
			RichTextBoxStateChange(this.StopTimeRichTextBox, this.StopTimeRichTextBox.Enabled, false, stopTime.ToString("#.#"));
		}

		private void UpdateToolStripStatusColor(xPCAppStatus targetStatus, bool isCpuOverloaded)
		{
			if(isCpuOverloaded == true)
			{
				this.TargetApplicationStatusStrip.BackColor = ViewConstants.CPU_OVERLOADED_COLOR;
			}
			else
			{
				switch(targetStatus)
				{
					case xPCAppStatus.Running:
						this.TargetApplicationStatusStrip.BackColor = ViewConstants.SIMULATION_RUNNING_COLOR;
						break;
					case xPCAppStatus.Stopped:
						this.TargetApplicationStatusStrip.BackColor = ViewConstants.SIMULATION_STOPPED_COLOR;
						break;
					case xPCAppStatus.Starting:
						this.TargetApplicationStatusStrip.BackColor = ViewConstants.SIMULATION_STOPPED_COLOR;
						break;
				}
			}
		}
	}
}
