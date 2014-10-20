using Xamarin.Forms;
using System.Linq.Expressions;
using System;
using App.Models;
using App.Extensions;

namespace App.Pages {
	public class BasePage : BasePage<BaseModel> {
	}

	public class BasePage<TModel> : ContentPage where TModel : BaseModel, new() {
		TModel _backingModel;

		public TModel BackingModel {
			get {
				return _backingModel ?? (_backingModel = new TModel {
					Navigation = Navigation
				});
			}
		}

		public BasePage() {
			// iOS 7 Status bar
			Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 5);

			BindingContext = BackingModel;

			Bind(IsBusyProperty, m => m.IsBusy);
		}

		protected void Bind<TV>(BindableProperty property, Expression<Func<TModel, TV>> func) {
			SetBinding(property, new Binding((func.Body as MemberExpression).Member.Name));
		}

		protected TView Bind<TView, TV>(TView element, BindableProperty property, Expression<Func<TModel, TV>> func) where TView : Element {
			element.SetBinding(property, new Binding((func.Body as MemberExpression).Member.Name));

			return element;
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

