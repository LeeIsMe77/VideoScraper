namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;
	#endregion

	[DataContract]
	[Serializable]
	public class NameIDPair {

		[DataMember(Name = @"name", IsRequired = false)]
		public string Name { get; set; }

		[DataMember(Name = @"id", IsRequired = false)]
		public int ID { get; set; }

	}

	[CollectionDataContract]
	[Serializable]
	public class NameIDPairCollection
		: Collection<NameIDPair> { }

}
