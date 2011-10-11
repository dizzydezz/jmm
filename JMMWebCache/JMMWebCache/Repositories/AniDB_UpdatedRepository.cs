using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;
using NHibernate.Criterion;

namespace OMMWebCache.Repositories
{
	public class AniDB_UpdatedRepository
	{
		public void Save(AniDB_Updated obj)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					session.SaveOrUpdate(obj);
					transaction.Commit();
				}
			}
		}

		public AniDB_Updated GetByID(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				return session.Get<AniDB_Updated>(id);
			}
		}

		public List<AniDB_Updated> GetByAnimeID(int animeID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(AniDB_Updated))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.List<AniDB_Updated>();

				return new List<AniDB_Updated>(xrefs);
			}
		}

		public List<AniDB_Updated> GetAll()
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var objs = session
					.CreateCriteria(typeof(AniDB_Updated))
					.AddOrder(Order.Asc("UpdateTime"))
					.List<AniDB_Updated>();

				return new List<AniDB_Updated>(objs); ;
			}
		}

		public void Delete(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					AniDB_Updated cr = GetByID(id);
					if (cr != null)
					{
						session.Delete(cr);
						transaction.Commit();
					}
				}
			}
		}
	}
}