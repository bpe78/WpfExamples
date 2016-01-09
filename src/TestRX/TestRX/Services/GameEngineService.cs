using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace TestRX.Services
{
	class GameEngineService
	{
		GameStateService _gameState;

		public GameEngineService(GameStateService gameState)
		{
			_gameState = gameState;
		}

		#region SwitchDirectionCommand

		public void ToggleDirection()
		{
			_gameState.Direction = !_gameState.Direction;
		}

		#endregion

		public void ToggleClock()
		{
			if (_gameState.IsClockStarted)
				_gameState.StopClock();
			else
				_gameState.StartClock();
		}
	}
}
