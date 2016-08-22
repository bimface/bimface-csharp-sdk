using System;
using Bimface.SDK.Properties;

namespace Bimface.SDK.Utils
{
    /// <summary>
    ///     版本工具
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class VersionInfoUtils
    {
        private const string USER_AGENT_PREFIX = "Bimface-SDK-NET";
        private static string version;
        private static string defaultUserAgent;

        public static string Version
        {
            get
            {
                if (string.IsNullOrEmpty(version))
                {
                    InitializeVersion();
                }
                return version;
            }
        }

        public static string DefaultUserAgent
        {
            get
            {
                if (defaultUserAgent == null)
                {
                    var operatingSystem = Environment.OSVersion;
                    defaultUserAgent = string.Format("{0}/{1}(OS:{2};.NET:{3})", USER_AGENT_PREFIX, Version,
                        Environment.OSVersion, Environment.Version);
                }
                return defaultUserAgent;
            }
        }

        private static void InitializeVersion()
        {
            try
            {
                version = Resources.Version;
            }
            catch (Exception)
            {
                version = "unknown-version";
            }
        }
    }
}