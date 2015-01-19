using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Acr.XamForms.UserDialogs.Droid;

[assembly: Dependency(typeof(UserDialogService))]
namespace App {
	[Activity(Label = "App.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsApplicationActivity {
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			Forms.Init(this, bundle);

			LoadApplication(new App());
		}
	}
}

