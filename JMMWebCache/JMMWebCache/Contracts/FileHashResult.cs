using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMMWebCache.Contracts
{
	[Serializable]
	public class FileHashResult : XMLBase
	{
		protected string hash = "";
		public string Hash
		{
			get { return hash; }
			set { hash = value; }
		}

		// default constructor
		public FileHashResult()
		{
		}

		public FileHashResult(string hash)
		{
			this.hash = hash;
		}
	}
}