using FridgeProduct.Contracts;
using FridgeProduct.Entities.ErrorModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace FridgeProduct.Extensions
{
    public static class ExceptionMiddleWareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contectFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contectFeature != null)
                {
                    logger.LogError($"Something went wrong: {contectFeature.Error}");

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal Server Error."
                    }.ToString());
                    }
                });
            });
        }
    }
}
