namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Xml.Linq;

	#endregion

	public class ConfigurationManager {

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

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigurationManager"/> class.
		/// </summary>
		public ConfigurationManager() {
			if (!File.Exists(this.ConfigurationFilePath)) return;
			try {
				var configuration = XElement.Load(this.ConfigurationFilePath);
				this.APIKey = configuration.SafeAttributeValue(nameof(ConfigurationManager.APIKey), this.APIKey);
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
					new XAttribute(nameof(ConfigurationManager.APIKey), this.APIKey)
					)
					.Save(this.ConfigurationFilePath, SaveOptions.None);
			}
			catch { }
		}

		#endregion

	}

}
