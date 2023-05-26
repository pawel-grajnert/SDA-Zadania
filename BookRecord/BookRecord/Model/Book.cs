namespace BookRecord.Domain.Model;

public class Book : EntityBase
{
    public int Id { get; set; }

    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }


    public Genre Genre { get; set; }
    public int GenreId { get; set; }
    public Author Author { get; set; }
    public int AuthorId { get; set; }
}