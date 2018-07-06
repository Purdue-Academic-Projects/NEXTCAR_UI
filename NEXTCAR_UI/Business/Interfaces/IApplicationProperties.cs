using MathWorks.xPCTarget.FrameWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface IApplicationProperties
	{
		xPCAppStatus TargetStatus { get; }
		double AverageTeT { get;  }
		double MaximumTeT { get; }
		bool CpuOverload { get; }
		double ExecutionTime { get; }
		string LoadedModelName { get; }
		double StopTime { get; }
		bool IsModelLoadedOnTarget { get; }
		bool IsSimulationRunning { get; }

		void LoadTargetApplication(ITargetConnection targetConnection, string realTimeModelFilePath);
		void UnloadTargetApplication(ITargetConnection targetConnection);
		void StartPropertyUpdatesTimer();
		void StopPropertyUpdatesTimer();
		void StartTargetApplication();
		void StopTargetApplication();
		void ResetApplicationProperties();
		void StartSimulation();
		void StopSimulation();

		event EventHandler<ApplicationPropertiesChangedEventArgs> ApplicationPropertiesChanged;
	}

	public class ApplicationPropertiesChangedEventArgs : EventArgs
	{
		private xPCAppStatus _targetStatus;
		private double _averageTeT;
		private double _maximumTeT;
		private bool _cpuOverload;
		private double _executionTime;
		private string _loadedModelName;
		private double _stopTime;

		public xPCAppStatus TargetStatus { get { return _targetStatus; } }
		public double AverageTeT { get { return _averageTeT; } }
		public double MaximumTeT { get { return _maximumTeT; } }
		public bool CpuOverload { get { return _cpuOverload; } }
		public double ExecutionTime { get { return _executionTime; } }
		public string LoadedModelName { get { return _loadedModelName; } }
		public double StopTime { get { return _stopTime; } }


		public ApplicationPropertiesChangedEventArgs(
			xPCAppStatus targetStatus,
			double averageTeT,
			double maximumTeT,
			bool cpuOverload,
			double executionTime,
			string loadedModelName,
			double stopTime)
		{
			_targetStatus = targetStatus;
			_averageTeT = averageTeT;
			_maximumTeT = maximumTeT;
			_cpuOverload = cpuOverload;
			_executionTime = executionTime;
			_loadedModelName = loadedModelName;
			_stopTime = stopTime;
		}
	}
}
