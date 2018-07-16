using NEXTCAR_UI.DataClasses;
using NEXTCAR_UI.UserInterface.ViewObjects;
using System.Windows.Forms;

namespace NEXTCAR_UI.UserInterface.Views.MainScreen
{
	public partial class MainScreen
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
			this.ConnectionStatusGroupBox = new System.Windows.Forms.GroupBox();
			this.ConnectToggleButton = new NEXTCAR_UI.UserInterface.ViewObjects.ToggleButton();
			this.IPaddressLabel = new System.Windows.Forms.Label();
			this.PortLabel = new System.Windows.Forms.Label();
			this.IPaddressRichTextBox = new System.Windows.Forms.RichTextBox();
			this.PortRichTextBox = new System.Windows.Forms.RichTextBox();
			this.RealTimeModelGroupBox = new System.Windows.Forms.GroupBox();
			this.RealTimeModelFileLocationRichTextBox = new System.Windows.Forms.RichTextBox();
			this.BrowseForModelFileButton = new NEXTCAR_UI.UserInterface.ViewObjects.ToggleButton();
			this.BuildModelFileButton = new NEXTCAR_UI.UserInterface.ViewObjects.ToggleButton();
			this.LoadModelToggleButton = new NEXTCAR_UI.UserInterface.ViewObjects.ToggleButton();
			this.DataLoggingGroupBox = new System.Windows.Forms.GroupBox();
			this.RebootTargetPCButton = new NEXTCAR_UI.UserInterface.ViewObjects.ToggleButton();
			this.StartSimulationToggleButton = new NEXTCAR_UI.UserInterface.ViewObjects.ToggleButton();
			this.StopTimeLabelRichTextBox = new System.Windows.Forms.RichTextBox();
			this.StopTimeLabel = new System.Windows.Forms.Label();
			this.LoadedModelRichTextBox = new System.Windows.Forms.RichTextBox();
			this.LoadedModelLabel = new System.Windows.Forms.Label();
			this.TargetApplicationStatusStrip = new System.Windows.Forms.StatusStrip();
			this.TargetStatusToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.ExecutionTimeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ExecutionTimeToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.AverageTetToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.AverageTetToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.MaximumTetToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MaximumTetToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.CpuOverloadedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.CpuOverloadedToolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.ConnectionStatusGroupBox.SuspendLayout();
			this.RealTimeModelGroupBox.SuspendLayout();
			this.DataLoggingGroupBox.SuspendLayout();
			this.TargetApplicationStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ConnectionStatusGroupBox
			// 
			this.ConnectionStatusGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.ConnectionStatusGroupBox.Controls.Add(this.ConnectToggleButton);
			this.ConnectionStatusGroupBox.Controls.Add(this.IPaddressLabel);
			this.ConnectionStatusGroupBox.Controls.Add(this.PortLabel);
			this.ConnectionStatusGroupBox.Controls.Add(this.IPaddressRichTextBox);
			this.ConnectionStatusGroupBox.Controls.Add(this.PortRichTextBox);
			this.ConnectionStatusGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.ConnectionStatusGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ConnectionStatusGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ConnectionStatusGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.ConnectionStatusGroupBox.Location = new System.Drawing.Point(12, 12);
			this.ConnectionStatusGroupBox.Name = "ConnectionStatusGroupBox";
			this.ConnectionStatusGroupBox.Size = new System.Drawing.Size(200, 97);
			this.ConnectionStatusGroupBox.TabIndex = 0;
			this.ConnectionStatusGroupBox.TabStop = false;
			this.ConnectionStatusGroupBox.Text = "CONNECTION STATUS";
			// 
			// ConnectToggleButton
			// 
			this.ConnectToggleButton.BackColor = System.Drawing.Color.Lime;
			this.ConnectToggleButton.CornerRadius = 1;
			this.ConnectToggleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ConnectToggleButton.ForeColor = System.Drawing.Color.Black;
			this.ConnectToggleButton.GlowColor = System.Drawing.Color.Lime;
			this.ConnectToggleButton.Location = new System.Drawing.Point(6, 66);
			this.ConnectToggleButton.Name = "ConnectToggleButton";
			this.ConnectToggleButton.PrimaryColor = System.Drawing.Color.Lime;
			this.ConnectToggleButton.SecondaryColor = System.Drawing.Color.Red;
			this.ConnectToggleButton.Size = new System.Drawing.Size(188, 23);
			this.ConnectToggleButton.TabIndex = 2;
			this.ConnectToggleButton.Text = "CONNECT";
			// 
			// IPaddressLabel
			// 
			this.IPaddressLabel.BackColor = System.Drawing.Color.Black;
			this.IPaddressLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.IPaddressLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IPaddressLabel.ForeColor = System.Drawing.Color.White;
			this.IPaddressLabel.Location = new System.Drawing.Point(6, 20);
			this.IPaddressLabel.Name = "IPaddressLabel";
			this.IPaddressLabel.Size = new System.Drawing.Size(96, 23);
			this.IPaddressLabel.TabIndex = 1;
			this.IPaddressLabel.Text = "IP Address";
			this.IPaddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// PortLabel
			// 
			this.PortLabel.BackColor = System.Drawing.Color.Black;
			this.PortLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.PortLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PortLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PortLabel.ForeColor = System.Drawing.Color.White;
			this.PortLabel.Location = new System.Drawing.Point(6, 43);
			this.PortLabel.Name = "PortLabel";
			this.PortLabel.Size = new System.Drawing.Size(96, 23);
			this.PortLabel.TabIndex = 2;
			this.PortLabel.Text = "Port";
			this.PortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// IPaddressRichTextBox
			// 
			this.IPaddressRichTextBox.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IPaddressRichTextBox.Location = new System.Drawing.Point(103, 20);
			this.IPaddressRichTextBox.Name = "IPaddressRichTextBox";
			this.IPaddressRichTextBox.Size = new System.Drawing.Size(91, 23);
			this.IPaddressRichTextBox.TabIndex = 2;
			this.IPaddressRichTextBox.Text = "192.168.7.1";
			// 
			// PortRichTextBox
			// 
			this.PortRichTextBox.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PortRichTextBox.Location = new System.Drawing.Point(103, 43);
			this.PortRichTextBox.Name = "PortRichTextBox";
			this.PortRichTextBox.Size = new System.Drawing.Size(91, 23);
			this.PortRichTextBox.TabIndex = 1;
			this.PortRichTextBox.Text = "22222";
			// 
			// RealTimeModelGroupBox
			// 
			this.RealTimeModelGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.RealTimeModelGroupBox.Controls.Add(this.RealTimeModelFileLocationRichTextBox);
			this.RealTimeModelGroupBox.Controls.Add(this.BrowseForModelFileButton);
			this.RealTimeModelGroupBox.Controls.Add(this.BuildModelFileButton);
			this.RealTimeModelGroupBox.Controls.Add(this.LoadModelToggleButton);
			this.RealTimeModelGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.RealTimeModelGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RealTimeModelGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RealTimeModelGroupBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.RealTimeModelGroupBox.Location = new System.Drawing.Point(12, 120);
			this.RealTimeModelGroupBox.Name = "RealTimeModelGroupBox";
			this.RealTimeModelGroupBox.Size = new System.Drawing.Size(200, 97);
			this.RealTimeModelGroupBox.TabIndex = 1;
			this.RealTimeModelGroupBox.TabStop = false;
			this.RealTimeModelGroupBox.Text = "REAL-TIME MODEL";
			// 
			// RealTimeModelFileLocationRichTextBox
			// 
			this.RealTimeModelFileLocationRichTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.RealTimeModelFileLocationRichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.RealTimeModelFileLocationRichTextBox.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RealTimeModelFileLocationRichTextBox.Location = new System.Drawing.Point(6, 19);
			this.RealTimeModelFileLocationRichTextBox.Multiline = false;
			this.RealTimeModelFileLocationRichTextBox.Name = "RealTimeModelFileLocationRichTextBox";
			this.RealTimeModelFileLocationRichTextBox.ReadOnly = true;
			this.RealTimeModelFileLocationRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.RealTimeModelFileLocationRichTextBox.Size = new System.Drawing.Size(91, 23);
			this.RealTimeModelFileLocationRichTextBox.TabIndex = 5;
			this.RealTimeModelFileLocationRichTextBox.Text = "C:\\";
			// 
			// BrowseForModelFileButton
			// 
			this.BrowseForModelFileButton.BackColor = System.Drawing.SystemColors.HotTrack;
			this.BrowseForModelFileButton.CornerRadius = 1;
			this.BrowseForModelFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BrowseForModelFileButton.ForeColor = System.Drawing.Color.Black;
			this.BrowseForModelFileButton.GlowColor = System.Drawing.Color.Lime;
			this.BrowseForModelFileButton.Location = new System.Drawing.Point(98, 20);
			this.BrowseForModelFileButton.Name = "BrowseForModelFileButton";
			this.BrowseForModelFileButton.PrimaryColor = System.Drawing.Color.Lime;
			this.BrowseForModelFileButton.SecondaryColor = System.Drawing.Color.Red;
			this.BrowseForModelFileButton.Size = new System.Drawing.Size(96, 23);
			this.BrowseForModelFileButton.TabIndex = 4;
			this.BrowseForModelFileButton.Text = "BROWSE";
			// 
			// BuildModelFileButton
			// 
			this.BuildModelFileButton.BackColor = System.Drawing.SystemColors.HotTrack;
			this.BuildModelFileButton.CornerRadius = 1;
			this.BuildModelFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BuildModelFileButton.ForeColor = System.Drawing.Color.Black;
			this.BuildModelFileButton.GlowColor = System.Drawing.Color.Lime;
			this.BuildModelFileButton.Location = new System.Drawing.Point(6, 43);
			this.BuildModelFileButton.Name = "BuildModelFileButton";
			this.BuildModelFileButton.PrimaryColor = System.Drawing.Color.Lime;
			this.BuildModelFileButton.SecondaryColor = System.Drawing.Color.Red;
			this.BuildModelFileButton.Size = new System.Drawing.Size(188, 23);
			this.BuildModelFileButton.TabIndex = 3;
			this.BuildModelFileButton.Text = "BUILD MODEL";
			// 
			// LoadModelToggleButton
			// 
			this.LoadModelToggleButton.BackColor = System.Drawing.Color.Lime;
			this.LoadModelToggleButton.CornerRadius = 1;
			this.LoadModelToggleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadModelToggleButton.ForeColor = System.Drawing.Color.Black;
			this.LoadModelToggleButton.GlowColor = System.Drawing.Color.Lime;
			this.LoadModelToggleButton.Location = new System.Drawing.Point(6, 65);
			this.LoadModelToggleButton.Name = "LoadModelToggleButton";
			this.LoadModelToggleButton.PrimaryColor = System.Drawing.Color.Lime;
			this.LoadModelToggleButton.SecondaryColor = System.Drawing.Color.Red;
			this.LoadModelToggleButton.Size = new System.Drawing.Size(188, 23);
			this.LoadModelToggleButton.TabIndex = 2;
			this.LoadModelToggleButton.Text = "LOAD MODEL";
			// 
			// DataLoggingGroupBox
			// 
			this.DataLoggingGroupBox.BackColor = System.Drawing.Color.Transparent;
			this.DataLoggingGroupBox.Controls.Add(this.RebootTargetPCButton);
			this.DataLoggingGroupBox.Controls.Add(this.StartSimulationToggleButton);
			this.DataLoggingGroupBox.Controls.Add(this.StopTimeLabelRichTextBox);
			this.DataLoggingGroupBox.Controls.Add(this.StopTimeLabel);
			this.DataLoggingGroupBox.Controls.Add(this.LoadedModelRichTextBox);
			this.DataLoggingGroupBox.Controls.Add(this.LoadedModelLabel);
			this.DataLoggingGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.DataLoggingGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DataLoggingGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DataLoggingGroupBox.ForeColor = System.Drawing.Color.White;
			this.DataLoggingGroupBox.Location = new System.Drawing.Point(12, 228);
			this.DataLoggingGroupBox.Name = "DataLoggingGroupBox";
			this.DataLoggingGroupBox.Size = new System.Drawing.Size(200, 118);
			this.DataLoggingGroupBox.TabIndex = 2;
			this.DataLoggingGroupBox.TabStop = false;
			this.DataLoggingGroupBox.Text = "TARGET PROPERTIES";
			// 
			// RebootTargetPCButton
			// 
			this.RebootTargetPCButton.BackColor = System.Drawing.SystemColors.HotTrack;
			this.RebootTargetPCButton.CornerRadius = 1;
			this.RebootTargetPCButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RebootTargetPCButton.ForeColor = System.Drawing.Color.Black;
			this.RebootTargetPCButton.GlowColor = System.Drawing.Color.Lime;
			this.RebootTargetPCButton.Location = new System.Drawing.Point(6, 64);
			this.RebootTargetPCButton.Name = "RebootTargetPCButton";
			this.RebootTargetPCButton.PrimaryColor = System.Drawing.Color.Lime;
			this.RebootTargetPCButton.SecondaryColor = System.Drawing.Color.Red;
			this.RebootTargetPCButton.Size = new System.Drawing.Size(188, 23);
			this.RebootTargetPCButton.TabIndex = 4;
			this.RebootTargetPCButton.Text = "REBOOT TARGET PC";
			// 
			// StartSimulationToggleButton
			// 
			this.StartSimulationToggleButton.BackColor = System.Drawing.Color.Lime;
			this.StartSimulationToggleButton.CornerRadius = 1;
			this.StartSimulationToggleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartSimulationToggleButton.ForeColor = System.Drawing.Color.Black;
			this.StartSimulationToggleButton.GlowColor = System.Drawing.Color.Lime;
			this.StartSimulationToggleButton.Location = new System.Drawing.Point(6, 87);
			this.StartSimulationToggleButton.Name = "StartSimulationToggleButton";
			this.StartSimulationToggleButton.PrimaryColor = System.Drawing.Color.Lime;
			this.StartSimulationToggleButton.SecondaryColor = System.Drawing.Color.Red;
			this.StartSimulationToggleButton.Size = new System.Drawing.Size(188, 23);
			this.StartSimulationToggleButton.TabIndex = 3;
			this.StartSimulationToggleButton.Text = "START SIMULATION";
			// 
			// StopTimeLabelRichTextBox
			// 
			this.StopTimeLabelRichTextBox.BackColor = System.Drawing.Color.White;
			this.StopTimeLabelRichTextBox.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StopTimeLabelRichTextBox.Location = new System.Drawing.Point(103, 41);
			this.StopTimeLabelRichTextBox.Multiline = false;
			this.StopTimeLabelRichTextBox.Name = "StopTimeLabelRichTextBox";
			this.StopTimeLabelRichTextBox.Size = new System.Drawing.Size(91, 23);
			this.StopTimeLabelRichTextBox.TabIndex = 15;
			this.StopTimeLabelRichTextBox.Text = "";
			// 
			// StopTimeLabel
			// 
			this.StopTimeLabel.BackColor = System.Drawing.Color.Black;
			this.StopTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.StopTimeLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StopTimeLabel.ForeColor = System.Drawing.Color.White;
			this.StopTimeLabel.Location = new System.Drawing.Point(6, 41);
			this.StopTimeLabel.Name = "StopTimeLabel";
			this.StopTimeLabel.Size = new System.Drawing.Size(96, 23);
			this.StopTimeLabel.TabIndex = 14;
			this.StopTimeLabel.Text = "Stop Time";
			this.StopTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LoadedModelRichTextBox
			// 
			this.LoadedModelRichTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.LoadedModelRichTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.LoadedModelRichTextBox.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadedModelRichTextBox.Location = new System.Drawing.Point(103, 18);
			this.LoadedModelRichTextBox.Multiline = false;
			this.LoadedModelRichTextBox.Name = "LoadedModelRichTextBox";
			this.LoadedModelRichTextBox.ReadOnly = true;
			this.LoadedModelRichTextBox.Size = new System.Drawing.Size(91, 23);
			this.LoadedModelRichTextBox.TabIndex = 13;
			this.LoadedModelRichTextBox.Text = "";
			// 
			// LoadedModelLabel
			// 
			this.LoadedModelLabel.BackColor = System.Drawing.Color.Black;
			this.LoadedModelLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.LoadedModelLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LoadedModelLabel.ForeColor = System.Drawing.Color.White;
			this.LoadedModelLabel.Location = new System.Drawing.Point(6, 18);
			this.LoadedModelLabel.Name = "LoadedModelLabel";
			this.LoadedModelLabel.Size = new System.Drawing.Size(96, 23);
			this.LoadedModelLabel.TabIndex = 12;
			this.LoadedModelLabel.Text = "Loaded Model";
			this.LoadedModelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TargetApplicationStatusStrip
			// 
			this.TargetApplicationStatusStrip.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.TargetApplicationStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TargetStatusToolStripStatus,
            this.ExecutionTimeToolStripStatusLabel,
            this.ExecutionTimeToolStripStatus,
            this.AverageTetToolStripStatusLabel,
            this.AverageTetToolStripStatus,
            this.MaximumTetToolStripStatusLabel,
            this.MaximumTetToolStripStatus,
            this.CpuOverloadedToolStripStatusLabel,
            this.CpuOverloadedToolStripStatus});
			this.TargetApplicationStatusStrip.Location = new System.Drawing.Point(0, 404);
			this.TargetApplicationStatusStrip.Name = "TargetApplicationStatusStrip";
			this.TargetApplicationStatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.TargetApplicationStatusStrip.Size = new System.Drawing.Size(800, 22);
			this.TargetApplicationStatusStrip.SizingGrip = false;
			this.TargetApplicationStatusStrip.TabIndex = 3;
			this.TargetApplicationStatusStrip.Text = "statusStrip1";
			// 
			// TargetStatusToolStripStatus
			// 
			this.TargetStatusToolStripStatus.Name = "TargetStatusToolStripStatus";
			this.TargetStatusToolStripStatus.Size = new System.Drawing.Size(51, 17);
			this.TargetStatusToolStripStatus.Text = "Stopped";
			// 
			// ExecutionTimeToolStripStatusLabel
			// 
			this.ExecutionTimeToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
			this.ExecutionTimeToolStripStatusLabel.Name = "ExecutionTimeToolStripStatusLabel";
			this.ExecutionTimeToolStripStatusLabel.Size = new System.Drawing.Size(115, 17);
			this.ExecutionTimeToolStripStatusLabel.Spring = true;
			this.ExecutionTimeToolStripStatusLabel.Text = "Execution Time:";
			// 
			// ExecutionTimeToolStripStatus
			// 
			this.ExecutionTimeToolStripStatus.Name = "ExecutionTimeToolStripStatus";
			this.ExecutionTimeToolStripStatus.Size = new System.Drawing.Size(13, 17);
			this.ExecutionTimeToolStripStatus.Text = "0";
			// 
			// AverageTetToolStripStatusLabel
			// 
			this.AverageTetToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
			this.AverageTetToolStripStatusLabel.Name = "AverageTetToolStripStatusLabel";
			this.AverageTetToolStripStatusLabel.Size = new System.Drawing.Size(115, 17);
			this.AverageTetToolStripStatusLabel.Spring = true;
			this.AverageTetToolStripStatusLabel.Text = "Average TET:";
			// 
			// AverageTetToolStripStatus
			// 
			this.AverageTetToolStripStatus.Name = "AverageTetToolStripStatus";
			this.AverageTetToolStripStatus.Size = new System.Drawing.Size(13, 17);
			this.AverageTetToolStripStatus.Text = "0";
			// 
			// MaximumTetToolStripStatusLabel
			// 
			this.MaximumTetToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
			this.MaximumTetToolStripStatusLabel.Name = "MaximumTetToolStripStatusLabel";
			this.MaximumTetToolStripStatusLabel.Size = new System.Drawing.Size(115, 17);
			this.MaximumTetToolStripStatusLabel.Spring = true;
			this.MaximumTetToolStripStatusLabel.Text = "Maximum TET:";
			// 
			// MaximumTetToolStripStatus
			// 
			this.MaximumTetToolStripStatus.Name = "MaximumTetToolStripStatus";
			this.MaximumTetToolStripStatus.Size = new System.Drawing.Size(13, 17);
			this.MaximumTetToolStripStatus.Text = "0";
			// 
			// CpuOverloadedToolStripStatusLabel
			// 
			this.CpuOverloadedToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(50, 3, 0, 2);
			this.CpuOverloadedToolStripStatusLabel.Name = "CpuOverloadedToolStripStatusLabel";
			this.CpuOverloadedToolStripStatusLabel.Size = new System.Drawing.Size(115, 17);
			this.CpuOverloadedToolStripStatusLabel.Spring = true;
			this.CpuOverloadedToolStripStatusLabel.Text = "CPU Overloaded:";
			// 
			// CpuOverloadedToolStripStatus
			// 
			this.CpuOverloadedToolStripStatus.Name = "CpuOverloadedToolStripStatus";
			this.CpuOverloadedToolStripStatus.Size = new System.Drawing.Size(33, 17);
			this.CpuOverloadedToolStripStatus.Text = "False";
			// 
			// MainScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.BackgroundImage = global::NEXTCAR_UI.Properties.Resources.PurdueLogo;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(800, 426);
			this.Controls.Add(this.TargetApplicationStatusStrip);
			this.Controls.Add(this.DataLoggingGroupBox);
			this.Controls.Add(this.RealTimeModelGroupBox);
			this.Controls.Add(this.ConnectionStatusGroupBox);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainScreen";
			this.Opacity = 0.95D;
			this.Text = "NEXTCAR User Interface";
			this.ConnectionStatusGroupBox.ResumeLayout(false);
			this.RealTimeModelGroupBox.ResumeLayout(false);
			this.DataLoggingGroupBox.ResumeLayout(false);
			this.TargetApplicationStatusStrip.ResumeLayout(false);
			this.TargetApplicationStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private GroupBox ConnectionStatusGroupBox;
		private Label IPaddressLabel;
		private Label PortLabel;
		private RichTextBox IPaddressRichTextBox;
		private RichTextBox PortRichTextBox;
		private ToggleButton ConnectToggleButton;
		private GroupBox RealTimeModelGroupBox;
		private ToggleButton LoadModelToggleButton;
		private ToggleButton BrowseForModelFileButton;
		private ToggleButton BuildModelFileButton;
		private RichTextBox RealTimeModelFileLocationRichTextBox;
		private GroupBox DataLoggingGroupBox;
		private ToggleButton StartSimulationToggleButton;
		private RichTextBox StopTimeLabelRichTextBox;
		private Label StopTimeLabel;
		private RichTextBox LoadedModelRichTextBox;
		private Label LoadedModelLabel;
		private ToggleButton RebootTargetPCButton;
		private StatusStrip TargetApplicationStatusStrip;
		private ToolStripStatusLabel ExecutionTimeToolStripStatusLabel;
		private ToolStripStatusLabel ExecutionTimeToolStripStatus;
		private ToolStripStatusLabel TargetStatusToolStripStatus;
		private ToolStripStatusLabel AverageTetToolStripStatusLabel;
		private ToolStripStatusLabel AverageTetToolStripStatus;
		private ToolStripStatusLabel MaximumTetToolStripStatusLabel;
		private ToolStripStatusLabel MaximumTetToolStripStatus;
		private ToolStripStatusLabel CpuOverloadedToolStripStatusLabel;
		private ToolStripStatusLabel CpuOverloadedToolStripStatus;
	}
}

