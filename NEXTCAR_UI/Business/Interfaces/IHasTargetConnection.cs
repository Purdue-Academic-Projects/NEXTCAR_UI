using MathWorks.xPCTarget.FrameWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface IHasTargetConnection
	{
		bool IsTargetConnected { get; set; }
		string TargetIPaddress { get; set; }
		string TargetPort { get; set; }
		xPCTargetPC TargetPC { get; }

		event EventHandler<TargetConnectionStateChangedEventArgs> TargetConnectionStateChanged;
	}

	public class TargetConnectionStateChangedEventArgs : EventArgs
	{
		private bool _isTargetConnected;
		private string _targetIPaddress;
		private string _targetPort;
		public bool IsTargetConnected { get { return _isTargetConnected; } private set { _isTargetConnected = value; } }
		public string TargetIPaddress { get { return _targetIPaddress; } private set { _targetIPaddress = value; } }
		public string TargetPort { get { return _targetPort; } private set { _targetPort = value; } }
		public TargetConnectionStateChangedEventArgs(bool isTargetConnected, string targetIPaddress, string targetPort)
		{
			IsTargetConnected = isTargetConnected;
			TargetIPaddress = targetIPaddress;
			TargetPort = targetPort;
		}
	}
}
