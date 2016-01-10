using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace ViewModelLocatorPattern.ViewModels
{
	public class Test2ViewModel : NotificationObject
	{
		public Test2ViewModel()
		{
		}

		public string Message
		{
			get { return "Test 2 View Model"; }
		}
	}
}
