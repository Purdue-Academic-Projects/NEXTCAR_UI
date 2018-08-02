using MathWorks.xPCTarget.FrameWork;
using NEXTCAR_UI.Business.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Models
{
	public class SimulationEnvironment : ISimulationState
	{
		private xPCApplication _loadedApplication;
		private double _maximumTeT;
		private double _stopTime;
		private bool _isModelLoadedOnTarget = false;
		public bool _isSimulationRunning = false;

		public xPCApplication LoadedApplication { get { return _loadedApplication; } private set { _loadedApplication = value; } }
		public double MaximumTeT
		{
			get { return _maximumTeT; }
			private set
			{
				if (_maximumTeT != value)
				{
					_maximumTeT = value;
					OnMaximumTeTChanged(value);
				}
			}
		}
		public double StopTime
		{
			get { return _stopTime; }
			set
			{
				if (_stopTime != value)
				{
					_stopTime = value;
					OnStopTimeChanged(value);
				}
			}
		}
		public bool IsModelLoadedOnTarget { get { return _isModelLoadedOnTarget; } private set { _isModelLoadedOnTarget = value; } }
		public bool IsSimulationRunning { get { return _isSimulationRunning; } private set { _isSimulationRunning = value; } }

		public event EventHandler<MaximumTeTChangedEventArgs> MaximumTeTChanged;
		public event EventHandler<StopTimeChangedEventArgs> StopTimeChanged;

		public void LoadRealTimeModel(IHasTargetConnection targetConnection, string realTimeModelFilePath)
		{
			this.LoadedApplication = targetConnection.TargetPC.Load(realTimeModelFilePath);
			if (this.LoadedApplication != null)
			{
				IsModelLoadedOnTarget = true;
				IsSimulationRunning = false;
			}
			else
			{
				IsModelLoadedOnTarget = false;
				IsSimulationRunning = false;
			}
		}

		public void UnloadRealTimeModel(IHasTargetConnection targetConnection)
		{
			try { targetConnection.TargetPC.Unload(); }
			catch { }

			LoadedApplication = null;
			IsModelLoadedOnTarget = false;
			IsSimulationRunning = false;
		}

		public void StartTargetApplication()
		{
			if (this.LoadedApplication != null) { this.LoadedApplication.Start(); }
			if(LoadedApplication.Status == xPCAppStatus.Running)
			{
				this.IsSimulationRunning = true;
				this.StopTime = this.LoadedApplication.StopTime;
				this.MaximumTeT = 0;
			}
			else
			{
				this.IsSimulationRunning = false;
			}
		}

		public void StopTargetApplication()
		{
			if (this.LoadedApplication != null)
			{
				this.LoadedApplication.Stop();
				this.IsSimulationRunning = false;
				this.MaximumTeT = this.LoadedApplication.MaximumTeT[0];
			}
		}

		public void ResetSimulationProperties()
		{
			LoadedApplication = null;
			this.IsModelLoadedOnTarget = false;
			this.IsSimulationRunning = false;
		}

		private void OnMaximumTeTChanged(double newMaximumTeT)
		{
			MaximumTeTChangedEventArgs args = new MaximumTeTChangedEventArgs(newMaximumTeT);
			MaximumTeTChanged?.Invoke(this, args);
		}

		private void OnStopTimeChanged(double newStopTime)
		{
			this.LoadedApplication.StopTime = newStopTime;

			StopTimeChangedEventArgs args = new StopTimeChangedEventArgs(newStopTime);
			StopTimeChanged?.Invoke(this, args);
		}
	}
}
