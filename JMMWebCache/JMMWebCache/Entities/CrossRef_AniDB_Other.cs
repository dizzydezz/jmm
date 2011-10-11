using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMMWebCache.Entities
{
	public class CrossRef_AniDB_Other
	{
		public int CrossRef_AniDB_OtherID { get; private set; }
		public int AnimeID { get; set; }
		public string CrossRefID { get; set; }
		public int CrossRefSource { get; set; }
		public int CrossRefType { get; set; }
		public int AdminApproved { get; set; }
		public string Username { get; set; }
	}
}