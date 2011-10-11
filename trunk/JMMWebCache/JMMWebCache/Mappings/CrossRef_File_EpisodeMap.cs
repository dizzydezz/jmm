using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using OMMWebCache.Entities;

namespace OMMWebCache.Mappings
{
	public class CrossRef_File_EpisodeMap : ClassMap<CrossRef_File_Episode>
	{
		public CrossRef_File_EpisodeMap()
		{
			Not.LazyLoad();
			Id(x => x.CrossRef_File_EpisodeID);

			Map(x => x.EpisodeID).Not.Nullable();
			Map(x => x.EpisodeOrder).Not.Nullable();
			Map(x => x.Hash);
			Map(x => x.Percentage).Not.Nullable();
			Map(x => x.AnimeID).Not.Nullable();
			Map(x => x.DateTimeUpdated).Not.Nullable();
			Map(x => x.Username);
		}
	}
}