using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SagitarioRhApi.Aplication;
using SagitarioRhApi.Infraestrutura.Data;
using SagitarioRhApi.Infraestrutura.Interfaces;
using SagitarioRhApi.Infraestrutura.Repositorios;
using SagitarioRhApi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IFuncionario, RepFun>();
builder.Services.AddScoped<IImpostoCalcular, InssCalcular>();
builder.Services.AddAutoMapper(typeof(DomainMapping));



builder.Services.AddDbContext<BancoContext>(options => 
options.UseNpgsql("Host=berry.db.elephantsql.com;Database=cclcbiwm;Username=cclcbiwm;Password=EP_X_koFmXeUspco84FYTUILWgPptiJ_;"));



builder.Services.AddSwaggerGen(c =>
{


    // Define o esquema de segurança JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    // Define os requisitos de segurança para as operações que exigem autenticação JWT
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
            new string[] {}
        }
    });
});





var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Mudar para true em ambiente de produção
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["chaveSecreta"]!)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("FuncionarioPolicy", policy => policy.RequireRole("Funcionario"));
    options.AddPolicy("GerentePolicy", policy => policy.RequireRole("Gerente"));
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
