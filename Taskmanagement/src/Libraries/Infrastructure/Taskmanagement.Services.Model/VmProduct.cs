using System.Text.Json.Serialization;
using Taskmanagement.Shared.Common;

namespace Taskmanagement.Services.Model;
public class VmProduct : IVm
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public double ProductPrice { get; set; }
    public string? ProductModel { get; set; }

    public int CustomerId { get; set; }
    
    public VmCustomer? Customer { get; set; }
}
