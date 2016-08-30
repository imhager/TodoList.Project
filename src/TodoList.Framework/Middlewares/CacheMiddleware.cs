using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TodoList.Framework.Middlewares
{
    public class CacheMiddleware
    {
        protected RequestDelegate NextMiddlewareDelegate;

        public CacheMiddleware(RequestDelegate nextMiddlewareDelegate)
        {
            NextMiddlewareDelegate = nextMiddlewareDelegate;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            using (var responseStream = new MemoryStream())
            {
                var fullResponse = httpContext.Response.Body;
                httpContext.Response.Body = responseStream;
                await NextMiddlewareDelegate.Invoke(httpContext);
                responseStream.Seek(0, SeekOrigin.Begin);

                await responseStream.CopyToAsync(fullResponse);
            }
        }

    }
}
