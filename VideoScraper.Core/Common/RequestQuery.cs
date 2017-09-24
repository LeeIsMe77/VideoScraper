namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	#endregion

	public class RequestQuery {

		#region Properties

		#region QueryName

		/// <summary>
		/// Gets the name of the query.
		/// </summary>
		/// <value>The name of the query.</value>
		public string QueryName { get; }

		#endregion

		#region QueryValue

		/// <summary>
		/// Gets or sets the query value.
		/// </summary>
		/// <value>The query value.</value>
		public string QueryValue { get; set; } 
		
		#endregion

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="RequestQuery"/> class.
		/// </summary>
		/// <param name="queryName">Name of the query.</param>
		/// <param name="queryValue">The query value.</param>
		public RequestQuery(string queryName, string queryValue) {
			this.QueryName = queryName;
			this.QueryValue = queryValue;
		}

		#endregion

	}

}
