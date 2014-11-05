using System;
using Xamarin.Forms;
using System.Linq.Expressions;

namespace App.Extensions {
	public static partial class Extensions {
		public static void BindTo<TModel, TV>(this DataTemplate template, BindableProperty targetProperty, Expression<Func<TModel, TV>> func) {
			template.SetBinding(targetProperty, new Binding((func.Body as MemberExpression).Member.Name));
		}
	}
}

