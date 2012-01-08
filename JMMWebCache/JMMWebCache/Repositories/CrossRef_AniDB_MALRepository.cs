using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JMMWebCache.Entities;
using OMMWebCache;
using NHibernate.Criterion;

namespace JMMWebCache.Repositories
{
	public class CrossRef_AniDB_MALRepository
	{
		public void Save(CrossRef_AniDB_MAL obj)
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

		public CrossRef_AniDB_MAL GetByID(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				return session.Get<CrossRef_AniDB_MAL>(id);
			}
		}

		public List<CrossRef_AniDB_MAL> GetByAnimeID(int animeID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_MAL))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.List<CrossRef_AniDB_MAL>();

				return new List<CrossRef_AniDB_MAL>(xrefs);
			}
		}

		public List<CrossRef_AniDB_MAL> GetByMALID(string malID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_MAL))
					.Add(Restrictions.Eq("MALID", malID))
					.List<CrossRef_AniDB_MAL>();

				return new List<CrossRef_AniDB_MAL>(xrefs);
			}
		}

		public List<CrossRef_AniDB_MAL> GetByAnimeIDUser(int animeID, string username)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_MAL))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.Add(Restrictions.Eq("Username", username))
					.List<CrossRef_AniDB_MAL>();

				return new List<CrossRef_AniDB_MAL>(xrefs);
			}
		}

		public void Delete(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					CrossRef_AniDB_MAL cr = GetByID(id);
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