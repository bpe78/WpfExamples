using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace ViewModelLocatorPattern.ViewModels
{
	public class Test3ViewModel : NotificationObject
	{
		public Test3ViewModel()
		{
		}

		public string Message
		{
			get { return "Test 3 View Model"; }
		}
	}
}
