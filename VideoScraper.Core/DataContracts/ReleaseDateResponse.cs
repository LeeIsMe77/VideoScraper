namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Runtime.Serialization;

	#endregion

	[DataContract]
	[Serializable]
	public class ReleaseDateResponse {

		[DataMember(Name = @"id", IsRequired = false)]
		public int ID { get; set; }
		
		[DataMember(Name = @"results", IsRequired = false)]
		public RegionReleaseDateCollection RegionReleaseDates { get; set; }

	}

}
