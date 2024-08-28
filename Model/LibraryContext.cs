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
        }
    }
}
