using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;
using NHibernate.Criterion;

namespace OMMWebCache.Repositories
{
	public class CrossRef_AniDB_TraktRepository
	{
		public void Save(CrossRef_AniDB_Trakt obj)
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

		public CrossRef_AniDB_Trakt GetByID(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				return session.Get<CrossRef_AniDB_Trakt>(id);
			}
		}

		public List<CrossRef_AniDB_Trakt> GetByAnimeID(int animeID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_Trakt))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.List<CrossRef_AniDB_Trakt>();

				return new List<CrossRef_AniDB_Trakt>(xrefs);
			}
		}

		public List<CrossRef_AniDB_Trakt> GetByTraktDBID(string showiD)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_Trakt))
					.Add(Restrictions.Eq("TraktID", showiD))
					.List<CrossRef_AniDB_Trakt>();

				return new List<CrossRef_AniDB_Trakt>(xrefs);
			}
		}

		public List<CrossRef_AniDB_Trakt> GetByAnimeIDUser(int animeID, string username)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_Trakt))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.Add(Restrictions.Eq("Username", username))
					.List<CrossRef_AniDB_Trakt>();

				return new List<CrossRef_AniDB_Trakt>(xrefs);
			}
		}

		public List<CrossRef_AniDB_Trakt> GetByAnimeIDApproved(int animeID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_AniDB_Trakt))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.Add(Restrictions.Eq("AdminApproved", 1))
					.List<CrossRef_AniDB_Trakt>();

				return new List<CrossRef_AniDB_Trakt>(xrefs);
			}
		}

		public void Delete(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					CrossRef_AniDB_Trakt cr = GetByID(id);
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