using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMMWebCache.Contracts
{
	[Serializable]
	public class UpdatesCollection : XMLBase
	{
		protected string animeIDs = "";

		public string AnimeIDs
		{
			get { return animeIDs; }
			set { animeIDs = value; }
		}

		protected long updateCount = 0;
		public long UpdateCount
		{
			get { return updateCount; }
			set { updateCount = value; }
		}


		// default constructor
		public UpdatesCollection()
		{
		}

		public void AddToCollection(int aid)
		{
			updateCount++;
			if (animeIDs.Length > 0)
			{
				animeIDs += "|";
			}

			animeIDs += aid.ToString();

		}
	}
}