using System.Text;
using Shared.Constants;
using Shared.Extensions;
using Shared.AppSettings;
using Ardalis.GuardClauses;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Web.Extensions;

internal static class JwtBearerExtensions
{
    internal static IServiceCollection AddJwtBearer(
        this IServiceCollection services,
        IConfiguration configuration,
        bool isProduction)
    {
        Guard.Against.Null(configuration, nameof(configuration));

        var jwtOptions = configuration.GetOptions<JwtOptions>(AppSettingsKeys.JwtOptions);

        services
            .AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                // RequireHttpsMetadata deve estar sempre habilitado no ambiente de produção.
                bearerOptions.RequireHttpsMetadata = isProduction;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = jwtOptions.Audience,
                    ValidIssuer = jwtOptions.Issuer
                };
            });

        // Ativa o uso do token como forma de autorizar o acesso a recursos deste projeto.
        services.AddAuthorization(authOptions =>
        {
            authOptions.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build());
        });

        return services;
    }
}