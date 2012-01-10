using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Contracts;
using JMMWebCache.Entities;

namespace JMMWebCache.Contracts
{
	[Serializable]
	public class CrossRef_AniDB_MALResult : XMLBase
	{
		public int AnimeID { get; set; }
		public int MALID { get; set; }
		public int CrossRefSource { get; set; }
		public string MALTitle { get; set; }
		public int StartEpisodeType { get; set; }
		public int StartEpisodeNumber { get; set; }

		// default constructor
		public CrossRef_AniDB_MALResult()
		{
		}

		public CrossRef_AniDB_MALResult(CrossRef_AniDB_MAL xref)
		{
			this.AnimeID = xref.AnimeID;
			this.MALID = xref.MALID;
			this.CrossRefSource = xref.CrossRefSource;
			this.MALTitle = xref.MALTitle;
			this.StartEpisodeType = xref.StartEpisodeType;
			this.StartEpisodeNumber = xref.StartEpisodeNumber;
		}
	}
}