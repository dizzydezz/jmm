﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading;
using System.IO;
using NLog;
using System.Diagnostics;

namespace JMMClient
{
	public class AppSettings
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static void CreateDefaultConfig()
		{
			System.Reflection.Assembly assm = System.Reflection.Assembly.GetExecutingAssembly();
			// check if the app config file exists

			string appConfigPath = assm.Location + ".config";
			string defaultConfigPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(assm.Location), "default.config");
			if (!File.Exists(appConfigPath) && File.Exists(defaultConfigPath))
			{
				File.Copy(defaultConfigPath, appConfigPath);
			}
		}

		public static string Culture
		{
			get
			{
				string osCulture = Thread.CurrentThread.CurrentUICulture.ToString();

				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string cult = appSettings["Culture"];
				if (!string.IsNullOrEmpty(cult))
					return cult;
				else
				{
					return UserCulture.GetClosestMatch(osCulture); // default
				}
			}
			set
			{
				UpdateSetting("Culture", value);
			}
		}


		public static AvailableEpisodeType Episodes_Availability
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				int val = 1;
				if (int.TryParse(appSettings["Episodes_Availability"], out val))
					return (AvailableEpisodeType)val;
				else
					return AvailableEpisodeType.All; // default value
			}
			set
			{
				UpdateSetting("Episodes_Availability", ((int)value).ToString());
			}
		}

		public static WatchedStatus Episodes_WatchedStatus
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				int val = 1;
				if (int.TryParse(appSettings["Episodes_WatchedStatus"], out val))
					return (WatchedStatus)val;
				else
					return WatchedStatus.All; // default value
			}
			set
			{
				UpdateSetting("Episodes_WatchedStatus", ((int)value).ToString());
			}
		}

		public static string BaseImagesPath
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				return appSettings["BaseImagesPath"];
			}
			set
			{
				UpdateSetting("BaseImagesPath", value);
				JMMServerVM.Instance.BaseImagePath = Utils.GetBaseImagesPath();
			}
		}

		public static bool BaseImagesPathIsDefault
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string basePath = appSettings["BaseImagesPathIsDefault"];
				if (!string.IsNullOrEmpty(basePath))
				{
					bool val = true;
					bool.TryParse(basePath, out val);
					return val;
				}
				else return true;

			}
			set
			{
				UpdateSetting("BaseImagesPathIsDefault", value.ToString());
				JMMServerVM.Instance.BaseImagePath = Utils.GetBaseImagesPath();
			}
		}

		public static string JMMServer_Address
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["JMMServer_Address"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "127.0.0.1";
					UpdateSetting("JMMServer_Address", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("JMMServer_Address", value);
			}
		}

		public static string JMMServer_Port
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["JMMServer_Port"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "8111";
					UpdateSetting("JMMServer_Port", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("JMMServer_Port", value);
			}
		}

		public static string JMMServer_FilePort
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["JMMServer_FilePort"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "8112";
					UpdateSetting("JMMServer_FilePort", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("JMMServer_FilePort", value);
			}
		}

		public static int DisplayHeight_GroupList
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DisplayHeight_GroupList"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival > 30 && ival < 300)
						return ival;
					else
						return 80;
				}
				else
					return 80; // default value
			}
			set
			{
				UpdateSetting("DisplayHeight_GroupList", value.ToString());
			}
		}

		public static int PlaylistHeader_Image_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["PlaylistHeader_Image_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival > 30 && ival < 400)
						return ival;
					else
						return 200;
				}
				else
					return 200; // default value
			}
			set
			{
				UpdateSetting("PlaylistHeader_Image_Height", value.ToString());
			}
		}

		public static int PlaylistItems_Image_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["PlaylistItems_Image_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival > 30 && ival < 400)
						return ival;
					else
						return 130;
				}
				else
					return 130; // default value
			}
			set
			{
				UpdateSetting("PlaylistItems_Image_Height", value.ToString());
			}
		}

		public static int PlaylistEpisode_Image_Width
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["PlaylistEpisode_Image_Width"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival > 10 && ival < 400)
						return ival;
					else
						return 120;
				}
				else
					return 120; // default value
			}
			set
			{
				UpdateSetting("PlaylistEpisode_Image_Width", value.ToString());
			}
		}

		public static bool PlaylistItems_ShowDetails
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["PlaylistItems_ShowDetails"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("PlaylistItems_ShowDetails", value.ToString());
			}
		}

		public static int DisplayHeight_SeriesInfo
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DisplayHeight_SeriesInfo"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival > 30 && ival < 300)
						return ival;
					else
						return 200;
				}
				else
					return 200; // default value
			}
			set
			{
				UpdateSetting("DisplayHeight_SeriesInfo", value.ToString());
			}
		}

		public static int DisplayWidth_EpisodeImage
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DisplayWidth_EpisodeImage"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival > 10 && ival < 400)
						return ival;
					else
						return 120;
				}
				else
					return 120; // default value
			}
			set
			{
				UpdateSetting("DisplayWidth_EpisodeImage", value.ToString());
			}
		}

		public static int DisplayStyle_GroupList
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DisplayStyle_GroupList"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 1 && ival <= 2)
						return ival;
					else
						return 1;
				}
				else
					return 1; // default value
			}
			set
			{
				UpdateSetting("DisplayStyle_GroupList", value.ToString());
			}
		}

		public static int DisplayHeight_DashImage
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DisplayHeight_DashImage"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("DisplayHeight_DashImage", value.ToString());
			}
		}

		public static int EpisodeImageOverviewStyle
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["EpisodeImageOverviewStyle"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 1 && ival <= 3)
						return ival;
					else
						return 1;
				}
				else
					return 1; // default value
			}
			set
			{
				UpdateSetting("EpisodeImageOverviewStyle", value.ToString());
			}
		}

		public static bool HideEpisodeImageWhenUnwatched
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["HideEpisodeImageWhenUnwatched"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("HideEpisodeImageWhenUnwatched", value.ToString());
			}
		}

		public static bool HideEpisodeOverviewWhenUnwatched
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["HideEpisodeOverviewWhenUnwatched"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("HideEpisodeOverviewWhenUnwatched", value.ToString());
			}
		}

		public static bool HideDownloadButtonWhenFilesExist
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["HideDownloadButtonWhenFilesExist"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("HideDownloadButtonWhenFilesExist", value.ToString());
			}
		}

		public static bool DisplayRatingDialogOnCompletion
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DisplayRatingDialogOnCompletion"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("DisplayRatingDialogOnCompletion", value.ToString());
			}
		}

		public static bool UseFanartOnSeries
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["UseFanartOnSeries"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("UseFanartOnSeries", value.ToString());
			}
		}

		public static bool UseFanartOnPlaylistHeader
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["UseFanartOnPlaylistHeader"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("UseFanartOnPlaylistHeader", value.ToString());
			}
		}

		public static bool UseFanartOnPlaylistItems
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["UseFanartOnPlaylistItems"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("UseFanartOnPlaylistItems", value.ToString());
			}
		}

		public static string SeriesWidgetsOrder
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["SeriesWidgetsOrder"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "5;2;1;6;4;3;7";
					UpdateSetting("SeriesWidgetsOrder", val);
				}

				// make sure the setting contains all the widgets
				// just in case the user has manually edited the config, or is using an old config
				string[] widgets = val.Split(';');
				int maxEnum = 7;
				for (int i = 1; i <= maxEnum; i++)
				{
					if (!widgets.Contains(i.ToString()))
					{
						if (val.Length > 0) val += ";";
						val += i.ToString();
					}
				}

				return val;
			}
			set
			{
				UpdateSetting("SeriesWidgetsOrder", value);
			}
		}

		public static string DashboardWidgetsOrder
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashboardWidgetsOrder"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "1;2;3;4;5;6;7;8";
					UpdateSetting("DashboardWidgetsOrder", val);
				}

				// make sure the setting contains all the widgets
				// just in case the user has manually edited the config, or is using an old config
				string[] widgets = val.Split(';');
				int maxEnum = 8;
				for (int i = 1; i <= maxEnum; i++)
				{
					if (!widgets.Contains(i.ToString()))
					{
						if (val.Length > 0) val += ";";
						val += i.ToString();
					}
				}

				return val;
			}
			set
			{
				UpdateSetting("DashboardWidgetsOrder", value);
			}
		}

		public static string MissingEpsExportColumns
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["MissingEpsExportColumns"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "1;1;1;1;1;1;1;1";
					UpdateSetting("MissingEpsExportColumns", val);
				}

				// make sure the setting contains all the columns
				// just in case the user has manually edited the config, or is using an old config
				string[] columns = val.Split(';');
				if (columns.Length != 8)
				{
					val = "1;1;1;1;1;1;1;1";
					UpdateSetting("MissingEpsExportColumns", val);
				}

				return val;
			}
			set
			{
				UpdateSetting("MissingEpsExportColumns", value);
			}
		}

		public static bool SeriesTvDBLinksExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["SeriesTvDBLinksExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("SeriesTvDBLinksExpanded", value.ToString());
			}
		}


		public static bool TitlesExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["TitlesExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("TitlesExpanded", value.ToString());
			}
		}

		public static bool TagsExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["TagsExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("TagsExpanded", value.ToString());
			}
		}

		public static bool WindowFullScreen
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["WindowFullScreen"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("WindowFullScreen", value.ToString());
			}
		}

		public static bool WindowNormal
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["WindowNormal"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("WindowNormal", value.ToString());
			}
		}

		public static bool SeriesNextEpisodeExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["SeriesNextEpisodeExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("SeriesNextEpisodeExpanded", value.ToString());
			}
		}

		public static bool SeriesFileSummaryExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["SeriesFileSummaryExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("SeriesFileSummaryExpanded", value.ToString());
			}
		}

		public static bool SeriesGroupExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["SeriesGroupExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("SeriesGroupExpanded", value.ToString());
			}
		}

		public static bool CategoriesExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["CategoriesExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("CategoriesExpanded", value.ToString());
			}
		}

		public static bool DashWatchNextEpExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashWatchNextEpExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("DashWatchNextEpExpanded", value.ToString());
			}
		}

		public static bool DashRecentlyWatchEpsExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashRecentlyWatchEpsExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("DashRecentlyWatchEpsExpanded", value.ToString());
			}
		}

		public static bool DashSeriesMissingEpisodesExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashSeriesMissingEpisodesExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("DashSeriesMissingEpisodesExpanded", value.ToString());
			}
		}

		public static bool DashMiniCalendarExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashMiniCalendarExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("DashMiniCalendarExpanded", value.ToString());
			}
		}

		public static bool DashRecommendationsWatchExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashRecommendationsWatchExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("DashRecommendationsWatchExpanded", value.ToString());
			}
		}

		public static bool DashRecommendationsDownloadExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashRecommendationsDownloadExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("DashRecommendationsDownloadExpanded", value.ToString());
			}
		}

		public static bool DashRecentAdditionsExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashRecentAdditionsExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("DashRecentAdditionsExpanded", value.ToString());
			}
		}

		public static int DashRecentAdditionsType
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashRecentAdditionsType"];
				int bval = 0;
				if (int.TryParse(val, out bval))
					return bval;
				else
					return 0; // default value
			}
			set
			{
				UpdateSetting("DashRecentAdditionsType", value.ToString());
			}
		}

		public static bool DashTraktFriendsExpanded
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashTraktFriendsExpanded"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("DashTraktFriendsExpanded", value.ToString());
			}
		}

		public static int Dash_WatchNext_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_WatchNext_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("Dash_WatchNext_Items", value.ToString());
			}
		}

		public static int Dash_RecentAdditions_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_RecentAdditions_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("Dash_RecentAdditions_Items", value.ToString());
			}
		}

		public static int Dash_WatchNext_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_WatchNext_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("Dash_WatchNext_Height", value.ToString());
			}
		}

		public static int Dash_RecentAdditions_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_RecentAdditions_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("Dash_RecentAdditions_Height", value.ToString());
			}
		}

		public static DashWatchNextStyle Dash_WatchNext_Style
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				int val = 1;
				if (int.TryParse(appSettings["Dash_WatchNext_Style"], out val))
					return (DashWatchNextStyle)val;
				else
					return DashWatchNextStyle.Detailed; // default value
			}
			set
			{
				UpdateSetting("Dash_WatchNext_Style", ((int)value).ToString());
			}
		}



		



		public static int Dash_RecentlyWatchedEp_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_RecentlyWatchedEp_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("Dash_RecentlyWatchedEp_Items", value.ToString());
			}
		}

		public static int Dash_RecentlyWatchedEp_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_RecentlyWatchedEp_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("Dash_RecentlyWatchedEp_Height", value.ToString());
			}
		}


		public static int Dash_MissingEps_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_MissingEps_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("Dash_MissingEps_Items", value.ToString());
			}
		}

		public static int Dash_MissingEps_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_MissingEps_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("Dash_MissingEps_Height", value.ToString());
			}
		}

		public static int Dash_MiniCalendarDays
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_MiniCalendarDays"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("Dash_MiniCalendarDays", value.ToString());
			}
		}

		public static int Dash_MiniCalendar_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_MiniCalendar_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("Dash_MiniCalendar_Height", value.ToString());
			}
		}

		public static int Dash_RecWatch_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_RecWatch_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("Dash_RecWatch_Height", value.ToString());
			}
		}

		public static int Dash_RecWatch_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_RecWatch_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("Dash_RecWatch_Items", value.ToString());
			}
		}

		public static int Dash_RecDownload_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_RecDownload_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("Dash_RecDownload_Height", value.ToString());
			}
		}

		public static int Dash_RecDownload_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_RecDownload_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("Dash_RecDownload_Items", value.ToString());
			}
		}

		public static int Dash_TraktFriends_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_TraktFriends_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("Dash_TraktFriends_Height", value.ToString());
			}
		}

		public static int Dash_TraktFriends_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_TraktFriends_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("Dash_TraktFriends_Items", value.ToString());
			}
		}

		public static bool Dash_TraktFriends_AnimeOnly
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["Dash_TraktFriends_AnimeOnly"];
				bool bval = false;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("Dash_TraktFriends_AnimeOnly", value.ToString());
			}
		}

		public static int SeriesGroup_Image_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["SeriesGroup_Image_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 80)
						return 80;

					if (ival > 400)
						return 400;

					return ival;
				}
				else
				{
					return 150; // default value
				}
			}
			set
			{
				UpdateSetting("SeriesGroup_Image_Height", value.ToString());
			}
		}

		public static System.Windows.WindowState DefaultWindowState
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DefaultWindowState"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 0)
						return System.Windows.WindowState.Normal;

					if (ival > 2)
						return System.Windows.WindowState.Normal;

					return (System.Windows.WindowState)ival;
				}
				else
				{
					return System.Windows.WindowState.Normal; // default value
				}
			}
			set
			{
				UpdateSetting("DefaultWindowState", ((int)value).ToString());
			}
		}

		public static Dictionary<int, string> ImportFolderMappings
		{
			get
			{
				Dictionary<int, string> mappings = new Dictionary<int, string>();
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string mpgs = appSettings["ImportFolderMappings"];

				if (string.IsNullOrEmpty(mpgs)) return mappings;

				string[] arrmpgs = mpgs.Split(';');
				foreach (string arrval in arrmpgs)
				{
					if (string.IsNullOrEmpty(arrval)) continue;

					string[] vals = arrval.Split('|');
					mappings[int.Parse(vals[0])] = vals[1];
				}

				return mappings;
			}
		}

		public static void SetImportFolderMapping(int folderID, string localPath)
		{
			NameValueCollection appSettings = ConfigurationManager.AppSettings;
			string mpgs = appSettings["ImportFolderMappings"];

			string output = "";

			// check if we already have this in the existing settings
			bool exists = ImportFolderMappings.ContainsKey(folderID);

			string[] arrmpgs = mpgs.Split(';');
			foreach (string arrval in arrmpgs)
			{
				if (string.IsNullOrEmpty(arrval)) continue;

				if (output.Length > 0) output += ";";

				string[] vals = arrval.Split('|');

				int thisFolderID = int.Parse(vals[0]);
				if (thisFolderID == folderID)
					output += string.Format("{0}|{1}", thisFolderID, localPath);
				else
					output += string.Format("{0}|{1}", thisFolderID, vals[1]);
			}

			// new entry
			if (!exists)
			{
				if (output.Length > 0) output += ";";
				output += string.Format("{0}|{1}", folderID, localPath);
			}

			UpdateSetting("ImportFolderMappings", output);
		}

		public static void RemoveImportFolderMapping(int folderID)
		{
			if (ImportFolderMappings.ContainsKey(folderID))
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string mpgs = appSettings["ImportFolderMappings"];

				string output = "";

				string[] arrmpgs = mpgs.Split(';');
				foreach (string arrval in arrmpgs)
				{
					if (string.IsNullOrEmpty(arrval)) continue;

					string[] vals = arrval.Split('|');

					int thisFolderID = int.Parse(vals[0]);
					if (thisFolderID != folderID)
					{
						if (output.Length > 0) output += ";";
						output += string.Format("{0}|{1}", thisFolderID, vals[1]);
					}
				}

				UpdateSetting("ImportFolderMappings", output);
			}
		}

		private static void SaveImportFolderMappings()
		{
			string output = "";
			foreach (KeyValuePair<int, string> kvp in ImportFolderMappings)
			{
				if (output.Length > 0) output += ";";
				output += string.Format("{0}|{1}", kvp.Key, kvp.Value);
			}
			UpdateSetting("ImportFolderMappings", output);
		}

		public static void UpdateSetting(string key, string value)
		{
			System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			if (config.AppSettings.Settings.AllKeys.Contains(key))
				config.AppSettings.Settings[key].Value = value;
			else
				config.AppSettings.Settings.Add(key, value);

			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
		}

		public static string UTorrentAddress
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["UTorrentAddress"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("UTorrentAddress", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("UTorrentAddress", value);
			}
		}

		public static string UTorrentPort
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["UTorrentPort"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("UTorrentPort", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("UTorrentPort", value);
			}
		}

		public static string UTorrentUsername
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["UTorrentUsername"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("UTorrentUsername", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("UTorrentUsername", value);
			}
		}

		public static string UTorrentPassword
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["UTorrentPassword"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("UTorrentPassword", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("UTorrentPassword", value);
			}
		}

		public static int UTorrentRefreshInterval
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["UTorrentRefreshInterval"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 1)
						return 5;

					if (ival > 999)
						return 5;

					return ival;
				}
				else
				{
					return 5; // default value
				}
			}
			set
			{
				UpdateSetting("UTorrentRefreshInterval", value.ToString());
			}
		}

		public static bool UTorrentAutoRefresh
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["UTorrentAutoRefresh"];
				bool bval = false;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("UTorrentAutoRefresh", value.ToString());
			}
		}

		public static bool TorrentSearchPreferOwnGroups
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["TorrentSearchPreferOwnGroups"];
				bool bval = false;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("TorrentSearchPreferOwnGroups", value.ToString());
			}
		}

		public static string TorrentSources
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["TorrentSources"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "1;4;5";
					UpdateSetting("TorrentSources", val);
				}

				// make sure the selected sources are valid
				// just in case the user has manually edited the config, or is using an old config
				string[] sources = val.Split(';');
				bool invalidSource = false;
				int maxEnum = 6;
				foreach (string src in sources)
				{
					int iSrc = 0;
					if (!int.TryParse(src, out iSrc))
					{
						invalidSource = true;
						break;
					}

					if (iSrc <= 0 || iSrc > maxEnum)
					{
						invalidSource = true;
						break;
					}
				}

				if (invalidSource)
				{
					// default value
					val = "1;4;5";
					UpdateSetting("TorrentSources", val);
				}
			

				return val;
			}
			set
			{
				UpdateSetting("TorrentSources", value);
			}
		}

		public static string BakaBTUsername
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["BakaBTUsername"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("BakaBTUsername", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("BakaBTUsername", value);
			}
		}

		public static string BakaBTPassword
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["BakaBTPassword"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("BakaBTPassword", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("BakaBTPassword", value);
			}
		}

		public static bool BakaBTOnlyUseForSeriesSearches
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["BakaBTOnlyUseForSeriesSearches"];
				bool bval = false;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("BakaBTOnlyUseForSeriesSearches", value.ToString());
			}
		}

		public static string AnimeBytesUsername
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["AnimeBytesUsername"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("AnimeBytesUsername", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("AnimeBytesUsername", value);
			}
		}

		public static string AnimeBytesPassword
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["AnimeBytesPassword"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("AnimeBytesPassword", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("AnimeBytesPassword", value);
			}
		}

		public static bool AnimeBytesOnlyUseForSeriesSearches
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["AnimeBytesOnlyUseForSeriesSearches"];
				bool bval = false;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return true; // default value
			}
			set
			{
				UpdateSetting("AnimeBytesOnlyUseForSeriesSearches", value.ToString());
			}
		}

		public static string MPCFolder
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["MPCFolder"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("MPCFolder", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("MPCFolder", value);
			}
		}

		public static string PotPlayerFolder
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["PotPlayerFolder"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("PotPlayerFolder", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("PotPlayerFolder", value);
			}
		}

		public static int VideoWatchedPct
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["VideoWatchedPct"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 1)
						return 85;

					if (ival > 100)
						return 85;

					return ival;
				}
				else
				{
					return 85; // default value
				}
			}
			set
			{
				UpdateSetting("VideoWatchedPct", value.ToString());
			}
		}

		public static bool VideoAutoSetWatched
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["VideoAutoSetWatched"];
				bool bval = false;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("VideoAutoSetWatched", value.ToString());
			}
		}

		public static bool MultipleFilesOnlyFinished
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["MultipleFilesOnlyFinished"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("MultipleFilesOnlyFinished", value.ToString());
			}
		}

		public static int FileSummaryTypeDefault
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["FileSummaryTypeDefault"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 0)
						return 0;

					if (ival > 1)
						return 0;

					return ival;
				}
				else
				{
					return 0; // default value
				}
			}
			set
			{
				UpdateSetting("FileSummaryTypeDefault", value.ToString());
			}
		}

		public static int FileSummaryQualSortDefault
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["FileSummaryQualSortDefault"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 0)
						return 0;

					if (ival > 1)
						return 0;

					return ival;
				}
				else
				{
					return 0; // default value
				}
			}
			set
			{
				UpdateSetting("FileSummaryQualSortDefault", value.ToString());
			}
		}

		public static int AutoFileFirst
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["AutoFileFirst"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 0)
						return 0;

					if (ival > 1)
						return 0;

					return ival;
				}
				else
				{
					return 0; // default value
				}
			}
			set
			{
				UpdateSetting("AutoFileFirst", value.ToString());
			}
		}

		public static int AutoFileSubsequent
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["AutoFileSubsequent"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 0)
						return 0;

					if (ival > 1)
						return 0;

					return ival;
				}
				else
				{
					return 0; // default value
				}
			}
			set
			{
				UpdateSetting("AutoFileSubsequent", value.ToString());
			}
		}

		public static bool AutoFileSingleEpisode
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["AutoFileSingleEpisode"];
				bool bval = true;
				if (bool.TryParse(val, out bval))
					return bval;
				else
					return false; // default value
			}
			set
			{
				UpdateSetting("AutoFileSingleEpisode", value.ToString());
			}
		}

		public static int DownloadsRecItems
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DownloadsRecItems"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 10;
				}
				else
					return 10; // default value
			}
			set
			{
				UpdateSetting("DownloadsRecItems", value.ToString());
			}
		}

		public static string LastLoginUsername
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;

				string val = appSettings["LastLoginUsername"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "";
					UpdateSetting("LastLoginUsername", val);
				}
				return val;
			}
			set
			{
				UpdateSetting("LastLoginUsername", value);
			}
		}

		public static DashboardType DashboardType
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				int val = 1;
				if (int.TryParse(appSettings["DashboardType"], out val))
					return (DashboardType)val;
				else
					return DashboardType.Normal; // default value
			}
			set
			{
				UpdateSetting("DashboardType", ((int)value).ToString());
			}
		}

		public static int DashMetro_WatchNext_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashMetro_WatchNext_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 5;
				}
				else
					return 5; // default value
			}
			set
			{
				UpdateSetting("DashMetro_WatchNext_Items", value.ToString());
			}
		}

		public static int DashMetro_RandomSeries_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashMetro_RandomSeries_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 5;
				}
				else
					return 5; // default value
			}
			set
			{
				UpdateSetting("DashMetro_RandomSeries_Items", value.ToString());
			}
		}

		public static int DashMetro_TraktActivity_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashMetro_TraktActivity_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 5;
				}
				else
					return 5; // default value
			}
			set
			{
				UpdateSetting("DashMetro_TraktActivity_Items", value.ToString());
			}
		}

		public static int DashMetro_NewEpisodes_Items
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashMetro_NewEpisodes_Items"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival >= 0 && ival <= 100)
						return ival;
					else
						return 5;
				}
				else
					return 5; // default value
			}
			set
			{
				UpdateSetting("DashMetro_NewEpisodes_Items", value.ToString());
			}
		}

		public static int DashMetro_Image_Height
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashMetro_Image_Height"];
				int ival = 0;
				if (int.TryParse(val, out ival))
				{
					if (ival < 30)
						return 30;

					if (ival > 300)
						return 300;

					return ival;
				}
				else
				{
					return 136; // default value
				}
			}
			set
			{
				UpdateSetting("DashMetro_Image_Height", value.ToString());
			}
		}

		public static DashboardMetroImageType DashMetroImageType
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				int val = 1;
				if (int.TryParse(appSettings["DashMetroImageType"], out val))
					return (DashboardMetroImageType)val;
				else
					return DashboardMetroImageType.Fanart; // default value
			}
			set
			{
				UpdateSetting("DashMetroImageType", ((int)value).ToString());
			}
		}

		public static string DashboardMetroSectionOrder
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashboardMetroSectionOrder"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "1:true;2:true;3:true;4:true";
					UpdateSetting("DashboardMetroSectionOrder", val);
				}

				// make sure the setting contains all the widgets
				// just in case the user has manually edited the config, or is using an old config
				string[] widgets = val.Split(';');
				List<string> tempWidgets = new List<string>();
				foreach (string w in widgets)
				{
					string[] vals = w.Split(':');
					tempWidgets.Add(vals[0]);
				}

				int maxEnum = 4;
				for (int i = 1; i <= maxEnum; i++)
				{
					if (!tempWidgets.Contains(i.ToString()))
					{
						if (val.Length > 0) val += ";";
						val += i.ToString() + ":true";
					}
				}

				return val;
			}
			set
			{
				UpdateSetting("DashboardMetroSectionOrder", value);
			}
		}

		public static string DashboardMetroSectionVisibility
		{
			get
			{
				NameValueCollection appSettings = ConfigurationManager.AppSettings;
				string val = appSettings["DashboardMetroSectionVisibility"];
				if (string.IsNullOrEmpty(val))
				{
					// default value
					val = "1;1;1;1";
					UpdateSetting("DashboardMetroSectionVisibility", val);
				}

				// make sure the setting contains all the widgets
				// just in case the user has manually edited the config, or is using an old config
				string[] widgets = val.Split(';');
				int maxEnum = 4;
				for (int i = 1; i <= maxEnum; i++)
				{
					if (!widgets.Contains(i.ToString()))
					{
						if (val.Length > 0) val += ";";
						val += i.ToString();
					}
				}

				return val;
			}
			set
			{
				UpdateSetting("DashboardMetroSectionVisibility", value);
			}
		}

		public static void DebugSettingsToLog()
		{
			#region System Info
			logger.Info("-------------------- SYSTEM INFO -----------------------");

			System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
			try
			{
				if (a != null)
				{
					logger.Info(string.Format("JMM Desktop Version: v{0}", Utils.GetApplicationVersion(a)));
				}
			}
			catch (Exception ex)
			{
				// oopps, can't create file
				logger.Warn("Error in log: {0}", ex.ToString());
			}

			logger.Info(string.Format("Operating System: {0}", Utils.GetOSInfo()));

			string screenSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString() + "x" +
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
			logger.Info(string.Format("Screen Size: {0}", screenSize));


			logger.Info("-------------------------------------------------------");
			#endregion

			logger.Info("----------------- DESKTOP SETTINGS ----------------------");

			logger.Info("Culture: {0}", Culture);
			logger.Info("Episodes_Availability: {0}", Episodes_Availability);
			logger.Info("Episodes_WatchedStatus: {0}", Episodes_WatchedStatus);
			logger.Info("BaseImagesPath: {0}", BaseImagesPath);
			logger.Info("BaseImagesPathIsDefault: {0}", BaseImagesPathIsDefault);
			logger.Info("JMMServer_Address: {0}", JMMServer_Address);
			logger.Info("JMMServer_Port: {0}", JMMServer_Port);
			logger.Info("JMMServer_FilePort: {0}", JMMServer_FilePort);
			logger.Info("EpisodeImageOverviewStyle: {0}", EpisodeImageOverviewStyle);
			logger.Info("HideEpisodeImageWhenUnwatched: {0}", HideEpisodeImageWhenUnwatched);
			logger.Info("HideEpisodeOverviewWhenUnwatched: {0}", HideEpisodeOverviewWhenUnwatched);
			logger.Info("Dash_WatchNext_Style: {0}", Dash_WatchNext_Style);

			logger.Info("-------------------------------------------------------");
		}
	}
}
