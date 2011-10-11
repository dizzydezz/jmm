using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;
using NHibernate.Criterion;

namespace OMMWebCache.Repositories
{
	public class CrossRef_AniDB_TvDBRepository
	{
		public void Save(CrossRef_AniDB_TvDB obj)
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

		public CrossRef_AniDB_TvDB GetByID(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				return session.Get<CrossRef_AniDB_TvDB>(id);
			}
		}

		public List<CrossRef_AniDB_TvDB> GetByAnimeID(int animeID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_TvDB))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.List<CrossRef_AniDB_TvDB>();

				return new List<CrossRef_AniDB_TvDB>(xrefs);
			}
		}

		public List<CrossRef_AniDB_TvDB> GetByTvDBID(int seriesID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_TvDB))
					.Add(Restrictions.Eq("TvDBID", seriesID))
					.List<CrossRef_AniDB_TvDB>();

				return new List<CrossRef_AniDB_TvDB>(xrefs);
			}
		}

		public List<CrossRef_AniDB_TvDB> GetByAnimeIDUser(int animeID, string username)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_TvDB))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.Add(Restrictions.Eq("Username", username))
					.List<CrossRef_AniDB_TvDB>();

				return new List<CrossRef_AniDB_TvDB>(xrefs);
			}
		}

		public List<CrossRef_AniDB_TvDB> GetByAnimeIDApproved(int animeID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_TvDB))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.Add(Restrictions.Eq("AdminApproved", 1))
					.List<CrossRef_AniDB_TvDB>();

				return new List<CrossRef_AniDB_TvDB>(xrefs);
			}
		}

		public void Delete(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					CrossRef_AniDB_TvDB cr = GetByID(id);
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