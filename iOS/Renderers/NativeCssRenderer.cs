using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using App.iOS.Renderers;
using Style;
using App.Interfaces;

[assembly: ExportRendererAttribute(typeof(Page), typeof(NativeCssRenderer))]
[assembly: ExportRendererAttribute(typeof(View), typeof(NativeCssViewRenderer))]
namespace App.iOS.Renderers {
	public class NativeCssRenderer : PageRenderer {
		protected override void OnElementChanged(VisualElementChangedEventArgs e) {
			base.OnElementChanged(e);

			if (!string.IsNullOrEmpty(e.NewElement.StyleId))
				View.SetCSSId(e.NewElement.StyleId);

			if (e.NewElement is IBasePage)
				View.AddCSSClass("basePage");
		}
	}

	public class NativeCssViewRenderer : ViewRenderer {
		protected override void OnElementChanged(ElementChangedEventArgs<View> e) {
			base.OnElementChanged(e);

			if (!string.IsNullOrEmpty(e.NewElement.StyleId))
				Control.SetCSSId(e.NewElement.StyleId);

			if (!string.IsNullOrEmpty(e.NewElement.ClassId))
				Control.AddCSSClass(e.NewElement.ClassId);
		}
	}
}

