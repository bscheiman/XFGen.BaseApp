using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using App.Pages;
using App.iOS.Renderers;

[assembly: ExportRenderer(typeof(CustomNavPage), typeof(CustomNavPageRenderer))]
namespace App.iOS.Renderers {
	public class CustomNavPageRenderer : NavigationRenderer {
	}
}

