using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business
{
	public class MatlabInterface
	{
		public void test()
		{
			MLApp.MLApp matlab = new MLApp.MLApp();
			string test = matlab.Execute("1+1");
		}
	}
}
