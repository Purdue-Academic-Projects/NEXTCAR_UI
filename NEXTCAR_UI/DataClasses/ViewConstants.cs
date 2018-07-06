﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXTCAR_UI.DataClasses
{
	public static class ViewConstants
	{
		public static readonly Color CONNECT_BUTTON_COLOR = Color.Lime;
		public static readonly Color DISCONNECT_BUTTON_COLOR = Color.Red;
		public static readonly Color LOAD_MODEL_BUTTON_COLOR = Color.Lime;
		public static readonly Color UNLOAD_MODEL_BUTTON_COLOR = Color.Red;
		public static readonly Color ACTIVE_BUTTON_COLOR = SystemColors.HotTrack;
		public static readonly Color INACTIVE_BUTTON_COLOR = SystemColors.ControlDarkDark;

		public static readonly string CONNECT_BUTTON_TEXT = "CONNECT";
		public static readonly string DISCONNECT_BUTTON_TEXT = "DISCONNECT";
		public static readonly string LOAD_BUTTON_TEXT = "LOAD MODEL";
		public static readonly string UNLOAD_BUTTON_TEXT = "UNLOAD_MODEL";
	}
}