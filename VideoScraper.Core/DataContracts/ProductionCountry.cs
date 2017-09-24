namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;
	#endregion

	[DataContract]
	[Serializable]
	public class ProductionCountry {

		[DataMember(Name = @"name", IsRequired = false)]
		public string Name { get; set; }

		[DataMember(Name = @"iso_3166_1", IsRequired = false)]
		public string ISO3166 { get; set; }

	}

	[CollectionDataContract]
	[Serializable]
	public class ProductionCountryCollection
		: Collection<ProductionCountry> { }

}
