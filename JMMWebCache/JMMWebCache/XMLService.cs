using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using OMMWebCache;

namespace JMMWebCache
{
	public class XMLService
	{
		public static void SendData(string uri, string xml)
		{
			if (!Utils.IsPrimaryCache()) return;

			WebRequest req = null;
			WebResponse rsp = null;
			try
			{
				DateTime start = DateTime.Now;

				req = WebRequest.Create(uri);
				req.Method = "POST";        // Post method
				req.ContentType = "text/xml";     // content type
				req.Proxy = null;

				// Wrap the request stream with a text-based writer
				StreamWriter writer = new StreamWriter(req.GetRequestStream());
				// Write the XML text into the stream
				writer.WriteLine(xml);
				writer.Close();
				// Send the data to the webserver
				rsp = req.GetResponse();

			}
			catch (WebException webEx)
			{
				//logger.Error("Error(1) in XMLServiceQueue.SendData: {0}", webEx);
			}
			catch (Exception ex)
			{
				//logger.ErrorException("Error(2) in XMLServiceQueue.SendData: {0}", ex);
			}
			finally
			{
				if (req != null) req.GetRequestStream().Close();
				if (rsp != null) rsp.GetResponseStream().Close();
			}
		}
	}
}