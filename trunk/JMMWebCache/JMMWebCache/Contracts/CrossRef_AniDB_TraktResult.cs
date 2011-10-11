using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;

namespace OMMWebCache.Contracts
{
	[Serializable]
	public class CrossRef_AniDB_TraktResult : XMLBase
	{
		public int AnimeID { get; set; }
		public string TraktID { get; set; }
		public int TraktSeasonNumber { get; set; }
		public int AdminApproved { get; set; }
		public string ShowName { get; set; }

		// default constructor
		public CrossRef_AniDB_TraktResult()
		{
		}

		public CrossRef_AniDB_TraktResult(CrossRef_AniDB_Trakt xref)
		{
			this.AnimeID = xref.AnimeID;
			this.TraktID = xref.TraktID;
			this.TraktSeasonNumber = xref.TraktSeasonNumber;
			this.AdminApproved = xref.AdminApproved;
			this.ShowName = xref.ShowName;
		}
	}
}