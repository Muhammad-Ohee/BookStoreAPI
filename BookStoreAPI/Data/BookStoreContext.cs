﻿using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
            
        }

        public DbSet<Books> Books { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BookStoreAPI;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
