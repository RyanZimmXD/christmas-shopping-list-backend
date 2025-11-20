using Microsoft.EntityFrameworkCore;
using shopping_list_backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ShoppingListDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var AllowLocalHost3000Origin = "_allowLocalhost3000";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowLocalHost3000Origin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowLocalHost3000Origin);

app.UseAuthorization();

app.MapControllers();

app.Run();
