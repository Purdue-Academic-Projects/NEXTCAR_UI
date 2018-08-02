using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface ICanLogData
	{
		double LoggingTime { get; set; }
		bool IsTargetLoggingData { get; set; }
	}

	public class UseLogTimeChangedEventArgs : EventArgs
	{
		private bool _isLoggingTimeSpecified;
		public bool IsLoggingTimeSpecified { get { return _isLoggingTimeSpecified; } private set { _isLoggingTimeSpecified = value; } }

		public UseLogTimeChangedEventArgs(bool isLoggingTimeSpecified)
		{
			IsLoggingTimeSpecified = isLoggingTimeSpecified;
		}
	}

	public class LogTimeChangedEventArgs : EventArgs
	{
		private double _loggingTime;
		public double LoggingTime { get { return _loggingTime; } private set { _loggingTime = value; } }

		public LogTimeChangedEventArgs(double loggingTime)
		{
			LoggingTime = loggingTime;
		}
	}
}
