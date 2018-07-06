using NEXTCAR_UI.DataClasses;
using NEXTCAR_UI.UserInterface.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Views.MainScreen
{
	public partial class MainScreen : Form, IMainScreen
	{
		public MainScreen()
		{
			InitializeComponent();
			InitializeRichTextBoxes();
			InitializeButtons();



			MLApp.MLApp matlab = new MLApp.MLApp();
			string test = matlab.Execute("1+1");
		}

		public void InitializeRichTextBoxes()
		{
			IPaddressRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
			IPaddressRichTextBox.TextChanged += new EventHandler(OnIPaddressTextChanged);

			PortRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
			PortRichTextBox.TextChanged += new EventHandler(OnPortTextChanged);

			RealTimeModelFileLocationRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
			RealTimeModelFileLocationRichTextBox.TextChanged += new EventHandler(OnModelFileLocationTextChanged);
		}

		public void InitializeButtons()
		{
			ConnectToggleButton.BackColor = ViewConstants.CONNECT_BUTTON_COLOR;
			ConnectToggleButton.MouseClick += new MouseEventHandler(OnConnectToggleButtonClicked);

			BrowseForModelFileButton.BackColor = ViewConstants.ACTIVE_BUTTON_COLOR;
			BrowseForModelFileButton.MouseClick += new MouseEventHandler(OnBrowseForModelFileButtonClicked);

			BuildModelFileButton.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
			BuildModelFileButton.Enabled = false;

			LoadModelToggleButton.BackColor = ViewConstants.INACTIVE_BUTTON_COLOR;
			LoadModelToggleButton.Enabled = false;
			LoadModelToggleButton.MouseClick += new MouseEventHandler(OnLoadModelToggleButtonClicked);
		}
	}
}
