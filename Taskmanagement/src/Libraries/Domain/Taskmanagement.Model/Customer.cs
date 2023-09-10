using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Taskmanagement.Shared.Common;

namespace Taskmanagement.Model;
public class Customer : BaseEntity, IEntity
{
    
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerCity { get; set; } = string.Empty;
    
    public string CustomerPhone { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; }=new HashSet<Product>();
}
