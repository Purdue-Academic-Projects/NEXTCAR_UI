﻿using NEXTCAR_UI.Business.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Interfaces
{
	public interface IViewApplication
	{
		event MouseEventHandler LoadModelToggleButtonClicked;
		event MouseEventHandler RebootTargetPCButtonClicked;
		event MouseEventHandler StartSimulationToggleButtonClicked;

		void ChangeLoadModelToggleButtonState(bool isTargetConnected, bool isRealTimeFileLoadedInTextbox, bool isModelLoadedOnTarget);
		void UpdateApplicationProperties(ApplicationPropertiesChangedEventArgs applicationProperties);
		void ChangeRebootButtonState(bool isTargetConnected);
		void ChangeSimulationStartToggleButtonState(bool isTargetConnected, bool isModelLoadedOnTarget, bool isTargetRunning);
	}
}
