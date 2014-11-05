using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using App.Pages;
using App.Android.Renderers;

[assembly: ExportRenderer(typeof(CustomNavPage), typeof(CustomNavPageRenderer))]
namespace App.Android.Renderers {
	public class CustomNavPageRenderer : NavigationRenderer {
	}
}

