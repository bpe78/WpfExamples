using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common;

namespace Module2
{
	/// <summary>
	/// Interaction logic for Module2View.xaml
	/// </summary>
	public partial class Module2View : UserControl, IModule2View
	{
		IModule2ViewModel viewModel;
		public Module2View(IModule2ViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
			DataContext = viewModel;
		}
	}
}
