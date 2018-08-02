using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface ICanMonitorRealTime
	{
		IHasLoadedApplicationState ApplicationState { get; set; }

		void StartPropertyUpdatesTimer();
		void StopPropertyUpdatesTimer();

		event EventHandler<ApplicationPropertiesChangedEventArgs> ApplicationPropertiesChanged;
		event EventHandler PropertyUpdateTimerElapsed;
	}

	public class ApplicationPropertiesChangedEventArgs : EventArgs
	{
		private IHasLoadedApplicationState _loadedApplicationProperties;
		public IHasLoadedApplicationState LoadedApplicationProperties { get { return _loadedApplicationProperties; } private set { _loadedApplicationProperties = value; } }

		public ApplicationPropertiesChangedEventArgs(IHasLoadedApplicationState loadedApplicationProperties)
		{
			LoadedApplicationProperties = loadedApplicationProperties;
		}
	}
}
