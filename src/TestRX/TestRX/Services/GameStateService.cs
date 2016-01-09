using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace TestRX.Services
{
	class GameStateService
	{
		ObservableTimerService _timerService;
		IObservable<int> _timeSequence;
		IDisposable _timeSubscription;

		public GameStateService(ObservableTimerService timerService)
		{
			if (timerService == null) throw new ArgumentNullException();
			
			_timerService = timerService;
			_timeSequence = _timerService.GetTimerSequence(100*1000, 1000);
			_timeSubscription = _timeSequence.Subscribe(newTime => ClockTime = newTime / 1000);

			Direction = true;
		}

		public void Initialize()
		{
			ClockTime = 100;
			IsClockStarted = false;
		}

		public void Shutdown()
		{
			_directionSubject.OnCompleted();
			_clockTimeSubject.OnCompleted();
			_clockStatusSubject.OnCompleted();
			_timeSubscription.Dispose();
		}

		#region SwitchDirection

		bool _direction;
		public bool Direction
		{
			get { return _direction; }
			set
			{
				if (_direction != value)
				{
					_direction = value;
					DirectionMonitor.OnNext(_direction);
				}
			}
		}

		BehaviorSubject<bool> _directionSubject;
		public ISubject<bool> DirectionMonitor { get { return _directionSubject ?? (_directionSubject = new BehaviorSubject<bool>(Direction)); } }


		#endregion

		#region ClockTime

		int _clockTime;
		public int ClockTime
		{
			get { return _clockTime; }
			set
			{
				if (_clockTime != value)
				{
					_clockTime = value;

					ClockTimeMonitor.OnNext(_clockTime);
				}
			}
		}

		Subject<int> _clockTimeSubject;
		public ISubject<int> ClockTimeMonitor { get { return _clockTimeSubject ?? (_clockTimeSubject = new Subject<int>()); } }

		#endregion

		bool _isClockStarted;
		public bool IsClockStarted
		{
			get { return _isClockStarted; }
			set
			{
				if (_isClockStarted != value)
				{
					_isClockStarted = value;
					ClockStatusMonitor.OnNext(_isClockStarted);
				}
			}
		}

		Subject<bool> _clockStatusSubject;
		public ISubject<bool> ClockStatusMonitor { get { return _clockStatusSubject ?? (_clockStatusSubject = new Subject<bool>()); } }


		public void StartClock()
		{
			if (IsClockStarted) throw new InvalidOperationException();

			_timerService.Start();
			IsClockStarted = true;
		}

		public void StopClock()
		{
			if (!IsClockStarted) throw new InvalidOperationException();

			_timerService.Stop();
			IsClockStarted = false;
		}
	}
}
