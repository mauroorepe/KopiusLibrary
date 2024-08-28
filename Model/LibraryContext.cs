using KopiusLibrary.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Model
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public  DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentItem> DocumentItems { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Branch>().ToTable("Branch");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Discount>().ToTable("Discount");
            modelBuilder.Entity<Document>().ToTable("Document");
            modelBuilder.Entity<DocumentType>().ToTable("DocumentType");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            modelBuilder.Entity<Price>().ToTable("Price");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<Tax>().ToTable("Tax");
            modelBuilder.Entity<Vendor>().ToTable("Vendor");
            modelBuilder.Entity<BookGenre>().ToTable("BookGenre");
            modelBuilder.Entity<DocumentItem>().ToTable("DocumentItem");
            modelBuilder.Entity<AuthorBook>().ToTable("AuthorBook");

            //modelBuilder.Entity<AuthorBook>()
            //   .HasOne(ab => ab.Author)
            //   .WithMany() 
            //   .HasForeignKey(ab => ab.AuthorId);

            //modelBuilder.Entity<Author>()
            //    .HasMany(a => a.AuthorBooks) 
            //    .WithOne(ab => ab.Author)
            //    .HasForeignKey(ab => ab.AuthorId);

            //modelBuilder.Entity<BookGenre>()
            //    .HasOne(bg => bg.Genre)
            //    .WithMany() 
            //    .HasForeignKey(bg => bg.GenreId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.AuthorBook)
                .WithOne() 
                .HasForeignKey(ab => ab.BookId);

            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });

            modelBuilder.Entity<AuthorBook>()
                .HasOne<Author>()
                .WithMany(a => a.AuthorBook)
                .HasForeignKey(ab => ab.AuthorId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne<Book>()
                .WithMany(b => b.AuthorBook)
                .HasForeignKey(ab => ab.BookId);

            //modelBuilder.Entity<Book>()
            //    .HasMany(b => b.AuthorBook)
            //    .WithMany(a => a.Books)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "AuthorBook",
            //        j => j.HasOne<Author>().WithMany().HasForeignKey("AuthorId"),
            //        j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
            //        j =>
            //        {
            //            j.HasKey("AuthorId", "BookId");
            //    });

            //modelBuilder.Entity<Book>()
            //    .HasMany(b => b.BookGenre)
            //    .WithMany(g => g.Books)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "BookGenre",
            //        j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
            //        j => j.HasOne<Book>().WithMany().HasForeignKey("BookId"),
            //        j =>
            //        {
            //            j.HasKey("GenreId", "BookId");
            //    });

            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.Branch)
            //    .WithMany(br => br.Books)
            //    .HasForeignKey("BranchId");

            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.Publisher)
            //    .WithMany(p => p.Books)
            //    .HasForeignKey("PublisherId");

        }
    }
}
