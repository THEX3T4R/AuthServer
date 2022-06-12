using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Extensions
{
    public static class AddCustomeValidationResponse
    {
        public static void UseCustomeValidationResponse(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = context => {
                    var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(b => b.Errors).Select(q => q.ErrorMessage);

                    ErrorDto errorDto = new ErrorDto(errors.ToList(),true);

                    var response = Response<NoDataDto>.Fail(errorDto, 400);

                    return new BadRequestObjectResult(response);
                };
            });
        }
    }
}
