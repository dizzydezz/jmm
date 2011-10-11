using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMMWebCache.Entities
{
	public class AniDB_Updated
	{
		public int AniDB_UpdatedID { get; private set; }
		public long UpdateTime { get; set; }
		public string AnimeIDList { get; set; }
		public string Username { get; set; }
		public DateTime DateTimeCreated { get; set; }
	}
}