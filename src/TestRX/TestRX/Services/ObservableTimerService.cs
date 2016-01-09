using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRX.Services
{
	class ObservableTimerService
	{
		System.Timers.Timer _timer;
		IObservable<int> _observable;

		public IObservable<int> GetTimerSequence(int startTime, int intervalMs)
		{
			return _observable ?? (_observable = Observable.Create<int>(observer =>
				{
					int elapsedInterval = startTime;
					_timer = new System.Timers.Timer();
					_timer.Interval = intervalMs;
					_timer.Elapsed += (s, e) => { elapsedInterval += intervalMs; observer.OnNext(elapsedInterval); };
					return _timer;
				}));
		}

		public void Start()
		{
			_timer.Start();
		}

		public void Stop()
		{
			_timer.Stop();
		}
	}
}
