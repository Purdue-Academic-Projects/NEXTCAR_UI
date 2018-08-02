﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.Business.Interfaces
{
	public interface ICanControlTargetFileSystem
	{
		void EstablishFileSystem(ICanControlTargetConnection targetConnection);
	}
}
