using MathWorks.xPCTarget.FrameWork;
using NEXTCAR_UI.Business.Interfaces;
using NEXTCAR_UI.DataClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.Business.Models
{
	public class TargetCommunication : ICanControlTargetConnection
	{
		private bool _isTargetConnected = false;
		private string _targetIPaddress = "192.168.7.1";
		private string _targetPort = "22222";
		private xPCTargetPC _targetPC;

		public bool IsTargetConnected
		{
			get { return _isTargetConnected; }
			set
			{
				if(_isTargetConnected != value)
				{
					_isTargetConnected = value;
					OnTargetConnectionChanged(value);
				}
			}
		}
		public string TargetIPaddress
		{
			get { return _targetIPaddress; }
			set
			{
				if (_targetIPaddress != value)
				{
					_targetIPaddress = value;
					OnTargetIPaddressChanged(value);
				}
			}
		}
		public string TargetPort
		{
			get { return _targetPort; }
			set
			{
				if (_targetPort != value)
				{
					_targetPort = value;
					OnTargetPortChanged(value);
				}
			}
		}
		public xPCTargetPC TargetPC { get { return _targetPC; } private set { _targetPC = value; } }

		public TargetCommunication()
		{
			this.TargetPC = new xPCTargetPC();
			this.TargetPC.TcpIpTargetAddress = TargetIPaddress;
			this.TargetPC.TcpIpTargetPort = TargetPort;
			this.TargetPC.CommunicationTimeOut = ModelConstants.REBOOT_TIMEOUT_PERIOD;
		}

		public void ConnectToTarget()
		{
			try
			{
				this._targetPC.Connect();
				IsTargetConnected = this._targetPC.IsConnected;
			}
			catch (Exception ex)
			{
				string errorMessage;
				switch (ex)
				{
					case xPCException xpcEx:
						errorMessage = "Could not connect to target!" + Environment.NewLine + Environment.NewLine +
							"Source: " + ex.Source + Environment.NewLine +
							"Error: " + ex.Message;
						MessageBox.Show(errorMessage, "Target Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						IsTargetConnected = false;
						break;

					case DllNotFoundException dllEx:
						errorMessage = "Move xpcapi.dll file to project /bin folder.";
						MessageBox.Show(errorMessage, "Target Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						IsTargetConnected = false;
						break;
				}
			}
		}

		public void DisconnectFromTarget()
		{
			this.TargetPC.Disconnect();
			IsTargetConnected = this._targetPC.IsConnected;
		}

		public void RebootTargetPC()
		{
			try
			{
				this._targetPC.Reboot(ModelConstants.REBOOT_TIMEOUT_PERIOD);
			}
			catch(Exception ex)
			{
				// This error seems to occur every time the target is reset. Force a disconnect update to be safe.
				IsTargetConnected = false;
			}
		}

		public event EventHandler<TargetConnectionStateChangedEventArgs> TargetConnectionStateChanged;

		private void OnTargetConnectionChanged(bool isTargetConnected)
		{
			TargetConnectionStateChangedEventArgs args = new TargetConnectionStateChangedEventArgs(isTargetConnected, this.TargetIPaddress, this.TargetPort);
			TargetConnectionStateChanged?.Invoke(this, args);
		}
		private void OnTargetIPaddressChanged(string targetIPaddress)
		{
			TargetConnectionStateChangedEventArgs args = new TargetConnectionStateChangedEventArgs(this.IsTargetConnected, targetIPaddress, this.TargetPort);
			TargetConnectionStateChanged?.Invoke(this, args);
		}
		private void OnTargetPortChanged(string targetPort)
		{
			TargetConnectionStateChangedEventArgs args = new TargetConnectionStateChangedEventArgs(this.IsTargetConnected, this.TargetIPaddress, targetPort);
			TargetConnectionStateChanged?.Invoke(this, args);
		}
	}
}
