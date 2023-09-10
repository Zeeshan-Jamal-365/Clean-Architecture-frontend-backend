using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Taskmanagement.Frontend.Models;

public class Product
{
    public int Id { get; set; }
    [DisplayName("Product Name"), Required, MaxLength(50)]
    public string? ProductName { get; set; }
    [DisplayName("Product Price"), Required]
    public double ProductPrice { get; set; }
    [DisplayName("Product Model"), Required, MaxLength(50)]
    public string? ProductModel { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}
