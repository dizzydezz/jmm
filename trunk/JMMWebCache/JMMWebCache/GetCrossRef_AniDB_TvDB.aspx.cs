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
	public partial class GetCrossRef_AniDB_TvDB : System.Web.UI.Page
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

				CrossRef_AniDB_TvDBRepository repCrossRef = new CrossRef_AniDB_TvDBRepository();
				CrossRef_AniDB_TvDB xref = null;

				// check for admin approved
				List<CrossRef_AniDB_TvDB> recs = repCrossRef.GetByAnimeIDApproved(animeid);
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
					
					List<CrossRefStat> results = new List<CrossRefStat>();
					foreach (CrossRef_AniDB_TvDB xrefloc in recs)
					{
						bool found = false;
						foreach (CrossRefStat stat in results)
						{
							if (stat.TvDBID == xrefloc.TvDBID && stat.TvDBSeason == xrefloc.TvDBSeasonNumber)
							{
								found = true;
								stat.ResultCount++;
							}
						}
						if (!found)
						{
							CrossRefStat stat = new CrossRefStat();
							stat.ResultCount = 1;
							stat.TvDBID = xrefloc.TvDBID;
							stat.TvDBSeason = xrefloc.TvDBSeasonNumber;
							stat.CrossRef = xrefloc;
							results.Add(stat);
						}
					}

					CrossRefStat mostPopular = null;
					foreach (CrossRefStat stat in results)
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

				CrossRef_AniDB_TvDBResult result = new CrossRef_AniDB_TvDBResult(xref);
				string ret = Utils.ConvertToXML(result, typeof(CrossRef_AniDB_TvDBResult));
				Response.Write(ret);
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
				return;
			}
		}
	}

	public class CrossRefStat
	{
		public int AnimeID { get; set; }
		public int TvDBID { get; set; }
		public int TvDBSeason { get; set; }
		public int ResultCount { get; set; }
		public CrossRef_AniDB_TvDB CrossRef { get; set; }
	}
}