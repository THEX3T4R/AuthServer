using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Configurations;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Extensions
{
    public static class CustomTokenAuth
    {

        public static void AddCustomTokenAuth(this IServiceCollection services, CustomTokenOption customTokenOption)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                //var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOption>();

                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = customTokenOption.Issuer,
                    ValidAudience = customTokenOption.Audience[0],
                    IssuerSigningKey = SignService.GetSymmetricSecurityKey(customTokenOption.SecurityKey),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
