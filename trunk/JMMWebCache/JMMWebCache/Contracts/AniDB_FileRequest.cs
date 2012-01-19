using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JMMWebCache.Entities;

namespace JMMWebCache.Contracts
{
	public class AniDB_FileRequest
	{
		public int FileID { get; set; }
		public string Hash { get; set; }
		public int AnimeID { get; set; }
		public int GroupID { get; set; }
		public string File_Source { get; set; }
		public string File_AudioCodec { get; set; }
		public string File_VideoCodec { get; set; }
		public string File_VideoResolution { get; set; }
		public string File_FileExtension { get; set; }
		public int File_LengthSeconds { get; set; }
		public string File_Description { get; set; }
		public int File_ReleaseDate { get; set; }
		public string Anime_GroupName { get; set; }
		public string Anime_GroupNameShort { get; set; }
		public int Episode_Rating { get; set; }
		public int Episode_Votes { get; set; }
		public string CRC { get; set; }
		public string MD5 { get; set; }
		public string SHA1 { get; set; }
		public string FileName { get; set; }
		public long FileSize { get; set; }


		public string SubtitlesRAW { get; set; }
		public string LanguagesRAW { get; set; }
		public string EpisodesRAW { get; set; }
		public string EpisodesPercentRAW { get; set; }

		public AniDB_FileRequest()
		{
		}

		public AniDB_FileRequest(AniDB_File data)
		{
			this.Anime_GroupName = data.Anime_GroupName;
			this.Anime_GroupNameShort = data.Anime_GroupNameShort;
			this.AnimeID = data.AnimeID;
			this.CRC = data.CRC;
			this.Episode_Rating = data.Episode_Rating;
			this.Episode_Votes = data.Episode_Votes;
			this.File_AudioCodec = data.File_AudioCodec;
			this.File_Description = data.File_Description;
			this.File_FileExtension = data.File_FileExtension;
			this.File_LengthSeconds = data.File_LengthSeconds;
			this.File_ReleaseDate = data.File_ReleaseDate;
			this.File_Source = data.File_Source;
			this.File_VideoCodec = data.File_VideoCodec;
			this.File_VideoResolution = data.File_VideoResolution;
			this.FileID = data.FileID;
			this.FileName = data.FileName;
			this.FileSize = data.FileSize;
			this.GroupID = data.GroupID;
			this.Hash = data.Hash;
			this.MD5 = data.MD5;
			this.SHA1 = data.SHA1;

			this.SubtitlesRAW = data.SubtitlesRAW;
			this.LanguagesRAW = data.LanguagesRAW;
			this.EpisodesRAW = data.EpisodesRAW;
			this.EpisodesPercentRAW = data.EpisodesPercentRAW;
		}
	}
}