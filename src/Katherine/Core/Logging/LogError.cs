using Elmah;
using System;
using System.Web;

namespace Katherine.Core.Logging
{
    public static class ErrorLog
    {

        /// <summary>
        /// Manually Log errors to Elmah
        /// Source: http://stackoverflow.com/a/14770142
        /// </summary>
        public static void LogError(Exception ex, string contextualMessage = null)
        {
            try
            {
                // log error to Elmah
                if (contextualMessage != null)
                {
                    // log exception with contextual information that's visible when
                    // clicking on the error in the Elmah log
                    var annotatedException = new Exception(contextualMessage, ex);
                    ErrorSignal.FromCurrentContext().Raise(annotatedException, HttpContext.Current);
                }
                else
                {
                    ErrorSignal.FromCurrentContext().Raise(ex, HttpContext.Current);
                }

            }
            catch (Exception)
            {
                // uh oh! just keep going
                // The caveat is a third party API could keep calling itself and blow up the app pool
            }
        }
    }
}