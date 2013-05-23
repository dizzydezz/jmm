using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMMWebCache.Entities;
using OMMWebCache.Repositories;
using OMMWebCache.Contracts;

namespace OMMWebCache
{
	public partial class GetFileNameHash : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				Response.Write(Constants.ERROR_XML);
				return;

				string sfsize = Utils.GetParam("fsize");
				long fsize = 0;
				long.TryParse(sfsize, out fsize);

				if (fsize <= 0) 
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				string fname = Utils.GetParam("fname");
				if (fname.Trim().Length == 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				string uname = Utils.GetParam("uname");
				if (uname.Trim().Length == 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				FileNameHash_Rep repHash = new FileNameHash_Rep();

				// check for user specific
				FileNameHash fnh = null;
				List<FileNameHash> recs = repHash.SearchForUser(uname, fsize, fname);
				if (recs.Count == 0)
				{
					// check for other users
					recs = repHash.SearchForAll(fsize, fname);
					if (recs.Count > 0)
						fnh = recs[0];
				}
				else
					fnh = recs[0];



				if (fnh == null)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				FileHashResult data = new FileHashResult(fnh.Hash);
				string ret = Utils.ConvertToXML(data, typeof(FileHashResult));

				Response.Write(ret);
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
				return;
			}
		}
	}
}