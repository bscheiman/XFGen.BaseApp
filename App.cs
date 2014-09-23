using Xamarin.Forms;
using App.Pages;

namespace App {
	public class App {
		public static Page GetMainPage() {	
			return new BasePage();
		}
	}
}

