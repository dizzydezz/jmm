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
namespace OMMWebCache
{
	public partial class AddCrossRef_AniDB_Trakt : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				CrossRef_AniDB_TraktRepository repCrossRef = new CrossRef_AniDB_TraktRepository();

				StreamReader reader = new StreamReader(this.Request.InputStream);
				String xmlData = reader.ReadToEnd();

				XmlDocument docXRef = new XmlDocument();
				docXRef.LoadXml(xmlData);

				string uname = Utils.TryGetProperty("AddCrossRef_AniDB_Trakt_Request", docXRef, "Username");
				string sname = Utils.TryGetProperty("AddCrossRef_AniDB_Trakt_Request", docXRef, "ShowName");

				string aid = Utils.TryGetProperty("AddCrossRef_AniDB_Trakt_Request", docXRef, "AnimeID");
				int animeid = 0;
				int.TryParse(aid, out animeid);

				string traktid = Utils.TryGetProperty("AddCrossRef_AniDB_Trakt_Request", docXRef, "TraktID");

				string traktseason = Utils.TryGetProperty("AddCrossRef_AniDB_Trakt_Request", docXRef, "Season");
				int traktSeason = 0;
				if (!int.TryParse(traktseason, out traktSeason))
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}


				if (string.IsNullOrEmpty(uname) || animeid <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				CrossRef_AniDB_Trakt xref = null;
				List<CrossRef_AniDB_Trakt> recs = repCrossRef.GetByAnimeIDUser(animeid, uname);
				if (recs.Count == 1)
					xref = recs[0];

				if (recs.Count == 0)
					xref = new CrossRef_AniDB_Trakt();
				else
					xref = recs[0];

				xref.AnimeID = animeid;
				xref.AdminApproved = 0;
				xref.TraktID = traktid;
				xref.TraktSeasonNumber = traktSeason;
				xref.Username = uname;
				xref.ShowName = sname;
				repCrossRef.Save(xref);

			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}