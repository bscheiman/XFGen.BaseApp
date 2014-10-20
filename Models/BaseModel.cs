using System;
using PropertyChanged;
using Xamarin.Forms;

namespace App.Models {
	[ImplementPropertyChanged]
	public class BaseModel {
		public bool IsBusy { get; set; }
		public INavigation Navigation { get; set; }
	}
}

