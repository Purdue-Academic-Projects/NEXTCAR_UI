using NEXTCAR_UI.Business.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Interfaces
{
	public interface IViewApplication
	{
		event MouseEventHandler LoadModelToggleButtonClicked;
		event MouseEventHandler RebootTargetPCButtonClicked;
		event MouseEventHandler StartSimulationToggleButtonClicked;
		event EventHandler<StopTimeChangedEventArgs> StopTimeTextChanged;

		void ChangeLoadApplicationToggleButtonState(bool isToggleButtonInDefaultState, bool isToggleButtonEnabled);
		void ChangeSimulationStartToggleButtonState(bool isToggleButtonInDefaultState, bool isToggleButtonEnabled);
		void ChangeRebootButtonState(bool isButtonEnabled);
		void ChangeLoadedModelRichTextBoxState(bool isRichTextBoxActive, bool clearTextOnDisable);
		void ChangeStopTimeRichTextBoxState(bool isRichTextBoxActive, bool clearTextOnDisable);
		void UpdateApplicationProperties(ApplicationPropertiesChangedEventArgs applicationProperties);
		void UpdateMaximumTeTValue(double maximumTeT);
		void UpdateStopTimeValue(double stopTime);
	}
}
