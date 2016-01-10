using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerNetLibrary
{
	public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs args);

	public class MessageReceivedEventArgs : EventArgs
	{
		public MessageReceivedEventArgs(string clientId, string message)
		{
			ClientId = clientId;
			Message = message;
		}

		public string ClientId { get; private set; }
		public string Message { get; private set; }
	}
}
