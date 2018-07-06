using NEXTCAR_UI.UserInterface.Interfaces;
using NEXTCAR_UI.UserInterface.ViewObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Views.MainScreen
{
    public partial class MainScreen : IViewTargetConnection
	{
		public event MouseEventHandler ConnectToggleButtonClicked;
		public event EventHandler IPaddressTextChanged;
		public event EventHandler PortTextChanged;

		private void OnConnectToggleButtonClicked(object sender, MouseEventArgs e) { ConnectToggleButtonClicked?.Invoke(sender, e); }
		private void OnIPaddressTextChanged(object sender, EventArgs e) { IPaddressTextChanged?.Invoke(sender, e); }
		private void OnPortTextChanged(object sender, EventArgs e) { PortTextChanged?.Invoke(sender, e); }

		public void ChangeConnectionToggleButtonState(bool isTargetConnected)
		{
			ConnectionToggleStateChange(this.ConnectToggleButton, isTargetConnected);
		}
	}
}
