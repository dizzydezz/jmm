using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace OMMWebCache
{
	public class Utils
	{
		public static readonly string AnonWebCacheUsername = @"AnonymousWebCacheUser";

		private static Regex htmlRE = new Regex(@"<(.|\n)*?>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		public static string ConvertToXML(object data, Type type)
		{
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("", "");

			XmlSerializer serializer = new XmlSerializer(type);
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.OmitXmlDeclaration = true; // Remove the <?xml version="1.0" encoding="utf-8"?>

			StringBuilder sb = new StringBuilder();
			XmlWriter writer = XmlWriter.Create(sb, settings);
			serializer.Serialize(writer, data, ns);

			return sb.ToString();
		}

		public static string TryGetProperty(string id, XmlDocument doc, string propertyName)
		{
			try
			{
				string prop = doc[id][propertyName].InnerText.Trim();
				return prop;
			}
			catch (Exception ex)
			{
			}

			return "";
		}

		public static string GetParam(string name)
		{
			string temp = "";

			if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[name]))
			{
				temp = HttpContext.Current.Request.QueryString[name];

				//Need to check if this is a url to retrieve a file. If so, need to get the redirect link as a whole (everything except redirect=)
				if (temp.IndexOf("file.type", 0) > 0)
				{
					string queryURL = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString.ToString()).ToString();

					//trucate queryURL string after the redirect= - position 9
					temp = queryURL.Substring(9, queryURL.Length - 9);
				}
			}

			// attempt to remove any nasties
			return FilterString(temp);
		}

		public static string FilterString(string input)
		{
			//if (temp.IndexOf('\'') < 0 && temp.IndexOf('%') < 0 && temp.IndexOf('"') < 0)
			//	ret = temp;

			if (string.IsNullOrEmpty(input))
				return string.Empty;

			input = input.Trim();

			string[] forbidden = { "union", "script", "cookie", "applet", "activex", "onabort", "sysobjects", "syslogins", "xp_", "openquery", "openrowset", "onblur", "onchange", "onclick", "ondblclick", "ondragdrop", "onerror", "onfocus", "onkeydown", "onkeypress", "onload", "onmouse", "onmove", "onreset", "onresize", "onselect", "onsubmit", "onunload" };

			for (int i = 0; i < forbidden.Length; i++)
			{
				if (input.IndexOf(forbidden[i]) >= 0)
					input = input.Replace(forbidden[i], "");
			}

			//input = input.Replace("'", "''");

			//input = HttpUtility.UrlEncode(input);
			input = HttpUtility.UrlDecode(input);

			//input = input.Replace("&", "&amp;");
			input = RemoveHtml(input);

			return input;
		}

		/// <summary>
		/// Removes all HTML tags from a string
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string RemoveHtml(string source)
		{
			if (string.IsNullOrEmpty(source))
				return string.Empty;

			source = source.Trim();
			//			source = source.Replace("&", " &amp; ");
			source = source.Replace("\"", "&quot;");

			// IE doesn't seem to support &apos!
			//source = source.Replace("'", "&apos;");

			return htmlRE.Replace(source, string.Empty);
		}
	}
}