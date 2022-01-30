using AccountInformationService.API.Middleware;
using AccountInformationService.Application.Interfaces;
using AccountInformationService.Application.Services;
using AccountInformationService.Core.Interfaces;
using AccountInformationService.Infrastructure.Data;
using AccountInformationService.Infrastructure.Repositories;
using Hellang.Middleware.ProblemDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var path = Directory.GetCurrentDirectory();

builder.Host.UseSerilog((ctx, Ic) => Ic.WriteTo.File($"{path}\\Logs\\Log.txt"));

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Identity Service API",
        Version = "v1",
        Description = "Identity Service API"
    });

    gen.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "bearer",
        Description = "Please enter userdetails encoded string"
    });

    gen.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
});
builder.Services.AddAuthentication(CustomTokenAuthOptions.DefaultScheme)
                .AddScheme<CustomTokenAuthOptions, CustomTokenAuthHandler>(
                 CustomTokenAuthOptions.DefaultScheme, opt =>
                  {

                  }
                 );

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddProblemDetails(opt =>
{
    opt.IncludeExceptionDetails = (ctx, ex) =>
    {
        return builder.Environment.IsDevelopment() || builder.Environment.IsStaging();
    };
});

builder.Services.AddControllers();

builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IClient, ClientRepository>();

builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IAuthentication, AuthenticationRepository>();

builder.Services.AddTransient<IAccountDetailsService, AccountDetailsService>();
builder.Services.AddTransient<IAccountDetails, AccountDetailsRepository>();

builder.Services.AddDbContext<AccountServiceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
