﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewSample
{
	public class UserGroupEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public List<UserEntity> Users { get; set; }
	}
}
