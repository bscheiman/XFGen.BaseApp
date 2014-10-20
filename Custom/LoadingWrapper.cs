using System;
using Xamarin.Forms;

namespace App.Custom {
	public class LoadingWrapper : IDisposable {
		public LoadingWrapper(string message = "Loading...") {
			Device.BeginInvokeOnMainThread(() => {
				// TODO: Add progress
			});
		}

		public void Dispose() {
			// TODO: Remove progress
		}
	}
}

