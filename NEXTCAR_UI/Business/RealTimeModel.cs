using NEXTCAR_UI.Business.Interfaces;

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
			EventArgs args = new EventArgs();
			RealTimeModelLocationChanged?.Invoke(this, args);
		}
	}
}
