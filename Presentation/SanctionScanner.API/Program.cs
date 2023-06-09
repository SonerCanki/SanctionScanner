using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SanctionScanner.API.Middlewares;
using SanctionScanner.Model.Context;
using SanctionScanner.Service.Services.Book;
using SanctionScanner.Service.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

//dependency injection for sql server
builder.Services.AddDbContext<DataContext>
    (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

builder.Services.AddControllers();

//dependency injection for unit of work pattern
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//dependency injection for services
builder.Services.AddScoped<IBookService, BookService>();

//dependency injection for automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//exception logging middleware
app.UseErrorWrappingMiddleware();

app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
