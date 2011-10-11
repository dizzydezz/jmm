using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using OMMWebCache.Entities;

namespace OMMWebCache.Mappings
{
	public class CrossRef_AniDB_OtherMap : ClassMap<CrossRef_AniDB_Other>
	{
		public CrossRef_AniDB_OtherMap()
		{
			Not.LazyLoad();
			Id(x => x.CrossRef_AniDB_OtherID);

			Map(x => x.AnimeID).Not.Nullable();
			Map(x => x.CrossRefID);
			Map(x => x.CrossRefSource).Not.Nullable();
			Map(x => x.CrossRefType).Not.Nullable();
			Map(x => x.AdminApproved).Not.Nullable();
			Map(x => x.Username);
		}
	}
}