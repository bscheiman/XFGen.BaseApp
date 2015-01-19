using System;
using System.IO;
using Xamarin.Forms;
using AppCreator.iOS.Implementations;
using UIKit;
using Foundation;
using AppCreator.Interfaces;

[assembly: Dependency(typeof(PathHelper))]
namespace AppCreator.iOS.Implementations {
	public class PathHelper : IPathHelper {
		public string GetFullPath(string filename) {
			string documentsPath = UIDevice.CurrentDevice.CheckSystemVersion(8, 0) 
									? NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path
									: Environment.GetFolderPath(Environment.SpecialFolder.Personal);

			return Path.Combine(documentsPath, filename);
		}

		public string GetLibraryFullPath(string filename) {
			string documentsPath = UIDevice.CurrentDevice.CheckSystemVersion(8, 0) 
									? NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User)[0].Path
									: Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(documentsPath, "..", "Library");

			if (!File.Exists(libraryPath))
				Directory.CreateDirectory(libraryPath);

			return Path.Combine(libraryPath, filename);
		}
	}
}

