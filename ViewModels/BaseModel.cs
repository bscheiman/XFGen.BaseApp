using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace App.ViewModels {
	public class BaseViewModel : INotifyPropertyChanged {
		public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging;
		public event PropertyChangedEventHandler PropertyChanged;

		protected void SetProperty<U>(ref U backingStore, U value, string propertyName, Action onChanged = null, Action<U> onChanging = null) {
			if (EqualityComparer<U>.Default.Equals(backingStore, value))
				return;

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

