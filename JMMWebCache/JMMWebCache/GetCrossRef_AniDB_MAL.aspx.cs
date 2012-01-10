using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JMMWebCache.Entities;
using OMMWebCache;
using JMMWebCache.Repositories;
using JMMWebCache.Contracts;

namespace JMMWebCache
{
	public partial class GetCrossRef_AniDB_MAL : System.Web.UI.Page
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

				CrossRef_AniDB_MALRepository repCrossRef = new CrossRef_AniDB_MALRepository();

				List<CrossRef_AniDB_MALResult> results = new List<CrossRef_AniDB_MALResult>();

				// check for user specific
				List<CrossRef_AniDB_MAL> recs = repCrossRef.GetByAnimeIDUser(animeid, uname);
				// check for other users
				if (recs.Count == 0)
				{
					// try user lwerndly
					recs = repCrossRef.GetByAnimeIDUser(animeid, "lwerndly");
					if (recs.Count == 0)
					{
						// try user jmediamanager
						recs = repCrossRef.GetByAnimeIDUser(animeid, "jmediamanager");
					}
				}

				if (recs.Count == 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}
				else
				{
					foreach (CrossRef_AniDB_MAL rec in recs)
					{
						CrossRef_AniDB_MALResult result = new CrossRef_AniDB_MALResult(rec);
						results.Add(result);
					}
					string ret = Utils.ConvertToXML(results, typeof(List<CrossRef_AniDB_MALResult>));
					Response.Write(ret);
				}
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
				return;
			}
		}
	}
}