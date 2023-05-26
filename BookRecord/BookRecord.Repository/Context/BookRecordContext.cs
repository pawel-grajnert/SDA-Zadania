using BookRecord.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BookRecord.Repository.Context;

public class BookRecordContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Author { get; set; }

    public BookRecordContext(DbContextOptions<BookRecordContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Genre>().HasData(InitialData.Genres);
        modelBuilder.Entity<Author>().HasData(InitialData.Authors);
        modelBuilder.Entity<Book>().HasData(InitialData.Books);
    }
}