using System;
using PropertyChanged;
using Xamarin.Forms;

namespace App.ViewModels {
	[ImplementPropertyChanged]
	public class BaseViewModel {
		public bool IsBusy { get; set; }
		public INavigation Navigation { get; set; }
	}
}

