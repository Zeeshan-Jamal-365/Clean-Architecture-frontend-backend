using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Taskmanagement.Frontend.Models;

public class Customer
{
    public int Id { get; set; }
    [DisplayName("Customer Name"), Required, MaxLength(50)]
    public string CustomerName { get; set; } = string.Empty;
    [DisplayName("Customer City"), Required, MaxLength(50)]
    public string CustomerCity { get; set; } = string.Empty;
    [DisplayName("Customer Phone"), Required, MaxLength(50)]
    public string CustomerPhone { get; set; } = string.Empty;
}
