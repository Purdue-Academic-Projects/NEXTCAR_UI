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
	public class RealTimeModelController
	{
		private IMainScreen _mainScreen;
		private ICanControlTargetConnection _targetConnection;
		private IHasModelLocation _realTimeModelProperties;
		private ISimulationState _simulationState;

		public IMainScreen MainScreen { get { return _mainScreen; } private set { _mainScreen = value; } }
		public ICanControlTargetConnection TargetConnection { get { return _targetConnection; } private set { _targetConnection = value; } }
		public IHasModelLocation RealTimeModelProperties { get { return _realTimeModelProperties; } private set { _realTimeModelProperties = value; } }
		public ISimulationState SimulationState { get { return _simulationState; } private set { _simulationState = value; } }

		public RealTimeModelController(
			IMainScreen mainScreen,
			ICanControlTargetConnection targetConnection,
			IHasModelLocation realTimeModelProperties,
			ISimulationState simulationState)
		{
			// Register needed models and views
			MainScreen = mainScreen;
			TargetConnection = targetConnection;
			RealTimeModelProperties = realTimeModelProperties;
			SimulationState = simulationState;

			// Subscribe to events
			MainScreen.BrowseForModelFileButtonClicked += new MouseEventHandler(HandleBrowseForModelFileButtonClicked);
			TargetConnection.TargetConnectionStateChanged += new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
			RealTimeModelProperties.RealTimeModelLocationChanged += new EventHandler(HandleRealTimeModelLocationChanged);
		}

		private void HandleBrowseForModelFileButtonClicked(object sender, MouseEventArgs args)
		{
			RealTimeModelProperties.BrowseForModel();
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			ChangeLoadApplicationControls();
		}

		// FIX ME
		private void HandleRealTimeModelLocationChanged(object sender, EventArgs args)
		{
			MainScreen.UpdateRealTimeModelLocationTextBox(this._realTimeModelProperties.RealTimeModelFilePath);
			if(RealTimeModelProperties.RealTimeModelFilePath != null)
			{
				if (RealTimeModelProperties.RealTimeModelFilePath.Contains(ModelConstants.REAL_TIME_MODEL_FILE_EXTENSION)==true)
				{
					MainScreen.ChangeBuildModelButtonState(false);
				}
				else if(RealTimeModelProperties.RealTimeModelFilePath.Contains(ModelConstants.SIMULINK_FILE_EXTENSION)==true)
				{
					MainScreen.ChangeBuildModelButtonState(true);
				}
				else
				{
					MainScreen.ChangeBuildModelButtonState(false);
				}
			}

			ChangeLoadApplicationControls();
		}

		private void ChangeLoadApplicationControls()
		{
			bool clearDataWhenDisabled = true;
			bool isLoadApplicationToggleButtonEnabled = TargetConnection.IsTargetConnected && RealTimeModelProperties.IsModelLocationLoaded;
			bool isLoadedModelRichTextBoxEnable = TargetConnection.IsTargetConnected && SimulationState.IsModelLoadedOnTarget;
			MainScreen.ChangeLoadApplicationToggleButtonState(SimulationState.IsModelLoadedOnTarget, isLoadApplicationToggleButtonEnabled);
			MainScreen.ChangeLoadedModelRichTextBoxState(isLoadedModelRichTextBoxEnable, clearDataWhenDisabled);
			MainScreen.ChangeStopTimeRichTextBoxState(isLoadedModelRichTextBoxEnable, clearDataWhenDisabled);
		}
	}
}
