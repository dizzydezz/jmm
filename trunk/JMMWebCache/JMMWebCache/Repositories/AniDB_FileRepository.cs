using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JMMWebCache.Entities;
using OMMWebCache;
using NHibernate.Criterion;

namespace JMMWebCache.Repositories
{
	public class AniDB_FileRepository
	{
		public void Save(AniDB_File obj)
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

		public AniDB_File GetByID(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				return session.Get<AniDB_File>(id);
			}
		}

		public AniDB_File GetByHashAndFileSize(string hash, long fileSize)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				AniDB_File cr = session
					.CreateCriteria(typeof(AniDB_File))
					.Add(Restrictions.Eq("Hash", hash))
					.Add(Restrictions.Eq("FileSize", fileSize))
					.UniqueResult<AniDB_File>();
				return cr;
			}
		}

		public AniDB_File GetByFileID(int fileID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				AniDB_File cr = session
					.CreateCriteria(typeof(AniDB_File))
					.Add(Restrictions.Eq("FileID", fileID))
					.UniqueResult<AniDB_File>();
				return cr;
			}
		}

		public List<AniDB_File> GetAll()
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var objs = session
					.CreateCriteria(typeof(AniDB_File))
					.List<AniDB_File>();

				return new List<AniDB_File>(objs);
			}
		}

		public List<AniDB_File> GetByAnimeID(int animeID)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var objs = session
					.CreateCriteria(typeof(AniDB_File))
					.Add(Restrictions.Eq("AnimeID", animeID))
					.List<AniDB_File>();

				return new List<AniDB_File>(objs);
			}
		}

		public void Delete(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					AniDB_File cr = GetByID(id);
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