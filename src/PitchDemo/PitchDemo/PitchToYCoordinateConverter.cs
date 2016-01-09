using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PitchDemo
{
	class PitchToYCoordinateConverter : IMultiValueConverter
	{
		#region IMultiValueConverter Members

		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double y = (double)values[0];
			double height = (double)values[1];
			double circleDiameter = (double)values[2];
			double retVal = height * y - circleDiameter / 2.0;
			//Trace.WriteLine(string.Format("y = {0}, h = {1}, r = {2}, val = {3}", y, height, circleDiameter, retVal));
			return retVal;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
