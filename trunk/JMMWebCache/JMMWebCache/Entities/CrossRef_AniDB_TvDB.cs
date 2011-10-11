using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMMWebCache.Entities
{
	public class CrossRef_AniDB_TvDB
	{
		public int CrossRef_AniDB_TvDBID { get; private set; }
		public int AnimeID { get; set; }
		public int TvDBID { get; set; }
		public int TvDBSeasonNumber { get; set; }
		public int CrossRefSource { get; set; }
		public int AdminApproved { get; set; }
		public string Username { get; set; }
		public string SeriesName { get; set; }
	}
}