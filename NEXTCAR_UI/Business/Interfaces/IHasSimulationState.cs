using MathWorks.xPCTarget.FrameWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface ISimulationState : ICanControlTargetApplication, ILoadable
	{
		double MaximumTeT { get; }
		double StopTime { get; set; }
		bool IsModelLoadedOnTarget { get; }
		bool IsSimulationRunning { get; }
		xPCApplication LoadedApplication { get; }

		void ResetSimulationProperties();

		event EventHandler<MaximumTeTChangedEventArgs> MaximumTeTChanged;
		event EventHandler<StopTimeChangedEventArgs> StopTimeChanged;
	}

	public class MaximumTeTChangedEventArgs : EventArgs
	{
		private double _maximumTeT;
		public double MaximumTeT { get { return _maximumTeT; } }

		public MaximumTeTChangedEventArgs(double maximumTeT)
		{
			_maximumTeT = maximumTeT;
		}
	}

	public class StopTimeChangedEventArgs : EventArgs
	{
		private double _stopTime;
		public double StopTime { get { return _stopTime; } }

		public StopTimeChangedEventArgs(double stopTime)
		{
			_stopTime = stopTime;
		}
	}
}
