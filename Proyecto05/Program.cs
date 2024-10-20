using Microsoft.EntityFrameworkCore;
using Proyecto03.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
/******************/
/*** JSON Patch ***/
    .AddNewtonsoftJson()
/******************/
/******************/
;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*******************/
/*** Contexto BD ***/
builder.Services.AddDbContext<ServiciosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
/*******************/
/*******************/

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "permite-front",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("permite-front");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
