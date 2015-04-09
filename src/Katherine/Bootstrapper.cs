using Katherine.Core.Caching;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Elmah;
using Nancy.TinyIoc;
using System;

namespace Katherine
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper


        /// <summary>
        /// Configure Nancy conventions.
        /// </summary>
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            /// <summary>
            /// Expires Header to Static Content in NancyFx
            /// Url: http://mike-ward.net/2014/01/13/adding-an-expires-header-to-static-content-in-nancyfx/
            /// </summary>
            nancyConventions.StaticContentsConventions.Clear();
            var responseBuilder = StaticContentConventionBuilderAddOn
                .AddDirectoryWithExpiresHeader("content", TimeSpan.FromDays(8));
            nancyConventions.StaticContentsConventions.Add(responseBuilder);

        }

        /// <summary>
        /// Application Startup
        /// </summary>
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {

            base.ApplicationStartup(container, pipelines);

            Nancy.Security.Csrf.Enable(pipelines);

            /// <summary>
            /// Elmah Logging - Enable Exception logging with select HttpStatusCode logging
            /// </summary>

            //TODO: Secure Elmah

            Elmahlogging.Enable(pipelines, "elmah", null, new HttpStatusCode[] { HttpStatusCode.NotFound, HttpStatusCode.InsufficientStorage, HttpStatusCode.InternalServerError });

        }
    }
}