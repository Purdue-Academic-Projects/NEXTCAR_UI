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

		public IMainScreen MainScreen { get { return _mainScreen; } private set { _mainScreen = value; } }
		public ICanControlTargetConnection TargetConnection { get { return _targetConnection; } private set { _targetConnection = value; } }

		public CommunicationController(
			IMainScreen mainScreen,
			ICanControlTargetConnection targetConnection)
		{
			// Register needed models and views
			MainScreen = mainScreen;
			TargetConnection = targetConnection;

			// Subscribe to events
			MainScreen.ConnectToggleButtonClicked += new MouseEventHandler(HandleToggleButtonClicked);
			MainScreen.IPaddressTextChanged += new EventHandler(HandleIPaddressTextChanged);
			MainScreen.PortTextChanged += new EventHandler(HandlePortTextChanged);

			TargetConnection.TargetConnectionStateChanged 
				+= new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
		}

		private void HandleToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if(TargetConnection.IsTargetConnected == false) { TargetConnection.ConnectToTarget(); }
			else { TargetConnection.DisconnectFromTarget(); }
			
		}
		private void HandleIPaddressTextChanged(object sender, EventArgs args)
		{
			TargetConnection.TargetIPaddress = ((RichTextBox)sender).Text;
		}
		private void HandlePortTextChanged(object sender, EventArgs args)
		{
			TargetConnection.TargetPort = ((RichTextBox)sender).Text;
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			MainScreen.ChangeConnectionProperties(!args.IsTargetConnected);
			MainScreen.ChangeConnectToggleButtonState(!args.IsTargetConnected);
		}
	}
}
