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
	public partial class DeleteCrossRef_AniDB_MAL : System.Web.UI.Page
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

				string uname = Utils.TryGetProperty("DeleteCrossRef_AniDB_MALRequest", docXRef, "Username");

				string aid = Utils.TryGetProperty("DeleteCrossRef_AniDB_MALRequest", docXRef, "AnimeID");
				int animeid = 0;
				int.TryParse(aid, out animeid);

				string sepType = Utils.TryGetProperty("DeleteCrossRef_AniDB_MALRequest", docXRef, "StartEpisodeType");
				int epType = 0;
				int.TryParse(sepType, out epType);

				string sepNumber = Utils.TryGetProperty("DeleteCrossRef_AniDB_MALRequest", docXRef, "StartEpisodeNumber");
				int epNumber = 0;
				int.TryParse(sepNumber, out epNumber);

				if (string.IsNullOrEmpty(uname) || animeid <= 0 || epType <= 0 || epNumber <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				List<CrossRef_AniDB_MAL> recs = repCrossRef.GetByAnimeIDUser(animeid, uname, epType, epNumber);
				foreach (CrossRef_AniDB_MAL xref in recs)
				{
					repCrossRef.Delete(xref.CrossRef_AniDB_MALID);
				}

				// now send to mirror
				string uri = string.Format("http://{0}/DeleteCrossRef_AniDB_MAL.aspx", Constants.MirrorWAIX);
				XMLService.SendData(uri, xmlData);

			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}