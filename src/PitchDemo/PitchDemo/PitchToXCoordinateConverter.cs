using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PitchDemo
{
	class PitchToXCoordinateConverter : IMultiValueConverter
	{
		#region IMultiValueConverter Members

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double x = (double)values[0];
			double width = (double)values[1];
			double circleDiameter = (double)values[2];
			double retVal = (width / 1.2) * (x + 0.1) - circleDiameter / 2.0;
			//Trace.WriteLine(string.Format("x = {0}, w = {1}, r = {2}, val = {3}", x, width, circleDiameter, retVal));
			return retVal;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
