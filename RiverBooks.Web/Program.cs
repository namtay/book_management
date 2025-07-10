using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using RiverBooks.Books;
using RiverBooks.Users;
using Serilog;
using System.Reflection;


var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
config.ReadFrom.Configuration(builder.Configuration));


builder.Services.AddFastEndpoints()
      .AddAuthenticationJwtBearer(opt =>
      {
          opt.SigningKey = builder.Configuration["Auth:JwtSecret"]!;
      
      })    
      .AddAuthorization()   
      .SwaggerDocument();

//add module services
List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
builder.Services.AddBookServices(builder.Configuration,logger, mediatRAssemblies);
builder.Services.AddUserModuleServices(builder.Configuration,logger, mediatRAssemblies);

//Set up MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger(opts => {
    //    opts.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    //});
    app.UseSwaggerUI();
}

app.UseAuthentication()
    .UseAuthorization();


app.UseFastEndpoints()
    .UseSwaggerGen(); //define a swagger document;


app.Run();


public partial class Program
{

}
//needed for tests