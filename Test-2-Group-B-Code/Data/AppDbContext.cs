using Microsoft.EntityFrameworkCore;
using Test_2_Group_B_Code.Entities;

namespace Test_2_Group_B_Code.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Author>    Authors    { get; set; }
    public DbSet<Book>      Books      { get; set; }
    public DbSet<Member>    Members    { get; set; }
    public DbSet<Borrowing> Borrowings { get; set; }
    public DbSet<Review>    Reviews    { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>()
            .HasKey(r => new { r.MemberId, r.BookId });
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);
        
        modelBuilder.Entity<Borrowing>()
            .HasOne(br => br.Member)
            .WithMany(m => m.Borrowings)
            .HasForeignKey(br => br.MemberId);
        
        modelBuilder.Entity<Borrowing>()
            .HasOne(br => br.Book)
            .WithMany(b => b.Borrowings)
            .HasForeignKey(br => br.BookId);
        
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Member)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MemberId);
        
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BookId);
        
        modelBuilder.Entity<Author>().HasData(
            new Author { AuthorId = 1, FirstName = "Adam", LastName = "Mickiewicz", Country = "Poland", BirthYear = 1798 },
            new Author { AuthorId = 2, FirstName = "Jane", LastName = "Austen", Country = "United Kingdom", BirthYear = 1775 },
            new Author { AuthorId = 3, FirstName = "Gabriel", LastName = "Garcia Marquez", Country = "Colombia", BirthYear = 1927 },
            new Author { AuthorId = 4, FirstName = "Haruki", LastName = "Murakami", Country = "Japan", BirthYear = 1949 }
        );
        
        modelBuilder.Entity<Book>().HasData(
            new Book { BookId = 1, Title = "Pan Tadeusz", ISBN = "9781234567890", PublishedYear = 1834, AuthorId = 1 },
            new Book { BookId = 2, Title = "Pride and Prejudice", ISBN = "9789876543210", PublishedYear = 1813, AuthorId = 2 },
            new Book { BookId = 3, Title = "One Hundred Years of Solitude", ISBN = "9781122334455", PublishedYear = 1967, AuthorId = 3 },
            new Book { BookId = 4, Title = "Norwegian Wood", ISBN = "9785566778899", PublishedYear = 1987, AuthorId = 4 },
            new Book { BookId = 5, Title = "Sense and Sensibility", ISBN = "9783344556677", PublishedYear = 1811, AuthorId = 2 }
        );
    }
}