namespace VideoScraper.Core.DataContracts {

	#region Directives
	using System;
	using System.Globalization;
	using System.Runtime.Serialization;
	#endregion

	[DataContract]
	[Serializable]
	public class RequestToken {

		[DataMember(Name = @"success", IsRequired = false)]
		public bool Success { get; set; }

		[DataMember(Name = @"expires_at", IsRequired = false)]
		public string ExpiresAt { get; set; }

		[DataMember(Name = @"request_token", IsRequired = false)]
		public string Value { get; set; }

		public bool IsExpired() {
			DateTime expirationDate;
			if (!DateTime.TryParseExact(this.ExpiresAt, @"yyyy-MM-dd HH:mm:ss UTC", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out expirationDate)) {
				throw new Exception($@"The value {this.ExpiresAt} is not a valid expiration date.");
			}
			return expirationDate < DateTime.Now;
		}

	}

}
