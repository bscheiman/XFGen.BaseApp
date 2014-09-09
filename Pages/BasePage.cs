using Xamarin.Forms;

namespace App.Pages {
	public class BasePage : ContentPage {
		public BasePage() {
			// iOS 7 Status bar
			Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
		}

		protected View BindElement(View view, BindableProperty property, string path) {
			view.SetBinding(property, path);

			return view;
		}
	}

}

