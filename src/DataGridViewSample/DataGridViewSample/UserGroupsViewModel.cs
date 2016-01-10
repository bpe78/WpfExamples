using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Microsoft.Practices.Prism.Mvvm;

namespace DataGridViewSample
{
    public class UserGroupsViewModel : BindableBase
	{
		private List<UserEntity> _users;
		private CollectionViewSource _cvs;

		public UserGroupsViewModel()
		{
			_users = new List<UserEntity>();
			_users.Add(new UserEntity { Id = 1, Username = "Bogdan", Description = "Admin, user, developer" });
			_users.Add(new UserEntity { Id = 2, Username = "Irina", Description = "Admin" });
			_users.Add(new UserEntity { Id = 3, Username = "Dragos", Description = "Admin, developer" });
			_users.Add(new UserEntity { Id = 4, Username = "Sorin", Description = "User, developer" });
			_users.Add(new UserEntity { Id = 5, Username = "Cosmin", Description = "User" });

			UserGroups = new ObservableCollection<UserGroupEntity>();
			UserGroups.Add(new UserGroupEntity { Id = 1, Name = "Administrators", Description = "Administrators group", Users = new List<UserEntity>() });
			UserGroups[0].Users.Add(_users.Find(u => u.Id == 1));
			UserGroups[0].Users.Add(_users.Find(u => u.Id == 2));
			UserGroups[0].Users.Add(_users.Find(u => u.Id == 3));

			UserGroups.Add(new UserGroupEntity { Id = 2, Name = "Users", Description = "Users group", Users = new List<UserEntity>() });
			UserGroups[1].Users.Add(_users.Find(u => u.Id == 1));
			UserGroups[1].Users.Add(_users.Find(u => u.Id == 4));
			UserGroups[1].Users.Add(_users.Find(u => u.Id == 5));

			UserGroups.Add(new UserGroupEntity { Id = 3, Name = "Developers", Description = "Developers group", Users = new List<UserEntity>() });
			UserGroups[2].Users.Add(_users.Find(u => u.Id == 1));
			UserGroups[2].Users.Add(_users.Find(u => u.Id == 3));
			UserGroups[2].Users.Add(_users.Find(u => u.Id == 4));

			_cvs = new CollectionViewSource();
			_cvs.Source = UserGroups;
		}

		public ObservableCollection<UserGroupEntity> UserGroups { get; private set; }

        private UserGroupEntity _selectedUserGroup;
        public UserGroupEntity SelectedUserGroup
		{
			get { return _selectedUserGroup; }
            set { SetProperty(ref _selectedUserGroup, value); }
		}
	}
}
