namespace VideoScraper {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	#endregion

	public static class StringExtension {

		/// <summary>
		/// Determines is the source values is contained in a list of values.
		/// </summary>
		/// <param name="thisString">The string to detect in the list.</param>
		/// <param name="comparisonType">Type of the comparison to perform.</param>
		/// <param name="values">The values to compare against.</param>
		/// <returns><c>true</c> if the source value is detected in the list, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// Null and empty strings are not the same.
		/// </remarks>
		public static bool In(this string thisString, StringComparison comparisonType, params string[] values) {
			return thisString.In(comparisonType, values.AsEnumerable<string>());
		}

		/// <summary>
		/// Determines is the source values is contained in a list of values.
		/// </summary>
		/// <param name="thisString">The string to detect in the list.</param>
		/// <param name="comparisonType">Type of the comparison to perform.</param>
		/// <param name="values">The values to compare against.</param>
		/// <returns><c>true</c> if the source value is detected in the list, <c>false</c> otherwise.</returns>
		/// <remarks>
		/// Null and empty strings are not the same.
		/// </remarks>
		public static bool In(this string thisString, StringComparison comparisonType, IEnumerable<string> values) {
			return values.Any(value => string.Compare(thisString, value, comparisonType) == 0);
		}

	}

}
