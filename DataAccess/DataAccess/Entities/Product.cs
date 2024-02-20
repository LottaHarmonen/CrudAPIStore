namespace DataAccess.Entities;

public class Product
{
    public int Id { get; set; }
    public string Productname { get; set; }
    public string Productdescription { get; set; }
    public decimal Price { get; set; }
    public string ProductCategory { get; set;}

    public List<Customer> Customers { get; set; }
}