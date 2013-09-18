using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace demoncodemonkey.LittleHelpers
{
	public static class WebConfig
	{
		/// <summary>
		/// Get an app-setting from the web.config as a string. The defaultValue will be returned if the specified setting is not found.
		/// </summary>
		public static string Get(string key, string defaultValue = "")
		{
			string configPath = HttpRuntime.AppDomainAppVirtualPath;
			var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath);
			if ((config.AppSettings.Settings.Count > 0) && config.AppSettings.Settings.AllKeys.Contains(key))
				return config.AppSettings.Settings[key].Value ?? defaultValue;
			return defaultValue;
		}

		/// <summary>
		/// Get an app-setting from the web.config as a bool. The defaultValue will be returned if the specified setting is not found or cannot be parsed.
		/// </summary>
		public static bool GetBool(string key, bool defaultValue = false)
		{
			string configValue = Get(key);
			bool result;
			if (bool.TryParse(configValue, out result))
				return result;
			return defaultValue;
		}

		/// <summary>
		/// Get an app-setting from the web.config as an int. The defaultValue will be returned if the specified setting is not found or cannot be parsed.
		/// </summary>
		public static int GetInt(string key, int defaultValue = 0)
		{
			string configValue = Get(key);
			int result;
			if (int.TryParse(configValue, out result))
				return result;
			return defaultValue;
		}
	}
}
