using Xamarin.Forms;

namespace App.Extensions {
	public static partial class Extensions {
		public static TView BindTo<TView>(this TView visualElement, BindableProperty targetProperty, string modelProperty) where TView : Element {
			visualElement.SetBinding(targetProperty, new Binding(modelProperty));

			return visualElement;
		}
	}
}

