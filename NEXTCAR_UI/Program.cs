using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using NEXTCAR_UI.Business;
using NEXTCAR_UI.Controllers;
using NEXTCAR_UI.UserInterface.Views.MainScreen;

namespace NEXTCAR_UI
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			MainScreen mainScreen = new MainScreen();
			TargetCommunication targetCommunication = new TargetCommunication();
			RealTimeModel realTimeModel = new RealTimeModel();
			TargetApplication targetApplication = new TargetApplication();

			CommunicationController communicationController = new CommunicationController(mainScreen, targetCommunication);
			RealTimeModelController realTimeModelController = new RealTimeModelController(mainScreen, targetCommunication, realTimeModel, targetApplication);
			ApplicationController applicationController = new ApplicationController(mainScreen, targetCommunication, realTimeModel, targetApplication);

			Application.Run(mainScreen);
		}
	}
}
