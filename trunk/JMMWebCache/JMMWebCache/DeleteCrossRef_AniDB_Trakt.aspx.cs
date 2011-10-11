using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMMWebCache.Repositories;
using OMMWebCache.Entities;
using OMMWebCache.Contracts;
using System.Xml;
using System.IO;

namespace OMMWebCache
{
	public partial class DeleteCrossRef_AniDB_Trakt : System.Web.UI.Page
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

				string uname = Utils.TryGetProperty("DeleteCrossRef_AniDB_TraktRequest", docXRef, "Username");

				string aid = Utils.TryGetProperty("DeleteCrossRef_AniDB_TraktRequest", docXRef, "AnimeID");
				int animeid = 0;
				int.TryParse(aid, out animeid);

				if (string.IsNullOrEmpty(uname) || animeid <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				List<CrossRef_AniDB_Trakt> recs = repCrossRef.GetByAnimeIDUser(animeid, uname);
				foreach (CrossRef_AniDB_Trakt xref in recs)
				{
					repCrossRef.Delete(xref.CrossRef_AniDB_TraktID);
				}

			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}