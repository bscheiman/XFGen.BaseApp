using App.ViewModels;
using Xamarin.Forms;

namespace App.Pages {
	public class DemoPage : BasePage<BaseViewModel> {
		public DemoPage() {
			// Hello, AppCreator!
			BackingModel.Title = "AppCreator";
		}

		protected override void ConfigureUI() {
			Content = ScrollWrap(new StackLayout {
				HorizontalOptions = LayoutOptions.Center,

				Padding = 0,
				Spacing = 5,
				Children = {
					GetLabel("Hi there!"),

					GetSpacing(30),

					GetLabel("This is a demo page that showcases AppCreator's ability to quickly prototype a working MVVM Page."),
					GetLabel("Feel free to browse the source or request more components."),

					GetLabel("You should change App.GetMainPage() to change your app's entry point."),

					GetSpacing(20),

					GetLabel("Most components have built-in Renderers. Or you can just use NativeCSS.")
				}
			});
		}

		protected Label GetLabel(string txt) {
			return new Label { Text = txt };
		}
	}
}

