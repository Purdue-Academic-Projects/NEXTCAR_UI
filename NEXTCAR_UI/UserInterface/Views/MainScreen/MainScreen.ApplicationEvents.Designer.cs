using NEXTCAR_UI.Business.Interfaces;
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

		private void OnLoadModelToggleButtonClicked(object sender, MouseEventArgs e) { LoadModelToggleButtonClicked?.Invoke(sender, e); }
		private void OnRebootTargetPCButtonClicked(object sender, MouseEventArgs e) { RebootTargetPCButtonClicked?.Invoke(sender, e); }
		private void OnStartSimulationToggleButtonClicked(object sender, MouseEventArgs e) { StartSimulationToggleButtonClicked?.Invoke(sender, e); }

		public void ChangeLoadModelToggleButtonState(bool isTargetConnected, bool isRealTimeFileLoadedInTextbox, bool isModelLoadedOnTarget)
		{
			LoadApplicationToggleButtonChange(this.LoadModelToggleButton, isTargetConnected, isRealTimeFileLoadedInTextbox, isModelLoadedOnTarget);
		}

		public void UpdateApplicationProperties(ApplicationPropertiesChangedEventArgs applicationProperties)
		{
			RichTextBoxTextChange(this.AverageTeTRichTextBox, applicationProperties.AverageTeT.ToString());
			RichTextBoxTextChange(this.MaximumTeTRichTextBox, applicationProperties.MaximumTeT.ToString());
			RichTextBoxTextChange(this.CPUOverloadRichTextBox, applicationProperties.CpuOverload.ToString());
			RichTextBoxTextChange(this.ExecutionTimeRichTextBox, applicationProperties.ExecutionTime.ToString());
			RichTextBoxTextChange(this.LoadedModelRichTextBox, applicationProperties.LoadedModelName.ToString());
			RichTextBoxTextChange(this.StopTimeLabelRichTextBox, applicationProperties.StopTime.ToString());
		}

		public void ChangeRebootButtonState(bool isTargetConnected)
		{
			TargetRebootButtonChange(this.RebootTargetPCButton, isTargetConnected);
		}

		public void ChangeSimulationStartToggleButtonState(bool isTargetConnected, bool isModelLoadedOnTarget, bool isTargetRunning)
		{
			StartSimulationToggleButtonChange(this.StartSimulationToggleButton, isTargetConnected, isModelLoadedOnTarget, isTargetRunning);
		}
	}
}
