using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;

namespace OMMWebCache.Contracts
{
	[Serializable]
	public class CrossRef_AniDB_TvDBResult : XMLBase
	{
		public int AnimeID { get; set; }
		public int TvDBID { get; set; }
		public int TvDBSeasonNumber { get; set; }
		public int AdminApproved { get; set; }
		public string SeriesName { get; set; }

		// default constructor
		public CrossRef_AniDB_TvDBResult()
		{
		}

		public CrossRef_AniDB_TvDBResult(CrossRef_AniDB_TvDB xref)
		{
			this.AnimeID = xref.AnimeID;
			this.TvDBID = xref.TvDBID;
			this.TvDBSeasonNumber = xref.TvDBSeasonNumber;
			this.AdminApproved = xref.AdminApproved;
			this.SeriesName = xref.SeriesName;
		}
	}
}