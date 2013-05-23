using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Contracts;

namespace JMMWebCache.Contracts
{
	[Serializable]
	public class AppVersionsResult : XMLBase
	{
		public string JMMServerVersion { get; set; }
		public string JMMServerDownload { get; set; }

		public string JMMDesktopVersion { get; set; }
		public string JMMDesktopDownload { get; set; }

		public string MyAnime3Version { get; set; }
		public string MyAnime3Download { get; set; }

		// default constructor
		public AppVersionsResult()
		{
			JMMServerVersion = "3.0.39";
			JMMDesktopVersion = "3.0.39";
			MyAnime3Version = "3.0.39";

			JMMServerDownload = @"http://code.google.com/p/jmm/downloads/list";
			JMMDesktopDownload = @"http://code.google.com/p/jmm/downloads/list";
			MyAnime3Download = @"http://code.google.com/p/jmm/downloads/list";
		}
	}
}