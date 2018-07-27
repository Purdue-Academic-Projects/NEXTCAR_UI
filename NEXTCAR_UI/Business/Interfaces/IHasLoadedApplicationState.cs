using MathWorks.xPCTarget.FrameWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface IHasLoadedApplicationState
	{
		xPCAppStatus TargetStatus { get; }
		double AverageTeT { get; }
		bool CpuOverload { get; }
		double ExecutionTime { get; }
		string LoadedModelName { get; }

		void ResetApplicationState();
	}
}
