using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using JMMWebCache.Entities;

namespace JMMWebCache.Mappings
{
	public class CrossRef_AniDB_MALMap : ClassMap<CrossRef_AniDB_MAL>
	{
		public CrossRef_AniDB_MALMap()
		{
			Not.LazyLoad();
			Id(x => x.CrossRef_AniDB_MALID);

			Map(x => x.AnimeID).Not.Nullable();
			Map(x => x.MALID);
			Map(x => x.CrossRefSource).Not.Nullable();
			Map(x => x.Username);
			Map(x => x.MALTitle);
		}
	}
}