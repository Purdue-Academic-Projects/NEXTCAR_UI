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
		public double MaximumTeT { get { return _maximumTeT; } private set { _maximumTeT = value; } }

		public MaximumTeTChangedEventArgs(double maximumTeT)
		{
			MaximumTeT = maximumTeT;
		}
	}

	public class StopTimeChangedEventArgs : EventArgs
	{
		private double _stopTime;
		public double StopTime { get { return _stopTime; } private set { _stopTime = value; } }

		public StopTimeChangedEventArgs(double stopTime)
		{
			StopTime = stopTime;
		}
	}
}
