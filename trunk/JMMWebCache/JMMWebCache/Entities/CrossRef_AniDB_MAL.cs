using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JMMWebCache.Entities
{
	public class CrossRef_AniDB_MAL
	{
		public int CrossRef_AniDB_MALID { get; private set; }
		public int AnimeID { get; set; }
		public int MALID { get; set; }
		public int CrossRefSource { get; set; }
		public string Username { get; set; }
		public string MALTitle { get; set; }
	}
}