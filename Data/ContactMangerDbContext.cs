using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class ContactMangerDbContext : DbContext
{
    public ContactMangerDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
}
