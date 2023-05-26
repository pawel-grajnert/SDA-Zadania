namespace BookRecord.Domain.Model;

public class EntityBase
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastModifyDate { get; set; }
}