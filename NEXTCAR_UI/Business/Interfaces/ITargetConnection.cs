using MathWorks.xPCTarget.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface ITargetConnection
	{
		bool IsTargetConnected { get; set; }
		string TargetIPaddress { get; set; }
		string TargetPort { get; set; }

		void ConnectToTarget();
		void DisconnectFromTarget();
		xPCApplication LoadRealTimeModel(string realTimeModelFilePath);
		void UnloadRealTimeModel();
		void RebootTargetPC();

		event EventHandler<TargetConnectionStateChangedEventArgs> TargetConnectionStateChanged;
	}

	public class TargetConnectionStateChangedEventArgs : EventArgs
	{
		private bool _isTargetConnected;
		private string _targetIPaddress;
		private string _targetPort;
		public bool IsTargetConnected { get { return _isTargetConnected; } }
		public string TargetIPaddress { get { return _targetIPaddress; } }
		public string TargetPort { get { return _targetPort; } }
		public TargetConnectionStateChangedEventArgs(bool isTargetConnected, string targetIPaddress, string targetPort)
		{
			_isTargetConnected = isTargetConnected;
			_targetIPaddress = targetIPaddress;
			_targetPort = targetPort;
		}
	}
}
