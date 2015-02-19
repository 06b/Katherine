using Nancy;
using Nancy.Bootstrapper;
using Nancy.Elmah;
using Nancy.TinyIoc;
using ConfigR;

namespace Katherine
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper


        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {

            Config.Global.LoadScriptFile("Katherine.csx");

            base.ApplicationStartup(container, pipelines);

            /// <summary>
            /// Elmah Logging - Enable Exception logging with select HttpStatusCode logging
            /// </summary>

            //TODO: Secure Elmah

            Elmahlogging.Enable(pipelines, "elmah", null, new HttpStatusCode[] { HttpStatusCode.NotFound, HttpStatusCode.InsufficientStorage, HttpStatusCode.InternalServerError });

        }
    }
}