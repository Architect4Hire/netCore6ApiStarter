using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AspNetCore.Identity.DocumentDb;
using Architect4Hire.netCore6ApiStarterDomainLayer;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer;
using Architect4Hire.netCore6ApiStarterDomainLayer.BusinessLayer;
using Architect4Hire.netCore6ApiStarter.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* CORS*/

builder.Services.AddCors(o => o.AddPolicy(MyAllowSpecificOrigins, builder => {builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();}));

/* END CORS */

/* SWAGGER */

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Architect4Hire Microservice Template", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "JWT",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
});

/* END SWAGGER */

/* REDIS CACHE */

//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = "CACHEKEY";
//});

/* END REDIS CACHE */

/* IDENTITY */

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.ISSUER,
                ValidateAudience = true,
                ValidAudience = AuthOptions.AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        }); ;

/* END IDENTITY */

/* ELMAH.IO */

//builder.Services.AddElmahIo(o =>
//{
//    o.ApiKey = "APIKEY";
//    o.LogId = new Guid("LOGID");
//    o.Application = "SERVICE NAME";
//    o.HandledStatusCodesToLog = new List<int>() { 404};
//});

/* END ELMAH.IO */

/* API VERSIONING */

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

/* END API VERSIONING */

builder.Services.AddTransient<IFacade, Facade>();
builder.Services.AddTransient<IDataLayer, DataLayer>();
builder.Services.AddTransient<IBusinessLayer, BusinessLayer>();
builder.Services.AddResponseCompression();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
var app = builder.Build();
if (app.Environment.IsProduction())
{
    app.UseElmahIo();
};
app.UseCors(MyAllowSpecificOrigins);
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("./swagger/v1/swagger.json", "Architect4Hire Microservice Template");
    c.RoutePrefix = string.Empty;
});
app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
