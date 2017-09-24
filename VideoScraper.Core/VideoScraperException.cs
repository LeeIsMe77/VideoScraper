namespace VideoScraper.Core {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	#endregion
	
	public class VideoScraperException
		: Exception {

		#region Properties

		/// <summary>
		/// Gets the original exception.
		/// </summary>
		/// <value>The original exception.</value>
		public Exception OriginalException { get; }

		#endregion

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
		/// <param name="originalException">The original exception.</param>
		/// <param name="message">The message.</param>
		public VideoScraperException(Exception originalException, string message)
			: base(message) {
			this.OriginalException = originalException;
		}

		#endregion

	}
}
