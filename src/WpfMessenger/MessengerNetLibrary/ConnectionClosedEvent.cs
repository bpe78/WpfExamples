using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerNetLibrary
{
	public delegate void ConnectionClosedEventHandler(object sender, ConnectionClosedEventArgs args);

	public class ConnectionClosedEventArgs : EventArgs
	{
	}
}
