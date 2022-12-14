using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CMS.JWT1.Providers;
using CMS.JWT1.Interfaces;
using CMS.Policy1;
using System.Security.Claims;

namespace CMS.JWT1.Extensions
{

    public static class ServiceExtensions
        {
            public static IServiceCollection RegisterServices(this IServiceCollection services)
            {
                services.AddSingleton<IAuthRepository, AuthRepository>();
                services.AddSingleton<ITokenManager, TokenManager>();
                return services;
            }

            public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection services)
            {
                var builder = services.AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                });

                builder.AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(TokenConstants.key)),
                        ValidIssuer = TokenConstants.Issuer,
                        ValidAudience = TokenConstants.Audience
                    };
                });

                return services;
            }

            public static IServiceCollection AddRolesAndPolicyAuthorization(this IServiceCollection services)
            {
                services.AddAuthorization(
                    config =>
                    {
                        config.AddPolicy("ShouldBeAReader", options =>
                        {
                            options.RequireAuthenticatedUser();
                            options.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                            options.Requirements.Add(new ShouldBeAReaderRequirement());
                        });

                        // Add a new Policy with requirement to check for Admin
                        config.AddPolicy("ShouldBeAuthorized", options =>
                        {
                            options.RequireAuthenticatedUser();
                            options.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                            options.Requirements.Add(new ShouldBeAnAuthorizedRequirement());
                        });

                        config.AddPolicy("ShouldContainRole", options => options.RequireClaim(ClaimTypes.Role));
                    });

                return services;
            }
        }
    
}
