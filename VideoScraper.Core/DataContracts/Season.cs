namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;

	#endregion

	[DataContract]
	[Serializable]
	public class Season {

		[DataMember(Name = @"air_date", IsRequired = false)]
		public string AirDate { get; set; }

		[DataMember(Name = @"episode_count", IsRequired = false)]
		public int EpisodeCount { get; set; }

		public EpisodeCollection Episodes { get; set; } = new EpisodeCollection();

		[DataMember(Name = @"id", IsRequired = false)]
		public int ID { get; set; }

		[DataMember(Name = @"poster_path", IsRequired = false)]
		public string PosterPath { get; set; }

		[DataMember(Name = @"season_number", IsRequired = false)]
		public int SeasonNumber { get; set; }

	}

	[CollectionDataContract]
	[Serializable]
	public class SeasonCollection
		: Collection<Season> { }

}
