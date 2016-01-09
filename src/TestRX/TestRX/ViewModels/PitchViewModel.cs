using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using TestRX.Services;

namespace TestRX.ViewModels
{
	class PitchViewModel : ViewModelBase
	{
		GameStateService _gameState;
		GameEngineService _gameEngine;

		public PitchViewModel(GameStateService gameState, GameEngineService gameEngine)
		{
			_gameState = gameState;
			_gameEngine = gameEngine;

			Initialize();
		}

		private void Initialize()
		{
			_directionSubscription = _gameState.DirectionMonitor.Subscribe(newValue => OnNextDirection(newValue), () => OnCompletedDirection());
			_clockTimeSubscription = _gameState.ClockTimeMonitor.Subscribe(newValue => OnNextClockTime(newValue), () => OnCompletedClocktime());
			_clockStatusSubscription = _gameState.ClockStatusMonitor.Subscribe(newValue => OnNextClockStatus(newValue), () => OnCompletedClockStatus());
		}

		#region Direction

		DelegateCommand _switchDirectionCmd;
		public ICommand SwitchDirectionCommand
		{
			get { return _switchDirectionCmd ?? (_switchDirectionCmd = new DelegateCommand(ExecuteSwitchDirection)); }
		}

		private void ExecuteSwitchDirection()
		{
			_gameEngine.ToggleDirection();
		}


		bool _direction;
		public bool Direction
		{
			get { return _direction; }
			set { SetProperty(ref _direction, value); }
		}

		IDisposable _directionSubscription;
		private void OnNextDirection(bool direction)
		{
			Direction = direction;
		}

		private void OnCompletedDirection()
		{
			_directionSubscription.Dispose();
		}

		#endregion

		#region ClockTime
		
		DelegateCommand _toggleClockCmd;
		public ICommand ToggleClockCommand
		{
			get { return _toggleClockCmd ?? (_toggleClockCmd = new DelegateCommand(ExecuteToggleClock)); }
		}

		private void ExecuteToggleClock()
		{
			_gameEngine.ToggleClock();
		}


		int _clockTime;
		public int ClockTime
		{
			get { return _clockTime; }
			set { SetProperty(ref _clockTime, value); }
		}

		IDisposable _clockTimeSubscription;
		private void OnNextClockTime(int clockTime)
		{
			ClockTime = clockTime;
		}

		private void OnCompletedClocktime()
		{
			_clockTimeSubscription.Dispose();
		}

		#endregion

		public bool IsClockStarted
		{
			get { return _gameState.IsClockStarted; }
			set
			{
				if (_gameState.IsClockStarted != value)
				{
					_gameState.IsClockStarted = value;
					OnPropertyChanged(() => IsClockStarted);
				}
			}
		}

		IDisposable _clockStatusSubscription;
		private void OnNextClockStatus(bool clockStatus)
		{
			IsClockStarted = clockStatus;
		}

		private void OnCompletedClockStatus()
		{
			_clockStatusSubscription.Dispose();
		}
	}
}
