namespace VideoScraper {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	#endregion

	public static class TypeExtension {

		/// <summary>
		/// Gets the custom attribute.
		/// </summary>
		/// <typeparam name="TAttribute">The type of the t attribute.</typeparam>
		/// <param name="thisType">Type of the this.</param>
		/// <param name="inherit">if set to <c>true</c> [inherit].</param>
		/// <returns>TAttribute.</returns>
		public static TAttribute GetCustomAttribute<TAttribute>(this Type thisType, bool inherit = false) 
			where TAttribute : Attribute {
			return thisType
				.GetCustomAttributes(typeof(TAttribute), inherit)
				.FirstOrDefault() as TAttribute;
		}

	}

}
