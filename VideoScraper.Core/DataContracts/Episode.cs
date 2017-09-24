namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;
	#endregion

	[DataContract]
	[Serializable]
	public class Episode {

		[DataMember(Name = @"air_date", IsRequired = false)]
		public string AirDate { get; set; }

		[DataMember(Name = @"crew", IsRequired = false)]
		public PersonCollection<CrewMember> Crew { get; set; } = new PersonCollection<CrewMember>();

		[DataMember(Name = @"id", IsRequired = false)]
		public int EpisodeID { get; set; }

		[DataMember(Name = @"episode_number", IsRequired = false)]
		public int EpisodeNumber { get; set; }

		[DataMember(Name = @"guest_stars", IsRequired = false)]
		public PersonCollection<CastMember> GuestStars { get; set; } = new PersonCollection<CastMember>();

		[DataMember(Name = @"name", IsRequired = false)]
		public string EpisodeName { get; set; }

		[DataMember(Name = @"overview", IsRequired = false)]
		public string Overview { get; set; }

		[DataMember(Name = @"production_code", IsRequired = false)]
		public string ProductionCode { get; set; }

		[DataMember(Name = @"season_number", IsRequired = false)]
		public int SeasonNumber { get; set; }

		[DataMember(Name = @"still_path", IsRequired = false)]
		public string StillPath { get; set; }

		[DataMember(Name = @"vote_average", IsRequired = false)]
		public decimal VoteAverage { get; set; }

		[DataMember(Name = @"vote_count", IsRequired = false)]
		public int VoteCount { get; set; }

	}

	[CollectionDataContract]
	[Serializable]
	public class EpisodeCollection
		: Collection<Episode> {

		[DataMember(Name = @"air_date", IsRequired = false)]
		public string AirDate { get; set; }

		[DataMember(Name = @"name", IsRequired = false)]
		public string Name { get; set; }

		[DataMember(Name = @"overview", IsRequired = false)]
		public string Overview { get; set; }

		[DataMember(Name = @"_id", IsRequired = false)]
		public string SeasonInternalID { get; set; }

		[DataMember(Name = @"id", IsRequired = false)]
		public int SeasonID { get; set; }

		[DataMember(Name = @"poster_path", IsRequired = false)]
		public string PosterPath { get; set; }

		[DataMember(Name = @"season_number", IsRequired = false)]
		public int SeasonNumber { get; set; }

	}	

}
