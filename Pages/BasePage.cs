using Xamarin.Forms;
using System.Linq.Expressions;
using System;

namespace App.Pages {
	public class BasePage : ContentPage {
		public BasePage() {
			// iOS 7 Status bar
			Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 5);
		}

		protected View BindElement(View view, BindableProperty property, string path) {
			view.SetBinding(property, path);

			return view;
		}

		protected View BindElement<T>(View view, BindableProperty property, Expression<Func<T>> action) {
			var expression = (MemberExpression)action.Body;
			string propertyName = expression.Member.Name;

			return BindElement(view, property, propertyName);
		}

		protected void ResetPadding() {
			Padding = new Thickness(0, 0, 0, 0);
		}

		protected ScrollView ScrollWrap(View view) {
			return new ScrollView { Content = view, Padding = 0 };
		}

		protected Frame GetSpacing(int space) {
			return new Frame {
				Padding = new Thickness(0, 0, 0, space),
				BackgroundColor = Color.Transparent
			};
		}
	}

}

