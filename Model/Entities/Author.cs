﻿using System.Text.Json.Serialization;

namespace KopiusLibrary.Model.Entities
{
    public class Author
    {
        public Guid Id { get; set; } 
        public string Bio { get; set; }
        public string  Name { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime DeathDate { get; set; }

        public ICollection<AuthorBook> AuthorBook { get; set; }

    }
}
