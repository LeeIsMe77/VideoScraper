namespace VideoScraper.Client.Management {
	partial class Search {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.searchButton = new System.Windows.Forms.Button();
			this.titleLabel = new System.Windows.Forms.Label();
			this.title = new System.Windows.Forms.TextBox();
			this.videosDataGridView = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.xmlText = new System.Windows.Forms.RichTextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.videosDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.searchButton);
			this.panel1.Controls.Add(this.titleLabel);
			this.panel1.Controls.Add(this.title);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1008, 60);
			this.panel1.TabIndex = 0;
			// 
			// searchButton
			// 
			this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.searchButton.Location = new System.Drawing.Point(876, 30);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(75, 21);
			this.searchButton.TabIndex = 2;
			this.searchButton.Text = "&Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// titleLabel
			// 
			this.titleLabel.Location = new System.Drawing.Point(12, 30);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(145, 21);
			this.titleLabel.TabIndex = 1;
			this.titleLabel.Text = "Title:";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// title
			// 
			this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.title.Location = new System.Drawing.Point(163, 31);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(707, 20);
			this.title.TabIndex = 0;
			// 
			// videosDataGridView
			// 
			this.videosDataGridView.AllowUserToAddRows = false;
			this.videosDataGridView.AllowUserToDeleteRows = false;
			this.videosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.videosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.videosDataGridView.Location = new System.Drawing.Point(0, 0);
			this.videosDataGridView.Name = "videosDataGridView";
			this.videosDataGridView.ReadOnly = true;
			this.videosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.videosDataGridView.Size = new System.Drawing.Size(1008, 316);
			this.videosDataGridView.TabIndex = 1;
			this.videosDataGridView.SelectionChanged += new System.EventHandler(this.videosDataGridView_SelectionChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 84);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.videosDataGridView);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.xmlText);
			this.splitContainer1.Size = new System.Drawing.Size(1008, 645);
			this.splitContainer1.SplitterDistance = 316;
			this.splitContainer1.TabIndex = 2;
			// 
			// xmlText
			// 
			this.xmlText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xmlText.Location = new System.Drawing.Point(0, 0);
			this.xmlText.Name = "xmlText";
			this.xmlText.Size = new System.Drawing.Size(1008, 325);
			this.xmlText.TabIndex = 0;
			this.xmlText.Text = "";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.optionsToolStripMenuItem.Text = "Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// Search
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "Search";
			this.Text = "Search";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.videosDataGridView)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView videosDataGridView;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.TextBox title;
		private System.Windows.Forms.Button searchButton;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.RichTextBox xmlText;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
	}
}