using Nancy;

namespace Katherine.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}