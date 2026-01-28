using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.SaveToken = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Auth:JWT:ValidIssuer"],
            ValidateLifetime = builder.Configuration.GetValue<bool>("Auth:JWT:ValidateLifetime", true),
            ValidateAudience = builder.Configuration.GetValue<bool>("Auth:JWT:ValidateAudience", true),
            ValidAudience = builder.Configuration["Auth:Jwt:ValidAudience"],
            ClockSkew = TimeSpan.Zero,
            IncludeTokenOnFailedValidation = builder.Configuration.GetValue<bool>("Auth:JWT:IncludeTokenOnFailedValidation", false),
            ValidateIssuerSigningKey = builder.Configuration.GetValue<bool>("Auth:JWT:ValidateIssuerSigningKey", true),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth:JWT:SigningKey"])),
            RequireAudience = builder.Configuration.GetValue<bool>("Auth:JWT:RequireAudience", true),
            RequireExpirationTime = builder.Configuration.GetValue<bool>("Auth:JWT:RequireExpirationTime", true),
            RequireSignedTokens = builder.Configuration.GetValue<bool>("Auth:JWT:RequireSignedTokens", true),
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception != null && context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.StatusCode = 401;
                    context.Response.Headers.Add("Status", "tokenlifetimeexpired");
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "Best Food Ordering App"
    });
});

var appConnectionString = builder.Configuration.GetConnectionString("App")
    ?? throw new InvalidOperationException("Connection string 'App' was not found");

var authConnectionString = builder.Configuration.GetConnectionString("Auth")
    ?? throw new InvalidOperationException("Connection string 'Auth' was not found");

builder.Services.AddData(appConnectionString, authConnectionString);

builder.Services.AddServices();

builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Best Food Ordering App v1");
        options.RoutePrefix = "";
    });
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionFeature?.Error;

        var logger = context.RequestServices
            .GetRequiredService<ILogger<Program>>();

        logger.LogError(exception, "Unhandled exception occurred while processing request: {Path}",
            context.Request.Path);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";

        var problem = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            Detail = "An unexpected error occurred. Please try again later.",
            Instance = context.Request.Path
        };
        await context.Response.WriteAsJsonAsync(problem);
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
