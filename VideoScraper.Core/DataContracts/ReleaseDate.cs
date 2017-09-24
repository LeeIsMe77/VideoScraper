namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;
	#endregion

	[DataContract]
	[Serializable]
	public class ReleaseDate {

		[DataMember(Name = @"certification", IsRequired = false)]
		public string Certification { get; set; }

		[DataMember(Name = @"iso_639_1", IsRequired = false)]
		public string ISO639 { get; set; }

		[DataMember(Name = @"note", IsRequired = false)]
		public string Note { get; set; }

		[DataMember(Name = @"release_date", IsRequired = false)]
		public string Date { get; set; }

		[DataMember(Name = @"type", IsRequired = false)]
		public int Type { get; set; }

	}

	[CollectionDataContract]
	[Serializable]
	public class ReleaseDateCollection
		: Collection<ReleaseDate> { }

}
