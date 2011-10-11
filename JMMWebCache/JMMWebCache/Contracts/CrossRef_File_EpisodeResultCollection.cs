using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMMWebCache.Contracts
{
	[Serializable]
	public class CrossRef_File_EpisodeResultCollection : XMLBase
	{
		public int AnimeID { get; set; }
		public string EpisodeIDs { get; set; }
		public string EpisodeOrders { get; set; }
		public string EpisodePercentages { get; set; }


		// default constructor
		public CrossRef_File_EpisodeResultCollection()
		{
			EpisodeIDs = "";
			EpisodeOrders = "";
			EpisodePercentages = "";
		}

		public void AddToCollection(string epid, string eporder, string eppct)
		{
			if (EpisodeIDs.Length > 0)
			{
				EpisodeIDs += "|";
			}
			EpisodeIDs += epid;

			if (EpisodeOrders.Length > 0)
			{
				EpisodeOrders += "|";
			}
			EpisodeOrders += eporder;

			if (EpisodePercentages.Length > 0)
			{
				EpisodePercentages += "|";
			}
			EpisodePercentages += eppct;
			
		}
	}
}