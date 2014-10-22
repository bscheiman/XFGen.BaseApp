using SQLite;

namespace App.Data {
	public class BaseDbObject {
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}
