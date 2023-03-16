using AddressBook.Data.Models.Contact;
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
