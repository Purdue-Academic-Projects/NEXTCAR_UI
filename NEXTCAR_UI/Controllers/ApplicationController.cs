using MathWorks.xPCTarget.FrameWork;

using NEXTCAR_UI.Business.Containers;
using NEXTCAR_UI.Business.Interfaces;
using NEXTCAR_UI.DataClasses;
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

		public IMainScreen MainScreen { get { return _mainScreen; } private set { _mainScreen = value; } }
		public ICanControlTargetConnection TargetConnection { get { return _targetConnection; } private set { _targetConnection = value; } }
		public IHasModelLocation RealTimeModelProperties { get { return _realTimeModelProperties; } private set { _realTimeModelProperties = value; } }
		public ICanMonitorRealTime RealTimeMonitor { get { return _realTimeMonitor; } private set { _realTimeMonitor = value; } }
		public ISimulationState SimulationState { get { return _simulationState; } private set { _simulationState = value; } }

		public ApplicationController(
			IMainScreen mainScreen,
			ICanControlTargetConnection targetConnection,
			IHasModelLocation realTimeModelProperties,
			ICanMonitorRealTime realTimeMonitor,
			ISimulationState simulationState)
		{
			// Register needed models and views
			MainScreen = mainScreen;
			TargetConnection = targetConnection;
			RealTimeModelProperties = realTimeModelProperties;
			RealTimeMonitor = realTimeMonitor;
			SimulationState = simulationState;

			// Subscribe to events
			MainScreen.LoadModelToggleButtonClicked += new MouseEventHandler(HandleLoadModelToggleButtonClicked);
			MainScreen.RebootTargetPCButtonClicked += new MouseEventHandler(HandleRebootTargetPCButtonClicked);
			MainScreen.StartSimulationToggleButtonClicked += new MouseEventHandler(HandleStartSimulationToggleButtonClicked);
			MainScreen.StopTimeTextChanged += new EventHandler<StopTimeChangedEventArgs>(HandleStopTimeTextChanged);
			TargetConnection.TargetConnectionStateChanged += 
				new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
			RealTimeMonitor.ApplicationPropertiesChanged +=
				new EventHandler<ApplicationPropertiesChangedEventArgs>(HandleApplicationPropertiesChanged);
			RealTimeMonitor.PropertyUpdateTimerElapsed += new EventHandler(HandlePropertyUpdateTimerElapsed);
			SimulationState.MaximumTeTChanged += new EventHandler<MaximumTeTChangedEventArgs>(HandleMaximumTeTChanged);
			SimulationState.StopTimeChanged += new EventHandler<StopTimeChangedEventArgs>(HandleStopTimeChanged);
		}

		private void HandleLoadModelToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if (SimulationState.IsModelLoadedOnTarget)
			{
				// If the model is already loaded, unload the model and clear the corresponding application data
				SimulationState.UnloadRealTimeModel(TargetConnection);
				RealTimeMonitor.ApplicationState.ResetApplicationState();
				RealTimeMonitor.StopPropertyUpdatesTimer();
			}
			else
			{
				// Otherwise, load the model and create a new application state
				SimulationState.LoadRealTimeModel(TargetConnection, RealTimeModelProperties.RealTimeModelFilePath);
				RealTimeMonitor.ApplicationState = new LoadedApplicationState(SimulationState.LoadedApplication);
			}

			bool clearDataWhenDisabled = true;
			bool isLoadApplicationToggleButtonEnabled = TargetConnection.IsTargetConnected && RealTimeModelProperties.IsModelLocationLoaded;
			bool isApplicationControlsEnabled = TargetConnection.IsTargetConnected && SimulationState.IsModelLoadedOnTarget;
			MainScreen.ChangeLoadApplicationToggleButtonState(SimulationState.IsModelLoadedOnTarget, isLoadApplicationToggleButtonEnabled);
			MainScreen.ChangeLoadedModelRichTextBoxState(isApplicationControlsEnabled, clearDataWhenDisabled);
			MainScreen.ChangeStopTimeRichTextBoxState(isApplicationControlsEnabled, clearDataWhenDisabled);
			MainScreen.ChangeSimulationStartToggleButtonState(!SimulationState.IsSimulationRunning, isApplicationControlsEnabled);
		}

		private void HandleRebootTargetPCButtonClicked(object sender, MouseEventArgs args)
		{
			TargetConnection.RebootTargetPC();
		}

		private void HandleStartSimulationToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if(SimulationState.IsSimulationRunning) { SimulationState.StopTargetApplication(); }
			else
			{
				SimulationState.StartTargetApplication();
				RealTimeMonitor.StartPropertyUpdatesTimer();
			}

			bool isSimulationStartToggleButtonEnabled = TargetConnection.IsTargetConnected && SimulationState.IsModelLoadedOnTarget;
			MainScreen.ChangeSimulationStartToggleButtonState(!SimulationState.IsSimulationRunning, isSimulationStartToggleButtonEnabled);

			// Update this at the start of every simulation in case the user removed it
			MainScreen.UpdateStopTimeValue(SimulationState.StopTime);
		}

		private void HandleStopTimeTextChanged(object sender, StopTimeChangedEventArgs args)
		{
			SimulationState.StopTime = args.StopTime;
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			if (TargetConnection.IsTargetConnected == false)
			{
				RealTimeMonitor.ApplicationState.ResetApplicationState();
				SimulationState.ResetSimulationProperties();
				RealTimeMonitor.StopPropertyUpdatesTimer();
			}

			bool isSimulationStartToggleButtonEnabled = TargetConnection.IsTargetConnected && SimulationState.IsModelLoadedOnTarget;
			MainScreen.ChangeSimulationStartToggleButtonState(!SimulationState.IsSimulationRunning, isSimulationStartToggleButtonEnabled);
			MainScreen.ChangeRebootButtonState(TargetConnection.IsTargetConnected);
		}

		private void HandlePropertyUpdateTimerElapsed(object sender, EventArgs args)
		{
			RealTimeMonitor.ApplicationState = new LoadedApplicationState(SimulationState.LoadedApplication);
		}

		private void HandleApplicationPropertiesChanged(object sender, ApplicationPropertiesChangedEventArgs args)
		{
			MainScreen.UpdateApplicationProperties(args);

			if(SimulationState.IsSimulationRunning)
			{
				// If target stopped automatically due to time stop or CPU exception, change control states as if the 
				// user had clicked "Stop Simulation"
				bool isValidStopTimeReached = (args.LoadedApplicationProperties.ExecutionTime >= SimulationState.StopTime) &&
					(SimulationState.StopTime != ModelConstants.INFINITE_STOP_TIME);
				if (isValidStopTimeReached || args.LoadedApplicationProperties.CpuOverload)
				{
					MouseEventArgs newArgs = new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0);
					HandleStartSimulationToggleButtonClicked(this, newArgs);
				}
			}
		}

		private void HandleMaximumTeTChanged(object sender, MaximumTeTChangedEventArgs args)
		{
			MainScreen.UpdateMaximumTeTValue(args.MaximumTeT);
		}

		private void HandleStopTimeChanged(object sender, StopTimeChangedEventArgs args)
		{
			MainScreen.UpdateStopTimeValue(args.StopTime);
		}
	}
}
