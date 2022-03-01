namespace MicShh
{
    partial class MicShhForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MicShhForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Item1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Item2");
            this.MicShhNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MicShhContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AudioDevicesListView = new System.Windows.Forms.ListView();
            this.RefereshDevicesButton = new System.Windows.Forms.Button();
            this.CurrentKeyBindLabel = new System.Windows.Forms.Label();
            this.DeviceInstructionLabel = new System.Windows.Forms.Label();
            this.UseSoundCheckBox = new System.Windows.Forms.CheckBox();
            this.RecordKeyBindButton = new System.Windows.Forms.Button();
            this.DefaultButton = new System.Windows.Forms.Button();
            ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MicShhContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowToolStripMenuItem
            // 
            ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            ShowToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            ShowToolStripMenuItem.Text = "Show";
            ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // MicShhNotifyIcon
            // 
            this.MicShhNotifyIcon.ContextMenuStrip = this.MicShhContextMenuStrip;
            this.MicShhNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MicShhNotifyIcon.Icon")));
            this.MicShhNotifyIcon.Text = "MicShh";
            this.MicShhNotifyIcon.Visible = true;
            // 
            // MicShhContextMenuStrip
            // 
            this.MicShhContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ShowToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.MicShhContextMenuStrip.Name = "ContextMenuStrip";
            this.MicShhContextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // AudioDevicesListView
            // 
            this.AudioDevicesListView.CheckBoxes = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.AudioDevicesListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.AudioDevicesListView.Location = new System.Drawing.Point(12, 27);
            this.AudioDevicesListView.Name = "AudioDevicesListView";
            this.AudioDevicesListView.Size = new System.Drawing.Size(257, 82);
            this.AudioDevicesListView.TabIndex = 1;
            this.AudioDevicesListView.UseCompatibleStateImageBehavior = false;
            this.AudioDevicesListView.View = System.Windows.Forms.View.List;
            this.AudioDevicesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.AudioDevicesListView_ItemChecked);
            // 
            // RefereshDevicesButton
            // 
            this.RefereshDevicesButton.Location = new System.Drawing.Point(275, 56);
            this.RefereshDevicesButton.Name = "RefereshDevicesButton";
            this.RefereshDevicesButton.Size = new System.Drawing.Size(204, 23);
            this.RefereshDevicesButton.TabIndex = 2;
            this.RefereshDevicesButton.Text = "Refresh Devices";
            this.RefereshDevicesButton.UseVisualStyleBackColor = true;
            this.RefereshDevicesButton.Click += new System.EventHandler(this.RefereshDevicesButton_Click);
            // 
            // CurrentKeyBindLabel
            // 
            this.CurrentKeyBindLabel.AutoSize = true;
            this.CurrentKeyBindLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentKeyBindLabel.Location = new System.Drawing.Point(12, 112);
            this.CurrentKeyBindLabel.Name = "CurrentKeyBindLabel";
            this.CurrentKeyBindLabel.Size = new System.Drawing.Size(207, 32);
            this.CurrentKeyBindLabel.TabIndex = 3;
            this.CurrentKeyBindLabel.Text = "Current Key Bind: ";
            // 
            // DeviceInstructionLabel
            // 
            this.DeviceInstructionLabel.AutoSize = true;
            this.DeviceInstructionLabel.Location = new System.Drawing.Point(12, 9);
            this.DeviceInstructionLabel.Name = "DeviceInstructionLabel";
            this.DeviceInstructionLabel.Size = new System.Drawing.Size(257, 15);
            this.DeviceInstructionLabel.TabIndex = 4;
            this.DeviceInstructionLabel.Text = "Select Devices to Mute with Hot Key Activation:";
            // 
            // UseSoundCheckBox
            // 
            this.UseSoundCheckBox.AutoSize = true;
            this.UseSoundCheckBox.Location = new System.Drawing.Point(392, 90);
            this.UseSoundCheckBox.Name = "UseSoundCheckBox";
            this.UseSoundCheckBox.Size = new System.Drawing.Size(87, 19);
            this.UseSoundCheckBox.TabIndex = 5;
            this.UseSoundCheckBox.Text = "Use Sound?";
            this.UseSoundCheckBox.UseVisualStyleBackColor = true;
            this.UseSoundCheckBox.CheckedChanged += new System.EventHandler(this.UseSoundCheckBox_CheckedChanged);
            // 
            // RecordKeyBindButton
            // 
            this.RecordKeyBindButton.Location = new System.Drawing.Point(275, 27);
            this.RecordKeyBindButton.Name = "RecordKeyBindButton";
            this.RecordKeyBindButton.Size = new System.Drawing.Size(204, 23);
            this.RecordKeyBindButton.TabIndex = 6;
            this.RecordKeyBindButton.Text = "Record New Keybind";
            this.RecordKeyBindButton.UseVisualStyleBackColor = true;
            this.RecordKeyBindButton.Click += new System.EventHandler(this.RecordKeyBindButton_Click);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Location = new System.Drawing.Point(275, 85);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(111, 23);
            this.DefaultButton.TabIndex = 7;
            this.DefaultButton.Text = "Reset Key Bind";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // MicShhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 155);
            this.Controls.Add(this.DefaultButton);
            this.Controls.Add(this.RecordKeyBindButton);
            this.Controls.Add(this.UseSoundCheckBox);
            this.Controls.Add(this.DeviceInstructionLabel);
            this.Controls.Add(this.CurrentKeyBindLabel);
            this.Controls.Add(this.RefereshDevicesButton);
            this.Controls.Add(this.AudioDevicesListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MicShhForm";
            this.Text = "MicShh";
            this.Leave += new System.EventHandler(this.MicShhForm_Leave);
            this.MicShhContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon MicShhNotifyIcon;
        private ContextMenuStrip MicShhContextMenuStrip;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ListView AudioDevicesListView;
        private Button RefereshDevicesButton;
        private Label CurrentKeyBindLabel;
        private Label DeviceInstructionLabel;
        private CheckBox UseSoundCheckBox;
        private Button RecordKeyBindButton;
        private Button DefaultButton;
    }
}