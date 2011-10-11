using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMMWebCache.Contracts;
using OMMWebCache.Repositories;
using OMMWebCache.Entities;

namespace OMMWebCache
{
	public partial class GetCrossRef_AniDB_Trakt : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				string aid = Utils.GetParam("AnimeID");
				int animeid = 0;
				int.TryParse(aid, out animeid);

				if (animeid <= 0)
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

				CrossRef_AniDB_TraktRepository repCrossRef = new CrossRef_AniDB_TraktRepository();
				CrossRef_AniDB_Trakt xref = null;

				// check for admin approved
				List<CrossRef_AniDB_Trakt> recs = repCrossRef.GetByAnimeIDApproved(animeid);
				if (recs.Count > 0) xref = recs[0]; // should only be one

				// check for user specific
				if (xref == null)
				{
					recs = repCrossRef.GetByAnimeIDUser(animeid, uname);
					if (recs.Count > 0) xref = recs[0]; // should only be one
				}

				// check for other users (anonymous)
				if (xref == null)
				{
					// check for other users (anonymous)
					recs = repCrossRef.GetByAnimeID(animeid);
					if (recs.Count == 0)
					{
						Response.Write(Constants.ERROR_XML);
						return;
					}

					// find the most popular result

					List<CrossRefTraktStat> results = new List<CrossRefTraktStat>();
					foreach (CrossRef_AniDB_Trakt xrefloc in recs)
					{
						bool found = false;
						foreach (CrossRefTraktStat stat in results)
						{
							if (stat.TraktID.Equals(xrefloc.TraktID, StringComparison.InvariantCultureIgnoreCase) && stat.TraktSeason == xrefloc.TraktSeasonNumber)
							{
								found = true;
								stat.ResultCount++;
							}
						}
						if (!found)
						{
							CrossRefTraktStat stat = new CrossRefTraktStat();
							stat.ResultCount = 1;
							stat.TraktID = xrefloc.TraktID;
							stat.TraktSeason = xrefloc.TraktSeasonNumber;
							stat.CrossRef = xrefloc;
							results.Add(stat);
						}
					}

					CrossRefTraktStat mostPopular = null;
					foreach (CrossRefTraktStat stat in results)
					{
						if (mostPopular == null)
							mostPopular = stat;
						else
						{
							if (stat.ResultCount > mostPopular.ResultCount) mostPopular = stat;
						}
					}

					xref = mostPopular.CrossRef;
				}

				CrossRef_AniDB_TraktResult result = new CrossRef_AniDB_TraktResult(xref);
				string ret = Utils.ConvertToXML(result, typeof(CrossRef_AniDB_TraktResult));
				Response.Write(ret);
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
				return;
			}
		}
	}

	public class CrossRefTraktStat
	{
		public int AnimeID { get; set; }
		public string TraktID { get; set; }
		public int TraktSeason { get; set; }
		public int ResultCount { get; set; }
		public CrossRef_AniDB_Trakt CrossRef { get; set; }
	}
}