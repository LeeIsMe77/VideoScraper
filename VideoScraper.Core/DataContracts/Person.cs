namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Collections.ObjectModel;
	using System.Runtime.Serialization;

	#endregion

	[DataContract]
	[Serializable]
	public class Person {

		[DataMember(Name = @"gender", IsRequired = false)]
		public int? Gender { get; set; }

		[DataMember(Name = @"id", IsRequired = false)]
		public int ID { get; set; }

		[DataMember(Name = @"name", IsRequired = false)]
		public string Name { get; set; }

		[DataMember(Name = @"profile_path", IsRequired = false)]
		public string ProfilePath { get; set; }

	}

	[CollectionDataContract]
	[Serializable]
	public class PersonCollection<TPerson>
		: Collection<TPerson>
		where TPerson : Person { }

	[DataContract]
	[Serializable]
	public class CastMember
		: Person {

		[DataMember(Name = @"cast_id", IsRequired = false)]
		public int CastID { get; set; }

		[DataMember(Name = @"character", IsRequired = false)]
		public string Character { get; set; }

		[DataMember(Name = @"credit_id", IsRequired = false)]
		public string CreditID { get; set; }

		[DataMember(Name = @"order", IsRequired = false)]
		public int Order { get; set; }

	}

	[DataContract]
	[Serializable]
	public class CrewMember
		: Person {

		[DataMember(Name = @"credit_id", IsRequired = false)]
		public int CreditID { get; set; }

		[DataMember(Name = @"department", IsRequired = false)]
		public string Department { get; set; }

		[DataMember(Name = @"job", IsRequired = false)]
		public string Job { get; set; }
		
	}

}
