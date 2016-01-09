using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.BaseModel;

namespace DomainModel
{
	public class Client : ObservableObject
	{
		private int _id;
		public int Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

		private string _identification;
		public string Identification
		{
			get { return _identification; }
			set { SetProperty(ref _identification, value); }
		}
	}
}
