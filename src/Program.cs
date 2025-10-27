using BugStore.Data;
using BugStore.Endpoints;
using BugStore.Handlers.Customers;
using BugStore.Handlers.Products;
using BugStore.Interfaces.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICustomerHandler, CustomerHandler>();
builder.Services.AddScoped<IProductHandler, ProductHandler>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapEndpoints();

//app.MapGet("/", () => "Hello World!");

//app.MapGet("/v1/customers", () => "Hello World!");
//app.MapGet("/v1/customers/{id}", () => "Hello World!");
//app.MapPost("/v1/customers", () => "Hello World!");
//app.MapPut("/v1/customers/{id}", () => "Hello World!");
//app.MapDelete("/v1/customers/{id}", () => "Hello World!");

//app.MapGet("/v1/products", () => "Hello World!");
//app.MapGet("/v1/products/{id}", () => "Hello World!");
//app.MapPost("/v1/products", () => "Hello World!");
//app.MapPut("/v1/products/{id}", () => "Hello World!");
//app.MapDelete("/v1/products/{id}", () => "Hello World!");

//app.MapGet("/v1/orders/{id}", () => "Hello World!");
//app.MapPost("/v1/orders", () => "Hello World!");

app.Run();
