using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Schgakko.src.Product.Domain.Repositories;
using Schgakko.src.Product.Domain.Services;
using Schgakko.src.Product.Infraestructure.Repositories;
using Schgakko.src.Product.Infraestructure.Services;
using Schgakko.src.Security.Domain.Model.Enum;
using Schgakko.src.Security.Domain.Repositories;
using Schgakko.src.Security.Domain.Services;
using Schgakko.src.Security.Infraestructure.Repositories;
using Schgakko.src.Security.Infraestructure.Services;
using Schgakko.src.Shared.Application.Abstractions;
using Schgakko.src.Shared.Domain.Repositories;
using Schgakko.src.Shared.Infraestructure;
using Schgakko.src.Shared.Infraestructure.Authentication;
using Schgakko.src.Shared.Infraestructure.Repository;
using Swashbuckle.AspNetCore.Filters;

namespace Schgakko
{
    public class StartUp
    {
        public IConfiguration configuration { get; }

        public StartUp(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection service)
        {
            service.AddDbContext<DataBaseContext>(options =>
            {
                options.UseInMemoryDatabase("asd");
            });

            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<ICompanyRepository, CompanyRepository>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
            service.AddScoped<IItemRepository, ItemRepository>();

            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<IAuthenticateService, AuthenticateService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IJwtProvider, JwtProvider>();
            service.AddScoped<IItemService, ItemService>();

            service.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Authorization header using the bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    JwtOptions jwtoptions = configuration.GetSection("Jwt").Get<JwtOptions>();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtoptions.Issuer,
                        ValidAudience = jwtoptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey))
                    };
                });
            service.AddAuthorization(options =>
            {
                options.AddPolicy(Role.Admin, policy => policy.RequireClaim("Role", Role.Admin));
                options.AddPolicy(Role.Customer, policy => policy.RequireClaim("Role", Role.Customer));
                options.AddPolicy(Role.Company, policy => policy.RequireClaim("Role", Role.Company));
            });
            service.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}