var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("StoreDb");
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


app.Run();