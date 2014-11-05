using System;
using Xamarin.Forms;
using App.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace App.Data {
	public static class Database {
		static string DbFilename = DependencyService.Get<IPathHelper>().GetLibraryFullPath("config.db3");
		static SQLiteAsyncConnection DbContext { get; set; }

		static Database() {
			DbContext = new SQLiteAsyncConnection(DbFilename);
			var tables = typeof(Database).Assembly.GetTypes().Where(i => i.BaseType == typeof(BaseDbObject) && i.Name != "BaseDbObject").ToArray();
			var method = typeof(SQLiteConnection).GetMethod("CreateTableAsync");

			foreach (var type in tables) {
				var generic = method.MakeGenericMethod(type);
				generic.Invoke(DbContext, null);
			}
		}

		public static async Task<List<TObject>> Get<TObject>() where TObject : BaseDbObject, new() {
			return await DbContext.Table<TObject>().ToListAsync();
		}

		public static async Task<List<TObject>> Get<TObject>(Expression<Func<TObject, bool>> pred) where TObject : BaseDbObject, new() {
			return await DbContext.Table<TObject>().Where(pred).ToListAsync();
		}

		public static async Task<TObject> Get<TObject>(int id) where TObject : BaseDbObject, new() {
			return await DbContext.FindAsync<TObject>(x => x.Id == id);
		}

		public static async Task<int> Save<TObject>(TObject item) where TObject : BaseDbObject, new() {
			if (item.Id != 0) {
				await DbContext.UpdateAsync(item);

				return item.Id;
			}

			return await DbContext.InsertAsync(item);
		}

		public static async Task<int> Delete<TObject>(TObject obj) where TObject : BaseDbObject, new() {
			return await DbContext.DeleteAsync(obj.Id);
		}
	}
}

