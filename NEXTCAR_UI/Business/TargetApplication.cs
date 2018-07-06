using MathWorks.xPCTarget.FrameWork;
using NEXTCAR_UI.Business.Interfaces;
using NEXTCAR_UI.DataClasses;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace NEXTCAR_UI.Business
{
	public class TargetApplication : IApplicationProperties
	{
		private Timer propertyUpdateTimer;
		private xPCApplication _xpcApplication = null;
		private xPCAppStatus _targetStatus = xPCAppStatus.Stopped;
		private double _averageTeT;
		private double _maximumTeT;
		private bool _cpuOverload;
		private double _executionTime;
		private string _loadedModelName = null;
		private double _stopTime;
		private bool _isModelLoadedOnTarget;
		public bool _isSimulationRunning = false;

		public xPCAppStatus TargetStatus
		{
			get { return _targetStatus; }
			private set
			{
				_targetStatus = value;
				OnTargetStatusChanged(value);
			}
		}
		public double AverageTeT { get { return _averageTeT; }  private set { _averageTeT = value; } }
		public double MaximumTeT { get { return _maximumTeT; } private set { _maximumTeT = value; } }
		public bool CpuOverload { get { return _cpuOverload; } private set { _cpuOverload = value; } }
		public double ExecutionTime { get { return _executionTime; } private set { _executionTime = value; } }
		public string LoadedModelName
		{
			get { return _loadedModelName; }
			private set
			{
				_loadedModelName = value;
				OnLoadedModelNameChanged(value);
			}
		}
		public double StopTime { get { return _stopTime; } private set { _stopTime = value; } }
		public bool IsModelLoadedOnTarget { get { return _isModelLoadedOnTarget; } private set { _isModelLoadedOnTarget = value; } }
		public bool IsSimulationRunning { get { return _isSimulationRunning; } private set { _isSimulationRunning = value; } }

		public event EventHandler<ApplicationPropertiesChangedEventArgs> ApplicationPropertiesChanged;


		public TargetApplication()
		{
		}

		public void StartPropertyUpdatesTimer()
		{
			propertyUpdateTimer = new System.Timers.Timer();
			propertyUpdateTimer.Interval = ModelConstants.APPLICATION_PROPERTY_UPDATE_INTERVAL;
			propertyUpdateTimer.Elapsed += OnIntervalElapsed;
			propertyUpdateTimer.Enabled = true;
		}

		public void StopPropertyUpdatesTimer()
		{
			if (propertyUpdateTimer != null) { propertyUpdateTimer.Enabled = false; }
		}

		public void LoadTargetApplication(ITargetConnection targetConnection, string realTimeModelFilePath)
		{
			if(targetConnection.IsTargetConnected == true)
			{
				this._xpcApplication = targetConnection.LoadRealTimeModel(realTimeModelFilePath);
				LoadedModelName = this._xpcApplication.Name;
				StartPropertyUpdatesTimer();
			}
		}

		public void UnloadTargetApplication(ITargetConnection targetConnection)
		{
			if (IsModelLoadedOnTarget) { targetConnection.UnloadRealTimeModel(); }
			ResetApplicationProperties();
		}

		public void StartTargetApplication()
		{
			if(this._xpcApplication != null) { this._xpcApplication.Start(); }
		}

		public void StopTargetApplication()
		{
			if (this._xpcApplication != null) { this._xpcApplication.Stop(); }
		}

		public void ResetApplicationProperties()
		{
			this._xpcApplication = null;
			this.LoadedModelName = null;
			this.TargetStatus = xPCAppStatus.Stopped;
			this.IsSimulationRunning = false;
			StopPropertyUpdatesTimer();
		}

		public void StartSimulation()
		{
			this._xpcApplication.Start();
			this.IsSimulationRunning = true;
		}

		public void StopSimulation()
		{
			this._xpcApplication.Stop();
			this.IsSimulationRunning = false;
			MaximumTeT = this._xpcApplication.MaximumTeT[0];
		}

		private void OnIntervalElapsed(Object source, System.Timers.ElapsedEventArgs e)
		{
			TargetStatus = this._xpcApplication.Status;
			AverageTeT = this._xpcApplication.AverageTeT;
			CpuOverload = this._xpcApplication.CPUOverload;
			ExecutionTime = this._xpcApplication.ExecTime;
			LoadedModelName = this._xpcApplication.Name;
			StopTime = this._xpcApplication.StopTime;

			ApplicationPropertiesChangedEventArgs args = new ApplicationPropertiesChangedEventArgs(this._xpcApplication.Status,
																									this._xpcApplication.AverageTeT,
																									MaximumTeT,
																									this._xpcApplication.CPUOverload,
																									this._xpcApplication.ExecTime,
																									this._xpcApplication.Name,
																									this._xpcApplication.StopTime);
			ApplicationPropertiesChanged?.Invoke(this, args);
		}

		private void OnTargetStatusChanged(xPCAppStatus appStatus)
		{
			switch (appStatus)
			{
				case xPCAppStatus.Running:
					IsSimulationRunning = true;
					break;
				case xPCAppStatus.Stopped:
					IsSimulationRunning = false;
					break;
				case xPCAppStatus.Starting:
					IsSimulationRunning = false;
					break;
			}
		}

		private void OnLoadedModelNameChanged(string loadedModelName)
		{
			if (String.IsNullOrEmpty(loadedModelName)) { IsModelLoadedOnTarget = false; }
			else { IsModelLoadedOnTarget = true; }
		}
	}
}
