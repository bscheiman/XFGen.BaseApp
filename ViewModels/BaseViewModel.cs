using PropertyChanged;
using Xamarin.Forms;
using App.Custom;
using PropertyChanging;
using System.Threading.Tasks;

namespace App.ViewModels {
	[ImplementPropertyChanged, ImplementPropertyChanging, ToString]
	public class BaseViewModel {
		public bool IsBusy { get; set; }
		public string Title { get; set; }
		public string Icon { get; set; }
		public INavigation Navigation { get; set; }

		public async virtual Task Update() {
		}
	}

	[ImplementPropertyChanged, ImplementPropertyChanging, ToString]
	public class BaseViewModel<T> : BaseViewModel {
		public ObservableCollectionEx<T> Collection { get; set; }

		public BaseViewModel() {
			Collection = new ObservableCollectionEx<T>();
		}
	}
}

