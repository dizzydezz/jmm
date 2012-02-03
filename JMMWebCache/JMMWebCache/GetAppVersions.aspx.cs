using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMMWebCache;
using JMMWebCache.Contracts;

namespace JMMWebCache
{
	public partial class GetAppVersions : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				AppVersionsResult appv = new AppVersionsResult();

				string ret = Utils.ConvertToXML(appv, typeof(AppVersionsResult));
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