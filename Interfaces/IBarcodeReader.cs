using System.Threading.Tasks;

namespace App.Interfaces {
	public interface IBarcodeReader {
		Task<string> ReadBarcodeAsync(string title, string footer);
	}
}

