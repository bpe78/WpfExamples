using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace WpfApplication4
{
	public class TotalSumConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var users = value as IEnumerable<object>;
			if (users == null)
				return "$0.00";

			double sum = users.Sum(user => ((User)user).Total);


			return sum.ToString("c");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new System.NotImplementedException();
		}
	}
}
