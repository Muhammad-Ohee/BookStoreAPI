using BookStoreAPI.Data;
using BookStoreAPI.Helpers;
using BookStoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Reading from configuration
var connectionString = builder.Configuration.GetConnectionString("BookStoreDB");
builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server=.;Database=BookStoreAPI;Integrated Security=True"));

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddTransient<IBookRepository, BookRepository>();

builder.Services.AddAutoMapper(typeof(ApplicationMapper).Assembly);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
