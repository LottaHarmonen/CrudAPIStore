namespace DataAccess.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Adress { get; set; }

    public List<Product> Products { get; set; }
}