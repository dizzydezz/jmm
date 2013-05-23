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
	public partial class AddUpdatedList : System.Web.UI.Page
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

				string aidList = Utils.TryGetProperty("AniDB_Updated", docXRef, "AnimeIDList").Trim().ToUpper();
				string uname = Utils.TryGetProperty("AniDB_Updated", docXRef, "Username");

				string utime = Utils.TryGetProperty("AniDB_Updated", docXRef, "UpdatedTime");
				long updateTime = 0;
				long.TryParse(utime, out updateTime);

				if (string.IsNullOrEmpty(aidList) || string.IsNullOrEmpty(uname) || updateTime <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				AniDB_UpdatedRepository repUpdates = new AniDB_UpdatedRepository();
				AniDB_Updated aniUpdated = new AniDB_Updated();
				aniUpdated.AnimeIDList = aidList;
				aniUpdated.Username = uname;
				aniUpdated.UpdateTime = updateTime;
				aniUpdated.DateTimeCreated = DateTime.Now;
				repUpdates.Save(aniUpdated);

				// now send to mirror
				string uri = string.Format("http://{0}/AddUpdatedList.aspx", Constants.MirrorWAIX);
				XMLService.SendData(uri, xmlData);

			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}