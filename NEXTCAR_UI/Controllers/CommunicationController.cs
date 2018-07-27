using NEXTCAR_UI.Business.Interfaces;
using NEXTCAR_UI.UserInterface.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.Controllers
{
	public class CommunicationController
	{
		private IMainScreen _mainScreen;
		private ICanControlTargetConnection _targetConnection;

		public CommunicationController(
			IMainScreen mainScreen,
			ICanControlTargetConnection targetConnection)
		{
			// Register needed models and views
			this._mainScreen = mainScreen;
			this._targetConnection = targetConnection;

			// Subscribe to events
			this._mainScreen.ConnectToggleButtonClicked += new MouseEventHandler(HandleToggleButtonClicked);
			this._mainScreen.IPaddressTextChanged += new EventHandler(HandleIPaddressTextChanged);
			this._mainScreen.PortTextChanged += new EventHandler(HandlePortTextChanged);

			this._targetConnection.TargetConnectionStateChanged 
				+= new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
		}

		private void HandleToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if(this._targetConnection.IsTargetConnected == false) { this._targetConnection.ConnectToTarget(); }
			else { this._targetConnection.DisconnectFromTarget(); }
			
		}
		private void HandleIPaddressTextChanged(object sender, EventArgs args)
		{
			this._targetConnection.TargetIPaddress = ((RichTextBox)sender).Text;
		}
		private void HandlePortTextChanged(object sender, EventArgs args)
		{
			this._targetConnection.TargetPort = ((RichTextBox)sender).Text;
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			this._mainScreen.ChangeConnectionToggleButtonState(args.IsTargetConnected);
		}
	}
}
