using NEXTCAR_UI.UserInterface.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Views.MainScreen
{
    public partial class MainScreen : IViewApplication
	{
		public event MouseEventHandler LoadModelToggleButtonClicked;

		private void OnLoadModelToggleButtonClicked(object sender, MouseEventArgs e) { LoadModelToggleButtonClicked?.Invoke(sender, e); }

		public void ChangeLoadModelToggleButtonState(string loadedModelName)
		{
			LoadApplicationToggleButtonChange(this.LoadModelToggleButton, loadedModelName);
		}
	}
}
