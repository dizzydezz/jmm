using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMMWebCache.Entities;
using OMMWebCache.Repositories;
using OMMWebCache.Contracts;
using OMMWebCache;
using JMMWebCache.Repositories;
using JMMWebCache.Entities;
using JMMWebCache.Contracts;

namespace JMMWebCache
{
	public partial class GetAniDB_File : System.Web.UI.Page
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

				string hash = Utils.GetParam("hash");
				if (hash.Trim().Length == 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				AniDB_FileRepository rep = new AniDB_FileRepository();

				AniDB_File anifile = rep.GetByHashAndFileSize(hash, fsize);
				if (anifile == null)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				AniDB_FileRequest data = new AniDB_FileRequest(anifile);
				string ret = Utils.ConvertToXML(data, typeof(AniDB_FileRequest));

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