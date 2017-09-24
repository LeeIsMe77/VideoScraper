namespace VideoScraper.Core.Common {

	#region Directives
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	#endregion

	public class DataGridViewDisplayAttribute
		: Attribute {

		#region Properties

		/// <summary>
		/// Gets or sets a value indicating whether the property should created a frozen column in a data grid view.
		/// </summary>
		/// <value><c>true</c> if frozen; otherwise, <c>false</c>.</value>
		public bool Frozen { get; set; }

		/// <summary>
		/// Gets or sets the index of the property as displayed in a data grid view.
		/// </summary>
		/// <value>The index.</value>
		public int Index { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="DataGridViewDisplayAttribute"/> class.
		/// </summary>
		/// <param name="index">The index of the property as displayed in a data grid view.</param>
		/// <param name="frozen">if set to <c>true</c> freeze the column representing this property.</param>
		public DataGridViewDisplayAttribute(int index, bool frozen = false) {
			this.Index = index;
			this.Frozen = frozen;
		}

		#endregion

	}

}
