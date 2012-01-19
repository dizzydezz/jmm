using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMMWebCache.Repositories;
using System.IO;
using JMMWebCache.Repositories;
using System.Xml;
using OMMWebCache;
using System.Xml.Serialization;
using JMMWebCache.Contracts;
using JMMWebCache.Entities;

namespace JMMWebCache
{
	public partial class AddAniDB_File : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				AniDB_FileRepository rep = new AniDB_FileRepository();

				StreamReader reader = new StreamReader(this.Request.InputStream);
				String xmlData = reader.ReadToEnd();

				XmlSerializer serializer = new XmlSerializer(typeof(AniDB_FileRequest));
				XmlDocument docSearchResult = new XmlDocument();
				docSearchResult.LoadXml(xmlData);

				XmlNodeReader xmlreader = new XmlNodeReader(docSearchResult.DocumentElement);
				object obj = serializer.Deserialize(xmlreader);
				AniDB_FileRequest result = (AniDB_FileRequest)obj;


				if (result == null)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}


				AniDB_File anifile = rep.GetByFileID(result.FileID);
				if (anifile == null)
					anifile = new AniDB_File();

				anifile.Populate(result);
				rep.Save(anifile);
			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}