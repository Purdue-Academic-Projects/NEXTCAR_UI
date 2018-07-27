using NEXTCAR_UI.Business.Interfaces;
using NEXTCAR_UI.DataClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.Business.Models
{
	public class RealTimeModel : IHasModelLocation
	{
		private string _realTimeModelLocation = "C\\";
		private bool _isModelLocationLoaded;

		public string RealTimeModelFilePath
		{
			get { return _realTimeModelLocation; }
			private set
			{
				if (_realTimeModelLocation != value)
				{
					_realTimeModelLocation = value;
					OnRealTimeModelLocationChanged(value);
				}
			}
		}
		public bool IsModelLocationLoaded { get { return _isModelLocationLoaded; } private set { _isModelLocationLoaded = value; } }

		public event EventHandler RealTimeModelLocationChanged;

		public void BrowseForModel()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "Simulink Model files (*.slx)|*.slx|MLDATX files (*.mldatx)|*.mldatx";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (openFileDialog.FileName != null) { RealTimeModelFilePath = openFileDialog.FileName; }
			}
		}

		private void OnRealTimeModelLocationChanged(string newFilePath)
		{
			// If a real-time model file was loaded into the textbox, set its corresponding property true
			if (newFilePath.Contains(ModelConstants.REAL_TIME_MODEL_FILE_EXTENSION)) { IsModelLocationLoaded = true; }
			else { IsModelLocationLoaded = false; }

			EventArgs args = new EventArgs();
			RealTimeModelLocationChanged?.Invoke(this, args);
		}
	}
}
