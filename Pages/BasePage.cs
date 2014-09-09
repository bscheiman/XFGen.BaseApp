using System;
using Xamarin.Forms;

namespace App.Pages {
	public class BasePage : ContentPage {
		public BasePage() {
			// iOS 7 Status bar
			Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
		}
	}
}

