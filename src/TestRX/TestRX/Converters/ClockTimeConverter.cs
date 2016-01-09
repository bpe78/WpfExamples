using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TestRX.Converters
{
	public class ClockTimeConverter : IValueConverter
	{
		readonly char[] _separator = { ':' };

		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType() != typeof(int)) throw new InvalidCastException();

			int clockTime = (int)value;
			int min = clockTime / 60;
			int sec = clockTime % 60;

			return string.Format("{0:D02} : {1:D02}", min, sec);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value.GetType() != typeof(string)) throw new InvalidCastException();

			string clock = (string)value;
			var digits = clock.Split(_separator);
			if (digits.Count() != 2) throw new InvalidOperationException();
			int min = int.Parse(digits[0]);
			int sec = int.Parse(digits[1]);

			return (min * 60) + sec;
		}

		#endregion
	}
}
