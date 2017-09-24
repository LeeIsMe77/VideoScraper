namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	#endregion

	public class SearchPathAttribute
		: Attribute {

		/// <summary>
		/// Gets or sets the path.
		/// </summary>
		/// <value>The path.</value>
		public string Path { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SearchPathAttribute"/> class.
		/// </summary>
		/// <param name="path">The path.</param>
		public SearchPathAttribute(string path) {
			this.Path = path;
		}

	}

}
