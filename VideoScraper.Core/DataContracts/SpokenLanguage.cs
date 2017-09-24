namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;

	#endregion

	[DataContract]
	[Serializable]
	public class SpokenLanguage {

		[DataMember(Name = @"name", IsRequired = false)]
		public string Name { get; set; }

		[DataMember(Name = @"iso_639_1", IsRequired = false)]
		public string ISO639 { get; set; }

	}

	[CollectionDataContract]
	[Serializable]
	public class SpokenLanguageCollection
		: Collection<SpokenLanguage> { }

}
