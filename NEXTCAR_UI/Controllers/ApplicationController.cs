using MathWorks.xPCTarget.FrameWork;

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
	public class ApplicationController
	{
		private IMainScreen _mainScreen;
		private ITargetConnection _targetConnection;
		private IModelProperties _realTimeModel;
		private IApplicationProperties _targetApplication;
		
		public ApplicationController(
			IMainScreen mainScreen, 
			ITargetConnection targetConnection,
			IModelProperties realTimeModel,
			IApplicationProperties targetApplication)
		{
			// Register needed models and views
			this._mainScreen = mainScreen;
			this._targetConnection = targetConnection;
			this._realTimeModel = realTimeModel;
			this._targetApplication = targetApplication;

			// Subscribe to events
			this._mainScreen.LoadModelToggleButtonClicked += new MouseEventHandler(HandleLoadModelToggleButtonClicked);
			this._mainScreen.RebootTargetPCButtonClicked += new MouseEventHandler(HandleRebootTargetPCButtonClicked);
			this._mainScreen.StartSimulationToggleButtonClicked += new MouseEventHandler(HandleStartSimulationToggleButtonClicked);
			this._targetConnection.TargetConnectionStateChanged += 
				new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
			this._targetApplication.ApplicationPropertiesChanged += 
				new EventHandler<ApplicationPropertiesChangedEventArgs>(HandleApplicationPropertiesChanged);
			this._targetApplication.MaximumTeTChanged += new EventHandler<MaximumTeTChangedEventArgs>(HandleMaximumTeTChanged);
			this._targetApplication.StopTimeChanged += new EventHandler<StopTimeChangedEventArgs>(HandleStopTimeChanged);
		}

		private void HandleLoadModelToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if (this._targetApplication.IsModelLoadedOnTarget)
			{
				this._targetApplication.UnloadTargetApplication(this._targetConnection);
			}
			else
			{
				this._targetApplication.LoadTargetApplication(this._targetConnection, this._realTimeModel.RealTimeModelFilePath);
			}
			this._mainScreen.ChangeLoadModelToggleButtonState(
				this._targetConnection.IsTargetConnected,
				this._realTimeModel.IsRealTimeFileLoadedInTextbox,
				this._targetApplication.IsModelLoadedOnTarget);
			this._mainScreen.ChangeSimulationStartToggleButtonState(
				this._targetConnection.IsTargetConnected,
				this._targetApplication.IsModelLoadedOnTarget,
				this._targetApplication.IsSimulationRunning);
		}

		private void HandleRebootTargetPCButtonClicked(object sender, MouseEventArgs args)
		{
			this._targetConnection.RebootTargetPC();
		}

		private void HandleStartSimulationToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if(this._targetApplication.IsSimulationRunning == true) { this._targetApplication.StopSimulation(); }
			else { this._targetApplication.StartSimulation(); }
			this._mainScreen.ChangeSimulationStartToggleButtonState(
				this._targetConnection.IsTargetConnected,
				this._targetApplication.IsModelLoadedOnTarget,
				this._targetApplication.IsSimulationRunning);
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			if (!this._targetConnection.IsTargetConnected) { this._targetApplication.ResetApplicationProperties(); }
			this._mainScreen.ChangeRebootButtonState(this._targetConnection.IsTargetConnected);
			this._mainScreen.ChangeSimulationStartToggleButtonState(
				this._targetConnection.IsTargetConnected,
				this._targetApplication.IsModelLoadedOnTarget, 
				this._targetApplication.IsSimulationRunning);
		}

		private void HandleApplicationPropertiesChanged(object sender, ApplicationPropertiesChangedEventArgs args)
		{
			this._mainScreen.UpdateApplicationProperties(args);
		}

		private void HandleMaximumTeTChanged(object sender, MaximumTeTChangedEventArgs args)
		{
			this._mainScreen.UpdateMaximumTeTValue(args.MaximumTeT);
		}

		private void HandleStopTimeChanged(object sender, StopTimeChangedEventArgs args)
		{
			this._mainScreen.UpdateStopTimeValue(args.StopTime);
		}
	}
}
