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
		private xPCApplication _xpcApplication;
		private xPCAppStatus _targetStatus;
		private double _averageTeT;
		private double _maximumTeT;
		private bool _cpuOverload;
		private double _executionTime;
		private string _loadedModelName;
		private double _stopTime;

		public xPCAppStatus TargetStatus { get; private set; }
		public double AverageTeT { get; private set; }
		public double MaximumTeT { get; private set; }
		public bool CpuOverload { get; private set; }
		public double ExecutionTime { get; private set; }
		public string LoadedModelName { get; private set; }
		public double StopTime { get; private set; }

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
			propertyUpdateTimer.Enabled = false;
		}

		public void LoadTargetApplication(ITargetConnection targetConnection, string realTimeModelFilePath)
		{
			if(targetConnection.IsTargetConnected == true)
			{
				this._xpcApplication = targetConnection.LoadRealTimeModel(realTimeModelFilePath);
				StartPropertyUpdatesTimer();
			}
		}

		public void UnloadTargetApplication(ITargetConnection targetConnection)
		{
			if (targetConnection.IsTargetConnected == true)
			{
				targetConnection.UnloadRealTimeModel();
				ResetApplicationProperties();
				StopPropertyUpdatesTimer();
			}
		}

		public void StartTargetApplication()
		{
			if(this._xpcApplication != null) { this._xpcApplication.Start(); }
		}

		public void StopTargetApplication()
		{
			if (this._xpcApplication != null) { this._xpcApplication.Stop(); }
		}

		private void ResetApplicationProperties()
		{
			this._xpcApplication = null;
			this.LoadedModelName = null;
		}

		private void OnIntervalElapsed(Object source, System.Timers.ElapsedEventArgs e)
		{
			TargetStatus = this._xpcApplication.Status;
			AverageTeT = this._xpcApplication.AverageTeT;
			MaximumTeT = this._xpcApplication.MaximumTeT[0];
			CpuOverload = this._xpcApplication.CPUOverload;
			ExecutionTime = this._xpcApplication.ExecTime;
			LoadedModelName = this._xpcApplication.Name;
			StopTime = this._xpcApplication.StopTime;

			ApplicationPropertiesChangedEventArgs args = new ApplicationPropertiesChangedEventArgs(TargetStatus,
																									AverageTeT,
																									MaximumTeT,
																									CpuOverload,
																									ExecutionTime,
																									LoadedModelName,
																									StopTime);
			ApplicationPropertiesChanged?.Invoke(this, args);
		}
	}
}
