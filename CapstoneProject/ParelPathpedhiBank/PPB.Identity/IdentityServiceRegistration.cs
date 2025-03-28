using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PPB.Domain.Models;
using PPB.Identity.Context;
using PPB.Identity.Service;

namespace PPB.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<PPBDBIdentityContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("PPBDBConnString")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<PPBDBIdentityContext>()
                .AddDefaultTokenProviders();
            //services.AddTransient<IAuthService, AuthService>();
            //services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuerSigningKey = true,
            //    ValidateIssuer = true,
            //    ValidateAudience = true,
            //    ValidateLifetime = true,
            //    ValidIssuer = configuration["JwtSettings:Issuer"],
            //    ValidAudience = configuration["JwtSettings:Audience"],
            //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            //});
            return services;
        }
    }
}
