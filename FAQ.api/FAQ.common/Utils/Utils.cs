using Microsoft.Extensions.Configuration;
using System;

namespace FAQ.common
{
    public class Utils
    {
        public static string GetConfig(string code)
        {
            IConfigurationRoot configuration = ConfigCollection.Instance.GetConfiguration();
            var value = configuration[code];
            return value;
        }

        public static string GetConfig(string code, string defaultValue)
        {
            IConfigurationRoot configuration = ConfigCollection.Instance.GetConfiguration();
            var value = configuration[code];
            if (string.IsNullOrEmpty(value))
                return defaultValue;
            return value;
        }

        public static string GetConfig(IConfiguration configuration, string code)
        {
            var value = configuration[code];
            return value;
        }
    }
}
