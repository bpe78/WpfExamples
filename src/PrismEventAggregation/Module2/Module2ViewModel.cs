using System.Windows.Input;
using Common;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Module2
{
    public class Module2ViewModel : BindableBase, IModule2ViewModel
	{
		private const int _id = 2;
		IEventAggregator _eventAggregator;
		public Module2ViewModel(IEventAggregator ea)
		{
			this._eventAggregator = ea;
			this._eventAggregator.GetEvent<SendEvent>().Subscribe(OnMessageReceived, ThreadOption.UIThread, false);
		}

		#region Properties

		string _text;
		public string Text
		{
			get { return _text; }
			set
			{
				if (_text != value)
				{
					_text = value;
                    OnPropertyChanged(() => this.Text);
				}
			}
		}

		string _receivedMessage;
		public string ReceivedMessage
		{
			get { return _receivedMessage; }
			set
			{
				if (_receivedMessage != value)
				{
					_receivedMessage = value;
                    OnPropertyChanged(() => this.ReceivedMessage);
				}
			}
		}

		#endregion

		#region Commands

		ICommand _sendCmd;
		public ICommand SendCmd
		{
			get { return _sendCmd ?? (_sendCmd = new DelegateCommand(ExecuteSendCmd)); }
		}

		private void ExecuteSendCmd()
		{
			var newEvent = new SendEventContent { SenderId = _id, Message = "Module2 : " + this.Text };
			_eventAggregator.GetEvent<SendEvent>().Publish(newEvent);
		}

		#endregion

		#region Helpers

		private void OnMessageReceived(SendEventContent message)
		{
			this.ReceivedMessage = message.Message;
		}



		#endregion
	}
}
