using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.AspNetCore;
using Common.AspNetCore.Middlewares;
using Microsoft.AspNetCore.Mvc;
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
            return new BadRequestObjectResult(result);
        });
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.RegisterShopDependency(connectionString);
CommonBootstrapper.Init(builder.Services);
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCors("ShopApi");
app.UseAuthentication();
app.UseAuthorization();

app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
