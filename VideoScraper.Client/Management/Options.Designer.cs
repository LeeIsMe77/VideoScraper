namespace VideoScraper.Client.Management {
	partial class Options {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.apiKeyLabel = new System.Windows.Forms.Label();
			this.apiKey = new System.Windows.Forms.TextBox();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.buttonPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// apiKeyLabel
			// 
			this.apiKeyLabel.Location = new System.Drawing.Point(11, 66);
			this.apiKeyLabel.Name = "apiKeyLabel";
			this.apiKeyLabel.Size = new System.Drawing.Size(145, 21);
			this.apiKeyLabel.TabIndex = 3;
			this.apiKeyLabel.Text = "API Key:";
			this.apiKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// apiKey
			// 
			this.apiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.apiKey.Location = new System.Drawing.Point(162, 67);
			this.apiKey.Name = "apiKey";
			this.apiKey.Size = new System.Drawing.Size(332, 20);
			this.apiKey.TabIndex = 2;
			// 
			// ok
			// 
			this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ok.Location = new System.Drawing.Point(426, 3);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 23);
			this.ok.TabIndex = 4;
			this.ok.Text = "&OK";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(345, 3);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 5;
			this.cancel.Text = "&Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// buttonPanel
			// 
			this.buttonPanel.Controls.Add(this.ok);
			this.buttonPanel.Controls.Add(this.cancel);
			this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonPanel.Location = new System.Drawing.Point(0, 227);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(506, 31);
			this.buttonPanel.TabIndex = 6;
			// 
			// Options
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(506, 258);
			this.ControlBox = false;
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.apiKeyLabel);
			this.Controls.Add(this.apiKey);
			this.Name = "Options";
			this.Text = "Options";
			this.buttonPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label apiKeyLabel;
		private System.Windows.Forms.TextBox apiKey;
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Panel buttonPanel;
	}
}