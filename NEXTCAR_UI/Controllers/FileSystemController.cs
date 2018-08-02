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
	public class FileSystemController
	{
		private IMainScreen _mainScreen;
		private ICanControlTargetConnection _targetConnection;
		private ICanControlTargetFileSystem _targetFileSystem;
		private ICanLogData _dataLogManager;
		private ISimulationState _simulationState;

		public IMainScreen MainScreen { get { return _mainScreen; } private set { _mainScreen = value; } }
		public ICanControlTargetConnection TargetConnection { get { return _targetConnection; } private set { _targetConnection = value; } }
		public ICanControlTargetFileSystem TargetFileSystem { get { return _targetFileSystem; } private set { _targetFileSystem = value; } }
		public ICanLogData DataLogManager { get { return _dataLogManager; } private set { _dataLogManager = value; } }
		public ISimulationState SimulationState { get { return _simulationState; } private set { _simulationState = value; } }

		public FileSystemController(
			IMainScreen mainScreen, 
			ICanControlTargetConnection targetConnection, 
			ICanControlTargetFileSystem targetFileSystem, 
			ICanLogData dataLogManager,
			ISimulationState simulationState)
		{
			// Register needed models and views
			MainScreen = mainScreen;
			TargetConnection = targetConnection;
			TargetFileSystem = targetFileSystem;
			DataLogManager = dataLogManager;
			SimulationState = simulationState;

			// Subscribe to events
			MainScreen.LoadModelToggleButtonClicked += new MouseEventHandler(HandleLoadModelToggleButtonClicked);
			MainScreen.UseLogTimeCheckboxChanged += new EventHandler<UseLogTimeChangedEventArgs>(HandleUseLogTimeCheckboxChecked);
			MainScreen.UserEnteredLoggingTime += new EventHandler<LogTimeChangedEventArgs>(HandleUserEnteredLoggingTIme);
			MainScreen.StartLoggingToggleButtonClicked += new EventHandler(HandleStartLoggingToggleButtonClicked);

			TargetConnection.TargetConnectionStateChanged += new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
		}

		private void HandleLoadModelToggleButtonClicked(object sender, MouseEventArgs args)
		{
			ChangeLoggingControlStates();
		}

		private void HandleUseLogTimeCheckboxChecked(object sender, UseLogTimeChangedEventArgs args)
		{
			MainScreen.ChangeLoggingTimeRichTextBoxState(args.IsLoggingTimeSpecified, false);
			MainScreen.ChangeProgressBarState(args.IsLoggingTimeSpecified);
		}

		private void HandleUserEnteredLoggingTIme(object sender, LogTimeChangedEventArgs args)
		{
			DataLogManager.LoggingTime = args.LoggingTime;
		}

		private void HandleStartLoggingToggleButtonClicked(object sender, EventArgs args)
		{
			// Two possible conditions - either (1) user entered logging time and wants to log for a fixed time, or (2) user is 'free logging'
			// and could stop logging at any time. To add to (1), the user may also enter a fixed logging time, yet decide to stop logging
			// preemptively regardless (3). All three conditions need considered here.

			// Update the logging toggle button appearance

			
			// If logging data was entered and start button was clicked, lock the 'user enter log time' controls
			if(DataLogManager.LoggingTime != ModelConstants.DEFAULT_LOGGING_TIME)
			{

			}

		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			ChangeLoggingControlStates();
		}

		private void ChangeLoggingControlStates()
		{
			bool clearDataWhenDisabled = true;
			bool isLoggingControlsEnabled = TargetConnection.IsTargetConnected && SimulationState.IsModelLoadedOnTarget;
			MainScreen.ChangeControlLoggingTimeCheckBoxState(isLoggingControlsEnabled, clearDataWhenDisabled);
			MainScreen.ChangeLoggingToggleButtonEnableState(!DataLogManager.IsTargetLoggingData, isLoggingControlsEnabled);

			// If the host loses connection to the speedgoat target, disable these controls regardless of the current state
			if (!isLoggingControlsEnabled)
			{
				MainScreen.ChangeLoggingTimeRichTextBoxState(isLoggingControlsEnabled, clearDataWhenDisabled);
				MainScreen.ChangeProgressBarState(isLoggingControlsEnabled);
			}
		}
	}
}
