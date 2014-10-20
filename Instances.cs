using System;
using Acr.XamForms.UserDialogs;
using Xamarin.Forms;

namespace App {
	public static class Instances {
		public static IUserDialogService Dialogs = DependencyService.Get<IUserDialogService>();
	}
}

