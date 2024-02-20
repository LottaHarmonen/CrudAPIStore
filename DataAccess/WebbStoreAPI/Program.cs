using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("StoreDb");

builder.Services.AddDbContext<StoreContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    }
);


var app = builder.Build();

app.MapGet("/customers", (StoreContext context)
    =>
{
    return context.Customer;
});

app.MapGet("/products", (StoreContext context)
    =>
{
    return context.Product;
});

app.MapPost("/customers", (StoreContext context, Customer customer)
    =>
{
    context.Add(customer);
    context.SaveChanges();
});

app.MapPost("/products", (StoreContext context, Product product)
    =>
{
    context.Add(product);
    context.SaveChanges();
});

app.MapPut("/products/{id}", (StoreContext context, Product product, int id)
    =>
{
    var productToUpdate = context.Product.FirstOrDefault(p => p.Id == id); 

    productToUpdate.ProductName = product.ProductName;
    productToUpdate.Price = product.Price;
    productToUpdate.ProductCategory = product.ProductCategory;
    productToUpdate.ProductDescription = product.ProductDescription;

    context.SaveChanges();
});

app.MapPut("/customers/{id}", (StoreContext context, Customer customer, int id)
    =>
{
    var customerToUpdate = context.Customer.FirstOrDefault(c => c.Id == id);

    customerToUpdate.FirstName = customer.FirstName;
    customerToUpdate.Surname = customer.Surname;
    customerToUpdate.Adress = customer.Adress;
    customerToUpdate.Email = customer.Email;
    customerToUpdate.Phone = customer.Phone;

    context.SaveChanges();
});

app.MapPatch("/customers/{id}", (StoreContext context, int id, string property, string value)
    =>
{
    var customerToUpdate = context.Customer.FirstOrDefault(c => c.Id == id);

    var propertyInfo = customerToUpdate.GetType().GetProperty(property);
    propertyInfo.SetValue(customerToUpdate,Convert.ChangeType(value, propertyInfo.PropertyType),null);


    context.SaveChanges();
});

app.MapPatch("/products/{id}", (StoreContext context, int id, string property, string value)
    =>
{
    var productToUpdate = context.Product.FirstOrDefault(c => c.Id == id);

    var propertyInfo = productToUpdate.GetType().GetProperty(property);
    propertyInfo.SetValue(productToUpdate, Convert.ChangeType(value, propertyInfo.PropertyType), null);

    context.SaveChanges();
});


app.MapDelete("/customers/{id}", (StoreContext context, int id)
    =>
{
    var customerToDelete = context.Customer.FirstOrDefault(c => c.Id == id);
    context.Customer.Remove(customerToDelete);

    context.SaveChanges();
});

app.MapDelete("/products/{id}", (StoreContext context, int id)
    =>
{
    var productToDelete = context.Product.FirstOrDefault(p => p.Id == id);
    context.Product.Remove(productToDelete);

    context.SaveChanges();
});

app.Run();