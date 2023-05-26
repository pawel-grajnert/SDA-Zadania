using BookRecord.Domain.Model;

namespace BookRecord.Repository;

public static class InitialData
{
    public static List<Book> Books => new()
    {
        new Book() {Id = 1, AuthorId = 1, Description = "Lorem ipsum srata tata...", GenreId = 1, CreationDate = new DateTime(2021, 5, 17), Isbn = "ISBN 9995554444", Title = "Stary Dom"},
        new Book() {Id = 2, AuthorId = 2, Description = "Lorem ipsum srata tata...", GenreId = 1, CreationDate = new DateTime(2022, 10, 5), Isbn = "ISBN 1112223333", Title = "Pośród Drzew"},
        new Book() {Id = 3, AuthorId = 3, Description = "Lorem ipsum srata tata...", GenreId = 2, CreationDate = new DateTime(2020, 1, 21), Isbn = "ISBN 5554442222", Title = "Czarna Kawa"},
        new Book() {Id = 4, AuthorId = 4, Description = "Lorem ipsum srata tata...", GenreId = 3, CreationDate = new DateTime(2020, 1, 21), Isbn = "ISBN 6475485585", Title = "Wraki czasu"},
    };

    public static List<Author> Authors => new()
    {
        new Author() { Id = 1, CreationDate = new DateTime(2019, 5, 10), Name = "Andrew", Surname = "Servantes"},
        new Author() { Id = 2, CreationDate = new DateTime(2019, 5, 10), Name = "Conrad", Surname = "Zimsky"},
        new Author() { Id = 3, CreationDate = new DateTime(2019, 5, 10), Name = "Agatha", Surname = "Christie"},
        new Author() { Id = 4, CreationDate = new DateTime(2019, 5, 10), Name = "Claude", Surname = "Experoxue"},
        new Author() { Id = 5, CreationDate = new DateTime(2019, 5, 10), Name = "Vittoria", Surname = "Malisen"},
        new Author() { Id = 6, CreationDate = new DateTime(2019, 5, 10), Name = "Debra", Surname = "Lothsori"},
    };

    public static List<Genre> Genres => new()
    {
        new Genre() {Id = 1, Name = "Horror"},
        new Genre() {Id = 2, Name = "Criminal"},
        new Genre() {Id = 3, Name = "Drama"},
        new Genre() {Id = 4, Name = "Romance"},
        new Genre() {Id = 5, Name = "Epic Tale"},
    };
}