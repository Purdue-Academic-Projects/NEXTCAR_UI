using MathWorks.xPCTarget.FrameWork;
using NEXTCAR_UI.Business.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Containers
{
	public class LoadedApplicationState : IHasLoadedApplicationState
	{
		private xPCAppStatus _targetStatus = xPCAppStatus.Stopped;
		private double _averageTeT;
		private bool _cpuOverload;
		private double _executionTime;
		private string _loadedModelName = null;

		public xPCAppStatus TargetStatus { get { return _targetStatus; } private set { _targetStatus = value; } }
		public double AverageTeT { get { return _averageTeT; } private set { _averageTeT = value; } }
		public bool CpuOverload { get { return _cpuOverload; } private set { _cpuOverload = value; } }
		public double ExecutionTime { get { return _executionTime; } private set { _executionTime = value; } }
		public string LoadedModelName { get { return _loadedModelName; } private set { _loadedModelName = value; } }

		public LoadedApplicationState()
		{
			// Default constructor
		}

		public LoadedApplicationState(
			xPCAppStatus targetStatus,
			double averageTeT,
			bool cpuOverload,
			double executionTime,
			string loadedModelName)
		{
			TargetStatus = targetStatus;
			AverageTeT = averageTeT;
			CpuOverload = cpuOverload;
			ExecutionTime = executionTime;
			LoadedModelName = loadedModelName;
		}

		public LoadedApplicationState(xPCApplication xpcApplication)
		{
			TargetStatus = xpcApplication.Status;
			AverageTeT = xpcApplication.AverageTeT;
			CpuOverload = xpcApplication.CPUOverload;
			ExecutionTime = xpcApplication.ExecTime;
			LoadedModelName = xpcApplication.Name;
		}

		public void ResetApplicationState()
		{
			this.TargetStatus = xPCAppStatus.Stopped;
			this.AverageTeT = 0;
			this.CpuOverload = false;
			this.ExecutionTime = 0;
			this.LoadedModelName = null;
		}
	}
}
