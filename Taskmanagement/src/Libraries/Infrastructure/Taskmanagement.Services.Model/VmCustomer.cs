using Taskmanagement.Shared.Common;

namespace Taskmanagement.Services.Model;
public class VmCustomer:IVm
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerCity { get; set; }
    public string? CustomerPhone { get; set; }


}
