using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Interfaces
{
	public interface IViewApplication
	{
		event MouseEventHandler LoadModelToggleButtonClicked;

		void ChangeLoadModelToggleButtonState(string loadedModelName);
	}
}
