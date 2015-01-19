using System;
using System.IO;
using Xamarin.Forms;
using App.Android.Implementations;
using AppCreator.Interfaces;

[assembly: Dependency(typeof(PathHelper))]
namespace App.Android.Implementations {
	public class PathHelper : IPathHelper {
		public string GetFullPath(string filename) {
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);

			return Path.Combine(documentsPath, filename);
		}

		public string GetLibraryFullPath(string filename) {
			return GetFullPath(filename);
		}
	}
}

