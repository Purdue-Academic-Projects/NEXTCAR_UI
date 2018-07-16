using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface IModelProperties
	{
		string RealTimeModelFilePath { get; set; }
		bool IsRealTimeFileLoadedInTextbox { get; }

		void BrowseForModel();

		event EventHandler RealTimeModelLocationChanged;
	}
}
