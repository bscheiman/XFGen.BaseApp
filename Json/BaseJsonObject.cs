using System;
using System.Runtime.Serialization;

namespace App.Json {
	[DataContract]
	public class BaseJsonObject {
		public bool Error { get; set; }
		public Exception Exception { get; set; }
	}
}

