using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TodoList.Project.Extensions
{
    /// <summary>
    /// 自定义middleware
    /// </summary>
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggerMiddleware(RequestDelegate nextRequestDelegate, ILoggerFactory loggerFactory)
        {
            _next = nextRequestDelegate;
            _logger = loggerFactory.CreateLogger<RequestLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Handling request: " + context.Request.Path);
            await _next.Invoke(context);
            _logger.LogInformation("Finished handling request.");
        }
    }
}
