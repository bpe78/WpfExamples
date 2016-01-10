using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace MessengerNetLibrary
{
    public class MsgServer
    {
			TcpListener _server;
			private bool _close;
			public event ClientConnectedEventHandler ClientConnected;
			public event MessageReceivedEventHandler MessageReceived;
			public event ConnectionClosedEventHandler ConnectionClosed;

			public MsgServer()
			{
				_close = false;
			}

			public bool Shutdown
			{
				get { return _close; }
				set
				{
					lock (this)
					{
						if (_close != value)
						{
							_close = value;
						}
					}
				}
			}

			public void Start(int port)
			{
				IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
				_server = new TcpListener(endPoint);

				_server.Start(5);

				Task.Factory.StartNew(() =>
				{
					while (!_close)
					{
						TcpClient client = _server.AcceptTcpClient();
						//TODO: add client to a list

						// Start a new thread
						Task.Factory.StartNew(() => { StartClientConversation(client); });
					}
				});
			}

			#region Helper Methods

			private void OnClientConnected()
			{
				var handler = ClientConnected;
				if (handler != null)
					handler(this, new ClientConnectedEventArgs());
			}

			private void OnMessageReceived(string clientName, string message)
			{
				var handler = MessageReceived;
				if (handler != null)
					handler(this, new MessageReceivedEventArgs(clientName, message));
			}

			private void OnConnectionClosed()
			{
				var handler = ConnectionClosed;
				if (handler != null)
					handler(this, new ConnectionClosedEventArgs());
			}

			private void StartClientConversation(TcpClient client)
			{
				try
				{
					string clientID = client.Client.RemoteEndPoint.ToString();
					Thread.CurrentThread.Name = clientID;
					OnMessageReceived(clientID, Thread.CurrentThread.ManagedThreadId.ToString());
					//TODO: log connected !
					OnClientConnected();

					using (NetworkStream stream = client.GetStream())
					{
						//while (!(client.Client.Poll(1000 * 1000, SelectMode.SelectRead) && (client.Client.Available == 0)))
						{
							ReceiveMessage(stream);
						}
						//OnMessageReceived("Received total", length.ToString());

						stream.Close();
					}

					client.Close();
					OnConnectionClosed();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			private byte[] ReceiveMessage(NetworkStream stream)
			{
				try
				{
					Stopwatch sw = new Stopwatch();
					sw.Start();
					int messageLength = 0;
					const int maxMesssageLength = 32 * 1024;
					byte[] bytes = new byte[maxMesssageLength];
					int bytesReceived = 0;

					using (MemoryStream ms = new MemoryStream())
					{
						while ((bytesReceived = stream.Read(bytes, 0, maxMesssageLength)) > 0)
						{
							messageLength += bytesReceived;
							ms.Write(bytes, 0, bytesReceived);
							System.Diagnostics.Debug.WriteLine(bytesReceived);
						}

						ms.Seek(0, SeekOrigin.Begin);
						using (BinaryWriter bw = new BinaryWriter(new FileStream("d:\\received.bin", FileMode.OpenOrCreate)))
						{
							bw.Write(ms.GetBuffer(), 0, messageLength);
							bw.Close();
						}

						ms.Close();
					}

					sw.Stop();
					OnMessageReceived("Received total = ", messageLength.ToString());
					OnMessageReceived("Time = ", sw.ElapsedMilliseconds.ToString());
					return null;
				}
				catch (Exception e)
				{
					System.Diagnostics.Debug.WriteLine(e.Message);
				}
				return null;
			}

			private string ReceiveMessage1(NetworkStream stream)
			{
				int bytesReceived = 0;
				byte[] bytes = new byte[1024];
				StringBuilder sb = new StringBuilder();

				while ((bytesReceived = stream.Read(bytes, 0, bytes.Length)) > 0)
				{
					string data = Encoding.ASCII.GetString(bytes, 0, bytesReceived);
					if(data.Length > 0)
					OnMessageReceived("new client", data);
				}

				return sb.ToString();
			}

			#endregion
		}
}
