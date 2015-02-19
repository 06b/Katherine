using System;
using Nancy;
using Nancy.Conventions;

namespace Katherine.Core.Caching
{
    /// <summary>
    /// Expires Header to Static Content in NancyFx
    /// Url: http://mike-ward.net/2014/01/13/adding-an-expires-header-to-static-content-in-nancyfx/
    /// </summary>
    public static class StaticContentConventionBuilderAddOn
    {
        public static Func<NancyContext, string, Response> AddDirectoryWithExpiresHeader(
            string requestedPath,
            TimeSpan expiresTimeSpan,
            string contentPath = null,
            params string[] allowedExtensions)
        {
            var responseBuilder = StaticContentConventionBuilder
               .AddDirectory(requestedPath, contentPath, allowedExtensions);
            return (context, root) =>
            {
                var response = responseBuilder(context, root);
                if (response != null)
                {
                    response.Headers.Add("Expires", DateTime.Now.Add(expiresTimeSpan).ToString("R"));
                }
                return response;
            };
        }
    }
}