using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using OMMWebCache.Entities;

namespace OMMWebCache.Mappings
{
	public class AniDB_UpdatedMap : ClassMap<AniDB_Updated>
	{
		public AniDB_UpdatedMap()
		{
			Not.LazyLoad();
			Id(x => x.AniDB_UpdatedID);

			Map(x => x.AnimeIDList);
			Map(x => x.DateTimeCreated).Not.Nullable();
			Map(x => x.UpdateTime).Not.Nullable();
			Map(x => x.Username);
		}
	}
}