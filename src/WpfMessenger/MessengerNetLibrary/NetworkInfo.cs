using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;


namespace MessengerNetLibrary
{
	class NetworkInfo
	{
		public NetworkInfo()
		{

		}

		public void GetNetworkInfo()
		{
			foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
			{
				Console.WriteLine(ni.Id);
			}
		}
	}
}
