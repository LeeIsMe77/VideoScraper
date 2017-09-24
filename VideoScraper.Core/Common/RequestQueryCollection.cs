namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	#endregion

	public class RequestQueryCollection
		: List<RequestQuery> {

		#region Collection Management

		/// <summary>
		/// Gets the <see cref="RequestQuery"/> with the specified request query name.
		/// </summary>
		/// <param name="requestQueryName">Name of the request query.</param>
		/// <returns>RequestQuery.</returns>
		public RequestQuery this[string requestQueryName] {
			get {
				return this.FirstOrDefault(requestQuery => string.Compare(requestQuery.QueryName, requestQueryName, StringComparison.Ordinal) == 0);
			}
		}

		/// <summary>
		/// Adds the specified query name.
		/// </summary>
		/// <param name="queryName">Name of the query.</param>
		/// <param name="queryValue">The query value.</param>
		/// <returns>RequestQuery.</returns>
		public RequestQuery Add(string queryName, string queryValue) {
			var requestQuery = new RequestQuery(queryName, queryValue);
			this.Add(requestQuery);
			return requestQuery;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString() {
			return string.Join(@"&", this.Select(requestQuery => $@"{requestQuery.QueryName}={requestQuery.QueryValue}"));
		}

		#endregion

	}

}
