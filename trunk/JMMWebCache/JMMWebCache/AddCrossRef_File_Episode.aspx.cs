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
	public partial class AddCrossRef_File_Episode : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				Response.Write(Constants.ERROR_XML);
				return;

				CrossRef_File_Episode_Rep repCrossRef = new CrossRef_File_Episode_Rep();

				StreamReader reader = new StreamReader(this.Request.InputStream);
				String xmlData = reader.ReadToEnd();

				XmlDocument docXRef = new XmlDocument();
				docXRef.LoadXml(xmlData);

				string hash = Utils.TryGetProperty("CrossRef_File_EpisodeRequest", docXRef, "Hash").Trim().ToUpper();
				string uname = Utils.TryGetProperty("CrossRef_File_EpisodeRequest", docXRef, "Uname");

				string aid = Utils.TryGetProperty("CrossRef_File_EpisodeRequest", docXRef, "AnimeID");
				int animeid = 0;
				int.TryParse(aid, out animeid);

				string eid = Utils.TryGetProperty("CrossRef_File_EpisodeRequest", docXRef, "EpisodeID");
				int episodeID = 0;
				int.TryParse(eid, out episodeID);

				string pct = Utils.TryGetProperty("CrossRef_File_EpisodeRequest", docXRef, "Percentage");
				int percentage = 0;
				int.TryParse(pct, out percentage);

				string eo = Utils.TryGetProperty("CrossRef_File_EpisodeRequest", docXRef, "EpisodeOrder");
				int eporder = 0;
				int.TryParse(eo, out eporder);

				if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(uname) || animeid <= 0 || episodeID <= 0 || percentage <= 0 || eporder <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				CrossRef_File_Episode xref = null;
				List<CrossRef_File_Episode> recs = repCrossRef.GetByHashUsernameAndEpisodeID(hash, uname, episodeID);
				if (recs.Count == 1)
					xref = recs[0];

				if (recs.Count == 0)
					xref = new CrossRef_File_Episode();

				if (recs.Count > 1)
				{
					foreach (CrossRef_File_Episode rec in recs)
					{
						repCrossRef.Delete(rec.CrossRef_File_EpisodeID);
					}
					xref = new CrossRef_File_Episode();
				}

				xref.DateTimeUpdated = DateTime.Now;
				xref.AnimeID = animeid;
				xref.EpisodeID = episodeID;
				xref.EpisodeOrder = eporder;
				xref.Percentage = percentage;
				xref.Hash = hash;
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