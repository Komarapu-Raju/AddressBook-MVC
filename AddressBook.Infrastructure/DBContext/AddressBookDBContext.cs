using AddressBook.Data.Models.Contacts;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Infrastructure.DBContext
{
    public class AddressBookDBContext : DbContext
    {
        public AddressBookDBContext(DbContextOptions<AddressBookDBContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
