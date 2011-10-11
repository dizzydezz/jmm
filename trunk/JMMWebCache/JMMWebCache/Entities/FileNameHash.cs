using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMMWebCache.Entities
{
	public class FileNameHash
	{
		public int FileNameHashID { get; private set; }
		public string FileName { get; set; }
		public long FileSize { get; set; }
		public string Username { get; set; }
		public string Hash { get; set; }
		public DateTime DateTimeUpdated { get; set; }
	}
}