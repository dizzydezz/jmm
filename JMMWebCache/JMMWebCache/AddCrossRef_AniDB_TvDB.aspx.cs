using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMMWebCache.Repositories;
using System.IO;
using System.Xml;
using OMMWebCache.Entities;
using JMMWebCache;

namespace OMMWebCache
{
	public partial class AddCrossRef_AniDB_TvDB : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				CrossRef_AniDB_TvDBRepository repCrossRef = new CrossRef_AniDB_TvDBRepository();

				StreamReader reader = new StreamReader(this.Request.InputStream);
				String xmlData = reader.ReadToEnd();

				XmlDocument docXRef = new XmlDocument();
				docXRef.LoadXml(xmlData);

				string uname = Utils.TryGetProperty("AddCrossRef_AniDB_TvDB_Request", docXRef, "Username");
				string sname = Utils.TryGetProperty("AddCrossRef_AniDB_TvDB_Request", docXRef, "SeriesName");

				string aid = Utils.TryGetProperty("AddCrossRef_AniDB_TvDB_Request", docXRef, "AnimeID");
				int animeid = 0;
				int.TryParse(aid, out animeid);

				string tvid = Utils.TryGetProperty("AddCrossRef_AniDB_TvDB_Request", docXRef, "TvDBID");
				int tvDBID = 0;
				int.TryParse(tvid, out tvDBID);

				string tvseason = Utils.TryGetProperty("AddCrossRef_AniDB_TvDB_Request", docXRef, "TvDBSeason");
				int tvDBSeason = 0;
				if (!int.TryParse(tvseason, out tvDBSeason))
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}


				if (string.IsNullOrEmpty(uname) || animeid <= 0 || tvDBID <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				CrossRef_AniDB_TvDB xref = null;
				List<CrossRef_AniDB_TvDB> recs = repCrossRef.GetByAnimeIDUser(animeid, uname);
				if (recs.Count == 1)
					xref = recs[0];

				if (recs.Count == 0)
					xref = new CrossRef_AniDB_TvDB();
				else
					xref = recs[0];

				xref.AnimeID = animeid;
				xref.AdminApproved = 0;
				xref.CrossRefSource = 1;
				xref.TvDBID = tvDBID;
				xref.TvDBSeasonNumber = tvDBSeason;
				xref.Username = uname;
				xref.SeriesName = sname;
				repCrossRef.Save(xref);

				// now send to mirror
				string uri = string.Format("http://{0}/AddCrossRef_AniDB_TvDB.aspx", Constants.MirrorWAIX);
				XMLService.SendData(uri, xmlData);

			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}