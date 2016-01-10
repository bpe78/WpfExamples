using System.Windows.Input;
using Common;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Module1
{
    public class Module1ViewModel : BindableBase, IModule1ViewModel
	{
		private const int _id = 1;
		IEventAggregator _eventAggregator;
		public Module1ViewModel(IEventAggregator ea)
		{
			this._eventAggregator = ea;
			this._eventAggregator.GetEvent<SendEvent>().Subscribe(OnMessageReceived, ThreadOption.UIThread, false, EventFilter);
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
			var newEvent = new SendEventContent { SenderId = _id, Message = "Module1 : " + this.Text };
			_eventAggregator.GetEvent<SendEvent>().Publish(newEvent);
		}

		#endregion

		#region Helpers

		private void OnMessageReceived(SendEventContent message)
		{
			if(string.IsNullOrEmpty(this.ReceivedMessage))
				this.ReceivedMessage = message.Message;
			else
				this.ReceivedMessage = string.Format("{0}\n{1}", this.ReceivedMessage, message.Message);
		}

		private bool EventFilter(SendEventContent message)
		{
			return message.SenderId != _id;
		}

		#endregion
	}
}
