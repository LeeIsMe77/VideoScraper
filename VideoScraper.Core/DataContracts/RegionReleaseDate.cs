namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;
	#endregion

	[DataContract]
	[Serializable]
	public class RegionReleaseDate {

		[DataMember(Name = @"iso_3166_1", IsRequired = false)]
		public string RegionName { get; set; }

		[DataMember(Name = @"release_dates", IsRequired = false)]
		public ReleaseDateCollection ReleaseDates { get; set; } = new ReleaseDateCollection();

	}

	[CollectionDataContract]
	[Serializable]
	public class RegionReleaseDateCollection
		: Collection<RegionReleaseDate> { }

}
