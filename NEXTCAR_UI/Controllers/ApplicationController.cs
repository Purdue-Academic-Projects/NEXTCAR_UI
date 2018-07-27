using MathWorks.xPCTarget.FrameWork;

using NEXTCAR_UI.Business.Containers;
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
		private ICanControlTargetConnection _targetConnection;
		private IHasModelLocation _realTimeModelProperties;
		private ICanMonitorRealTime _realTimeMonitor;
		private ISimulationState _simulationState;

		public ApplicationController(
			IMainScreen mainScreen,
			ICanControlTargetConnection targetConnection,
			IHasModelLocation realTimeModelProperties,
			ICanMonitorRealTime realTimeMonitor,
			ISimulationState simulationState)
		{
			// Register needed models and views
			this._mainScreen = mainScreen;
			this._targetConnection = targetConnection;
			this._realTimeModelProperties = realTimeModelProperties;
			this._realTimeMonitor = realTimeMonitor;
			this._simulationState = simulationState;

			// Subscribe to events
			this._mainScreen.LoadModelToggleButtonClicked += new MouseEventHandler(HandleLoadModelToggleButtonClicked);
			this._mainScreen.RebootTargetPCButtonClicked += new MouseEventHandler(HandleRebootTargetPCButtonClicked);
			this._mainScreen.StartSimulationToggleButtonClicked += new MouseEventHandler(HandleStartSimulationToggleButtonClicked);
			this._mainScreen.StopTimeTextChanged += new EventHandler<StopTimeChangedEventArgs>(HandleStopTimeTextChanged);
			this._targetConnection.TargetConnectionStateChanged += 
				new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
			this._realTimeMonitor.ApplicationPropertiesChanged +=
				new EventHandler<ApplicationPropertiesChangedEventArgs>(HandleApplicationPropertiesChanged);
			this._realTimeMonitor.PropertyUpdateTimerElapsed += new EventHandler(HandlePropertyUpdateTimerElapsed);
			this._simulationState.MaximumTeTChanged += new EventHandler<MaximumTeTChangedEventArgs>(HandleMaximumTeTChanged);
			this._simulationState.StopTimeChanged += new EventHandler<StopTimeChangedEventArgs>(HandleStopTimeChanged);
		}

		private void HandleLoadModelToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if (this._simulationState.IsModelLoadedOnTarget)
			{
				this._simulationState.UnloadRealTimeModel(this._targetConnection);
				this._realTimeMonitor.ApplicationState.ResetApplicationState();
			}
			else
			{
				this._simulationState.LoadRealTimeModel(this._targetConnection, this._realTimeModelProperties.RealTimeModelFilePath);
				this._realTimeMonitor.ApplicationState = new LoadedApplicationState(this._simulationState.LoadedApplication);
			}

			this._mainScreen.ChangeLoadModelToggleButtonState(
				this._targetConnection.IsTargetConnected,
				this._realTimeModelProperties.IsModelLocationLoaded,
				this._simulationState.IsModelLoadedOnTarget);
			this._mainScreen.ChangeSimulationStartToggleButtonState(
				this._targetConnection.IsTargetConnected,
				this._simulationState.IsModelLoadedOnTarget,
				this._simulationState.IsSimulationRunning);
		}

		private void HandleRebootTargetPCButtonClicked(object sender, MouseEventArgs args)
		{
			this._targetConnection.RebootTargetPC();
		}

		private void HandleStartSimulationToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if(this._simulationState.IsSimulationRunning == true) { this._simulationState.StopTargetApplication(); }
			else
			{
				this._simulationState.StartTargetApplication();
				this._realTimeMonitor.StartPropertyUpdatesTimer();
			}
			this._mainScreen.ChangeSimulationStartToggleButtonState(
				this._targetConnection.IsTargetConnected,
				this._simulationState.IsModelLoadedOnTarget,
				this._simulationState.IsSimulationRunning);
		}

		private void HandleStopTimeTextChanged(object sender, StopTimeChangedEventArgs args)
		{
			this._simulationState.StopTime = args.StopTime;
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			if (this._targetConnection.IsTargetConnected == false)
			{
				this._realTimeMonitor.ApplicationState.ResetApplicationState();
				this._simulationState.ResetSimulationProperties();
			}

			this._mainScreen.ChangeRebootButtonState(this._targetConnection.IsTargetConnected);
			this._mainScreen.ChangeSimulationStartToggleButtonState(
				this._targetConnection.IsTargetConnected,
				this._simulationState.IsModelLoadedOnTarget, 
				this._simulationState.IsSimulationRunning);
		}

		private void HandlePropertyUpdateTimerElapsed(object sender, EventArgs args)
		{
			this._realTimeMonitor.ApplicationState = new LoadedApplicationState(this._simulationState.LoadedApplication);
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
