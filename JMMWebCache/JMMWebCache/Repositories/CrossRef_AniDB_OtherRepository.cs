using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;
using NHibernate.Criterion;

namespace OMMWebCache.Repositories
{
	public class CrossRef_AniDB_OtherRepository
	{
		public void Save(CrossRef_AniDB_Other obj)
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

		public CrossRef_AniDB_Other GetByID(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				return session.Get<CrossRef_AniDB_Other>(id);
			}
		}

		public List<CrossRef_AniDB_Other> GetByAnimeID(int animeID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_Other))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.List<CrossRef_AniDB_Other>();

				return new List<CrossRef_AniDB_Other>(xrefs);
			}
		}

		public List<CrossRef_AniDB_Other> GetByAnimeIDAndType(int animeID, CrossRefType xrefType)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_Other))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.Add(Restrictions.Eq("CrossRefType", (int)xrefType))
					.List<CrossRef_AniDB_Other>();

				return new List<CrossRef_AniDB_Other>(xrefs);
			}
		}

		public List<CrossRef_AniDB_Other> GetByAnimeIDAndTypeAndUser(int animeID, string username, CrossRefType xrefType)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_Other))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.Add(Restrictions.Eq("CrossRefType", (int)xrefType))
					.Add(Restrictions.Eq("Username", username))
					.List<CrossRef_AniDB_Other>();

				return new List<CrossRef_AniDB_Other>(xrefs);
			}
		}

		public void Delete(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					CrossRef_AniDB_Other cr = GetByID(id);
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