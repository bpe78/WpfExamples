using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Events;

namespace Common
{
	public class SendEvent : CompositePresentationEvent<SendEventContent>
	{
	}

	public class SendEventContent
	{
		public int SenderId { get; set; }
		public string Message { get; set; }
	}
}
