using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Collections.Specialized;
using System.Configuration;

namespace OMMWebCache
{
	public class WebCache
	{
		private static readonly object sessionLock = new object();

		private static ISessionFactory sessionFactory = null;
		public static ISessionFactory SessionFactory
		{
			get
			{
				lock (sessionLock)
				{
					if (sessionFactory == null)
					{
						sessionFactory = CreateSessionFactory();
					}
					return WebCache.sessionFactory;
				}
			}
		}

		public static ISessionFactory CreateSessionFactory()
		{
			NameValueCollection appSettings = ConfigurationManager.AppSettings;
			string dbname = appSettings["DatabaseName"];
			string dbserver = appSettings["DatabaseServer"];
			string uname = appSettings["Username"];
			string password = appSettings["Password"];

			string connectionstring = string.Format(@"data source={0};initial catalog={1};persist security info=True;user id={2};password={3}",
				dbserver, dbname, uname, password);

			return Fluently.Configure()
			.Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionstring))
			.Mappings(m =>
				m.FluentMappings.AddFromAssemblyOf<WebCache>())
			.BuildSessionFactory();
			
		}
	}
}