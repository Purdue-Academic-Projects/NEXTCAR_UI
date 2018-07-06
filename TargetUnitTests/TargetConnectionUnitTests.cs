using System;
using MathWorks.xPCTarget.FrameWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TargetUnitTests
{
	[TestClass]
	public class TargetConnectionUnitTests
	{
		private xPCTargetPC _targetPC;
		private xPCApplication _targetApplication;

		[TestMethod]
		public void TargetConnectionTests()
		{
			_targetPC = new xPCTargetPC();
			_targetPC.TcpIpTargetAddress = "192.168.7.1";
			_targetPC.TcpIpTargetPort = "22222";
			_targetPC.Connect();

			_targetApplication = _targetPC.Load();
		}
	}
}
