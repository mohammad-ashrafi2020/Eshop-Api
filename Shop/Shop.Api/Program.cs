using AspNetCoreRateLimit;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.AspNetCore;
using Common.AspNetCore.Middlewares;
using Common.Domain.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Shop.Api.Infrastructure;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Config;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(option =>
    {
        option.InvalidModelStateResponseFactory = (context =>
        {
            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new()
                {
                    AppStatusCode = AppStatusCode.BadRequest,
                    Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
                }
            };
            var json = JsonConvert.SerializeObject(result);
            throw new BadRequestException(JoinErrors(context.ModelState));
        });
    });
string JoinErrors(ModelStateDictionary modelState)
{
    var errors = new Dictionary<string, List<string>>();

    if (!modelState.IsValid)
    {
        if (modelState.ErrorCount > 0)
        {
            for (int i = 0; i < modelState.Values.Count(); i++)
            {
                var key = modelState.Keys.ElementAt(i);
                var value = modelState.Values.ElementAt(i);

                if (value.ValidationState == ModelValidationState.Invalid)
                {
                    errors.Add(key, value.Errors.Select(x => string.IsNullOrEmpty(x.ErrorMessage) ? x.Exception?.Message : x.ErrorMessage).ToList());
                }
            }
        }
    }
    var error = string.Join(" ", errors.Select(x => $"{string.Join(" - ", x.Value)}"));
    return error;
}
builder.Services.AddDistributedMemoryCache();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter Token",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.RegisterShopDependency(connectionString);
builder.Services.RegisterApiDependency(builder.Configuration);

CommonBootstrapper.Init(builder.Services);
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

//
var dataSeeder = app.Services.GetRequiredService<DataSeeder>();
await dataSeeder.SeedData();
//
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("ShopApi");
app.UseAuthentication();
app.UseAuthorization();

app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
