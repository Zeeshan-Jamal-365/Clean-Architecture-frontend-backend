using Taskmanagement.Shared.Enum;

namespace Taskmanagement.Shared.Common;

public abstract class BaseEntity : IEntity
{ 
    public int Id { get; set; }
    public DateTimeOffset Created { get; set; }= DateTimeOffset.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTimeOffset? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public EntityStatus Status { get;set; }
}

