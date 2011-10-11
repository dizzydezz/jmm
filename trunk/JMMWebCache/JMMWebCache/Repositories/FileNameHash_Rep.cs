using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;
using NHibernate.Criterion;

namespace OMMWebCache.Repositories
{
	public class FileNameHash_Rep
	{
		public void Save(FileNameHash obj)
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

		public FileNameHash GetByID(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				return session.Get<FileNameHash>(id);
			}
		}

		public FileNameHash GetForUser(string username, long fileSize, string hash, string fileName)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				FileNameHash obj = session
					.CreateCriteria(typeof(FileNameHash))
					.Add(Restrictions.Eq("Username", username))
					.Add(Restrictions.Eq("FileSize", fileSize))
					.Add(Restrictions.Eq("Hash", hash.Trim().ToUpper()))
					.Add(Restrictions.Eq("FileName", fileName))
					.UniqueResult<FileNameHash>();

				return obj;
			}
		}

		public List<FileNameHash> SearchForUser(string username, long fileSize, string fileName)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var objs = session
					.CreateCriteria(typeof(FileNameHash))
					.Add(Restrictions.Eq("Username", username))
					.Add(Restrictions.Eq("FileSize", fileSize))
					.Add(Restrictions.Eq("FileName", fileName))
					.List<FileNameHash>();

				return new List<FileNameHash>(objs);
			}
		}

		public List<FileNameHash> SearchForAll(long fileSize, string fileName)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var objs = session
					.CreateCriteria(typeof(FileNameHash))
					.Add(Restrictions.Eq("FileSize", fileSize))
					.Add(Restrictions.Eq("FileName", fileName))
					.List<FileNameHash>();

				return new List<FileNameHash>(objs);
			}
		}

		public void Delete(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					FileNameHash cr = GetByID(id);
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