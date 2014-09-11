using Xamarin.Forms;
using System.Linq.Expressions;
using System;

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

		protected View BindElement<T>(View view, BindableProperty property, Expression<Func<T>> action) {
			var expression = (MemberExpression)action.Body;
			string propertyName = expression.Member.Name;

			return BindElement(view, property, propertyName);
		}
	}

}

