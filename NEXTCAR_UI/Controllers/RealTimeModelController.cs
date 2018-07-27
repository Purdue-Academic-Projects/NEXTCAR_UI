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

		public RealTimeModelController(
			IMainScreen mainScreen,
			ICanControlTargetConnection targetConnection,
			IHasModelLocation realTimeModelProperties,
			ISimulationState simulationState)
		{
			// Register needed models and views
			this._mainScreen = mainScreen;
			this._targetConnection = targetConnection;
			this._realTimeModelProperties = realTimeModelProperties;
			this._simulationState = simulationState;

			// Subscribe to events
			this._mainScreen.BrowseForModelFileButtonClicked += new MouseEventHandler(HandleBrowseForModelFileButtonClicked);

			this._targetConnection.TargetConnectionStateChanged += new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
			this._realTimeModelProperties.RealTimeModelLocationChanged += new EventHandler(HandleRealTimeModelLocationChanged);
		}

		private void HandleBrowseForModelFileButtonClicked(object sender, MouseEventArgs args)
		{
			this._realTimeModelProperties.BrowseForModel();
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			this._mainScreen.ChangeLoadModelToggleButtonState(this._targetConnection.IsTargetConnected,
																this._realTimeModelProperties.IsModelLocationLoaded,
																this._simulationState.IsModelLoadedOnTarget);
		}

		// FIX ME
		private void HandleRealTimeModelLocationChanged(object sender, EventArgs args)
		{
			this._mainScreen.UpdateRealTimeModelLocationTextBox(this._realTimeModelProperties.RealTimeModelFilePath);
			if(this._realTimeModelProperties.RealTimeModelFilePath != null)
			{
				if (this._realTimeModelProperties.RealTimeModelFilePath.Contains(ModelConstants.REAL_TIME_MODEL_FILE_EXTENSION)==true)
				{
					this._mainScreen.ChangeBuildModelButtonState(false);
				}
				else if(this._realTimeModelProperties.RealTimeModelFilePath.Contains(ModelConstants.SIMULINK_FILE_EXTENSION)==true)
				{
					this._mainScreen.ChangeBuildModelButtonState(true);
				}
				else
				{
					this._mainScreen.ChangeBuildModelButtonState(false);
				}
			}
			this._mainScreen.ChangeLoadModelToggleButtonState(this._targetConnection.IsTargetConnected,
													this._realTimeModelProperties.IsModelLocationLoaded,
													this._simulationState.IsModelLoadedOnTarget);
		}
	}
}
