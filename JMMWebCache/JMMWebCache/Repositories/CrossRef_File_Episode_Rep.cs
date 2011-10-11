using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMMWebCache.Entities;
using NHibernate.Criterion;

namespace OMMWebCache.Repositories
{
	public class CrossRef_File_Episode_Rep
	{
		public void Save(CrossRef_File_Episode obj)
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

		public CrossRef_File_Episode GetByID(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				return session.Get<CrossRef_File_Episode>(id);
			}
		}

		public List<CrossRef_File_Episode> GetByHash(string hash)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_File_Episode))
					.Add(Restrictions.Eq("Hash", hash))
					.AddOrder(Order.Asc("EpisodeOrder"))
					.List<CrossRef_File_Episode>();

				return new List<CrossRef_File_Episode>(xrefs);
			}
		}


		/// <summary>
		/// This is the only way to uniquely identify the record other than the IDENTITY
		/// </summary>
		/// <param name="hash"></param>
		/// <param name="episodeID"></param>
		/// <returns></returns>
		public List<CrossRef_File_Episode> GetByHashAndUsername(string hash, string username)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_File_Episode))
					.Add(Restrictions.Eq("Hash", hash))
					.Add(Restrictions.Eq("Username", username))
					.AddOrder(Order.Asc("EpisodeOrder"))
					.List<CrossRef_File_Episode>();

				return new List<CrossRef_File_Episode>(xrefs);
			}
		}

		public List<CrossRef_File_Episode> GetByHashUsernameAndEpisodeID(string hash, string username, int epid)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				var xrefs = session
					.CreateCriteria(typeof(CrossRef_File_Episode))
					.Add(Restrictions.Eq("Hash", hash))
					.Add(Restrictions.Eq("Username", username))
					.Add(Restrictions.Eq("EpisodeID", epid))
					.List<CrossRef_File_Episode>();

				return new List<CrossRef_File_Episode>(xrefs);
			}
		}

		public void Delete(int id)
		{
			using (var session = WebCache.SessionFactory.OpenSession())
			{
				// populate the database
				using (var transaction = session.BeginTransaction())
				{
					CrossRef_File_Episode cr = GetByID(id);
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