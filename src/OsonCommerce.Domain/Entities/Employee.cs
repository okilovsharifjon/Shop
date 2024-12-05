namespace OsonCommerce.Domain.Entities;

public class Employee : User
{
    public string Position { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Guid> StoreBranchIds { get; set; }
    public ICollection<StoreBranch> StoreBranches { get; set; }
}
           
