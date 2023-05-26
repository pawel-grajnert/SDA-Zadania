using BookRecord.Domain.Model;

namespace BookRecord.WebApi.Dto;

public class BookEditDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int GenreId { get; set; }

    public Book AsBook()
    {
        var book = new Book();

        book.Id = Id;
        book.Description = Description;
        book.GenreId = GenreId;
        
        return book;
    }
}