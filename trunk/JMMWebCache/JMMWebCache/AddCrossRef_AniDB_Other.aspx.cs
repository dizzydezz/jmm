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
	public partial class AddCrossRef_AniDB_Other : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				CrossRef_AniDB_OtherRepository repCrossRef = new CrossRef_AniDB_OtherRepository();

				StreamReader reader = new StreamReader(this.Request.InputStream);
				String xmlData = reader.ReadToEnd();

				XmlDocument docXRef = new XmlDocument();
				docXRef.LoadXml(xmlData);

				string uname = Utils.TryGetProperty("AddCrossRef_AniDB_Other_Request", docXRef, "Username");

				string aid = Utils.TryGetProperty("AddCrossRef_AniDB_Other_Request", docXRef, "AnimeID");
				int animeid = 0;
				int.TryParse(aid, out animeid);

				string xrefID = Utils.TryGetProperty("AddCrossRef_AniDB_Other_Request", docXRef, "CrossRefID");

				string xtype = Utils.TryGetProperty("AddCrossRef_AniDB_Other_Request", docXRef, "CrossRefType");
				int xrefType = 0;
				int.TryParse(xtype, out xrefType);




				if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(xrefID) || animeid <= 0 || xrefType <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				CrossRef_AniDB_Other xref = null;
				List<CrossRef_AniDB_Other> recs = repCrossRef.GetByAnimeIDAndTypeAndUser(animeid, uname, (CrossRefType)xrefType);
				if (recs.Count == 1)
					xref = recs[0];

				if (recs.Count == 0)
					xref = new CrossRef_AniDB_Other();
				else
					xref = recs[0];

				xref.AnimeID = animeid;
				xref.AdminApproved = 0;
				xref.CrossRefSource = 1;
				xref.CrossRefType = xrefType;
				xref.CrossRefID = xrefID;
				xref.Username = uname;
				repCrossRef.Save(xref);

				// now send to mirror
				string uri = string.Format("http://{0}/AddCrossRef_AniDB_Other.aspx", Constants.MirrorWAIX);
				XMLService.SendData(uri, xmlData);

			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}