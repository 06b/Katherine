using Nancy;
using System.Dynamic;

namespace Katherine.Modules
{
    public class HomeModule : NancyModule
    {

        protected dynamic Model = new ExpandoObject();

        public HomeModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };
        }
    }
}