using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Acr.XamForms.UserDialogs.iOS;

[assembly: Dependency(typeof(UserDialogService))]
namespace App.iOS {
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate {
		public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
			Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}

