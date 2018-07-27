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
			if (e.KeyCode == Keys.Enter)
			{
				try
				{
					StopTimeChangedEventArgs args = new StopTimeChangedEventArgs(Convert.ToDouble(this.StopTimeRichTextBox.Text));
					StopTimeTextChanged?.Invoke(sender, args);
				}
				catch { }
			}
		}

		public void ChangeLoadModelToggleButtonState(bool isTargetConnected, bool isRealTimeFileLoadedInTextbox, bool isModelLoadedOnTarget)
		{
			LoadApplicationToggleButtonChange(this.LoadModelToggleButton, isTargetConnected, isRealTimeFileLoadedInTextbox, isModelLoadedOnTarget);
		}

		public void UpdateApplicationProperties(ApplicationPropertiesChangedEventArgs applicationProperties)
		{
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.TargetStatusToolStripStatus, applicationProperties.LoadedApplicationProperties.TargetStatus.ToString());
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.AverageTetToolStripStatus, applicationProperties.LoadedApplicationProperties.AverageTeT.ToString("#.######"));
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.CpuOverloadedToolStripStatus, applicationProperties.LoadedApplicationProperties.CpuOverload.ToString());
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.ExecutionTimeToolStripStatus, applicationProperties.LoadedApplicationProperties.ExecutionTime.ToString("#.#"));
			RichTextBoxTextChange(this.LoadedModelRichTextBox, applicationProperties.LoadedApplicationProperties.LoadedModelName.ToString());

			UpdateToolStripStatusColor(applicationProperties.LoadedApplicationProperties.TargetStatus, applicationProperties.LoadedApplicationProperties.CpuOverload);
		}

		public void UpdateMaximumTeTValue(double maximumTeT)
		{
			StatusStripValueChanged(this.TargetApplicationStatusStrip, this.MaximumTetToolStripStatus, maximumTeT.ToString("#.######"));
		}

		public void UpdateStopTimeValue(double stopTime)
		{
			RichTextBoxTextChange(this.StopTimeRichTextBox, stopTime.ToString("#.#"));
		}

		public void ChangeRebootButtonState(bool isTargetConnected)
		{
			TargetRebootButtonChange(this.RebootTargetPCButton, isTargetConnected);
		}

		public void ChangeSimulationStartToggleButtonState(bool isTargetConnected, bool isModelLoadedOnTarget, bool isTargetRunning)
		{
			StartSimulationToggleButtonChange(this.StartSimulationToggleButton, isTargetConnected, isModelLoadedOnTarget, isTargetRunning);
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
