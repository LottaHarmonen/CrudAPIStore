using DataAccess;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("StoreDb");

builder.Services.AddDbContext<StoreContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    }
);


// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


app.Run();