﻿namespace KopiusLibrary.Model.Entities
{
    public class AuthorBook : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
