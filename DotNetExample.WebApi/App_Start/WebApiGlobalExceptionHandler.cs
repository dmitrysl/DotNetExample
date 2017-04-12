using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace DotNetExample.WebApi.App_Start
{
    public class WebApiGlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Handle(ExceptionHandlerContext context)
        {
            var requestContext = context.RequestContext;
            var config = requestContext.Configuration;

            context.Result = new ErrorResult(
              context.Exception,
              requestContext == null ? false : requestContext.IncludeErrorDetail,
              config.Services.GetContentNegotiator(),
              context.Request,
              config.Formatters);
        }

        private class ErrorResult : ExceptionResult
        {
            public ErrorResult(Exception exception, bool includeErrorDetail, IContentNegotiator negotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
                : base(exception, includeErrorDetail, negotiator, request, formatters)
            {
            }

            public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var content = new HttpError(Exception, IncludeErrorDetail);
                content.Add("code", "UnknownError");
                content.Message = Exception.Message;

                var result = ContentNegotiator.Negotiate(typeof(HttpError), Request, Formatters);

                var message = new HttpResponseMessage
                {
                    RequestMessage = Request,
                    StatusCode = result == null ?
                    HttpStatusCode.NotAcceptable : HttpStatusCode.InternalServerError
                };

                if (result != null)
                {
                    try
                    {
                        message.Content = new ObjectContent<HttpError>(
                          content,
                          result.Formatter,
                          result.MediaType);
                    }
                    catch
                    {
                        message.Dispose();

                        throw;
                    }
                }

                return Task.FromResult(message);
            }
        }
    }
}