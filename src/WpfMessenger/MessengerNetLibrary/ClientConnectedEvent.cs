using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerNetLibrary
{
	public delegate void ClientConnectedEventHandler(object sender, ClientConnectedEventArgs args);

	public class ClientConnectedEventArgs : EventArgs
	{
	}
}
