using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Views.MainScreen
{
	public partial class MainScreen
	{
		public event EventHandler UserEnteredLoggingTime;

		private void OnUserEnteredLoggingTime(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{

			}
		}	
	}
}
