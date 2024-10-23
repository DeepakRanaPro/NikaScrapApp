namespace NikaScrapApp.Web.Utility.CustomFilters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using NikaScrapApp.Web.Models;

    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var request = context.HttpContext.Request;
            var routeData = context.RouteData;
            var controllerName = routeData.Values["controller"]?.ToString();
            var actionName = routeData.Values["action"]?.ToString();
            var requestUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";

            _logger.LogError(context.Exception, context.Exception.Message);
             
            var errorModel = new ErrorViewModel
            {
                RequestId = context.HttpContext.TraceIdentifier,
                ControllerName = controllerName,
                ActionName = actionName,
                RequestUrl = requestUrl,
                Exception = context.Exception
            };

            //var result = new ViewResult { ViewName = "Error" };
            //result.ViewData["Exception"] = context.Exception.Message;
            //result.ViewData["requestUrl"] = requestUrl;
            //result.ViewData["controllerName"] = controllerName;
            //result.ViewData["actionName"] = actionName;

            context.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ErrorViewModel>(
                    new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
                    new Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary())
                {
                    Model = errorModel
                }
            };
            context.ExceptionHandled = true;
        }
    }

}
