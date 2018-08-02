using NEXTCAR_UI.Business.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.UserInterface.Interfaces
{
	public interface IViewLogging
	{
		event EventHandler<LogTimeChangedEventArgs> UserEnteredLoggingTime;
		event EventHandler<UseLogTimeChangedEventArgs> UseLogTimeCheckboxChanged;
		event EventHandler StartLoggingToggleButtonClicked;

		void ChangeControlLoggingTimeCheckBoxState(bool isEnabled, bool clearDataIfDisabled);
		void ChangeLoggingToggleButtonEnableState(bool isToggleButtonInDefaultState, bool isToggleButtonEnabled);
		void ChangeLoggingTimeRichTextBoxState(bool isRichTextBoxActive, bool clearTextOnDisable, string newRichTextBoxText=null);
		void ChangeProgressBarState(bool isVisible);
	}
}
