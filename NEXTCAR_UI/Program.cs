using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using NEXTCAR_UI.Business;
using NEXTCAR_UI.Business.Models;
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
			TargetCommunication targetConnection = new TargetCommunication();
			RealTimeModel realTimeModelProperties = new RealTimeModel();
			RealTimeMonitor realTimeMonitor = new RealTimeMonitor();
			SimulationEnvironment simulationState = new SimulationEnvironment();

			CommunicationController communicationController = new CommunicationController(mainScreen, targetConnection);
			RealTimeModelController realTimeModelController = new RealTimeModelController(mainScreen, targetConnection, realTimeModelProperties, simulationState);
			ApplicationController applicationController = new ApplicationController(mainScreen, targetConnection, realTimeModelProperties, realTimeMonitor, simulationState);

			Application.Run(mainScreen);
		}
	}
}
