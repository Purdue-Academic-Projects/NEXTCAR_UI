using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface IHasModelLocation
	{
		string RealTimeModelFilePath { get; }
		bool IsModelLocationLoaded { get; }

		void BrowseForModel();

		event EventHandler RealTimeModelLocationChanged;
	}
}
