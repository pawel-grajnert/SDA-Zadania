namespace BookRecord.Domain.Model;

public class Genre : EntityBase
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}