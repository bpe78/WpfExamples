using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace PitchDemo
{
	class MainViewModel : BindableBase
	{
		Teams _currentTeam = Teams.Home;

		public MainViewModel()
		{
			Points = new ObservableCollection<PointViewModel>();
			/*Points.Add(new PointViewModel("1", -0.1, 0.2, Teams.Home));
			Points.Add(new PointViewModel("2", 0.0, 0.2, Teams.Home));
			Points.Add(new PointViewModel("3", 0.5, 0.5, Teams.Home));
			Points.Add(new PointViewModel("4", 1.0, 0.3, Teams.Home));
			Points.Add(new PointViewModel("5", 1.0, 1.0, Teams.Home));*/
		}

		public ObservableCollection<PointViewModel> Points { get; private set; }

		DelegateCommand _switchDirectionCmd;
		public ICommand SwitchDirectionCommand
		{
			get { return _switchDirectionCmd ?? (_switchDirectionCmd = new DelegateCommand(ExecuteSwitchDirection)); }
		}

		private void ExecuteSwitchDirection()
		{
			foreach (var p in Points)
				p.SwitchDirection();
		}

		#region SwitchTeamsCommand

		DelegateCommand _switchTeamsCmd;
		public ICommand SwitchTeamsCommand
		{
			get { return _switchTeamsCmd ?? (_switchTeamsCmd = new DelegateCommand(ExecuteSwitchTeams)); }
		}

		private void ExecuteSwitchTeams()
		{
			_currentTeam = (_currentTeam == Teams.Home) ? Teams.Away : Teams.Home;

			foreach (var p in Points)
				p.Team = _currentTeam;
		}

		#endregion

		#region MyCommand

		DelegateCommand<PitchPoint> _myCmd;
		public ICommand MyCommand
		{
			get { return _myCmd ?? (_myCmd = new DelegateCommand<PitchPoint>(ExecuteMyCommand)); }
		}

		private void ExecuteMyCommand(PitchPoint point)
		{
			var newPoint = new PointViewModel(Points.Count.ToString(), point.X, point.Y, _currentTeam);
			Points.Add(newPoint);
		}

		#endregion

		#region ContextMenuCommand

		DelegateCommand<PitchPoint> _contextMenuCmd;
		public ICommand ContextMenuCommand
		{
			get { return _contextMenuCmd ?? (_contextMenuCmd = new DelegateCommand<PitchPoint>(ExecuteContextMenu)); }
		}

		private void ExecuteContextMenu(PitchPoint point)
		{
			Points.Clear();

			var newPoint = new PointViewModel(Points.Count.ToString(), point.X, point.Y, _currentTeam);
			Points.Add(newPoint);
		}

		#endregion
	}
}
