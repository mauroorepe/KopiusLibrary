﻿namespace KopiusLibrary.Model.Entities
{
    public class Tax : BaseEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
    }
}
