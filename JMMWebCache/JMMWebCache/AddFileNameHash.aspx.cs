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
	public partial class AddFileNameHash : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				FileNameHash_Rep repHash = new FileNameHash_Rep();

				StreamReader reader = new StreamReader(this.Request.InputStream);
				String xmlData = reader.ReadToEnd();

				XmlDocument docFile = new XmlDocument();
				docFile.LoadXml(xmlData);

				string hash = Utils.TryGetProperty("FileHashRequest", docFile, "Hash").Trim().ToUpper();
				string fname = Utils.TryGetProperty("FileHashRequest", docFile, "Fname");
				string uname = Utils.TryGetProperty("FileHashRequest", docFile, "Uname");
				string sfsize = Utils.TryGetProperty("FileHashRequest", docFile, "Fsize");
				long fsize = 0;
				long.TryParse(sfsize, out fsize);

				if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(uname) || fsize <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				FileNameHash fnh = null;
				List<FileNameHash> recs = repHash.SearchForUser(uname, fsize, fname);
				if (recs.Count == 1)
					fnh = recs[0];

				if (recs.Count == 0)
					fnh = new FileNameHash();

				if (recs.Count > 1)
				{
					foreach (FileNameHash rec in recs)
					{
						repHash.Delete(rec.FileNameHashID);
					}
					fnh = new FileNameHash();
				}
				
				fnh.DateTimeUpdated = DateTime.Now;
				fnh.FileName = fname;
				fnh.FileSize = fsize;
				fnh.Hash = hash;
				fnh.Username = uname;
				repHash.Save(fnh);

			}
			catch (Exception ex)
			{
				Response.Write(Constants.ERROR_XML);
			}
		}
	}
}