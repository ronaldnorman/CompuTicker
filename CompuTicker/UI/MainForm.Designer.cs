namespace CompuTicker.UI
{
    partial class MainForm
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
            this.StartToggleButton = new System.Windows.Forms.Button();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.SubtitleLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ClearLogLink = new System.Windows.Forms.LinkLabel();
            this.AlertLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartToggleButton
            // 
            this.StartToggleButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.StartToggleButton.CausesValidation = false;
            this.StartToggleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartToggleButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartToggleButton.ForeColor = System.Drawing.Color.White;
            this.StartToggleButton.Location = new System.Drawing.Point(98, 119);
            this.StartToggleButton.Name = "StartToggleButton";
            this.StartToggleButton.Size = new System.Drawing.Size(151, 54);
            this.StartToggleButton.TabIndex = 0;
            this.StartToggleButton.Text = "START";
            this.StartToggleButton.UseVisualStyleBackColor = false;
            this.StartToggleButton.Click += new System.EventHandler(this.StartToggleButton_Click);
            // 
            // LogListBox
            // 
            this.LogListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(0, 240);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LogListBox.Size = new System.Drawing.Size(341, 225);
            this.LogListBox.TabIndex = 1;
            // 
            // SubtitleLabel
            // 
            this.SubtitleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SubtitleLabel.CausesValidation = false;
            this.SubtitleLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubtitleLabel.Location = new System.Drawing.Point(-5, 50);
            this.SubtitleLabel.Name = "SubtitleLabel";
            this.SubtitleLabel.Padding = new System.Windows.Forms.Padding(10);
            this.SubtitleLabel.Size = new System.Drawing.Size(344, 38);
            this.SubtitleLabel.TabIndex = 2;
            this.SubtitleLabel.Text = "Retrieve && Compute the Latest Equations";
            this.SubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(73, 21);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(187, 29);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "CompuTicker";
            // 
            // ClearLogLink
            // 
            this.ClearLogLink.AutoSize = true;
            this.ClearLogLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.ClearLogLink.Location = new System.Drawing.Point(298, 225);
            this.ClearLogLink.Name = "ClearLogLink";
            this.ClearLogLink.Size = new System.Drawing.Size(31, 13);
            this.ClearLogLink.TabIndex = 5;
            this.ClearLogLink.TabStop = true;
            this.ClearLogLink.Text = "Clear";
            this.ClearLogLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClearLogLink_LinkClicked);
            // 
            // AlertLabel
            // 
            this.AlertLabel.AutoSize = true;
            this.AlertLabel.BackColor = System.Drawing.Color.Tomato;
            this.AlertLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlertLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlertLabel.ForeColor = System.Drawing.Color.White;
            this.AlertLabel.Location = new System.Drawing.Point(0, 0);
            this.AlertLabel.Name = "AlertLabel";
            this.AlertLabel.Size = new System.Drawing.Size(93, 13);
            this.AlertLabel.TabIndex = 6;
            this.AlertLabel.Text = "(alerts go here)";
            this.AlertLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 465);
            this.Controls.Add(this.AlertLabel);
            this.Controls.Add(this.ClearLogLink);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.SubtitleLabel);
            this.Controls.Add(this.LogListBox);
            this.Controls.Add(this.StartToggleButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CompuTicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartToggleButton;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Label SubtitleLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.LinkLabel ClearLogLink;
        private System.Windows.Forms.Label AlertLabel;
    }
}

