using NEXTCAR_UI.Business.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface ILoadable
	{
		void LoadRealTimeModel(IHasTargetConnection targetConnection, string realTimeModelFilePath);
		void UnloadRealTimeModel(IHasTargetConnection targetConnection);
	}
}
