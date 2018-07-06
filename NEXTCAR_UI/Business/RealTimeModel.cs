using NEXTCAR_UI.Business.Interfaces;
using NEXTCAR_UI.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.Business
{
	public class RealTimeModel : IModelProperties
	{
		private string _realTimeModelLocation = "C\\";
		private bool _isRealTimeFileLoadedInTextbox;

		public string RealTimeModelFilePath
		{
			get { return _realTimeModelLocation; }
			set
			{
				if (_realTimeModelLocation != value)
				{
					_realTimeModelLocation = value;
					OnRealTimeModelLocationChanged(value);
				}
			}
		}
		public bool IsRealTimeFileLoadedInTextbox { get; set; }


		public RealTimeModel()
		{

		}

		public void BrowseForModel()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "Simulink Model files (*.slx)|*.slx|MLDATX files (*.mldatx)|*.mldatx";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;

			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if(openFileDialog.FileName != null) { RealTimeModelFilePath = openFileDialog.FileName; }
			}
		}

		public event EventHandler RealTimeModelLocationChanged;

		private void OnRealTimeModelLocationChanged(string newFilePath)
		{
			// If a real-time model file was loaded into the textbox, set its corresponding property true
			if (newFilePath.Contains(ModelConstants.REAL_TIME_MODEL_FILE_EXTENSION)) { IsRealTimeFileLoadedInTextbox = true; }
			else { IsRealTimeFileLoadedInTextbox = false; }

			EventArgs args = new EventArgs();
			RealTimeModelLocationChanged?.Invoke(this, args);
		}
	}
}
