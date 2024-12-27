using Global.Application.Commands.Handlers.Contact;
using Global.Application.Commands.Handlers.Login;
using Global.Application.Commands.Handlers.Token;
using Global.Application.Commands.Inputs.User;
using Global.Domain.Interfaces;
using Global.Application.Data;
using Global.Application.Repositories;
using Global.Application.Settings;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Global_api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configurações JWT centralizadas
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        // Injeção das configurações diretamente
        services.AddSingleton(sp =>
            sp.GetRequiredService<IOptions<JwtSettings>>().Value);

        // Banco de Dados
        services.AddScoped<IDbConnection>(provider =>
            new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

        services.AddControllers();

        // DbContext
        services.AddSingleton<GlobalDbContext>();

        // Handlers
        services.AddScoped<LoginCommandHandler>();
        services.AddScoped<TokenCommandHandler>();

        services.AddScoped<GetContactCommandHandler>();
        services.AddScoped<CreateContactCommandHandler>();
        services.AddScoped<UpdateContactCommandHandler>();
        services.AddScoped<IRequestHandler<CreateUserSessionCommandInput, int>, CreateUserSessionCommandHandler>();

        // Repositories
        services.AddScoped<IUserSessionRepository, UserSessionRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();

        return services;
    }

    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Global API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Insira o token JWT no campo abaixo",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}