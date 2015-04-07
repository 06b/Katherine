﻿using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.ErrorHandling;
using Nancy.ViewEngines;

namespace Katherine.Core.Handlers
{

    /// <summary>
    /// Custom Error Pages
    /// Url: https://blog.tommyparnell.com/custom-error-pages-in-nancy/
    /// </summary>
    public class ErrorStatusCodeHandler : IStatusCodeHandler
    {
        private static IEnumerable<int> _checks = new List<int>();

        public static IEnumerable<int> Checks { get { return _checks; } }

        private IViewRenderer viewRenderer;

        public ErrorStatusCodeHandler(IViewRenderer viewRenderer)
        {
            this.viewRenderer = viewRenderer;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return (_checks.Any(x => x == (int)statusCode));
        }

        public static void AddCode(int code)
        {
            AddCode(new List<int>() { code });
        }
        public static void AddCode(IEnumerable<int> code)
        {
            _checks = _checks.Union(code);
        }

        public static void RemoveCode(int code)
        {
            RemoveCode(new List<int>() { code });
        }
        public static void RemoveCode(IEnumerable<int> code)
        {
            _checks = _checks.Except(code);
        }

        public static void Disable()
        {
            _checks = new List<int>();
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            try
            {

                if (statusCode == HttpStatusCode.NotFound)
                {
                    // Specific Custom Error Codes Pages
                    var response = viewRenderer.RenderView(context, "Codes/" + (int)statusCode + ".cshtml");
                    response.StatusCode = statusCode;
                    context.Response = response;
                }
                else
                {
                    // Generic Custom Error Code Page
                    var response = viewRenderer.RenderView(context, "Codes/DefaultError.cshtml");
                    response.StatusCode = statusCode;
                    context.Response = response;
                }

            }
            catch (Exception)
            {

                RemoveCode((int)statusCode);
                context.Response.StatusCode = statusCode;
            }
        }
    }
}