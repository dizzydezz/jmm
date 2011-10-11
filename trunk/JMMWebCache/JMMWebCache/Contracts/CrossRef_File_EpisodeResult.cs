using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;

namespace OMMWebCache.Contracts
{
	[Serializable]
	public class CrossRef_File_EpisodeResult : XMLBase
	{
		public string Hash { get; set; }
		public int AnimeID { get; set; }
		public int EpisodeID { get; set; }
		public int Percentage { get; set; }
		public int EpisodeOrder { get; set; }

		public CrossRef_File_EpisodeResult(CrossRef_File_Episode xref)
		{
			this.Hash = xref.Hash;
			this.AnimeID = xref.AnimeID;
			this.EpisodeID = xref.EpisodeID;
			this.Percentage = xref.Percentage;
			this.EpisodeOrder = xref.EpisodeOrder;
		}
	}
}