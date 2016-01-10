using Microsoft.Practices.Prism.Mvvm;

namespace ComboBoxEnabledItems
{
    public class ItemDetailsViewModel : BindableBase
	{
		MainWindowViewModel _parentVM;
		IncomeItemEntity _entity;

		public ItemDetailsViewModel(MainWindowViewModel parentVM, IncomeItemEntity entity)
		{
			_parentVM = parentVM;
			_entity = entity;
		}

		#region Properties

		public int Id
		{
			get { return _entity.Id; }
			set
			{
				if (_entity.Id != value)
				{
					_entity.Id = value;
					OnPropertyChanged(() => this.Id);
				}
			}
		}

		public string Symbol
		{
			get { return _entity.Symbol; }
			set
			{
				if (_entity.Symbol != value)
				{
					_entity.Symbol = value;
                    OnPropertyChanged(() => this.Symbol);
				}
			}
		}

		public IncomeItemEntity Parent
		{
			get { return _entity.Parent; }
			set
			{
				if (_entity.Parent != value)
				{
					_entity.Parent = value;
                    OnPropertyChanged(() => this.Parent);
					//RaisePropertyChanged(() => this.IsEnabled);
				}
			}
		}

		public bool IsEnabled
		{
			get { return _parentVM.IsLeaf(_entity); }
		}


		#endregion
	}
}
