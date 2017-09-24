namespace VideoScraper.Client.Management {

	#region Directives
	using System;
	using System.IO;
	using System.Windows.Forms;
	using System.Xml;
	using System.Xml.Serialization;
	using VideoScraper.Core.Common;
	using VideoScraper.Core.DataContracts;
	#endregion

	public partial class Search
		: Form {

		#region Properties

		private ConfigurationManager _configurationManager;

		#region RequestManager

		private RequestManager _requestManager;

		/// <summary>
		/// Gets the request manager.
		/// </summary>
		/// <value>The request manager.</value>
		public RequestManager RequestManager {
			get { return _requestManager ?? (_requestManager = new RequestManager(_configurationManager)); }
		}

		#endregion

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="Search"/> class.
		/// </summary>
		public Search(ConfigurationManager configurationManager) {
			InitializeComponent();
			_configurationManager = configurationManager;
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Form.FormClosing" /> event.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.FormClosingEventArgs" /> that contains the event data.</param>
		protected override void OnFormClosing(FormClosingEventArgs e) {
			base.OnFormClosing(e);
			_configurationManager.SaveConfiguration();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Automatically re-sizes each column in the <seealso cref="DataGridView"/> to fit all content in header and cells.
		/// </summary>
		/// <param name="videosDataGridView">The data grid view.</param>
		private void AutoSizeColumns() {
			if (videosDataGridView == null) return;
			foreach (DataGridViewColumn column in videosDataGridView.Columns) {
				column.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
		}

		/// <summary>
		/// Generates the XML.
		/// </summary>
		private void GenerateXml() {
			if (this.videosDataGridView.SelectedRows.Count != 1) {
				this.xmlText.Text = null;
				return;
			}

			if (this.videosDataGridView.SelectedRows.Count != 1) return;

			var video = this.videosDataGridView.SelectedRows[0].DataBoundItem as Video;
			if (video == null) return;

			var xmlSerializer = new XmlSerializer(video.GetType());
			using (var stringWriter = new StringWriter()) {
				
				using (XmlWriter writer = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true })) {
					xmlSerializer.Serialize(writer, video);
					this.xmlText.Text = stringWriter.ToString();
				}
			}

		}

		/// <summary>
		/// Gets the video details.
		/// </summary>
		private void GetVideoDetails() {
			var videoCollection = this.videosDataGridView.DataSource as VideoCollection<Movie>;
			if (videoCollection != null) {
				var selectedVideo = this.videosDataGridView.SelectedRows[0].DataBoundItem as Movie;
				if (selectedVideo == null) return;
				videoCollection[videoCollection.IndexOf(selectedVideo)] = RequestManager.GetDetails(selectedVideo); ;
			}

			var tvShowCollection = this.videosDataGridView.DataSource as VideoCollection<TVShow>;
			if (tvShowCollection != null) {
				var selectedVideo = this.videosDataGridView.SelectedRows[0].DataBoundItem as TVShow;
				if (selectedVideo == null) return;
				tvShowCollection[tvShowCollection.IndexOf(selectedVideo)] = RequestManager.GetDetails(selectedVideo);
			}
		}

		#endregion

		#region Control Events

		/// <summary>
		/// Handles the Click event of the closeToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Handles the Click event of the optionsToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			Options.Show(this, _configurationManager);
		}

		/// <summary>
		/// Handles the Click event of the searchButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void searchButton_Click(object sender, EventArgs e) {
			this.videosDataGridView.SelectionChanged -= this.videosDataGridView_SelectionChanged;
			try {

				this.videosDataGridView.DataSource = null;
				if (this.modeMovie.Checked) {
					this.videosDataGridView.DataSource = RequestManager.Search<Movie>(this.title.Text);
				}
				else {
					this.videosDataGridView.DataSource = RequestManager.Search<TVShow>(this.title.Text);
				}
				this.AutoSizeColumns();

				this.videosDataGridView.SelectionChanged += this.videosDataGridView_SelectionChanged;
				this.GetVideoDetails();
				this.GenerateXml();
			}
			catch (Exception caught) {
				MessageBox.Show(this, caught.Message, @"Failure Searching...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Handles the SelectionChanged event of the videosDataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void videosDataGridView_SelectionChanged(object sender, EventArgs e) {
			this.GetVideoDetails();
			this.GenerateXml();
		}

		#endregion

	}

}
