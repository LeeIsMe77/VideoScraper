namespace VideoScraper.Client.Management {

	#region Directives
	using System;
	using System.Windows.Forms;
	using VideoScraper.Core.Common;
	#endregion

	public partial class Options 
		: Form {

		#region Static

		/// <summary>
		/// Shows the <seealso cref="Options"/> form as a child of the parent form.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="videoScraperManager">The video scraper manager.</param>
		public static void Show(IWin32Window owner, VideoScraperManager videoScraperManager) {
			using (var form = new Options(videoScraperManager)) {
				form.ShowDialog(owner);
			}
		}

		#endregion

		private readonly VideoScraperManager _videoScraperManager;

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="Options"/> class.
		/// </summary>
		/// <param name="videoScraperManager">The video scraper manager.</param>
		private Options(VideoScraperManager videoScraperManager) {
			InitializeComponent();
			_videoScraperManager = videoScraperManager;
		}

		#endregion

		#region Base Overrides

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Form.Load" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			this.apiKey.Text = _videoScraperManager.APIKey;
		}

		#endregion

		#region Control Events

		/// <summary>
		/// Handles the Click event of the cancel control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void cancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Handles the Click event of the ok control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void ok_Click(object sender, EventArgs e) {
			_videoScraperManager.APIKey = this.apiKey.Text;
			this.DialogResult = DialogResult.OK;
		}

		#endregion

	}

}
