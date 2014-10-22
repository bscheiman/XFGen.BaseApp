using System;

namespace App.Interfaces {
	public interface IPathHelper {
		string GetFullPath(string filename);
		string GetLibraryFullPath(string filename);
	}
}

