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
    }
}