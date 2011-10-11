using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using OMMWebCache.Entities;

namespace OMMWebCache.Mappings
{
	public class FileNameHashMap : ClassMap<FileNameHash>
	{
		public FileNameHashMap()
        {
			Not.LazyLoad();
            Id(x => x.FileNameHashID);

			Map(x => x.DateTimeUpdated).Not.Nullable();
			Map(x => x.FileName);
			Map(x => x.FileSize).Not.Nullable();
			Map(x => x.Hash);
			Map(x => x.Username);
        }
	}
}