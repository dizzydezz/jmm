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
	public partial class DeleteCrossRef_File_Episode : System.Web.UI.Page
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

				string hash = Utils.TryGetProperty("DeleteCrossRef_File_EpisodeRequest", docXRef, "Hash").Trim().ToUpper();
				string uname = Utils.TryGetProperty("DeleteCrossRef_File_EpisodeRequest", docXRef, "Uname");

				// anonymous uers will not get this benefit
				if (uname.ToLower() == Utils.AnonWebCacheUsername.ToLower()) return;

				string eid = Utils.TryGetProperty("DeleteCrossRef_File_EpisodeRequest", docXRef, "EpisodeID");
				int episodeID = 0;
				int.TryParse(eid, out episodeID);

				CrossRef_File_Episode_Rep repCrossRef = new CrossRef_File_Episode_Rep();
				List<CrossRef_File_Episode> recs = repCrossRef.GetByHashAndUsername(hash, uname);
				foreach (CrossRef_File_Episode xref in recs)
				{
					if (xref.EpisodeID == episodeID)
					{
						repCrossRef.Delete(xref.CrossRef_File_EpisodeID);
					}
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