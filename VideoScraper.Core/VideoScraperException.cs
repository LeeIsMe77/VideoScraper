namespace VideoScraper.Core {

	#region Directives
	using System;
	#endregion

	/// <summary>
	/// Used to throw a specialized exception type from within this library to a calling assembly or application.
	/// </summary>
	[Serializable]
	public class VideoScraperException
		: Exception {
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="VideoScraperException" /> class with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public VideoScraperException(string message)
			: base(message) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="VideoScraperException"/> class.
		/// </summary>
		/// <param name="innerException">The original exception.</param>
		/// <param name="message">The message.</param>
		public VideoScraperException(Exception innerException, string message)
			: base(message, innerException) { }

		#endregion

	}

}
