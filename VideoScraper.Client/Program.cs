namespace VideoScraper.Client {

	#region Directives
	using System;
	using System.Diagnostics;
	using Core.Common;
	using Management;
	#endregion

	public class Program {

		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		/// <returns>System.Int32.</returns>
		[STAThread]
		public static int Main(string[] args) {
			try {
				
				using (var form = new Search(new SearchProvider())) {
					form.ShowDialog();
				}

				return 0;
			}
			catch (Exception caught) {
				Debug.Print(caught.Message);
				return 1;
			}
		}

	}

}
