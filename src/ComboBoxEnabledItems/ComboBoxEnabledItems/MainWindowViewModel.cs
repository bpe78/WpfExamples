using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;

namespace ComboBoxEnabledItems
{
    public class MainWindowViewModel : BindableBase
	{
		private List<IncomeItemEntity> _incomeItems;
		public MainWindowViewModel()
		{
			_incomeItems = new List<IncomeItemEntity>();
			_incomeItems.Add(new IncomeItemEntity { Id = 1, Symbol = "Alimente", Parent = null });

			_incomeItems.Add(new IncomeItemEntity { Id = 2, Symbol = "Mancare", Parent = _incomeItems[0] });
			_incomeItems.Add(new IncomeItemEntity { Id = 3, Symbol = "Fructe", Parent = _incomeItems[1] });
			_incomeItems.Add(new IncomeItemEntity { Id = 4, Symbol = "Dulciuri", Parent = _incomeItems[1] });
			_incomeItems.Add(new IncomeItemEntity { Id = 5, Symbol = "FastFood", Parent = _incomeItems[1] });

			_incomeItems.Add(new IncomeItemEntity { Id = 6, Symbol = "Bautura", Parent = _incomeItems[0] });
			_incomeItems.Add(new IncomeItemEntity { Id = 7, Symbol = "Alcool", Parent = _incomeItems[5] });
			_incomeItems.Add(new IncomeItemEntity { Id = 8, Symbol = "Suc", Parent = _incomeItems[5] });

			_incomeItems.Add(new IncomeItemEntity { Id = 9, Symbol = "Banane", Parent = _incomeItems[2] });
			_incomeItems.Add(new IncomeItemEntity { Id = 10, Symbol = "Portocale", Parent = _incomeItems[2] });
			_incomeItems.Add(new IncomeItemEntity { Id = 11, Symbol = "Lamai", Parent = _incomeItems[2] });
			_incomeItems.Add(new IncomeItemEntity { Id = 12, Symbol = "Mere", Parent = _incomeItems[2] });

			_incomeItems.Add(new IncomeItemEntity { Id = 13, Symbol = "Mere Golden", Parent = _incomeItems[11] });
			_incomeItems.Add(new IncomeItemEntity { Id = 14, Symbol = "Mere Varatice", Parent = _incomeItems[11] });
			_incomeItems.Add(new IncomeItemEntity { Id = 15, Symbol = "Mere Ionathan", Parent = _incomeItems[11] });
			_incomeItems.Add(new IncomeItemEntity { Id = 16, Symbol = "Mere Voinesti", Parent = _incomeItems[11] });

			Items = new ObservableCollection<ItemDetailsViewModel>(_incomeItems.Select(e => new ItemDetailsViewModel(this, e)));

			Root = CreateHierarchyFromList(_incomeItems);
		}

		public ObservableCollection<ItemDetailsViewModel> Items { get; private set; }

		public TreeNode Root { get; private set; }

		public bool IsLeaf(IncomeItemEntity entity)
		{
			return !Items.Any(e => e.Parent == entity);
		}

		#region Helper methods

		private TreeNode CreateHierarchyFromList(List<IncomeItemEntity> items)
		{
			TreeNode root = new TreeNode();
			root.Symbol = string.Empty;

			PopulateChildren(root, null, items);

			return root;
		}

		private void PopulateChildren(TreeNode node, IncomeItemEntity info, List<IncomeItemEntity> items)
		{
			node.Children = items.Where(c => c.Parent == info).OrderBy(c => c.Id).Select(c =>
			{
				var tmp = new TreeNode();
				tmp.Symbol = c.Symbol;
				PopulateChildren(tmp, c, items);
				return tmp;
			}).ToList();
		}

		#endregion
	}
}
