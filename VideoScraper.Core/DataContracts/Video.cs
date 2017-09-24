namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.ComponentModel;
	using System.Runtime.Serialization;
	using Common;
	#endregion

	#region Video

	[DataContract]
	[Serializable]
	public abstract class Video {

		[DataMember(Name = @"backdrop_path", IsRequired = false)]
		public string BackdropPath { get; set; }

		[DataMember(Name = @"cast", IsRequired = false)]
		public PersonCollection<CastMember> Cast { get; set; } = new PersonCollection<CastMember>();

		[DataMember(Name = @"crew", IsRequired = false)]
		public PersonCollection<CrewMember> Crew { get; set; } = new PersonCollection<CrewMember>();

		[DataMember(Name = @"genre_ids", IsRequired = false)]
		public int[] GenreIDs { get; set; }

		[DataMember(Name = @"genres", IsRequired = false)]
		public NameIDPairCollection Genres { get; set; } = new NameIDPairCollection();

		[DataMember(Name = @"homepage", IsRequired = false)]
		public string Homepage { get; set; }

		[DataGridViewDisplay(0, true)]
		[DataMember(Name = @"id", IsRequired = false)]
		public int ID { get; set; }

		[DataGridViewDisplay(100)]
		[DataMember(Name = @"original_language", IsRequired = false)]
		[DisplayName(@"Original Language")]
		public string OriginalLanguage { get; set; }

		[DataMember(Name = @"overview", IsRequired = false)]
		public string Overview { get; set; }

		[DataMember(Name = @"popularity", IsRequired = false)]
		[DataGridViewDisplay(101)]
		public decimal Popularity { get; set; }

		[DataMember(Name = @"poster_path", IsRequired = false)]
		public string PosterPath { get; set; }

		[DataMember(Name = @"production_companies", IsRequired = false)]
		public NameIDPairCollection ProductionCompanies { get; set; }

		[DataMember(Name = @"status", IsRequired = false)]
		public string Status { get; set; }

		[DataGridViewDisplay(102)]
		[DataMember(Name = @"vote_average", IsRequired = false)]
		[DisplayName(@"Vote Average")]
		public decimal VoteAverage { get; set; }

		[DataGridViewDisplay(103)]
		[DataMember(Name = @"vote_count", IsRequired = false)]
		[DisplayName(@"Vote Count")]
		public int VoteCount { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [details retrieved].
		/// </summary>
		/// <value><c>true</c> if [details retrieved]; otherwise, <c>false</c>.</value>
		public bool DetailsRetrieved { get; set; }

	}

	#endregion

	#region Movie

	[DataContract]
	[Serializable]
	[SearchPath(@"movie")]
	public class Movie
		: Video {

		[DataMember(Name = @"belongs_to_collection", IsRequired = false)]
		public Collection BelongsToCollection { get; set; }

		[DataMember(Name = @"budget", IsRequired = false)]
		public int Budget { get; set; }

		[DataGridViewDisplay(int.MaxValue - 2)]
		[DataMember(Name = @"adult", IsRequired = false)]
		public bool IsAdult { get; set; }

		[DataMember(Name = @"imdb_id", IsRequired = false)]
		public string IMDBID { get; set; }

		[DataGridViewDisplay(2)]
		[DataMember(Name = @"original_title", IsRequired = false)]
		public string OriginalTitle { get; set; }

		[DataMember(Name = @"production_countries", IsRequired = false)]
		public ProductionCountryCollection ProductionCountries { get; set; }

		public RegionReleaseDateCollection RegionReleaseDates { get; set; } = new RegionReleaseDateCollection();

		[DataGridViewDisplay(3)]
		[DataMember(Name = @"release_date", IsRequired = false)]
		public string ReleaseDate { get; set; }

		[DataMember(Name = @"revenue", IsRequired = false)]
		public int Revenue { get; set; }

		[DataMember(Name = @"runtime", IsRequired = false)]
		public int? Runtime { get; set; }

		[DataMember(Name = @"spoken_languages", IsRequired = false)]
		public SpokenLanguageCollection SpokenLanguages { get; set; }

		[DataMember(Name = @"tagline", IsRequired = false)]
		public string Tagline { get; set; }

		[DataGridViewDisplay(1, true)]
		[DataMember(Name = @"title", IsRequired = false)]
		public string Title { get; set; }

		[DataGridViewDisplay(int.MaxValue - 1)]
		[DataMember(Name = @"video", IsRequired = false)]
		public bool Video { get; set; }

	}

	#endregion

	#region TVShow

	[DataContract]
	[Serializable]
	[SearchPath(@"tv")]
	public class TVShow
		: Video {

		[DataMember(Name = @"created_by", IsRequired = false)]
		public Person CreatedBy { get; set; }

		[DataMember(Name = @"episode_run_time", IsRequired = false)]
		public int[] EpisodeRunTime { get; set; }

		[DataGridViewDisplay(3)]
		[DataMember(Name = @"first_air_date", IsRequired = false)]
		[DisplayName(@"First Air Date")]
		public string FirstAirDate { get; set; }

		[DataMember(Name = @"in_production", IsRequired = false)]
		public bool InProduction { get; set; }

		[DataMember(Name = @"languages", IsRequired = false)]
		public string[] Languages { get; set; }

		[DataMember(Name = @"last_air_date", IsRequired = false)]
		public string LastAirDate { get; set; }

		[DataGridViewDisplay(1, true)]
		[DataMember(Name = @"name", IsRequired = false)]
		public string Name { get; set; }

		[DataMember(Name = @"networks", IsRequired = false)]
		public NameIDPairCollection Networks { get; set; }

		[DataMember(Name = @"number_of_episodes", IsRequired = false)]
		public int NumberOfEpisodes { get; set; }

		[DataMember(Name = @"number_of_seasons", IsRequired = false)]
		public int NumberOfSeasons { get; set; }

		[DataMember(Name = @"origin_country", IsRequired = false)]
		public string[] OriginCountries { get; set; }
		
		[DataMember(Name = @"original_name", IsRequired = false)]
		[DataGridViewDisplay(2)]
		[DisplayName(@"Original Name")]
		public string OriginalName { get; set; }

		[DataMember(Name = @"seasons", IsRequired = false)]
		public SeasonCollection Seasons { get; set; }

		[DataMember(Name = @"type", IsRequired = false)]
		public string Type { get; set; }

	}

	#endregion

}
