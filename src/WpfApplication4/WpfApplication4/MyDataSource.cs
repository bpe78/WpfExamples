using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WpfApplication4
{
	//public class MyDataSource
	public class MyDataSource : ObservableCollection<User>
	{
		//public ObservableCollection<User> Users { get; set; }
		public MyDataSource()
		{
			//Users = new ObservableCollection<User>();
			LoadDummyData();
		}

		private void LoadDummyData()
		{
			this.Add(new User()
			{
				Name = "Frank",
				Phone = "(122) 555-1234",
				Country = "USA",
				Total = 432
			});

			this.Add(new User()
			{
				Name = "Bob",
				Phone = "(212) 555-1234",
				Country = "USA",
				Total = 456
			});

			this.Add(new User()
			{
				Name = "Mark",
				Phone = "(301) 555-1234",
				Country = "USA",
				Total = 123
			});

			this.Add(new User()
			{
				Name = "Pierre",
				Phone = "+33 (122) 555-1234",
				Country = "France",
				Total = 333
			});

			this.Add(new User()
			{
				Name = "Jacques",
				Phone = "+33 (122) 555-1234",
				Country = "France",
				Total = 222
			});

			this.Add(new User()
			{
				Name = "Olivier",
				Phone = "+33 (122) 555-1234",
				Country = "France",
				Total = 444
			});
		}
	}
}
