using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMMWebCache.Repositories;
using OMMWebCache.Entities;
using OMMWebCache.Contracts;

namespace OMMWebCache
{
	public partial class GetCrossRef_File_Episode : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				Response.Write(Constants.ERROR_XML);
				return;

				string hash = Utils.GetParam("hash");
				if (hash.Trim().Length == 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				string uname = Utils.GetParam("uname");
				if (uname.Trim().Length == 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				CrossRef_File_EpisodeResultCollection colResults = new CrossRef_File_EpisodeResultCollection();
				CrossRef_File_Episode_Rep repCrossRef = new CrossRef_File_Episode_Rep();

				// check for user specific
				List<CrossRef_File_Episode> recs = repCrossRef.GetByHashAndUsername(hash, uname);
				if (recs.Count == 0)
				{
					// check for other users (anonymous)
					recs = repCrossRef.GetByHash(hash);

					int lastAnimeID = -1;
					bool invalidAnime = false;
					foreach (CrossRef_File_Episode xref in recs)
					{
						if (lastAnimeID < 0) lastAnimeID = xref.AnimeID;
						if (lastAnimeID != xref.AnimeID) invalidAnime = true;
					}

					// if we have one file which has been assigned episodes across multiple anime, something has gone
					// wrong somewhere. So let's delete all the records for this hash so we can start again
					// This case is for anonymous users, so this scenario could be likely
					if (invalidAnime)
					{
						foreach (CrossRef_File_Episode xref in recs)
							repCrossRef.Delete(xref.CrossRef_File_EpisodeID);

						Response.Write(Constants.ERROR_XML);
						return;
					}
				}
				else
				{
					// make sure all the episodes belong to the same anime
					int lastAnimeID = -1;
					bool invalidAnime = false;
					foreach (CrossRef_File_Episode xref in recs)
					{
						if (lastAnimeID < 0) lastAnimeID = xref.AnimeID;
						if (lastAnimeID != xref.AnimeID) invalidAnime = true;
					}

					// if we have one file which has been assigned episodes across multiple anime, something has gone
					// wrong somewhere. So let's delete all the records for this hash so we can start again
					if (invalidAnime)
					{
						foreach (CrossRef_File_Episode xref in recs)
							repCrossRef.Delete(xref.CrossRef_File_EpisodeID);

						Response.Write(Constants.ERROR_XML);
						return;
					}
				}

				if (recs.Count == 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				foreach (CrossRef_File_Episode xref in recs)
				{
					colResults.AnimeID = xref.AnimeID;
					colResults.AddToCollection(xref.EpisodeID.ToString(), xref.EpisodeOrder.ToString(), xref.Percentage.ToString());
				}

				string ret = Utils.ConvertToXML(colResults, typeof(CrossRef_File_EpisodeResultCollection));
				Response.Write(ret);
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
				return;
			}
		}
	}
}