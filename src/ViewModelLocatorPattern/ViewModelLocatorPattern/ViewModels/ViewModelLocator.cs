using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace ViewModelLocatorPattern.ViewModels
{
	public class ViewModelLocator : NotificationObject
	{
		public ViewModelLocator()
		{
		}

		Test1ViewModel viewModel1;
		public Test1ViewModel VM1
		{
			get { return viewModel1 ?? (viewModel1 = new Test1ViewModel()); }
		}

		Test2ViewModel viewModel2;
		public Test2ViewModel VM2
		{
			get { return viewModel2 ?? (viewModel2 = new Test2ViewModel()); }
		}


		Test3ViewModel viewModel3;
		public Test3ViewModel VM3
		{
			get { return viewModel3 ?? (viewModel3 = new Test3ViewModel()); }
		}
	}
}
