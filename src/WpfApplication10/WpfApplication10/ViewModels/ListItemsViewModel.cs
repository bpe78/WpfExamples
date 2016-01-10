using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace WpfApplication10
{
	public class ListItemsViewModel : NotificationObject
	{
		ShellViewModel parentVM;
		public ListItemsViewModel(ShellViewModel parentVM)
		{
			this.parentVM = parentVM;
		}

		public ObservableCollection<object> Items { get {return parentVM.Items;}}
	}
}
