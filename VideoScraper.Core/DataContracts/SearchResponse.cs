namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Runtime.Serialization;
	#endregion

	[DataContract]
	[Serializable]
	public class SearchResponse<TVideo>
		where TVideo : Video {

		[DataMember(Name = @"page", IsRequired = false)]
		public int PageNumber { get; set; }

		[DataMember(Name = @"total_results", IsRequired = false)]
		public int TotalResults { get; set; }

		[DataMember(Name = @"total_pages", IsRequired = false)]
		public int TotalPages { get; set; }

		[DataMember(Name = @"results", IsRequired = false)]
		public VideoCollection<TVideo> Results { get; set; }

	}

}
