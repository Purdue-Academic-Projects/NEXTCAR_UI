using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.DataClasses
{
	public static class ModelConstants
	{
		public static readonly string SIMULINK_FILE_EXTENSION = ".slx";
		public static readonly string REAL_TIME_MODEL_FILE_EXTENSION = ".mldatx";

		public static readonly int APPLICATION_PROPERTY_UPDATE_INTERVAL = 100;
		public static readonly int REBOOT_TIMEOUT_PERIOD = 10000;

		public static readonly int INFINITE_STOP_TIME = -1;
		public static readonly int DEFAULT_LOGGING_TIME = -1;
	}
}
