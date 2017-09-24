namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Net;
	using System.Reflection;
	using System.Runtime.Serialization.Json;
	using System.Xml.Linq;
	using DataContracts;

	#endregion

	public class VideoScraperManager {

		#region Constants
		private const string CONFIGURATION_FILE_NAME = "VideoScraper.xml";
		private const int CONFIGURATION_VERSION = 1;
		private const string URL_HOST = @"api.themoviedb.org";
		private const string URL_SCHEME = @"https";
		private const int URL_VERSION = 3;
		#endregion

		#region Static

		#region Methods

		/// <summary>
		/// Creates the request.
		/// </summary>
		/// <param name="requestMethod">The request method.</param>
		/// <param name="path">The path.</param>
		/// <param name="requestQueries">The request queries.</param>
		/// <returns>HttpWebRequest.</returns>
		private static HttpWebRequest CreateRequest(RequestMethod requestMethod, string path, RequestQueryCollection requestQueries) {

			var uriBuilder = new UriBuilder();
			uriBuilder.Scheme = URL_SCHEME;
			uriBuilder.Host = $@"{URL_HOST}/{URL_VERSION}";
			uriBuilder.Path = path;
			uriBuilder.Query = requestQueries?.ToString();

			var request = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
			request.ContentType = @"application/json";
			request.Method = requestMethod.ToString();

			return request;
		}

		/// <summary>
		/// Gets the response of an HttpWebRequest and uses the <see cref="DataContractJsonSerializer"/> to return an object of specified type.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="httpWebRequest">The HTTP web request.</param>
		/// <returns>T</returns>
		private static T GetResponse<T>(HttpWebRequest httpWebRequest) {
			try {
				var response = (HttpWebResponse)httpWebRequest.GetResponse();
				if ((int)response.StatusCode != 200) throw new Exception(response.StatusDescription);

				var memoryStream = new MemoryStream();
				try {
					response.GetResponseStream()?.CopyTo(memoryStream);

					memoryStream.Position = 0;
					var serializer = new DataContractJsonSerializer(typeof(T));
					var returnObject = (T)serializer.ReadObject(memoryStream);

#if DEBUG
					memoryStream.Position = 0;
					var streamReader = new StreamReader(memoryStream);
					Debug.Print(streamReader.ReadToEnd());
#endif

					return returnObject;
				}
				finally {
					memoryStream.Dispose();
				}

			}
			catch (Exception caught) {
				throw new Exception(caught.Message);
			}
		}

		#endregion

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="VideoScraperManager"/> class.
		/// </summary>
		public VideoScraperManager() {
			this.Initialize();
		}

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

		#region Methods

		#region Configuration

		/// <summary>
		/// Loads the configuration.
		/// </summary>
		private void LoadConfiguration() {
			if (!File.Exists(this.ConfigurationFilePath)) return;
			try {
				var configuration = XElement.Load(this.ConfigurationFilePath);
				this.APIKey = configuration.SafeAttributeValue(nameof(this.APIKey), this.APIKey);
			}
			catch { }
		}

		/// <summary>
		/// Saves the configuration.
		/// </summary>
		public void SaveConfiguration() {
			try {

				if (!Directory.Exists(_configurationFileDirectory)) {
					Directory.CreateDirectory(_configurationFileDirectory);
				}

				new XElement(
					nameof(VideoScraperManager), 
					new XAttribute(nameof(VideoScraperManager.APIKey), this.APIKey)
					)
					.Save(this.ConfigurationFilePath, SaveOptions.None);
			}
			catch { }
		}

		#endregion

		#region Data Retrieval

		/// <summary>
		/// Creates the request token.
		/// </summary>
		/// <returns>RequestToken.</returns>
		public RequestToken GetRequestToken() {
			var requestQueries = new RequestQueryCollection { new RequestQuery(@"api_key", this.APIKey) };
			var request = VideoScraperManager.CreateRequest(RequestMethod.GET, @"authentication/token/new", requestQueries);
			return VideoScraperManager.GetResponse<RequestToken>(request);
		}

		/// <summary>
		/// Searches the specified movie name.
		/// </summary>
		/// <typeparam name="TVideo">The type of the t video type.</typeparam>
		/// <param name="movieName">Name of the movie.</param>
		/// <returns>List&lt;TVideoType&gt;.</returns>
		public VideoCollection<TVideo> Search<TVideo>(string movieName)
			where TVideo : Video, new() {

			var videoType = typeof(TVideo);
			var searchPath = videoType.GetCustomAttribute<SearchPathAttribute>()?.Path;
			if (string.IsNullOrWhiteSpace(searchPath)) {
				throw new Exception($@"The video type {videoType.Name} does not have a search path.");
			}

			var videos = new VideoCollection<TVideo>();
			var pageNumber = 1;

			while (true) {
				var requestQueries = new RequestQueryCollection {
					new RequestQuery(@"api_key", this.APIKey),
					new RequestQuery(@"query", movieName),
					new RequestQuery(@"page", pageNumber.ToString()),
					new RequestQuery(@"include_adult", bool.TrueString.ToLower())
				};

				var request = VideoScraperManager.CreateRequest(RequestMethod.GET, $@"search/{searchPath}", requestQueries);
				var response = VideoScraperManager.GetResponse<SearchResponse<TVideo>>(request);
				videos.AddRange(response.Results);
				if (pageNumber >= response.TotalPages || response.Results.Count == 0) break;
				pageNumber++;
			}
			return videos;
		}

		/// <summary>
		/// Gets the details.
		/// </summary>
		/// <param name="video">The movie.</param>
		/// <returns>Movie.</returns>
		public TVideo GetDetails<TVideo>(TVideo video)
			where TVideo : Video, new() {

			if (video.DetailsRetrieved) return video;

			var videoType = typeof(TVideo);
			var searchPath = videoType.GetCustomAttribute<SearchPathAttribute>()?.Path;
			if (string.IsNullOrWhiteSpace(searchPath)) {
				throw new Exception($@"The video type {videoType.Name} does not have a search path.");
			}

			var requestQueries = new RequestQueryCollection { new RequestQuery(@"api_key", this.APIKey) };
			var request = VideoScraperManager.CreateRequest(RequestMethod.GET, $@"{searchPath}/{video.ID}", requestQueries);
			var response = VideoScraperManager.GetResponse<TVideo>(request);
			response.DetailsRetrieved = true;

			var responseAsMovie = response as Movie;
			if (responseAsMovie != null) {
				request = VideoScraperManager.CreateRequest(RequestMethod.GET, $@"{searchPath}/{video.ID}/release_dates", requestQueries);
				var releaseDatesResponse = VideoScraperManager.GetResponse<ReleaseDateResponse>(request);
				responseAsMovie.RegionReleaseDates = releaseDatesResponse.RegionReleaseDates;
			}			
			return response;
		}

		#endregion

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		public void Initialize() {
			this.LoadConfiguration();
		}
		
		#endregion

	}

}
