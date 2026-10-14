using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyJWT.Extensions
{
    public static class JwtExtensions
    {
        public static IServiceCollection AddJwtAuth(
       this IServiceCollection services,
       IConfiguration configuration)
        {
            var section = configuration.GetSection("Jwt");

            var key = section["Key"]
                ?? throw new InvalidOperationException("Jwt:Key is missing");

            var issuer = section["Issuer"]
                ?? throw new InvalidOperationException("Jwt:Issuer is missing");

            var audience = section["Audience"]
                ?? throw new InvalidOperationException("Jwt:Audience is missing");

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = issuer,

                            ValidateAudience = true,
                            ValidAudience = audience,

                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(key)),

                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero
                        };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
