using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.BaseModel;

namespace DomainModel
{
	public class Device : ObservableObject, IDataErrorInfo
	{
		[Key]
		public int Id
		{
			get { return _id; }
			set { SetProperty(ref _id, value); }
		}
		private int _id;

		[Required]
		[StringLength(10, MinimumLength=5)]
		public string SerialNumber
		{
			get { return _serialNumber; }
			set { SetProperty(ref _serialNumber, value); }
		}
		private string _serialNumber;

		[Required]
		[StringLength(10)]
		public string Identifier
		{
			get { return _identifier; }
			set { SetProperty(ref _identifier, value); }
		}
		private string _identifier;

		private Client _client;
		public virtual Client CurrentClient
		{
			get { return _client; }
			set { SetProperty(ref _client, value); }
		}


		#region IDataErrorInfo Members

		public string Error
		{
			get { throw new NotImplementedException(); }
		}

		public string this[string propertyName]
		{
			get
			{
				string errors = string.Empty;

				if (string.IsNullOrEmpty(propertyName) || (propertyName == "SerialNumber"))
				{
					if (string.IsNullOrEmpty(_serialNumber))
						errors = "The SerialNumber cannot be empty.";
					else if ((_serialNumber.Length < 5) || (_serialNumber.Length > 10))
						errors = "Invalid length.";
				}
				if (string.IsNullOrEmpty(propertyName) || (propertyName == "SerialNumber"))
				{
				}

				return errors;
			}
		}

		#endregion
	}
}
