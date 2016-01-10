using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.ViewModel;

namespace ViewModelLocatorPattern.ViewModels
{
	public class Test1ViewModel : NotificationObject
	{
		public Test1ViewModel()
		{
		}

		public string Message
		{
			get { return "Test 1 View Model"; }
		}
	}
}
