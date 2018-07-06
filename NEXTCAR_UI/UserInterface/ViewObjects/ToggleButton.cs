using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.ViewObjects
{
	public class ToggleButton : EnhancedGlassButton.GlassButton
	{
		private Color _primaryColor;
		private Color _secondaryColor;

		public Color PrimaryColor { get { return _primaryColor; } set { _primaryColor = value; } }
		public Color SecondaryColor { get { return _secondaryColor; } set { _secondaryColor = value; } }

		public ToggleButton(): base()
		{

		}

		public ToggleButton(Color primaryColor, Color secondaryColor) : base()
		{
			PrimaryColor = primaryColor;
			SecondaryColor = secondaryColor; 
		}
	}
}
