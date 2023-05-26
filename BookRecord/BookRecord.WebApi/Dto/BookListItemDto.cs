using BookRecord.Domain.Model;

namespace BookRecord.WebApi.Dto;

public class BookListItemDto
{
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }

    public BookListItemDto(Book book)
    {
        Id = book.Id;
        Isbn = book.Isbn;
        Title=book.Title;
        Genre = book.Genre?.Name ?? string.Empty;
    }
}