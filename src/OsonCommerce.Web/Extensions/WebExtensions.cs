using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OsonCommerce.Infrastructure.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace OsonCommerce.Web.Extensions;

public static class WebExtensions
{
    public static void AddWebAuthentication(
        this IServiceCollection services,
        IOptions<JwtOptions> jwtOptions)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey))
                };

                options.Events = new()
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["delicious-cookies"];

                        return Task.CompletedTask;
                    }
                };
            });
    }
}
