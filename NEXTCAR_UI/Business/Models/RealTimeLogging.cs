using NEXTCAR_UI.Business.Interfaces;
using NEXTCAR_UI.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Models
{
	public class RealTimeLogging : ICanLogData
	{
		private double _loggingTime = ModelConstants.DEFAULT_LOGGING_TIME;
		private bool _isTargetLoggingData;

		public double LoggingTime { get { return _loggingTime; } set { _loggingTime = value; } }
		public bool IsTargetLoggingData { get { return _isTargetLoggingData; } set { _isTargetLoggingData = value; } }

	}
}
