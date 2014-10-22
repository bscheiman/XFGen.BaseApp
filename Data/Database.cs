using System;
using Xamarin.Forms;
using App.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace App.Data {
	public static class Database {
		static string DbFilename = DependencyService.Get<IPathHelper>().GetLibraryFullPath("config.db3");
		static SQLiteConnection DbContext { get; set; }
		static readonly object _lockObject = new object();

		static Database() {
			DbContext = new SQLiteConnection(DbFilename);
			var tables = typeof(Database).Assembly.GetTypes().Where(i => i.BaseType == typeof(BaseDbObject) && i.Name != "BaseDbObject").ToArray();
			var method = typeof(SQLiteConnection).GetMethod("CreateTable", new[] { typeof(CreateFlags) });

			foreach (var type in tables) {
				var generic = method.MakeGenericMethod(type);
				generic.Invoke(DbContext, new object[] { CreateFlags.None });
			}
		}

		public static IEnumerable<TObject> Get<TObject>() where TObject : BaseDbObject, new() {
			lock (_lockObject)
				return DbContext.Table<TObject>().ToList();
		}

		public static IEnumerable<TObject> Get<TObject>(Func<TObject, bool> pred) where TObject : BaseDbObject, new() {
			lock (_lockObject)
				return DbContext.Table<TObject>().Where(pred).ToList();
		}

		public static TObject Get<TObject>(int id) where TObject : BaseDbObject, new() {
			lock (_lockObject)
				return DbContext.Table<TObject>().FirstOrDefault(x => x.Id == id);
		}

		public static int Save<TObject>(TObject item) where TObject : BaseDbObject, new() {
			lock (_lockObject) {
				if (item.Id != 0) {
					DbContext.Update(item);

					return item.Id;
				}

				return DbContext.Insert(item);
			}
		}

		public static int Delete<TObject>(TObject obj) where TObject : BaseDbObject, new() {
			return DbContext.Delete<TObject>(obj.Id);
		}
	}
}

