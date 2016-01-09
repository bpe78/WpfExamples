using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestRX.Services;
using TestRX.ViewModels;

namespace TestRX
{
	class MainViewModel : ViewModelBase
	{
		GameEngineService _gameEngine;
		GameStateService _gameState;
		public MainViewModel()
		{
			_gameState = new GameStateService(new ObservableTimerService());
			_gameEngine = new GameEngineService(_gameState);

			PitchVM = new PitchViewModel(_gameState, _gameEngine);
			DetailsVM = new DetailsViewModel(_gameState, _gameEngine);

			_gameState.Initialize();
		}

		public PitchViewModel PitchVM { get; private set; }

		public DetailsViewModel DetailsVM { get; private set; }
	}
}
