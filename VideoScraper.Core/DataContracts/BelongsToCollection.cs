namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Runtime.Serialization;

	#endregion

	[DataContract]
	[Serializable]
	public class BelongsToCollection {

		[DataMember(Name = @"id", IsRequired = false)]
		public int ID { get; set; }

		[DataMember(Name = @"name", IsRequired = false)]
		public string Name { get; set; }

		[DataMember(Name = @"poster_path", IsRequired = false)]
		public string PosterPath { get; set; }

		[DataMember(Name = @"backdrop_path", IsRequired = false)]
		public string BackdropPath { get; set; }

	}

}
