using System;
using System.Linq;
using AccessSoftekCore.Configs.Interfaces;

namespace AccessSoftekCore.Configs
{
    public class BaseConfig
    {
        public static IApplication Application { get; set; }

        public static Uri BaseUri { get; set; }

        public static Uri BaseUriFor(IApplication application)
        {
            return new UriBuilder(Uri.UriSchemeHttps, application.Url.Authority).Uri;
        }

        protected static Uri UriFor(IApplication application, string pathName)
        {
            var baseUri = BaseUriFor(application);
            var relativeUri = application.Url.Paths.SingleOrDefault(endpoint => endpoint.Name.Equals(pathName))?.Path ?? string.Empty;

            return new Uri(baseUri, relativeUri);
        }
    }
}