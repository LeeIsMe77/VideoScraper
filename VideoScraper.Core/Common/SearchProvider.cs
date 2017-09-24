namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.IO;
	using System.Xml.Linq;

	#endregion

	public class SearchProvider {

		#region Constants
		private const string CONFIGURATION_FILE_NAME = "VideoScraper.xml";
		private const int CONFIGURATION_VERSION = 1;
		#endregion

		#region Properties

		#region APIKey

		/// <summary>
		/// Gets or sets the API key.
		/// </summary>
		/// <value>The API key.</value>
		public string APIKey { get; set; }

		#endregion

		#region ConfigurationFilePath

		private string _configurationFileDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create)}\\Lee Gurley\\Video Scraper\\{CONFIGURATION_VERSION}";

		/// <summary>
		/// Gets the configuration file path.
		/// </summary>
		/// <value>The configuration file path.</value>
		public string ConfigurationFilePath {
			get { return Path.Combine(_configurationFileDirectory, CONFIGURATION_FILE_NAME); }
		}

		#endregion

		#region RequestManager

		private RequestManager _requestManager;

		/// <summary>
		/// Gets the request manager.
		/// </summary>
		/// <value>The request manager.</value>
		public RequestManager RequestManager {
			get { return _requestManager ?? (_requestManager = new RequestManager(this)); }
		}

		#endregion

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="SearchProvider"/> class.
		/// </summary>
		public SearchProvider() {
			if (!File.Exists(this.ConfigurationFilePath)) return;
			try {
				var configuration = XElement.Load(this.ConfigurationFilePath);
				this.APIKey = configuration.SafeAttributeValue(nameof(SearchProvider.APIKey), this.APIKey);
			}
			catch { }
		}

		#endregion

		#region Configuration
		
		/// <summary>
		/// Saves the configuration.
		/// </summary>
		public void SaveConfiguration() {
			try {
				if (!Directory.Exists(_configurationFileDirectory)) {
					Directory.CreateDirectory(_configurationFileDirectory);
				}

				new XElement(
					nameof(RequestManager),
					new XAttribute(nameof(SearchProvider.APIKey), this.APIKey)
					)
					.Save(this.ConfigurationFilePath, SaveOptions.None);
			}
			catch { }
		}

		#endregion

	}

}
