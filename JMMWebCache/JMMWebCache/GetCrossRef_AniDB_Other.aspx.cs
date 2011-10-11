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
	public partial class GetCrossRef_AniDB_Other : System.Web.UI.Page
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

				string xtype = Utils.GetParam("CrossRefType");
				int xrefType = 0;
				int.TryParse(xtype, out xrefType);

				if (xrefType <= 0)
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

				CrossRef_AniDB_OtherRepository repCrossRef = new CrossRef_AniDB_OtherRepository();
				CrossRef_AniDB_Other xref = null;

				// check for user specific
				List<CrossRef_AniDB_Other> recs;
				if (xref == null)
				{
					recs = repCrossRef.GetByAnimeIDAndTypeAndUser(animeid, uname, (CrossRefType)xrefType);
					if (recs.Count > 0) xref = recs[0]; // should only be one
				}

				// check for other users (anonymous)
				if (xref == null)
				{
					// check for other users (anonymous)
					recs = repCrossRef.GetByAnimeIDAndType(animeid, (CrossRefType)xrefType);
					if (recs.Count == 0)
					{
						Response.Write(Constants.ERROR_XML);
						return;
					}

					// find the most popular result

					List<CrossRefStatOther> results = new List<CrossRefStatOther>();
					foreach (CrossRef_AniDB_Other xrefloc in recs)
					{
						bool found = false;
						foreach (CrossRefStatOther stat in results)
						{
							if (stat.CrossRefID.Equals(xrefloc.CrossRefID, StringComparison.InvariantCultureIgnoreCase))
							{
								found = true;
								stat.ResultCount++;
							}
						}
						if (!found)
						{
							CrossRefStatOther stat = new CrossRefStatOther();
							stat.ResultCount = 1;
							stat.CrossRefID = xrefloc.CrossRefID;
							stat.CrossRef = xrefloc;
							results.Add(stat);
						}
					}

					CrossRefStatOther mostPopular = null;
					foreach (CrossRefStatOther stat in results)
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

				CrossRef_AniDB_OtherResult result = new CrossRef_AniDB_OtherResult(xref);
				string ret = Utils.ConvertToXML(result, typeof(CrossRef_AniDB_OtherResult));
				Response.Write(ret);
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
				return;
			}
		}
	}

	public class CrossRefStatOther
	{
		public int AnimeID { get; set; }
		public string CrossRefID { get; set; }
		public int ResultCount { get; set; }
		public CrossRef_AniDB_Other CrossRef { get; set; }
	}
}