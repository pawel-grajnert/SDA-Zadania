namespace BookRecord.Domain.Model;

public class Author : EntityBase
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<Book> Books { get; set; }
}