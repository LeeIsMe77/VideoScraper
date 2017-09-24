namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Net;
	using System.Reflection;
	using System.Runtime.Serialization.Json;
	using DataContracts;

	#endregion

	public class RequestManager {

		#region Constants
		private const string CONFIGURATION_FILE_NAME = "VideoScraper.xml";
		private const string URL_HOST = @"api.themoviedb.org";
		private const string URL_SCHEME = @"https";
		private const int URL_VERSION = 3;
		private const string REQUEST_QUERY_NAME_API_KEY = @"api_key";
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

			if (string.IsNullOrWhiteSpace(requestQueries[REQUEST_QUERY_NAME_API_KEY]?.QueryValue)) {
				throw new VideoScraperException(null, @"The API key cannot be blank.");
			}

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

		#region Properties
		private readonly SearchProvider _configurationManager;

		#region APIRequestQuery

		private RequestQuery _apiRequestQuery;

		/// <summary>
		/// Gets the API request query.
		/// </summary>
		/// <value>The API request query.</value>
		public RequestQuery APIRequestQuery {
			get { return _apiRequestQuery ?? (_apiRequestQuery = new RequestQuery(REQUEST_QUERY_NAME_API_KEY, _configurationManager.APIKey)); }
		}

		#endregion

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="RequestManager"/> class.
		/// </summary>
		public RequestManager(SearchProvider configurationManager) {
			_configurationManager = configurationManager;
		}

		#endregion

		#region Methods

		#region Data Retrieval
		
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
					this.APIRequestQuery,
					new RequestQuery(@"query", movieName),
					new RequestQuery(@"page", pageNumber.ToString()),
					new RequestQuery(@"include_adult", bool.TrueString.ToLower())
				};

				var request = RequestManager.CreateRequest(RequestMethod.GET, $@"search/{searchPath}", requestQueries);
				var response = RequestManager.GetResponse<SearchResponse<TVideo>>(request);
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

			var requestQueries = new RequestQueryCollection { this.APIRequestQuery };
			var request = RequestManager.CreateRequest(RequestMethod.GET, $@"{searchPath}/{video.ID}", requestQueries);
			var response = RequestManager.GetResponse<TVideo>(request);
			response.DetailsRetrieved = true;

			var responseAsMovie = response as Movie;
			if (responseAsMovie != null) {
				request = RequestManager.CreateRequest(RequestMethod.GET, $@"{searchPath}/{video.ID}/release_dates", requestQueries);
				var releaseDatesResponse = RequestManager.GetResponse<ReleaseDateResponse>(request);
				responseAsMovie.RegionReleaseDates = releaseDatesResponse.RegionReleaseDates;
			}			
			return response;
		}

		#endregion
		
		#endregion

	}

}
