using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace App.ViewModels {
	public class BaseViewModel : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging;

		private void SetProperty<T>(ref T backingStore, T value, Expression<Func<T>> action, Action onChanged = null, Action<T> onChanging = null) {
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return;

			var expression = (MemberExpression)action.Body;
			string propertyName = expression.Member.Name;

			if (onChanging != null)
				onChanging(value);

			OnPropertyChanging(propertyName);

			backingStore = value;

			if (onChanged != null)
				onChanged();

			OnPropertyChanged(propertyName);
		}


		public void OnPropertyChanging(string propertyName) {
			if (PropertyChanging == null)
				return;

			PropertyChanging(this, new Xamarin.Forms.PropertyChangingEventArgs(propertyName));
		}


		public void OnPropertyChanged(string propertyName) {
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}

