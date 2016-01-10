using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace WpfApplication6
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Thread _processingThread;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			PersonViewModel viewModel = new PersonViewModel();

			DataContext = viewModel;

			_processingThread = new Thread(RunBackgroundThread);
			_processingThread.IsBackground = true;
			_processingThread.Name = "My background thread";
			_processingThread.Start(viewModel);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if ((_processingThread != null) && _processingThread.IsAlive)
			{
				_processingThread.Abort();
			}
			this.Close();
		}

		private void RunBackgroundThread(object parameter)
		{
			PersonViewModel model = parameter as PersonViewModel;

			int i = 0;
			if (model != null)
			{
				while (true)
				{
					model.FirstName = "John " + i;
					model.LastName = "Ewing " + i;
					i++;
					//Thread.Sleep(10);
					Thread.Yield();
				}
			}
		}
	}
}
