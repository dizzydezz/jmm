using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JMMWebCache.Repositories;
using System.IO;
using System.Xml;
using OMMWebCache;
using JMMWebCache.Entities;

namespace JMMWebCache
{
	public partial class AddCrossRef_AniDB_MAL : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				CrossRef_AniDB_MALRepository repCrossRef = new CrossRef_AniDB_MALRepository();

				StreamReader reader = new StreamReader(this.Request.InputStream);
				String xmlData = reader.ReadToEnd();

				XmlDocument docXRef = new XmlDocument();
				docXRef.LoadXml(xmlData);

				string uname = Utils.TryGetProperty("AddCrossRef_AniDB_MAL_Request", docXRef, "Username");
				string malTitle = Utils.TryGetProperty("AddCrossRef_AniDB_MAL_Request", docXRef, "MALTitle");

				string aid = Utils.TryGetProperty("AddCrossRef_AniDB_MAL_Request", docXRef, "AnimeID");
				int animeid = 0;
				int.TryParse(aid, out animeid);

				string mID = Utils.TryGetProperty("AddCrossRef_AniDB_MAL_Request", docXRef, "MALID");
				int malID = 0;
				int.TryParse(mID, out malID);


				if (string.IsNullOrEmpty(uname) || animeid <= 0 || malID <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				CrossRef_AniDB_MAL xref = null;
				List<CrossRef_AniDB_MAL> recs = repCrossRef.GetByAnimeIDUser(animeid, uname);
				if (recs.Count == 1)
					xref = recs[0];

				if (recs.Count == 0)
					xref = new CrossRef_AniDB_MAL();
				else
					xref = recs[0];

				xref.AnimeID = animeid;
				xref.CrossRefSource = 1;
				xref.MALID = malID;
				xref.MALTitle = malTitle;
				xref.Username = uname;
				repCrossRef.Save(xref);

			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}