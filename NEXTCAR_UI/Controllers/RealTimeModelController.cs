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
		private ITargetConnection _targetConnection;
		private IModelProperties _realTimeModel;

		public RealTimeModelController(
			IMainScreen mainScreen,
			ITargetConnection targetConnection,
			IModelProperties realTimeModel)
		{
			// Register needed models and views
			this._mainScreen = mainScreen;
			this._targetConnection = targetConnection;
			this._realTimeModel = realTimeModel;

			// Subscribe to events
			this._mainScreen.BrowseForModelFileButtonClicked += new MouseEventHandler(HandleBrowseForModelFileButtonClicked);

			this._targetConnection.TargetConnectionStateChanged += new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
			this._realTimeModel.RealTimeModelLocationChanged += new EventHandler(HandleRealTimeModelLocationChanged);
		}

		private void HandleBrowseForModelFileButtonClicked(object sender, MouseEventArgs args)
		{
			this._realTimeModel.BrowseForModel();
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			if(args.IsTargetConnected==false) { this._mainScreen.ChangeLoadModelButtonState(false); }
		}

		private void HandleRealTimeModelLocationChanged(object sender, EventArgs args)
		{
			this._mainScreen.UpdateRealTimeModelLocationTextBox(this._realTimeModel.RealTimeModelFilePath);
			if(this._realTimeModel.RealTimeModelFilePath != null)
			{
				if(this._realTimeModel.RealTimeModelFilePath.Contains(ModelConstants.REAL_TIME_MODEL_FILE_EXTENSION)==true)
				{
					if(_targetConnection.IsTargetConnected == true)
					{
						this._mainScreen.ChangeBuildModelButtonState(false);
						this._mainScreen.ChangeLoadModelButtonState(true);
					}
				}
				else if(this._realTimeModel.RealTimeModelFilePath.Contains(ModelConstants.SIMULINK_FILE_EXTENSION)==true)
				{
					this._mainScreen.ChangeBuildModelButtonState(true);
					this._mainScreen.ChangeLoadModelButtonState(false);
				}
				else
				{
					this._mainScreen.ChangeBuildModelButtonState(false);
					this._mainScreen.ChangeLoadModelButtonState(false);
				}
			}

		}
	}
}
