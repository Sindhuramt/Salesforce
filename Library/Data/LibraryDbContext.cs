using Library.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<TicketMaster> TicketMasters { get; set; }

        public DbSet<TicketStatus> TicketStatuses { get; set; }

        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
