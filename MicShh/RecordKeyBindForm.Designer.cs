namespace MicShh
{
    partial class RecordKeyBindForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordKeyBindForm));
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.RecordButton = new System.Windows.Forms.Button();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.KeyBindLabel = new System.Windows.Forms.Label();
            this.CancelRecordingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(360, 118);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(279, 118);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(12, 118);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(75, 23);
            this.RecordButton.TabIndex = 2;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.AutoSize = true;
            this.CurrentLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentLabel.Location = new System.Drawing.Point(12, 9);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(182, 30);
            this.CurrentLabel.TabIndex = 3;
            this.CurrentLabel.Text = "Current Key Bind:";
            // 
            // KeyBindLabel
            // 
            this.KeyBindLabel.AutoSize = true;
            this.KeyBindLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyBindLabel.Location = new System.Drawing.Point(12, 39);
            this.KeyBindLabel.Name = "KeyBindLabel";
            this.KeyBindLabel.Size = new System.Drawing.Size(124, 30);
            this.KeyBindLabel.TabIndex = 4;
            this.KeyBindLabel.Text = "{{key bind}}";
            // 
            // CancelRecordingButton
            // 
            this.CancelRecordingButton.Location = new System.Drawing.Point(93, 118);
            this.CancelRecordingButton.Name = "CancelRecordingButton";
            this.CancelRecordingButton.Size = new System.Drawing.Size(110, 23);
            this.CancelRecordingButton.TabIndex = 5;
            this.CancelRecordingButton.Text = "Cancel Recording";
            this.CancelRecordingButton.UseVisualStyleBackColor = true;
            this.CancelRecordingButton.Click += new System.EventHandler(this.CancelRecordingButton_Click);
            // 
            // RecordKeyBindForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 155);
            this.Controls.Add(this.CancelRecordingButton);
            this.Controls.Add(this.KeyBindLabel);
            this.Controls.Add(this.CurrentLabel);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordKeyBindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Record Key Bind";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecordKeyBindForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CancelButton;
        private Button OkButton;
        private Button RecordButton;
        private Label CurrentLabel;
        private Label KeyBindLabel;
        private Button CancelRecordingButton;
    }
}