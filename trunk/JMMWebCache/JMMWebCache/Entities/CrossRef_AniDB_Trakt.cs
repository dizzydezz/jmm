using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMMWebCache.Entities
{
	public class CrossRef_AniDB_Trakt
	{
		public int CrossRef_AniDB_TraktID { get; private set; }
		public int AnimeID { get; set; }
		public string TraktID { get; set; }
		public int TraktSeasonNumber { get; set; }
		public int AdminApproved { get; set; }
		public string Username { get; set; }
		public string ShowName { get; set; }
	}
}