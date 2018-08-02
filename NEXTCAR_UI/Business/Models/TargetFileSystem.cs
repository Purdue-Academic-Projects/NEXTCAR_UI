using MathWorks.xPCTarget.FrameWork;

using NEXTCAR_UI.Business.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Models
{
	public class TargetFileSystem : ICanControlTargetFileSystem
	{
		private xPCFileSystem _fileSystem;

		public xPCFileSystem FileSystem { get { return _fileSystem; } private set { _fileSystem = value; } }

		public void EstablishFileSystem(ICanControlTargetConnection targetConnection)
		{
			this.FileSystem = targetConnection.TargetPC.FileSystem;
		}
	}
}
