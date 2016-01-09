using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRX.Services;

namespace TestRX.ViewModels
{
	class DetailsViewModel : ViewModelBase
	{
		GameStateService _gameState;
		GameEngineService _gameEngine;

		public DetailsViewModel(GameStateService gameState, GameEngineService gameEngine)
		{
			_gameState = gameState;
			_gameEngine = gameEngine;
		}
	}
}
