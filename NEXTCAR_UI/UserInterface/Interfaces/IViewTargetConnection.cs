using NEXTCAR_UI.UserInterface.ViewObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Interfaces
{
	public interface IViewTargetConnection
	{
		event MouseEventHandler ConnectToggleButtonClicked;
		event EventHandler IPaddressTextChanged;
		event EventHandler PortTextChanged;

		void ChangeConnectToggleButtonState(bool isToggleButtonInDefaultState);
		void ChangeConnectionProperties(bool isRichTextBoxActive);
	}
}
