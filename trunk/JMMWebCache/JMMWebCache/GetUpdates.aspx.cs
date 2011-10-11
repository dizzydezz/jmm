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
	public partial class GetUpdates : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.ContentType = "text/xml";

			try
			{
				AniDB_UpdatedRepository repUpdates = new AniDB_UpdatedRepository();

				string updatetime = Utils.GetParam("updatetime");
				long fupdatetime = 0;
				long.TryParse(updatetime, out fupdatetime);

				if (fupdatetime <= 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				// get all the records
				// we need to find all the records greater than the update time, and one record
				// which is just before the update time
				// this will ensure we get all records
				List<AniDB_Updated> allUpdateRecords = repUpdates.GetAll();
				if (allUpdateRecords.Count == 0)
				{
					Response.Write(Constants.ERROR_XML);
					return;
				}

				List<string> allUpdates = new List<string>();

				int idxSmallest = -1;
				// find the first record greater
				for (int i = 0; i < allUpdateRecords.Count; i++)
				{
					if (allUpdateRecords[i].UpdateTime > fupdatetime)
					{
						if (idxSmallest < 0)
						{
							idxSmallest = i;
							if (i > 0)
							{
								string[] ids = allUpdateRecords[i - 1].AnimeIDList.Split(',');
								foreach (string id in ids)
								{
									if (!allUpdates.Contains(id.Trim())) allUpdates.Add(id.Trim());
								}
							}
						}

						// get a list of anime id's
						string[] ids2 = allUpdateRecords[i].AnimeIDList.Split(',');
						foreach (string id in ids2)
						{
							if (!allUpdates.Contains(id.Trim())) allUpdates.Add(id.Trim());
						}
					}
				}

				UpdatesCollection colUpdates = new UpdatesCollection();
				foreach (string id in allUpdates)
				{
					colUpdates.AddToCollection(int.Parse(id));
				}

				string ret = Utils.ConvertToXML(colUpdates, typeof(UpdatesCollection));
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