using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Excepitons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharedLibrary.Extensions
{
    public static class CustomeExcepitonHandler
    {
        public static void UseCustomeExcepiton(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(cfg =>
            {
                cfg.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var errors = context.Features.Get<IExceptionHandlerFeature>();
                    if (errors!=null)
                    {
                        var ex = errors.Error;
                        ErrorDto errorDto = null;
                        if (ex is CustomeException)
                        {
                            errorDto = new ErrorDto(ex.Message,true);
                        }
                        else
                        {
                            errorDto = new ErrorDto(ex.Message, false);

                        }


                        var response = Response<NoDataDto>.Fail(errorDto, 500);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });

            });
        }
    }
}
