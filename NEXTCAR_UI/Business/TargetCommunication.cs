using MathWorks.xPCTarget.FrameWork;
using NEXTCAR_UI.Business.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.Business
{
	public class TargetCommunication : ITargetConnection
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

		public TargetCommunication()
		{
			this._targetPC = new xPCTargetPC();
			this._targetPC.TcpIpTargetAddress = TargetIPaddress;
			this._targetPC.TcpIpTargetPort = TargetPort;
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
			this._targetPC.Disconnect();
			IsTargetConnected = this._targetPC.IsConnected;
		}

		public xPCApplication LoadRealTimeModel(string realTimeModelFilePath)
		{
			xPCApplication targetApplication = this._targetPC.Load(realTimeModelFilePath);
			return targetApplication;
		}

		public void UnloadRealTimeModel()
		{
			this._targetPC.Unload();
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
