using Xamarin.Forms;
using App.Pages;

namespace App {
	public class App : Application {
		public App() {
			MainPage = new DemoPage();
		}

		protected override void OnStart() {
		}

		protected override void OnSleep() {
		}

		protected override void OnResume() {
		}
	}
}

