using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;

namespace OMMWebCache.Contracts
{
	[Serializable]
	public class CrossRef_AniDB_OtherResult : XMLBase
	{
		public int AnimeID { get; set; }
		public string CrossRefID { get; set; }

		// default constructor
		public CrossRef_AniDB_OtherResult()
		{
		}

		public CrossRef_AniDB_OtherResult(CrossRef_AniDB_Other xref)
		{
			this.AnimeID = xref.AnimeID;
			this.CrossRefID = xref.CrossRefID;
		}
	}
}