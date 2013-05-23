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
using JMMWebCache;

namespace OMMWebCache
{
	public partial class DeleteCrossRef_AniDBTvDBAll : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				StreamReader reader = new StreamReader(this.Request.InputStream);
				String xmlData = reader.ReadToEnd();

				XmlDocument docXRef = new XmlDocument();
				docXRef.LoadXml(xmlData);

				string sid = Utils.TryGetProperty("DeleteCrossRef_AniDBTvDBAll_Request", docXRef, "SeriesID");
				int seriesID = 0;
				int.TryParse(sid, out seriesID);

				CrossRef_AniDB_TvDBRepository repCrossRef = new CrossRef_AniDB_TvDBRepository();
				List<CrossRef_AniDB_TvDB> recs = repCrossRef.GetByTvDBID(seriesID);
				foreach (CrossRef_AniDB_TvDB xref in recs)
				{
					repCrossRef.Delete(xref.CrossRef_AniDB_TvDBID);
				}

				// now send to mirror
				string uri = string.Format("http://{0}/DeleteCrossRef_AniDBTvDBAll.aspx", Constants.MirrorWAIX);
				XMLService.SendData(uri, xmlData);
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
				return;
			}
		}
	}
}