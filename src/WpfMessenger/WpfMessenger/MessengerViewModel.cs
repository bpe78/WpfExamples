using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;
using MessengerNetLibrary;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace WpfMessenger
{
    public class MessengerViewModel : BindableBase
	{
		private MsgServer _server;
		private MsgClient _client;

		public MessengerViewModel()
		{
			Thread.CurrentThread.Name = "UI Thread";
			_server = null;
			_client = null;
			_isConnected = false;

			_address = "127.0.0.1";
			_message = string.Empty;

			StatusMessages = new ObservableCollection<string>();
		}

		#region Properties

		private string _address;
		public string Address
		{
			get { return _address; }
			set
			{
				if (_address != value)
				{
					//TODO: validate address
					_address = value;
					OnPropertyChanged(() => this.Address);
					_connectCmd.RaiseCanExecuteChanged();
				}
			}
		}

		private bool _isServer;
		public bool IsServer
		{
			get { return _isServer; }
			set
			{
				if (_isServer != value)
				{
					_isServer = value;
                    OnPropertyChanged(() => this.IsServer);
				}
			}
		}

		private string _message;
		public string Message
		{
			get { return _message; }
			set
			{
				if (_message != value)
				{
					//TODO: validate message
					_message = value;
                    OnPropertyChanged(() => this.Message);
					_sendCmd.RaiseCanExecuteChanged();
				}
			}
		}

		private bool _isConnected;
		public bool IsConnected
		{
			get { return _isConnected; }
			set
			{
				if (_isConnected != value)
				{
					_isConnected = value;
                    OnPropertyChanged(() => this.IsConnected);
					_connectCmd.RaiseCanExecuteChanged();
				}
			}
		}

		public ObservableCollection<string> StatusMessages { get; private set; }

		#endregion

		#region Commands

		DelegateCommand _connectCmd;
		public ICommand ConnectCmd
		{
			get { return _connectCmd ?? (_connectCmd = new DelegateCommand(ExecuteConnect, CanExecuteConnect)); }
		}

		private void ExecuteConnect()
		{
			if (_isServer)
			{
				IsConnected = true;
				_server = new MsgServer();
				_server.ClientConnected += _server_ClientConnected;
				_server.MessageReceived += _server_MessageReceived;
				_server.ConnectionClosed += _server_ConnectionClosed;
				_server.Start(10000);
			}
			else
			{
				_client = new MsgClient();
				_client.Connect(_address);
			}
		}

		void _server_ConnectionClosed(object sender, ConnectionClosedEventArgs args)
		{
			App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => StatusMessages.Add("Client disconnected.")));
		}

		void _server_MessageReceived(object sender, MessageReceivedEventArgs args)
		{
			App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => StatusMessages.Add(string.Format("{0} - sent message : {1} ", args.ClientId, args.Message))));
		}

		void _server_ClientConnected(object sender, ClientConnectedEventArgs args)
		{
			App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => StatusMessages.Add("New client connected.")));
		}

		private bool CanExecuteConnect()
		{
			return (!_isConnected) && (_address != null) && (_address.Length > 0);
		}

		DelegateCommand _sendCmd;
		public ICommand SendCmd
		{
			get { return _sendCmd ?? (_sendCmd = new DelegateCommand(ExecuteSend, CanExecuteSend)); }
		}

		private void ExecuteSend()
		{
			throw new NotImplementedException();
		}

		private bool CanExecuteSend()
		{
			return (_message != null) && (_message.Length > 0);
		}

		#endregion
	}
}
