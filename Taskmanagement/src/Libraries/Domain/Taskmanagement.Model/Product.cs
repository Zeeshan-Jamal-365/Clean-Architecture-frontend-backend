using Taskmanagement.Shared.Common;

namespace Taskmanagement.Model;
public class Product : BaseEntity, IEntity
{
    
    public string? ProductName { get; set; }
    
    public double ProductPrice { get; set; }
    
    public string? ProductModel { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; }
}
