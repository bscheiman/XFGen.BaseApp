using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Acr.XamForms.UserDialogs.Droid;

[assembly: Dependency(typeof(UserDialogService))]
namespace App.Android {
	[Activity(Label = "App.Android.Android", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity {
		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			Xamarin.Forms.Forms.Init(this, bundle);
			Xamarin.FormsMaps.Init(this, bundle);

			SetPage(App.GetMainPage());
		}
	}
}

