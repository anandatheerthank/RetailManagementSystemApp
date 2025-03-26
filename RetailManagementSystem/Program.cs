using Microsoft.EntityFrameworkCore;
using RetailManagementSystem.Data;
using RetailManagementSystem.Interfaces;
using RetailManagementSystem.Repositories;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddDbContext<RetailContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
 
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<IOrder, OrderRepository>();
 
builder.Services.AddControllers();
 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
var app = builder.Build();
 
// Enable Swagger in both Development and Production
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
});
 
// Redirect root URL to Swagger UI
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }
    await next();
});
 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
 
app.Run();
