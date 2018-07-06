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
			this._targetConnection.TargetConnectionStateChanged += 
				new EventHandler<TargetConnectionStateChangedEventArgs>(HandleTargetConnectionStateChanged);
			this._targetApplication.ApplicationPropertiesChanged += 
				new EventHandler<ApplicationPropertiesChangedEventArgs>(HandleApplicationPropertiesChanged);
		}

		private void HandleLoadModelToggleButtonClicked(object sender, MouseEventArgs args)
		{
			if(this._targetApplication.LoadedModelName == null)
			{
				this._targetApplication.LoadTargetApplication(this._targetConnection, this._realTimeModel.RealTimeModelFilePath);
				this._mainScreen.ChangeLoadModelToggleButtonState(this._targetApplication.LoadedModelName);
			}
			else
			{
				this._targetApplication.UnloadTargetApplication(this._targetConnection);
				this._mainScreen.ChangeLoadModelToggleButtonState(this._targetApplication.LoadedModelName);
			}
		}

		private void HandleTargetConnectionStateChanged(object sender, TargetConnectionStateChangedEventArgs args)
		{
			if(this._targetConnection.IsTargetConnected == true && this._targetApplication.LoadedModelName != null)
			{
				this._targetApplication.StartPropertyUpdatesTimer();
			}
			else
			{
				this._targetApplication.StopPropertyUpdatesTimer();
			}
		}

		private void HandleApplicationPropertiesChanged(object sender, ApplicationPropertiesChangedEventArgs args)
		{

		}
	}
}
