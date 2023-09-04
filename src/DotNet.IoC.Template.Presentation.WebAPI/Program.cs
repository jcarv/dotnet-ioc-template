using DotNet.IoC.Template.Application.Services.Configuration;
using DotNet.IoC.Template.Data.EFCore.Configuration;
using DotNet.IoC.Template.Infrastructure.CrossCutting.Settings;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.Get<AppSettings>();

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureDataEf(appSettings);
builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// NSwag
builder.Services.AddOpenApiDocument();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseCors("Open");

app.UseAuthorization();

app.MapControllers();

app.Run();
