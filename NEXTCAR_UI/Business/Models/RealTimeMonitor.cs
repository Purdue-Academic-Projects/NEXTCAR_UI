using NEXTCAR_UI.Business.Containers;
using NEXTCAR_UI.Business.Interfaces;
using NEXTCAR_UI.DataClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NEXTCAR_UI.Business.Models
{
	public class RealTimeMonitor : ICanMonitorRealTime
	{
		private IHasLoadedApplicationState _applicationState = new LoadedApplicationState();
		private Timer propertyUpdateTimer;

		public IHasLoadedApplicationState ApplicationState
		{
			get { return _applicationState; }
			set
			{
				if (_applicationState != value)
				{
					_applicationState = value;
					OnApplicationStateChanged(value);
				}
			}
		}

		public event EventHandler<ApplicationPropertiesChangedEventArgs> ApplicationPropertiesChanged;
		public event EventHandler PropertyUpdateTimerElapsed;

		public void StartPropertyUpdatesTimer()
		{
			propertyUpdateTimer = new System.Timers.Timer();
			propertyUpdateTimer.Interval = ModelConstants.APPLICATION_PROPERTY_UPDATE_INTERVAL;
			propertyUpdateTimer.Elapsed += OnIntervalElapsed;
			propertyUpdateTimer.Enabled = true;
		}

		public void StopPropertyUpdatesTimer()
		{
			if (propertyUpdateTimer != null) { propertyUpdateTimer.Enabled = false; }
		}

		private void OnApplicationStateChanged(IHasLoadedApplicationState applicationState)
		{
			ApplicationPropertiesChangedEventArgs args = new ApplicationPropertiesChangedEventArgs(applicationState);
			ApplicationPropertiesChanged?.Invoke(this, args);
		}

		private void OnIntervalElapsed(Object source, System.Timers.ElapsedEventArgs e)
		{
			PropertyUpdateTimerElapsed?.Invoke(this, e);
		}
	}
}
